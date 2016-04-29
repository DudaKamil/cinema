1. [Tutorial Entity Framework - Code First Migrations](http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application)
2. Katalogi baz danych w których dokonujemy zmian
	* Modele do EF - folder `Models`
	* Przykładowe dane - plik `Migrations.Configuration.cs`
	* Schematy bazy danych - folder `Migrations`
3. Aktualizacja bazy danych na podstawie stworzonych schematów:
	1. Tools -> NuGet Package Manager -> Package Manager Console
	2. Komenda: `Update-Database`
	3. Sprawdzamy czy baza została stworzona:
		1. View -> Server Exploler
		2. Data Connections
		3. Powinna zostać stworzona baza `CinemaContext`
		4. W `Tables` sprawdzamy czy tabele wglądają tak jak chcieliśmy
    4. W razie problemów ręcznie skasować wszystkie tabele w bazie przez `Server Explorer`
, a dopiero potem użyć komendy `Update-Database`
4. Tworznie nowej migracji:
	1. Tools -> NuGet Package Manager -> Package Manager Console
	2. Komenda: `Add-Migration NazwaMigracji`
    3. Nowa migracja stworzy się w folderze Migrations, `AktualnaData_Nazwa.cs`