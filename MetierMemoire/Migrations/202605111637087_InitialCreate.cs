namespace MetierMemoire.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Memoires", "AnneeMemoire", c => c.Int(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Memoires", "AnneeMemoire", c => c.String(nullable: false, unicode: false));
        }
    }
}
