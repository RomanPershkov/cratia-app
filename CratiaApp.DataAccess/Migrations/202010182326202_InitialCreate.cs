namespace CratiaApp.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Battles",
                c => new
                    {
                        Id = c.Guid(nullable: false),
                        Date = c.DateTime(nullable: false),
                        Winner = c.String(),
                        Loser = c.String(),
                        Rounds = c.Int(nullable: false),
                        RefereePointsWinner = c.Int(nullable: false),
                        RefereePointsLoser = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Battles");
        }
    }
}
