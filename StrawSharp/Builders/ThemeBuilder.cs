using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using StrawSharp.Models.EnumValues;
using StrawSharp.Models.PollModels;

namespace StrawSharp.Builders
{
    public class ThemeBuilder
    {
        private PollTheme _theme = new PollTheme();

        public string Name
        {
            get => _theme.Name; 
            set => _theme.Name = value;
        }

        /// <summary>
        /// Known values in <see cref="Models.EnumValues.PageAppearance"/>
        /// </summary>
        public string PageAppearance
        {
            get => _theme.PageAppearance; 
            set => _theme.PageAppearance = value;
        }

        /// <summary>
        /// Known values in <see cref="Models.EnumValues.PageLayout"/>
        /// </summary>
        public string PageLayout
        {
            get => _theme.PageLayout;
            set => _theme.PageLayout = value;
        }

        public Color? TitleColor
        {
            get => _theme.TitleColor; 
            set => _theme.TitleColor = value;
        }
        
        public Color? TextColor 
        {
            get => _theme.TextColor; 
            set => _theme.TextColor = value;
        }

        public Color? BorderColor
        {
            get => _theme.BorderColor; 
            set => _theme.BorderColor = value;
        }

        public Color? BoxBackgroundColor
        {
            get => _theme.BoxBackgroundColor; 
            set => _theme.BoxBackgroundColor = value;
        }

        public Color? BoxBorderColor
        {
            get => _theme.BoxBorderColor; 
            set => _theme.BoxBorderColor = value;
        }

        public Color? BoxBorderTopColor
        {
            get => _theme.BoxBorderTopColor; 
            set => _theme.BoxBorderTopColor = value;
        }

        public Color? InputBackgroundColor
        {
            get => _theme.InputBackgroundColor; 
            set => _theme.InputBackgroundColor = value;
        }

        public Color? InputBorderColor
        {
            get => _theme.InputBorderColor; 
            set => _theme.InputBorderColor = value;
        }

        public Color? InputHighlightColor
        {
            get => _theme.InputHighlightColor; 
            set => _theme.InputHighlightColor = value;
        }

        public Color? InputTextColor
        {
            get => _theme.InputTextColor; 
            set => _theme.InputTextColor = value;
        }

        public Color? PageBackgroundColor
        {
            get => _theme.PageBackgroundColor; 
            set => _theme.PageBackgroundColor = value;
        }

        public Color? PrimaryButtonBackgroundColor
        {
            get => _theme.PrimaryButtonBackgroundColor; 
            set => _theme.PrimaryButtonBackgroundColor = value;
        }

        public Color? PrimaryButtonBorderColor
        {
            get => _theme.PrimaryButtonBorderColor; 
            set => _theme.PrimaryButtonBorderColor = value;
        }

        public Color? PrimaryButtonTextColor
        {
            get => _theme.PrimaryButtonTextColor; 
            set => _theme.PrimaryButtonTextColor = value;
        }

        public Color? SecondaryButtonBackgroundColor
        {
            get => _theme.SecondaryButtonBackgroundColor;
            set => _theme.SecondaryButtonBackgroundColor = value;
        }

        public Color? SecondaryButtonBorderColor
        {
            get => _theme.SecondaryButtonBorderColor; 
            set => _theme.SecondaryButtonBorderColor = value;
        }

        public Color? SecondaryButtonTextColor
        {
            get => _theme.SecondaryButtonTextColor; 
            set => _theme.SecondaryButtonTextColor = value;
        }
        
        public List<Color> OptionColors
        {
            get => _theme.OptionColors;
            set => _theme.OptionColors = value ?? new List<Color>();
        }

        public string BackToPollText
        {
            get => _theme.BackToPollText; 
            set => _theme.BackToPollText = value;
        }

        public string InstructionsText
        {
            get => _theme.InstructionsText; 
            set => _theme.InstructionsText = value;
        }

        public string LiveResultsText
        {
            get => _theme.LiveResultsText; 
            set => _theme.LiveResultsText = value;
        }

        public string ParticipantsText
        {
            get => _theme.ParticipantsText; 
            set => _theme.ParticipantsText = value;
        }

        public string RefreshResultsText
        {
            get => _theme.RefreshResultsText; 
            set => _theme.RefreshResultsText = value;
        }

        public string ResultsText
        {
            get => _theme.ResultsText; 
            set => _theme.ResultsText = value;
        }

        public string ShareText
        {
            get => _theme.ShareText; 
            set => _theme.ShareText = value;
        }

        public string TotalVotesText
        {
            get => _theme.TotalVotesText; 
            set => _theme.TotalVotesText = value;
        }

        public string UpdateVoteText
        {
            get  => _theme.UpdateVoteText; 
            set => _theme.UpdateVoteText = value;
        }

        public string VoteText
        {
            get => _theme.VoteText; 
            set => _theme.VoteText = value;
        }

        public string VotesText
        {
            get => _theme.VotesText; 
            set => _theme.VotesText = value;
        }

        public string InputFieldText
        {
            get => _theme.InputFieldText; 
            set => _theme.InputFieldText = value;
        }

        public string Font
        {
            get => _theme.Font; 
            set => _theme.Font = value;
        }

        public bool BoxShadow
        {
            get => _theme.BoxShadow; 
            set => _theme.BoxShadow = value;
        }

        public bool HideShareButton
        {
            get => _theme.HideShareButton; 
            set => _theme.HideShareButton = value;
        }

        public bool UseCustomText
        {
            get => _theme.UseCustomText; 
            set => _theme.UseCustomText = value;
        }

