using System;

namespace Engine.Exceptions
{
    public class PlayerDataException : Exception
    {
        public PlayerDataException(string message) : base(message)
        { }

        public PlayerDataException()
        { }
    }
}
