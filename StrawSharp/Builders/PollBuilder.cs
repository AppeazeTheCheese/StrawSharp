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
        private readonly Poll _poll;

        public string Title { get; set; }

        public string Type
        {
            get => _poll.Type;
            set => _poll.Type = value ?? PollType.MultipleChoice;
        }

        public PollMedia Media
        {
            get => _poll.Media;
            set => _poll.Media = value ?? new PollMedia();
        }

        public PollConfig Config
        {
            get => _poll.Config;
            set => _poll.Config = value ?? new PollConfig();
        }

        public PollMeta Meta
        {
            get => _poll.Meta;
            set => _poll.Meta = value ?? new PollMeta();
        }

        public List<PollOption> Options
        {
            get => _poll.Options;
            set => _poll.Options = value ?? new List<PollOption>();
        }

        public PollTheme Theme
        {
            get => _poll.Theme;
            set => _poll.Theme = value ?? new PollTheme();
        }

        public Workspace Workspace
        {
            get => _poll.Workspace;
            set => _poll.Workspace = value ?? new Workspace();
        }

        public string Status { get; set; } = PollStatus.Published;

        public PollBuilder()
        {
            _poll = new Poll
            {
                Type = PollType.MultipleChoice,
                Media = new PollMedia(),
                Config = new PollConfig(),
                Meta = new PollMeta(),
                Options = new List<PollOption>(),
                Theme = new PollTheme(),
                Workspace = new Workspace()
            };
        }

        public PollBuilder(Poll poll)
        {
            _poll = new Poll(poll);
        }

        public static PollBuilder From(Poll poll)
        {
            return new PollBuilder(poll);
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

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithTitle(string title) => WithTitle(title);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithTitle(string title) => WithTitle(title);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithTitle(string title) => WithTitle(title);

        public PollBuilder WithDescription(string description)
        {
            Meta.Description = description;
            return this;
        }

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithDescription(string title) => WithDescription(title);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithDescription(string title) => WithDescription(title);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithDescription(string title) => WithDescription(title);

        public PollBuilder WithMediaId(string mediaId)
        {
            Media.Id = mediaId;
            return this;
        }

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithMediaId(string mediaId) => WithMediaId(mediaId);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithMediaId(string mediaId) => WithMediaId(mediaId);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithMediaId(string mediaId) => WithMediaId(mediaId);

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

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithThemeId(string themeId) => WithThemeId(themeId);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithThemeId(string themeId) => WithThemeId(themeId);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithThemeId(string themeId) => WithThemeId(themeId);

        public PollBuilder WithWorkspaceId(string workspaceId)
        {
            Workspace.Id = workspaceId;
            return this;
        }

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithWorkspaceId(string workspaceId) => WithWorkspaceId(workspaceId);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithWorkspaceId(string workspaceId) => WithWorkspaceId(workspaceId);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithWorkspaceId(string workspaceId) => WithWorkspaceId(workspaceId);
        
        public PollBuilder AllowComments(bool allow = true)
        {
            Config.AllowComments = allow;
            return this;
        }

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.AllowComments(bool allow) => AllowComments(allow);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.AllowComments(bool allow) => AllowComments(allow);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.AllowComments(bool allow) => AllowComments(allow);


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

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.AllowVpn(bool allow) => AllowVpn(allow);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.AllowVpn(bool allow) => AllowVpn(allow);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.AllowVpn(bool allow) => AllowVpn(allow);

        public PollBuilder WithDeadline(DateTime? deadline)
        {
            Config.Deadline = deadline;
            return this;
        }

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithDeadline(DateTime? deadline) => WithDeadline(deadline);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithDeadline(DateTime? deadline) => WithDeadline(deadline);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithDeadline(DateTime? deadline) => WithDeadline(deadline);

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

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithDuplicationChecking(string checkType) => WithDuplicationChecking(checkType);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithDuplicationChecking(string checkType) => WithDuplicationChecking(checkType);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithDuplicationChecking(string checkType) => WithDuplicationChecking(checkType);

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

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithEditVotePermissions(string permission) =>
            WithEditVotePermissions(permission);

        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithEditVotePermissions(string permission) =>
            WithEditVotePermissions(permission);

        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithEditVotePermissions(string permission) =>
            WithEditVotePermissions(permission);

        public PollBuilder HideParticipants(bool hide = true)
        {
            Config.HideParticipants = hide;
            return this;
        }

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.HideParticipants(bool hide) => HideParticipants(hide);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.HideParticipants(bool hide) => HideParticipants(hide);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.HideParticipants(bool hide) => HideParticipants(hide);

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

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithResultVisibility(string visibility) => WithResultVisibility(visibility);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithResultVisibility(string visibility) => WithResultVisibility(visibility);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithResultVisibility(string visibility) => WithResultVisibility(visibility);

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
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.RemoveOptions(params PollOption[] options) => RemoveOptions(options);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.RemoveOptions(params PollOption[] options) => RemoveOptions(options);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.RemoveOptions(params PollOption[] options) => RemoveOptions(options);

        public PollBuilder RemoveOptions(IEnumerable<PollOption> options)
        {
            Options.RemoveAll(options.Contains);
            return this;
        }

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.RemoveOptions(IEnumerable<PollOption> options) => RemoveOptions(options);
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.RemoveOptions(IEnumerable<PollOption> options) => RemoveOptions(options);
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.RemoveOptions(IEnumerable<PollOption> options) => RemoveOptions(options);

        public PollBuilder ClearOptions()
        {
            Options.Clear();
            return this;
        }

        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.ClearOptions() => ClearOptions();
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.ClearOptions() => ClearOptions();
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.ClearOptions() => ClearOptions();

        public Poll Build()
        {
            return new Poll(_poll);
        }
    }
}