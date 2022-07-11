using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using StrawSharp.Models.EnumValues;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders
{
    public class PollBuilder
    {
        private string _title;
        private PollMedia _media = new PollMedia();
        private PollConfig _config = new PollConfig();
        private PollMeta _meta = new PollMeta();
        private List<PollOption> _options = new List<PollOption>();

        public PollBuilder()
        {

        }

        public static PollBuilder From(Poll poll)
        {
            if (poll == null) throw new ArgumentNullException(nameof(poll));

            return new PollBuilder
            {
                Title = poll.Title,
                Media = new PollMedia(poll.Media),
                Config = new PollConfig(poll.Config),
                Meta = new PollMeta(poll.Meta),
                Options = poll.Options.Select(x => (PollOption)Activator.CreateInstance(x.GetType(), x)).ToList()
            };
        }

        public string Title
        {
            get => _title;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("You must provide a title", nameof(Title));
                _title = value;
            }
        }

        public PollMedia Media
        {
            get => _media;
            set => _media = value ?? new PollMedia();
        }

        public PollConfig Config
        {
            get => _config;
            set => _config = value ?? new PollConfig();
        }

        public PollMeta Meta
        {
            get => _meta;
            set => _meta = value ?? new PollMeta();
        }

        public List<PollOption> Options
        {
            get => _options;
            set => _options = value ?? new List<PollOption>();
        }

        public PollBuilder WithTitle(string title)
        {
            Title = title;
            return this;
        }

        public PollBuilder WithMediaId(string mediaId)
        {
            Media.Id = mediaId;
            return this;
        }

        public PollBuilder AllowComments(bool allow = true)
        {
            Config.AllowComments = allow;
            return this;
        }

        public PollBuilder AllowIndeterminate(bool allow = true)
        {
            Config.AllowIndeterminate = allow;
            return this;
        }

        public PollBuilder AllowOtherOption(bool allow = true)
        {
            Config.AllowOtherOption = allow;
            return this;
        }
        
        public PollBuilder AllowVpn(bool allow = true)
        {
            Config.AllowVpn = allow;
            return this;
        }

        public PollBuilder UseCustomDesign(bool customColors = true)
        {
            Config.UseCustomDesign = customColors;
            return this;
        }

        public PollBuilder WithBackgroundColor(Color color)
        {
            Config.CustomDesignColors.Background = color;
            return this;
        }

        public PollBuilder WithBorderTableColor(Color color)
        {
            Config.CustomDesignColors.BorderTable = color;
            return this;
        }

        public PollBuilder WithBorderTopColor(Color color)
        {
            Config.CustomDesignColors.BorderTop = color;
            return this;
        }

        public PollBuilder WithHighlightColor(Color color)
        {
            Config.CustomDesignColors.Highlight = color;
            return this;
        }

        public PollBuilder WithOptionColor(Color color)
        {
            Config.CustomDesignColors.Option = color;
            return this;
        }

        public PollBuilder WithOptionBorderColor(Color color)
        {
            Config.CustomDesignColors.OptionBorder = color;
            return this;
        }

        public PollBuilder WithPageBackgroundColor(Color color)
        {
            Config.CustomDesignColors.PageBackground = color;
            return this;
        }

        public PollBuilder WithPrimaryBackgroundColor(Color color)
        {
            Config.CustomDesignColors.PrimaryBackground = color;
            return this;
        }

        public PollBuilder WithPrimaryBorderColor(Color color)
        {
            Config.CustomDesignColors.PrimaryBorder = color;
            return this;
        }

        public PollBuilder WithPrimaryTextColor(Color color)
        {
            Config.CustomDesignColors.PrimaryText = color;
            return this;
        }

        public PollBuilder WithSecondaryBackgroundColor(Color color)
        {
            Config.CustomDesignColors.SecondaryBackground = color;
            return this;
        }

        public PollBuilder WithSecondaryBorderColor(Color color)
        {
            Config.CustomDesignColors.SecondaryBorder = color;
            return this;
        }

        public PollBuilder WithSecondaryTextColor(Color color)
        {
            Config.CustomDesignColors.SecondaryText = color;
            return this;
        }

        public PollBuilder WithTextColor(Color color)
        {
            Config.CustomDesignColors.Text = color;
            return this;
        }

        public PollBuilder WithTitleColor(Color color)
        {
            Config.CustomDesignColors.Title = color;
            return this;
        }

        public PollBuilder WithDeadline(DateTime? deadline)
        {
            Config.Deadline = deadline;
            return this;
        }

        /// <summary>
        /// Set the type of duplication checking to be used by the poll.
        /// </summary>
        /// <param name="checkType">Known values in <see cref="DuplicationCheck"/>.</param>
        /// <returns></returns>
        public PollBuilder WithDuplicationChecking(string checkType)
        {
            Config.DuplicationChecking = checkType;
            return this;
        }

        /// <summary>
        /// Set who has access to edit votes.
        /// </summary>
        /// <param name="permission">Known values in <see cref="EditVotePermission"/></param>
        /// <returns></returns>
        public PollBuilder WithEditVotePermissions(string permission)
        {
            Config.EditVotePermissions = permission;
            return this;
        }

        public PollBuilder HideParticipants(bool hide = true)
        {
            Config.HideParticipants = hide;
            return this;
        }

        public PollBuilder MultipleChoice(bool multipleChoice = true)
        {
            Config.IsMultipleChoice = multipleChoice;
            return this;
        }

        public PollBuilder Private(bool isPrivate = true)
        {
            Config.IsPrivate = isPrivate;
            return this;
        }

        public PollBuilder WithMinChoices(int? minChoices = null)
        {
            Config.MinChoices = minChoices;
            return this;
        }

        public PollBuilder WithMaxChoices(int? maxChoices = null)
        {
            Config.MaxChoices = maxChoices;
            return this;
        }

        public PollBuilder RequireNames(bool require = true)
        {
            Config.RequireName = require;
            return this;
        }

        /// <summary>
        /// Sets when the results become visible.
        /// </summary>
        /// <param name="visibility">Known values in <see cref="ResultVisibility"/></param>
        /// <returns></returns>
        public PollBuilder WithResultVisibility(string visibility)
        {
            Config.ResultVisibility = visibility;
            return this;
        }

        public PollBuilder WithConfig(PollConfig config)
        {
            Config = config;
            return this;
        }

        public PollBuilder WithDescription(string description)
        {
            Meta.Description = description;
            return this;
        }

        public PollBuilder WithMeta(PollMeta meta)
        {
            Meta = meta;
            return this;
        }

        public PollBuilder WithOptions(IEnumerable<PollOption> options)
        {
            Options = options.ToList();
            return this;
        }

        public PollBuilder WithTextOptions(IEnumerable<string> options)
        {
            return WithOptions(options.Select(x => new TextPollOption { Value = x }));
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
            return AddOptions(options.Select(x => new TextPollOption { Value = x }));
        }

        public PollBuilder AddTextOptions(params string[] options)
        {
            return AddTextOptions(options.AsEnumerable());
        }

        public PollBuilder AddImageOption(PollMedia media, string caption)
        {
            return AddOptions(new ImagePollOption {Media = media, Value = caption});
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

        public PollBuilder RemoveOptions(IEnumerable<PollOption> options)
        {
            Options.RemoveAll(options.Contains);
            return this;
        }

        public PollBuilder RemoveOptions(params PollOption[] options)
        {
            return RemoveOptions(options.AsEnumerable());
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
                Title = Title
            };

            if (!string.IsNullOrWhiteSpace(Media.Id))
                poll.Media.Id = _media.Id;
            
            poll.Config = Config;

            if(!string.IsNullOrWhiteSpace(Meta.Description))
                poll.Meta.Description = Meta.Description;
            if (!string.IsNullOrWhiteSpace(Meta.Location))
                poll.Meta.Location = Meta.Location;

            poll.Options.AddRange(Options.Where(x => x != null));
            return poll;
        }
    }
}
