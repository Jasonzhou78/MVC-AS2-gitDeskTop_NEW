20211115
1810
--updated visual studio 2019
--create the project ZhijunsBooks, and store in ASP.NET folder
--delete options => options.SignIn.RequireConfirmedAccount = true in Startup.cs

2200
--replace bootstrap.css and site.css
--made changes to navbar and text color
--made a dropdown navbar, all codes same as the slide, but submenu does not show up
--in case text has the same color as background, i changed text color to white, still not show.
2250
--add three .net core class library. ZhijunsBooks.DataAccess, ZhijunsBooks.Models, and ZhijunsBooks.Utility
--save the version as ZhijunsBooks-v2-threeProjectsAdded

2309
--copy Data from ZhijunsBooks to ZhijunsBooks.DataAccess
--try to install relational and sql server, default method will fail
--command -version 5.0.11 will do or toos/Nuget Package Manager/manage nuget package for solution
--delete Migration in .DataAccess project, save this version.


20211116
0012
--Install-Package Microsoft.AspNetCore.Identity.EntityFrameworkCore -Version 5.0.11, succeeded.
--deleted class1.cs in other three classes
--move Models in to ZhijunsBooks.Models and delete the original one
--right click ZhijunsBooks project, add->project reference, check .DataAccess and .Models
--Rename Models folder to ViewModels
--Change namespace in ErrorViewModels.cs to Models.ViewModel.
--change using statement from ZhijunsBooks.Data to ZhijunsBooks.DataAccess.Data
--built the projects, succeeded.Save a new version

1257
--change ZhijunsBooks project file Error.cshtml, to @Model ZhijunsBooks.Models.ViewModels.ErrorViewModel
--in ZhijunsBooks.Models, change namespace to ZhijunsBooks.Models.ViewModels for file
ErrorViewModels.cs
--built it, succeeded. save to a new version

1303 work on Utility
--create a static details class called SD.cs
--add project reference to the main project
--in the DataAccess project add project references to Models and Utility

1322 P37

--add Customer area to Area
--change the route in Startup.cs: 
pattern: "{area=Customer}/{controller=Home}/{action=Index}/{id?}")
--move the HomeController.cs to Area/Customer/Controllers
--delete the folder Models (slide asks to delete Data too, but it has been delete earlier)
--add [Area("Customer")] just below namespace in the file Homecontroller.cs
--add a using statement ZhijunsBooks.Models.ViewModels
--modify namespace of the homecontroller
--move View/Home to Area/Customer/Views
--built the app, succeeded.

1354 P38
--copy(not move!) the _viewimport and _viewstart to customer area/view

1629 P39
--added admin area in areas
--deleted controllers
--slide asks for delete Data and Models, but they are deleted.
--built and displayed it, succeeded.

1739 starting working with part 2
--built the project to make sure it is working properly, succeeded
--change the Database=ZhijunsBooks in the appsettings.json
--migrate the database using add-migration AddDefaultIdentityMigration
--migration name: 20211116224211_AddDefaultIdentityMigration

1744 update the database
--update-database
--check the tables under ZhijunsBooks in View/SQL Server Object Explorer
--run the application, succeeded. but the database is not shown yet.
--create a Category model under ZhijunsBooks.Models
--update the class contents
--add the migration via add-migration AddCategoryToDb as the command
with a name 20211116230631_AddCategoryToDb in ZhijunsBooks.DataAccess
--modify applicationDbContext file
--run the command add-migration AddCategoryToDb
--error message says an existing file
--delete 20211116230631_AddCategoryToDb.cs file and re-run the command
--succeeded

1910 work with category
--create a categor and added to	ApplicationDbContext
--add a new folder Repositor
--in it, add a folder IRepository
--add a new item of type interface to IRepository
--modify its contents
--built, succeeded, save as a new version
1945
--create a new repository
--modify code refer to assignment 2 folder
--built it, succeeded, save as a new version

2000 work on page 9

--modify categoryRepository and ICategoryRepository
--for file CategoryRepository, the Categories should be Category. I modified this word.

2052 work on page 10
--added a new file called ISP_Calls
--modified its codes
--built it, succeeded, save a new version.

2140 work on page 11

--add a SP_Call.cs file in Repository
--modify its contents
--error on  using (SqlConnection sqlCon = new SqlConnection(ConnectionString)), warning on 
SqlConnection, added using Microsoft.Data.SqlClient to resolve the problem;

2246 work on page 12

--create a file under IRepository folder called IUnitOfWork
--modify codes

2330

--added categorycontroller to controller in zhijunsbooks
--modify codes of the file
--there are two errors regarding inconsistence of accessibility of CategoryController and 
IUnitOfWork files, and IUnitOfWork does not contain Category

0000
--change the index.cshtml








