using System.Configuration;

namespace GameConfig.ConfigSection
{
    public sealed class GameConfigurationSection : ConfigurationSection
    {
        [ConfigurationProperty("initialPlayerConfig")]
        public InitialPlayerElement InitialPlayer
        {
            get { return (InitialPlayerElement)this["initialPlayerConfig"]; }
            set { this["initialPlayerConfig"] = value; }
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
