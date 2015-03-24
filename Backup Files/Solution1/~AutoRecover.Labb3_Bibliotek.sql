USE MASTER
GO

IF NOT EXISTS (SELECT * FROM sys.sysdatabases WHERE name='BibliotekDb')

	CREATE DATABASE BibliotekDb
GO

USE BibliotekDb
go

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='BibliotekDb.Kund')
CREATE TABLE Kund
(
	KundId INT NOT NULL IDENTITY (1,1), --PRIMÄRNYCKEL
	ForNamn VARCHAR (30)NOT NULL,
	EfterNamn VARCHAR (30)NOT NULL, 
	Adress VARCHAR(30) NULL,
	HemTelefon VARCHAR(10) NULL,
	MobilTelefon VARCHAR(10) NOT NULL,
	Epost VARCHAR (30)NULL, -- UNIQUE
	Kon VARCHAR (6)NULL,
	FodelseAr VARCHAR (12)NOT NULL
	
	CONSTRAINT Pk_KundId PRIMARY KEY (KundId),
	CONSTRAINT Ak_KUND_Epost UNIQUE (Epost)
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='BibliotekDb.Forfattare')
CREATE TABLE Forfattare
(
	ForfattarId INT NOT NULL IDENTITY (1,1),--PRIMÄRNYCKEL
	ForNamn VARCHAR (30) NOT NULL,
	EfterNamn VARCHAR (50) NOT NULL,
	FodelseAr VARCHAR (12)NOT NULL,
	AvlidenAr DATE NULL,
	Sprak VARCHAR (30) NOT NULL,
	Land VARCHAR (30) NOT NULL,

	CONSTRAINT Pk_ForfattarId PRIMARY KEY(ForfattarId),
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='BibliotekDb.Bok')
CREATE TABLE Bok 
(
	BokId INT NOT NULL IDENTITY (1,1), -- PRIMÄRNYCKEL
	Forfattare INT NOT NULL,
	Titel VARCHAR(50) NOT NULL,
	Publicerades DATE NOT NULL,
	Genre VARCHAR (20) NOT NULL,
	Sprak VARCHAR (30) NOT NULL,
	ISBN VARCHAR (13)NOT NULL, 

	CONSTRAINT Pk_BokId PRIMARY KEY(BokId),

	CONSTRAINT Fk_Forfattare_Bok_ForfattarId FOREIGN KEY (Forfattare)
		REFERENCES Forfattare(ForfattarId)
)

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='BibliotekDb.Kopia')
CREATE TABLE Kopia
(
	KopiaId INT NOT NULL IDENTITY (1,1), --PRIMÄRNYCKEL
	Inkopspris SMALLMONEY NOT NULL,
	InkopsAr DATE NULL,
	BokId INT NOT NULL,
	[Status] VARCHAR (20)NOT NULL,

	CONSTRAINT Pk_Kopia_Id PRIMARY KEY(KopiaId),	
	CONSTRAINT Fk_Kopia_Bok_BokId FOREIGN KEY (BokId)
		REFERENCES Bok(BokId)
);
ALTER TABLE dbo.Kopia
	ADD CONSTRAINT DF_Kopia_Status DEFAULT (1) FOR [Status]
	
--ALTER TABLE dbo.Kopia
--	ADD CONSTRAINT 

IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='BibliotekDb.Lan')
CREATE TABLE Lan
(
	LanId INT NOT NULL IDENTITY (1,1), -- PRIMÄRNYCKEL
	KundId INT NOT NULL, --FK till Kund.KundId
	KopiaId INT NOT NULL,
	LaneDatum DATE NOT NULL 
		CONSTRAINT DF_LaneDatum DEFAULT GETDATE(), 
	LamnasTillbaka DATE NULL CONSTRAINT DF_ReturDatum 
		DEFAULT DATEADD(WEEK, 2, GETDATE()), 
	SparradKund INT CONSTRAINT DF_SparradKund DEFAULT(1),

	CONSTRAINT uc_EttLanPerKund UNIQUE (KundId, KopiaId, LaneDatum),
	CONSTRAINT Pk_LanId PRIMARY KEY(LanId),
	CONSTRAINT Fk_Lan_Kund FOREIGN KEY (KundId)
		REFERENCES Kund(KundId),
	CONSTRAINT Fk_Lan_Kund_KundId FOREIGN KEY (KopiaId)
		REFERENCES Kopia(KopiaId)	
)

DECLARE @ForfattarId INTEGER 
DECLARE @BokId INTEGER
DECLARE @KopiaId INTEGER
DECLARE @KundId INTEGER
DECLARE @LanId INTEGER

--Kunder
INSERT INTO dbo.Kund(ForNamn,EfterNamn,Adress,HemTelefon,MobilTelefon,Epost,Kon,FodelseAr) 
			VALUES ('Nisse', 'Hult', 'Storgatan 15', '0480432258', '0733338503', 'nisse.hult@test.se', 'Man', '860324-3254')
