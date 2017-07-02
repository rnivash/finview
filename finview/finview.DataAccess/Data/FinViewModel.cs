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

        public virtual DbSet<FileUploadTrack> FileUploadTracks { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Configurations.Add<Transactions>(new TransactionsConfiguration());

            modelBuilder.Configurations.Add<FileUploadTrack>(new FileUploadTrackConfiguration());
        }
    }
}
