namespace PruebaAcidLabs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Album",
                c => new
                    {
                        AlbumID = c.Int(nullable: false, identity: true),
                        ArtistaID = c.Int(nullable: false),
                        NombreAlbum = c.String(),
                        PopularidadAlbum = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Disponibilidad = c.String(),
                    })
                .PrimaryKey(t => t.AlbumID)
                .ForeignKey("dbo.Artista", t => t.ArtistaID, cascadeDelete: true)
                .Index(t => t.ArtistaID);
            
            CreateTable(
                "dbo.Artista",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        NombreArtista = c.String(),
                        PopularidadArtista = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pista",
                c => new
                    {
                        PistaID = c.Int(nullable: false, identity: true),
                        AlbumID = c.Int(nullable: false),
                        NombrePista = c.String(),
                        NumeroPista = c.Int(nullable: false),
                        Duracion = c.Int(nullable: false),
                        Popularidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.PistaID)
                .ForeignKey("dbo.Album", t => t.AlbumID, cascadeDelete: true)
                .Index(t => t.AlbumID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Pista", "AlbumID", "dbo.Album");
            DropForeignKey("dbo.Album", "ArtistaID", "dbo.Artista");
            DropIndex("dbo.Pista", new[] { "AlbumID" });
            DropIndex("dbo.Album", new[] { "ArtistaID" });
            DropTable("dbo.Pista");
            DropTable("dbo.Artista");
            DropTable("dbo.Album");
        }
    }
}
