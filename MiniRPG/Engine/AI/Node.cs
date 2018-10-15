using Engine.Enums;

namespace Engine.AI
{
    class Node
    {
        public ActionTypes Action { get; private set; }
        public GameState State { get; private set; }

        public Node()
        { }

        public Node(GameState state)
        {
            State = state;
        }

        public Node(GameState state, ActionTypes action)
        {
            State = state;
            Action = action;
        }

        public int Win { get; set; }
        public int Death { get; set; }
        public int Health { get; set; }

        public int Value
        {
            get
            {
                if (Death > Win)
                    return int.MinValue;
                return Win + Health - Death * 5;
            }
        }

        public override string ToString()
        {
            return string.Format("{0} ({1})", Action, Value);
        }
    }
}
