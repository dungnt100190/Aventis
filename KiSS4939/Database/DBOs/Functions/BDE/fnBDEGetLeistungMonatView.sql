SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnBDEGetLeistungMonatView;
GO
/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get values for overwiew of month (details)
    @UserID:       The user to get data from
    @LanguageCode: The language code used for display data
  -
  RETURNS: Table containing all neccessary fiels used for Monat in ZLE-Erfassung
  -
  TEST:    SELECT * FROM dbo.fnBDEGetLeistungMonatView(2, 1)
           SELECT * FROM dbo.fnBDEGetLeistungMonatView(515, 1)
           SELECT * FROM dbo.fnBDEGetLeistungMonatView(515, 1)
           SELECT * FROM dbo.fnBDEGetLeistungMonatView(515, 1)
=================================================================================================*/

CREATE FUNCTION dbo.fnBDEGetLeistungMonatView
(
  @UserID INT,
  @LanguageCode INT
)
RETURNS @Result TABLE
(
  Id$ INT identity(1, 1) NOT NULL PRIMARY KEY,
  UserID INT,
  Jahr INT,
  Monat INT,
  MonatText VARCHAR(50),
  MonatStartDatum datetime,
  MonatEndDatum datetime,
  EndOfLastYear DATETIME,
  Freigegeben BIT,
  Visiert BIT,
  Verbucht datetime,
  VerbuchtLD DATETIME,
  IstVerbucht BIT,
  IstVerbuchtLD BIT,
  Fakturiert BIT,
  PensumProzent INT, 
  GZIstArbeitszeitProMonat money,
  GZSollArbeitszeitProMonat money,
  GZMonatsSaldo MONEY,
  GZUebertragVorjahr money,
  GZKorrekturen money,
  GZAusbezahlteUeberstunden money,
  GZSaldo money,
  SLIstArbeitszeitProMonat MONEY,
  FerienUebertragVorjahr money,
  FerienAnspruchProJahr money,
  FerienBisherBezogen money,
  FerienBezogenMonat money,
  FerienZugabenKuerzungen money,
  FerienKorrekturen money,
  FerienSaldo money
)
AS BEGIN
  -------------------------------------------------------------------------------
  -- validate
  -------------------------------------------------------------------------------
  IF (@UserID IS NULL OR @LanguageCode IS NULL)
  BEGIN
    -- invalid values
    RETURN
  END

  -------------------------------------------------------------------------------
  -- temporary table (same as result)
  -------------------------------------------------------------------------------
  DECLARE @Temp TABLE
  (
    Id$ INT identity(1, 1) NOT NULL PRIMARY KEY,
    UserID INT,
    Jahr INT,
    Monat INT,
    MonatText VARCHAR(50),
    MonatStartDatum datetime,
    MonatEndDatum datetime,
    EndOfLastYear DATETIME,
    Freigegeben BIT,
    Visiert BIT,
    Verbucht datetime,
    VerbuchtLD DATETIME,
    IstVerbucht BIT,
    IstVerbuchtLD BIT,
    Fakturiert BIT,
    PensumProzent INT,
    GZIstArbeitszeitProMonat money,
    GZSollArbeitszeitProMonat money,
    GZMonatsSaldo MONEY,
    GZUebertragVorjahr money,
    GZKorrekturen money,
    GZAusbezahlteUeberstunden money,
    GZSaldo money,
    SLIstArbeitszeitProMonat MONEY,
    FerienUebertragVorjahr money,
    FerienAnspruchProJahr money,
    FerienBisherBezogen money,
    FerienBezogenMonat money,
    FerienZugabenKuerzungen money,
    FerienKorrekturen money,
    FerienSaldo money
  )

  -------------------------------------------------------------------------------
  -- get all recorded Leistungen with dates
  -------------------------------------------------------------------------------
  INSERT INTO @Temp (UserID, Jahr, Monat, MonatText, MonatStartDatum, MonatEndDatum,
                     GZIstArbeitszeitProMonat, GZSollArbeitszeitProMonat, GZMonatsSaldo,
                     SLIstArbeitszeitProMonat, Freigegeben, Visiert, Verbucht, VerbuchtLD,
                     IstVerbucht, IstVerbuchtLD, Fakturiert)
    SELECT UserID                    = LEI.UserID,
           Jahr                      = LEI.Jahr,
           Monat                     = LEI.Monat,
           MonatText                 = LEI.MonatText,
           MonatStartDatum           = LEI.MonatStartDatum,
           MonatEndDatum             = LEI.MonatEndDatum,
           GZIstArbeitszeitProMonat  = LEI.GZIstArbeitszeitProMonat,
           GZSollArbeitszeitProMonat = LEI.GZSollArbeitszeitProMonat,
           GZMonatsSaldo             = LEI.GZMonatsSaldo,
           SLIstArbeitszeitProMonat  = LEI.SLIstArbeitszeitProMonat,
           Freigegeben               = LEI.Freigegeben,
           Visiert                   = LEI.Visiert,
           Verbucht                  = LEI.Verbucht,
           VerbuchtLD                = LEI.VerbuchtLD,
           IstVerbucht               = LEI.IstVerbucht,
           IstVerbuchtLD             = LEI.IstVerbuchtLD,
           Fakturiert                = LEI.Fakturiert
    FROM dbo.fnBDEGetLeistungMonat(@UserID, @LanguageCode, NULL, NULL) LEI

  -----------------------------------------------------------------------------
  -- update required fields
  -----------------------------------------------------------------------------
  UPDATE TMP
  SET TMP.EndOfLastYear = dbo.fnGetDateFromInts(31, 12, YEAR(TMP.MonatStartDatum) - 1)
  FROM @Temp TMP

  -----------------------------------------------------------------------------
  -- update other data
  -- INFO: same as in dbo.fnBDEGetUebersicht
  -----------------------------------------------------------------------------
  UPDATE TMP
  SET PensumProzent              = IsNull(dbo.fnBDEGetPensumPercent(@UserID, TMP.MonatEndDatum), 0),
      GZUebertragVorjahr         = IsNull(dbo.fnBDEGetGleitzeitSaldo(@UserID, TMP.EndOfLastYear), 0.0),             -- till end of last year
      GZKorrekturen              = IsNull(dbo.fnBDEGetGleitzeitKorrekturen(@UserID, TMP.MonatEndDatum, 1), 0.0),    -- only current year
      GZAusbezahlteUeberstunden  = IsNull(dbo.fnBDEGetAusbezahlteUeberstunden(@UserID, TMP.MonatEndDatum, 1), 0.0), -- only current year
      GZSaldo                    = IsNull(dbo.fnBDEGetGleitzeitSaldo(@UserID, TMP.MonatEndDatum), 0.0),
      FerienUebertragVorjahr     = IsNull(dbo.fnBDEGetFerienSaldo(@UserID, TMP.EndOfLastYear), 0.0),                -- till end of last year
      FerienAnspruchProJahr      = IsNull(dbo.fnBDEGetFerienAnspruch(@UserID, TMP.MonatEndDatum, 1), 0.0),          -- only current year
      FerienBisherBezogen        = IsNull(dbo.fnBDEGetErfassteFerien(@UserID, TMP.MonatEndDatum, 1), 0.0),          -- only current year
      FerienZugabenKuerzungen    = IsNull(dbo.fnBDEGetFerienZugabenKuerzungen(@UserID, TMP.MonatEndDatum, 1), 0.0), -- only current year
      FerienKorrekturen          = IsNull(dbo.fnBDEGetFerienKorrekturen(@UserID, TMP.MonatEndDatum, 1), 0.0),       -- only current year
      FerienSaldo                = IsNull(dbo.fnBDEGetFerienSaldo(@UserID, TMP.MonatEndDatum), 0.0)
  FROM @Temp TMP

  -- update FerienBezogenMonat
  UPDATE TMP
  SET FerienBezogenMonat = CASE WHEN MONTH(TMP.MonatEndDatum) = 1 THEN TMP.FerienBisherBezogen -- only current year (first month)
                                ELSE TMP.FerienBisherBezogen - IsNull(dbo.fnBDEGetErfassteFerien(@UserID, (DATEADD(d, -1, dbo.fnFirstDayOf(TMP.MonatEndDatum))), 1), 0) -- only current month within same year (end of current month - end of last month)!
                           END
  FROM @Temp TMP

  -----------------------------------------------------------------------------
  -- apply values to result and sort properly
  -----------------------------------------------------------------------------
  INSERT INTO @Result
    SELECT TMP.UserID, TMP.Jahr, TMP.Monat, TMP.MonatText, TMP.MonatStartDatum, TMP.MonatEndDatum,
           TMP.EndOfLastYear, TMP.Freigegeben, TMP.Visiert, TMP.Verbucht, TMP.VerbuchtLD,
           TMP.IstVerbucht, TMP.IstVerbuchtLD, TMP.Fakturiert, TMP.PensumProzent, TMP.GZIstArbeitszeitProMonat,
           TMP.GZSollArbeitszeitProMonat, TMP.GZMonatsSaldo, TMP.GZUebertragVorjahr, TMP.GZKorrekturen,
           TMP.GZAusbezahlteUeberstunden, TMP.GZSaldo, TMP.SLIstArbeitszeitProMonat,
           TMP.FerienUebertragVorjahr, TMP.FerienAnspruchProJahr, TMP.FerienBisherBezogen,
           TMP.FerienBezogenMonat, TMP.FerienZugabenKuerzungen, TMP.FerienKorrekturen, TMP.FerienSaldo
    FROM @Temp TMP
    ORDER BY TMP.Jahr DESC, TMP.Monat DESC

  -----------------------------------------------------------------------------
  -- done
  -----------------------------------------------------------------------------
  RETURN
END
GO