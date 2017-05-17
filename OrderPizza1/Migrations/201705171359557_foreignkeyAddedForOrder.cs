namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class foreignkeyAddedForOrder : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers");
            DropForeignKey("dbo.Orders", "Pizza_Id", "dbo.Pizzas");
            DropIndex("dbo.Orders", new[] { "Customer_Id" });
            DropIndex("dbo.Orders", new[] { "Pizza_Id" });
            RenameColumn(table: "dbo.Orders", name: "Customer_Id", newName: "CustomerId");
            RenameColumn(table: "dbo.Orders", name: "Pizza_Id", newName: "PizzaId");
            AlterColumn("dbo.Orders", "CustomerId", c => c.Int(nullable: false));
            AlterColumn("dbo.Orders", "PizzaId", c => c.Int(nullable: false));
            CreateIndex("dbo.Orders", "CustomerId");
            CreateIndex("dbo.Orders", "PizzaId");
            AddForeignKey("dbo.Orders", "CustomerId", "dbo.Customers", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Orders", "PizzaId", "dbo.Pizzas", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Orders", "PizzaId", "dbo.Pizzas");
            DropForeignKey("dbo.Orders", "CustomerId", "dbo.Customers");
            DropIndex("dbo.Orders", new[] { "PizzaId" });
            DropIndex("dbo.Orders", new[] { "CustomerId" });
            AlterColumn("dbo.Orders", "PizzaId", c => c.Int());
            AlterColumn("dbo.Orders", "CustomerId", c => c.Int());
            RenameColumn(table: "dbo.Orders", name: "PizzaId", newName: "Pizza_Id");
            RenameColumn(table: "dbo.Orders", name: "CustomerId", newName: "Customer_Id");
            CreateIndex("dbo.Orders", "Pizza_Id");
            CreateIndex("dbo.Orders", "Customer_Id");
            AddForeignKey("dbo.Orders", "Pizza_Id", "dbo.Pizzas", "Id");
            AddForeignKey("dbo.Orders", "Customer_Id", "dbo.Customers", "Id");
        }
    }
}
