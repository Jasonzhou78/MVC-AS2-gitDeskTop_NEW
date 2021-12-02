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


2021-11-20
2200
--Check the folder in the ZhijunsBook in local computer, compared with the folder in the vs studio is different. There is a file called iunitofwork in the folder
in the local , but no such file in the visual studio 2019. and the interface has accessibility of internal. I deleted this file, and every error gone.

20211122
1431
--the dropdown menu still does not work. Go back to check link files (css files and js files)
--temporarily skip the dropdown menu
1510
--add partial view files called _CreateAndBackToListButton.cshtml and _EditAndBackToListButton.cshtml
--modify code in both files
--modify code in the Upsert.cshtml file


20211125
18:00
--continue to modify file CategoryController.cs
--after added delete method and other modification, there is an error:
   end region expected in the file (last curly brace shows an error), but the file seems the same as
   the teacher's work
--built, failed

1906 modify file category.js
--add function(Delete) and two method for error or success message
--built, two errors, one is from the last step
--one error was excluded by delete an extra void save() function in the file IUnitOfWork.cs
--rebuilt, still one error thus failed.
--commit and push to github

20211130
1300 updating local files by clone github files
--updating files by committing changes
--

1320 start working the section 1 part 3
--add a new class Product.cs in the Model folder
--update the file with given codes
--update codes in the file ApplicationDbContext.cs under the folder .DataAccess
--add CoverType.cs under the folder .Model, the codes are very similar to Category.cs except name
is different and replace Category with CoverType
--add CoverType.cs, CoverTypeRepository, ICoverTypeRepository.cs files
--updated these files
--updated UnitOfWork.cs, but there is an error under the type(or variable) CoverType
--the error is gone when public ICoverTypeRepository CoverType { get; private set; } was added
--update the IUnitofWork file by adding a property of CoverType
--migration and update, but I chose the default folder (ZhijunsBook) by mistake
--did not commit the change, I exited the program without saving, deleted the local
files,
--double check CoverType file and related files
--reclone from github, redo migration and update the database under the project of 
ZhijunsBook.DataAccess
--innitiate the nuget manage console
-- Add-Migration InitialCreate, succeeded
--Update-Database, failed, it says object CoverType existed
--check tables, there are two tables added in the database(CoverType, and Product)
--20211130202853_InitialCreate.cs in the Migration folder produced
--commit the changes and push to github.com, save changes.
--built it, succeeded.

1840 redo the dropmenu
--update _layout.cshtml file, the dropdow menu works now.
--update the product class title, isbn, and author to required
--rebuild, succeeded
--Add-Migration InitialCreate, remind that there is a _InitialCreate.Designer.cs existed
--delete the migration file,
--Add-Migration InitialCreate, succeeded
--Update-Database, succeeded
--check Product.db in SQL explorer, the field title, author, and ISBN have been changed to not null
--rebuild the app, succeeded
--commit the changes and push to github

2015 work on the Product, IProductRepository, etc
--Add Product to the Repository. I don't understand where the file should be added thus it is skipped
--IProductRepository was added and the codes were updated according to ICategoryRepository.cs
--ProductRepository class was added and codes were modified according to teachers code.
--open UnitOfWork.cs file,add line21 (Product = new ProductRepository(_db);) and line26(public IProductRepository Product { get; private set; })
--open IUnitOfWork.cs file, add IProductRepository Product { get; }
--save it, build it, succeeded.
--commit and push to github

2030 start working on part 3 section 2 (3.2 Product CRUD(2))
--add CoverTypeController.cs in Area/Admin/Controllers, and modified the file according to 
CategoryController.cs
--add ProductController.cs according to lecture
--add a ProductVM.cs file under .Models/ViewModels
--save and build successfully, commit and push to github

2115 work on ProductController.cs
--open the file.
--modify the codes in the ProductController.cs
--build it, succeeded
--comment out the Upsert method and rebuilt,succeeded.
--appended region section to the end of ProductController.cs
--rebuilt the app, succeeded.

2318
--add new js files (CoverType and Product by copy category.js) under wwwroot/js folder and made changes
--add product link in the _layout.cshtml
--build it, succeeded. Save it, commit and push to github

2355
--create CoverType folder, Product folder in the view folder, and index.cshtml to it.
--add Upsert.cshtml to Product folder in Views and modify the file according lecture slides
(copy code from FILES and added the rest of code from slides)
--Built it, succeeded, commit it, push to github

0015 Finishing the section 3 of part 3
--come back to ProductController.cs
--modify it, rebuild, succeeded
--
20211201
2100  comparing with standard file
--comparing











