using GameConfig;
using GameConfig.CoreReaders;
using StructureMap.Configuration.DSL;

namespace MiniRPG.IoC
{
    internal sealed class DefaultRegistry : Registry
    {
        public DefaultRegistry()
        {
            For<IGameConfigReader>().Use<ConfigSectionReader>();
        }
    }
}
