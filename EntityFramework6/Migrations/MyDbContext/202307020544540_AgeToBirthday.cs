//Add-Migration AgeToBirthday -COnfigurationTypeName EntityFramework6.Migrations.MyDbContext.Configuration
namespace EntityFramework6.Migrations.MyDbContext
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AgeToBirthday : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.student", "birthday", c => c.String(nullable: false, maxLength: 8));
            DropColumn("dbo.student", "age");
        }
        
        public override void Down()
        {
            AddColumn("dbo.student", "age", c => c.Int(nullable: false));
            DropColumn("dbo.student", "birthday");
        }
    }
}
//Update-Database