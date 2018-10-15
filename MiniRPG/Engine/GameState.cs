using GameConfig.Models;

namespace Engine
{
    public sealed class GameState
    {
        public Player CurrentPlayer { get; set; }

        public int Attacks { get; set; }

        public void Initialize(InitialPlayerConfiguration config)
        {
            Attacks = 0;

            CurrentPlayer = new Player();
            CurrentPlayer.Initialize(
                          config.InitialPlayerHealth,
                          config.InitialPlayerMaxHealth,
                          config.InitialPlayerPower,
                          config.InitialPlayerCoins);
        }

        public GameState DeepCopy()
        {
            return new GameState
            {
                Attacks = Attacks,
                CurrentPlayer = CurrentPlayer.DeepCopy()
            };
        }
    }
}
