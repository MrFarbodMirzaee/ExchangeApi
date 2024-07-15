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
                    " or 'delete currency' or 'update currency' or type 'currency image' or 'currency stream'");
                string selecteduser = Console.ReadLine();
                if (selecteduser == "get currency by id")
                {
                    var client = new CurrencyRepositoryClient(channel);
                    GetCurrencyBYIdData(client);
                }
                else if (selecteduser == "add currency")
                {
                    var client = new CurrencyRepositoryClient(channel);
                    AddCurrencyData(client);
                }
                else if (selecteduser == "delete currency")
                {
                    var client = new CurrencyRepositoryClient(channel);
                    DeleteCurrencyBYIdData(client);
                }
                else if (selecteduser == "update currency")
                {
                    var client = new CurrencyRepositoryClient(channel);
                    UpdateCurrencyBYIdData(client);
                }
                else if (selecteduser == "currency image")
                {
                    var client = new CurrencyFileStreamingClient(channel);
                    var contentRootPath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
                    //put your image address
                    string file = Path.Combine(contentRootPath, "Files", "Address");
                    UploadFileAsync(client, file);
                }
                else if (selecteduser == "currency stream")
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
    public static async Task UploadFileAsync(CurrencyFileStreamingClient client, string filePath)
    {
        try
        {
            var fileInfo = new FileInfo(filePath);

            decimal chunkSize = 0;
            var buffer = new byte[1024 * 2];
            using var call = client.UploadFile();
            using var fileStream = new FileStream(filePath, FileMode.Open);

            var content = new ByteContent
            {
                FileSize = fileStream.Length,
                ReadedByte = 0,
                ImageRequest = new ImageRequest
                {
                    FileName = Path.GetFileNameWithoutExtension(fileInfo.Name),
                    FileExtention = Path.GetExtension(fileInfo.Name).TrimStart('.')
                }
            };

            while ((content.ReadedByte = fileStream.Read(buffer, 0, buffer.Length)) > 0)
            {
                content.Buffer = ByteString.CopyFrom(buffer);
                await call.RequestStream.WriteAsync(content);
                chunkSize += buffer.Length;
                Console.WriteLine($"{Math.Round(chunkSize * 100 / fileStream.Length)} %");
                await Task.Delay(100);
            }
            await call.RequestStream.CompleteAsync();
            Console.ReadKey();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"{ex.Message}");
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