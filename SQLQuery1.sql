USE Test_nr_1;
-- i samma databas
-- schema.tabell
SELECT	KundNummer AS Id, -- Byter namn p� KundNummer till Id. ALIAS!
		F�rnamn,
		Efternamn,
		Mobilnummer,
		Ort
FROM Kund
WHERE KundNummer <= 2 -- IS �r NULL operatorn. NULL g�r endast att anv�nda med IS!


-- SELECT och FROM ska alltid finnas med. 


--WHERE -- Vilkor
--GROUP BY -- Kolumner
--HAVING -- Vilkor f�r att filtrera gruppen
--ORDER BY -- Sorterar efter
