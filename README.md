# Album management applicatie

Logs:
Het project moet bestaan uit een Blazor frontend en ASP.NET Api backend. Hierbij moet gebruik gemaakt worden van EntityFramework Core en voor versiebeheer wordt Git gebruikt.

Opzet applicatie:
Het opzetten van de applicatie is gedaan in Visual Studio 2022, hierbij is een nieuw project aangemaakt. Bij het opzetten van de applicatie is gekozen voor de Blazor Web App configuratie. Hierbij is gekozen voor een server en client verdeling. Dit om functionaliteiten te kunnen scheiden tussen beide omgevingen indien nodig.

Er is een lokale database aangemaakt. Deze database is verbonden door middel van een ConnectionString in appsettings.json en er wordt een DbContext aangemaakt om te kunnen communiceren met de database.

Hierna is met de onderstaande queries een tabel aangemaakt om albums op te slaan met minimale veriabelen om de applicatie redelijk simpel te houden. Dit wordt gedaan in SSMS. Op deze manier kan ik zeker weten welke data er in de database staat, zonder de mogelijkheid dat de code iets niet juist teruggeeft.

```
CREATE TABLE Albums
(
Id int IDENTITY(1,1) PRIMARY KEY,
Artist varchar(255) NOT NULL,
AlbumName varchar(255),
Songs varchar(MAX),
ReleaseDate DateTime
);

INSERT INTO Albums (AlbumName, Artist, Songs, ReleaseDate) 
VALUES 
    ('Abbey Road', 'The Beatles', '["Come Together", "Something", "Maxwells Silver Hammer"]', '1969-09-26'),
    ('Back in Black', 'AC/DC', '["Hells Bells", "Shoot to Thrill", "Back in Black"]', '1980-07-25'),
    ('The Dark Side of the Moon', 'Pink Floyd', '["Speak to Me", "Breathe", "Time"]', '1973-03-01'),
    ('Hotel California', 'Eagles', '["Hotel California", "New Kid in Town", "Life in the Fast Lane"]', '1976-12-08');
```

Allereerst moet een pagina aangemaakt worden om alle informatie van de albums te laten zien in de frontend. Hiervoor wordt de pagina albums.razor aagemaakt in /pages van de applicatie.

Gezien het mij leuk lijkt om als eerst de albums te kunnen filteren, maak ik een InputText element aan waarbij het de bedoeling is om de frontend te updaten zodra er iets in de input wordt ingevoerd. Na een tijdje te denken dat ik een fout heb gemaakt in mijn code, blijkt dat ik "@rendermode InteractiveServer" was vergeten toe te voegen.

Hierna wordt de lijst daadwerkelijk gefilterd op basis van de tekst in de input.

Hierna besluit ik dat het alleen logisch is om het hele project maar eens een serieuze structuur te geven. Mappen zoals /Services /Controllers en /Models worden aangemaakt. Daarnaast worden er interfaces toegevoegd om overzichtelijk te houden welke functionaliteiten binnen de services beschikbaar zijn. Hierna kom ik erachter dat alle services en interfaces nog aan de program.cs toegevoegd moeten worden, dus dat wordt gedaan.

Ik heb hierna een klein beetje ruzie met de opmaak van bootstrap (wat standaard in het project zit). Uiteindelijk besluit ik om er tenminste voor te zorgen dat alle CRUD-functionaliteiten aanwezig zijn binnen de applicatie. De laatste paar functies komen hierdoor in de Albums.razor pagina. Dit is niet helemaal hoe ik het zou willen hebben, maar gezien ik de applicatie graag wil opsturen, laat ik deze code een beetje slordig onderin de pagina staan.

Al met al is de codestructuur hiernaast volgens mij vrij goed. Alleen door deze laatste paar toevoegingen lijkt Albums.razor wat slordig. Dit had uiteindelijk nog wel uiteengezet kunnen worden in meerdere componenten en hadden daarna toegevoegd kunnen worden aan de daadwerkelijke pagina.

Al met al denk ik dat ik wat meer commits had kunnen maken, maar ik ben uiteindelijk alleen bezig met een project voor mijzelf. Dus dat maakt het voor mij wel eens dat ik dan denk om het pas te doen als de functionaliteiten allemaal werken. Wellicht is het nog een leerpuntje om kleinere wijzigingen per keer te ontwikkelen en dan wat regelmatiger te committen.