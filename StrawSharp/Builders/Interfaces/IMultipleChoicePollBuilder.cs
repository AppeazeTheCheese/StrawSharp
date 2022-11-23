using System;
using System.Collections.Generic;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders.Interfaces
{
    public interface IMultipleChoicePollBuilder : IPollBuilderBase<IMultipleChoicePollBuilder>
    {
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
