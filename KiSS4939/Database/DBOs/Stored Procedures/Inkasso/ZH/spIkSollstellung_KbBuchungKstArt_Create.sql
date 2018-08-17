SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spIkSollstellung_KbBuchungKstArt_Create
GO
/*===============================================================================================
  $Archive: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkSollstellung_KbBuchungKstArt_Create.sql $
  $Author: Nweber $
  $Modtime: 14.07.10 10:39 $
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KiSS4_MASTER_ZH/Stored Procedures/spIkSollstellung_KbBuchungKstArt_Create.sql $
 * 
 * 6     14.07.10 11:35 Nweber
 * #6064: Spalte KbPeriodeID von der Tabelle KbBuchungKostenart löschen
 * 
 * 5     11.12.09 11:30 Lloreggia
 * Header aktualisiert, ALTER -> CREATE
 * 
 * 4     29.05.09 15:23 Rhesterberg
 * #4734: Neues Feld KbBuchungKostenart.PscdKennzeichen befüllen
 * 
 * 3     10.03.09 14:39 Rhesterberg
 * 
 * 2     6.01.09 13:15 Rhesterberg
 * 
 * 1     9.09.08 14:59 Aklopfenstein
 * VSS FIRST
=================================================================================================*/
/*
===================================================================================================
Author:      sozheo
Create date: 06.10.2007
Description: Erstellen der Buchungen aus Forderungen
TESTS: 
EXEC dbo.[spIkSollstellung_CreateBuchungKstArt] 


===================================================================================================
sozhew : 4.3.2008 Konten von Rahel erfasst modulID = 4 ist nur Alimente
Hauptbuchkonten Zürich (Haupt- und Teilvorgang) 
select * from BgKostenart
where modulID = 4
----------------------------------------------------------------------------------------------------------
Forderungsart                                       BgKostenartID    +/-
----------------------------------------------------------------------------------------------------------
10   ALBV Auszahlung								416              -
11   üBH  Auszahlung                                417              -
12   KKBB Auszahlung                                415              -

1    ALBV Sollstellung					            427              +
2    ALIM Vermittelt Sollstellung Kinder            433              +
2    ALIM Vermittelt Sollstellung Erwachsene        434              +
3    Kinderzulagen Sollstellung                     384              +

> 30 Betreibungskosten und andere                   429              +

Andere > 30  je nach Forderungsart wird noch definiert zur Zeit alles unter Betreibungskosten

===================================================================================================
History:
--------
06.10.2007 : sozheo : neu erstellt
10.10.2007 : sozheo : Korrekturen für eimmalige Beträge
31.10.2007 : sozheo : Neue Felder hinzugefügt
14.11.2007 : sozheo : Belegnummer korrigiert
16.11.2007 : sozheo : Kontonummern korrigiert
04.02.2008 : sozheo : Korrektur Umbennenung Tabelle KbBuchung
08.02.2008 : sozheo : Korrektur neues Datenmodell
28.02.2008 : sozheo : Korrektur Kontierungen
26.03.2008 : sozheo : Teilvorgang/Hauptvorgang korrigiert
11.05.2008 : sozheo : Splittingart eingefügt
21.05.2008 : sozheo : Forderungsartcode von KbBuchungKostenart nach KbBuchung
13.06.2008 : sozheo : Verwendungperiode korrigiert
18.06.2008 : sozheo : Fehlermeldungen verbessert
18.06.2008 : sozheo : Parameter @BgKostenartID korrigiert
27.06.2008 : sozheo : Einmalige Zahlungen eingebaut
04.08.2008 : sozheo : Alter von Forderungsartcode entfernt
21.08.2008 : sozheo : Korrekturen SQL Performance
06.11.2008 : sozheo : Anpassung für Füllen Belegart
02.03.2009 : sozheo : Korrektur für Buchungstexte
18.05.2009 : sozheo : #4734: Neues Feld KbBuchungKostenart.PscdKennzeichen befüllen
===================================================================================================
*/
CREATE PROCEDURE [dbo].[spIkSollstellung_KbBuchungKstArt_Create] 
  -- ID der Hautpbuchung:
  @KbBuchungNewID INT,
  -- Typ:
  @IkForderungartCode INT,
  -- Buchungstext:
  @Buchungstext VARCHAR(200),
  -- Person:
  @BaPersonID INT,
  -- Betrag:
  @Betrag MONEY,
  -- Belegnummer:
  @Beleg INT,
  -- BgKostenartID
  @BgKostenartID INT,
  -- @VerwPeriodeVon
  @VerwPeriodeVon DATETIME,
  -- @VerwPeriodeBis
  @VerwPeriodeBis DATETIME,
  -- @BelegArt
  @BelegArt VARCHAR(4)
