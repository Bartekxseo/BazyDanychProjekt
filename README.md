# Backend

## Uruchomienie

### Wymagania wstêpne:
* Baza danych SQL (dowolna wersja)
* VisualStudio 

### Pierwsze uruchomienie
W celu uruchomienia aplikacji nale¿y:
* Przywróciæ pakiety NuGet
* Utworzyæ bazê danych
* Podmieniæ adres bazy danych w FaDbContextFactory.cs oraz appsettings.json
* Zaaplikowaæ migracje (Package Manager Console -> FA.DataAcces -> Wpisaæ "Update-database")
* Wybraæ FA.RestApi jako projekt startowy
* Uruchomiæ

---

### Zmiany Punkt Kontrolny 1
#### Utworzenie Infrastruktury:
* Projekt FA.RestApi
* Projekt FA.Domain
* Projekt FA.DataAccess
* Projekt FA.Services
#### Przygotowanie Entity Framework - Prace w FA.Domain oraz FA. DataAccess
#### Przygotowanie RestApi - Prace w FA.RestApi
#### Utworzenie bazy danych

---

### Zmiany Punkt Kontrolny 2
#### Utworzenie pustych kontrolerów w celu przygotowania integracji z FrontEndem - FA.RestApi/Controllers
#### Przygotowanie Dependency Injection 
#### Wystawienie pliku swagger