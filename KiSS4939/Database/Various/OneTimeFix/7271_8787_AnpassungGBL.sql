-----------------------------------------------------------------------------------------------------------------------------
-- #8787 - Anpassung GBL
-----------------------------------------------------------------------------------------------------------------------------
DECLARE @Stichtag DATETIME
Set @Stichtag = '2013-06-01'

INSERT INTO XConfig
(KeyPath, DatumVon, ValueCode, ValueVar, Description)
VALUES
('System\Sozialhilfe\SKOS2005\GBL\1', @Stichtag, 4, 986.00, 'Grundbedarf 1 Person')

INSERT INTO XConfig
(KeyPath, DatumVon, ValueCode, ValueVar, Description)
VALUES
('System\Sozialhilfe\SKOS2005\GBL\2', @Stichtag, 4, 1509.00, 'Grundbedarf 2 Personen')

INSERT INTO XConfig
(KeyPath, DatumVon, ValueCode, ValueVar, Description)
VALUES
('System\Sozialhilfe\SKOS2005\GBL\3', @Stichtag, 4, 1834.00, 'Grundbedarf 3 Personen')

INSERT INTO XConfig
(KeyPath, DatumVon, ValueCode, ValueVar, Description)
VALUES
('System\Sozialhilfe\SKOS2005\GBL\4', @Stichtag, 4, 2110.00, 'Grundbedarf 4 Personen')

INSERT INTO XConfig
(KeyPath, DatumVon, ValueCode, ValueVar, Description)
VALUES
('System\Sozialhilfe\SKOS2005\GBL\5', @Stichtag, 4, 2386.00, 'Grundbedarf 5 Personen')

INSERT INTO XConfig
(KeyPath, DatumVon, ValueCode, ValueVar, Description)
VALUES
('System\Sozialhilfe\SKOS2005\GBL\6', @Stichtag, 4, 2662.00, 'Grundbedarf 6 Personen')

INSERT INTO XConfig
(KeyPath, DatumVon, ValueCode, ValueVar, Description)
VALUES
('System\Sozialhilfe\SKOS2005\GBL\7', @Stichtag, 4, 2938.00, 'Grundbedarf 7 Personen')

INSERT INTO XConfig
(KeyPath, DatumVon, ValueCode, ValueVar, Description)
VALUES
('System\Sozialhilfe\SKOS2005\GBL_PerPerson', @Stichtag, 4, 276.00, 'Grundbedarf pro weitere Person')

Update dbo.XLOVCode Set Text = 'LA 110, 120 oder 121 SKOS 2005/SKOS 2011/SKOS 2013 (gültig ab 01.06.2013)' Where LOVName = 'WhGrundbedarfTyp' and Code = 32015

UPDATE BgPositionsart
Set sqlRichtlinie = '
DECLARE @valueHG money, @valueUE money    

SELECT    
@valueHG = 
(
	SELECT TOP 1 CONVERT(money, TMP.ValueVar) 
		+ (
			CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS2005\GBL_PerPerson'', @RefDate)) 
			* (KZ.HgGrundbedarf - CONVERT(int, Child)) 
		) 
	FROM dbo.fnXConfigChild(''System\Sozialhilfe\SKOS2005\GBL\'', @RefDate)  TMP  
	WHERE CONVERT(int, Child) <= KZ.HgGrundbedarf                
	ORDER BY CONVERT(int, Child) DESC
),      

@valueUE = CASE WHEN KZ.GBUseHgUeFactor = 1 
		THEN 
			(
				SELECT TOP 1 CONVERT(money, TMP.ValueVar) 
					+ (
						CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS2005\GBL_PerPerson'', @RefDate)) * 	
						(KZ.HgGrundbedarf - CONVERT(int, Child)) 
					)                       
				FROM dbo.fnXConfigChild(''System\Sozialhilfe\SKOS2005\GBL\'', @RefDate)  TMP                       
				WHERE CONVERT(int, Child) <= KZ.HgGrundbedarf                       
				ORDER BY CONVERT(int, Child) DESC
			) * GBHgUeFactor                 
		ELSE 
			(
				SELECT TOP 1 CONVERT(money, TMP.ValueVar) 
					+ (
						CONVERT(money, dbo.fnXConfig(''System\Sozialhilfe\SKOS2005\GBL_PerPerson'', @RefDate)) 
						* (KZ.UeGrundbedarf - CONVERT(int, Child)) 
					)                       
				FROM dbo.fnXConfigChild(''System\Sozialhilfe\SKOS2005\GBL\'', @RefDate)  TMP                       
				WHERE CONVERT(int, Child) <= KZ.UeGrundbedarf                       
				ORDER BY CONVERT(int, Child) DESC
			)
		END 
FROM dbo.fnWhKennzahlen(@BgFinanzplanID) KZ    

SELECT 
	$0.00 AS HG_MIN, 
	@valueHG AS HG_MAX, 
	@valueHG AS HG_DEF,    
	$0.00 AS UE_MIN, 
	ROUND(@valueUE,0) AS UE_MAX, 
	ROUND(@valueUE,0) AS UE_DEF'
	
WHERE BgPositionsartID = 32015

