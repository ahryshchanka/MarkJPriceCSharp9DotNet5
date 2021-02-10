```bash
dotnet ef dbcontext scaffold "Filename=Northwind.db" Microsoft.EntityFrameworkCore.Sqlite --table Categories --table Products --output-dir AutoGenModels --namespace Packt.Shared.AutoGen --data-annotations --context Northwind
dotnet ef dbcontext scaffold "Filename=piranha.db" Microsoft.EntityFrameworkCore.Sqlite --output-dir Entities --context PiranhaContext --force
```