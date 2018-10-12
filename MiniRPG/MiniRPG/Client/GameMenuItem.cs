using System;

namespace MiniRPG.Client
{
    internal class GameMenuItem
    {
        public string Title { get; set; }
        public Action Action { get; set; }
        public bool IsExit { get; set; }

        public GameMenuItem(string title, Action action, bool isExit)
        {
            Action = action;
            Title = title;
            IsExit = isExit;
        }

        public GameMenuItem(string title, Action action) : this(title, action, false)
        {  }
    }
}
