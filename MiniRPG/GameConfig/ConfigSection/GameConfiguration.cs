using GameConfig.Models;

namespace GameConfig.ConfigSection
{
    public sealed class GameConfiguration
    {
        public GameConfiguration()
        {
            InitialPlayer = new InitialPlayerConfiguration();
            Battle = new BattleConfiguration();
            Shops = new ShopsConfiguration();
        }

        public InitialPlayerConfiguration InitialPlayer { get; set; }
        public BattleConfiguration Battle { get; set; }
        public ShopsConfiguration Shops { get; set; }
    }
}
