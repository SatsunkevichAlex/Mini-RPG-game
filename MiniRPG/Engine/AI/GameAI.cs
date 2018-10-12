using Engine;
using Engine.Enums;
using GameConfig.ConfigSection;
using System.Threading.Tasks;

namespace MiniRPG
{
    internal class GameAI
    {
        private static readonly int ProcessCount = 13;
        private static readonly int CalculateAttaclCount = 10000;
        private static readonly int Deep = 3;
        private GameConfiguration _config;

        public ActionTypes GetBestAction(GameState state, GameConfiguration config)
        {
            _config = config;

            List<Node> bestList = new List<Node>();

            Parallel.For(0, ProcessCount, index =>
            {
                Node start = new Node(state.DeepCoopy());
                Node best = Iterate(start, Deep);
                bestList.Add(best);
            });
        }
    }
}
