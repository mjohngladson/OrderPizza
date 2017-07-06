namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;

    public partial class _201705151326481_seedPizzaAttributes : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into PizzaAttributes Values('Size', 'Small', 1, 12, 12)");
            Sql("Insert into PizzaAttributes Values('Size', 'Medium', 0, 14, 14)");
            Sql("Insert into PizzaAttributes Values('Size', 'Large', 0, 16, 16)");
            Sql("Insert into PizzaAttributes Values('Crust', 'Regular', 1, null, null)");
            Sql("Insert into PizzaAttributes Values('Crust', 'Thin', 0, null, null)");
            Sql("Insert into PizzaAttributes Values('Crust', 'Thick', 0, 2, null)");
            Sql("Insert into PizzaAttributes Values('Toppings', 'Sausage', 1, 2, null)");
            Sql("Insert into PizzaAttributes Values('Toppings', 'Pepperoni', 0, 1.5, null)");
            Sql("Insert into PizzaAttributes Values('Toppings', 'Onions', 0, 1, null)");
            Sql("Insert into PizzaAttributes Values('Toppings', 'Green Peppers', 0, 1, null)");
        }

        public override void Down()
        {
            Sql("Truncate table PizzaAttributes");
        }
    }
}
