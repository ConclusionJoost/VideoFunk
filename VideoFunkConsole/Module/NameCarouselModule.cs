using VideoFunkConsole.Interfaces;

namespace VideoFunkConsole.Module
{
    public interface INameCarouselModule : INameCarousel
    {
    }

    public class NameCarouselModule(INameCarousel nameCarousel) : INameCarouselModule
    {
        private readonly INameCarousel nameCarouselImplementation = nameCarousel;

        public void Init(ConfigSettings config)
        {
            nameCarouselImplementation.Init(config);
        }

        public void Generate()
        {
            nameCarouselImplementation.Generate();
        }
    }
}
