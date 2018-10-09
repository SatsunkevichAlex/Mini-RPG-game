using StructureMap;

namespace MiniRPG.IoC
{
    internal static class Resolver
    {
        private static IContainer _container;

        public static IContainer Current
        {
            get
            {
                if (_container == null)
                    _container = Initialize();
                return _container;
            }
        }

        private static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}
