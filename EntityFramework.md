1. [Tutorial Entity Framework - Code First Migrations](http://www.asp.net/mvc/overview/getting-started/getting-started-with-ef-using-mvc/migrations-and-deployment-with-the-entity-framework-in-an-asp-net-mvc-application)
2. Katalogi baz danych w których dokonujemy zmian
	* Modele do EF - folder `Models`
	* Przykładowe dane - plik `Migrations.Configuration.cs`
3. Aktualizacja bazy danych na podstawie stworzonych schematów:
	1. Zmiany danych w `Migrations.Configuration.cs`
    2. Zmiany schematów w pliku `Migrations.201604291502373_InitialMigration.cs`
    3. Podczas uruchamianai aplikacji wszystko zostać automatycznie zmienione
4. Ręczne zarządzanie i sprawdzanie bazy danych
    1. `View` -> `SQL Server Object Explorer`, a NIE `Server explorer`!
    2. `(localdb)\typ_bazy`
    3. `Databases` -> nasza baza danych
5. Gdyby coś nie działało, a pewnie nie będzie działać to:
    1. Ręcznie skasować bazę przez `SQL Server Object Explorer`
        1. `View` -> `SQL Server Object Explorer`, a NIE `Server explorer`!
        2. `(localdb)\typ_bazy`
        3. `Databases` -> nasza baza danych
        4. Kasujemy bazę
        5. Zaznaczyć opcję `Close existing connections`
    2. W NuGet Package Manager console wpisujemy:
        1. `Updata-Database` - stawia wtedy schemat bazy danych (tabele)
        2. `Updata-Database` - drugi raz to samo polecenie, zapelnia wtedy bazę danymi