using System.Collections.Generic;

namespace VideoFunkConsole.Module;

public static class NameCarouselConstants
{
    public static class TitleClipValues
    {
        public const double Duration = 3.0;
        public const double gapBefore = 0;

        public const string Color = "color";
        public const string FontFamily = "fontFamily";
        public const string EffectTemplateID = "effectTemplateID";
        public const string FontStyle = "style";

        private static readonly Dictionary<string, string> colors = new()
        {
            {  "Yellow", "1;1;0" },
            {  "Green", "0;1;0" },
            {  "Red", "1;0;0" },
            {  "White", "1;1;1" }
        };

        public static Dictionary<string, string> Colors => colors;

        private  static readonly string[] effectTemplateIDs =
        [
            "TextEffectFadeTemplate",
            "TextEffectStretchTemplate",
            "TextEffectSwingDownTemplate",
            "TextEffectFadeZoomTemplate",
            "TextEffectScrollTemplate",
            "TextEffectFlyInTemplate",
            "TextEffectFlyInLeftTemplate",
            "TextEffectBigZoomTemplate",
            "TextEffectSpinOutTemplate",
            "TextEffectSpinInTemplate"
        ];
        public static string[] EffectTemplateIDs => effectTemplateIDs;

        private static readonly string[] fontFamilies =[
            "Segoe UI",
            "Consolas",
            "Lucida Console",
            "Arial Black",
            "Georgia",
            "Constantia",
            "Segoe Print",
            "Verdana",
            "SketchFlow Print",
            "Times New Roman",
            "Trebuchet MS",
            "Candara",
            "Buxton Sketch",
            "Cambria"
        ];

        public static string[] FontFamilies => fontFamilies;

        private static readonly string[] fontStyles = [

            "BoldItalic",
            "Italic",
            "Bold",
            "Plain"
        ];

        public static string[] FontStyles => fontStyles;
    }

    public static class Placeholders
    {
        public static class Wlmp
        {
            public const string Duration = "{wlmp.duration}";
            public const string TitleClips = "{wlmp.TitleClips}";
            public const string ExtentRefs = "{wlmp.ExtentRefs}";
        }

        public static class TitleClip
        {
            public const string extentID = "{TitleClip.extentID}";
            public const string gapBefore = "{TitleClip.gapBefore}";
            public const string duration = "{TitleClip.duration}";
            public const string textValue = "{TitleClip.textValue}";
            public const string effectTemplateID = "{TitleClip.effectTemplateID}";
            public const string Color = "{TitleClip.Color}";
            public const string fontFamily = "{TitleClip.family}";
            public const string fontSize = "{TitleClip.size}";
            public const string fontStyle = "{TitleClip.style}";
        }

        public static class TitleClipColor
        {
            public const string R = "{color.R}";
            public const string G = "{color.G}";
            public const string B = "{color.B}";
        }

        public static class ExtentRef
        {
            public const string Id = "{ExtentRef.id}";
        }
    }
}
