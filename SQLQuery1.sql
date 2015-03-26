USE Test_nr_1;
-- i samma databas
-- schema.tabell
SELECT	KundNummer AS Id, -- Byter namn på KundNummer till Id. ALIAS!
		Förnamn,
		Efternamn,
		Mobilnummer,
		Ort
FROM Kund
WHERE KundNummer <= 2 -- IS är NULL operatorn. NULL går endast att använda med IS!


-- SELECT och FROM ska alltid finnas med. 


--WHERE -- Vilkor
--GROUP BY -- Kolumner
--HAVING -- Vilkor för att filtrera gruppen
--ORDER BY -- Sorterar efter