        public static ThemeBuilder From(PollTheme theme)
        {
            if (theme == null) throw new ArgumentNullException(nameof(theme));

            return new ThemeBuilder
            {
                _theme = new PollTheme(theme)
            };
        }

        public ThemeBuilder WithName(string name)
        {
            Name = name;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="appearance">Known values in <see cref="Models.EnumValues.PageAppearance"/></param>
        /// <returns></returns>
        public ThemeBuilder WithPageAppearance(string appearance)
        {
            PageAppearance = appearance;
            return this;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="layout">Known values in <see cref="Models.EnumValues.PageLayout"/></param>
        /// <returns></returns>
        public ThemeBuilder WithPageLayout(string layout)
        {
            PageLayout = layout;
            return this;
        }

        public ThemeBuilder WithTitleColor(Color? color)
        {
            TitleColor = color;
            return this;
        }
        
        public ThemeBuilder WithTextColor(Color? color)
        {
            TextColor = color;
            return this;
        }

        public ThemeBuilder WithBorderColor(Color? color)
        {
            BorderColor = color;
            return this;
        }

        public ThemeBuilder WithBoxBackgroundColor(Color? color)
        {
            BoxBackgroundColor = color;
            return this;
        }

        public ThemeBuilder WithBoxBorderColor(Color? color)
        {
            BoxBorderColor = color;
            return this;
        }

        public ThemeBuilder WithBoxBorderTopColor(Color? color)
        {
            BoxBorderTopColor = color;
            return this;
        }

        public ThemeBuilder WithInputBackgroundColor(Color? color)
        {
            InputBackgroundColor = color;
            return this;
        }

        public ThemeBuilder WithInputBorderColor(Color? color)
        {
            InputBorderColor = color;
            return this;
        }

        public ThemeBuilder WithInputHighlightColor(Color? color)
        {
            InputHighlightColor = color;
            return this;
        }

        public ThemeBuilder WithInputTextColor(Color? color)
        {
            InputTextColor = color;
            return this;
        }

        public ThemeBuilder WithPageBackgroundColor(Color? color)
        {
            PageBackgroundColor = color;
            return this;
        }

        public ThemeBuilder WithPrimaryButtonBackgroundColor(Color? color)
        {
            PrimaryButtonBackgroundColor = color;
            return this;
        }

        public ThemeBuilder WithPrimaryButtonBorderColor(Color? color)
        {
            PrimaryButtonBorderColor = color;
            return this;
        }

        public ThemeBuilder WithPrimaryButtonTextColor(Color? color)
        {
            PrimaryButtonTextColor = color;
            return this;
        }

        public ThemeBuilder WithSecondaryButtonBackgroundColor(Color? color)
        {
            SecondaryButtonBackgroundColor = color;
            return this;
        }

        public ThemeBuilder WithSecondaryButtonBorderColor(Color? color)
        {
            SecondaryButtonBorderColor = color;
            return this;
        }

        public ThemeBuilder WithSecondaryButtonTextColor(Color? color)
        {
            SecondaryButtonTextColor = color;
            return this;
        }

        public ThemeBuilder WithOptionColors(IEnumerable<Color> colors)
        {
            OptionColors = colors as List<Color> ?? colors.ToList();
            return this;
        }

        public ThemeBuilder WithOptionColors(params Color[] colors)
        {
            return WithOptionColors(colors.AsEnumerable());
        }

        public ThemeBuilder AddOptionColors(IEnumerable<Color> colors)
        {
            OptionColors.AddRange(colors);
            return this;
        }

        public ThemeBuilder AddOptionColors(params Color[] colors)
        {
            return AddOptionColors(colors.AsEnumerable());
        }

        public ThemeBuilder RemoveOptionColors(IEnumerable<Color> colors)
        {
            OptionColors.RemoveAll(colors.Contains);
            return this;
        }

        public ThemeBuilder RemoveOptionColors(params Color[] colors)
        {
            return RemoveOptionColors(colors.AsEnumerable());
        }

        public ThemeBuilder ClearOptionColors()
        {
            OptionColors.Clear();
            return this;
        }

        public ThemeBuilder WithBackToPollText(string text)
        {
            BackToPollText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithInstructionsText(string text)
        {
            InstructionsText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithLiveResultsText(string text)
        {
            LiveResultsText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithParticipantsText(string text)
        {
            ParticipantsText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithRefreshResultsText(string text)
        {
            RefreshResultsText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithResultsText(string text)
        {
            ResultsText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithShareText(string text)
        {
            ShareText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithTotalVotesText(string text)
        {
            TotalVotesText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithUpdateVoteText(string text)
        {
            UpdateVoteText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithVoteText(string text)
        {
            VoteText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithVotesText(string text)
        {
            VotesText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithInputFieldText(string text)
        {
            InputFieldText = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithFont(string text)
        {
            Font = text;
            UseCustomText = true;
            return this;
        }

        public ThemeBuilder WithBoxShadow(bool enable = true)
        {
            BoxShadow = enable;
            return this;
        }

        public ThemeBuilder WithoutBoxShadow()
        {
            BoxShadow = false;
            return this;
        }

        public ThemeBuilder WithShareButton(bool enabled = true)
        {
            HideShareButton = !enabled;
            return this;
        }

        public ThemeBuilder WithoutShareButton()
        {
            HideShareButton = true;
            return this;
        }

        public ThemeBuilder WithCustomText(bool enabled = true)
        {
            UseCustomText = enabled;
            return this;
        }

        public ThemeBuilder WithoutCustomText()
        {
            UseCustomText = false;
            return this;
        }


        public PollTheme Build()
        {
            return new PollTheme(_theme);
        }
    }
}