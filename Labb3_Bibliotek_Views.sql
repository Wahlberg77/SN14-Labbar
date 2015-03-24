--Vilken bok som är lånad av vilken kund och när den ska vara tillbaka. 

--IF NOT EXISTS (SELECT * FROM sys.objects WHERE name='vUtlanadBokAvKundOchVaraTillbaka')

GO
CREATE VIEW vUtlanadBokAvKundOchVaraTillbaka AS
	SELECT Bok.Titel AS BokTitel,
			Kund.ForNamn + ' ' + Kund.EfterNamn AS 'Kund',
			Lan.LamnasTillbaka
	FROM dbo.Lan	
	INNER JOIN dbo.Kopia
			ON Lan.LanId = Kopia.KopiaId

	INNER JOIN dbo.Kund
			ON Lan.KundId = Kund.KundId

	INNER JOIN dbo.Bok
			ON Kopia.KopiaId = BOK.BokId

				
-- Antal kopior av respektive bok och tillgängliga för utlåning.
GO
CREATE VIEW vAntalKopiorTillgangligaUtlaning AS
	SELECT Bok.Titel, COUNT (Kopia.KopiaId) AS AntalTillgangliga
	FROM dbo.Kopia
	INNER JOIN dbo.Bok
		ON Kopia.KopiaId = Bok.BokId
	WHERE KOPIA.Status = 1
	GROUP BY Bok.Titel
WITH CHECK OPTION;

-- Store Procedure för att långa en bok och för att lämna tillbaka den. 
GO
--SET NOCOUNT ON
CREATE PROCEDURE usp_Utlaning (@KopiaId INT, @KundId INT)
AS
BEGIN
	INSERT INTO dbo.Lan (KundId, KopiaId, LaneDatum)
	VALUES (@KopiaId, @KundId, GETDATE())
	SELECT SCOPE_IDENTITY();
END

GO
CREATE PROCEDURE usp_TillbakaLamning (@KopiaId INT)
AS
BEGIN
	UPDATE dbo.Kopia
	SET Status = 1
	WHERE KopiaId = @KopiaId
	UPDATE dbo.Lan
	SET SparradKund = 1
	WHERE KopiaId = @KopiaId
END
-----------------------------------------------------------------


