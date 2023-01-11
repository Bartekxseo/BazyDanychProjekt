# Backend

## Uruchomienie

### Wymagania wstępne:
* Baza danych SQL (dowolna wersja)
* VisualStudio 

### Pierwsze uruchomienie
W celu uruchomienia aplikacji należy:
* Przywrócić pakiety NuGet
* Utworzyć bazę danych
* Podmienić adres bazy danych w FaDbContextFactory.cs oraz appsettings.json
* Zaaplikować migracje (Package Manager Console -> BD.DataAcces -> Wpisać "Update-database")
* Wybrać BD.RestApi jako projekt startowy
* Uruchomić
