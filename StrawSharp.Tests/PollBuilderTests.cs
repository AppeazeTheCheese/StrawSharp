using System;
using System.Linq;
using NUnit.Framework;
using StrawSharp.Builders;
using StrawSharp.Models.EnumValues;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Tests
{
    public class PollBuilderTests
    {
        private readonly PollBuilder _pollBuilder;
        public PollBuilderTests()
        {
            _pollBuilder = new PollBuilder();
        }

        [Test]
        public void WithTitle_Null_ArgumentException()
        {
            Assert.Throws<ArgumentException>(() => _pollBuilder.WithTitle(null));
        }

        [Test]
        public void WithTitle_String_PropertySet()
        {
            const string title = "Foo Bar";
            _pollBuilder.WithTitle(title);
            Assert.AreEqual(title, _pollBuilder.Title);
        }

        [Test]
        public void WithMediaId_Null_SetProperty()
        {
            _pollBuilder.WithMediaId(null);
            Assert.IsNull(_pollBuilder.Media.Id);
        }

        [Test]
        public void WithMediaId_String_SetProperty()
        {
            const string mediaId = "FooBar";
            _pollBuilder.WithMediaId(mediaId);
            Assert.AreEqual(mediaId, _pollBuilder.Media.Id);
        }

        [Test]
        public void WithMedia_Null_SetPropertyToNewInstance()
        {
            _pollBuilder.WithMedia(null);
            Assert.AreEqual(new PollMedia(), _pollBuilder.Media);
        }

        [Test]
        public void WithMedia_Instance_SetProperty()
        {
            var media = new PollMedia { Id = "Foo" };
            _pollBuilder.WithMedia(media);
            Assert.AreSame(media, _pollBuilder.Media);
        }


        [Test]
        public void WithPollConfig_Null_SetPropertyToNewInstance()
        {
            _pollBuilder.WithConfig(null);
            Assert.AreEqual(new PollConfig(), _pollBuilder.Config);
        }

        [Test]
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

        [Test]
        public void WithDescription_Null_SetProperty()
        {
            _pollBuilder.WithDescription(null);
            Assert.IsNull(_pollBuilder.Meta.Description);
        }

        [Test]
        public void WithDescription_String_SetProperty()
        {
            const string description = "This is an awesome poll description!";
            _pollBuilder.WithDescription(description);
            Assert.AreEqual(description, _pollBuilder.Meta.Description);
        }

        [Test]
        public void WithMeta_Null_SetPropertyToNewInstance()
        {
            _pollBuilder.WithMeta(null);
            Assert.AreEqual(new PollMeta(), _pollBuilder.Meta);
        }

        [Test]
        public void WithMeta_Instance_SetProperty()
        {
            var meta = new PollMeta
            {
                Description = "asd123",
                Location = "United States"
            };
            _pollBuilder.WithMeta(meta);
            Assert.AreSame(meta, _pollBuilder.Meta);
        }

        [Test]
        public void WithOptions_EnumerablePollOption_SetOptions()
        {
            var pollOptions = new PollOption[]
            {
                new TextPollOption("These"),
                new TextPollOption("are"),
                new TextPollOption("options"),
                new DatePollOption(DateTime.Now),
                new TimeRangePollOption(DateTime.Now - TimeSpan.FromMinutes(5), DateTime.Now + TimeSpan.FromMinutes(5))
            };

            _pollBuilder.WithOptions(pollOptions);
            for (var i = 0; i < pollOptions.Length; i++)
            {
                Assert.AreSame(pollOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void WithOptions_EnumerablePollOption_SetOptionsTwice()
        {
            var firstOptions = new PollOption[]
            {
                new DatePollOption(DateTime.Now + TimeSpan.FromHours(2)),
                new TextPollOption("T1"),
                new TimeRangePollOption(DateTime.Now + TimeSpan.FromMinutes(1), DateTime.Now + TimeSpan.FromHours(1))
            };

            var secondOptions = new PollOption[]
            {
                new TextPollOption("T2"),
                new TextPollOption("T3"),
                new DatePollOption(DateTime.Now + TimeSpan.FromMinutes(2))
            };

            _pollBuilder.WithOptions(firstOptions);
            _pollBuilder.WithOptions(secondOptions);
            Assert.AreEqual(secondOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreSame(secondOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void WithTextOptions_EnumerableString_SetOptions()
        {
            const string text1 = "Test1";
            const string text2 = "Test2";
            const string text3 = "Test3";

            var expectedOptions = new TextPollOption[]
            {
                new TextPollOption(text1),
                new TextPollOption(text2),
                new TextPollOption(text3)
            };

            _pollBuilder.WithTextOptions(text1, text2, text3);
            Assert.AreEqual(expectedOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void WithTextOptions_EnumerableString_SetOptionsTwice()
        {
            const string text1 = "Test1";
            const string text2 = "Test2";
            const string text3 = "Test3";

            const string text4 = "Test4";
            const string text5 = "Test5";
            const string text6 = "Text6";

            var expectedOptions = new[]
            {
                new TextPollOption(text4),
                new TextPollOption(text5),
                new TextPollOption(text6)
            };

            _pollBuilder.WithTextOptions(text1, text2, text3);
            _pollBuilder.WithTextOptions(text4, text5, text6);
            Assert.AreEqual(expectedOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void WithDateOptions_EnumerableDateTime_SetOptions()
        {
            var date1 = DateTime.Now + TimeSpan.FromMinutes(2);
            var date2 = DateTime.Now + TimeSpan.FromHours(2);
            var date3 = DateTime.Now + TimeSpan.FromDays(2);

            var expectedOptions = new DatePollOption[]
            {
                new DatePollOption(date1),
                new DatePollOption(date2),
                new DatePollOption(date3)
            };

            _pollBuilder.WithDateOptions(date1, date2, date3);
            Assert.AreEqual(expectedOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void WithDateOptions_EnumerableDateTime_SetOptionsTwice()
        {
            var date1 = DateTime.Now + TimeSpan.FromMinutes(2);
            var date2 = DateTime.Now + TimeSpan.FromHours(2);
            var date3 = DateTime.Now + TimeSpan.FromDays(2);

            var date4 = DateTime.Now + TimeSpan.FromMinutes(5);
            var date5 = DateTime.Now + TimeSpan.FromHours(2);
            var date6 = DateTime.Now + TimeSpan.FromDays(2);

            var expectedOptions = new[]
            {
                new DatePollOption(date4),
                new DatePollOption(date5),
                new DatePollOption(date6)
            };

            _pollBuilder.WithDateOptions(date1, date2, date3);
            _pollBuilder.WithDateOptions(date4, date5, date6);
            Assert.AreEqual(expectedOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void AddOptions_EnumerablePollOption_AddOptions()
        {
            var pollOptions = new PollOption[]
            {
                new TextPollOption("These"),
                new TextPollOption("are"),
                new TextPollOption("options"),
                new DatePollOption(DateTime.Now),
                new TimeRangePollOption(DateTime.Now - TimeSpan.FromMinutes(5), DateTime.Now + TimeSpan.FromMinutes(5)),
            };

            _pollBuilder.AddOptions(pollOptions);
            for (var i = 0; i < pollOptions.Length; i++)
            {
                Assert.AreSame(pollOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void AddOptions_EnumerablePollOption_AddOptionsTwice()
        {
            var firstOptions = new PollOption[]
            {
                new DatePollOption(DateTime.Now + TimeSpan.FromHours(2)),
                new TextPollOption("T1"),
                new TimeRangePollOption(DateTime.Now + TimeSpan.FromMinutes(1), DateTime.Now + TimeSpan.FromHours(1))
            };

            var secondOptions = new PollOption[]
            {
                new TextPollOption("T2"),
                new TextPollOption("T3"),
                new DatePollOption(DateTime.Now + TimeSpan.FromMinutes(2))
            };

            var allOptions = firstOptions.Concat(secondOptions).ToArray();

            _pollBuilder.AddOptions(firstOptions);
            _pollBuilder.AddOptions(secondOptions);
            Assert.AreEqual(allOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreSame(allOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void AddTextOptions_EnumerableString_AddOptions()
        {
            const string text1 = "Test1";
            const string text2 = "Test2";
            const string text3 = "Test3";

            var expectedOptions = new TextPollOption[]
            {
                new TextPollOption(text1),
                new TextPollOption(text2),
                new TextPollOption(text3)
            };

            _pollBuilder.AddTextOptions(text1, text2, text3);
            Assert.AreEqual(expectedOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void AddTextOptions_EnumerableString_AddOptionsTwice()
        {
            const string text1 = "Test1";
            const string text2 = "Test2";
            const string text3 = "Test3";

            const string text4 = "Test4";
            const string text5 = "Test5";
            const string text6 = "Text6";

            var expectedOptions = new TextPollOption[]
            {
                new TextPollOption(text1),
                new TextPollOption(text2),
                new TextPollOption(text3),
                new TextPollOption(text4),
                new TextPollOption(text5),
                new TextPollOption(text6)
            };
            
            _pollBuilder.AddTextOptions(text1, text2, text3);
            _pollBuilder.AddTextOptions(text4, text5, text6);
            Assert.AreEqual(expectedOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void AddDateOptions_EnumerableDateTime_AddOptions()
        {
            var date1 = DateTime.Now + TimeSpan.FromMinutes(2);
            var date2 = DateTime.Now + TimeSpan.FromHours(2);
            var date3 = DateTime.Now + TimeSpan.FromDays(2);

            var expectedOptions = new DatePollOption[]
            {
                new DatePollOption(date1),
                new DatePollOption(date2),
                new DatePollOption(date3)
            };

            _pollBuilder.AddDateOptions(date1, date2, date3);
            Assert.AreEqual(expectedOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void AddDateOptions_EnumerableDateTime_AddOptionsTwice()
        {
            var date1 = DateTime.Now + TimeSpan.FromMinutes(2);
            var date2 = DateTime.Now + TimeSpan.FromHours(2);
            var date3 = DateTime.Now + TimeSpan.FromDays(2);

            var date4 = DateTime.Now + TimeSpan.FromMinutes(5);
            var date5 = DateTime.Now + TimeSpan.FromHours(2);
            var date6 = DateTime.Now + TimeSpan.FromDays(2);

            var expectedOptions = new DatePollOption[]
            {
                new DatePollOption(date1),
                new DatePollOption(date2),
                new DatePollOption(date3),
                new DatePollOption(date4),
                new DatePollOption(date5),
                new DatePollOption(date6)
            };

            _pollBuilder.AddDateOptions(date1, date2, date3);
            _pollBuilder.AddDateOptions(date4, date5, date6);
            Assert.AreEqual(expectedOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void AddTimeRangeOption_DateTime_AddOption()
        {
            var start = DateTime.Now + TimeSpan.FromMinutes(2);
            var end = DateTime.Now + TimeSpan.FromHours(2);

            var expectedOption = new TimeRangePollOption {StartTime = start, EndTime = end};

            _pollBuilder.AddTimeRangeOption(start, end);
            Assert.AreEqual(1, _pollBuilder.Options.Count);
            Assert.AreEqual(expectedOption, _pollBuilder.Options[0]);
        }

        [Test]
        public void AddTimeRangeOption_DateTime_AddOptionTwice()
        {
            var start1 = DateTime.Now + TimeSpan.FromMinutes(1);
            var end1 = DateTime.Now + TimeSpan.FromHours(1);

            var start2 = DateTime.Now + TimeSpan.FromMinutes(2);
            var end2 = DateTime.Now + TimeSpan.FromHours(2);

            var expectedOptions = new TimeRangePollOption[]
            {
                new TimeRangePollOption(start1, end1),
                new TimeRangePollOption(start2, end2)
            };

            _pollBuilder.AddTimeRangeOption(start1, end1);
            _pollBuilder.AddTimeRangeOption(start2, end2);

            Assert.AreEqual(2, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void RemoveOptions_EnumerablePollOption_RemoveOptions()
        {
            var allOptions = new PollOption[]
            {
                new TextPollOption("Test1"),
                new TextPollOption("Test2"),
                new TextPollOption("Test3"),
                new TextPollOption("Test4"),
                new TextPollOption("Test5"),
                new TextPollOption("Test6")
            };

            var expectedOptions = new PollOption[]
            {
                new TextPollOption("Test2"),
                new TextPollOption("Test4"),
                new TextPollOption("Test6")
            };

            var removeOptions = allOptions.Where((x, i) => i % 2 == 0); // Should get index 0, 2 and 4
            _pollBuilder.Options = allOptions.ToList();
            _pollBuilder.RemoveOptions(removeOptions);
            Assert.AreEqual(expectedOptions.Length, _pollBuilder.Options.Count);
            for (var i = 0; i < _pollBuilder.Options.Count; i++)
            {
                Assert.AreEqual(expectedOptions[i], _pollBuilder.Options[i]);
            }
        }

        [Test]
        public void ClearOptions_EnumerablePollOption_RemoveAllOptions()
        {
            var options = new PollOption[]
            {
                new TextPollOption("Test"),
                new DatePollOption(DateTime.Now),
                new TimeRangePollOption(DateTime.Now, DateTime.Now + TimeSpan.FromMinutes(2))
            };

            _pollBuilder.Options = options.ToList();
            _pollBuilder.ClearOptions();
            Assert.IsTrue(_pollBuilder.Options.Count == 0);
        }
    }
}