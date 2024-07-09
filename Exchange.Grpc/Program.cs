using Exchange.gRPCClient;
using Grpc.Net.Client;
using static Exchange.gRPCClient.CurrencyRepository;
namespace Exchange.Grpc;

internal class Program
{
    static void Main(string[] args)
    {
        string address = "https://localhost:7219";
        var channel = GrpcChannel.ForAddress(address);

        var client = new CurrencyRepositoryClient(channel);
        try
        {
            Console.WriteLine("Please Enter Your Currency Id ");
            int id = Convert.ToInt32(Console.ReadLine());

            var request = new GetCurrencyRequestDto
            {
                Id = id
            };

            var response = client.GetCurrency(request);
            Console.WriteLine($"The currency code is {response.CurrencyCode} and the price is {response.Price}");

        }
        catch (Exception ex)
        {
            Console.WriteLine($"The Error is {ex.Message}");
        }
    }
}
