namespace PruebaAcidLabs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Pista", "AlbumID", "dbo.Album");
            DropIndex("dbo.Album", new[] { "Artista_ID" });
            DropIndex("dbo.Pista", new[] { "AlbumID" });
            DropColumn("dbo.Album", "ArtistaID");
            RenameColumn(table: "dbo.Album", name: "Artista_ID", newName: "ArtistaID");
            DropPrimaryKey("dbo.Album");
            DropPrimaryKey("dbo.Pista");
            AddColumn("dbo.Album", "ID", c => c.String(nullable: false, maxLength: 128));
            AddColumn("dbo.Pista", "ID", c => c.String(nullable: false, maxLength: 128));
            AlterColumn("dbo.Album", "ArtistaID", c => c.String(maxLength: 128));
            AlterColumn("dbo.Pista", "AlbumID", c => c.String(maxLength: 128));
            AddPrimaryKey("dbo.Album", "ID");
            AddPrimaryKey("dbo.Pista", "ID");
            CreateIndex("dbo.Album", "ArtistaID");
            CreateIndex("dbo.Pista", "AlbumID");
            AddForeignKey("dbo.Pista", "AlbumID", "dbo.Album", "ID");
            DropColumn("dbo.Album", "AlbumID");
            DropColumn("dbo.Pista", "PistaID");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pista", "PistaID", c => c.Int(nullable: false, identity: true));
            AddColumn("dbo.Album", "AlbumID", c => c.Int(nullable: false, identity: true));
            DropForeignKey("dbo.Pista", "AlbumID", "dbo.Album");
            DropIndex("dbo.Pista", new[] { "AlbumID" });
            DropIndex("dbo.Album", new[] { "ArtistaID" });
            DropPrimaryKey("dbo.Pista");
            DropPrimaryKey("dbo.Album");
            AlterColumn("dbo.Pista", "AlbumID", c => c.Int(nullable: false));
            AlterColumn("dbo.Album", "ArtistaID", c => c.Int(nullable: false));
            DropColumn("dbo.Pista", "ID");
            DropColumn("dbo.Album", "ID");
            AddPrimaryKey("dbo.Pista", "PistaID");
            AddPrimaryKey("dbo.Album", "AlbumID");
            RenameColumn(table: "dbo.Album", name: "ArtistaID", newName: "Artista_ID");
            AddColumn("dbo.Album", "ArtistaID", c => c.Int(nullable: false));
            CreateIndex("dbo.Pista", "AlbumID");
            CreateIndex("dbo.Album", "Artista_ID");
            AddForeignKey("dbo.Pista", "AlbumID", "dbo.Album", "AlbumID", cascadeDelete: true);
        }
    }
}
