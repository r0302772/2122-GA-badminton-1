
insert into BadmintonDB.dbo.Geslachten(Naam) values('M');
insert into BadmintonDB.dbo.Geslachten(Naam) values('V');
insert into BadmintonDB.dbo.Geslachten(Naam) values('X');

insert into BadmintonDB.dbo.Clubs(Clubnaam,Gemeente,Adres,DatumOpgericht,Telefoonnummer,Email)
values('Leopoldsburg' ,'Kamp','Geleeg 1','1973-10-06','011554477','test@email.com');
insert into BadmintonDB.dbo.Clubs(Clubnaam,Gemeente,Adres,DatumOpgericht,Telefoonnummer,Email)
values('Belgian Tigers' ,'Hasselt','Kiewit 2','1971-10-06','011556677','test@email.com');
insert into BadmintonDB.dbo.Clubs(Clubnaam,Gemeente,Adres,DatumOpgericht,Telefoonnummer,Email)
values('BadmintonGeel' ,'Geel','Statiestraat 5','1973-10-06','011554477','test@email.com');


INSERT INTO BadmintonDB.dbo.Spelers(Voornaam,Familienaam,Geboortedatum,Email,Telefoonnummer,GeslachtID,ClubID)
VALUES ('Niels','Reniers','1993-08-31','niels32@gmail.com','0483999101',1,2);
INSERT INTO dbo.Spelers(Voornaam,Familienaam,Geboortedatum,Email,Telefoonnummer,GeslachtID,ClubID)
VALUES ('Marcel','Reniers','1993-08-31','niels32@gmail.com','0483999101',1,1);
INSERT INTO dbo.Spelers(Voornaam,Familienaam,Geboortedatum,Email,Telefoonnummer,GeslachtID,ClubID)
VALUES ('Joske','Reniers','1993-08-31','niels32@gmail.com','0483999101',1,3);
INSERT INTO dbo.Spelers(Voornaam,Familienaam,Geboortedatum,Email,Telefoonnummer,GeslachtID,ClubID)
VALUES ('Tom','Reniers','1993-08-31','niels32@gmail.com','0483999101',3,2);
