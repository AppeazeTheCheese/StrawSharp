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

        /// <summary>
        /// The title of the poll
        /// </summary>
        public string Title 
        { 
            get => _poll.Title; 
            set => _poll.Title = value;
        }

        /// <summary>
        /// The type of the poll. Known values in <see cref="PollType"/>.
        /// </summary>
        public string Type
        {
            get => _poll.Type;
            set => _poll.Type = value ?? PollType.MultipleChoice;
        }

        /// <summary>
        /// The media (image, video, gif) displayed in the poll.
        /// </summary>
        public PollMedia Media
        {
            get => _poll.Media;
            set => _poll.Media = value ?? new PollMedia();
        }

        /// <summary>
        /// The poll's configuration.
        /// </summary>
        public PollConfig Config
        {
            get => _poll.Config;
            set => _poll.Config = value ?? new PollConfig();
        }

        /// <summary>
        /// Information about the poll.
        /// </summary>
        public PollMeta Meta
        {
            get => _poll.Meta;
            set => _poll.Meta = value ?? new PollMeta();
        }

        /// <summary>
        /// The options in the poll.
        /// </summary>
        public List<PollOption> Options
        {
            get => _poll.Options;
            set => _poll.Options = value ?? new List<PollOption>();
        }

        /// <summary>
        /// The poll's appearance.
        /// </summary>
        public PollTheme Theme
        {
            get => _poll.Theme;
            set => _poll.Theme = value ?? new PollTheme();
        }

        /// <summary>
        /// The workspace that the poll belongs to.
        /// </summary>
        public Workspace Workspace
        {
            get => _poll.Workspace;
            set => _poll.Workspace = value ?? new Workspace();
        }

        /// <summary>
        /// The current status of the poll. Known values in <see cref="PollStatus"/>.
        /// </summary>
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

        /// <summary>
        /// Creates a copy of the provided <paramref name="poll"/> and uses it as the base for the returned <see cref="PollBuilder"/>.
        /// </summary>
        /// <param name="poll">The poll to use.</param>
        public PollBuilder(Poll poll)
        {
            _poll = new Poll(poll);
        }

        /// <summary>
        /// Creates a new <see cref="PollBuilder"/> instance using a copy of the provided <paramref name="poll"/> as a base.
        /// </summary>
        /// <param name="poll">The poll to use.</param>
        /// <returns>The new <see cref="PollBuilder"/> instance.</returns>
        public static PollBuilder From(Poll poll)
        {
            return new PollBuilder(poll);
        }

        /// <summary>
        /// Creates a new <see cref="PollBuilder"/> and sets the default settings for the multiple choice poll type.
        /// </summary>
        /// <returns>A new <see cref="PollBuilder"/> as an instance of <see cref="IMultipleChoicePollBuilder"/>.</returns>
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

        /// <summary>
        /// Creates a new <see cref="PollBuilder"/> and sets the default settings for the meeting poll type.
        /// </summary>
        /// <returns>A new <see cref="PollBuilder"/> as an instance of <see cref="IMeetingPollBuilder"/>.</returns>
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

        /// <summary>
        /// Creates a new <see cref="PollBuilder"/> and sets the default settings for the multiple choice poll type.
        /// </summary>
        /// <returns>A new <see cref="PollBuilder"/> as an instance of <see cref="IImagePollBuilder"/>.</returns>
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

        /// <summary>
        /// Sets the <see cref="Type"/> of the current <see cref="PollBuilder"/> instance to <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <returns>The current <see cref="PollBuilder"/> as an instance of <see cref="IMultipleChoicePollBuilder"/>.</returns>
        public IMultipleChoicePollBuilder ToMultipleChoice()
        {
            Type = PollType.MultipleChoice;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Type"/> of the current <see cref="PollBuilder"/> instance to <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <returns>The current <see cref="PollBuilder"/> as an instance of <see cref="IMeetingPollBuilder"/>.</returns>
        public IMeetingPollBuilder ToMeeting()
        {
            Type = PollType.Meeting;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Type"/> of the current <see cref="PollBuilder"/> instance to <see cref="PollType.Image"/>.
        /// </summary>
        /// <returns>The current <see cref="PollBuilder"/> as an instance of <see cref="IImagePollBuilder"/>.</returns>
        public IImagePollBuilder ToImage()
        {
            Type = PollType.Image;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Type"/> of the poll to the provided <paramref name="pollType"/>. Known possible values in <see cref="PollType"/>
        /// </summary>
        /// <param name="pollType">The type to set the poll to. Known possible values in <see cref="PollType"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithPollType(string pollType)
        {
            Type = pollType;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Title"/> of the poll to the provided <paramref name="title"/>.
        /// </summary>
        /// <param name="title">The title to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when no title is provided.</exception>
        public PollBuilder WithTitle(string title)
        {
            if (string.IsNullOrWhiteSpace(title))
            {
                throw new ArgumentException("The title cannot be null or empty.", nameof(title));
            }

            Title = title;
            return this;
        }

        /// <summary>
        /// Sets the <see cref="Title"/> of the poll to the provided <paramref name="title"/>.
        /// </summary>
        /// <param name="title">The title to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when no title is provided.</exception>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithTitle(string title) => WithTitle(title);
        /// <summary>
        /// Sets the <see cref="Title"/> of the poll to the provided <paramref name="title"/>.
        /// </summary>
        /// <param name="title">The title to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when no title is provided.</exception>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithTitle(string title) => WithTitle(title);
        /// <summary>
        /// Sets the <see cref="Title"/> of the poll to the provided <paramref name="title"/>.
        /// </summary>
        /// <param name="title">The title to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        /// <exception cref="ArgumentException">Thrown when no title is provided.</exception>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithTitle(string title) => WithTitle(title);

        /// <summary>
        /// Sets the poll's description.
        /// </summary>
        /// <param name="description">The description to be set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithDescription(string description)
        {
            Meta.Description = description;
            return this;
        }

        /// <summary>
        /// Sets the poll's description.
        /// </summary>
        /// <param name="description">The description to be set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithDescription(string description) => WithDescription(description);
        /// <summary>
        /// Sets the poll's description.
        /// </summary>
        /// <param name="description">The description to be set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithDescription(string description) => WithDescription(description);
        /// <summary>
        /// Sets the poll's description.
        /// </summary>
        /// <param name="description">The description to be set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithDescription(string description) => WithDescription(description);

        /// <summary>
        /// Sets the ID of the media to use in the poll.
        /// </summary>
        /// <param name="mediaId">The ID to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithMediaId(string mediaId)
        {
            Media.Id = mediaId;
            return this;
        }

        /// <summary>
        /// Sets the ID of the media to use in the poll.
        /// </summary>
        /// <param name="mediaId">The ID to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithMediaId(string mediaId) => WithMediaId(mediaId);
        /// <summary>
        /// Sets the ID of the media to use in the poll.
        /// </summary>
        /// <param name="mediaId">The ID to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithMediaId(string mediaId) => WithMediaId(mediaId);
        /// <summary>
        /// Sets the ID of the media to use in the poll.
        /// </summary>
        /// <param name="mediaId">The ID to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithMediaId(string mediaId) => WithMediaId(mediaId);

        /// <summary>
        /// Sets the theme (appearance) of the poll.
        /// You may either pass the ID of a custom theme or of a default theme from <see cref="DefaultTheme"/>.
        /// </summary>
        /// <param name="themeId">The ID of the theme to apply.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithThemeId(string themeId)
        {
            Theme.Id = themeId;
            return this;
        }

        /// <summary>
        /// Sets the theme (appearance) of the poll.
        /// You may either pass the ID of a custom theme or of a default theme from <see cref="DefaultTheme"/>.
        /// </summary>
        /// <param name="themeId">The ID of the theme to apply.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithThemeId(string themeId) => WithThemeId(themeId);
        /// <summary>
        /// Sets the theme (appearance) of the poll.
        /// You may either pass the ID of a custom theme or of a default theme from <see cref="DefaultTheme"/>.
        /// </summary>
        /// <param name="themeId">The ID of the theme to apply.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithThemeId(string themeId) => WithThemeId(themeId);
        /// <summary>
        /// Sets the theme (appearance) of the poll.
        /// You may either pass the ID of a custom theme or of a default theme from <see cref="DefaultTheme"/>.
        /// </summary>
        /// <param name="themeId">The ID of the theme to apply.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithThemeId(string themeId) => WithThemeId(themeId);

        /// <summary>
        /// Adds the poll to the workspace associated with the given <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithWorkspaceId(string workspaceId)
        {
            Workspace.Id = workspaceId;
            return this;
        }

        /// <summary>
        /// Adds the poll to the workspace associated with the given <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithWorkspaceId(string workspaceId) => WithWorkspaceId(workspaceId);
        /// <summary>
        /// Adds the poll to the workspace associated with the given <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithWorkspaceId(string workspaceId) => WithWorkspaceId(workspaceId);
        /// <summary>
        /// Adds the poll to the workspace associated with the given <paramref name="workspaceId"/>.
        /// </summary>
        /// <param name="workspaceId">The ID of the workspace.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithWorkspaceId(string workspaceId) => WithWorkspaceId(workspaceId);

        /// <summary>
        /// Sets if participants should be allowed to post comments on the poll.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if comments should be allowed, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AllowComments(bool allow = true)
        {
            Config.AllowComments = allow;
            return this;
        }

        /// <summary>
        /// Sets if participants should be allowed to post comments on the poll.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if comments should be allowed, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.AllowComments(bool allow) => AllowComments(allow);
        /// <summary>
        /// Sets if participants should be allowed to post comments on the poll.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if comments should be allowed, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.AllowComments(bool allow) => AllowComments(allow);
        /// <summary>
        /// Sets if participants should be allowed to post comments on the poll.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if comments should be allowed, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.AllowComments(bool allow) => AllowComments(allow);

        /// <summary>
        /// Sets if participants should be allowed to select "if need be" (yellow check mark in parentheses) for this poll.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if participants should be able to select the "if need be" option, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AllowIndeterminate(bool allow = true)
        {
            Config.AllowIndeterminate = allow;
            return this;
        }

        /// <summary>
        /// Sets if participants should be allowed to select "if need be" (yellow check mark in parentheses) for this poll.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if participants should be able to select the "if need be" option, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IMeetingPollBuilder.AllowIndeterminate(bool allow) => AllowIndeterminate(allow);

        /// <summary>
        /// Sets if participants should be allowed to add their own options to this poll.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if participants should be able to add their own options, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AllowOtherOption(bool allow = true)
        {
            Config.AllowOtherOption = allow;
            return this;
        }

        /// <summary>
        /// Sets if participants should be allowed to add their own options to this poll.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if participants should be able to add their own options, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.AllowOtherOption(bool allow) => AllowOtherOption(allow);

        /// <summary>
        /// Sets if participants using a VPN should be allowed to vote in this poll.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if VPN participants should be allowed to vote, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AllowVpn(bool allow = true)
        {
            Config.AllowVpn = allow;
            return this;
        }

        /// <summary>
        /// Sets if participants using a VPN should be allowed to vote in this poll.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if VPN participants should be allowed to vote, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.AllowVpn(bool allow) => AllowVpn(allow);
        /// <summary>
        /// Sets if participants using a VPN should be allowed to vote in this poll.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if VPN participants should be allowed to vote, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.AllowVpn(bool allow) => AllowVpn(allow);
        /// <summary>
        /// Sets if participants using a VPN should be allowed to vote in this poll.
        /// </summary>
        /// <param name="allow"><see langword="true"/> if VPN participants should be allowed to vote, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.AllowVpn(bool allow) => AllowVpn(allow);

        /// <summary>
        /// Sets the deadline for the poll. Nobody will be able to vote after this date.
        /// </summary>
        /// <param name="deadline">The date and time at which participants should no longer be able to vote. For no deadline, set to <see langword="null"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithDeadline(DateTime? deadline)
        {
            Config.Deadline = deadline;
            return this;
        }

        /// <summary>
        /// Sets the deadline for the poll. Nobody will be able to vote after this date.
        /// </summary>
        /// <param name="deadline">The date and time at which participants should no longer be able to vote. For no deadline, set to <see langword="null"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithDeadline(DateTime? deadline) => WithDeadline(deadline);
        /// <summary>
        /// Sets the deadline for the poll. Nobody will be able to vote after this date.
        /// </summary>
        /// <param name="deadline">The date and time at which participants should no longer be able to vote. For no deadline, set to <see langword="null"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithDeadline(DateTime? deadline) => WithDeadline(deadline);
        /// <summary>
        /// Sets the deadline for the poll. Nobody will be able to vote after this date.
        /// </summary>
        /// <param name="deadline">The date and time at which participants should no longer be able to vote. For no deadline, set to <see langword="null"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithDeadline(DateTime? deadline) => WithDeadline(deadline);

        /// <summary>
        /// Sets the type of duplication checking to be used by the poll.
        /// </summary>
        /// <param name="checkType">Known values in <see cref="DuplicationCheck"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithDuplicationChecking(string checkType)
        {
            Config.DuplicationChecking = checkType;
            return this;
        }

        /// <summary>
        /// Sets the type of duplication checking to be used by the poll.
        /// </summary>
        /// <param name="checkType">Known values in <see cref="DuplicationCheck"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithDuplicationChecking(string checkType) => WithDuplicationChecking(checkType);
        /// <summary>
        /// Sets the type of duplication checking to be used by the poll.
        /// </summary>
        /// <param name="checkType">Known values in <see cref="DuplicationCheck"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithDuplicationChecking(string checkType) => WithDuplicationChecking(checkType);
        /// <summary>
        /// Sets the type of duplication checking to be used by the poll.
        /// </summary>
        /// <param name="checkType">Known values in <see cref="DuplicationCheck"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithDuplicationChecking(string checkType) => WithDuplicationChecking(checkType);

        /// <summary>
        /// Sets who has access to edit votes.
        /// </summary>
        /// <param name="permission">Known values in <see cref="EditVotePermission"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithEditVotePermissions(string permission)
        {
            Config.EditVotePermissions = permission;
            return this;
        }

        /// <summary>
        /// Sets who has access to edit votes.
        /// </summary>
        /// <param name="permission">Known values in <see cref="EditVotePermission"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithEditVotePermissions(string permission) =>
            WithEditVotePermissions(permission);
        /// <summary>
        /// Sets who has access to edit votes.
        /// </summary>
        /// <param name="permission">Known values in <see cref="EditVotePermission"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithEditVotePermissions(string permission) =>
            WithEditVotePermissions(permission);
        /// <summary>
        /// Sets who has access to edit votes.
        /// </summary>
        /// <param name="permission">Known values in <see cref="EditVotePermission"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithEditVotePermissions(string permission) =>
            WithEditVotePermissions(permission);

        /// <summary>
        /// Sets whether or not to hide participants from each other.
        /// </summary>
        /// <param name="hide"><see langword="true"/> if participants should be hidden from each other, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder HideParticipants(bool hide = true)
        {
            Config.HideParticipants = hide;
            return this;
        }

        /// <summary>
        /// Sets whether or not to hide participants from each other.
        /// </summary>
        /// <param name="hide"><see langword="true"/> if participants should be hidden from each other, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.HideParticipants(bool hide) => HideParticipants(hide);
        /// <summary>
        /// Sets whether or not to hide participants from each other.
        /// </summary>
        /// <param name="hide"><see langword="true"/> if participants should be hidden from each other, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.HideParticipants(bool hide) => HideParticipants(hide);
        /// <summary>
        /// Sets whether or not to hide participants from each other.
        /// </summary>
        /// <param name="hide"><see langword="true"/> if participants should be hidden from each other, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.HideParticipants(bool hide) => HideParticipants(hide);

        /// <summary>
        /// Sets whether this poll should allow participants to select multiple choices or just one.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="multipleChoice"><see langword="true"/> if participants should be able to select multiple answers, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder MultipleChoice(bool multipleChoice = true)
        {
            Config.IsMultipleChoice = multipleChoice;
            return this;
        }

        /// <summary>
        /// Sets whether this poll should allow participants to select multiple choices or just one.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="multipleChoice"><see langword="true"/> if participants should be able to select multiple answers, otherwise <see langword="false"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.MultipleChoice(bool multipleChoice) =>
            MultipleChoice(multipleChoice);

        /// <summary>
        /// Sets the minimum number of choices participants are required to select for polls that allow multiple choices to be selected.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>
        /// </summary>
        /// <param name="minChoices">The minimum number of choices participants can select. This defaults to 1 if set to<see langword="null"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithMinChoices(int? minChoices = null)
        {
            Config.MinChoices = minChoices;
            return this;
        }

        /// <summary>
        /// Sets the minimum number of choices participants are required to select for polls that allow multiple choices to be selected.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>
        /// </summary>
        /// <param name="minChoices">The minimum number of choices participants can select. This defaults to 1 if set to<see langword="null"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithMinChoices(int? minChoices) =>
            WithMinChoices(minChoices);

        /// <summary>
        /// Sets the maximum number of choices participants are required to select for polls that allow multiple choices to be selected.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>
        /// </summary>
        /// <param name="maxChoices">The maximum number of choices participants can select, or <see langword="null"/> for unlimited.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithMaxChoices(int? maxChoices = null)
        {
            Config.MaxChoices = maxChoices;
            return this;
        }

        /// <summary>
        /// Sets the maximum number of choices participants are required to select for polls that allow multiple choices to be selected.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>
        /// </summary>
        /// <param name="maxChoices">The maximum number of choices participants can select, or <see langword="null"/> for unlimited.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithMaxChoices(int? maxChoices) =>
            WithMaxChoices(maxChoices);

        /// <summary>
        /// Set the layout of the poll.
        /// This currently only applies to polls of type <see cref="PollType.Image"/>
        /// </summary>
        /// <param name="layout">Known values in <see cref="PollLayout"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithLayout(string layout)
        {
            Config.Layout = layout;
            return this;
        }

        /// <summary>
        /// Sets the layout of the poll.
        /// This currently only applies to polls of type <see cref="PollType.Image"/>
        /// </summary>
        /// <param name="layout">Known values in <see cref="PollLayout"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IImagePollBuilder.WithLayout(string layout) => WithLayout(layout);

        /// <summary>
        /// Sets whether or not participants are required to enter their name when voting.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/> and <see cref="PollType.Image"/>.
        /// </summary>
        /// <param name="require"><see langword="true"/> if participants should be required to enter their names, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder RequireNames(bool require = true)
        {
            Config.RequireName = require;
            return this;
        }

        /// <summary>
        /// Sets whether or not participants are required to enter their name when voting.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/> and <see cref="PollType.Image"/>.
        /// </summary>
        /// <param name="require"><see langword="true"/> if participants should be required to enter their names, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.RequireNames(bool require) => RequireNames(require);
        /// <summary>
        /// Sets whether or not participants are required to enter their name when voting.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/> and <see cref="PollType.Image"/>.
        /// </summary>
        /// <param name="require"><see langword="true"/> if participants should be required to enter their names, otherwise <see langword="false"/>.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IImagePollBuilder.RequireNames(bool require) => RequireNames(require);

        /// <summary>
        /// Sets when the results of the poll should become visible to participants.
        /// </summary>
        /// <param name="visibility">Known values in <see cref="ResultVisibility"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithResultVisibility(string visibility)
        {
            Config.ResultVisibility = visibility;
            return this;
        }

        /// <summary>
        /// Sets when the results of the poll should become visible to participants.
        /// </summary>
        /// <param name="visibility">Known values in <see cref="ResultVisibility"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.WithResultVisibility(string visibility) => WithResultVisibility(visibility);
        /// <summary>
        /// Sets when the results of the poll should become visible to participants.
        /// </summary>
        /// <param name="visibility">Known values in <see cref="ResultVisibility"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.WithResultVisibility(string visibility) => WithResultVisibility(visibility);
        /// <summary>
        /// Sets when the results of the poll should become visible to participants.
        /// </summary>
        /// <param name="visibility">Known values in <see cref="ResultVisibility"/></param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.WithResultVisibility(string visibility) => WithResultVisibility(visibility);

        /// <summary>
        /// Sets the poll's config.
        /// </summary>
        /// <param name="config">The config to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithConfig(PollConfig config)
        {
            Config = config;
            return this;
        }

        /// <summary>
        /// Sets the poll's meta.
        /// </summary>
        /// <param name="meta">The meta to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithMeta(PollMeta meta)
        {
            Meta = meta;
            return this;
        }

        /// <summary>
        /// Sets the poll's options.
        /// </summary>
        /// <param name="options">THe options to set.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithOptions(IEnumerable<PollOption> options)
        {
            Options = options.ToList();
            return this;
        }

        /// <summary>
        /// Sets the poll's options to text options representing the provided <see langword="string"/>s.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="options">The <see langword="string"/>s to create text options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithTextOptions(IEnumerable<string> options)
        {
            return WithOptions(options.Select(x => new TextPollOption {Value = x}));
        }

        /// <summary>
        /// Sets the poll's options to text options representing the provided <see langword="string"/>s.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="options">The <see langword="string"/>s to create text options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithTextOptions(IEnumerable<string> options) => WithTextOptions(options);

        /// <summary>
        /// Sets the poll's options to text options representing the provided <see langword="string"/>s.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="options">The <see langword="string"/>s to create text options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithTextOptions(params string[] options)
        {
            return WithTextOptions(options.AsEnumerable());
        }

        /// <summary>
        /// Sets the poll's options to text options representing the provided <see langword="string"/>s.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="options">The <see langword="string"/>s to create text options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.WithTextOptions(params string[] options) => WithTextOptions(options);

        /// <summary>
        /// Sets the poll's options to date options representing the provided <see cref="DateTime"/>s.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="options">The <see cref="DateTime"/>s to create date options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithDateOptions(IEnumerable<DateTime> options)
        {
            return WithOptions(options.Select(x => new DatePollOption {Date = x}));
        }

        /// <summary>
        /// Sets the poll's options to date options representing the provided <see cref="DateTime"/>s.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="options">The <see cref="DateTime"/>s to create date options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IMeetingPollBuilder.WithDateOptions(IEnumerable<DateTime> options) => WithDateOptions(options);

        /// <summary>
        /// Sets the poll's options to date options representing the provided <see cref="DateTime"/>s.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="options">The <see cref="DateTime"/>s to create date options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder WithDateOptions(params DateTime[] options)
        {
            return WithDateOptions(options.AsEnumerable());
        }

        /// <summary>
        /// Sets the poll's options to date options representing the provided <see cref="DateTime"/>s.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="options">The <see cref="DateTime"/>s to create date options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IMeetingPollBuilder.WithDateOptions(params DateTime[] options) => WithDateOptions(options);

        /// <summary>
        /// Adds options to the poll.
        /// </summary>
        /// <param name="options">The options to add to the poll.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AddOptions(IEnumerable<PollOption> options)
        {
            Options.AddRange(options);
            return this;
        }

        /// <summary>
        /// Adds options to the poll.
        /// </summary>
        /// <param name="options">The options to add to the poll.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AddOptions(params PollOption[] options)
        {
            return AddOptions(options.AsEnumerable());
        }

        /// <summary>
        /// Adds text options to the poll representing the provided <see langword="string"/>s.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="options">The <see langword="string"/>s to create text options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AddTextOptions(IEnumerable<string> options)
        {
            return AddOptions(options.Select(x => new TextPollOption {Value = x}));
        }

        /// <summary>
        /// Adds text options to the poll representing the provided <see langword="string"/>s.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="options">The <see langword="string"/>s to create text options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.AddTextOptions(IEnumerable<string> options) => AddTextOptions(options);

        /// <summary>
        /// Adds text options to the poll representing the provided <see langword="string"/>s.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="options">The <see langword="string"/>s to create text options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AddTextOptions(params string[] options)
        {
            return AddTextOptions(options.AsEnumerable());
        }

        /// <summary>
        /// Adds text options to the poll representing the provided <see langword="string"/>s.
        /// This currently only applies to polls of type <see cref="PollType.MultipleChoice"/>.
        /// </summary>
        /// <param name="options">The <see langword="string"/>s to create text options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IMultipleChoicePollBuilder.AddTextOptions(params string[] options) => AddTextOptions(options);

        /// <summary>
        /// Adds an image option to the poll.
        /// This currently only applies to polls of type <see cref="PollType.Image"/>.
        /// </summary>
        /// <param name="mediaId">The unique ID of the <see cref="PollMedia"/> object to add as an image option.</param>
        /// <param name="caption">The image's caption.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
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

        /// <summary>
        /// Adds an image option to the poll.
        /// This currently only applies to polls of type <see cref="PollType.Image"/>.
        /// </summary>
        /// <param name="mediaId">The unique ID of the <see cref="PollMedia"/> object to add as an image option.</param>
        /// <param name="caption">The image's caption.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IImagePollBuilder.AddImageOption(string mediaId, string caption) => AddImageOption(mediaId, caption);

        /// <summary>
        /// Adds date options to the poll representing the provided <see cref="DateTime"/>s.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="dates">The <see cref="DateTime"/>s to create date options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AddDateOptions(IEnumerable<DateTime> dates)
        {
            return AddOptions(dates.Select(x => new DatePollOption {Date = x}));
        }

        /// <summary>
        /// Adds date options to the poll representing the provided <see cref="DateTime"/>s.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="dates">The <see cref="DateTime"/>s to create date options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IMeetingPollBuilder.AddDateOptions(IEnumerable<DateTime> dates) => AddDateOptions(dates);

        /// <summary>
        /// Adds date options to the poll representing the provided <see cref="DateTime"/>s.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="dates">The <see cref="DateTime"/>s to create date options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AddDateOptions(params DateTime[] dates)
        {
            return AddDateOptions(dates.AsEnumerable());
        }

        /// <summary>
        /// Adds date options to the poll representing the provided <see cref="DateTime"/>s.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="dates">The <see cref="DateTime"/>s to create date options for.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IMeetingPollBuilder.AddDateOptions(params DateTime[] dates) => AddDateOptions(dates);

        /// <summary>
        /// Adds a date range option to the poll given the <paramref name="startTime"/> and <paramref name="endTime"/>.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="startTime">The beginning of the time range.</param>
        /// <param name="endTime">The end of the time range.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder AddTimeRangeOption(DateTime startTime, DateTime endTime)
        {
            return AddOptions(new TimeRangePollOption {StartTime = startTime, EndTime = endTime});
        }

        /// <summary>
        /// Adds a date range option to the poll given the <paramref name="startTime"/> and <paramref name="endTime"/>.
        /// This currently only applies to polls of type <see cref="PollType.Meeting"/>.
        /// </summary>
        /// <param name="startTime">The beginning of the time range.</param>
        /// <param name="endTime">The end of the time range.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IMeetingPollBuilder.AddTimeRangeOption(DateTime startTime, DateTime endTime) => AddTimeRangeOption(startTime, endTime);


        /// <summary>
        /// Removes options from the poll based on object equality.
        /// </summary>
        /// <param name="options">The options to remove.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder RemoveOptions(params PollOption[] options)
        {
            return RemoveOptions(options.AsEnumerable());
        }
        /// <summary>
        /// Removes options from the poll based on object equality.
        /// </summary>
        /// <param name="options">The options to remove.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.RemoveOptions(params PollOption[] options) => RemoveOptions(options);
        /// <summary>
        /// Removes options from the poll based on object equality.
        /// </summary>
        /// <param name="options">The options to remove.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.RemoveOptions(params PollOption[] options) => RemoveOptions(options);
        /// <summary>
        /// Removes options from the poll based on object equality.
        /// </summary>
        /// <param name="options">The options to remove.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.RemoveOptions(params PollOption[] options) => RemoveOptions(options);

        /// <summary>
        /// Removes options from the poll based on object equality.
        /// </summary>
        /// <param name="options">The options to remove.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder RemoveOptions(IEnumerable<PollOption> options)
        {
            Options.RemoveAll(options.Contains);
            return this;
        }

        /// <summary>
        /// Removes options from the poll based on object equality.
        /// </summary>
        /// <param name="options">The options to remove.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.RemoveOptions(IEnumerable<PollOption> options) => RemoveOptions(options);
        /// <summary>
        /// Removes options from the poll based on object equality.
        /// </summary>
        /// <param name="options">The options to remove.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.RemoveOptions(IEnumerable<PollOption> options) => RemoveOptions(options);
        /// <summary>
        /// Removes options from the poll based on object equality.
        /// </summary>
        /// <param name="options">The options to remove.</param>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.RemoveOptions(IEnumerable<PollOption> options) => RemoveOptions(options);

        /// <summary>
        /// Removes all options from the poll.
        /// </summary>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        public PollBuilder ClearOptions()
        {
            Options.Clear();
            return this;
        }

        /// <summary>
        /// Removes all options from the poll.
        /// </summary>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMultipleChoicePollBuilder IPollBuilderBase<IMultipleChoicePollBuilder>.ClearOptions() => ClearOptions();
        /// <summary>
        /// Removes all options from the poll.
        /// </summary>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IMeetingPollBuilder IPollBuilderBase<IMeetingPollBuilder>.ClearOptions() => ClearOptions();
        /// <summary>
        /// Removes all options from the poll.
        /// </summary>
        /// <returns>The current <see cref="PollBuilder"/> instance.</returns>
        IImagePollBuilder IPollBuilderBase<IImagePollBuilder>.ClearOptions() => ClearOptions();

        /// <summary>
        /// Builds a <see cref="Poll"/> object that represents the current state of the builder.
        /// </summary>
        /// <returns>The built <see cref="Poll"/>.</returns>
        public Poll Build()
        {
            return new Poll(_poll);
        }
    }
}