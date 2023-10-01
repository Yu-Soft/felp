using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;

namespace Felp.Core.ExpenseTracking.Shared
{
    public class ExpenseAmount : ValueObject
    {
        public decimal Value { get; private set; }
        public string Currency { get; private set; }
        protected ExpenseAmount()
        {

        }
        public static ExpenseAmount From(decimal value, string currency) {
            Guard.Against.NegativeOrZero(value, nameof(value));
            Guard.Against.NullOrEmpty(currency, nameof(currency));
            return new ExpenseAmount { 
                Value = value,
                Currency = currency
            };
        }
        protected override IEnumerable<IComparable> GetEqualityComponents()
        {
            yield return Value;
            yield return Currency;
        }
    }
}
