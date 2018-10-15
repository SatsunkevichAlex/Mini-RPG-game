using MiniRPG.Client;

namespace MiniRPG
{
    class EntryPoint
    {
        static void Main(string[] args)
        {
            GameConsoleClient client = new GameConsoleClient();
            client.Start();
        }
    }
}
