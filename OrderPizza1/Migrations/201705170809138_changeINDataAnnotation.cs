namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class changeINDataAnnotation : DbMigration
    {
        public override void Up()
        {
            AlterColumn("dbo.Pizzas", "Size", c => c.String());
            AlterColumn("dbo.Pizzas", "Crust", c => c.String());
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Pizzas", "Crust", c => c.String(nullable: false));
            AlterColumn("dbo.Pizzas", "Size", c => c.String(nullable: false));
        }
    }
}
