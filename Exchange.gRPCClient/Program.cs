using Exchange.gRPCServer.Protos;
using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using System.Diagnostics;
using static Exchange.gRPCServer.Protos.CurrencyFileStreaming;
using static Exchange.gRPCServer.Protos.CurrencyRepository;
using static Exchange.gRPCServer.Protos.CurrencyStreamRepository;

const string address = "https://localhost:7219";
var channel = GrpcChannel.ForAddress(address);

while (true)
{
    try
    {
        Console.WriteLine("You want get currency by id or add currency or delete currency or update currency" +
                          " or currency image or currency Stream. if you want 'get currency by id' or 'add currency'" +
                          " or 'delete currency' or 'update currency' or type 'upload image' or 'download file' or 'list files' or 'currency stream'");
        string selectedUser = Console.ReadLine() ?? throw new InvalidOperationException();
        if (selectedUser == "get currency by id")
        {
            var client = new CurrencyRepositoryClient(channel);
            await GetCurrencyByIdData(client);
        }
        else if (selectedUser == "add currency")
        {
            var client = new CurrencyRepositoryClient(channel);
            await AddCurrencyData(client);
        }
        else if (selectedUser == "delete currency")
        {
            var client = new CurrencyRepositoryClient(channel);
            await DeleteCurrencyByIdData(client);
        }
        else if (selectedUser == "update currency")
        {
            var client = new CurrencyRepositoryClient(channel);
            await UpdateCurrencyByIdData(client);
        }
        else if (selectedUser == "list files")
        {
            var client = new FileService.FileServiceClient(channel);
            Console.WriteLine("All files:");
            await GetAllFiles(client);
        }
        else if (selectedUser == "upload image")
        {
            var client = new CurrencyFileStreamingClient(channel);
            Console.WriteLine("Enter the full path to the file you want to upload:");
            var filePath = Console.ReadLine();
            if (filePath != null) await UploadFileAsync(client, filePath);
        }
        else if (selectedUser == "download file")
        {
            var client = new DownloadFileStreaming.DownloadFileStreamingClient(channel);
            Console.WriteLine("Enter the fileId");
            var fileId = Convert.ToInt32(Console.ReadLine());
            await DownloadFile(client, fileId);
        }
        else if (selectedUser == "currency stream")
        {
            var client = new CurrencyStreamRepositoryClient(channel);
            await GetAllCurrencyStreamAsync(client);
        }
        else
        {
            Console.WriteLine("Please Enter the correct format");
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"The error is {ex.Message}");
    }
}


static async Task GetAllFiles(FileService.FileServiceClient client)
{
    var request = new Empty();

    try
    {
        using var call = client.GetAllFiles(request);

        await foreach (var fileMetadata in call.ResponseStream.ReadAllAsync())
        {
            Console.WriteLine(
                $"File Name: {fileMetadata.FileName} Kind :{fileMetadata.FileExtension} FileSize: {fileMetadata.FileSize}");
            Console.WriteLine("_______________");
        }
    }
    catch (RpcException ex)
    {
        Console.WriteLine($"gRPC Error: {ex.Status.Detail}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Error: {ex.Message}");
    }
}