AS
BEGIN
  -- SET NOCOUNT ON added to prevent extra result sets from
  -- interfering with SELECT statements.
  SET NOCOUNT ON

  -- ------------------------------------------
  -- Kontierung und Teilvorgänge bestimmen:
  -- ------------------------------------------
  -- select * from BgKostenart order by BgKostenartID
  DECLARE 
    @KArt_Haupt INT,
    @KArt_Teil INT,
    @KArt_Art VARCHAR(4),
    @KontoNr VARCHAR(10),
    @BgSplittingArt INT,
    @PscdKennzeichen VARCHAR(1)

  SELECT TOP 1
    @KArt_Haupt = CASE WHEN @IkForderungartCode IN (10,11,12,13,14,15,31,32,33) 
      THEN Hauptvorgang 
      ELSE HauptvorgangAbtretung END, 
    @KArt_Teil = CASE WHEN @IkForderungartCode IN (10,11,12,13,14,15,31,32,33) 
      THEN Teilvorgang 
      ELSE TeilvorgangAbtretung END, 
    @KArt_Art = Belegart,  
    @KontoNr = KontoNr,
    @BgSplittingArt = BgSplittingArtCode
  FROM dbo.BgKostenart WITH(READUNCOMMITTED)
  WHERE BgKostenartID = @BgKostenartID

  IF @BelegArt IS NOT NULL BEGIN
    SET @KArt_Art = @BelegArt
  END

  IF @BgKostenartID IS NULL OR @BgKostenartID = 0 BEGIN
    RETURN -1
  END
  IF (@KArt_Haupt IS NULL OR @KArt_Teil IS NULL OR @KontoNr IS NULL) BEGIN
    RETURN -2
  END

  SET @PscdKennzeichen = CASE 
    WHEN @KArt_Art = 'UB' THEN 'T'
    WHEN @IkForderungArtCode IN (10,11,12,13,14,15,31,32,102,103,104,130) THEN 'C' 
    WHEN @IkForderungArtCode IN (1,2,3,4,30,1000,1050) THEN 'D' 
    ELSE NULL 
  END


  -- --------------------------------
  -- Einfügen:
  -- --------------------------------
  INSERT INTO dbo.KbBuchungKostenart (
	KbBuchungID,
	BgKostenartID,
	BaPersonID,
	Buchungstext,
	Betrag,
    KontoNr,
	PositionImBeleg,
	Hauptvorgang,
	Teilvorgang,
	Belegart,
    VerwPeriodeVon,
    VerwPeriodeBis,
    PscdKennzeichen
  ) VALUES (
    -- KbBuchungID,
    @KbBuchungNewID,
    -- BgKostenartID
    @BgKostenartID,
    -- BaPersonID,
    @BaPersonID,
    -- Buchungstext,
    @Buchungstext, 
    -- Betrag,
    @Betrag,
    -- KontoNr,
    @KontoNr,
    -- PositionImBeleg,
    @Beleg,
    -- Hauptvorgang (Konto 3660),
    @KArt_Haupt,
    -- Teilvorgang (Konto 5110),
    @KArt_Teil,
    -- Belegart
    @KArt_Art,
    -- von
    @VerwPeriodeVon,
    -- bis
    @VerwPeriodeBis,
    -- PscdKennzeichen
    @PscdKennzeichen
  )

  RETURN 0
END

GO