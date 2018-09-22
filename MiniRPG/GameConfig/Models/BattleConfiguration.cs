using GameConfig.Enums;

namespace GameConfig.Models
{
    public sealed class BattleConfiguration
    {
        public int MinWinProbability { get; set; }
        public int MaxWinProbability { get; set; }
        public int IncreasePowerProbability { get; set; }
        public BattleResultConfiguration WinResult { get; set; }
        public BattleResultConfiguration LooseResult { get; set; }
    }

    public sealed class BattleResultConfiguration
    {
        public int CoinsChange { get; set; }
        public int HealthChange { get; set; }
        public ChangeValueTypes HealthChangeType { get; set; }
    }
}
