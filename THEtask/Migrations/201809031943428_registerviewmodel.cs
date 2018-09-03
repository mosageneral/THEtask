namespace THEtask.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class registerviewmodel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Medical_Profile",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Weight = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Height = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Goal_of_diet = c.String(),
                        Exercise_Time = c.Int(nullable: false),
                        Leve_of_Exercise = c.String(),
                        Daily_Food = c.String(),
                        Vitamins = c.String(),
                        Problem_History = c.String(),
                        User = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Medical_Profile");
        }
    }
}