SET @KundId = SCOPE_IDENTITY();
INSERT INTO dbo.Kund(ForNamn,EfterNamn,Adress,HemTelefon,MobilTelefon,Epost,Kon,FodelseAr)
			VALUES ('Peter', 'Svensson', 'Storgatan 20', '0480556698', '0701458503', 'peter@kalmar.se', 'Man', '770425-2365')
SET @KundId = SCOPE_IDENTITY();
INSERT INTO dbo.Kund(ForNamn,EfterNamn,Adress,HemTelefon,MobilTelefon,Epost,Kon,FodelseAr)
			VALUES ('Rebecka', 'Svensson', 'Vintergatan 115', '0471525569', '0708338503', 'rebecka@vaxjo.se', 'Kvinna', '551201-7254')
SET @KundId = SCOPE_IDENTITY();
INSERT INTO dbo.Kund(ForNamn,EfterNamn,Adress,HemTelefon,MobilTelefon,Epost,Kon,FodelseAr)
			VALUES ('Robin', 'Prutt', 'Fisgränd 215', '0481415258', '0733256598', 'robin.prutt@test.se', 'Man', '890124-0102')
SET @KundId = SCOPE_IDENTITY();
INSERT INTO dbo.Kund(ForNamn,EfterNamn,Adress,HemTelefon,MobilTelefon,Epost,Kon,FodelseAr)
			VALUES ('Jocke', 'Delfin', 'Gnestavägen 15', '048525658', '0733236589', 'jocke.fisludd@test.se', 'Man', '890125-3254')
SET @KundId = SCOPE_IDENTITY();

--Författare
INSERT INTO dbo.Forfattare(ForNamn, EfterNamn, FodelseAr, AvlidenAr, Sprak, Land)
			VALUES ('Dolly', 'Tuttsson', '192002152912', '', 'Amerikanska', 'USA')
SET @ForfattarId = SCOPE_IDENTITY();

INSERT INTO dbo.Forfattare(ForNamn, EfterNamn, FodelseAr, AvlidenAr, Sprak, Land)
			VALUES ('Molly', 'Muffsson', '199202192955', '', 'Svenska', 'Sverige')
SET @ForfattarId = SCOPE_IDENTITY();

--Bok 1
INSERT INTO dbo.Bok(Forfattare, Titel, Publicerades, Genre, Sprak, ISBN)
			VALUES (@ForfattarId, 'En gammla bok', '2001-01-25', 'Fiction', 'Armeniska', '2565874589652')
SET @BokId = SCOPE_IDENTITY();
INSERT INTO dbo.Kopia(Inkopspris, InkopsAr, BokId)
			VALUES (25,'2011', @BokId),
					(25,'2011', @BokId),
					(25,'2011', @BokId)
			SET @KopiaId = SCOPE_IDENTITY();
INSERT INTO dbo.Lan (KundId, KopiaId, LaneDatum)
			VALUES (@KundId, @KopiaId, GETDATE())

--Bok 2
INSERT INTO dbo.Bok(Forfattare, Titel, Publicerades, Genre, Sprak, ISBN)
			VALUES (@ForfattarId, 'En ny bok', '2015-01-25', 'Hälsa', 'Svenska', '6985588965412')
SET @BokId = SCOPE_IDENTITY();
INSERT INTO dbo.Kopia(Inkopspris, InkopsAr, BokId)
			VALUES (40,'1996', @BokId),
					(40,'1996', @BokId),
					(40,'1996', @BokId)
			SET @KopiaId = SCOPE_IDENTITY();
INSERT INTO dbo.Lan (KundId, KopiaId, LaneDatum)
			VALUES (@KundId, @KopiaId, GETDATE())

--Bok 3
INSERT INTO dbo.Bok(Forfattare, Titel, Publicerades, Genre, Sprak, ISBN)
			VALUES (@ForfattarId, 'Lär er att prutta', '2011-01-25', 'Barnbok', 'Svenska', '6985588965458')
SET @BokId = SCOPE_IDENTITY();
INSERT INTO dbo.Kopia(Inkopspris, InkopsAr, BokId)
			VALUES (60,'2012', @BokId),
					(60,'2012', @BokId),				
					(60,'2012', @BokId)
			SET @KopiaId = SCOPE_IDENTITY();
INSERT INTO dbo.Lan (KundId, KopiaId, LaneDatum)
			VALUES (@KundId, @KopiaId, GETDATE())

SELECT *
FROM DBO.Kopia

SELECT *
FROM dbo.Kund

SELECT *
FROM dbo.Kopia

SELECT *
FROM dbo.Forfattare

SELECT *
FROM dbo.Lan







	



