using Engine;
using Engine.Exceptions;
using NUnit.Framework;
using System;

namespace MiniRPGTests
{
    [TestFixture]
    public class PlayerTests
    {
        [Test]
        public void Player_InitializeWithIncorrectDate_ThrowException()
        {
            Player player = new Player();
            Assert.Throws<ArgumentOutOfRangeException>(() => player.Initialize(10, 10, -1, -1));
        }

        [Test]
        public void Player_DoubleInitialize_ThrowException()
        {
            Player player = new Player();
            player.Initialize(10, 20, 10, 20);
            Assert.Throws<PlayerDataException>(() => player.Initialize(10, 20, 10, 20));
        }

        [Test]
        public void Player_CoinsCountBelowZero_ThrowException()
        {
            Player player = new Player();
            player.Initialize(10, 20, 10, 20);
            Assert.Throws<PlayerDataException>(() => player.DecreaseCoins(1000));
        }

        [Test]
        public void Player_WorkWithCoinsCount_Correct()
        {
            Player player = new Player();
            player.Initialize(10, 20, 1, 1);

            player.ApplyHeal(40);
            Assert.AreEqual(player.Health, 20);

            player.ApplyDamage(15);
            Assert.AreEqual(player.Health, 5);

            player.ApplyDamage(10);
            Assert.AreEqual(player.Health, 0);
        }

        [Test]
        public void Player_InitPlayer_Correct()
        {
            Player player = new Player();
            player.Initialize(1, 2, 3, 4);

            Assert.AreEqual(player.Health, 1);
            Assert.AreEqual(player.MaxHealth, 2);
            Assert.AreEqual(player.Power, 3);
            Assert.AreEqual(player.Coins, 4);
        }
    }
}
