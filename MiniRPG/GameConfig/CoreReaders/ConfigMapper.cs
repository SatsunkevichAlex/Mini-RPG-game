using AutoMapper;
using GameConfig.ConfigSection;
using GameConfig.Models;

namespace GameConfig.CoreReaders
{
    public static class ConfigMapper
    {
        static ConfigMapper()
        {
            Mapper.CreateMap<GameConfigurationSection, GameConfiguration>();
            
            Mapper.CreateMap<InitialPlayerElement, InitialPlayerConfiguration>();

            Mapper.CreateMap<BattleElement, BattleConfiguration>();
            Mapper.CreateMap<BattleResultElement, BattleResultConfiguration>();

            Mapper.CreateMap<ShopsElement, ShopsConfiguration>();
            Mapper.CreateMap<ShopElement, ShopConfiguration>();
        }

        public static GameConfiguration Map(this GameConfigurationSection section)
        {
            return Mapper.Map<GameConfigurationSection, GameConfiguration>(section);
        }
    }
}
