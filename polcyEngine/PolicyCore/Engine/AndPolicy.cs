namespace polcyEngine.PolicyCore.Engine
{

    public class AndPolicy : IPolicy
    {
        private readonly IPolicy _first;
        private readonly IPolicy _second;

        public string Definition => $"({_first.Definition} &  {_second.Definition})";

        public AndPolicy(IPolicy first, IPolicy second)
        {
            _first = first;
            _second = second;
        }
        public bool When()
        {
            return _first.When() && _second.When();
        }
        public PolicyResult Check()
        {
            var firstResult = _first.Check();
            if (!firstResult.IsPassed)
            {
                return firstResult;
            }

            var secondResult = _second.Check();
            if (!secondResult.IsPassed)
            {
                return secondResult;
            }
            return PolicyResult.SuccessResult();
        }


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
