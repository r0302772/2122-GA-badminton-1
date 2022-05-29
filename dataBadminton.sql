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
Values ('admin','8c6976e5b5410415bde908bd4dee15dfb167a9c873fc4bb8a81f6f2ab448a918');

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
VALUES ('Tom','Reniers','1990-08-04','tom32@gmail.com','0486929110',3,5);2


INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Loreas 1', 'Clonen','straat 123', 'Geel', '0487542451', 'loreas@fake.com',1,2)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Loreas 2', 'Clonen','straat 123', 'Geel', '0487542451', 'loreas@fake.com',2,2)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Loreas 3', 'Clonen','straat 123', 'Geel', '0487542451', 'loreas@fake.com',3,2)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Loreas 4', 'Clonen','straat 123', 'Geel', '0487542451', 'loreas@fake.com',4,2)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Loreas 5', 'Clonen','straat 123', 'Geel', '0487542451', 'loreas@fake.com',5,2)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Loreas 6', 'Clonen','straat 123', 'Geel', '0487542451', 'loreas@fake.com',6,2)

INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Tom 1', 'Clonen','straat 113', 'Geel', '0487541451', 'Tom@fake.com',1,1)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Tom 2', 'Clonen','straat 123', 'Geel', '0487542451', 'Tom@fake.com',2,1)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Tom 3', 'Clonen','straat 123', 'Geel', '0487542451', 'Tom@fake.com',3,1)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Tom 4', 'Clonen','straat 123', 'Geel', '0487542451', 'Tom@fake.com',4,1)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Tom 5', 'Clonen','straat 123', 'Geel', '0487542451', 'Tom@fake.com',5,1)
INSERT INTO dbo.Personeel(Voornaam,Familienaam, Adres, Gemeente, Telefoonnummer, Email, ClubId, FunctieId)
values('Tom 6', 'Clonen','straat 123', 'Geel', '0487542451', 'Tom@fake.com',6,1)
