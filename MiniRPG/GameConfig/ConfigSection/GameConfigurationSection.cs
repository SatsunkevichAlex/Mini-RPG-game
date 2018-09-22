using System.Configuration;

namespace GameConfig.ConfigSection
{
    public sealed class GameConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("initaialPlayerConfig")]
        public InitialPlayerElement InitialPlayer
        {
            get { return (InitialPlayerElement)this["initalPlayerConfig"]; }
            set { this["initalPlayerConfig"] = value; }
        }

        [ConfigurationProperty("battle")]
        public BattleElement Battle
        {
            get { return (BattleElement) this["battle"]; }
            set { this["battle"] = value; }
        }

        [ConfigurationProperty("shops")]
        public ShopsElement Shops
        {
            get { return (ShopsElement)this["shops"]; }
            set { this["shops"] = value; }
        }
    }
}
