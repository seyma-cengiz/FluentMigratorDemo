using FluentMigrator.Runner;
using System.Reflection;

namespace FluentMigratorDemo
{
    public static class MigrationExtension
    {
        public static void AddFluentMigratorService(this IServiceCollection service)
        {
            service.AddFluentMigratorCore()
                   //for seeing logs in the console
                   .AddLogging(conf => conf.AddFluentMigratorConsole())
                   .ConfigureRunner(conf =>
                   {
                       conf.AddPostgres()
                           .WithGlobalConnectionString("Server=localhost;port=5432;Database=FluentMigratorDemo;User Id=postgres;Password=admin;Pooling=true;Maximum Pool Size=300;")
                           // defining which directory the FM would scan to run the classes
                           .ScanIn(Assembly.GetExecutingAssembly()).For.All();
                   });
        }

        public static void Migrate(this IApplicationBuilder app)
        {
            using (var scope = app.ApplicationServices.CreateScope())
            {
                var runner = scope.ServiceProvider.GetRequiredService<IMigrationRunner>();
                runner.MigrateUp();
            }
        }
    }
}
