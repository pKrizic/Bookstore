<Query Kind="Program">
  <Connection>
    <ID>d70d9296-369f-4354-b1cc-e013d54fb2d0</ID>
    <Persist>true</Persist>
    <Server>localhost\SQLEXPRESS</Server>
    <Database>rhetos_test_pk</Database>
    <ShowServer>true</ShowServer>
  </Connection>
  <Reference Relative="..\bin\Autofac.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Autofac.dll</Reference>
  <Reference Relative="..\bin\EntityFramework.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\EntityFramework.dll</Reference>
  <Reference Relative="..\bin\EntityFramework.SqlServer.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\EntityFramework.SqlServer.dll</Reference>
  <Reference Relative="..\bin\Bookstore.Service.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Bookstore.Service.dll</Reference>
  <Reference>..\bin\Generated\ServerDom.Orm.dll</Reference>
  <Reference>..\bin\Generated\ServerDom.Repositories.dll</Reference>
  <Reference Relative="..\bin\NLog.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\NLog.dll</Reference>
  <Reference Relative="..\bin\Oracle.ManagedDataAccess.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Oracle.ManagedDataAccess.dll</Reference>
  <Reference>..\bin\Rhetos.AspNetFormsAuth.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dom.DefaultConcepts.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Dom.DefaultConcepts.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dom.DefaultConcepts.Interfaces.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Dom.DefaultConcepts.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dsl.DefaultConcepts.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Dsl.DefaultConcepts.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Processing.DefaultCommands.Interfaces.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Processing.DefaultCommands.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Configuration.Autofac.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Configuration.Autofac.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dom.Interfaces.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Dom.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Dsl.Interfaces.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Dsl.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Interfaces.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Logging.Interfaces.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Logging.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Persistence.Interfaces.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Persistence.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Processing.Interfaces.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Processing.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Security.Interfaces.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Security.Interfaces.dll</Reference>
  <Reference Relative="..\bin\Rhetos.TestCommon.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.TestCommon.dll</Reference>
  <Reference Relative="..\bin\Rhetos.Utilities.dll">C:\Users\pkrizic\source\repos\Bookstore\Bookstore.Service\bin\Rhetos.Utilities.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.AccountManagement.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.DirectoryServices.dll</Reference>
  <Reference>&lt;RuntimeDirectory&gt;\System.Runtime.Serialization.dll</Reference>
  <Namespace>Oracle.ManagedDataAccess.Client</Namespace>
  <Namespace>Rhetos.Configuration.Autofac</Namespace>
  <Namespace>Rhetos.Dom</Namespace>
  <Namespace>Rhetos.Dom.DefaultConcepts</Namespace>
  <Namespace>Rhetos.Dsl</Namespace>
  <Namespace>Rhetos.Dsl.DefaultConcepts</Namespace>
  <Namespace>Rhetos.Logging</Namespace>
  <Namespace>Rhetos.Persistence</Namespace>
  <Namespace>Rhetos.Security</Namespace>
  <Namespace>Rhetos.Utilities</Namespace>
  <Namespace>System</Namespace>
  <Namespace>System.Collections.Generic</Namespace>
  <Namespace>System.Data.Entity</Namespace>
  <Namespace>System.DirectoryServices</Namespace>
  <Namespace>System.DirectoryServices.AccountManagement</Namespace>
  <Namespace>System.IO</Namespace>
  <Namespace>System.Linq</Namespace>
  <Namespace>System.Reflection</Namespace>
  <Namespace>System.Runtime.Serialization.Json</Namespace>
  <Namespace>System.Text</Namespace>
  <Namespace>System.Xml</Namespace>
  <Namespace>System.Xml.Serialization</Namespace>
  <Namespace>Autofac</Namespace>
  <Namespace>Rhetos.TestCommon</Namespace>
  <Namespace>Rhetos</Namespace>
</Query>

void Main()
{
	string applicationFolder = Path.GetDirectoryName(Util.CurrentQueryPath);
	ConsoleLogger.MinLevel = EventType.Info; // Use EventType.Trace for more detailed log.
	
	using (var scope = ProcessContainer.CreateScope(applicationFolder))
    {
        var context = scope.Resolve<Common.ExecutionContext>();
        var repository = context.Repository;

		// <<<< Copy-paste the example code here >>>>
		var allBooks = repository.Bookstore.Book.Load();
		allBooks.Dump();
		
		var query = repository.Bookstore.Book
			.Query()
			.Select(b => new { b.Title, b.Author.Name })
			.Dump();	

		query.ToString().Dump("Generated SQL (query)");

		var actionParameter = new Bookstore.InsertManyBooks
		{
			NumberOfBooks = 7,
			TitlePrefix = "A Song of Ice and Fire"
		};
		repository.Bookstore.InsertManyBooks.Execute(actionParameter);

		scope.CommitAndClose();
		//scope.CommitChanges(); // Database transaction is rolled back by default.
	}
}