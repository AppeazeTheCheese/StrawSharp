using System;
using System.Collections.Generic;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders.Interfaces
{
    public interface IMeetingPollBuilder : IPollBuilderBase
    {
        // Shared methods
        IMeetingPollBuilder WithTitle(string title);
        IMeetingPollBuilder WithDescription(string description);
        IMeetingPollBuilder WithMediaId(string mediaId);
        IMeetingPollBuilder WithThemeId(string themeId);
        IMeetingPollBuilder AllowComments(bool allow = true);
        IMeetingPollBuilder AllowVpn(bool allow = true);
        IMeetingPollBuilder WithDeadline(DateTime? deadline);
        IMeetingPollBuilder WithDuplicationChecking(string checkType);
        IMeetingPollBuilder WithEditVotePermissions(string permission);
        IMeetingPollBuilder HideParticipants(bool hide = true);
        IMeetingPollBuilder WithResultVisibility(string visibility);
        IMeetingPollBuilder RemoveOptions(IEnumerable<PollOption> options);
        IMeetingPollBuilder RemoveOptions(params PollOption[] options);
        IMeetingPollBuilder ClearOptions();
        
        // Meeting poll specific methods
        IMeetingPollBuilder AllowIndeterminate(bool allow = true);
        IMeetingPollBuilder WithDateOptions(IEnumerable<DateTime> options);
        IMeetingPollBuilder WithDateOptions(params DateTime[] options);
        IMeetingPollBuilder AddDateOptions(IEnumerable<DateTime> dates);
        IMeetingPollBuilder AddDateOptions(params DateTime[] dates);
        IMeetingPollBuilder AddTimeRangeOption(DateTime startTime, DateTime endTime);
    }
}
