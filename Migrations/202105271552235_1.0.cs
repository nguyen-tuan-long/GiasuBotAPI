namespace GiasuBotAPI.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _10 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Lop1",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop10",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop11",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop12",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop2",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop3",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop4",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop5",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop6",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop7",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop8",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
            CreateTable(
                "dbo.Lop9",
                c => new
                    {
                        SubjectId = c.Int(nullable: false, identity: true),
                        Subject = c.String(),
                        Tenbai = c.String(),
                        Bailam = c.String(),
                    })
                .PrimaryKey(t => t.SubjectId);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Lop9");
            DropTable("dbo.Lop8");
            DropTable("dbo.Lop7");
            DropTable("dbo.Lop6");
            DropTable("dbo.Lop5");
            DropTable("dbo.Lop4");
            DropTable("dbo.Lop3");
            DropTable("dbo.Lop2");
            DropTable("dbo.Lop12");
            DropTable("dbo.Lop11");
            DropTable("dbo.Lop10");
            DropTable("dbo.Lop1");
        }
    }
}
