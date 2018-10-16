using StructureMap;

namespace MiniRPG.IoC
{
    internal static class PTResolver
    {
        private static IContainer Сontainer { get; set; }

        public static IContainer Current
        {
            get
            {
                if (Сontainer == null)
                    Сontainer = Initialize();
                return Сontainer;
            }
        }

        private static IContainer Initialize()
        {
            return new Container(c => c.AddRegistry<DefaultRegistry>());
        }
    }
}
