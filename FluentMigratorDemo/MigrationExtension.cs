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
                           .WithGlobalConnectionString("{connection-string}")
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
