using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using StrawSharp.Models;
using StrawSharp.Models.Enums;

namespace StrawSharp.Helpers
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

        //TODO: Create constructor that takes a Poll as an argument and populates the builder with the info

        #region Configuration Properties

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

        #endregion

        #region Configuration Methods

        public PollBuilder WithTitle(string title)
        {
            _title = title;
            return this;
        }

        #region Media

        public PollBuilder WithMediaId(string mediaId)
        {
            Media.Id = mediaId;
            return this;
        }

        public PollBuilder WithMedia(PollMedia media)
        {
            Media = media;
            return this;
        }

        #endregion

        #region Config

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

        #region Poll Custom Design Colors

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

        #endregion

        public PollBuilder WithDeadline(DateTime? deadline)
        {
            Config.Deadline = deadline;
            return this;
        }

        public PollBuilder WithDuplicationChecking(DuplicationCheck checkType)
        {
            Config.DuplicationChecking = checkType;
            return this;
        }

        public PollBuilder WithEditVotePermissions(EditVotePermission permission)
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

        public PollBuilder WithResultVisibility(ResultVisibility visibility)
        {
            Config.ResultVisibility = visibility;
            return this;
        }

        public PollBuilder WithConfig(PollConfig config)
        {
            Config = config;
            return this;
        }

        #endregion

        #region Meta

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

        #endregion

        #region Options

        #region Set Options

        public PollBuilder WithOptions(IEnumerable<PollOption> options)
        {
            Options = options.ToList();
            return this;
        }

        public PollBuilder WithOptions(IEnumerable<string> options)
        {
            return WithOptions(options.Select(x => new PollOption { Value = x }));
        }

        public PollBuilder WithOptions(params string[] options)
        {
            return WithOptions(options.AsEnumerable());
        }

        #endregion

        #region Add Options

        public PollBuilder AddOptions(IEnumerable<PollOption> options)
        {
            Options.AddRange(options);
            return this;
        }

        public PollBuilder AddOptions(IEnumerable<string> options)
        {
            return AddOptions(options.Select(x => new PollOption { Value = x }));
        }

        public PollBuilder AddOptions(params string[] options)
        {
            return AddOptions(options.AsEnumerable());
        }

        #endregion

        #region Remove Options

        public PollBuilder RemoveOptions(IEnumerable<PollOption> options)
        {
            Options.RemoveAll(options.Contains);
            return this;
        }

        public PollBuilder RemoveOptions(params PollOption[] options)
        {
            return RemoveOptions(options.AsEnumerable());
        }

        public PollBuilder RemoveOptions(IEnumerable<string> options)
        {
            Options.RemoveAll(x => options.Contains(x.Value));
            return this;
        }

        public PollBuilder RemoveOptions(params string[] options)
        {
            return RemoveOptions(options.AsEnumerable());
        }

        public PollBuilder ClearOptions()
        {
            Options.Clear();
            return this;
        }

        #endregion

        #endregion

        #endregion

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
