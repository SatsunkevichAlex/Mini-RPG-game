using Engine.Utils;
using GameConfig.Models;

namespace Engine.Actions.Base
{
    internal abstract class ShopActionBase
    {
        protected int GetItemEffect(ShopConfiguration shop)
        {
            int delta = shop.EffectTo - shop.EffectFrom;
            if (delta == 0)
                return shop.EffectTo;

            return shop.EffectFrom + Generator.Next(0, delta);
        }
    }
}
