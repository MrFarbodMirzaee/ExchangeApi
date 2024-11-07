using Exchange.gRPCServer.Protos;
using Google.Protobuf;
using Grpc.Core;
using Grpc.Net.Client;
using System.Diagnostics;
using System.Reflection;
using static Exchange.gRPCServer.Protos.CurrencyFileStreaming;
using static Exchange.gRPCServer.Protos.CurrencyRepository;
using static Exchange.gRPCServer.Protos.CurrencyStreamRepository;

namespace Exchange.gRPCClient;
internal class Program
{
    static async Task Main(string[] args)
    {
        string address = "https://localhost:7219";
        var channel = GrpcChannel.ForAddress(address);

        while (true)
        {
            try
            {
                Console.WriteLine("You want get currency by id or add currency or delete currency or update currency" +
                    " or currency image or currency Stream. if you want 'get currency by id' or 'add currency'" +
                    " or 'delete currency' or 'update currency' or type 'currency image' or 'download file' or 'list files' or 'currency stream'");
                string selectedUser = Console.ReadLine();
                if (selectedUser == "get currency by id")
                {
                    var client = new CurrencyRepositoryClient(channel);
                    GetCurrencyBYIdData(client);
                }
                else if (selectedUser == "add currency")
                {
                    var client = new CurrencyRepositoryClient(channel);
                    AddCurrencyData(client);
                }
                else if (selectedUser == "delete currency")
                {
                    var client = new CurrencyRepositoryClient(channel);
                    DeleteCurrencyBYIdData(client);
                }
                else if (selectedUser == "update currency")
                {
                    var client = new CurrencyRepositoryClient(channel);
                    UpdateCurrencyBYIdData(client);
                }
                else if (selectedUser == "currency image")
                {
                    var client = new CurrencyFileStreamingClient(channel);
                    Console.WriteLine("Enter the full path to the file you want to upload:");
                    var filePath = Console.ReadLine();
                    await UploadFileAsync(client, filePath);
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
                    GetAllCurrrencyStreamAsync(client);
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
    }

    private static async Task DownloadFile(DownloadFileStreaming.DownloadFileStreamingClient client, int fileId)
    {
        // Get the user's Downloads folder path.
        string downloadsFolder = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), "Downloads");

        // Ensure the directory exists.
        if (!Directory.Exists(downloadsFolder))
        {
            Directory.CreateDirectory(downloadsFolder);
        }

        // Start the download request using the fileId.
        using var call = client.DownloadFileById(new FileRequestById { Id = fileId });

        try
        {
            // Assuming the server sends the file name with the correct extension.
            string fileName = "file_" + fileId;  // You can modify this if the server returns a file name.
            string fileExtension = ".bin";  // Default extension, in case the server doesn't return it.

            // Read the first chunk to get the file name and extension (if the server provides it).
            if (await call.ResponseStream.MoveNext(CancellationToken.None))
            {
                var chunk = call.ResponseStream.Current;

                // Assuming the server sends the file name with extension in the metadata (adjust if needed)
                if (!string.IsNullOrEmpty(chunk.FileName))
                {
                    fileName = Path.GetFileNameWithoutExtension(chunk.FileName); // Extract the base file name
                    fileExtension = Path.GetExtension(chunk.FileName); // Extract the file extension
                }

                // Create the file path using the original file name and extension.
                string outputPath = Path.Combine(downloadsFolder, fileName + fileExtension);

                // Create a FileStream to save the received chunks.
                await using var fileStream = new FileStream(outputPath, FileMode.Create, FileAccess.Write);

                // Write the first chunk (already fetched) to the file.
                await fileStream.WriteAsync(chunk.Content.ToByteArray());

                // Process the remaining chunks as they come in from the server.
                while (await call.ResponseStream.MoveNext(CancellationToken.None))
                {
                    var nextChunk = call.ResponseStream.Current;

                    // Write the next chunk to the file.
                    await fileStream.WriteAsync(nextChunk.Content.ToByteArray());

                    // Optionally, log the progress.
                    Console.WriteLine($"Downloaded {nextChunk.ChunkSize} bytes...");
                }

                // When all chunks have been received and written to the file, display a success message.
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

    public static async Task UploadFileAsync(CurrencyFileStreamingClient client, string filePath)
    {
        if (string.IsNullOrWhiteSpace(filePath) || !File.Exists(filePath))
        {
            Console.WriteLine("Invalid file path. Please provide a valid file.");
            return;
        }

        var allowedExtensions = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
    {
        ".jpg", ".jpeg", ".png", ".bmp", ".txt"  // Add more extensions as needed
    };

        var fileName = Path.GetFileName(filePath);
        var fileExtension = Path.GetExtension(filePath);

        if (!allowedExtensions.Contains(fileExtension))
        {
            Console.WriteLine($"Invalid file extension '{fileExtension}'. Allowed extensions are: {string.Join(", ", allowedExtensions)}.");
            return;
        }

        var fileBytes = await File.ReadAllBytesAsync(filePath);
        var chunkSize = 1024 * 64; // 64KB

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

                Console.WriteLine($"Uploaded {Math.Min(i + chunkSize, fileBytes.Length)} of {fileBytes.Length} bytes...");
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

    public static async Task GetCurrencyBYIdData(CurrencyRepositoryClient client)

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
    public static async Task AddCurrencyData(CurrencyRepositoryClient client)
    {
        try
        {
            Console.WriteLine("Please Enter Currency Code");
            string currencyCode = Console.ReadLine();
            Console.WriteLine("Please Enter Price");
            double price = double.Parse(Console.ReadLine());
            var request = new AddCurrencyRequestDto()
            {
                CurrencyCode = currencyCode,
                Price = price
            };
            var send = await client.AddCurrencyAsync(request);
            Console.WriteLine($"send was succesfuly");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
    public static async Task DeleteCurrencyBYIdData(CurrencyRepositoryClient client)
    {
        try
        {
            Console.WriteLine("Please Enter Currency Id");
            int Id = Convert.ToInt32(Console.ReadLine());

            var request = new DeleteCurrencyRequestDto()
            {
                Id = Id
            };
            var send = await client.DeleteCurrencyAsync(request);
            Console.WriteLine($"{send} deleted succesfuly");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
    public static async Task UpdateCurrencyBYIdData(CurrencyRepositoryClient client)
    {
        try
        {
            Console.WriteLine("Please Enter Id");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Please Enter Currency Code and remember it has to be 3 character");
            string currencyCode = Console.ReadLine();
            Console.WriteLine("Please Enter Price");
            double price = double.Parse(Console.ReadLine());
            var request = new UpdateCurrencyRequestDto()
            {
                Id = id,
                Price = price,
                CurrencyCode = currencyCode,
            };

            var send = await client.UpdateCurrencyAsync(request);
            Console.WriteLine("Updated succesfuly");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
        }
    }
    public static async Task GetAllCurrrencyStreamAsync(CurrencyStreamRepositoryClient client)
    {
        using var call = client.GetAllCurrrency(new GetCurrencyStraminRequestDto { Input = new Google.Protobuf.WellKnownTypes.Empty() });
        var sp = Stopwatch.StartNew();

        await foreach (var currencyData in call.ResponseStream.ReadAllAsync())
        {
            Console.WriteLine($"Currrency Id is : {currencyData.Id} with Currrency Code {currencyData.CurrencyCode} And {currencyData.Price}");
        }

        sp.Stop();
        Console.WriteLine($"Streaming ended in {sp.Elapsed.TotalSeconds} seconds");
    }

}