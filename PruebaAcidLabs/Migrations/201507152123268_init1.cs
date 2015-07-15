namespace PruebaAcidLabs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pista", "NumeroPista", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pista", "NumeroPista", c => c.String());
        }
    }
}
