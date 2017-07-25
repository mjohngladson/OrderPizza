namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class modelPizzaToppingAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.PizzaToppings",
                c => new
                    {
                        Pizza = c.Int(nullable: false),
                        Topping = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Pizza, t.Topping });
            
        }
        
        public override void Down()
        {
            DropTable("dbo.PizzaToppings");
        }
    }
}
