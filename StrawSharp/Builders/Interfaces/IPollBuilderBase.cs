using System;
using System.Collections.Generic;
using System.Drawing;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders.Interfaces
{
    public interface IPollBuilderBase
    {
        Poll Build();
    }
}
