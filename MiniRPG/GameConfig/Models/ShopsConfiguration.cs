namespace GameConfig.Models
{
    public class ShopsConfiguration
    {
        public ShopsConfiguration()
        {
            Armor = new ShopConfiguration();
            Weapon = new ShopConfiguration();
            Heal = new ShopConfiguration();
        }

        public ShopConfiguration Armor { get; set; }
        public ShopConfiguration Weapon { get; set; }
        public ShopConfiguration Heal { get; set; }
    }

    public sealed class ShopConfiguration
    {
        public int Price { get; set; }
        public int EffectFrom { get; set; }
        public int EffectTo { get; set; }
    }
}
