namespace ExemploAjax.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Hoteis",
                c => new
                    {
                        HotelId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                    })
                .PrimaryKey(t => t.HotelId);
            
            CreateTable(
                "dbo.Quartos",
                c => new
                    {
                        QuartoId = c.Int(nullable: false, identity: true),
                        Nome = c.String(),
                        HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.QuartoId)
                .ForeignKey("dbo.Hoteis", t => t.HotelId, cascadeDelete: true)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.Temporadas",
                c => new
                    {
                        TemporadaId = c.Int(nullable: false, identity: true),
                        NomeTemporada = c.String(),
                        Chegada = c.DateTime(nullable: false),
                        Saida = c.DateTime(nullable: false),
                        DiariaForaTemporada = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiariaTemporada = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiariaSabado = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiariaSemana = c.Decimal(nullable: false, precision: 18, scale: 2),
                        DiariaMes = c.Decimal(nullable: false, precision: 18, scale: 2),
                        QuartoId = c.Int(nullable: false),
                        HotelId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.TemporadaId)
                .ForeignKey("dbo.Hoteis", t => t.HotelId, cascadeDelete: true)
                .ForeignKey("dbo.Quartos", t => t.QuartoId, cascadeDelete: false)
                .Index(t => t.QuartoId)
                .Index(t => t.HotelId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Temporadas", "QuartoId", "dbo.Quartos");
            DropForeignKey("dbo.Temporadas", "HotelId", "dbo.Hoteis");
            DropForeignKey("dbo.Quartos", "HotelId", "dbo.Hoteis");
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Temporadas", new[] { "HotelId" });
            DropIndex("dbo.Temporadas", new[] { "QuartoId" });
            DropIndex("dbo.Quartos", new[] { "HotelId" });
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Temporadas");
            DropTable("dbo.Quartos");
            DropTable("dbo.Hoteis");
        }
    }
}
