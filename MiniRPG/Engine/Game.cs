using GameConfig.ConfigSection;
using GameConfig;
using System;
using Engine.Enums;
using Engine.Actions;
using Engine.Actions.Base;
using MiniRPG;

namespace Engine
{
    public class Game
    {
        public GameConfiguration Config { get; private set; }
        public GameState GameState { get; private set; }

        public Game(IGameConfigReader configReader)
        {
            if (configReader == null)
                throw new ArgumentNullException("configReader is null");

            Config = configReader.ReadConfig();
            GameState = new GameState();

            GameState.Initialize(Config.InitialPlayer);
        }

        public ActionTypes GetBestMove()
        {
            GameAI ai = new GameAI();
            return ai.GetBestAction(GameState, Config);
        }

        public void StartFromBeginning()
        {
            GameState.Initialize(Config.InitialPlayer);
        }

        public BuyItemActionResult BuyItem(ItemTypes itemType)
        {
            IAction buyItemAction = new BuyItemAction(itemType);
            return ProcessAction<BuyItemActionResult>(buyItemAction);
        }

        public HealActionResult Heal()
        {
            IAction healAction = new HealAction();
            return ProcessAction<HealActionResult>(healAction);
        }

        public AttackActionResult Attack()
        {
            IAction attackAction = new AttackAction();
            return ProcessAction<AttackActionResult>(attackAction);
        }

        private T ProcessAction<T>(IAction action) where T : ActionResultBase
        {
            ActionResultBase result = action.Process(GameState, Config);

            if (result.IsDead)
                StartFromBeginning();

            if (result is T)
                return (T)result;

            throw new InvalidCastException(String.Format("Invalid action processor for {0}", action));
        }
    }
}
