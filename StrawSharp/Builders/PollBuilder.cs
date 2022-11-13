using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Net;
using StrawSharp.Models.EnumValues;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders
{
    public class PollBuilder : PollBuilderBase, IMultipleChoicePollBuilder, IMeetingPollBuilder, IImagePollBuilder
    {
        public string Title
        {
            get => InternalTitle;
            set => InternalTitle = value;
        }

        public string Type
        {
            get => InternalType;
            set => InternalType = value;
        }

        public PollMedia Media
        {
            get => InternalMedia;
            set => InternalMedia = value;
        }

        public PollConfig Config
        {
            get => InternalConfig;
            set => InternalConfig = value;
        }

        public PollMeta Meta
        {
            get => InternalMeta;
            set => InternalMeta = value;
        }

        public List<PollOption> Options
        {
            get => InternalOptions;
            set => InternalOptions = value ?? new List<PollOption>();
        }

        public PollBuilder()
        {
        }

        public static PollBuilder From(Poll poll)
        {
            if (poll == null) throw new ArgumentNullException(nameof(poll));

            return new PollBuilder
            {
                Title = poll.Title,
                InternalType = poll.Type,
                Media = new PollMedia(poll.Media),
                InternalConfig = new PollConfig(poll.Config),
                InternalMeta = new PollMeta(poll.Meta),
                Options = poll.Options.Select(x => (PollOption) Activator.CreateInstance(x.GetType(), x)).ToList()
            };
        }

        public static IMultipleChoicePollBuilder ForMultipleChoicePoll()
        {
            return new PollBuilder
            {
            };
        }

        public static IMeetingPollBuilder ForMeetingPoll()
        {
            return new PollBuilder()
            {
            };
        }

        public PollBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        /// <summary>
        /// Sets the type of the poll. Known possible values in <see cref="PollType"/>
        /// </summary>
        /// <param name="pollType"></param>
        /// <returns></returns>
        public PollBuilder WithPollType(string pollType)
        {
            InternalType = pollType;
            return this;
        }

        public PollBuilder WithMediaId(string mediaId)
        {
            Media.Id = mediaId;
            return this;
        }

        public PollBuilder AllowComments(bool allow = true)
        {
            InternalConfig.AllowComments = allow;
            return this;
        }

        public PollBuilder AllowIndeterminate(bool allow = true)
        {
            InternalConfig.AllowIndeterminate = allow;
            return this;
        }

        public PollBuilder AllowOtherOption(bool allow = true)
        {
            InternalConfig.AllowOtherOption = allow;
            return this;
        }

        public PollBuilder AllowVpn(bool allow = true)
        {
            InternalConfig.AllowVpn = allow;
            return this;
        }

        public PollBuilder UseCustomDesign(bool customColors = true)
        {
            InternalConfig.UseCustomDesign = customColors;
            return this;
        }

        public PollBuilder WithBackgroundColor(Color color)
        {
            InternalConfig.CustomDesignColors.Background = color;
            return this;
        }

        public PollBuilder WithBorderTableColor(Color color)
        {
            InternalConfig.CustomDesignColors.BorderTable = color;
            return this;
        }

        public PollBuilder WithBorderTopColor(Color color)
        {
            InternalConfig.CustomDesignColors.BorderTop = color;
            return this;
        }

        public PollBuilder WithHighlightColor(Color color)
        {
            InternalConfig.CustomDesignColors.Highlight = color;
            return this;
        }

        public PollBuilder WithOptionColor(Color color)
        {
            InternalConfig.CustomDesignColors.Option = color;
            return this;
        }

        public PollBuilder WithOptionBorderColor(Color color)
        {
            InternalConfig.CustomDesignColors.OptionBorder = color;
            return this;
        }

        public PollBuilder WithPageBackgroundColor(Color color)
        {
            InternalConfig.CustomDesignColors.PageBackground = color;
            return this;
        }

        public PollBuilder WithPrimaryBackgroundColor(Color color)
        {
            InternalConfig.CustomDesignColors.PrimaryBackground = color;
            return this;
        }

        public PollBuilder WithPrimaryBorderColor(Color color)
        {
            InternalConfig.CustomDesignColors.PrimaryBorder = color;
            return this;
        }

        public PollBuilder WithPrimaryTextColor(Color color)
        {
            InternalConfig.CustomDesignColors.PrimaryText = color;
            return this;
        }

        public PollBuilder WithSecondaryBackgroundColor(Color color)
        {
            InternalConfig.CustomDesignColors.SecondaryBackground = color;
            return this;
        }

        public PollBuilder WithSecondaryBorderColor(Color color)
        {
            InternalConfig.CustomDesignColors.SecondaryBorder = color;
            return this;
        }

        public PollBuilder WithSecondaryTextColor(Color color)
        {
            InternalConfig.CustomDesignColors.SecondaryText = color;
            return this;
        }

        public PollBuilder WithTextColor(Color color)
        {
            InternalConfig.CustomDesignColors.Text = color;
            return this;
        }

        public PollBuilder WithTitleColor(Color color)
        {
            InternalConfig.CustomDesignColors.Title = color;
            return this;
        }

        public PollBuilder WithDeadline(DateTime? deadline)
        {
            InternalConfig.Deadline = deadline;
            return this;
        }

        /// <summary>
        /// Set the type of duplication checking to be used by the poll.
        /// </summary>
        /// <param name="checkType">Known values in <see cref="DuplicationCheck"/>.</param>
        /// <returns></returns>
        public PollBuilder WithDuplicationChecking(string checkType)
        {
            InternalConfig.DuplicationChecking = checkType;
            return this;
        }

        /// <summary>
        /// Set who has access to edit votes.
        /// </summary>
        /// <param name="permission">Known values in <see cref="EditVotePermission"/></param>
        /// <returns></returns>
        public PollBuilder WithEditVotePermissions(string permission)
        {
            InternalConfig.EditVotePermissions = permission;
            return this;
        }

        public PollBuilder HideParticipants(bool hide = true)
        {
            InternalConfig.HideParticipants = hide;
            return this;
        }

        public PollBuilder MultipleChoice(bool multipleChoice = true)
        {
            InternalConfig.IsMultipleChoice = multipleChoice;
            return this;
        }

        public PollBuilder Private(bool isPrivate = true)
        {
            InternalConfig.IsPrivate = isPrivate;
            return this;
        }

        public PollBuilder WithMinChoices(int? minChoices = null)
        {
            InternalConfig.MinChoices = minChoices;
            return this;
        }

        public PollBuilder WithMaxChoices(int? maxChoices = null)
        {
            InternalConfig.MaxChoices = maxChoices;
            return this;
        }

        public PollBuilder RequireNames(bool require = true)
        {
            InternalConfig.RequireName = require;
            return this;
        }

        /// <summary>
        /// Sets when the results become visible.
        /// </summary>
        /// <param name="visibility">Known values in <see cref="ResultVisibility"/></param>
        /// <returns></returns>
        public PollBuilder WithResultVisibility(string visibility)
        {
            InternalConfig.ResultVisibility = visibility;
            return this;
        }

        public PollBuilder WithConfig(PollConfig config)
        {
            InternalConfig = config;
            return this;
        }

        public PollBuilder WithDescription(string description)
        {
            InternalMeta.Description = description;
            return this;
        }

        public PollBuilder WithMeta(PollMeta meta)
        {
            InternalMeta = meta;
            return this;
        }

        public PollBuilder WithOptions(IEnumerable<PollOption> options)
        {
            Options = options.ToList();
            return this;
        }

        public PollBuilder WithTextOptions(IEnumerable<string> options)
        {
            return WithOptions(options.Select(x => new TextPollOption {Value = x}));
        }

        public PollBuilder WithTextOptions(params string[] options)
        {
            return WithTextOptions(options.AsEnumerable());
        }

        public PollBuilder WithDateOptions(IEnumerable<DateTime> options)
        {
            return WithOptions(options.Select(x => new DatePollOption {Date = x}));
        }

        public PollBuilder WithDateOptions(params DateTime[] options)
        {
            return WithDateOptions(options.AsEnumerable());
        }

        public PollBuilder AddOptions(IEnumerable<PollOption> options)
        {
            Options.AddRange(options);
            return this;
        }

        public PollBuilder AddOptions(params PollOption[] options)
        {
            return AddOptions(options.AsEnumerable());
        }

        public PollBuilder AddTextOptions(IEnumerable<string> options)
        {
            return AddOptions(options.Select(x => new TextPollOption {Value = x}));
        }

        public PollBuilder AddTextOptions(params string[] options)
        {
            return AddTextOptions(options.AsEnumerable());
        }

        public PollBuilder AddImageOption(string mediaId, string caption)
        {
            return AddOptions(new ImagePollOption
            {
                Media = new PollMedia
                {
                    Id = mediaId
                },
                Value = caption
            });
        }

        public PollBuilder AddDateOptions(IEnumerable<DateTime> dates)
        {
            return AddOptions(dates.Select(x => new DatePollOption {Date = x}));
        }

        public PollBuilder AddDateOptions(params DateTime[] dates)
        {
            return AddDateOptions(dates.AsEnumerable());
        }

        public PollBuilder AddTimeRangeOption(DateTime startTime, DateTime endTime)
        {
            return AddOptions(new TimeRangePollOption {StartTime = startTime, EndTime = endTime});
        }

        public PollBuilder RemoveOptions(params PollOption[] options)
        {
            return RemoveOptions(options.AsEnumerable());
        }

        public PollBuilder RemoveOptions(IEnumerable<PollOption> options)
        {
            Options.RemoveAll(options.Contains);
            return this;
        }

        public PollBuilder ClearOptions()
        {
            Options.Clear();
            return this;
        }

        public Poll Build()
        {
            var poll = new Poll
            {
                Title = Title,
                Type = InternalType
            };

            if (!string.IsNullOrWhiteSpace(Media.Id))
                poll.Media.Id = Media.Id;

            poll.Config = InternalConfig;

            if (!string.IsNullOrWhiteSpace(InternalMeta.Description))
                poll.Meta.Description = InternalMeta.Description;
            if (!string.IsNullOrWhiteSpace(InternalMeta.Location))
                poll.Meta.Location = InternalMeta.Location;

            poll.Options.AddRange(Options.Where(x => x != null));
            return poll;
        }
    }
}