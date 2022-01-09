using System;
using System.Threading.Tasks;

namespace ConsoleApiCallapp
{
    class Program
    {
        static async Task Main(string[] args)
        {
            ApiHelper apiHelper = new();
            var obj = await apiHelper.ApiCall();

            System.Console.WriteLine($"Id: {obj.Id}");
            System.Console.WriteLine($"Joke: {obj.Value}");

        }
    }
}
