namespace UwbItContest.Web.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Teams : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Team",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TeamName = c.String(nullable: false, maxLength: 15),
                        CanAddTeamMembersImmidiately = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Team");
        }
    }
}
