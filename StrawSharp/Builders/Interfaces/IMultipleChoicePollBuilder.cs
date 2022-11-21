using System;
using System.Collections.Generic;
using System.Drawing;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders.Interfaces
{
    public interface IMultipleChoicePollBuilder : IPollBuilderBase
    {
        // Shared methods
        IMultipleChoicePollBuilder WithTitle(string title);
        IMultipleChoicePollBuilder WithDescription(string description);
        IMultipleChoicePollBuilder WithMediaId(string mediaId);
        IMultipleChoicePollBuilder WithThemeId(string themeId);
        IMultipleChoicePollBuilder AllowComments(bool allow = true);
        IMultipleChoicePollBuilder AllowVpn(bool allow = true);
        IMultipleChoicePollBuilder WithDeadline(DateTime? deadline);
        IMultipleChoicePollBuilder WithDuplicationChecking(string checkType);
        IMultipleChoicePollBuilder WithEditVotePermissions(string permission);
        IMultipleChoicePollBuilder HideParticipants(bool hide = true);
        IMultipleChoicePollBuilder WithResultVisibility(string visibility);
        IMultipleChoicePollBuilder RemoveOptions(IEnumerable<PollOption> options);
        IMultipleChoicePollBuilder RemoveOptions(params PollOption[] options);
        IMultipleChoicePollBuilder ClearOptions();
        
        // Image poll specific methods
        IMultipleChoicePollBuilder AllowOtherOption(bool allow = true);
        IMultipleChoicePollBuilder MultipleChoice(bool multipleChoice = true);
        IMultipleChoicePollBuilder WithMinChoices(int? minChoices = null);
        IMultipleChoicePollBuilder WithMaxChoices(int? maxChoices = null);
        IMultipleChoicePollBuilder RequireNames(bool require = true);
        IMultipleChoicePollBuilder WithTextOptions(IEnumerable<string> options);
        IMultipleChoicePollBuilder WithTextOptions(params string[] options);
        IMultipleChoicePollBuilder AddTextOptions(IEnumerable<string> options);
        IMultipleChoicePollBuilder AddTextOptions(params string[] options);
    }
}
