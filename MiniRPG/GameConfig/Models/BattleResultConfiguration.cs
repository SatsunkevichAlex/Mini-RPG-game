using GameConfig.Enums;

namespace GameConfig.Models
{
    public sealed class BattleResultConfiguration
    {
        public int CoinsChange { get; set; }
        public int HealthChange { get; set; }
        public ChangeValueTypes HealthChangeType { get; set; }
    }
}
