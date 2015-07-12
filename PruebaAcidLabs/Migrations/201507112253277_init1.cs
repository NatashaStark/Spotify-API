namespace PruebaAcidLabs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init1 : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Album", "Popularidad", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Artista", "Popularidad", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AlterColumn("dbo.Pista", "Popularidad", c => c.Decimal(nullable: false, precision: 18, scale: 2));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pista", "Popularidad", c => c.Single(nullable: false));
            AlterColumn("dbo.Artista", "Popularidad", c => c.Single(nullable: false));
            AlterColumn("dbo.Album", "Popularidad", c => c.Single(nullable: false));
        }
    }
}
