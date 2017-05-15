namespace OrderPizza1.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class seedRoleUserData : DbMigration
    {
        public override void Up()
        {
            Sql("Insert into [AspNetUsers] values ('5aeef528-595c-48c9-813d-07a86876be44', 'mjohngladson@gmail.com', 0, 'ADzGcRPy4U+9AP+vduvdtTgzUma4e3brDVJwKux3e427aBUMs/Ybv5L2hhKtQ9dmdg==', '08e1337b-1160-42b0-beeb-48b2c1fb6bbb', NULL, 0, 0, NULL, 1, 0, 'mjohngladson@gmail.com')");
            Sql("Insert into [AspNetRoles] values ('37df3645-e01b-4ec0-8a6f-5f08106ee7ef', 'CanOrderPizza')");
            Sql("Insert into [AspNetUserRoles] values ('5aeef528-595c-48c9-813d-07a86876be44', '37df3645-e01b-4ec0-8a6f-5f08106ee7ef')");
        }
        
        public override void Down()
        {
            Sql("truncate table [OrderPizza1].[dbo].[AspNetUserRoles]");
            Sql("truncate table [OrderPizza1].[dbo].[AspNetRoles]");
            Sql("truncate table [OrderPizza1].[dbo].[AspNetUsers]");
        }
    }
}
