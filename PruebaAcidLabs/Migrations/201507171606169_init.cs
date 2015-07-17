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
                        ID = c.String(nullable: false, maxLength: 128),
                        ArtistaID = c.String(maxLength: 128),
                        NombreAlbum = c.String(),
                        Año = c.Int(nullable: false),
                        Disponibilidad = c.String(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Artista", t => t.ArtistaID)
                .Index(t => t.ArtistaID);
            
            CreateTable(
                "dbo.Artista",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        NombreArtista = c.String(),
                        PopularidadArtista = c.String(),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Pista",
                c => new
                    {
                        ID = c.String(nullable: false, maxLength: 128),
                        AlbumID = c.String(maxLength: 128),
                        NombrePista = c.String(),
                        NumeroPista = c.Int(nullable: false),
                        Duracion = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Popularidad = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Album", t => t.AlbumID)
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
