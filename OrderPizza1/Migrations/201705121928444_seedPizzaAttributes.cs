namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedPizzaAttributes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into PizzaAttributes Values('Size', 'Small', 1)");
            Sql("Insert into PizzaAttributes Values('Size', 'Medium', 0)");
            Sql("Insert into PizzaAttributes Values('Size', 'Large', 0)");
            Sql("Insert into PizzaAttributes Values('Crust', 'Regular', 1)");
            Sql("Insert into PizzaAttributes Values('Crust', 'Thin', 0)");
            Sql("Insert into PizzaAttributes Values('Crust', 'Thick', 0)");
            Sql("Insert into PizzaAttributes Values('Toppings', 'Sausage', 1)");
            Sql("Insert into PizzaAttributes Values('Toppings', 'Pepperoni', 0)");
            Sql("Insert into PizzaAttributes Values('Toppings', 'Onions', 0)");
            Sql("Insert into PizzaAttributes Values('Toppings', 'Green Peppers', 0)");
        }
        
        public override void Down()
        {
            Sql("truncate table PizzaAttributes");
        }
    }
}
