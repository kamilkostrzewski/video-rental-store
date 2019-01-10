namespace VideoRentalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class SetNameColumnNullable : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(maxLength: 50));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 50));
        }
    }
}
