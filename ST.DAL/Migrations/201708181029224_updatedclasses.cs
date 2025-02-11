namespace ST.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class updatedclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.SiparisDetaylar",
                c => new
                    {
                        SiparisId = c.Int(nullable: false),
                        UrunId = c.Int(nullable: false),
                        Adet = c.Int(nullable: false),
                        UrunFiyat = c.Decimal(nullable: false, precision: 7, scale: 2),
                    })
                .PrimaryKey(t => new { t.SiparisId, t.UrunId })
                .ForeignKey("dbo.Siparisler", t => t.SiparisId, cascadeDelete: true)
                .ForeignKey("dbo.Urunler", t => t.UrunId, cascadeDelete: true)
                .Index(t => t.SiparisId)
                .Index(t => t.UrunId);
            
            AddColumn("dbo.Siparisler", "AdresId", c => c.Int(nullable: false));
            AddColumn("dbo.Siparisler", "FirmaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Siparisler", "AdresId");
            CreateIndex("dbo.Siparisler", "FirmaId");
            AddForeignKey("dbo.Siparisler", "AdresId", "dbo.Adresler", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Siparisler", "FirmaId", "dbo.Firmas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.SiparisDetaylar", "UrunId", "dbo.Urunler");
            DropForeignKey("dbo.SiparisDetaylar", "SiparisId", "dbo.Siparisler");
            DropForeignKey("dbo.Siparisler", "FirmaId", "dbo.Firmas");
            DropForeignKey("dbo.Siparisler", "AdresId", "dbo.Adresler");
            DropIndex("dbo.SiparisDetaylar", new[] { "UrunId" });
            DropIndex("dbo.SiparisDetaylar", new[] { "SiparisId" });
            DropIndex("dbo.Siparisler", new[] { "FirmaId" });
            DropIndex("dbo.Siparisler", new[] { "AdresId" });
            DropColumn("dbo.Siparisler", "FirmaId");
            DropColumn("dbo.Siparisler", "AdresId");
            DropTable("dbo.SiparisDetaylar");
        }
    }
}
