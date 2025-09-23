using VideoFunkConsole.Module;

namespace VideoFunkConsole.Interfaces;

public interface INameCarousel
{
    void Init(ConfigSettings config);
    void Generate();
}
