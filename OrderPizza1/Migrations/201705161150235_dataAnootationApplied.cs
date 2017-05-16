namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class dataAnootationApplied : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Customers", "Name", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Address", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Zip", c => c.String(nullable: false));
            AlterColumn("dbo.Customers", "Phone", c => c.String(nullable: false));
            AlterColumn("dbo.Pizzas", "Size", c => c.String(nullable: false));
            AlterColumn("dbo.Pizzas", "Crust", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pizzas", "Crust", c => c.String());
            AlterColumn("dbo.Pizzas", "Size", c => c.String());
            AlterColumn("dbo.Customers", "Phone", c => c.String());
            AlterColumn("dbo.Customers", "Zip", c => c.String());
            AlterColumn("dbo.Customers", "Address", c => c.String());
            AlterColumn("dbo.Customers", "Name", c => c.String());
        }
    }
}
