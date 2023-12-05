namespace polcyEngine.PolicyCore.Engine
{
    public abstract class BasePolicy : IPolicy
    {
        public abstract string Definition { get; }

        public abstract PolicyResult Check();
        public abstract bool When();
        public IPolicy And(IPolicy other)
        {
            return new AndPolicy(this, other);
        }
        public IPolicy Or(IPolicy other)
        {
            return new OrPolicy(this, other);
        }

    }
}