static async Task DownloadFile(DownloadFileStreaming.DownloadFileStreamingClient client, int fileId)
{
    string downloadsFolder =
        Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Downloads");

    if (!Directory.Exists(downloadsFolder))
    {
        Directory.CreateDirectory(downloadsFolder);
    }

    using var call = client.DownloadFileById(new FileRequestById { Id = fileId });

    try
    {
        string fileName = "file_" + fileId;
        string fileExtension = ".bin";

        if (await call.ResponseStream.MoveNext(CancellationToken.None))
        {
            var chunk = call.ResponseStream.Current;

            if (!string.IsNullOrEmpty(chunk.FileName))
            {
                fileName = Path.GetFileNameWithoutExtension(chunk.FileName);
                fileExtension = Path.GetExtension(chunk.FileName);
            }

            string outputPath = Path.Combine(downloadsFolder, fileName + fileExtension);

            await using var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

            await fileStream.WriteAsync(chunk.Content.ToByteArray());

            while (await call.ResponseStream.MoveNext(CancellationToken.None))
            {
                var nextChunk = call.ResponseStream.Current;

                await fileStream.WriteAsync(nextChunk.Content.ToByteArray());

                Console.WriteLine($"Downloaded {nextChunk.ChunkSize} bytes...");
            }

            Console.WriteLine($"File downloaded successfully to {outputPath}");
        }
    }
    catch (RpcException ex)
    {
        Console.WriteLine($"gRPC Error: {ex.Status.Detail}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

static async Task UploadFileAsync(CurrencyFileStreamingClient client, string filePath)
{
    if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
    {
        Console.WriteLine("Invalid file path. Please provide a valid file.");
        return;
    }

    var allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".bmp", ".txt"
    };

    var fileName = Path.GetFileName(filePath);
    var fileExtension = Path.GetExtension(filePath);

    if (!allowedExtensions.Contains(fileExtension))
    {
        Console.WriteLine(
            $"Invalid file extension '{fileExtension}'. Allowed extensions are: {string.Join(", ", allowedExtensions)}.");
        return;
    }

    var fileBytes = await File.ReadAllBytesAsync(filePath);
    var chunkSize = 1024 * 64;

    using var call = client.UploadFile();

    try
    {
        Console.WriteLine($"Starting upload for {fileName} ({fileBytes.Length} bytes)...");

        for (int i = 0; i < fileBytes.Length; i += chunkSize)
        {
            var chunk = fileBytes.Skip(i).Take(chunkSize).ToArray();
            await call.RequestStream.WriteAsync(new FileChunk
            {
                Content = ByteString.CopyFrom(chunk),
                FileName = fileName,
                FileSize = fileBytes.Length
            });

            Console.WriteLine(
                $"Uploaded {Math.Min(i + chunkSize, fileBytes.Length)} of {fileBytes.Length} bytes...");
        }

        await call.RequestStream.CompleteAsync();

        var response = await call.ResponseAsync;
        Console.WriteLine($"Upload status: {response.Message}");
    }
    catch (RpcException ex)
    {
        Console.WriteLine($"gRPC Error: {ex.Status.Detail}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"An error occurred: {ex.Message}");
    }
}

static async Task GetCurrencyByIdData(CurrencyRepositoryClient client)

{
    try
    {
        Console.WriteLine("Please Enter Your Currency Id ");
        int id = Convert.ToInt32(Console.ReadLine());

        var request = new GetCurrencyByIdRequestDto
        {
            Id = id
        };

        var response = await client.GetCurrencyByIdAsync(request);
        Console.WriteLine($"The currency code is {response.CurrencyCode} and the price is {response.Price}");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"The Error is {ex.Message}");
    }
}

static async Task AddCurrencyData(CurrencyRepositoryClient client)
{
    try
    {
        Console.WriteLine("Please Enter Currency Code");
        string currencyCode = Console.ReadLine() ?? throw new InvalidOperationException();
        Console.WriteLine("Please Enter Price");
        double price = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        var request = new AddCurrencyRequestDto()
        {
            CurrencyCode = currencyCode,
            Price = price
        };
        var send = await client.AddCurrencyAsync(request);
        Console.WriteLine($"{send} was successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}

static async Task DeleteCurrencyByIdData(CurrencyRepositoryClient client)
{
    try
    {
        Console.WriteLine("Please Enter Currency Id");
        int id = Convert.ToInt32(Console.ReadLine());

        var request = new DeleteCurrencyRequestDto()
        {
            Id = id
        };
        var send = await client.DeleteCurrencyAsync(request);
        Console.WriteLine($"{send} deleted successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}

static async Task UpdateCurrencyByIdData(CurrencyRepositoryClient client)
{
    try
    {
        Console.WriteLine("Please Enter Id");
        int id = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Please Enter Currency Code and remember it has to be 3 character");
        string currencyCode = Console.ReadLine() ?? throw new InvalidOperationException();
        Console.WriteLine("Please Enter Price");
        double price = double.Parse(Console.ReadLine() ?? throw new InvalidOperationException());
        var request = new UpdateCurrencyRequestDto()
        {
            Id = id,
            Price = price,
            CurrencyCode = currencyCode,
        };

        var send = await client.UpdateCurrencyAsync(request);
        Console.WriteLine($"Updated {send} successfully");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"{ex.Message}");
    }
}

static async Task GetAllCurrencyStreamAsync(CurrencyStreamRepositoryClient client)
{
    using var call = client.GetAllCurrrency(new GetCurrencyStraminRequestDto
        { Input = new Google.Protobuf.WellKnownTypes.Empty() });
    var sp = Stopwatch.StartNew();

    await foreach (var currencyData in call.ResponseStream.ReadAllAsync())
    {
        Console.WriteLine(
            $"Currency Id is : {currencyData.Id} with Currency Code {currencyData.CurrencyCode} And {currencyData.Price}");
    }

    sp.Stop();
    Console.WriteLine($"Streaming ended in {sp.Elapsed.TotalSeconds} seconds");
}