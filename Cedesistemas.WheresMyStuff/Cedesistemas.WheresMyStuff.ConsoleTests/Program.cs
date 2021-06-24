using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Cedesistemas.WheresMyStuff.ConsoleTests
{
    class Program
    {
        static async Task Main(string[] args)
        {
            Sync1();
            
            Sync2();
            int length = Async1();
            var task = Async3();

            Console.WriteLine($"Main");
            Sync2();

            int length2 = await task;
            Sync3(length2);

            //int length2 = await task;
            Console.ReadLine();
        }

        static void Sync1()
        {
            // You can do whatever work is needed here
            Console.WriteLine("Sync1. Doing some work synchronously");
        }

        static void Sync3(int a)
        {
            // You can do whatever work is needed here
            Console.WriteLine("Sync1. Doing some work synchronously: " + a);
        }

        static void Sync2()
        {
            // You can do whatever work is needed here
            Console.WriteLine("Sync2. Doing some other work synchronously");
        }

        static async Task<int> Async3()
        {
            Console.WriteLine("Async3. Async3 task has started...");
            int length = await GetString(); // we are awaiting the Async Method GetStringAsync
            Console.WriteLine("Async3. Async3 task has ended...");
            return length;
        }

        static int Async1() //A Task return type will eventually yield a void
        {
            Console.WriteLine("Async1 (Sync3). Async1 task has started...");
            int length = GetString().Result; // we are awaiting the Async Method GetStringAsync
            Console.WriteLine("Async1. Async1 task has ended...");
            return length;
        }

        static async Task<int> GetString()
        {
            using (var httpClient = new HttpClient())
            {
                var url = "http://google.com";
                Console.WriteLine("GetString. Awaiting the result of GetStringAsync of Http Client...");
                string result = await httpClient.GetStringAsync(url); //execution pauses here while awaiting GetStringAsync to complete

                //From this line and below, the execution will resume once the above awaitable is done
                //using await keyword, it will do the magic of unwrapping the Task<string> into string (result variable)
                Console.WriteLine("GetString. The awaited task has completed. Let's get the content length...");
                Console.WriteLine($"GetString. The length of http Get for {url}");
                return result.Length;
            }
        }
    }
}
