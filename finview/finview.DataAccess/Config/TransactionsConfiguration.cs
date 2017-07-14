using finview.Entities.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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
            this.ToTable("Transactions");

            this.HasKey(e => new { e.TransactionDate, e.ChequeNumer, e.ClosingBalance });

            this.Property(e => e.ChequeNumer)
               .HasMaxLength(100);

            this.Property(e => e.Category)
                .HasMaxLength(50);

            this.Property(e => e.posted_at)
                .IsFixedLength()
                .IsRowVersion()
                .HasDatabaseGeneratedOption(DatabaseGeneratedOption.Computed)
                .HasMaxLength(8)
                .HasColumnType("timestamp");

            this.Property(e => e.Narration)
                .HasMaxLength(200);

            this.HasRequired(t => t.FileUploadTrack)
               .WithMany(t => t.Transactions)
               .HasForeignKey(d => d.FileUploadTrackId)
               .WillCascadeOnDelete(true);

            this.HasOptional(t => t.TransCategory)
                .WithMany(t => t.Transactions)
                .HasForeignKey(d => d.CategoryId);
        }
    }
}
