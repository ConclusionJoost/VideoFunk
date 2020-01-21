using log4net;
using log4net.Config;
using System;
using System.IO;
using System.IO.Abstractions;
using System.Reflection;
using System.Text;
using VideoFunkConsole.Domain;
using VideoFunkConsole.Domain.MovieMaker;
using VideoFunkConsole.Interfaces;
using VideoFunkConsole.Module;

namespace VideoFunkConsole
{
    class Program
    {
        private static readonly ILog log = LogManager.GetLogger(MethodBase.GetCurrentMethod().DeclaringType);

        static void Main(string[] args)
        {
            var logRepository = LogManager.GetRepository(Assembly.GetEntryAssembly());
            XmlConfigurator.Configure(logRepository, new FileInfo("log4net.config"));

            log.Info("Start application");
            var message = new StringBuilder();

            message.AppendLine("");
            message.AppendLine("========================");
            message.AppendLine("VideoFunk Sync");
            message.AppendLine(Assembly.GetExecutingAssembly().GetName().Version.ToString());
            message.AppendLine("========================");

            log.Info(message);

            try
            {
                var startupArguments = StartupArguments.Parse(args);

                var fileSystem = new FileSystem();
                var names = fileSystem.File.ReadAllLines(".\\data\\names.txt");

                var settings = new ConfigSettings
                {
                    TemplatePath = ".\\Domain\\MovieMaker\\NameCarouselTemplates\\",
                    Names = names,
                    OutputFilePath = "d:\\temp\\myfilename.wlmp"
                };

                INameCarousel nameCarouselModule = new NameCarouselModule(new NameCarouselGenerator(fileSystem));
                nameCarouselModule.Init(settings);
                nameCarouselModule.Generate();
            }
            catch (Exception ex)
            {
                log.Error(ex);
                log.Info(StartupArguments.USAGE);
            }

            log.Info("Close application");
        }
    }
}
