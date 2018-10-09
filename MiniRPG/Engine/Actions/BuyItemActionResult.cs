using Engine.Actions.Base;
using Engine.Enums;
using GameConfig.ConfigSection;
using GameConfig.Models;
using System;

namespace Engine.Actions
{
    public sealed class BuyItemActionResult : ActionResultBase
    {
        public int EffectResult { get; set; }
    }

    internal sealed class BuyItemAction : ShopActionBase, IAction
    {
        private readonly ItemTypes _type;

        public BuyItemAction(ItemTypes type)
        {
            _type = type;
        }

        public ActionResultBase Process(GameState state, GameConfiguration config)
        {
            BuyItemActionResult result = new BuyItemActionResult();

            if (!CanApply(state, config))
            {
                result.IsSeccessful = false;
                return result;
            }

            ShopConfiguration shop = GetShop(config);

            Item newItem = new Item();
            newItem.ItemType = _type;
            newItem.Price = shop.Price;

            result.EffectResult = GetItemEffect(shop);

            switch (_type)
            {
                case ItemTypes.Armor:
                    newItem.Health = result.EffectResult;
                    break;
                case ItemTypes.Weapon:
                    newItem.Damage = result.EffectResult;
                    break;
            }

            state.CurrentPlayer.ApplyItem(newItem);
            state.CurrentPlayer.DecreaseCoins(shop.Price);

            return result;
        }

        public bool CanApply(GameState state, GameConfiguration config)
        {
            ShopConfiguration shop = GetShop(config);
            if (state.CurrentPlayer.Coins < shop.Price)
                return false;

            return true;
        }

        public ActionTypes Type
        {
            get
            {
                switch (_type)
                {
                    case ItemTypes.Armor:
                        return ActionTypes.BuyArmor;
                    case ItemTypes.Weapon:
                    default:
                        return ActionTypes.BuyWeapon;
                }
            }
        }

        /// <summary>
        /// Return shop info by ItemType
        /// </summary>
        private ShopConfiguration GetShop(GameConfiguration config)
        {
            ShopConfiguration shop = null;
            switch (_type)
            {
                case ItemTypes.Armor:
                    shop = config.Shops.Armor;
                    break;
                case ItemTypes.Weapon:
                    shop = config.Shops.Weapon;
                    break;
            }

            if (shop == null)
                throw new ArgumentOutOfRangeException("itenType", "Item should be weapon or armor");

            return shop;
        }
    }
}
