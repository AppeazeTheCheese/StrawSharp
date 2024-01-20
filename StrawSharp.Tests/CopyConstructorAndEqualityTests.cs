using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using AutoFixture;
using AutoFixture.NUnit3;
using FluentAssertions;
using NUnit.Framework;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.UserModels;

namespace StrawSharp.Tests
{
    [TestFixture]
    public class CopyConstructorAndEqualityTests
    {

        private IFixture _fixture;

        [OneTimeSetUp]
        public void Setup()
        {
            var rand = new Random();

            _fixture = new Fixture();
            _fixture.Customize<Color>(c => c.FromFactory(() =>
                Color.FromArgb(rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256), rand.Next(0, 256))));
        }

        [Test, AutoData]
        public void PollThemeCopyConstructorTests()
        {
            var theme = _fixture.Create<PollTheme>();
            var copy = new PollTheme(theme);

            ShouldMatch(copy, theme);
            copy.Should().Be(theme);
        }

        [Test, AutoData]
        public void PollMetaCopyConstructorTests()
        {
            var meta = _fixture.Create<PollMeta>();
            var copy = new PollMeta(meta);

            ShouldMatch(copy, meta);
            copy.Should().Be(meta);
        }

        [Test, AutoData]
        public void PollConfigCopyConstructorTests()
        {
            var config = _fixture.Create<PollConfig>();
            var copy = new PollConfig(config);

            ShouldMatch(copy, config);
            copy.Should().Be(config);
        }

        [Test, AutoData]
        public void PollMediaCopyConstructorTests()
        {
            var media = _fixture.Create<PollMedia>();
            var copy = new PollMedia(media);

            ShouldMatch(copy, media);
            copy.Should().Be(media);
        }

        [Test, AutoData]
        public void UserConfigCopyConstructorTests()
        {
            var config = _fixture.Create<UserConfig>();
            var copy = new UserConfig(config);

            ShouldMatch(copy, config);
            copy.Should().Be(config);
        }

        [Test, AutoData]
        public void UserMetaCopyConstructorTests()
        {
            var meta = _fixture.Create<UserMeta>();
            var copy = new UserMeta(meta);

            ShouldMatch(copy, meta);
            copy.Should().Be(meta);
        }

        [Test, AutoData]
        public void UserCopyConstructorTests()
        {
            var user = _fixture.Create<User>();
            var copy = new User(user);

            ShouldMatch(copy, user);
            copy.Should().Be(user);
        }

        [Test, AutoData]
        public void PollCopyConstructorTests()
        {
            var poll = _fixture.Create<Poll>();
            var copy = new Poll(poll);

            ShouldMatch(copy, poll);
            copy.Should().Be(poll);
        }

        /// <summary>
        /// Asserts that the values for each property in the given objects should match.
        /// </summary>
        /// <typeparam name="T">The type of the objects to compare.</typeparam>
        /// <param name="obj1">The first object to compare.</param>
        /// <param name="obj2">The second object to compare.</param>
        /// <exception cref="Exception"></exception>
        private void ShouldMatch<T>(T obj1, T obj2)
        {
            var type = typeof(T);
            foreach (var property in type.GetProperties())
            {
                var val1 = property.GetValue(obj1);
                var val2 = property.GetValue(obj2);

                if (val1 != null && val2 != null && property.PropertyType.IsGenericType && typeof(List<>).IsAssignableFrom(property.PropertyType.GetGenericTypeDefinition()))
                {
                    var typeParam = property.PropertyType.GetGenericArguments()[0];

                    var seqMethod = typeof(Enumerable).GetMethods().First(x =>
                        x.Name == nameof(Enumerable.SequenceEqual) && x.GetParameters().Length == 2);
                    var genericSeq = seqMethod.MakeGenericMethod(typeParam);

                    var equal = (bool)genericSeq.Invoke(null, new[] {val1, val2})!;

                    if (!equal)
                    {
                        throw new Exception($"The sequence of items in property \"{property.Name}\" do not match.");
                    }
                }
                else if (!Equals(val1, val2))
                {
                    throw new Exception($"Values for property \"{property.Name}\" do not match. Ensure this property is being set within the copy constructor.");
                }
            }
        }
    }
}