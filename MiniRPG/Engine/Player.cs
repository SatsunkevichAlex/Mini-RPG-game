using Engine.Exceptions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace Engine
{
    public class Player
    {
        public int Health { private set; get; }
        public int MaxHealth { private set; get; }
        public int Power { private set; get; }
        public int Coins { private set; get; }


        private List<Item> _items;

        public Player()
        {
            _items = new List<Item>();
        }

        public IReadOnlyCollection<Item> Items
        {
            get { return new ReadOnlyCollection<Item>(_items); }
        }

        public void Clear() => _items = new List<Item>();

        public void Initialize(int health, int maxHealth, int power, int coins)
        {
            if (MaxHealth != 0)
                throw new PlayerDataException("Player already initialized");

            if (health > maxHealth)
                throw new ArgumentOutOfRangeException("health", "Health can not be greater than MaxHealth");

            if (coins < 0)
                throw new ArgumentOutOfRangeException("Coins", "Conis can not bet less than 0");

            if (power < 0)
                throw new ArgumentOutOfRangeException("Power", "Powe can not be less than 0");

            Health = health;
            MaxHealth = maxHealth;
            Power = power;
            Coins = coins;
        }

        public Player DeepCopy()
        {
            Player player = (Player)MemberwiseClone();
            player.Clear();

            foreach (Item item in Items)
            {
                player.ApplyItem(new Item(item));
            }

            return player;
        }

        public void ApplyDamage(int damage)
        {
            Health -= damage;

            if (Health < 0)
                Health = 0;
        }

        public int ApplyHeal(int heal)
        {
            Health += heal;

            if (Health > MaxHealth)
            {
                heal = Health - MaxHealth;
                Health = MaxHealth;
            }

            return heal;
        }

        public void AddCoins(int coins)
        {
            Coins += coins;
        }

        public void DecreaseCoins(int coins)
        {
            if (Coins < coins)
                throw new PlayerDataException("Can not decrease!");

            Coins -= coins;
        }

        public void ApplyItem(Item item)
        {
            MaxHealth += item.Health;
            Power += item.Damage;

            _items.Add(item);
        }
    }
}
