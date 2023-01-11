namespace BD.DataAccess.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class refactoring : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Dom", "LicznikPraduNumber", "dbo.LicznikPradu");
            DropForeignKey("dbo.Dom", "LicznikWodyNumber", "dbo.LicznikWody");
            DropIndex("dbo.Dom", new[] { "LicznikPraduNumber" });
            DropIndex("dbo.Dom", new[] { "LicznikWodyNumber" });
            AddColumn("dbo.LicznikPradu", "DomId", c => c.Int(nullable: false));
            AddColumn("dbo.LicznikWody", "DomId", c => c.Int(nullable: false));
            CreateIndex("dbo.LicznikPradu", "DomId");
            CreateIndex("dbo.LicznikWody", "DomId");
            AddForeignKey("dbo.LicznikPradu", "DomId", "dbo.Dom", "Id");
            AddForeignKey("dbo.LicznikWody", "DomId", "dbo.Dom", "Id");
            DropColumn("dbo.Dom", "LicznikPraduNumber");
            DropColumn("dbo.Dom", "LicznikWodyNumber");
            DropColumn("dbo.LicznikPradu", "LicznikNumber");
            DropColumn("dbo.LicznikWody", "LicznikNumber");
        }
        
        public override void Down()
        {
            AddColumn("dbo.LicznikWody", "LicznikNumber", c => c.Int(nullable: false));
            AddColumn("dbo.LicznikPradu", "LicznikNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Dom", "LicznikWodyNumber", c => c.Int(nullable: false));
            AddColumn("dbo.Dom", "LicznikPraduNumber", c => c.Int(nullable: false));
            DropForeignKey("dbo.LicznikWody", "DomId", "dbo.Dom");
            DropForeignKey("dbo.LicznikPradu", "DomId", "dbo.Dom");
            DropIndex("dbo.LicznikWody", new[] { "DomId" });
            DropIndex("dbo.LicznikPradu", new[] { "DomId" });
            DropColumn("dbo.LicznikWody", "DomId");
            DropColumn("dbo.LicznikPradu", "DomId");
            CreateIndex("dbo.Dom", "LicznikWodyNumber");
            CreateIndex("dbo.Dom", "LicznikPraduNumber");
            AddForeignKey("dbo.Dom", "LicznikWodyNumber", "dbo.LicznikWody", "Id");
            AddForeignKey("dbo.Dom", "LicznikPraduNumber", "dbo.LicznikPradu", "Id");
        }
    }
}
