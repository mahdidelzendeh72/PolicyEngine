namespace polcyEngine
{
    public interface IPolicy
    {
        string Definition { get; }
        bool When(); // Check when this policy should be applied to the model
        PolicyResult Check(); // Check the policy and return a result object
        IPolicy And(IPolicy other);
        IPolicy Or(IPolicy other);
    }

}
