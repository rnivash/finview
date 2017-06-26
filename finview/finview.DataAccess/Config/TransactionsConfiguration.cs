using finview.Entities.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace finview.DataAccess.Config
{
    public class TransactionsConfiguration : EntityTypeConfiguration<Transactions>
    {
        public TransactionsConfiguration()
        {
            this.HasKey(e => new { e.TransactionDate, e.ChequeNumer });

            this.Property(e => e.ChequeNumer)
               .HasMaxLength(100);

            this.Property(e => e.Category)
                .HasMaxLength(50);

            this.Property(e => e.posted_at)
                .IsFixedLength();

            this.Property(e => e.Narration)
                .HasMaxLength(200);
        }
    }
}
