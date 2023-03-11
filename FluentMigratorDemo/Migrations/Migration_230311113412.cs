using FluentMigrator;

namespace FluentMigratorDemo.Migrations
{
    //the id specified in attibute, must be unique and int64
    [Migration(230311113412)]
    public class Migration_230311113412 : Migration
    {
        public override void Down()
        {
            Delete.Table("Products");
        }

        public override void Up()
        {
            Create.Table("Products")
                  .WithColumn("Id").AsInt32().NotNullable().PrimaryKey().Identity()
                  .WithColumn("Name").AsString().NotNullable()
                  .WithColumn("Sku").AsFixedLengthString(10).NotNullable()
                  .WithColumn("Price").AsDecimal(18, 2).NotNullable()
                  .WithColumn("DiscountPercentage").AsInt32().Nullable();
        }
    }
}
