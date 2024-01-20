using System;
using System.Collections.Generic;

namespace StrawSharp.Builders.Interfaces
{
    public interface IMeetingPollBuilder : IPollBuilderBase<IMeetingPollBuilder>
    {
        IMeetingPollBuilder AllowIndeterminate(bool allow = true);
        IMeetingPollBuilder WithDateOptions(IEnumerable<DateTime> options);
        IMeetingPollBuilder WithDateOptions(params DateTime[] options);
        IMeetingPollBuilder AddDateOptions(IEnumerable<DateTime> dates);
        IMeetingPollBuilder AddDateOptions(params DateTime[] dates);
        IMeetingPollBuilder AddTimeRangeOption(DateTime startTime, DateTime endTime);
    }
}
