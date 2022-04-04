using System;
using System.Threading.Tasks;
using StrawSharp;
using StrawSharp.Helpers;
using StrawSharp.Requests;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args) => Start().GetAwaiter().GetResult();

        static async Task Start()
        {
            var client = new StrawPollClient();

            // Create Poll
#if true
            var poll = new PollBuilder()
                .WithTitle("")
                .WithDescription("StrawSharp Test")
                .Private()
                .MultipleChoice()
                .WithOptions("Test 1", "Test 2", "Test 3")
                .Build();

            var createPollResponse = await client.CreatePollAsync(poll);
#endif

            // Get Poll
#if true
            var getPollResponse = await client.GetPollAsync(createPollResponse.Poll.Id);
#endif

            Console.Read();
        }
    }
}
