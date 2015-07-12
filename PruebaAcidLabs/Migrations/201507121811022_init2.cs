namespace PruebaAcidLabs.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class init2 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Album", "NombreAlbum", c => c.String());
            AddColumn("dbo.Album", "PopularidadAlbum", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Artista", "NombreArtista", c => c.String());
            AddColumn("dbo.Artista", "PopularidadArtista", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Pista", "NombrePista", c => c.String());
            DropColumn("dbo.Album", "Nombre");
            DropColumn("dbo.Album", "Popularidad");
            DropColumn("dbo.Artista", "Nombre");
            DropColumn("dbo.Artista", "Popularidad");
            DropColumn("dbo.Pista", "Nombre");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Pista", "Nombre", c => c.String());
            AddColumn("dbo.Artista", "Popularidad", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Artista", "Nombre", c => c.String());
            AddColumn("dbo.Album", "Popularidad", c => c.Decimal(nullable: false, precision: 18, scale: 2));
            AddColumn("dbo.Album", "Nombre", c => c.String());
            DropColumn("dbo.Pista", "NombrePista");
            DropColumn("dbo.Artista", "PopularidadArtista");
            DropColumn("dbo.Artista", "NombreArtista");
            DropColumn("dbo.Album", "PopularidadAlbum");
            DropColumn("dbo.Album", "NombreAlbum");
        }
    }
}
