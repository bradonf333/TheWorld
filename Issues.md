# Issues

## These are issues I had creating this database.
I was following a tutorial on PluralSights and they were using the ef tool which I guess is no longer supported in VS 2017. 




### NuGet Package Manager
**Install Microsoft.EntityFrameworkCore.Tools**
**Install Microsoft.EntityFrameworkCore.SqlServer**

Can view [this](https://docs.microsoft.com/en-us/ef/core/miscellaneous/cli/powershell) link from Microsoft to see all the commands available.

### PM> Add-Migration
Name: InitialDatabase(can be whatever you want)

### PM> Scaffold-DbContext
This takes two parameters:

1 - ConnectionString

2 - Provider

**To get the ConnectionString:**
SQL Server Object Explorer>Right Click on (localdb)\MSSQLLocalDBxxxx>Properties>Copy Connection String
Provider = Microsoft.EntityFrameworkCore.SqlServer
Once this has been done you will get a couple new files that pop up. In the one that ends in xxContext.cs you can replace your connection string the config.json info if you put your connection string there.

Example command all in one line:
```console
Scaffold-DbContext 'Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=master;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=True;ApplicationIntent=ReadWrite;MultiSubnetFailover=False' Microsoft.EntityFrameworkCore.SqlServer
```
* After all this you need to still update the database to reflect the changes. To do this you need to:

### PM>Update-Database
In doing this I got an error saying there was more than 1 DbContext and I needed to specify which was the correct one. In the previous steps a new cs file was created called masterContext.cs. I looked in this class and it was pretty similar to the WorldContext.cs I already created. I removed this file and re-ran the command, this time it worked correctly.

### SideNote
When I did this it didn't create a new database but instead it just created the tables within the System Databases under the master db. I dropped the tables it created and then manually created a new Database within the SQL connection. The original connection string had something in it called "Initial Catalog= master" I replaced that with Database=myDB and re ran the above steps. 
When I ran the Scaffold it created another xxContext.cs that held the extra DbContext in it. I removed this again and re ran the Update-Database. This time working correctly.
