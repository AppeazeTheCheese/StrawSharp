using System;
using System.Collections.Generic;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders.Interfaces
{
    public interface IImagePollBuilder : IPollBuilderBase
    {
        // Shared methods
        IImagePollBuilder WithTitle(string title);
        IImagePollBuilder WithDescription(string description);
        IImagePollBuilder WithMediaId(string mediaId);
        IImagePollBuilder WithThemeId(string themeId);
        IImagePollBuilder AllowComments(bool allow = true);
        IImagePollBuilder AllowVpn(bool allow = true);
        IImagePollBuilder WithDeadline(DateTime? deadline);
        IImagePollBuilder WithDuplicationChecking(string checkType);
        IImagePollBuilder WithEditVotePermissions(string permission);
        IImagePollBuilder HideParticipants(bool hide = true);
        IImagePollBuilder WithResultVisibility(string visibility);
        IImagePollBuilder RemoveOptions(IEnumerable<PollOption> options);
        IImagePollBuilder RemoveOptions(params PollOption[] options);
        IImagePollBuilder ClearOptions();

        // Image poll specific methods
        IImagePollBuilder RequireNames(bool require = true);
        IImagePollBuilder AddImageOption(string mediaId, string caption);
        IImagePollBuilder WithLayout(string layout);
    }
}
