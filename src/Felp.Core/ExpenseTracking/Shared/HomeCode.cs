using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;

namespace Felp.Core.ExpenseTracking.Shared
{
    public class HomeCode : ValueObject
    {
        public string Value { get; private set; }

        public static HomeCode From(string value)
        {
            Guard.Against.NullOrEmpty(value, nameof(value));
            return new HomeCode
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
