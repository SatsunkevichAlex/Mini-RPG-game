using System.Configuration;

namespace GameConfig.ConfigSection
{
    public class InitialPlayerElement : ConfigurationElement
    {
        [ConfigurationProperty("initialPlayerHealth", DefaultValue = "100", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 1)]
        public int InitialPlayerHealth
        {
            get { return (int)this["initialPlayerHealth"]; }
            set { this["initialPlayerHealth"] = value; }
        }

        [ConfigurationProperty("initialPlayerMaxHealth", DefaultValue = "100", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 1)]
        public int InitialPlayerMaxHealth
        {
            get { return (int)this["initialPlayerMaxHealth"]; }
            set { this["initialPlayerMaxHealth"] = value; }
        }

        [ConfigurationProperty("initialPlayerPower", DefaultValue = "1", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int InitialPlayerPower
        {
            get { return (int)this["initialPlayerPower"]; }
            set { this["initialPlayerPower"] = value; }
        }

        [ConfigurationProperty("initialPlayerCoins", DefaultValue = "2", IsRequired = true)]
        [IntegerValidator(ExcludeRange = false, MinValue = 0)]
        public int InitialPlayerCoins
        {
            get { return (int)this["initialPlayerCoins"]; }
            set { this["initialPlayerCoins"] = value; }
        }
    }
}
