namespace finview.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.FileUploadTracks",
                c => new
                    {
                        Id = c.Long(nullable: false, identity: true),
                        UploadDate = c.DateTime(nullable: false),
                        Status = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Transactions",
                c => new
                    {
                        TransactionDate = c.DateTime(nullable: false),
                        ChequeNumer = c.String(nullable: false, maxLength: 100),
                        ClosingBalance = c.Decimal(nullable: false, precision: 18, scale: 2),
                        TransactionValueDate = c.DateTime(),
                        Narration = c.String(maxLength: 200),
                        WithdrawalAmount = c.Decimal(precision: 18, scale: 2),
                        DepositAmount = c.Decimal(precision: 18, scale: 2),
                        Category = c.String(maxLength: 50),
                        posted_at = c.Binary(nullable: false, fixedLength: true, timestamp: true, storeType: "timestamp"),
                        FileUploadTrackId = c.Long(nullable: false),
                    })
                .PrimaryKey(t => new { t.TransactionDate, t.ChequeNumer, t.ClosingBalance })
                .ForeignKey("dbo.FileUploadTracks", t => t.FileUploadTrackId, cascadeDelete: true)
                .Index(t => t.FileUploadTrackId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Transactions", "FileUploadTrackId", "dbo.FileUploadTracks");
            DropIndex("dbo.Transactions", new[] { "FileUploadTrackId" });
            DropTable("dbo.Transactions");
            DropTable("dbo.FileUploadTracks");
        }
    }
}
