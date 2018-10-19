using Engine;
using Engine.Actions;
using GameConfig.ConfigSection;
using NUnit.Framework;
using Engine.Actions.Base;

namespace MiniRPGTests
{
    [TestFixture]
    public class HealActionTest
    {
        private GameConfiguration config;

        [SetUp]
        public void Init()
        {
            config = new GameConfiguration();
            config.Shops.Heal.Price = 10;
            config.Shops.Heal.EffectFrom = 10;
            config.Shops.Heal.EffectTo = 10;
        }

        [Test]
        public void HealAction_CheckMaxHealth_Correct()
        {
            GameState state = new GameState();
            state.CurrentPlayer = new Player();
            state.CurrentPlayer.Initialize(10, 15, 10, 10);

            IAction healAction = new HealAction();
            healAction.Process(state, config);
            Assert.AreEqual(state.CurrentPlayer.Health, 15);
        }

        [Test]
        public void HealAction_Heal_DecreaseCoins()
        {
            GameState state = new GameState();
            state.CurrentPlayer = new Player();
            state.CurrentPlayer.Initialize(10, 20, 10, 10);

            IAction healAction = new HealAction();
            Assert.AreEqual(healAction.CanApply(state, config), true);

            ActionResultBase actionResult = healAction.Process(state, config);
            Assert.AreEqual(actionResult.IsSeccessful, true);

            Assert.AreEqual(state.CurrentPlayer.Coins, 0);
            Assert.AreEqual(state.CurrentPlayer.Health, 20);
        }

        [Test]
        public void HealAction_CheckCoins_AreNotEnough()
        {
            GameState state = new GameState();
            state.CurrentPlayer = new Player();
            state.CurrentPlayer.Initialize(10, 10, 10, 9);

            IAction healAction = new HealAction();
            Assert.AreEqual(healAction.CanApply(state, config), false);
        }
    }
}
