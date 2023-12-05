namespace polcyEngine
{

    public class PolicyEngine
    {
        private readonly List<IPolicy> _policies;

        public PolicyEngine()
        {
            _policies = new List<IPolicy>();
        }

        public void AddPolicy(IPolicy policy)
        {
            _policies.Add(policy);
        }
        public void AddRangePolicy(IEnumerable<IPolicy> policies)
        {
            _policies.AddRange(policies);
        }

        public List<PolicyResult> Run()
        {
            var notPassedPolicies = new List<PolicyResult>();
            foreach (var policy in _policies)
            {
                if (policy.When())
                {
                    var result = policy.Check();
                    if (!result.IsPassed)
                    {
                        notPassedPolicies.Add(result);
                    }
                }
            }

            return notPassedPolicies;
        }
    }

}
