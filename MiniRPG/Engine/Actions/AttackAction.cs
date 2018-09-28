using Engine.Actions.Base;
using Engine.Enums;
using Engine.Utils;
using GameConfig.ConfigSection;
using GameConfig.Enums;
using GameConfig.Models;
using System;

namespace Engine.Actions
{
    public sealed class AttackActionResult : ActionResultBase
    {
        public bool IsWin { get; set; }
        public bool Level { get; set; }
    }

    internal sealed class AttackAction : IAction
    {
        public ActionResultBase Process(GameState state, GameConfiguration config)
        {
            AttackActionResult result = new AttackActionResult();

            int winProbability =
                Math.Min(
                    config.Battle.MinWinProbability + state.CurrebtPlayer.Power * config.Battle.IncreasePowerProbability,
                    config.Battle.MaxWinProbability);

            int random = Generator.Next(1, 100);

            BattleResultConfiguration battleResult = null;

            //Win
            if (random <= winProbability)
            {
                battleResult = config.Battle.WinResult;
                result.IsWin = true;
                state.Attacks++;
            }
            //Loose
            else
                battleResult = config.Battle.LooseResult;

            state.CurrentPlayer.ApplyDamage(-GetDemage(state.CurrentPlayer.Health, battleResult));
            state.CurrentPlayer.AddCoins(battleResult.CoinsChange);
            result.Level = state.Attacks;

            if (state.CurrentPlayer.Health <= 0)
                result.IsDead = true;

            return result;
        }

        public bool CanApply(GameState state, GameConfiguration config) => true;

        public ActionTypes Type => ActionTypes.Attack;

        private int GetDamge(int currentHealth, BattleResultConfiguration config)
        {
            switch (config.HealthChangeType)
            {
                case ChangeValueTypes.Percent:
                    return (int)Math.Round(currentHealth * config.HealthChange / 100.0);
                default:
                    return config.HealthChange;
            }
        }
    }
}
