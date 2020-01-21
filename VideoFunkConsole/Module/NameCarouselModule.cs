using VideoFunkConsole.Interfaces;

namespace VideoFunkConsole.Module
{
    public interface INameCarouselModule : INameCarousel
    {
    }

    public class NameCarouselModule : INameCarouselModule
    {
        private readonly INameCarousel nameCarouselImplementation;

        public NameCarouselModule(INameCarousel nameCarousel)
        {
            nameCarouselImplementation = nameCarousel;
        }

        public void Init(ConfigSettings t)
        {
            nameCarouselImplementation.Init(t);
        }

        public void Generate()
        {
            nameCarouselImplementation.Generate();
        }
    }
}
