namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class _201705171410246_DataTypeChangedforPizzaTopping1 : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Pizzas", "Topping", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Pizzas", "Topping");
        }
    }
}
