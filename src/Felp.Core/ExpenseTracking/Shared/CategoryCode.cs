using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;

namespace Felp.Core.ExpenseTracking.Shared
{
    public class CategoryCode : ValueObject
    {
        public string Value { get; private set; }

        public static CategoryCode From(string value)
        {
            Guard.Against.NullOrEmpty(value, nameof(value));
            return new CategoryCode
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
