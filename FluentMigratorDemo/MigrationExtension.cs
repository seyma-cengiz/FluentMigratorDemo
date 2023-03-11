using FluentMigrator.Runner;
using System.Reflection;

namespace FluentMigratorDemo
{
    public static class MigrationExtension
    {
        public static void AddFluentMigratorService(this IServiceCollection service)
        {
            service.AddFluentMigratorCore()
                   .AddLogging(conf => conf.AddFluentMigratorConsole())
                   .ConfigureRunner(conf =>
                   {
                       conf.AddPostgres()
                           .WithGlobalConnectionString("{enter-connection-string}")
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
