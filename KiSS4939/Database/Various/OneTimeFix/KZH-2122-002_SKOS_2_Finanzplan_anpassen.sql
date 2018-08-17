/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Script zur Anpassung (beenden, neu erstellen) der Finanzpläne
=================================================================================================*/
--TestTran comment
--BEGIN TRAN

/*
DROP TABLE MigBgFinanzplanSkos2016

SELECT *
FROM dbo.MigBgFinanzplanSkos2016 MBFS WITH (READUNCOMMITTED)
WHERE 1=1


*/

SET NOCOUNT ON;

-------------------------------------------------------------------------------
-- Init vars and tables
-------------------------------------------------------------------------------
DECLARE @Stichtag DATETIME;
SET @Stichtag = '20160501'

DECLARE @StichtagVortag DATETIME;
SET @StichtagVortag = DATEADD(DAY, -1, @Stichtag);

DECLARE @StartTime DATETIME;
SET @StartTime = GETDATE();
PRINT ('Info: Start at ' + CONVERT(VARCHAR(MAX), @StartTime, 120));
PRINT ('      Finanzpläne terminieren per ' + CONVERT(VARCHAR(MAX), @StichtagVortag, 104));
PRINT ('      Finanzpläne wieder eröffnen per ' + CONVERT(VARCHAR(MAX), @Stichtag, 104));

DECLARE @UserID_kiss_sys INT;
SET @UserID_kiss_sys = dbo.fnXGetSystemUserID();

DECLARE @EntriesCount INT;
DECLARE @EntriesIterator INT;
DECLARE @PrintMsg VARCHAR(200);

DECLARE @Finanzplan TABLE
(
  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
  BgFinanzplanID INT,
  FaLeistungID INT,
  BgBudgetID_Master INT,
  WhHilfeTypCode INT,
  WhGrundbedarfTypCode INT,
  GeplantBis DATETIME,
  AnzahlPersonUE INT,
  GBL_Betrag MONEY,
  FpMitGbl110 BIT,
  FpMitGbl121 BIT,
  FpMitMizPosition BIT,
  FpMitNur1PersonAlter1825 BIT,
  BgPositionIDs_Izu1825 VARCHAR(200),
  BgPositionIDs_Miz VARCHAR(200),
  NextFpAlreadyExists BIT
);

DECLARE @BgFinanzplanID_Neu INT;
DECLARE @BgFinanzplanID INT;
DECLARE @FaLeistungID INT;
DECLARE @BgBudgetID_Master INT;
DECLARE @WhHilfeTypCode INT;
DECLARE @WhGrundbedarfTypCode INT;
DECLARE @GeplantBis DATETIME;
DECLARE @AnzahlPersonUE INT;
DECLARE @GBL_Betrag MONEY;
DECLARE @FpMitGbl110 BIT;
DECLARE @FpMitGbl121 BIT;
DECLARE @FpMitMizPosition BIT;
DECLARE @FpMitNur1PersonAlter1825 BIT;
DECLARE @BgPositionIDs_Izu1825 VARCHAR(200);
DECLARE @BgPositionIDs_Miz VARCHAR(200);
DECLARE @NextFpAlreadyExists BIT;

DECLARE @BgBudgetID INT;
DECLARE @Text VARCHAR(500)
DECLARE @GBL_Betrag_Neu MONEY;


IF (NOT EXISTS(SELECT TOP 1 1
               FROM sys.tables
               WHERE name = 'MigBgFinanzplanSkos2016'))
BEGIN
  CREATE TABLE dbo.MigBgFinanzplanSkos2016
  (
    MigBgFinanzplanSkos2016ID INT IDENTITY(1, 1) NOT NULL,
    BgFinanzplanID INT NOT NULL,
    FaFallID INT NOT NULL,
    FaLeistungID INT NOT NULL,
    BaPersonID INT NOT NULL,
    BgBudgetID_Master INT NOT NULL,
    WhHilfeTypCode INT NOT NULL,
    WhGrundbedarfTypCode INT NOT NULL,
    GeplantBis DATETIME NOT NULL,
    AnzahlPersonUE INT NOT NULL,
    FpMitGbl110 BIT NULL CONSTRAINT DF_MigBgFinanzplanSkos2016_FpMitGbl110  DEFAULT (0),
    FpMitGbl121 BIT NULL CONSTRAINT DF_MigBgFinanzplanSkos2016_FpMitGbl121  DEFAULT (0),
    FpMitMizPosition BIT NULL CONSTRAINT DF_MigBgFinanzplanSkos2016_FpMitMizPosition  DEFAULT (0),
    FpMitNur1PersonAlter1825 BIT NULL CONSTRAINT DF_MigBgFinanzplanSkos2016_FpMitNur1PersonAlter1825  DEFAULT (0),
    NextFpAlreadyExists BIT NULL,
    BgPositionIDs_Izu1825 VARCHAR(200) NULL,
    BgPositionIDs_Miz VARCHAR(200) NULL,
    GBL_Betrag MONEY NULL,
    BgFinanzplanID_Neu INT NULL,
    Fehlermeldung VARCHAR(MAX) NULL,
    Migriert DATETIME,
    Created DATETIME NOT NULL
  );
  PRINT ('Info: Tabelle MigBgFinanzplanSkos2016 erstellt');
END
ELSE
BEGIN 
  PRINT ('Info: Tabelle MigBgFinanzplanSkos2016 bereits vorhanden');
END;

PRINT ('Info: Tabelle MigBgFinanzplanSkos2016 füllen');

