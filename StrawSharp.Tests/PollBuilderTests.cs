using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using StrawSharp.Builders;
using StrawSharp.Models.Enums;
using StrawSharp.Models.PollModels;

namespace StrawSharp.Tests
{
    [TestClass]
    public class PollBuilderTests
    {
        private readonly PollBuilder _pollBuilder;
        public PollBuilderTests()
        {
            _pollBuilder = new PollBuilder();
        }

        [TestMethod]
        public void WithTitle_Null_ArgumentException()
        {
            Assert.ThrowsException<ArgumentException>(() => _pollBuilder.WithTitle(null));
        }

        [TestMethod]
        public void WithTitle_String_PropertySet()
        {
            const string title = "Foo Bar";
            _pollBuilder.WithTitle(title);
            Assert.AreEqual(title, _pollBuilder.Title);
        }

        [TestMethod]
        public void WithMediaId_Null_SetProperty()
        {
            _pollBuilder.WithMediaId(null);
            Assert.IsNull(_pollBuilder.Media.Id);
        }

        [TestMethod]
        public void WithMediaId_String_SetProperty()
        {
            const string mediaId = "FooBar";
            _pollBuilder.WithMediaId(mediaId);
            Assert.AreEqual(mediaId, _pollBuilder.Media.Id);
        }

        [TestMethod]
        public void WithMedia_Null_SetPropertyToNewInstance()
        {
            _pollBuilder.WithMedia(null);
            Assert.AreEqual(new PollMedia(), _pollBuilder.Media);
        }

        [TestMethod]
        public void WithMedia_Instance_SetProperty()
        {
            var media = new PollMedia {Id = "Foo"};
            _pollBuilder.WithMedia(media);
            Assert.AreSame(media, _pollBuilder.Media);
        }


        [TestMethod]
        public void WithPollConfig_Null_SetPropertyToNewInstance()
        {
            _pollBuilder.WithConfig(null);
            Assert.AreEqual(new PollConfig(), _pollBuilder.Config);
        }

        [TestMethod]
        public void WithPollConfig_Instance_SetProperty()
        {
            var config = new PollConfig()
            {
                AllowComments = true,
                EditVotePermissions = EditVotePermission.Voter,
                Deadline = DateTime.Now + TimeSpan.FromDays(10)
            };
            _pollBuilder.WithConfig(config);
            Assert.AreSame(config, _pollBuilder.Config);
        }

        [TestMethod]
        public void WithDescription_Null_SetProperty()
        {
            _pollBuilder.WithDescription(null);
            Assert.IsNull(_pollBuilder.Meta.Description);
        }

        [TestMethod]
        public void WithDescription_String_SetProperty()
        {
            const string description = "This is an awesome poll description!";
            _pollBuilder.WithDescription(description);
            Assert.AreEqual(description, _pollBuilder.Meta.Description);
        }

        //TODO: WithMeta
    }
}
