[Tutorial Entity Framework - Code First Migrations](http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application)

1. Katalogi baz danych w których dokonujemy zmian
	* Modele do EF - folder `Models`
	* Przykładowe dane - plik `Migrations.Configuration.cs`
	* Schematy bazy danych - folder `Migrations`
2. Aktualziacja bazy danych na podstawie stworzonych schematów:
	1. Tools -> NuGet Package Manager -> Package Manager Console
	2. Komenda: update-database
	3. Sprawdzamy czy baza zosta³a stworzona:
		1. View -> Server Exploler
		2. Data Connections
		3. Powinan byæ stworzona baza CinemaContext
		4. W "Tables" sprawdzamy czy tabele wygl¹daj¹ tak jak chcieliœmy

