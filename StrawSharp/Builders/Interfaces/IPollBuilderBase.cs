using System;
using System.Collections.Generic;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders.Interfaces
{
    public interface IPollBuilderBase<T> where T : IPollBuilderBase<T>
    {
        T WithTitle(string title);
        T WithDescription(string description);
        T WithMediaId(string mediaId);
        T WithThemeId(string themeId);
        T WithWorkspaceId(string workspaceId);
        T AllowComments(bool allow = true);
        T AllowVpn(bool allow = true);
        T WithDeadline(DateTime? deadline);
        T WithDuplicationChecking(string checkType);
        T WithEditVotePermissions(string permission);
        T HideParticipants(bool hide = true);
        T WithResultVisibility(string visibility);
        T RemoveOptions(IEnumerable<PollOption> options);
        T RemoveOptions(params PollOption[] options);
        T ClearOptions();
        Poll Build();
    }
}
