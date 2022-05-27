using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using StrawSharp.Builders;
using NUnit.Framework;
using StrawSharp.Models.EnumValues;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Tests.Integration
{
    public class RestClientIntegrationTests
    {
        private static readonly StrawPollClient Client = new();
        private static Poll createdPoll;

        [Test, Order(50)]
        public async Task CreateAnonymousPoll_PollObject_CreatedAnonymousPollWithSettings()
        {
            const string title = "StrawSharp Test";
            const string pollType = PollType.MultipleChoice;
            const bool isPrivate = true;
            const string duplicationChecking = DuplicationCheck.Session;
            const string description = "Test Poll";
            const string option1 = "Test1";
            const string option2 = "Test2";
            const string option3 = "Test3";

            var poll = new Poll
            {
                Title = title,
                Type = pollType,
                Config = new PollConfig
                {
                    IsPrivate = isPrivate,
                    DuplicationChecking = duplicationChecking
                },
                Meta = new PollMeta
                {
                    Description = description
                },
                Options = new List<PollOption>
                {
                    new TextPollOption {Value = option1},
                    new TextPollOption {Value = option2},
                    new TextPollOption {Value = option3}
                }
            };

            createdPoll = await Client.CreatePollAsync(poll);
            Assert.NotNull(createdPoll);
            Assert.NotNull(createdPoll.Id);
            Assert.NotNull(createdPoll.Url);

            Assert.AreEqual(title, createdPoll.Title);
            //Assert.AreEqual(pollType, createdPoll.Type);

            Assert.NotNull(createdPoll.Config);
            Assert.AreEqual(isPrivate, createdPoll.Config.IsPrivate);
            Assert.AreEqual(duplicationChecking, createdPoll.Config.DuplicationChecking);

            Assert.NotNull(createdPoll.Meta);
            Assert.AreEqual(description, createdPoll.Meta.Description);

            Assert.NotNull(createdPoll.Options);
            Assert.AreEqual(3, createdPoll.Options.Count);
            Assert.IsInstanceOf<TextPollOption>(createdPoll.Options[0]);
            Assert.IsInstanceOf<TextPollOption>(createdPoll.Options[1]);
            Assert.IsInstanceOf<TextPollOption>(createdPoll.Options[2]);
            Assert.AreEqual(option1, ((TextPollOption)createdPoll.Options[0]).Value);
            Assert.AreEqual(option2, ((TextPollOption)createdPoll.Options[1]).Value);
            Assert.AreEqual(option3, ((TextPollOption)createdPoll.Options[2]).Value);
        }

        [Test, Order(100)]
        public async Task GetAnonymousPoll_PollReturned()
        {
            var poll = await Client.GetPollAsync(createdPoll.Id);
            
            Assert.IsNotNull(poll);
            Assert.AreEqual(createdPoll.Id, poll.Id);
        }

        [Test, Order(150)]
        public async Task UpdateAnonymousPoll_PollObject_UpdatedAnonymousPollWithSettings()
        {
            const string duplicationCheck = DuplicationCheck.Ip;
            const string description = "Cool Description";

            createdPoll.Config.DuplicationChecking = duplicationCheck;
            createdPoll.Meta.Description = description;

            var updatedPoll = await Client.UpdatePollAsync(createdPoll);

            Assert.AreEqual(description, updatedPoll.Meta.Description);
            Assert.AreEqual(duplicationCheck, updatedPoll.Config.DuplicationChecking);
        }

        [Test, Order(200)]
        public void DeleteAnonymousPoll_SuccessResponse()
        {
            Assert.DoesNotThrowAsync(() => Client.DeletePollAsync(createdPoll.Id));
        }
    }
}