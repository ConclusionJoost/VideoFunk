using System;
using System.Collections.Generic;
using System.Text;

namespace VideoFunkConsole.Module
{
    public class NameCarouselConstants
    {
        public class TitleClipValues
        {
            public const double Duration = 3.0;
            public const double gapBefore = 0;

            public const string Color = "color";
            public const string FontFamily = "fontFamily";
            public const string EffectTemplateID = "effectTemplateID";
            public const string FontStyle = "style";

            public static Dictionary<string, string> Colors = new Dictionary<string, string>
            {
                {  "Yellow", "1;1;0" },
                {  "Green", "0;1;0" },
                {  "Red", "1;0;0" },
                {  "White", "1;1;1" }
            };

            public static string[] EffectTemplateIDs = new string[]
            {
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
            };

            public static string[] FontFamilies = new string[]
            {
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
            };

            public static string[] FontStyles = new string[]
            {
                "BoldItalic",
                "Italic",
                "Bold",
                "Plain"
            };
        }

        public class Placeholders
        {
            public class wlmp
            {
                public const string Duration = "{wlmp.duration}";
                public const string TitleClips = "{wlmp.TitleClips}";
                public const string ExtentRefs = "{wlmp.ExtentRefs}";
            }

            public class TitleClip
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

            public class TitleClipColor
            {
                public const string R = "{color.R}";
                public const string G = "{color.G}";
                public const string B = "{color.B}";
            }

            public class ExtentRef
            {
                public const string Id = "{ExtentRef.id}";
            }
        }
    }
}
