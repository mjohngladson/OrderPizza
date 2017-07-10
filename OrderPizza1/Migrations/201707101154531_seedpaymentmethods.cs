using System.Web.UI.WebControls;

namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedpaymentmethods : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into PaymentMethods Values('Cash')");
            Sql("Insert into PaymentMethods Values('PayPal')");
        }
        
        public override void Down()
        {
            Sql("truncate table PaymentMethods");
        }
    }
}
