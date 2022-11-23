using System;
using System.Collections.Generic;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders.Interfaces
{
    public interface IImagePollBuilder : IPollBuilderBase<IImagePollBuilder>
    {
        IImagePollBuilder RequireNames(bool require = true);
        IImagePollBuilder AddImageOption(string mediaId, string caption);
        IImagePollBuilder WithLayout(string layout);
    }
}
