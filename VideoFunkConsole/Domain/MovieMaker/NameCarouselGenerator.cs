using System;
using System.Collections.Generic;
using System.IO.Abstractions;
using System.Linq;
using System.Text;
using System.Xml;
using VideoFunkConsole.Interfaces;
using VideoFunkConsole.Module;
using static VideoFunkConsole.Module.NameCarouselConstants;

namespace VideoFunkConsole.Domain.MovieMaker
{
    public interface INameCarouselGenerator : INameCarousel
    {
    }

    public class NameCarouselGenerator : INameCarouselGenerator
    {
        private ConfigSettings settings;
        private readonly IFileSystem fileSystem;
        private string wlmpXmlTemplate;
        private string ExtentRefXmlTemplate;
        private string titleClipXmlTemplate;
        private string titleClipColorXmlTemplate;
        private string titleClipStringValueXmlTemplate;
        private readonly Dictionary<string, int> currectValues;

        public NameCarouselGenerator(IFileSystem fileSystem)
        {
            this.fileSystem = fileSystem;
            currectValues = new Dictionary<string, int>
            {
                { TitleClipValues.Color, -1 },
                { TitleClipValues.FontFamily, -1 },
                { TitleClipValues.EffectTemplateID, -1 },
                { TitleClipValues.FontStyle, -1 }
            };
        }

        public void Init(ConfigSettings settings)
        {
            this.settings = settings;
            wlmpXmlTemplate = fileSystem.File.ReadAllText($"{settings.TemplatePath}wlmp.xml");
            titleClipXmlTemplate = fileSystem.File.ReadAllText($"{settings.TemplatePath}TitleClip.xml");
            titleClipColorXmlTemplate = fileSystem.File.ReadAllText($"{settings.TemplatePath}TitleClipColor.xml");
            titleClipStringValueXmlTemplate = fileSystem.File.ReadAllText($"{settings.TemplatePath}TitleClipStringValue.xml");
            ExtentRefXmlTemplate = fileSystem.File.ReadAllText($"{settings.TemplatePath}ExtentRef.xml");
        }

        public void Generate()
        {
            double wmplDuration = 0;
            var titleClips = new StringBuilder();
            var extentRef = new StringBuilder();

            var extentId = 6;

            foreach (var name in settings.Names)
            {
                Console.WriteLine($"Name : '{name}'");
                var titleClipXml = titleClipXmlTemplate
                    .Replace(Placeholders.TitleClip.extentID, extentId.ToString())
                    .Replace(Placeholders.TitleClip.gapBefore, TitleClipValues.gapBefore.ToString())
                    .Replace(Placeholders.TitleClip.duration, TitleClipValues.Duration.ToString())
                    .Replace(Placeholders.TitleClip.textValue, GetText(name))
                    .Replace(Placeholders.TitleClip.fontSize, GetFontSize(name))
                    .Replace(Placeholders.TitleClip.fontFamily, GetRandom(TitleClipValues.FontFamilies, TitleClipValues.FontFamily))
                    .Replace(Placeholders.TitleClip.fontStyle, GetRandom(TitleClipValues.FontStyles, TitleClipValues.FontStyle))
                    .Replace(Placeholders.TitleClip.effectTemplateID, GetRandom(TitleClipValues.EffectTemplateIDs, TitleClipValues.EffectTemplateID))
                    .Replace(Placeholders.TitleClip.Color, GetRandomColor());


                titleClips.AppendLine(titleClipXml);

                var extentRefXml = ExtentRefXmlTemplate
                    .Replace(Placeholders.TitleClip.extentID, extentId.ToString());

                extentRef.AppendLine(extentRefXml);

                extentId++;
                wmplDuration += TitleClipValues.gapBefore + TitleClipValues.Duration;
            }


            var wlmpTxt = wlmpXmlTemplate
                .Replace(Placeholders.wlmp.Duration, wmplDuration.ToString())
                .Replace(Placeholders.wlmp.TitleClips, titleClips.ToString())
                .Replace(Placeholders.wlmp.ExtentRefs, extentRef.ToString());


            if (fileSystem.File.Exists(settings.OutputFilePath))
            {
                fileSystem.File.Delete(settings.OutputFilePath);
            }

            XmlDocument xdoc = new XmlDocument();
            xdoc.LoadXml(wlmpTxt);
            xdoc.Save(settings.OutputFilePath);
        }

        private string GetText(string name)
        {
            var names = name.Split(' ');
            var returnvalue = titleClipStringValueXmlTemplate
                    .Replace(Placeholders.TitleClip.textValue, names[0]);

            if (names.Length == 2)
            {
                returnvalue +=
                    titleClipStringValueXmlTemplate
                    .Replace(Placeholders.TitleClip.textValue, names[1]);
            }
            else
            {
                var restArray = string.Join(' ', names.Skip(1));
                returnvalue +=
                         titleClipStringValueXmlTemplate
                         .Replace(Placeholders.TitleClip.textValue, restArray);
            }

            //Console.WriteLine(returnvalue);
            return returnvalue;
        }

        private string GetFontSize(string name)
        {
            if (name.Length > 20) { return "0.8"; }
            if (name.Length > 1) { return "1"; }
            return "1.2";
        }

        private string GetRandomColor()
        {
            var selectedIndex = currectValues[TitleClipValues.Color];

            while (currectValues[TitleClipValues.Color] == selectedIndex)
            {
                selectedIndex = Rnd(TitleClipValues.Colors.Count);
            }

            var color = TitleClipValues.Colors.ElementAt(selectedIndex).Value.Split(';');

            currectValues[TitleClipValues.Color] = selectedIndex;

            return titleClipColorXmlTemplate
                .Replace(Placeholders.TitleClipColor.R, color[0])
                .Replace(Placeholders.TitleClipColor.G, color[1])
                .Replace(Placeholders.TitleClipColor.B, color[2]);

        }

        private string GetRandom(string[] collection, string valueName)
        {
            var selectedIndex = currectValues[valueName];

            while (currectValues[valueName] == selectedIndex)
            {
                selectedIndex = Rnd(collection.Length);
            }
            currectValues[valueName] = selectedIndex;

            return collection[selectedIndex];
        }

        private int Rnd(int max)
        {
            //Random ramdom = new Random(DateTime.Now.Millisecond);
            Random ramdom = new Random(Guid.NewGuid().GetHashCode());

            return ramdom.Next(0, max);
        }
    }
}
