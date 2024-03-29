﻿namespace CodeFirstFrameworkSansAssistantV2.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migra1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nom = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Produits",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Designation = c.String(),
                        CategorieId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Categories", t => t.CategorieId, cascadeDelete: true)
                .Index(t => t.CategorieId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Produits", "CategorieId", "dbo.Categories");
            DropIndex("dbo.Produits", new[] { "CategorieId" });
            DropTable("dbo.Produits");
            DropTable("dbo.Categories");
        }
    }
}
