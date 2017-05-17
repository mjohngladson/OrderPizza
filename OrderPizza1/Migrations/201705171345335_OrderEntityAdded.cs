namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class OrderEntityAdded : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Orders",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DateCreated = c.DateTime(nullable: false),
                        Customer_Id = c.Int(),
                        Pizza_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Customers", t => t.Customer_Id)
                .ForeignKey("dbo.Pizzas", t => t.Pizza_Id)
                .Index(t => t.Customer_Id)
                .Index(t => t.Pizza_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "Pizza_Id", "dbo.Pizzas");
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "Pizza_Id" });
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropTable("dbo.Orders");
        }
    }
}
