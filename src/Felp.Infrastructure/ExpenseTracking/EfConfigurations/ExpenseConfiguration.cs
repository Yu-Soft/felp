using Felp.Core.ExpenseTracking.ExpenseAggregate;
using Felp.Core.ExpenseTracking.Shared;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Felp.Infrastructure.ExpenseTracking.EfConfigurations
{
    public class ExpenseConfiguration : IEntityTypeConfiguration<Expense>
    {
        public void Configure(EntityTypeBuilder<Expense> builder)
        {
            builder.ToTable("Expense");
            builder.HasKey(x=>x.Id);

            builder.OwnsOne(x=>x.Amount, a => { 
                a.Property(x=>x.Value).HasColumnName("Amount").IsRequired();
                a.Property(x => x.Currency).HasColumnName("Currency").HasMaxLength(3).IsRequired();
            });

            builder.Property(x => x.CategoryCode)
                   .HasConversion(categoryCode => categoryCode.Value,
                                                              value => CategoryCode.From(value))
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.Note)
                   .HasMaxLength(200)
                   .IsRequired(false);

            builder.Property(x => x.EnteredByUserCode)
                   .HasConversion(userCode => userCode.Value,
                                  value => UserCode.From(value))
                   .HasMaxLength(50)
                   .IsRequired();

            builder.Property(x => x.EnteredForHomeCode)
                   .HasConversion(homeCode => homeCode.Value,
                                  value => HomeCode.From(value))
                   .HasMaxLength(50)
                   .IsRequired();
        }
    }
}
