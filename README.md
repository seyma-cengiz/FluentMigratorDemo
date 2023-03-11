<h2>Fluent Migrator Demo</h2>
<h3>Basics</h3>

  FluentMigrator is a database migration framework for .Net Framework and .Net Core and great tool for deploying and making revisions to a database. It supports many of databases like SqlServer, Postgres, SQLite, Oracle, MySql, FireBird etc.
  
  Required Nuget packages for implementation:

- FluentMigrator 
- FluentMigrator.Runner
- FluentMigrator.Runner.Postgres (can change depends on the project)
- Npgsql (can change depends on the project)

<h3>Implementation</h3>

The basic unit of FM is the Migration abstract class. Your migrations will derive from this class and implement two methods. You also need to define the Migration attribute with a unique identifier.

Commonly, this identifier is just an incrementing value, although the attribute accepts an Int64, some people use a numbered date format such as yyyyMMdd. The significance of this number is for the ordering of your migrations. Lower numbers execute first and then larger. It also provides a way to target a specific migration. Your migration class that you create is where you define the migrations to execute.

After adding and configuring the FluentMigratorCore service, you can realize on MigrateUp() method the VersionInfo table is created in the database if it's not created before. 

<img src="https://github.com/seyma-cengiz/FluentMigratorDemo/blob/master/FluentMigratorDemo/src/version-info-table.png" height="100"/>
<img src="https://github.com/seyma-cengiz/FluentMigratorDemo/blob/master/FluentMigratorDemo/src/version-info-create.png" height="350"/>

Then it's gonna start to scan classes and choose the classes which is not runned yet by checking incrementally specified id. You can also watch it in the console all this steps.

<img src="https://github.com/seyma-cengiz/FluentMigratorDemo/blob/master/FluentMigratorDemo/src/migration.png" height="500"/>

The VersionInfo table is the table which holds the information of the runned classes.

<b>Version:</b> refers to unique Id that specified in [Migration("{id}")] attribute for each classes.
<br><b>AppliedOn:</b> holds the timestamp when the class was run.
<br><b>Description</b> keeps the description info specified in [Migration("{id}, {description}")] attribute. if it's not defined it'll be written class name as default.

<img src="https://github.com/seyma-cengiz/FluentMigratorDemo/blob/master/FluentMigratorDemo/src/version-info-data.png" height="80"/>
