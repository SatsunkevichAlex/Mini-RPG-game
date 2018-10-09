using GameConfig.ConfigSection;

namespace GameConfig
{
    public interface IGameConfigReader
    {
        GameConfiguration ReadConfig();
    }
}
