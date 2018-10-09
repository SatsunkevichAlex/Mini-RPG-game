using Engine.Enums;

namespace Engine
{
    public class Item
    {
        public ItemTypes ItemType { get; set; }
        public int Damage { get; set; }
        public int Price { get; set; }
        public int Health { get; set; }

        public Item()
        { }

        public Item(Item copy)
        {
            ItemType = copy.ItemType;
            Damage = copy.Damage;
            Price = copy.Price;
            Health = copy.Health;
        }
    }
}
