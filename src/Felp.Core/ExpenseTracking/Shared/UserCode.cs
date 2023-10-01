using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;

namespace Felp.Core.ExpenseTracking.Shared
{
    public class UserCode : ValueObject
    {
        public string Value { get; private set; }

        public static UserCode From(string value)
        {
            Guard.Against.NullOrEmpty(value, nameof(value));
            return new UserCode
            {
                Value = value
            };
        }
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
        }
    }
}
