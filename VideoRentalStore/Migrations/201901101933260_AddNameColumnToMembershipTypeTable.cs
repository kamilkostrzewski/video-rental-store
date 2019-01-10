namespace VideoRentalStore.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddNameColumnToMembershipTypeTable : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.MembershipTypes", "Name", c => c.String(nullable: false, maxLength: 50));
        }
        
        public override void Down()
        {
            DropColumn("dbo.MembershipTypes", "Name");
        }
    }
}
