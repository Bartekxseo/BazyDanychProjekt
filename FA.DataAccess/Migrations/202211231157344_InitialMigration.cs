namespace FA.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialMigration : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Dom",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        LicznikPraduNumber = c.Int(nullable: false),
                        LicznikWodyNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.LicznikPradu", t => t.LicznikPraduNumber)
                .ForeignKey("dbo.LicznikWody", t => t.LicznikWodyNumber)
                .Index(t => t.LicznikPraduNumber)
                .Index(t => t.LicznikWodyNumber);
            
            CreateTable(
                "dbo.LicznikPradu",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        LicznikNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.LicznikWody",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Value = c.Int(nullable: false),
                        LicznikNumber = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Dom", "LicznikWodyNumber", "dbo.LicznikWody");
            DropForeignKey("dbo.Dom", "LicznikPraduNumber", "dbo.LicznikPradu");
            DropIndex("dbo.Dom", new[] { "LicznikWodyNumber" });
            DropIndex("dbo.Dom", new[] { "LicznikPraduNumber" });
            DropTable("dbo.LicznikWody");
            DropTable("dbo.LicznikPradu");
            DropTable("dbo.Dom");
        }
    }
}
