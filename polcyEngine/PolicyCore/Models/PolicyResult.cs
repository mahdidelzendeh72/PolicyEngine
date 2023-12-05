namespace polcyEngine
{
    public class PolicyResult
    {
        public PolicyResult(bool isPassed, string message, string definition)
        {
            IsPassed = isPassed;
            Message = message;
            Definition = definition;
        }
        public bool IsPassed { get; set; }
        public string Message { get; set; }
        public string Definition { get; set; }

        public static PolicyResult SuccessResult()
        {
            return new PolicyResult(true, string.Empty,string.Empty);
        }
        public static PolicyResult FailedResult(string message,string definition)
        {
            return new PolicyResult(false, message, definition);
        }
    }

}
