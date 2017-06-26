namespace finview.DataAccess.Data
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;
    using finview.Entities.Model;
    using finview.DataAccess.Config;

    public partial class FinViewModel : DbContext
    {
        public FinViewModel()
            : base("name=finviewdb")
        {
        }

        public virtual DbSet<Transactions> Tables { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Transactions>()
                .Property(e => e.posted_at)
                .IsFixedLength();

            modelBuilder.Configurations.Add<Transactions>(new TransactionsConfiguration());
        }
    }
}
