WeddingPlatform
Assignment 3 – Identity, Security & Web API

WeddingPlatform är en ASP.NET Core MVC-applikation utvecklad som en bröllopsplattform där gäster kan registrera sig, svara på OSA, ta del av evenemangsinformation samt där administratörer kan hantera innehåll och statistik.

Projektet bygger vidare på Assignment 2 (MVC, Entity Framework Core och SQLite) och utökas i Assignment 3 med:

ASP.NET Core Identity
Authentication och Authorization
Rollen Admin och User
ViewModels
Web API
LINQ
Async/Await
Statistik och Dashboard


Tekniker
ASP.NET Core MVC
Entity Framework Core
SQLite
ASP.NET Core Identity
Bootstrap
LINQ
Asynchronous Programming (async/await)


Funktioner
Gästfunktioner

Användare kan:
Registrera sig
Logga in
Logga ut
Registrera gäster
Skicka OSA
Se evenemang
Se bröllopsinformation

Administrativa funktioner

Administratörer kan:
Hantera gäster
Ändra gäster
Ta bort gäster
Skapa evenemang
Ändra evenemang
Ta bort evenemang
Hantera bröllopsinformation
Hantera bilder
Se statistik i Admin Dashboard

Alla administrativa funktioner skyddas med:
[Authorize]
[Authorize(Roles = "Admin")]

Testkonton
Administratör

Email
admin@gmail.com

Lösenord
Admin1234@

Behörighet
Admin
Kan:
Se Admin Dashboard
Skapa evenemang
Ändra evenemang
Ta bort evenemang
Redigera gäster
Ta bort gäster
Hantera Wedding Information

Vanlig användare
Email
user@gmail.com

Lösenord
User1234@

Behörighet
User
Kan:
Logga in
Logga ut
Registrera gäster
Skicka OSA

Visa information
Kan inte:
Öppna Admin Dashboard
Ändra gäster
Ta bort gäster
Skapa evenemang
Ändra evenemang
Ta bort evenemang

Roller
Projektet använder två roller:
Admin
User

Rollerna skapas automatiskt vid programstart genom:
RoleManager<IdentityRole>
UserManager<ApplicationUser>

Identity
Projektet använder ASP.NET Core Identity för:

Registrering
Inloggning
Utloggning
Roller
Behörighetskontroll

Identity-tabeller skapas automatiskt i databasen:
AspNetUsers
AspNetRoles
AspNetUserRoles
AspNetUserClaims
AspNetRoleClaims
AspNetUserLogins
AspNetUserTokens
ViewModels

Projektet använder flera ViewModels för att separera presentation från datalager.

Exempel:
AdminDashboardViewModel
GuestCreateViewModel
GuestEditViewModel
RSVPViewModel
HomeViewModel
Databas

SQLite används som databas.

Databasfil:
Wedding.db

Huvudsakliga tabeller:
Guests
Events
WeddingInfos
WeddingImages

samt Identity-tabellerna.

Web API
Projektet innehåller flera API-endpoints som returnerar JSON-data.

Guests API
Hämta alla gäster
HTTP
GET /api/guestsapi

Exempel:

JSON
[
{
"name": "Anna Svensson",
"email": "anna@mail.se",
"willAttend": true,
"numberOfAttendants": 2
}
]

Hämta en specifik gäst
GET /api/guestsapi/{id}

Exempel:
GET /api/guestsapi/1

Events API
Hämta alla evenemang
GET /api/eventsapi

Hämta ett specifikt evenemang
GET /api/eventsapi/{id}
Exempel:
GET /api/eventsapi/1

Statistics API
Hämta statistik
GET /api/statisticsapi
Exempel:
JSON
{
"totalGuests": 25,
"attendingGuests": 18,
"notAttendingGuests": 4,
"attendancePercentage": 72
}

LINQ
Projektet använder LINQ för:
Filtrering
Sortering
Statistik
API-frågor
Exempel:
.Where(g => g.WillAttend == true)
.OrderBy(e => e.EventDate)
.Select(g => new
{
g.Name,
g.Email
})
C#
.CountAsync()
.SumAsync()

Säkerhet
Projektet använder:
Authentication
app.UseAuthentication();
Authorization
app.UseAuthorization();
Rollbaserad säkerhet
[Authorize(Roles = "Admin")]

Administrativa funktioner skyddas både i controllers och i användargränssnittet genom att dölja administrativa knappar för vanliga användare.

Starta projektet
Öppna lösningen i Visual Studio.
Kör migrationer:
PowerShell
Update-Database
Starta projektet:
HTTPS
Logga in med något av testkontona.
