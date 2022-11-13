using System;
using System.Collections.Generic;
using StrawSharp.Models.EnumValues;
using StrawSharp.Models.PollModels;
using StrawSharp.Models.PollModels.Options;

namespace StrawSharp.Builders
{
    public abstract class PollBuilderBase
    {
        private string _internalType;
        private string _internalTitle;
        private PollMedia _internalMedia = new PollMedia();
        private PollConfig _internalConfig = new PollConfig();
        private PollMeta _internalMeta = new PollMeta();
        private List<PollOption> _internalOptions = new List<PollOption>();

        protected virtual string InternalTitle
        {
            get => _internalTitle;
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("You must provide a title", nameof(InternalTitle));
                _internalTitle = value;
            }
        }
        
        /// <summary>
        /// The type of the poll. Known possible values are in <see cref="PollType"/>
        /// </summary>
        protected virtual string InternalType
        {
            get => _internalType;
            set => _internalType = value ?? PollType.MultipleChoice;
        }
        
        protected virtual PollMedia InternalMedia
        {
            get => _internalMedia;
            set => _internalMedia = value ?? new PollMedia();
        }
        
        protected virtual PollConfig InternalConfig
        {
            get => _internalConfig;
            set => _internalConfig = value ?? new PollConfig();
        }
        
        protected virtual PollMeta InternalMeta
        {
            get => _internalMeta;
            set => _internalMeta = value ?? new PollMeta();
        }
        
        protected virtual List<PollOption> InternalOptions
        {
            get => _internalOptions;
            set => _internalOptions = value ?? new List<PollOption>();
        }
    }
}