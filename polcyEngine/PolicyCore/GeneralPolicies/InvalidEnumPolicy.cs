using polcyEngine.PolicyCore.Engine;

namespace polcyEngine
{
    public class InvalidEnumPolicy<T> : BasePolicy where T : Enum
    {
        private readonly object model;
        private readonly string _propertyName;
        private readonly List<T> _invalidValue;

        public override string Definition => $"{nameof(InvalidEnumPolicy<T>)} :check enum field in a model is valid and not in forbiden list";

        public InvalidEnumPolicy(object model, string propertyName, params T[] invalidValue)
        {
            this.model = model;
            _propertyName = propertyName;
            _invalidValue = invalidValue.ToArray().ToList();
        }

        public override bool When()
        {

            return model != null &&
                   model.GetType().GetProperty(_propertyName)?.GetValue(model, null) is T;
        }

        public override PolicyResult Check()
        {
            var propertyValue = model.GetType().GetProperty(_propertyName)?.GetValue(model, null);
            if (propertyValue == null || _invalidValue.Contains((T)propertyValue))
            {
                return PolicyResult.FailedResult($"The {_propertyName} field cannot be null or one of the invalid values: {string.Join(',', _invalidValue)}", Definition);

            }
            else
            {
                return PolicyResult.SuccessResult();

            }
        }

    }

}
