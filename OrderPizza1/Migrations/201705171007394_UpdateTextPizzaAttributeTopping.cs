namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class UpdateTextPizzaAttributeTopping : DbMigration
    {
        public override void Up()
        {
            Sql("Update PizzaAttributes set Name = 'Topping' where Name = 'Toppings'");
        }
        
        public override void Down()
        {
            Sql("Update PizzaAttributes set Name = 'Toppings' where Name = 'Topping'");
        }
    }
}
