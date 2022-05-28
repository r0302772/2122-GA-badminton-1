Insert into dbo.Categorie (naam)
Values ('Enkel');
Insert into dbo.Categorie (naam)
Values ('Dubbel');
Insert into dbo.Categorie (naam)
Values ('Gemengd');

Insert into dbo.Functie(naam)
Values ('Contactpersoon');
Insert into dbo.Functie(naam)
Values ('Voorzitter');

Insert into dbo.Geslachten(naam)
Values ('M');
Insert into dbo.Geslachten(naam)
Values ('V');
Insert into dbo.Geslachten(naam)
Values ('X');

Insert into dbo.Gebruiker(Gebruikersnaam,Wachtwoord)
Values ('admin','53b6bc441def19973ed8a7876bb3db26f52e56b1f5d6c86d865678e327ec2e26');

insert into dbo.Clubs(Clubnaam ,DatumOpgericht,Email,Gemeente,Adres,Telefoonnummer)
values('Molse BC','1990-01-05','info@molseBC.be','Mol','Weidestraat 1','0478992345');
insert into dbo.Clubs(Clubnaam ,DatumOpgericht,Email,Gemeente,Adres,Telefoonnummer)
values('Retie BC','1990-01-05','info@molseBC.be','Mol','Weidestraat 1','0478992345');
insert into dbo.Clubs(Clubnaam ,DatumOpgericht,Email,Gemeente,Adres,Telefoonnummer)
values('Kabad','1990-01-05','secretariaat@kabadminton.be','Kasterlee','Duineneind 15','0479952724');
insert into dbo.Clubs(Clubnaam ,DatumOpgericht,Email,Gemeente,Adres,Telefoonnummer)
values('Hasbad','1990-01-05','frederic.jospin@gmail.com','Hasselt','Bieststraat 40','0494332923');
insert into dbo.Clubs(Clubnaam ,DatumOpgericht,Email,Gemeente,Adres,Telefoonnummer)
values('Arendonk BC','1990-01-05','info@Arendonk-BC.be','Arendonk','Diepenbeemd 14','0468992335');
insert into dbo.Clubs(Clubnaam ,DatumOpgericht,Email,Gemeente,Adres,Telefoonnummer)
values('Dessel BC','1990-01-05','info@Dessel-BC.be','Dessel','kolkstraat 2','014324588');


INSERT INTO dbo.Spelers(Voornaam,Familienaam,Geboortedatum,Email,Telefoonnummer,GeslachtID,ClubID)
VALUES ('Niels','Reniers','1995-02-08','niels32@gmail.com','0483999101',1,2);
INSERT INTO dbo.Spelers(Voornaam,Familienaam,Geboortedatum,Email,Telefoonnummer,GeslachtID,ClubID)
VALUES ('Marcel','Reniers','1998-02-03','marcel32@gmail.com','0479909101',1,3);
INSERT INTO dbo.Spelers(Voornaam,Familienaam,Geboortedatum,Email,Telefoonnummer,GeslachtID,ClubID)
VALUES ('Joske','Reniers','1997-06-09','joske32@gmail.com','0499849192',1,4);
INSERT INTO dbo.Spelers(Voornaam,Familienaam,Geboortedatum,Email,Telefoonnummer,GeslachtID,ClubID)
VALUES ('Tom','Reniers','1990-08-04','tom32@gmail.com','0486929110',3,5);

