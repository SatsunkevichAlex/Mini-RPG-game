using Engine;
using Engine.Actions;
using Engine.Actions.Base;
using Engine.AI;
using Engine.Enums;
using GameConfig.ConfigSection;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace MiniRPG
{
    internal class GameAI
    {
        private static readonly int ProcessCount = 13;
        private static readonly int CalculateAttackCount = 10000;
        private static readonly int Deep = 3;
        public GameConfiguration Config { get; set; }

        public ActionTypes GetBestAction(GameState state, GameConfiguration config)
        {
            Config = config;

            List<Node> bestList = new List<Node>();

            Parallel.For(0, ProcessCount, index =>
            {
                Node start = new Node(state.DeepCopy());
                Node best = Iterate(start, Deep);
                bestList.Add(best);
            });

            bestList = bestList.OrderByDescending(x => x.Value).ToList();

            var result = bestList.Where(x => x.Value > 0).ToList();
            Node bestGroup = null;
            if (result.Count > 0)
            {
                bestGroup = result.GroupBy(x => x.Action)
                                  .OrderByDescending(x => x.Sum(a => a.Value))
                                  .First().First();
            }

            Node bestByValue = bestList.First();

            Debug.WriteLine("1 = {0}, 2 = {1}", bestByValue.Action,
                            bestGroup != null ? bestGroup.Action.ToString() : "null");

            return (bestGroup ?? bestByValue).Action;
        }

        public Node Iterate(Node node, int depth)
        {
            Node best = null;
            Node childReturn = null;
            if (depth == 0 || node.State.CurrentPlayer.Health == 0)
            {
                var calcResult = Calculate(node.State);
                node.Win = calcResult.Item1;
                node.Death = calcResult.Item2;
                node.Health = node.State.CurrentPlayer.Health;
                return node;
            }

            foreach (Node child in Children(node.State))
            {
                Node iteratedNode = Iterate(child, depth - 1);

                if (best == null || iteratedNode.Value > best.Value)
                {
                    best = iteratedNode;
                    childReturn = child;
                    childReturn.Death = best.Death;
                    childReturn.Win = best.Win;
                    childReturn.Health = best.Health;
                }
            }

            if (childReturn == null)
                return node;

            return childReturn;
        }

        private List<Node> Children(GameState state)
        {
            if (state.CurrentPlayer.Health == 0)
                return new List<Node>();

            List<Node> resultNodes = new List<Node>();

            List<IAction> actions = new List<IAction>();

            actions.Add(new AttackAction());
            actions.Add(new HealAction());
            actions.Add(new BuyItemAction(ItemTypes.Weapon));
            actions.Add(new BuyItemAction(ItemTypes.Armor));

            foreach (IAction action in actions)
            {
                GameState copy = state.DeepCopy();
                if (action.CanApply(copy, Config))
                {
                    action.Process(copy, Config);
                    resultNodes.Add(new Node(copy, action.Type));
                }
            }

            return resultNodes;
        }

        private Tuple<int, int> Calculate(GameState state)
        {
            AttackAction action = new AttackAction();
            int win = 0;
            int death = 0;
            GameState copy;
            for (int i = 0; i < CalculateAttackCount; i++)
            {
                copy = state.DeepCopy();
                AttackActionResult result = (AttackActionResult)action.Process(copy, Config);
                if (result.IsWin)
                    win++;
                if (result.IsDead)
                    death++;
            }

            return new Tuple<int, int>(win / 10, death / 10);
        }
    }
}