-------------------------------------------------------------------------------
-- FPs mit GBL 110 oder GBL 121 und UE > 5
-------------------------------------------------------------------------------
INSERT INTO dbo.MigBgFinanzplanSkos2016 (BgFinanzplanID, FaFallID, FaLeistungID, BaPersonID, BgBudgetID_Master, WhHilfeTypCode, WhGrundbedarfTypCode, GeplantBis, AnzahlPersonUE, FpMitGbl110, FpMitGbl121, GBL_Betrag, Created)
  SELECT 
    FPL.BgFinanzplanID,
    LEI.FaFallID,
    LEI.FaLeistungID,
    LEI.BaPersonID, 
    BgBudgetID_Master = BDG.BgBudgetID,
    FPL.WhHilfeTypCode,
    FPL.WhGrundbedarfTypCode,
    GeplantBis = ISNULL(FPL.DatumBis, FPL.GeplantBis),
    AnzahlPersonUE      = FPP.AnzahlPersonUE,
    FpMitGbl110         = CASE WHEN FPL.WhGrundbedarfTypCode = 32015 THEN 1 ELSE 0 END,
    FpMitGbl121         = CASE WHEN FPL.WhGrundbedarfTypCode = 3102 THEN 1 ELSE 0 END,
    GBL_Betrag          = POS.Betrag,
    Created             = @StartTime
  FROM dbo.BgFinanzplan           FPL WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgBudget       BDG ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                                     AND BDG.MasterBudget = 1
    INNER JOIN dbo.FaLeistung     LEI ON LEI.FaLeistungID = FPL.FaLeistungID
    INNER JOIN dbo.vwPersonSimple PRS ON PRS.BaPersonID = LEI.BaPersonID
    CROSS APPLY (SELECT AnzahlPersonUE = COUNT(1)
                 FROM dbo.BgFinanzplan_BaPerson
                 WHERE BgFinanzplanID = FPL.BgFinanzplanID
                   AND IstUnterstuetzt = 1) FPP   
    OUTER APPLY (SELECT POS1.Betrag
                 FROM dbo.BgPosition POS1 WITH (READUNCOMMITTED)
                 WHERE POS1.BgBudgetID = BDG.BgBudgetID
                   AND POS1.BgPositionsartID = FPL.WhGrundbedarfTypCode
                   AND POS1.BgKategorieCode = 2) POS
  WHERE 1=1
    AND FPL.WhGrundbedarfTypCode IN (32015, 3102) -- LA 110, 121
    AND COALESCE(FPL.DatumBis, FPL.GeplantBis, '99991231') >= @Stichtag
    AND FPP.AnzahlPersonUE > 5
    AND (FPL.WhGrundbedarfTypCode = 32015 
      OR (FPL.WhGrundbedarfTypCode = 3102 
        AND POS.Betrag = dbo.fnXConfig('System\Sozialhilfe\SKOS2005\GBL\' + CONVERT(VARCHAR(MAX), FPP.AnzahlPersonUE), FPL.DatumVon)))
  ORDER BY FPL.WhGrundbedarfTypCode, FPL.BgFinanzplanID

PRINT ('      ' + ISNULL(CONVERT(VARCHAR(MAX), @@ROWCOUNT), 0) + ' FPs mit GBL 110 oder GBL 121 und UE > 5');


-------------------------------------------------------------------------------
-- FPs von jung Erwachsene zwischen 18 und 25 in eigenem Haushalt
-------------------------------------------------------------------------------
;WITH Pers1825CTE AS
(
  -- Aus Excel Register 1 (18-25 eigenem HH) kopieren
  -- =IF(A2=""; "";CONCATENATE("  SELECT BaPersonID = ";B2;", FaFallID = ";C2;", BgFinanzplanID = ";D2;", BgPositionIDs = '";I2;"' UNION ALL"))
  -- =WENN(A2=""; "";VERKETTEN("  SELECT BaPersonID = ";B2;", FaFallID = ";C2;", BgFinanzplanID = ";D2;", BgPositionIDs = '";I2;"' UNION ALL"))
  -- start paste
  SELECT BaPersonID = 157646, FaFallID = 23099, BgFinanzplanID = 151521, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 224740, FaFallID = 64433, BgFinanzplanID = 154610, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 136341, FaFallID = 72485, BgFinanzplanID = 155671, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 192050, FaFallID = 65081, BgFinanzplanID = 155788, BgPositionIDs = '11494004' UNION ALL
  SELECT BaPersonID = 237430, FaFallID = 71906, BgFinanzplanID = 155888, BgPositionIDs = '10783645' UNION ALL
  SELECT BaPersonID = 253108, FaFallID = 81352, BgFinanzplanID = 155997, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 222988, FaFallID = 66612, BgFinanzplanID = 156058, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 243000, FaFallID = 75279, BgFinanzplanID = 156070, BgPositionIDs = '10803186' UNION ALL
  SELECT BaPersonID = 126164, FaFallID = 10588, BgFinanzplanID = 156107, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 166114, FaFallID = 27866, BgFinanzplanID = 156108, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 241680, FaFallID = 74451, BgFinanzplanID = 156161, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 248764, FaFallID = 78676, BgFinanzplanID = 156243, BgPositionIDs = '10826482' UNION ALL
  SELECT BaPersonID = 212604, FaFallID = 78128, BgFinanzplanID = 156470, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 248900, FaFallID = 78743, BgFinanzplanID = 156561, BgPositionIDs = '11047670' UNION ALL
  SELECT BaPersonID = 236842, FaFallID = 81573, BgFinanzplanID = 156666, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 157772, FaFallID = 70072, BgFinanzplanID = 156965, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 143693, FaFallID = 75307, BgFinanzplanID = 156966, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 148827, FaFallID = 71917, BgFinanzplanID = 157104, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 248077, FaFallID = 78296, BgFinanzplanID = 157124, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 220967, FaFallID = 62156, BgFinanzplanID = 157269, BgPositionIDs = '10909892' UNION ALL
  SELECT BaPersonID = 155308, FaFallID = 64579, BgFinanzplanID = 157360, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 253736, FaFallID = 81729, BgFinanzplanID = 157493, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 150926, FaFallID = 81787, BgFinanzplanID = 157521, BgPositionIDs = '10982800' UNION ALL
  SELECT BaPersonID = 248705, FaFallID = 78648, BgFinanzplanID = 157601, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 215020, FaFallID = 68898, BgFinanzplanID = 157685, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 162756, FaFallID = 81292, BgFinanzplanID = 157695, BgPositionIDs = '10946076' UNION ALL
  SELECT BaPersonID = 154853, FaFallID = 74511, BgFinanzplanID = 157977, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 119280, FaFallID = 75779, BgFinanzplanID = 158102, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 235389, FaFallID = 80435, BgFinanzplanID = 158145, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 157206, FaFallID = 74437, BgFinanzplanID = 158159, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 203090, FaFallID = 64730, BgFinanzplanID = 158248, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 162181, FaFallID = 78745, BgFinanzplanID = 158269, BgPositionIDs = '11003963' UNION ALL
  SELECT BaPersonID = 184772, FaFallID = 73450, BgFinanzplanID = 158273, BgPositionIDs = '11004046' UNION ALL
  SELECT BaPersonID = 241596, FaFallID = 74406, BgFinanzplanID = 158329, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 226706, FaFallID = 65601, BgFinanzplanID = 158383, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 238092, FaFallID = 78816, BgFinanzplanID = 158536, BgPositionIDs = '11024589' UNION ALL
  SELECT BaPersonID = 254335, FaFallID = 82068, BgFinanzplanID = 158583, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 242356, FaFallID = 74894, BgFinanzplanID = 158806, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 244964, FaFallID = 79150, BgFinanzplanID = 158921, BgPositionIDs = '11399782' UNION ALL
  SELECT BaPersonID = 241203, FaFallID = 74168, BgFinanzplanID = 158970, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 153306, FaFallID = 968, BgFinanzplanID = 158978, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 187827, FaFallID = 65065, BgFinanzplanID = 158980, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 165571, FaFallID = 17000, BgFinanzplanID = 159180, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 175443, FaFallID = 32880, BgFinanzplanID = 159310, BgPositionIDs = '11102953' UNION ALL
  SELECT BaPersonID = 231740, FaFallID = 68598, BgFinanzplanID = 159325, BgPositionIDs = '11104112' UNION ALL
  SELECT BaPersonID = 249796, FaFallID = 79289, BgFinanzplanID = 159355, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 254466, FaFallID = 82154, BgFinanzplanID = 159447, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 173906, FaFallID = 82152, BgFinanzplanID = 159561, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 249477, FaFallID = 79071, BgFinanzplanID = 159637, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 166203, FaFallID = 21539, BgFinanzplanID = 159657, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 146740, FaFallID = 61694, BgFinanzplanID = 159663, BgPositionIDs = '11141460' UNION ALL
  SELECT BaPersonID = 251210, FaFallID = 80166, BgFinanzplanID = 159668, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 166441, FaFallID = 73315, BgFinanzplanID = 159713, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 217145, FaFallID = 72506, BgFinanzplanID = 159763, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 226966, FaFallID = 65747, BgFinanzplanID = 159932, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 249873, FaFallID = 79333, BgFinanzplanID = 160237, BgPositionIDs = '11190156' UNION ALL
  SELECT BaPersonID = 250456, FaFallID = 79678, BgFinanzplanID = 160260, BgPositionIDs = '11191837' UNION ALL
  SELECT BaPersonID = 216973, FaFallID = 59816, BgFinanzplanID = 160426, BgPositionIDs = '11203739' UNION ALL
  SELECT BaPersonID = 149663, FaFallID = 71345, BgFinanzplanID = 160609, BgPositionIDs = '11220452' UNION ALL
  SELECT BaPersonID = 243778, FaFallID = 75800, BgFinanzplanID = 160611, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 215281, FaFallID = 79297, BgFinanzplanID = 160636, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 201579, FaFallID = 80081, BgFinanzplanID = 160659, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 192659, FaFallID = 79628, BgFinanzplanID = 160660, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 189614, FaFallID = 73786, BgFinanzplanID = 160792, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 208451, FaFallID = 75649, BgFinanzplanID = 160866, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 145044, FaFallID = 82349, BgFinanzplanID = 160894, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 145671, FaFallID = 76597, BgFinanzplanID = 160898, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 244871, FaFallID = 76442, BgFinanzplanID = 160968, BgPositionIDs = '11352312' UNION ALL
  SELECT BaPersonID = 195903, FaFallID = 79234, BgFinanzplanID = 161090, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 185527, FaFallID = 68450, BgFinanzplanID = 161106, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 238957, FaFallID = 72781, BgFinanzplanID = 161243, BgPositionIDs = '11275646' UNION ALL
  SELECT BaPersonID = 243654, FaFallID = 75722, BgFinanzplanID = 161277, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 193685, FaFallID = 81850, BgFinanzplanID = 161280, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 116120, FaFallID = 4694, BgFinanzplanID = 161365, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 244368, FaFallID = 79113, BgFinanzplanID = 161390, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 130233, FaFallID = 72033, BgFinanzplanID = 161435, BgPositionIDs = '11290646' UNION ALL
  SELECT BaPersonID = 151762, FaFallID = 75463, BgFinanzplanID = 161484, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 145349, FaFallID = 70486, BgFinanzplanID = 161492, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 247795, FaFallID = 78143, BgFinanzplanID = 161514, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 251720, FaFallID = 80465, BgFinanzplanID = 161552, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 144924, FaFallID = 81786, BgFinanzplanID = 161597, BgPositionIDs = '11399244' UNION ALL
  SELECT BaPersonID = 244154, FaFallID = 76028, BgFinanzplanID = 161719, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 192678, FaFallID = 82115, BgFinanzplanID = 161902, BgPositionIDs = '11326484' UNION ALL
  SELECT BaPersonID = 254913, FaFallID = 82424, BgFinanzplanID = 161986, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 254892, FaFallID = 82415, BgFinanzplanID = 162006, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 240361, FaFallID = 73656, BgFinanzplanID = 162011, BgPositionIDs = '11401744' UNION ALL
  SELECT BaPersonID = 255051, FaFallID = 82509, BgFinanzplanID = 162041, BgPositionIDs = '11339380' UNION ALL
  SELECT BaPersonID = 133516, FaFallID = 11016, BgFinanzplanID = 162080, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 246546, FaFallID = 77421, BgFinanzplanID = 162242, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 161524, FaFallID = 62463, BgFinanzplanID = 162280, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 136076, FaFallID = 6161, BgFinanzplanID = 162321, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 156389, FaFallID = 22526, BgFinanzplanID = 162367, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 159057, FaFallID = 82163, BgFinanzplanID = 162395, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 237902, FaFallID = 72178, BgFinanzplanID = 162400, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 143442, FaFallID = 15554, BgFinanzplanID = 162490, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 214406, FaFallID = 79198, BgFinanzplanID = 162559, BgPositionIDs = '11392981' UNION ALL
  SELECT BaPersonID = 254413, FaFallID = 82120, BgFinanzplanID = 162567, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 159404, FaFallID = 66051, BgFinanzplanID = 162767, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 202097, FaFallID = 57801, BgFinanzplanID = 162868, BgPositionIDs = '11415995' UNION ALL
  SELECT BaPersonID = 188540, FaFallID = 40619, BgFinanzplanID = 162878, BgPositionIDs = '11416491' UNION ALL
  SELECT BaPersonID = 253536, FaFallID = 81602, BgFinanzplanID = 162930, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 224612, FaFallID = 73460, BgFinanzplanID = 162976, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 250139, FaFallID = 79486, BgFinanzplanID = 162977, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 250862, FaFallID = 79940, BgFinanzplanID = 163115, BgPositionIDs = '11433457' UNION ALL
  SELECT BaPersonID = 135465, FaFallID = 10614, BgFinanzplanID = 163139, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 244554, FaFallID = 76254, BgFinanzplanID = 163155, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 244892, FaFallID = 76454, BgFinanzplanID = 163202, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 252791, FaFallID = 81169, BgFinanzplanID = 163274, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 176234, FaFallID = 76715, BgFinanzplanID = 163278, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 174539, FaFallID = 83, BgFinanzplanID = 163434, BgPositionIDs = '11530040' UNION ALL
  SELECT BaPersonID = 161295, FaFallID = 25157, BgFinanzplanID = 163463, BgPositionIDs = '11464915' UNION ALL
  SELECT BaPersonID = 255184, FaFallID = 82599, BgFinanzplanID = 163489, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 239420, FaFallID = 82867, BgFinanzplanID = 163729, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 251028, FaFallID = 80046, BgFinanzplanID = 163837, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 199838, FaFallID = 79763, BgFinanzplanID = 163845, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 244798, FaFallID = 76392, BgFinanzplanID = 163859, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 164097, FaFallID = 26750, BgFinanzplanID = 163878, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 154452, FaFallID = 68660, BgFinanzplanID = 163958, BgPositionIDs = '11517314' UNION ALL
  SELECT BaPersonID = 255817, FaFallID = 82971, BgFinanzplanID = 163993, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 235139, FaFallID = 70559, BgFinanzplanID = 164011, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 156963, FaFallID = 73714, BgFinanzplanID = 164047, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 244544, FaFallID = 76249, BgFinanzplanID = 164050, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 254690, FaFallID = 82296, BgFinanzplanID = 164099, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 156409, FaFallID = 73243, BgFinanzplanID = 164205, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 170879, FaFallID = 79599, BgFinanzplanID = 165228, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 246419, FaFallID = 79996, BgFinanzplanID = 165291, BgPositionIDs = '11543177' UNION ALL
  SELECT BaPersonID = 173799, FaFallID = 73196, BgFinanzplanID = 165556, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 245443, FaFallID = 76763, BgFinanzplanID = 165568, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 234129, FaFallID = 82363, BgFinanzplanID = 165666, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 152324, FaFallID = 20261, BgFinanzplanID = 165882, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 179705, FaFallID = 82710, BgFinanzplanID = 165887, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 197362, FaFallID = 66981, BgFinanzplanID = 165947, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 223588, FaFallID = 66915, BgFinanzplanID = 165993, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 242377, FaFallID = 74911, BgFinanzplanID = 166064, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 154374, FaFallID = 64671, BgFinanzplanID = 166081, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 153596, FaFallID = 83006, BgFinanzplanID = 166098, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 145911, FaFallID = 66711, BgFinanzplanID = 166304, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 249621, FaFallID = 79159, BgFinanzplanID = 166364, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 149260, FaFallID = 83224, BgFinanzplanID = 166373, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 254870, FaFallID = 82396, BgFinanzplanID = 166376, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 251135, FaFallID = 80115, BgFinanzplanID = 166378, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 169686, FaFallID = 69750, BgFinanzplanID = 166470, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 153533, FaFallID = 79497, BgFinanzplanID = 166472, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 253717, FaFallID = 81710, BgFinanzplanID = 166506, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 201162, FaFallID = 71644, BgFinanzplanID = 166541, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 241702, FaFallID = 74459, BgFinanzplanID = 166576, BgPositionIDs = '11650659' UNION ALL
  SELECT BaPersonID = 154043, FaFallID = 21298, BgFinanzplanID = 166667, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 251133, FaFallID = 80112, BgFinanzplanID = 166699, BgPositionIDs = '11757296' UNION ALL
  SELECT BaPersonID = 199270, FaFallID = 82256, BgFinanzplanID = 166800, BgPositionIDs = '11665395' UNION ALL
  SELECT BaPersonID = 235303, FaFallID = 70650, BgFinanzplanID = 166820, BgPositionIDs = '11666729' UNION ALL
  SELECT BaPersonID = 250704, FaFallID = 79836, BgFinanzplanID = 166835, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 241659, FaFallID = 83206, BgFinanzplanID = 166912, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 157646, FaFallID = 83093, BgFinanzplanID = 167084, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 242895, FaFallID = 80121, BgFinanzplanID = 167113, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 193482, FaFallID = 82338, BgFinanzplanID = 167143, BgPositionIDs = '11686594' UNION ALL
  SELECT BaPersonID = 255578, FaFallID = 82835, BgFinanzplanID = 167182, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 152971, FaFallID = 80684, BgFinanzplanID = 167189, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 172747, FaFallID = 82429, BgFinanzplanID = 167190, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 139242, FaFallID = 9513, BgFinanzplanID = 167201, BgPositionIDs = '11690267' UNION ALL
  SELECT BaPersonID = 146084, FaFallID = 78123, BgFinanzplanID = 167279, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 154346, FaFallID = 21471, BgFinanzplanID = 167324, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 197829, FaFallID = 80062, BgFinanzplanID = 167329, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 160234, FaFallID = 70573, BgFinanzplanID = 167363, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 200858, FaFallID = 82743, BgFinanzplanID = 167364, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 158697, FaFallID = 83543, BgFinanzplanID = 167452, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 216158, FaFallID = 59362, BgFinanzplanID = 167483, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 162056, FaFallID = 4594, BgFinanzplanID = 167505, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 189488, FaFallID = 68223, BgFinanzplanID = 167615, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 159602, FaFallID = 80754, BgFinanzplanID = 167637, BgPositionIDs = '11829371' UNION ALL
  SELECT BaPersonID = 240630, FaFallID = 83511, BgFinanzplanID = 167648, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 241653, FaFallID = 74438, BgFinanzplanID = 167655, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 187734, FaFallID = 82042, BgFinanzplanID = 167742, BgPositionIDs = '11742588' UNION ALL
  SELECT BaPersonID = 251903, FaFallID = 80587, BgFinanzplanID = 167791, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 218084, FaFallID = 60345, BgFinanzplanID = 167856, BgPositionIDs = '11752778' UNION ALL
  SELECT BaPersonID = 253768, FaFallID = 81748, BgFinanzplanID = 167859, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 255423, FaFallID = 82740, BgFinanzplanID = 167896, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 249598, FaFallID = 79145, BgFinanzplanID = 167997, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 256769, FaFallID = 83553, BgFinanzplanID = 168001, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 255369, FaFallID = 82713, BgFinanzplanID = 168045, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 192505, FaFallID = 43021, BgFinanzplanID = 168056, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 145910, FaFallID = 66712, BgFinanzplanID = 168062, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 188978, FaFallID = 74920, BgFinanzplanID = 168158, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 169155, FaFallID = 8273, BgFinanzplanID = 168279, BgPositionIDs = '11793614' UNION ALL
  SELECT BaPersonID = 232317, FaFallID = 68955, BgFinanzplanID = 168288, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 178131, FaFallID = 69223, BgFinanzplanID = 168352, BgPositionIDs = '11799624' UNION ALL
  SELECT BaPersonID = 216834, FaFallID = 83520, BgFinanzplanID = 168376, BgPositionIDs = '11802134' UNION ALL
  SELECT BaPersonID = 233500, FaFallID = 69663, BgFinanzplanID = 168445, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 237792, FaFallID = 71964, BgFinanzplanID = 168485, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 255752, FaFallID = 82932, BgFinanzplanID = 168554, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 144650, FaFallID = 62968, BgFinanzplanID = 168589, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 152324, FaFallID = 83471, BgFinanzplanID = 168608, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 235264, FaFallID = 70628, BgFinanzplanID = 168625, BgPositionIDs = '11827654' UNION ALL
  SELECT BaPersonID = 182013, FaFallID = 77294, BgFinanzplanID = 168651, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 243430, FaFallID = 75553, BgFinanzplanID = 168704, BgPositionIDs = '11836355' UNION ALL
  SELECT BaPersonID = 181690, FaFallID = 73639, BgFinanzplanID = 168709, BgPositionIDs = '11837731' UNION ALL
  SELECT BaPersonID = 256870, FaFallID = 83602, BgFinanzplanID = 168778, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 250614, FaFallID = 79779, BgFinanzplanID = 168788, BgPositionIDs = '' UNION ALL
  SELECT BaPersonID = 132374, FaFallID = 74090, BgFinanzplanID = 168803, BgPositionIDs = '' 
  -- stop paste and remove last UNION ALL
)
INSERT INTO dbo.MigBgFinanzplanSkos2016 (BgFinanzplanID, FaFallID, FaLeistungID, BaPersonID, BgBudgetID_Master, WhHilfeTypCode, WhGrundbedarfTypCode, GeplantBis, AnzahlPersonUE, FpMitNur1PersonAlter1825, BgPositionIDs_Izu1825, GBL_Betrag, Created)
  SELECT 
    FPL.BgFinanzplanID,
    LEI.FaFallID,
    LEI.FaLeistungID,
    LEI.BaPersonID, 
    BgBudgetID_Master = BDG.BgBudgetID,
    FPL.WhHilfeTypCode,
    FPL.WhGrundbedarfTypCode,
    GeplantBis               = ISNULL(FPL.DatumBis, FPL.GeplantBis),
    AnzahlPersonUE           = FPP.AnzahlPersonUE,
    FpMitNur1PersonAlter1825 = 1,
    BgPositionIDs_Izu1825    = CTE.BgPositionIDs,
    GBL_Betrag               = POS_GBL.Betrag,
    Created                  = @StartTime
  FROM dbo.BgFinanzplan       FPL WITH (READUNCOMMITTED)
    INNER JOIN Pers1825CTE    CTE ON CTE.BgFinanzplanID = FPL.BgFinanzplanID
    INNER JOIN dbo.BgBudget   BDG ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                                 AND BDG.MasterBudget = 1
    INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FPL.FaLeistungID
    CROSS APPLY (SELECT AnzahlPersonUE = COUNT(1)
                 FROM dbo.BgFinanzplan_BaPerson
                 WHERE BgFinanzplanID = FPL.BgFinanzplanID
                   AND IstUnterstuetzt = 1) FPP   
    OUTER APPLY (SELECT Betrag = SUM(POS1.Betrag)
                  FROM dbo.BgPosition POS1 WITH (READUNCOMMITTED)
                  WHERE POS1.BgBudgetID = BDG.BgBudgetID
                    AND POS1.BgPositionsartID = FPL.WhGrundbedarfTypCode
                    AND POS1.BgKategorieCode = 2) POS_GBL
  WHERE 1=1


PRINT ('      ' + ISNULL(CONVERT(VARCHAR(MAX), @@ROWCOUNT), 0) + ' FPs mit nur einer Person zwischen 18 und 25');

-------------------------------------------------------------------------------
-- FPs mit einer MIZ-Position
-------------------------------------------------------------------------------
;WITH MizPosCTE AS
(
  -- Aus Excel Register 2 (LA 380,381 (MIZ)) kopieren
  -- =IF(A2=""; "";CONCATENATE("  SELECT BaPersonID = ";B2;", FaFallID = ";C2;", BgFinanzplanID = ";D2;", BgPositionIDs = '";I2;"' UNION ALL"))
  -- =WENN(A2=""; "";VERKETTEN("  SELECT BaPersonID = ";B2;", FaFallID = ";C2;", BgFinanzplanID = ";D2;", BgPositionIDs = '";I2;"' UNION ALL"))
  -- start paste
  SELECT BaPersonID = 101511, FaFallID = 72688, BgFinanzplanID = 166339, BgPositionIDs = '11653386' UNION ALL
  SELECT BaPersonID = 107469, FaFallID = 2165, BgFinanzplanID = 155879, BgPositionIDs = '10783028' UNION ALL
  SELECT BaPersonID = 115372, FaFallID = 58074, BgFinanzplanID = 162610, BgPositionIDs = '11396453' UNION ALL
  SELECT BaPersonID = 120209, FaFallID = 56537, BgFinanzplanID = 163451, BgPositionIDs = '11463848' UNION ALL
  SELECT BaPersonID = 120360, FaFallID = 76520, BgFinanzplanID = 167258, BgPositionIDs = '11692011' UNION ALL
  SELECT BaPersonID = 128501, FaFallID = 79986, BgFinanzplanID = 165387, BgPositionIDs = '11548574' UNION ALL
  SELECT BaPersonID = 133128, FaFallID = 61444, BgFinanzplanID = 167264, BgPositionIDs = '11694095' UNION ALL
  SELECT BaPersonID = 143162, FaFallID = 15391, BgFinanzplanID = 157646, BgPositionIDs = '10942360' UNION ALL
  SELECT BaPersonID = 145122, FaFallID = 16452, BgFinanzplanID = 163355, BgPositionIDs = '11455711' UNION ALL
  SELECT BaPersonID = 150640, FaFallID = 83023, BgFinanzplanID = 165572, BgPositionIDs = '11561711' UNION ALL
  SELECT BaPersonID = 154045, FaFallID = 21299, BgFinanzplanID = 156071, BgPositionIDs = '10805341' UNION ALL
  SELECT BaPersonID = 157222, FaFallID = 22895, BgFinanzplanID = 163364, BgPositionIDs = '11456226' UNION ALL
  SELECT BaPersonID = 162154, FaFallID = 58616, BgFinanzplanID = 163051, BgPositionIDs = '11429196' UNION ALL
  SELECT BaPersonID = 163228, FaFallID = 26260, BgFinanzplanID = 163508, BgPositionIDs = '11471113' UNION ALL
  SELECT BaPersonID = 163590, FaFallID = 26459, BgFinanzplanID = 158122, BgPositionIDs = '10994247' UNION ALL
  SELECT BaPersonID = 164255, FaFallID = 26837, BgFinanzplanID = 163669, BgPositionIDs = '11487520' UNION ALL
  SELECT BaPersonID = 164334, FaFallID = 26880, BgFinanzplanID = 160644, BgPositionIDs = '11223315' UNION ALL
  SELECT BaPersonID = 164761, FaFallID = 27114, BgFinanzplanID = 160513, BgPositionIDs = '11402527' UNION ALL
  SELECT BaPersonID = 168867, FaFallID = 29370, BgFinanzplanID = 153325, BgPositionIDs = '10642363' UNION ALL
  SELECT BaPersonID = 170042, FaFallID = 29988, BgFinanzplanID = 161434, BgPositionIDs = '11290613' UNION ALL
  SELECT BaPersonID = 171628, FaFallID = 30842, BgFinanzplanID = 168531, BgPositionIDs = '11815161' UNION ALL
  SELECT BaPersonID = 172053, FaFallID = 31043, BgFinanzplanID = 157542, BgPositionIDs = '11127781' UNION ALL
  SELECT BaPersonID = 173118, FaFallID = 31625, BgFinanzplanID = 158434, BgPositionIDs = '11160617' UNION ALL
  SELECT BaPersonID = 173681, FaFallID = 11, BgFinanzplanID = 162722, BgPositionIDs = '11405385' UNION ALL
  SELECT BaPersonID = 174250, FaFallID = 32205, BgFinanzplanID = 165798, BgPositionIDs = '11576423' UNION ALL
  SELECT BaPersonID = 175052, FaFallID = 32659, BgFinanzplanID = 157427, BgPositionIDs = '10949203' UNION ALL
  SELECT BaPersonID = 175307, FaFallID = 32808, BgFinanzplanID = 155789, BgPositionIDs = '10775871' UNION ALL
  SELECT BaPersonID = 176609, FaFallID = 33559, BgFinanzplanID = 159518, BgPositionIDs = '11358680' UNION ALL
  SELECT BaPersonID = 179107, FaFallID = 35040, BgFinanzplanID = 160719, BgPositionIDs = '11229842' UNION ALL
  SELECT BaPersonID = 180435, FaFallID = 55642, BgFinanzplanID = 161797, BgPositionIDs = '11319613' UNION ALL
  SELECT BaPersonID = 180816, FaFallID = 36038, BgFinanzplanID = 167292, BgPositionIDs = '11694885' UNION ALL
  SELECT BaPersonID = 182232, FaFallID = 36854, BgFinanzplanID = 157376, BgPositionIDs = '10917422' UNION ALL
  SELECT BaPersonID = 182795, FaFallID = 81924, BgFinanzplanID = 157564, BgPositionIDs = '11298522' UNION ALL
  SELECT BaPersonID = 185454, FaFallID = 38780, BgFinanzplanID = 166053, BgPositionIDs = '11625382' UNION ALL
  SELECT BaPersonID = 185716, FaFallID = 38948, BgFinanzplanID = 160020, BgPositionIDs = '11384380' UNION ALL
  SELECT BaPersonID = 187092, FaFallID = 39756, BgFinanzplanID = 163956, BgPositionIDs = '11516250' UNION ALL
  SELECT BaPersonID = 187094, FaFallID = 72202, BgFinanzplanID = 163610, BgPositionIDs = '11480576' UNION ALL
  SELECT BaPersonID = 190403, FaFallID = 41712, BgFinanzplanID = 163097, BgPositionIDs = '11432230,11432231' UNION ALL
  SELECT BaPersonID = 191584, FaFallID = 57176, BgFinanzplanID = 157973, BgPositionIDs = '10981697' UNION ALL
  SELECT BaPersonID = 191826, FaFallID = 42575, BgFinanzplanID = 157400, BgPositionIDs = '10917514' UNION ALL
  SELECT BaPersonID = 192819, FaFallID = 43220, BgFinanzplanID = 163697, BgPositionIDs = '11490986' UNION ALL
  SELECT BaPersonID = 193678, FaFallID = 43762, BgFinanzplanID = 165514, BgPositionIDs = '11557872' UNION ALL
  SELECT BaPersonID = 196903, FaFallID = 45828, BgFinanzplanID = 156241, BgPositionIDs = '10826346' UNION ALL
  SELECT BaPersonID = 197898, FaFallID = 46455, BgFinanzplanID = 160910, BgPositionIDs = '11249548' UNION ALL
  SELECT BaPersonID = 200759, FaFallID = 48365, BgFinanzplanID = 155379, BgPositionIDs = '10743611' UNION ALL
  SELECT BaPersonID = 200807, FaFallID = 48394, BgFinanzplanID = 162675, BgPositionIDs = '11401620' UNION ALL
  SELECT BaPersonID = 200885, FaFallID = 48449, BgFinanzplanID = 159972, BgPositionIDs = '11166177' UNION ALL
  SELECT BaPersonID = 201208, FaFallID = 48654, BgFinanzplanID = 163960, BgPositionIDs = '11516411' UNION ALL
  SELECT BaPersonID = 202192, FaFallID = 49333, BgFinanzplanID = 158443, BgPositionIDs = '11059088' UNION ALL
  SELECT BaPersonID = 202429, FaFallID = 49491, BgFinanzplanID = 163431, BgPositionIDs = '11489270' UNION ALL
  SELECT BaPersonID = 202748, FaFallID = 49728, BgFinanzplanID = 163356, BgPositionIDs = '11455878' UNION ALL
  SELECT BaPersonID = 203430, FaFallID = 57072, BgFinanzplanID = 157352, BgPositionIDs = '10914018' UNION ALL
  SELECT BaPersonID = 205129, FaFallID = 51415, BgFinanzplanID = 165768, BgPositionIDs = '11574636,11575016' UNION ALL
  SELECT BaPersonID = 205683, FaFallID = 51803, BgFinanzplanID = 158820, BgPositionIDs = '11050712' UNION ALL
  SELECT BaPersonID = 206029, FaFallID = 53633, BgFinanzplanID = 158405, BgPositionIDs = '11013407' UNION ALL
  SELECT BaPersonID = 206093, FaFallID = 53247, BgFinanzplanID = 162029, BgPositionIDs = '11338642' UNION ALL
  SELECT BaPersonID = 206163, FaFallID = 53461, BgFinanzplanID = 157981, BgPositionIDs = '10982982' UNION ALL
  SELECT BaPersonID = 206403, FaFallID = 53755, BgFinanzplanID = 157423, BgPositionIDs = '10921630' UNION ALL
  SELECT BaPersonID = 210469, FaFallID = 55647, BgFinanzplanID = 156855, BgPositionIDs = '10877432' UNION ALL
  SELECT BaPersonID = 211327, FaFallID = 76843, BgFinanzplanID = 166918, BgPositionIDs = '11672782' UNION ALL
  SELECT BaPersonID = 214250, FaFallID = 67787, BgFinanzplanID = 167357, BgPositionIDs = '11698953' UNION ALL
  SELECT BaPersonID = 216478, FaFallID = 59552, BgFinanzplanID = 166431, BgPositionIDs = '11640333' UNION ALL
  SELECT BaPersonID = 220028, FaFallID = 56909, BgFinanzplanID = 159166, BgPositionIDs = '11685654' UNION ALL
  SELECT BaPersonID = 220395, FaFallID = 61799, BgFinanzplanID = 162818, BgPositionIDs = '11412745' UNION ALL
  SELECT BaPersonID = 220685, FaFallID = 61987, BgFinanzplanID = 157914, BgPositionIDs = '10974846' UNION ALL
  SELECT BaPersonID = 221784, FaFallID = 62618, BgFinanzplanID = 156492, BgPositionIDs = '10856334' UNION ALL
  SELECT BaPersonID = 223307, FaFallID = 63555, BgFinanzplanID = 166642, BgPositionIDs = '11703717' UNION ALL
  SELECT BaPersonID = 224004, FaFallID = 64005, BgFinanzplanID = 160801, BgPositionIDs = '11239574' UNION ALL
  SELECT BaPersonID = 224740, FaFallID = 64433, BgFinanzplanID = 154610, BgPositionIDs = '10670114' UNION ALL
  SELECT BaPersonID = 225084, FaFallID = 64661, BgFinanzplanID = 155608, BgPositionIDs = '10761460' UNION ALL
  SELECT BaPersonID = 225356, FaFallID = 64819, BgFinanzplanID = 163725, BgPositionIDs = '11495596' UNION ALL
  SELECT BaPersonID = 226297, FaFallID = 24233, BgFinanzplanID = 156393, BgPositionIDs = '10842924' UNION ALL
  SELECT BaPersonID = 226343, FaFallID = 65389, BgFinanzplanID = 161410, BgPositionIDs = '11288805' UNION ALL
  SELECT BaPersonID = 229035, FaFallID = 66954, BgFinanzplanID = 167881, BgPositionIDs = '11753832' UNION ALL
  SELECT BaPersonID = 232227, FaFallID = 50945, BgFinanzplanID = 158768, BgPositionIDs = '11048975' UNION ALL
  SELECT BaPersonID = 232306, FaFallID = 68950, BgFinanzplanID = 159755, BgPositionIDs = '11149135' UNION ALL
  SELECT BaPersonID = 233100, FaFallID = 69422, BgFinanzplanID = 159848, BgPositionIDs = '11525658' UNION ALL
  SELECT BaPersonID = 233286, FaFallID = 69539, BgFinanzplanID = 160555, BgPositionIDs = '11216558' UNION ALL
  SELECT BaPersonID = 233340, FaFallID = 69573, BgFinanzplanID = 163109, BgPositionIDs = '11432842' UNION ALL
  SELECT BaPersonID = 233401, FaFallID = 74886, BgFinanzplanID = 159572, BgPositionIDs = '11133974' UNION ALL
  SELECT BaPersonID = 234338, FaFallID = 70090, BgFinanzplanID = 164068, BgPositionIDs = '11542607' UNION ALL
  SELECT BaPersonID = 235844, FaFallID = 70957, BgFinanzplanID = 168661, BgPositionIDs = '11832122' UNION ALL
  SELECT BaPersonID = 236065, FaFallID = 71105, BgFinanzplanID = 156159, BgPositionIDs = '10814404' UNION ALL
  SELECT BaPersonID = 239553, FaFallID = 73146, BgFinanzplanID = 162700, BgPositionIDs = '11407395' UNION ALL
  SELECT BaPersonID = 239963, FaFallID = 73404, BgFinanzplanID = 161208, BgPositionIDs = '11326422' UNION ALL
  SELECT BaPersonID = 240158, FaFallID = 73518, BgFinanzplanID = 167176, BgPositionIDs = '11688998' UNION ALL
  SELECT BaPersonID = 241596, FaFallID = 74406, BgFinanzplanID = 158329, BgPositionIDs = '11008151' UNION ALL
  SELECT BaPersonID = 241916, FaFallID = 74521, BgFinanzplanID = 165303, BgPositionIDs = '11543705' UNION ALL
  SELECT BaPersonID = 243367, FaFallID = 75515, BgFinanzplanID = 163660, BgPositionIDs = '11485881' UNION ALL
  SELECT BaPersonID = 243586, FaFallID = 75681, BgFinanzplanID = 165239, BgPositionIDs = '11540499' UNION ALL
  SELECT BaPersonID = 244091, FaFallID = 75978, BgFinanzplanID = 156914, BgPositionIDs = '10881882' UNION ALL
  SELECT BaPersonID = 244126, FaFallID = 76001, BgFinanzplanID = 159238, BgPositionIDs = '11092131' UNION ALL
  SELECT BaPersonID = 245816, FaFallID = 76959, BgFinanzplanID = 166223, BgPositionIDs = '11618369' UNION ALL
  SELECT BaPersonID = 245919, FaFallID = 77012, BgFinanzplanID = 159579, BgPositionIDs = '11134550' UNION ALL
  SELECT BaPersonID = 246816, FaFallID = 77561, BgFinanzplanID = 168851, BgPositionIDs = '11852009' UNION ALL
  SELECT BaPersonID = 249134, FaFallID = 78875, BgFinanzplanID = 157320, BgPositionIDs = '10912508' UNION ALL
  SELECT BaPersonID = 249409, FaFallID = 79039, BgFinanzplanID = 159398, BgPositionIDs = '11120069' UNION ALL
  SELECT BaPersonID = 249742, FaFallID = 79252, BgFinanzplanID = 161941, BgPositionIDs = '11330083' UNION ALL
  SELECT BaPersonID = 249963, FaFallID = 79386, BgFinanzplanID = 160584, BgPositionIDs = '11218923' UNION ALL
  SELECT BaPersonID = 249970, FaFallID = 79391, BgFinanzplanID = 161939, BgPositionIDs = '11329861' UNION ALL
  SELECT BaPersonID = 252567, FaFallID = 81025, BgFinanzplanID = 161866, BgPositionIDs = '11325189' UNION ALL
  SELECT BaPersonID = 253637, FaFallID = 81659, BgFinanzplanID = 160355, BgPositionIDs = '11751269' UNION ALL
  SELECT BaPersonID = 254618, FaFallID = 82246, BgFinanzplanID = 161916, BgPositionIDs = '11553398' UNION ALL
  SELECT BaPersonID = 254940, FaFallID = 82452, BgFinanzplanID = 162763, BgPositionIDs = '11408377' UNION ALL
  SELECT BaPersonID = 255198, FaFallID = 82609, BgFinanzplanID = 165500, BgPositionIDs = '11556164' UNION ALL
  SELECT BaPersonID = 256311, FaFallID = 83279, BgFinanzplanID = 166462, BgPositionIDs = '11643292' 
  -- stop paste and remove last UNION ALL
)
INSERT INTO dbo.MigBgFinanzplanSkos2016 (BgFinanzplanID, FaFallID, FaLeistungID, BaPersonID, BgBudgetID_Master, WhHilfeTypCode, WhGrundbedarfTypCode, GeplantBis, AnzahlPersonUE, FpMitMizPosition, BgPositionIDs_MIZ, Created)
  SELECT 
    FPL.BgFinanzplanID,
    LEI.FaFallID,
    LEI.FaLeistungID,
    LEI.BaPersonID, 
    BgBudgetID_Master = BDG.BgBudgetID,
    FPL.WhHilfeTypCode,
    FPL.WhGrundbedarfTypCode,
    GeplantBis        = ISNULL(FPL.DatumBis, FPL.GeplantBis),
    AnzahlPersonUE    = FPP.AnzahlPersonUE,
    FpMitMizPosition  = 1,
    BgPositionIDs_Miz = CTE.BgPositionIDs,
    Created             = @StartTime
  FROM dbo.BgFinanzplan       FPL WITH (READUNCOMMITTED)
    INNER JOIN MizPosCTE      CTE ON CTE.BgFinanzplanID = FPL.BgFinanzplanID
    INNER JOIN dbo.BgBudget   BDG ON BDG.BgFinanzplanID = FPL.BgFinanzplanID
                                 AND BDG.MasterBudget = 1
    INNER JOIN dbo.FaLeistung LEI ON LEI.FaLeistungID = FPL.FaLeistungID       
    CROSS APPLY (SELECT AnzahlPersonUE = COUNT(1)
                 FROM dbo.BgFinanzplan_BaPerson
                 WHERE BgFinanzplanID = FPL.BgFinanzplanID
                   AND IstUnterstuetzt = 1) FPP   
  WHERE 1=1


PRINT ('      ' + ISNULL(CONVERT(VARCHAR(MAX), @@ROWCOUNT), 0) + ' FPs mit einer MIZ-Position');


-- zusätzliche Spalten in Mig-Tabelle setzen
UPDATE MIG
  SET NextFpAlreadyExists = CASE WHEN EXISTS (SELECT TOP 1 1
                                              FROM dbo.BgFinanzplan WITH (READUNCOMMITTED)
                                              WHERE FaLeistungID = MIG.FaLeistungID
                                                AND ISNULL(DatumVon, GeplantVon) >= @Stichtag)
                              THEN 1
                              ELSE 0
                            END
FROM dbo.MigBgFinanzplanSkos2016 MIG
WHERE Created >= @StartTime;


INSERT INTO @Finanzplan (BgFinanzplanID, FaLeistungID, BgBudgetID_Master, WhHilfeTypCode, WhGrundbedarfTypCode, GeplantBis, AnzahlPersonUE, FpMitGbl110, FpMitGbl121, FpMitMizPosition, FpMitNur1PersonAlter1825, BgPositionIDs_Izu1825, BgPositionIDs_Miz, GBL_Betrag, NextFpAlreadyExists)
  SELECT 
    BgFinanzplanID, 
    FaLeistungID,
    BgBudgetID_Master,
    WhHilfeTypCode            = WhHilfeTypCode,
    WhGrundbedarfTypCode      = WhGrundbedarfTypCode, 
    GeplantBis                = MIN(GeplantBis), 
    AnzahlPersonUE            = MAX(AnzahlPersonUE), 
    FpMitGbl110               = MAX(CONVERT(INT, FpMitGbl110)), 
    FpMitGbl121               = MAX(CONVERT(INT, FpMitGbl121)), 
    FpMitMizPosition          = MAX(CONVERT(INT, FpMitMizPosition)), 
    FpMitNur1PersonAlter1825  = MAX(CONVERT(INT, FpMitNur1PersonAlter1825)),
    BgPositionIDs_Izu1825     = dbo.ConcDistinct(ISNULL(BgPositionIDs_Izu1825, '')),
    BgPositionIDs_Miz         = dbo.ConcDistinct(ISNULL(BgPositionIDs_Miz, '')),
    GBL_Betrag                = MAX(ISNULL(GBL_Betrag, 0)),
    NextFpAlreadyExists       = MAX(CONVERT(INT, NextFpAlreadyExists))
  FROM dbo.MigBgFinanzplanSkos2016 MIG
  WHERE Created >= @StartTime
-- debug
--  AND BgFinanzplanID IN (155788, 155888, 165947)
-- end debug
  GROUP BY BgFinanzplanID, FaLeistungID, BgBudgetID_Master, WhHilfeTypCode, WhGrundbedarfTypCode;

-- prepare vars for loop
SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

PRINT('Info: Anzahl Finanzpläne = ' + CONVERT(VARCHAR(MAX), @EntriesCount));

-- debug
--SELECT * FROM @Finanzplan 
-- end debug

-------------------------------------------------------------------------------
-- loop all entries
-------------------------------------------------------------------------------
WHILE (@EntriesIterator <= @EntriesCount)
BEGIN
  -- get current entry
  SELECT
    @BgFinanzplanID            = TMP.BgFinanzplanID, 
    @FaLeistungID              = TMP.FaLeistungID, 
    @BgBudgetID_Master         = TMP.BgBudgetID_Master,
    @WhHilfeTypCode            = TMP.WhHilfeTypCode,
    @WhGrundbedarfTypCode      = TMP.WhGrundbedarfTypCode, 
    @GeplantBis                = TMP.GeplantBis, 
    @AnzahlPersonUE            = TMP.AnzahlPersonUE, 
    @GBL_Betrag                = TMP.GBL_Betrag,
    @FpMitGbl110               = TMP.FpMitGbl110, 
    @FpMitGbl121               = TMP.FpMitGbl121, 
    @FpMitMizPosition          = TMP.FpMitMizPosition, 
    @FpMitNur1PersonAlter1825  = TMP.FpMitNur1PersonAlter1825,
    @BgPositionIDs_Izu1825     = TMP.BgPositionIDs_Izu1825,
    @BgPositionIDs_Miz         = TMP.BgPositionIDs_Miz,
    @NextFpAlreadyExists       = TMP.NextFpAlreadyExists
  FROM @Finanzplan TMP
  WHERE TMP.ID = @EntriesIterator;
  

  -------------------------------------------------------------------------------
  BEGIN TRY
    --TestTran BEGIN TRAN
    BEGIN TRAN
    -----------------------------------------------
    -- MIZ-Positionen terminieren
    -----------------------------------------------
    IF (@FpMitMizPosition = 1)
    BEGIN
      UPDATE POS
        SET DatumBis = @StichtagVortag
      FROM dbo.BgPosition POS
      WHERE BgBudgetID = @BgBudgetID_Master
        AND BgPositionID IN (SELECT CONVERT(INT, SplitValue)
                              FROM dbo.fnSplitStringToValues(@BgPositionIDs_Miz, ',', 1))
      PRINT ('    ' + ISNULL(CONVERT(VARCHAR(MAX), @@ROWCOUNT), '0') + ' MIZ-Positionen terminiert: ' + @BgPositionIDs_Miz);

      -- Fallverlaufsprotokoll
      SET @Text = 'Automatisch terminierte MIZ-Finanzplan-Position per ' + CONVERT(varchar, @StichtagVortag, 104) + '  in Folge GBL-Anpassung SKOS-Richtlinien. (FP' + CONVERT(VARCHAR(MAX), @BgFinanzplanID) + ')'
      EXECUTE dbo.spFaInsertFVProtokoll NULL /*FaFallID*/, 
                                        @FaLeistungID, 
                                        NULL /*BaPersonID*/, 
                                        @UserID_kiss_sys /* = kiss_sys*/, 
                                        1 /* = FaJournalCode*/,
                                        @Text
      
    END;
    --TestTran COMMIT
    COMMIT

    --TestTran BEGIN TRAN
    BEGIN TRAN
    
    SET @PrintMsg = CONVERT(VARCHAR(30), @EntriesIterator) + ': ' + CONVERT(VARCHAR(30), @BgFinanzplanID);
    PRINT @PrintMsg;
    
    SET @BgFinanzplanID_Neu = NULL;
    
    IF (@NextFpAlreadyExists = 1)
    BEGIN
      RAISERROR('Folgefinanzplan ist bereits vorhanden', 18, 1);
    END;

    -- alle grauen Budgets nach Stichtag löschen
    DECLARE cBudget CURSOR FOR
      SELECT BgBudgetID
      FROM dbo.BgBudget   BBG
      WHERE BBG.BgFinanzplanID = @BgFinanzplanID 
        AND BBG.MasterBudget = 0 
        AND BBG.BgBewilligungStatusCode < 5
        AND dbo.fnDateSerial(BBG.Jahr, BBG.Monat, 1) > @Stichtag

    OPEN cBudget
    WHILE 1 = 1 BEGIN
    FETCH NEXT FROM cBudget INTO @BgBudgetID
      IF @@FETCH_STATUS != 0 BREAK
      PRINT ('    graues Budget nach Stichtag löschen (ID = ' + CONVERT(VARCHAR(MAX), @BgBudgetID) + ')');
      EXECUTE dbo.spWhBudget_Delete @BgBudgetID
      DELETE FROM dbo.BgBudget WHERE BgBudgetID = @BgBudgetID
    END
    CLOSE cBudget
    DEALLOCATE cBudget
        
    
    -----------------------------------------------
    -- bei 18-25 Jährigen mit GBL 120 muss kein neuen FP erstellt werden
    -- siehe Kommentar von Claudia vom 11.01.2016 https://jira.bedag.ch/browse/KZH-2122?focusedCommentId=202404&page=com.atlassian.jira.plugin.system.issuetabpanels:comment-tabpanel#comment-202404
    -----------------------------------------------
    IF (@FpMitNur1PersonAlter1825 = 1 AND @WhGrundbedarfTypCode = 32019) -- GBL 120
    BEGIN
      RAISERROR('bei 18-25 Jährigen mit GBL 120 muss kein neuen FP erstellt werden', 18, 1);
    END;
    
    -----------------------------------------------
    -- bei 18-25 Jährigen mit GBL 121 und GBL-Betrag != 986.00 oder 938.00 muss kein neuen FP erstellt werden
    -- siehe Kommentar von Claudia vom 18.01.2016 https://jira.bedag.ch/browse/KZH-2122?focusedCommentId=202960&page=com.atlassian.jira.plugin.system.issuetabpanels:comment-tabpanel#comment-202960
    -----------------------------------------------
    IF (@FpMitNur1PersonAlter1825 = 1 AND @WhGrundbedarfTypCode = 3102 AND @GBL_Betrag <> 986.00 AND @GBL_Betrag <> 938.00 ) -- GBL 121
    BEGIN
      RAISERROR('bei 18-25 Jährigen mit GBL 121 und GBL-Betrag ungleich 986.00 oder 938.00 muss kein neuen FP erstellt werden', 18, 1);
    END;
    
    -----------------------------------------------
    -- FP terminieren und wieder eröffnen
    -----------------------------------------------
    IF ((@AnzahlPersonUE > 5 AND (@FpMitGbl110 = 1 OR @FpMitGbl121 = 1))
      OR (@FpMitNur1PersonAlter1825 = 1 AND @WhGrundbedarfTypCode IN (32015, 3102))) -- GBL 110, 121
    BEGIN
      
      -----------------------------------------------
      -- bei 18-25 Jährigen mit GBL 110 von Berechnungsgrundlage 110 auf 121 ändern
      -----------------------------------------------
      IF (@FpMitNur1PersonAlter1825 = 1 AND @WhGrundbedarfTypCode = 32015)
      BEGIN
        SET @WhGrundbedarfTypCode = 3102;
        PRINT ('    Berechnungsgrundlage auf GBL 121 geändert');
      END;      

      -- neuen Finanzplan erstellen
      PRINT ('    neuen Finanzplan erstellen');
      EXECUTE spWhFinanzPlan_Create @FaLeistungID, @Stichtag, @GeplantBis, @WhHilfeTypCode, 1, @WhGrundbedarfTypCode
      
      SELECT TOP 1 @BgFinanzplanID_Neu = BgFinanzplanID
      FROM dbo.BgFinanzplan 
      WHERE FaLeistungID = @FaLeistungID 
        AND GeplantBis = @GeplantBis 
      ORDER BY BgFinanzplanID DESC;
      
      PRINT ('          mit ID ' + ISNULL(CONVERT(VARCHAR(MAX), @BgFinanzplanID_Neu), 'NULL'));
      
      -----------------------------------------------
      -- GBL-Betrag anpassen bei FP mit GBL 121
      -----------------------------------------------
      IF (@FpMitGbl121 = 1)
      BEGIN
        SET @GBL_Betrag_Neu = CONVERT(MONEY, dbo.fnXConfig('System\Sozialhilfe\SKOS2005\GBL\' + CONVERT(VARCHAR(MAX), @AnzahlPersonUE), @Stichtag));
        PRINT ('    FP mit GBL 121 --> GBL Betrag angepasst von ' + CONVERT(VARCHAR(MAX), @GBL_Betrag) + ' auf ' + CONVERT(VARCHAR(MAX), @GBL_Betrag_Neu));
        
        UPDATE POS 
          SET Betrag = @GBL_Betrag_Neu
        FROM dbo.BgPosition POS
        WHERE BgBudgetID = @BgBudgetID_Master
          AND BgPositionsartID = @WhGrundbedarfTypCode
          AND BgKategorieCode = 2
      END;
      
      PRINT ('    beendeten Finanzplan anpassen und Bewilligungseintrag erfassen. Neuen Finanzplan anpassen. Fallverlaufsprotokoll erfassen.');
      -- beendeten Finanzplan anpassen
      UPDATE BgFinanzplan 
        SET Bemerkung = 'Automatisch terminierter Finanzplan per ' + CONVERT(varchar, @StichtagVortag, 104) + ' in Folge GBL-Anpassung SKOS-Richtlinien.' + ISNULL(' ' + CONVERT(varchar, Bemerkung), ''),
            DatumBis = @StichtagVortag,
            BgGrundAbschlussCode = 4 -- Signifikante Änderung der finanziellen Situation
      WHERE BgFinanzplanID = @BgFinanzplanID

      -- neuen Finanzplan anpassen
      UPDATE BgFinanzplan 
        SET Bemerkung = 'Automatisch wieder eröffneter Finanzplan per ' + CONVERT(varchar, @Stichtag, 104) + '  in Folge GBL-Anpassung SKOS-Richtlinien.' + ISNULL(' ' + CONVERT(varchar, Bemerkung), ''),
            UnterschriftAntrag = (SELECT TOP 1 UnterschriftAntrag FROM BgFinanzplan WHERE BgFinanzplanID = @BgFinanzplanID) -- Kopiere UnterschriftAnftrag vom alten Finanzplan
      WHERE BgFinanzplanID = @BgFinanzplanID_Neu  
                    
      -- Finanzplan-Bewilligungs-Eintrag
      INSERT INTO dbo.BgBewilligung (BgFinanzPlanID, PerDatum, BgBewilligungCode, Bemerkung, UserID, Datum)
        VALUES (@BgFinanzplanID, @StichtagVortag, 5 /* = 'Finanzplan vorzeitig beendet' */, 'Automatisch terminierter Finanzplan per ' + CONVERT(varchar, @StichtagVortag, 104) + ' in Folge GBL-Anpassung SKOS-Richtlinien.', @UserID_kiss_sys, GETDATE())

      -- Fallverlaufsprotokoll
      SET @Text = 'Automatisch terminierter und wieder eröffneter Finanzplan per ' + CONVERT(varchar, @StichtagVortag, 104) + '  in Folge GBL-Anpassung SKOS-Richtlinien. (alt FP' + CONVERT(VARCHAR(MAX), @BgFinanzplanID) + ' neu FP' + ISNULL(CONVERT(VARCHAR(MAX), @BgFinanzplanID_Neu), '-') + ')'
      EXECUTE dbo.spFaInsertFVProtokoll NULL /*FaFallID*/, 
                                        @FaLeistungID, 
                                        NULL /*BaPersonID*/, 
                                        @UserID_kiss_sys /* = kiss_sys*/, 
                                        1 /* = FaJournalCode*/,
                                        @Text

    END;

    -- update MigBgFinanzplanSkos2016
    UPDATE MIG
      SET BgFinanzplanID_Neu = @BgFinanzplanID_Neu,
          Fehlermeldung      = NULL,
          Migriert           = GETDATE()
    FROM MigBgFinanzplanSkos2016 MIG
    WHERE BgFinanzplanID = @BgFinanzplanID
      AND Created >= @StartTime;

    --TestTran COMMIT
    COMMIT
  END TRY
  BEGIN CATCH
    --TestTran ROLLBACK
    ROLLBACK
    
    -- Metadaten nachführen
    DECLARE @errormsg varchar(500)
    SET @errormsg = ERROR_MESSAGE()

    PRINT ('    ERROR: ' + @errormsg);

    UPDATE MIG
      SET Fehlermeldung           = @errormsg
    FROM MigBgFinanzplanSkos2016 MIG
    WHERE BgFinanzplanID = @BgFinanzplanID
      AND Created >= @StartTime;
    
  END CATCH
  -------------------------------------------------------------------------------

  -- prepare for next entry
  SET @EntriesIterator = @EntriesIterator + 1;
END;

SELECT 
  [Pers-Nr Leistungsträger/in W]               = PRS.BaPersonID,
  [Fall-Nr]                                    = MIG.FaFallID,
  [Finanzplan-Nr]                              = MIG.BgFinanzplanID,
  [Finanzplan-Nr Neu]                          = MIG.BgFinanzplanID_Neu,
  [Geb-Datum]                                  = CONVERT(VARCHAR, PRS.Geburtsdatum, 104),
  [Name, Vorname Leistungsträger/in W]         = PRS.NameVorname,
  [Name, Vorname Leistungsverantwortliche/r W] = USR.NameVorname,
  [Team W-Leistungsverantwortliche/r]          = USR.OrgUnit,
  MIG.MigBgFinanzplanSkos2016ID,
  MIG.FaLeistungID,
  MIG.BgBudgetID_Master,
  MIG.WhHilfeTypCode,
  [Finanzplantyp]                              = dbo.fnLOVText('WhHilfeTyp', MIG.WhHilfeTypCode),
  MIG.WhGrundbedarfTypCode,
  [Berechnungsgrundlage]                       = dbo.fnLOVText('WhGrundbedarfTyp', MIG.WhGrundbedarfTypCode),
  MIG.GeplantBis,
  [Anzahl unterstüzte Personen]                = MIG.AnzahlPersonUE,
  [FP mit GBL 110]                             = MIG.FpMitGbl110,
  [FP mit GBL 121]                             = MIG.FpMitGbl121,
  [FP mit MIZ-Position]                        = MIG.FpMitMizPosition,
  [FP mit Person 18-25 in eigenem Haushalt]    = MIG.FpMitNur1PersonAlter1825,
  [Folgefinanzplan bereits vorhanden]          = MIG.NextFpAlreadyExists,
  MIG.BgPositionIDs_Izu1825,
  MIG.BgPositionIDs_Miz,
  MIG.GBL_Betrag,
  MIG.Fehlermeldung,
  Migriert = CONVERT(VARCHAR(MAX), MIG.Migriert, 120),
  Created  = CONVERT(VARCHAR(MAX), MIG.Created, 120)
FROM dbo.MigBgFinanzplanSkos2016 MIG WITH (READUNCOMMITTED)
  LEFT JOIN dbo.FaLeistung LEI WITH (READUNCOMMITTED) ON LEI.FaLeistungID = MIG.FaLeistungID
  LEFT JOIN dbo.vwPersonSimple PRS WITH (READUNCOMMITTED) ON PRS.BaPersonID = LEI.BaPersonID
  LEFT JOIN dbo.vwUser USR ON USR.UserID = LEI.UserID
WHERE MIG.Created >= @StartTime
ORDER BY MIG.BgFinanzplanID;

PRINT ('Info: Stop at ' + CONVERT(VARCHAR(MAX), GETDATE(), 120));


SET NOCOUNT OFF;

--TestTran comment
--COMMIT
--ROLLBACK
