using polcyEngine.PolicyCore.Engine;

namespace polcyEngine
{
    public class NotNullOrEmptyStringPolicy : BasePolicy
    {
        private readonly object model;
        private readonly string _propertyName;

        public NotNullOrEmptyStringPolicy(object model, string propertyName)
        {
            this.model = model;
            _propertyName = propertyName;
        }
        public override string Definition => "این قانون مقدار داشتن یک فیلد خاص تحت شرایط مشخص چک میکند";

        public override  bool When()
        {
            var propertyValue = model.GetType().GetProperty(_propertyName)?.GetValue(model, null);
            return model != null && propertyValue is string;
        }

        public override PolicyResult Check()
        {
            var propertyValue = model.GetType().GetProperty(_propertyName)?.GetValue(model, null);
            if (propertyValue is string && !string.IsNullOrEmpty((string)propertyValue))
                return PolicyResult.SuccessResult();

            else
                return PolicyResult.FailedResult($"مقدار فیلد {_propertyName} نباید خالی باشد ",Definition);

        }
    }

}
