using Engine.Actions.Base;
using Engine.Enums;
using GameConfig.ConfigSection;

namespace Engine.Actions
{
    public class HealActionResult : ActionResultBase
    {
        public int HealAction { get; set; }
    }

    public sealed class HealAction : ShopActionBase, IAction
    {
        public ActionResultBase Process(GameState state, GameConfiguration config)
        {
            HealActionResult result = new HealActionResult();
            if (!CanApply(state, config))
            {
                result.IsSeccessful = false;
                return result;
            }

            state.CurrentPlayer.DecreaseCoins(config.Shops.Heal.Price);
            result.HealAction = state.CurrentPlayer.ApplyHeal(GetItemEffect(config.Shops.Heal));
            return result;
        }

        public bool CanApply(GameState state, GameConfiguration config)
        {
            if (state.CurrentPlayer.Coins < config.Shops.Heal.Price)
                return false;

            return true;
        } 

        public ActionTypes Type
        {
            get { return ActionTypes.Heal; }
        }
    }
}
