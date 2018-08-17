/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this script to <description>.
=================================================================================================*/

-------------------------------------------------------------------------------
-- pre-steps
-------------------------------------------------------------------------------
SET NOCOUNT ON;
GO

-------------------------------------------------------------------------------
-- drop the data
-------------------------------------------------------------------------------
DELETE FROM dbo.SstPscdSachkontoInnenauftrag;
PRINT ('Info: Deleted data SstPscdSachkontoInnenauftrag');

-------------------------------------------------------------------------------
-- add the data
-------------------------------------------------------------------------------
DECLARE @CreatorModifier VARCHAR(50);
SELECT @CreatorModifier = dbo.fnGetDBRowCreatorModifier(dbo.fnXGetSystemUserID());

INSERT INTO dbo.SstPscdSachkontoInnenauftrag([KbuKontoID], [Sachkonto], [Creator], [Modifier])
SELECT KbuKontoID, KontoNr, @CreatorModifier, @CreatorModifier
FROM dbo.KbuKonto
WHERE KbuKontoklasseCode IN (3,4) --Aufwand, Ertrag
  AND LEN(KontoNr) <= 3
  AND CONVERT(INT, KontoNr) BETWEEN 31 AND 999


-- aus xls generiert:
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605031', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 031
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605032', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 032
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605033', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 033
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '10110207', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501101000', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 034
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '42205041', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501101000', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 041
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605110', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 110
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605119', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 119
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605120', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 120
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605121', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 121
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605125', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 125
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605126', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 126
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605127', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 127
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605128', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 128
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605129', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 129
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605130', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 130
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605131', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 131
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605140', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913014', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 140
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605141', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 141
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605142', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 142
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605143', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 143
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605150', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 150
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605151', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 151
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605152', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 152
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605160', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 160
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605170', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 170
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605210', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 210
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605211', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 211
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605212', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 212
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605213', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 213
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605215', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 215
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605216', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 216
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605220', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 220
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605221', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 221
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605222', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 222
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605230', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 230
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605231', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 231
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605232', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 232
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605233', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 233
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605235', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 235
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605240', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 240
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605241', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 241
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605242', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 242
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605260', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 260
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605261', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 261
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605310', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 310
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605311', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 311
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605313', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 313
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605314', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 314
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605315', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 315
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605320', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 320
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605321', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 321
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605330', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 330
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605331', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 331
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605332', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 332
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605333', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 333
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605334', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 334
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605340', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 340
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605341', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 341
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605350', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 350
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605351', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 351
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605352', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 352
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605353', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 353
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605359', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 359
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605360', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 360
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605361', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 361
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605362', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 362
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605365', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 365
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605366', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 366
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605370', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 370
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605371', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 371
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605380', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 380
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605381', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 381
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605390', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 390
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605391', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 391
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605392', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 392
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605410', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 410
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605411', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 411
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605420', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 420
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605430', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 430
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605440', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 440
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605450', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 450
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605460', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 460
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605465', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 465
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605470', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 470
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605473', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 473
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605475', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 475
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605476', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 476
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605480', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 480
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605481', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 481
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605482', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 482
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605510', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 510
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605511', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 511
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605512', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 512
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605515', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501913001', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 515
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605520', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 520
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605521', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 521
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605522', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 522
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605523', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 523
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605530', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 530
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605531', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 531
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605532', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 532
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605533', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 533
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605540', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 540
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605550', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 550
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605560', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 560
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605561', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 561
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605562', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 562
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605570', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 570
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605590', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919200', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 590
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605591', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 591
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36605600', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920300', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 600
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36635610', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920400', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 610
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36635611', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920400', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 611
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '36635612', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920400', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 612
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '37605620', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501930100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 620
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '37605621', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501930100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 621
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '37605622', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501930100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 622
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605710', SachkontoErtragOhneGeldfluss = '36605710', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 710
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605711', SachkontoErtragOhneGeldfluss = '36605711', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 711
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605720', SachkontoErtragOhneGeldfluss = '36605720', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 720
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605721', SachkontoErtragOhneGeldfluss = '36605721', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 721
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605722', SachkontoErtragOhneGeldfluss = '36605722', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 722
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605723', SachkontoErtragOhneGeldfluss = '36605723', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 723
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605724', SachkontoErtragOhneGeldfluss = '36605724', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 724
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605725', SachkontoErtragOhneGeldfluss = '36605725', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 725
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605726', SachkontoErtragOhneGeldfluss = '36605726', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 726
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605730', SachkontoErtragOhneGeldfluss = '36605730', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 730
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605731', SachkontoErtragOhneGeldfluss = '36605731', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 731
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605732', SachkontoErtragOhneGeldfluss = '36605732', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 732
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605733', SachkontoErtragOhneGeldfluss = '36605733', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 733
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605734', SachkontoErtragOhneGeldfluss = '36605734', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 734
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605735', SachkontoErtragOhneGeldfluss = '36605735', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 735
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605736', SachkontoErtragOhneGeldfluss = '36605736', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 736
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605740', SachkontoErtragOhneGeldfluss = '36605740', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 740
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605741', SachkontoErtragOhneGeldfluss = '36605741', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 741
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605742', SachkontoErtragOhneGeldfluss = '36605742', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 742
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605743', SachkontoErtragOhneGeldfluss = '36605743', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 743
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605744', SachkontoErtragOhneGeldfluss = '36605744', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 744
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605750', SachkontoErtragOhneGeldfluss = '36605750', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 750
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605751', SachkontoErtragOhneGeldfluss = '36605751', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 751
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605752', SachkontoErtragOhneGeldfluss = '36605752', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 752
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605753', SachkontoErtragOhneGeldfluss = '36605753', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 753
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605754', SachkontoErtragOhneGeldfluss = '36605754', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 754
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605755', SachkontoErtragOhneGeldfluss = '36605755', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 755
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605756', SachkontoErtragOhneGeldfluss = '36605756', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 756
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605757', SachkontoErtragOhneGeldfluss = '36605757', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 757
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605758', SachkontoErtragOhneGeldfluss = '36605758', Innenauftrag = '55501913014', InnenauftragErtragOhneGeldfluss = '55501913014' WHERE Sachkonto = 758
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605760', SachkontoErtragOhneGeldfluss = '36605760', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 760
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605761', SachkontoErtragOhneGeldfluss = '36605761', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 761
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605762', SachkontoErtragOhneGeldfluss = '36605762', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 762
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605763', SachkontoErtragOhneGeldfluss = '36605763', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 763
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605764', SachkontoErtragOhneGeldfluss = '36605764', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 764
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605780', SachkontoErtragOhneGeldfluss = '36605780', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 780
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605798', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501914004' WHERE Sachkonto = 798
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605810', SachkontoErtragOhneGeldfluss = '43605810', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 810
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605811', SachkontoErtragOhneGeldfluss = '43605811', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 811
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605812', SachkontoErtragOhneGeldfluss = '43605812', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 812
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605814', SachkontoErtragOhneGeldfluss = '43605814', Innenauftrag = '55501920100', InnenauftragErtragOhneGeldfluss = '55501920100' WHERE Sachkonto = 814
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605815', SachkontoErtragOhneGeldfluss = '43605815', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 815
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605816', SachkontoErtragOhneGeldfluss = '43605816', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 816
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605817', SachkontoErtragOhneGeldfluss = '43605817', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 817
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605818', SachkontoErtragOhneGeldfluss = '43605818', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 818
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605819', SachkontoErtragOhneGeldfluss = '43605819', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 819
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605820', SachkontoErtragOhneGeldfluss = '36605820', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 820
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605821', SachkontoErtragOhneGeldfluss = '36605821', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 821
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605822', SachkontoErtragOhneGeldfluss = '36605822', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 822
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605830', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 830
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605831', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501914003' WHERE Sachkonto = 831
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605833', SachkontoErtragOhneGeldfluss = '36605833', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 833
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605834', SachkontoErtragOhneGeldfluss = '36605834', Innenauftrag = '55501914003', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 834
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605850', SachkontoErtragOhneGeldfluss = '36605850', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 850
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605851', SachkontoErtragOhneGeldfluss = '36605851', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 851
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605852', SachkontoErtragOhneGeldfluss = '36605852', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 852
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605853', SachkontoErtragOhneGeldfluss = '36605853', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 853
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605854', SachkontoErtragOhneGeldfluss = '36605854', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 854
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605855', SachkontoErtragOhneGeldfluss = '36605855', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501913001' WHERE Sachkonto = 855
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605860', SachkontoErtragOhneGeldfluss = '43605860', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 860
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605861', SachkontoErtragOhneGeldfluss = '43605861', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 861
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605862', SachkontoErtragOhneGeldfluss = '43605862', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 862
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605863', SachkontoErtragOhneGeldfluss = '43605863', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 863
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605864', SachkontoErtragOhneGeldfluss = '43605864', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 864
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605865', SachkontoErtragOhneGeldfluss = '43605865', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 865
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605870', SachkontoErtragOhneGeldfluss = '43605870', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 870
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605871', SachkontoErtragOhneGeldfluss = '43605871', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 871
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605872', SachkontoErtragOhneGeldfluss = '43605872', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 872
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605873', SachkontoErtragOhneGeldfluss = '43605873', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 873
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605874', SachkontoErtragOhneGeldfluss = '43605874', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 874
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605875', SachkontoErtragOhneGeldfluss = '43605875', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 875
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605876', SachkontoErtragOhneGeldfluss = '43605876', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 876
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605877', SachkontoErtragOhneGeldfluss = '43605877', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 877
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605880', SachkontoErtragOhneGeldfluss = '43605880', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 880
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605881', SachkontoErtragOhneGeldfluss = '43605881', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 881
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605890', SachkontoErtragOhneGeldfluss = '43605890', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 890
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605891', SachkontoErtragOhneGeldfluss = '43605891', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 891
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605892', SachkontoErtragOhneGeldfluss = '43605892', Innenauftrag = '55501914002', InnenauftragErtragOhneGeldfluss = '55501914002' WHERE Sachkonto = 892
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '4360900', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920300', InnenauftragErtragOhneGeldfluss = '55501920300' WHERE Sachkonto = 900
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43635910', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920400', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 910
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43635911', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920400', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 911
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43635912', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920400', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 912
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43635913', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920400', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 913
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43635914', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501920400', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 914
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '47605920', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501930100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 920
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '47605921', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501930100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 921
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '47605922', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501930100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 922
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '47605923', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501930100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 923
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '43605989', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501914004', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 989
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '45205990', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501914520', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 990
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '46105991', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501914614', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 991
UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = '46105992', SachkontoErtragOhneGeldfluss = '', Innenauftrag = '55501919100', InnenauftragErtragOhneGeldfluss = '55501' WHERE Sachkonto = 992


UPDATE SstPscdSachkontoInnenauftrag SET Sachkonto = NULL WHERE Sachkonto = '' OR LEN(Sachkonto) <= 3 -- nicht überschriebene temporäre KontoNr entfernen
UPDATE SstPscdSachkontoInnenauftrag SET SachkontoErtragOhneGeldfluss = NULL WHERE SachkontoErtragOhneGeldfluss = ''
UPDATE SstPscdSachkontoInnenauftrag SET Innenauftrag = NULL WHERE Innenauftrag IN ('','55501')
UPDATE SstPscdSachkontoInnenauftrag SET InnenauftragErtragOhneGeldfluss = NULL WHERE InnenauftragErtragOhneGeldfluss IN ('','55501')


-- info
PRINT ('Info: Created data SstPscdSachkontoInnenauftrag');
GO

-------------------------------------------------------------------------------
-- post-steps
-------------------------------------------------------------------------------
SET NOCOUNT OFF;
GO