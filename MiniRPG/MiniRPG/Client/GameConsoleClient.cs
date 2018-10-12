using Engine;
using Engine.Actions;
using Engine.Enums;
using GameConfig;
using MiniRPG.IoC;
using System;
using System.Collections.Generic;

namespace MiniRPG.Client
{
    internal class GameConsoleClient
    {
        private ActionTypes _expertActionType;
        private readonly Game _game;
        private readonly Dictionary<char, GameMenuItem> _menu;
        private readonly List<string> _messagesFromActions;

        public GameConsoleClient()
        {
            _menu = new Dictionary<char, GameMenuItem>();
            _messagesFromActions = new List<string>();

            _game = new Game(Resolver.Current.GetInstance<IGameConfigReader>());

            _menu.Add('w', new GameMenuItem("Attack", Attack));
            _menu.Add('a', new GameMenuItem("Buy Weapon", BuyWeapon));
            _menu.Add('d', new GameMenuItem("Buy Armor", BuyArmor));
            _menu.Add('s', new GameMenuItem("Heal", Heal));
            _menu.Add('e', new GameMenuItem("Auto", Auto));
            _menu.Add('9', new GameMenuItem("Exit", null, true));
        }

        public void Start()
        {
            bool inGame = true;

            while (inGame)
            {
                Console.Clear();
                PrintStatus();
                PrintMenu();
                Console.Write(">");
                _expertActionType = _game.GetBestMove();
                Console.WriteLine("Expert advice: {0}", _expertActionType);

                ConsoleKeyInfo key = Console.ReadKey();
                _messagesFromActions.Clear();
                char selectedMenu = key.KeyChar;
                if (_menu.ContainsKey(selectedMenu))
                {
                    if (_menu[selectedMenu].IsExit)
                        return;

                    if (_menu[selectedMenu] != null)
                        _menu[selectedMenu].Action();
                }
                else
                {
                    _messagesFromActions.Add("No action with this key");
                }
            }
        }

        private void BuyItem(ItemTypes type)
        {
            BuyItemActionResult result = _game.BuyItem(type);
            if (!result.IsSeccessful)
                _messagesFromActions.Add("Fail buy (no money).");
            else
                _messagesFromActions.Add(string.Format("Item Effect: {0}", result.EffectResult));
        }

        private void BuyWeapon()
        {
            _messagesFromActions.Add("Buy Weapon");
            BuyItem(ItemTypes.Weapon);
        }

        private void BuyArmor()
        {
            _messagesFromActions.Add("Buy Armor");
            BuyItem(ItemTypes.Armor);
        }

        private void Attack()
        {
            _messagesFromActions.Add("Attack");

            AttackActionResult result = _game.Attack();

            if (result.IsDead)
            {
                _messagesFromActions.Add("You dead. Game Over.");
                _messagesFromActions.Add(string.Format("Your level: {0}", result.Level));
                return;
            }

            if (result.IsWin)
                _messagesFromActions.Add("You win!");
            else
                _messagesFromActions.Add("You loose!");
        }

        private void Heal()
        {
            _messagesFromActions.Add("Heal");
            HealActionResult result = _game.Heal();
            if (!result.IsSeccessful)
                _messagesFromActions.Add("Heal fail (no money)");
            else
                _messagesFromActions.Add(string.Format("Heal action for: {0}", result.HealAction));
        }

        private void Auto()
        {
            ActionTypes action = _expertActionType;
            switch(action)
            {
                case ActionTypes.Attack:
                    Attack();
                    break;
                case ActionTypes.BuyArmor:
                    BuyArmor();
                    break;
                case ActionTypes.BuyWeapon:
                    BuyWeapon();
                    break;
                case ActionTypes.Heal:
                    Heal();
                    break;
            }
        }

        private void PrintStatus()
        {
            Console.WriteLine("**************** Player Info ****************");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(" Health.....{0}/{1}", _game.GameState.CurrentPlayer.Health,
                                                     _game.GameState.CurrentPlayer.MaxHealth);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(" Power.....{0}", _game.GameState.CurrentPlayer.Power);

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine(" Coins......{0}", _game.GameState.CurrentPlayer.Coins);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(" Items......{0} total", _game.GameState.CurrentPlayer.Items.Count);

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine(" Level......{0}", _game.GameState.Attacks);

            Console.WriteLine();
            foreach (string messageFromAction in _messagesFromActions)
            {
                Console.Write(">");
                Console.WriteLine(messageFromAction);
            }
            Console.WriteLine();
        }

        private void PrintMenu()
        {
            DrawStars();
            foreach(KeyValuePair<char, GameMenuItem> pair in _menu)
            {
                Console.WriteLine(" {0}. {1}", pair.Key, pair.Value.Title);
            }
            DrawStars();
            Console.WriteLine();
        }

        private void DrawStars()
        {
            Console.WriteLine("**********************************");
        }
    }
}
