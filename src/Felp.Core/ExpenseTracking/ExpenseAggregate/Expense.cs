using Ardalis.GuardClauses;
using CSharpFunctionalExtensions;
using Felp.Core.ExpenseTracking.Shared;

namespace Felp.Core.ExpenseTracking.ExpenseAggregate
{
    public class Expense : Entity<int>
    {
        public ExpenseAmount Amount { get; private set; }
        public DateTimeOffset ExpenseDate { get; private set; }
        public CategoryCode CategoryCode { get; private set; }
        public string? Note { get; private set; }

        public UserCode EnteredByUserCode { get; private set; }
        public HomeCode EnteredForHomeCode { get; private set; }
        public DateTimeOffset EntryDate { get; private set; }

        protected Expense()
        {

        }

        public static Expense New(ExpenseAmount expenseAmount, DateTimeOffset expenseDate, CategoryCode categoryCode) {
            Guard.Against.Null(expenseAmount , nameof(expenseAmount));
            Guard.Against.Null(categoryCode, nameof(categoryCode));
            return new Expense { 
                Amount = expenseAmount,
                ExpenseDate = expenseDate.UtcDateTime,
                CategoryCode = categoryCode,
                EntryDate = DateTimeOffset.UtcNow,
            };
        }

        public void SetEnteredBy(UserCode userCode) { 
            Guard.Against.Null(userCode, nameof(userCode));
            EnteredByUserCode = userCode;
        }
        public void SetEnteredFor(HomeCode homeCode)
        {
            Guard.Against.Null(homeCode, nameof(homeCode));
            EnteredForHomeCode = homeCode;
        }
        public void SetNote(string note) {
            Guard.Against.NullOrEmpty(note, nameof(note));
            Note = note;
        }
    }
}
