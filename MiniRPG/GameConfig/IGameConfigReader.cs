
using GameConfig.ConfigSection;

namespace GameConfig
{
    interface IGameConfigReader
    {
        GameConfiguration ReadConfig();
    }
}
