using FluentMigrator;

namespace FluentMigratorDemo.Migrations
{
    [Migration(230311123512, "Category table created")]
    public class Migration_230311123512 : ForwardOnlyMigration
    {
        public override void Up()
        {
            Execute.Sql(@"CREATE TABLE public.""Categories"" 
                          (
                          	""Id"" uuid NOT NULL,
                          	""Name"" text NOT NULL,
                          	""Description"" text NULL,
                          	CONSTRAINT ""Categories_pkey"" PRIMARY KEY (""Id"")
                          );");
        }
    }
}