using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using StrawSharp.Models.PollModels;

namespace StrawSharp.Builders
{
    public class ThemeBuilder
    {
        private PollTheme _theme = new PollTheme();

        /// <summary>
        /// The name of the theme.
        /// </summary>
        public string Name
        {
            get => _theme.Name; 
            set => _theme.Name = value;
        }

        /// <summary>
        /// The appearance of the page. Known values in <see cref="Models.EnumValues.PageAppearance"/>
        /// </summary>
        public string PageAppearance
        {
            get => _theme.PageAppearance; 
            set => _theme.PageAppearance = value;
        }

        /// <summary>
        /// The layout of the page. Known values in <see cref="Models.EnumValues.PageLayout"/>
        /// </summary>
        public string PageLayout
        {
            get => _theme.PageLayout;
            set => _theme.PageLayout = value;
        }

        /// <summary>
        /// The color of the poll's title text.
        /// </summary>
        public Color? TitleColor
        {
            get => _theme.Colors.TitleColor; 
            set => _theme.Colors.TitleColor = value;
        }
        
        /// <summary>
        /// The color of the poll's text.
        /// </summary>
        public Color? TextColor 
        {
            get => _theme.Colors.TextColor; 
            set => _theme.Colors.TextColor = value;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public Color? BorderColor
        {
            get => _theme.Colors.BorderColor; 
            set => _theme.Colors.BorderColor = value;
        }

        /// <summary>
        /// The background color of the box containing the poll.
        /// </summary>
        public Color? BoxBackgroundColor
        {
            get => _theme.Colors.BoxBackgroundColor; 
            set => _theme.Colors.BoxBackgroundColor = value;
        }

        /// <summary>
        /// The border color of the box containing the poll.
        /// </summary>
        public Color? BoxBorderColor
        {
            get => _theme.Colors.BoxBorderColor; 
            set => _theme.Colors.BoxBorderColor = value;
        }

        /// <summary>
        /// The top border color of the box containing the poll.
        /// </summary>
        public Color? BoxBorderTopColor
        {
            get => _theme.Colors.BoxBorderTopColor; 
            set => _theme.Colors.BoxBorderTopColor = value;
        }

        /// <summary>
        /// The background color of the page.
        /// </summary>
        public Color? PageBackgroundColor
        {
            get => _theme.Colors.PageBackgroundColor; 
            set => _theme.Colors.PageBackgroundColor = value;
        }

        /// <summary>
        /// The background color of the buttons.
        /// </summary>
        public Color? ButtonBackgroundColor
        {
            get => _theme.Colors.ButtonBackgroundColor; 
            set => _theme.Colors.ButtonBackgroundColor = value;
        }

        /// <summary>
        /// The border color of the buttons.
        /// </summary>
        public Color? ButtonBorderColor
        {
            get => _theme.Colors.ButtonBorderColor; 
            set => _theme.Colors.ButtonBorderColor = value;
        }

        /// <summary>
        /// The text color of the buttons.
        /// </summary>
        public Color? ButtonTextColor
        {
            get => _theme.Colors.ButtonTextColor; 
            set => _theme.Colors.ButtonTextColor = value;
        }

        /// <summary>
        /// The color of the poll options. The index of these colors is mapped directly to the list containing the poll's options.
        /// If there are more options in the poll than colors in this list, the colors will be repeated as many times as needed to cover every poll option.
        /// </summary>
        public List<Color> OptionColors
        {
            get => _theme.OptionColors;
            set => _theme.OptionColors = value ?? new List<Color>();
        }

        /// <summary>
        /// Custom text for the "Back to poll" button.
        /// </summary>
        public string BackToPollText
        {
            get => _theme.BackToPollText; 
            set => _theme.BackToPollText = value;
        }

        /// <summary>
        /// TODO
        /// Custom text to replace "Make a choice" above the poll options.
        /// </summary>
        public string InstructionsText
        {
            get => _theme.InstructionsText; 
            set => _theme.InstructionsText = value;
        }

        /// <summary>
        /// Custom text for the "Live results" button.
        /// </summary>
        public string LiveResultsText
        {
            get => _theme.LiveResultsText; 
            set => _theme.LiveResultsText = value;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string ParticipantsText
        {
            get => _theme.ParticipantsText; 
            set => _theme.ParticipantsText = value;
        }

        /// <summary>
        /// Custom text for the "Refresh results" button.
        /// </summary>
        public string RefreshResultsText
        {
            get => _theme.RefreshResultsText; 
            set => _theme.RefreshResultsText = value;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string ResultsText
        {
            get => _theme.ResultsText; 
            set => _theme.ResultsText = value;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string ShareText
        {
            get => _theme.ShareText; 
            set => _theme.ShareText = value;
        }

        /// <summary>
        /// Custom text to replace "Total votes" at the bottom of the poll's results screen.
        /// </summary>
        public string TotalVotesText
        {
            get => _theme.TotalVotesText; 
            set => _theme.TotalVotesText = value;
        }

        /// <summary>
        /// Custom text for the "Update vote" button.
        /// </summary>
        public string UpdateVoteText
        {
            get  => _theme.UpdateVoteText; 
            set => _theme.UpdateVoteText = value;
        }

        /// <summary>
        /// Custom text for the "Vote" button.
        /// </summary>
        public string VoteText
        {
            get => _theme.VoteText; 
            set => _theme.VoteText = value;
        }

        /// <summary>
        /// TODO
        /// </summary>
        public string VotesText
        {
            get => _theme.VotesText; 
            set => _theme.VotesText = value;
        }

        /// <summary>
        /// TODO
        /// </summary>
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

        public ThemeBuilder WithPageBackgroundColor(Color? color)
        {
            PageBackgroundColor = color;
            return this;
        }

        public ThemeBuilder WithButtonBackgroundColor(Color? color)
        {
            ButtonBackgroundColor = color;
            return this;
        }

        public ThemeBuilder WithButtonBorderColor(Color? color)
        {
            ButtonBorderColor = color;
            return this;
        }

        public ThemeBuilder WithButtonTextColor(Color? color)
        {
            ButtonTextColor = color;
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

        public ThemeBuilder WithShareButton(bool enabled = true)
        {
            HideShareButton = !enabled;
            return this;
        }

        public ThemeBuilder WithCustomText(bool enabled = true)
        {
            UseCustomText = enabled;
            return this;
        }

        public PollTheme Build()
        {
            return new PollTheme(_theme);
        }
    }
}