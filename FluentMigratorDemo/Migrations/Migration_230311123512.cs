using FluentMigrator;

namespace FluentMigratorDemo.Migrations
{
    //you can define a specific description
    [Migration(230311123512, "Category table created")]
    public class Migration_230311123512 : ForwardOnlyMigration // with ForwardOnlyMigration abstract class, you can override only Up method
    {
        public override void Up()
        {
            //for running a custom sql, you can choose Execute.Sql method 
            Execute.Sql(@"CREATE TABLE public.""Categories"" 
                          (
                          	""Id"" uuid NOT NULL,
                          	""Name"" text NOT NULL,
                          	""Description"" text NULL,
                          	CONSTRAINT ""Categories_pkey"" PRIMARY KEY (""Id"")
                          );");

            //for running embedded sql file, you can choose EmbeddedScript. don't forget to specify build action of file as Embedded resource from Properties.
            Execute.EmbeddedScript("FluentMigratorDemo.Scripts.InsertCategories.sql");
        }
    }
}