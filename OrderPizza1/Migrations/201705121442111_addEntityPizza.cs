namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addEntityPizza : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Pizzas",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Size = c.String(),
                        Crust = c.String(),
                        Toppings = c.String(),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropTable("dbo.Pizzas");
        }
    }
}
