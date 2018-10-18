using System;

namespace Engine.Utils
{
    public static class Generator
    {
        private static readonly Random _generator = new Random();
        private static readonly object locker = new object();
        
        /// <summary>
        /// Thread safe generate [min, max]
        /// </summary>
        public static int Next(int minm, int maxValue)
        {
            lock (locker)
            {
                //https://msdn.microsoft.com/en-us/library/2dx6wyd4(v=vs.110).aspx
                return _generator.Next(minm, maxValue + 1);
            }
        }
    }
}
