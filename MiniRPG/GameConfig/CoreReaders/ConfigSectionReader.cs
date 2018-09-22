using GameConfig.ConfigSection;
using System.Configuration;

namespace GameConfig.CoreReaders
{
    public sealed class ConfigSectionReader : IGameConfigReader
    {
        public GameConfiguration ReadConfig()
        {
            GameConfigurationSection config = (GameConfigurationSection)ConfigurationManager.GetSection("gameConfig");

            GameConfiguration gameConfig = config.Map(); ;
            return gameConfig;
        }
    }
}
