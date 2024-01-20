using System;
using System.IO;
using System.Threading.Tasks;
using StrawSharp;
using StrawSharp.Builders;
using StrawSharp.Models.EnumValues;
using StrawSharp.Models.PollModels;

namespace TestApp
{
    internal class Program
    {
        static void Main(string[] args) => Start().GetAwaiter().GetResult();

        static async Task Start()
        {
            var client = new StrawPollClient(/* Your API Key (if you have one) */);
            
            // Upload Image
            var imageName = "TestImage.png";
            var imagePath = Path.Combine(AppContext.BaseDirectory, "Media", imageName);
            PollMedia uploadMediaResponse;
            await using (var file = File.OpenRead(imagePath))
            {
                uploadMediaResponse = await client.UploadMediaAsync(imageName, file);
            }
            
            //Create Multiple Choice Poll
            var poll = PollBuilder
                .ForMultipleChoicePoll()
                .WithTitle("Test")
                .WithDescription("StrawSharp Test")
                .WithDeadline(DateTime.Now + TimeSpan.FromMinutes(2))
                .WithMediaId(uploadMediaResponse.Id)
                .WithTextOptions("Test 1", "Test 2", "Test 3")
                .WithThemeId(DefaultTheme.Cyberpunk2077)
                .Build();

            //Create Image Poll
            /*var images = new List<PollMedia>();
            for (var i = 1; i < 4; i++)
            {
                var name = $"{i}.png";
                var path = Path.Combine(AppContext.BaseDirectory, "Media", name);

                await using (var file = File.OpenRead(path))
                {
                    var response = await client.UploadMediaAsync(name, file);
                    images.Add(response);
                }
            }

            var builder = PollBuilder.ForImagePoll().WithTitle("StrawSharp Test").WithLayout(PollLayout.ListLarge);
            for(var i = 0; i < images.Count; i++)
            {
                var media = images[i];
                builder.AddImageOption(media.Id, $"Option {i + 1}");
            }

            var poll = builder.Build();*/
            var createdPoll = await client.CreatePollAsync(poll);

            // Update Poll
            createdPoll.Config.Deadline = null;
            var updatedPoll = await client.UpdatePollAsync(createdPoll);

            // Get Poll
            var getPollResponse = await client.GetPollAsync(updatedPoll.Id);

            // Delete Poll
            await client.DeletePollAsync(getPollResponse.Id);
            Console.Read();
        }
    }
}
