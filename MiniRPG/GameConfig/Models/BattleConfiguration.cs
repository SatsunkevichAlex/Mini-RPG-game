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
}
