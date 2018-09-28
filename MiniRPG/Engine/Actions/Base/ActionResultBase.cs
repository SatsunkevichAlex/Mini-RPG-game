namespace Engine.Actions.Base
{
    public abstract class ActionResultBase
    {
        protected ActionResultBase()
        {
            IsSeccessful = true;
        }

        public bool IsSeccessful { get; set; }
        public bool IsDead { get; set; }
    }
}
