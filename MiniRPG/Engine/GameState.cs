using GameConfig.Models;

namespace Engine
{
    public sealed class GameState
    {
        public Player CurrentPlayer { get; set; }

        public int Attacks { get; set; }

        public void Initialize(InitialPlayerConfiguration config)
        {

        }
    }
}
