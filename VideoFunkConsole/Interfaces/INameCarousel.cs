using TrafficJam.Lib.Interfaces;
using VideoFunkConsole.Module;

namespace VideoFunkConsole.Interfaces
{
    public interface INameCarousel : IInit<ConfigSettings>
    {
        void Generate();
    }
}
