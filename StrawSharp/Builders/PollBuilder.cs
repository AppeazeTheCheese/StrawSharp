using System;
using System.Collections.Generic;
using System.Linq;
using StrawSharp.Builders.Interfaces;
using StrawSharp.Models;
using StrawSharp.Models.EnumValues;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders
{
    public class PollBuilder : IMultipleChoicePollBuilder, IMeetingPollBuilder, IImagePollBuilder
    {
        private string _type = PollType.MultipleChoice;
        private PollMedia _media = new PollMedia();
        private PollConfig _config = new PollConfig();
        private PollMeta _meta = new PollMeta();
        private PollTheme _theme = new PollTheme();
        private Workspace _workspace = new Workspace();
        private List<PollOption> _options = new List<PollOption>();

        public string Title { get; set; }

        public string Type
        {
            get => _type;
            set => _type = value ?? PollType.MultipleChoice;
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

        public PollTheme Theme
        {
            get => _theme;
            set => _theme = value ?? new PollTheme();
        }

        public Workspace Workspace
        {
            get => _workspace;
            set => _workspace = value ?? new Workspace();
        }

        public string Status { get; set; } = PollStatus.Published;

        public static PollBuilder From(Poll poll)
        {
            if (poll == null) throw new ArgumentNullException(nameof(poll));

            return new PollBuilder
            {
                Title = poll.Title,
                Type = poll.Type,
                Media = new PollMedia(poll.Media),
                Config = new PollConfig(poll.Config),
                Meta = new PollMeta(poll.Meta),
                Options = poll.Options.Select(x => (PollOption) Activator.CreateInstance(x.GetType(), x)).ToList()
            };
        }

        public static IMultipleChoicePollBuilder ForMultipleChoicePoll()
        {
            return new PollBuilder
            {
                Type = PollType.MultipleChoice,
                Config = new PollConfig
                {
                    DuplicationChecking = DuplicationCheck.Ip,
                    ResultVisibility = ResultVisibility.Always,
                    EditVotePermissions = EditVotePermission.Nobody
                }
            };
        }

        public static IMeetingPollBuilder ForMeetingPoll()
        {
            return new PollBuilder
            {
                Type = PollType.Meeting,
                Config = new PollConfig
                {
                    DuplicationChecking = DuplicationCheck.None,
                    EditVotePermissions = EditVotePermission.AdminVoter,
                    ResultVisibility = ResultVisibility.Always,
                    RequireName = true
                }
            };
        }

        public static IImagePollBuilder ForImagePoll()
        {
            return new PollBuilder
            {
                Type = PollType.Image,
                Config = new PollConfig
                {
                    DuplicationChecking = DuplicationCheck.Ip,
                    EditVotePermissions = EditVotePermission.Nobody,
                    ResultVisibility = ResultVisibility.Always
                }
            };
        }

        public IMultipleChoicePollBuilder ToMultipleChoice()
        {
            Type = PollType.MultipleChoice;
            return this;
        }

        public IMeetingPollBuilder ToMeeting()
        {
            Type = PollType.Meeting;
            return this;
        }

        public IImagePollBuilder ToImage()
        {
            Type = PollType.Image;
            return this;
        }

        /// <summary>
        /// Sets the type of the poll. Known possible values in <see cref="PollType"/>
        /// </summary>
        /// <param name="pollType"></param>
        /// <returns></returns>
        public PollBuilder WithPollType(string pollType)
        {
            Type = pollType;
            return this;
        }

        public PollBuilder WithTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("The title cannot be null or empty.", nameof(title));
            }

            Title = title;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithTitle(string title) => WithTitle(title);
        IMeetingPollBuilder IMeetingPollBuilder.WithTitle(string title) => WithTitle(title);
        IImagePollBuilder IImagePollBuilder.WithTitle(string title) => WithTitle(title);

        public PollBuilder WithDescription(string description)
        {
            Meta.Description = description;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithDescription(string title) => WithDescription(title);
        IMeetingPollBuilder IMeetingPollBuilder.WithDescription(string title) => WithDescription(title);
        IImagePollBuilder IImagePollBuilder.WithDescription(string title) => WithDescription(title);

        public PollBuilder WithMediaId(string mediaId)
        {
            Media.Id = mediaId;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithMediaId(string mediaId) => WithMediaId(mediaId);
        IMeetingPollBuilder IMeetingPollBuilder.WithMediaId(string mediaId) => WithMediaId(mediaId);
        IImagePollBuilder IImagePollBuilder.WithMediaId(string mediaId) => WithMediaId(mediaId);

        /// <summary>
        /// Sets the current theme given the theme ID.
        /// You may either pass the ID of a custom theme or of a default theme from <see cref="DefaultTheme"/>.
        /// </summary>
        /// <param name="themeId"></param>
        /// <returns></returns>
        public PollBuilder WithThemeId(string themeId)
        {
            Theme.Id = themeId;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithThemeId(string themeId) => WithThemeId(themeId);
        IMeetingPollBuilder IMeetingPollBuilder.WithThemeId(string themeId) => WithThemeId(themeId);
        IImagePollBuilder IImagePollBuilder.WithThemeId(string themeId) => WithThemeId(themeId);

        public PollBuilder WithWorkspaceId(string workspaceId)
        {
            Workspace.Id = workspaceId;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithWorkspaceId(string workspaceId) => WithWorkspaceId(workspaceId);
        IMeetingPollBuilder IMeetingPollBuilder.WithWorkspaceId(string workspaceId) => WithWorkspaceId(workspaceId);
        IImagePollBuilder IImagePollBuilder.WithWorkspaceId(string workspaceId) => WithWorkspaceId(workspaceId);
        
        public PollBuilder AllowComments(bool allow = true)
        {
            Config.AllowComments = allow;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.AllowComments(bool allow) => AllowComments(allow);
        IMeetingPollBuilder IMeetingPollBuilder.AllowComments(bool allow) => AllowComments(allow);
        IImagePollBuilder IImagePollBuilder.AllowComments(bool allow) => AllowComments(allow);


        public PollBuilder AllowIndeterminate(bool allow = true)
        {
            Config.AllowIndeterminate = allow;
            return this;
        }

        IMeetingPollBuilder IMeetingPollBuilder.AllowIndeterminate(bool allow) => AllowIndeterminate(allow);

        public PollBuilder AllowOtherOption(bool allow = true)
        {
            Config.AllowOtherOption = allow;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.AllowOtherOption(bool allow) => AllowOtherOption(allow);

        public PollBuilder AllowVpn(bool allow = true)
        {
            Config.AllowVpn = allow;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.AllowVpn(bool allow) => AllowVpn(allow);
        IMeetingPollBuilder IMeetingPollBuilder.AllowVpn(bool allow) => AllowVpn(allow);
        IImagePollBuilder IImagePollBuilder.AllowVpn(bool allow) => AllowVpn(allow);

        public PollBuilder WithDeadline(DateTime? deadline)
        {
            Config.Deadline = deadline;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithDeadline(DateTime? deadline) => WithDeadline(deadline);
        IMeetingPollBuilder IMeetingPollBuilder.WithDeadline(DateTime? deadline) => WithDeadline(deadline);
        IImagePollBuilder IImagePollBuilder.WithDeadline(DateTime? deadline) => WithDeadline(deadline);

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

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithDuplicationChecking(string checkType) => WithDuplicationChecking(checkType);
        IMeetingPollBuilder IMeetingPollBuilder.WithDuplicationChecking(string checkType) => WithDuplicationChecking(checkType);
        IImagePollBuilder IImagePollBuilder.WithDuplicationChecking(string checkType) => WithDuplicationChecking(checkType);

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

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithEditVotePermissions(string permission) =>
            WithEditVotePermissions(permission);

        IMeetingPollBuilder IMeetingPollBuilder.WithEditVotePermissions(string permission) =>
            WithEditVotePermissions(permission);

        IImagePollBuilder IImagePollBuilder.WithEditVotePermissions(string permission) =>
            WithEditVotePermissions(permission);

        public PollBuilder HideParticipants(bool hide = true)
        {
            Config.HideParticipants = hide;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.HideParticipants(bool hide) => HideParticipants(hide);
        IMeetingPollBuilder IMeetingPollBuilder.HideParticipants(bool hide) => HideParticipants(hide);
        IImagePollBuilder IImagePollBuilder.HideParticipants(bool hide) => HideParticipants(hide);

        public PollBuilder MultipleChoice(bool multipleChoice = true)
        {
            Config.IsMultipleChoice = multipleChoice;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.MultipleChoice(bool multipleChoice) =>
            MultipleChoice(multipleChoice);

        public PollBuilder WithMinChoices(int? minChoices = null)
        {
            Config.MinChoices = minChoices;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithMinChoices(int? minChoices) =>
            WithMinChoices(minChoices);

        public PollBuilder WithMaxChoices(int? maxChoices = null)
        {
            Config.MaxChoices = maxChoices;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithMaxChoices(int? minChoices) =>
            WithMaxChoices(minChoices);

        /// <summary>
        /// Set the layout of the poll.
        /// </summary>
        /// <param name="layout">Known values in <see cref="PollLayout"/></param>
        /// <returns></returns>
        public PollBuilder WithLayout(string layout)
        {
            Config.Layout = layout;
            return this;
        }

        IImagePollBuilder IImagePollBuilder.WithLayout(string layout) => WithLayout(layout);

        public PollBuilder RequireNames(bool require = true)
        {
            Config.RequireName = require;
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.RequireNames(bool require) => RequireNames(require);
        IImagePollBuilder IImagePollBuilder.RequireNames(bool require) => RequireNames(require);

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

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithResultVisibility(string visibility) => WithResultVisibility(visibility);
        IMeetingPollBuilder IMeetingPollBuilder.WithResultVisibility(string visibility) => WithResultVisibility(visibility);
        IImagePollBuilder IImagePollBuilder.WithResultVisibility(string visibility) => WithResultVisibility(visibility);

        public PollBuilder WithConfig(PollConfig config)
        {
            Config = config;
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
            return WithOptions(options.Select(x => new TextPollOption {Value = x}));
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithTextOptions(IEnumerable<string> options) => WithTextOptions(options);

        public PollBuilder WithTextOptions(params string[] options)
        {
            return WithTextOptions(options.AsEnumerable());
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithTextOptions(params string[] options) => WithTextOptions(options);

        public PollBuilder WithDateOptions(IEnumerable<DateTime> options)
        {
            return WithOptions(options.Select(x => new DatePollOption {Date = x}));
        }

        IMeetingPollBuilder IMeetingPollBuilder.WithDateOptions(IEnumerable<DateTime> options) => WithDateOptions(options);

        public PollBuilder WithDateOptions(params DateTime[] options)
        {
            return WithDateOptions(options.AsEnumerable());
        }

        IMeetingPollBuilder IMeetingPollBuilder.WithDateOptions(params DateTime[] options) => WithDateOptions(options);

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

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.AddTextOptions(IEnumerable<string> options) => AddTextOptions(options);

        public PollBuilder AddTextOptions(params string[] options)
        {
            return AddTextOptions(options.AsEnumerable());
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.AddTextOptions(params string[] options) => AddTextOptions(options);

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

        IImagePollBuilder IImagePollBuilder.AddImageOption(string mediaId, string caption) => AddImageOption(mediaId, caption);

        public PollBuilder AddDateOptions(IEnumerable<DateTime> dates)
        {
            return AddOptions(dates.Select(x => new DatePollOption {Date = x}));
        }

        IMeetingPollBuilder IMeetingPollBuilder.AddDateOptions(IEnumerable<DateTime> dates) => AddDateOptions(dates);

        public PollBuilder AddDateOptions(params DateTime[] dates)
        {
            return AddDateOptions(dates.AsEnumerable());
        }

        IMeetingPollBuilder IMeetingPollBuilder.AddDateOptions(params DateTime[] dates) => AddDateOptions(dates);

        public PollBuilder AddTimeRangeOption(DateTime startTime, DateTime endTime)
        {
            return AddOptions(new TimeRangePollOption {StartTime = startTime, EndTime = endTime});
        }

        IMeetingPollBuilder IMeetingPollBuilder.AddTimeRangeOption(DateTime startTime, DateTime endTime) => AddTimeRangeOption(startTime, endTime);

        public PollBuilder RemoveOptions(params PollOption[] options)
        {
            return RemoveOptions(options.AsEnumerable());
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.RemoveOptions(params PollOption[] options) => RemoveOptions(options);
        IMeetingPollBuilder IMeetingPollBuilder.RemoveOptions(params PollOption[] options) => RemoveOptions(options);
        IImagePollBuilder IImagePollBuilder.RemoveOptions(params PollOption[] options) => RemoveOptions(options);

        public PollBuilder RemoveOptions(IEnumerable<PollOption> options)
        {
            Options.RemoveAll(options.Contains);
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.RemoveOptions(IEnumerable<PollOption> options) => RemoveOptions(options);
        IMeetingPollBuilder IMeetingPollBuilder.RemoveOptions(IEnumerable<PollOption> options) => RemoveOptions(options);
        IImagePollBuilder IImagePollBuilder.RemoveOptions(IEnumerable<PollOption> options) => RemoveOptions(options);

        public PollBuilder ClearOptions()
        {
            Options.Clear();
            return this;
        }

        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.ClearOptions() => ClearOptions();
        IMeetingPollBuilder IMeetingPollBuilder.ClearOptions() => ClearOptions();
        IImagePollBuilder IImagePollBuilder.ClearOptions() => ClearOptions();

        public Poll Build()
        {
            var poll = new Poll
            {
                Title = Title,
                Type = Type,
                Status = Status,
                Config = Config
            };

            if (!string.IsNullOrWhiteSpace(Media.Id))
                poll.Media = new PollMedia {Id = Media.Id};
            if (!string.IsNullOrWhiteSpace(Theme.Id))
                poll.Theme = new PollTheme {Id = Theme.Id};
            if (!string.IsNullOrWhiteSpace(Workspace.Id))
                poll.Workspace = new Workspace {Id = Workspace.Id};

            if (!string.IsNullOrWhiteSpace(Meta.Description))
                poll.Meta.Description = Meta.Description;
            if (!string.IsNullOrWhiteSpace(Meta.Location))
                poll.Meta.Location = Meta.Location;

            poll.Options.AddRange(Options.Where(x => x != null));
            return poll;
        }
    }
}