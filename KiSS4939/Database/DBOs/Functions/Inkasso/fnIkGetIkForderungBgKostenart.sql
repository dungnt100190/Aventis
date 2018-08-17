SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnIkGetIkForderungBgKostenart;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: BgKostenartID anhand Belegdatum und IkForderungCode holen
    @Einmalig:          Flag zum wissen ob nach einmalige oder periodische Foderungen gesucht wird
    @Datum:             Datum um die Gültigkeit einzuschränken
    @IkForderungCode:   IkForderungEinmaligCode oder IkForderungPeriodischCode anhängig von @Einmalig
    @IstAlbvBerechtigt: Flag zum wissen ob die periodische Forderung ALBV-Berechtigt ist
    @IstAlbvUeberMax:   Flag zum wissen ob die periodische Forderung den ALBV max. Beitrag übersteigt
    @IstUnterstuetzt:   Flag zum wissen ob die periodische Forderung ein Unterstützungsfall ist
  -
  RETURNS: IkForderungBgKostenartHistID und BgKostenartID für die gegebene Forderung
  -
  TEST:    SELECT * FROM dbo.fnIkGetIkForderungBgKostenart(0, GETDATE(), 1, 0, 0, 0);
=================================================================================================*/

CREATE FUNCTION dbo.fnIkGetIkForderungBgKostenart
(
  @Einmalig BIT,
  @Datum DATETIME,
  @IkForderungCode INT,
  @IstAlbvBerechtigt BIT = 0,
  @IstAlbvUeberMax BIT = 0,
  @IstUnterstuetzt BIT = 0
)
RETURNS @Result TABLE
(
  ID INT NOT NULL IDENTITY(1, 1),
  IkForderungBgKostenartHistID INT, 
  BgKostenartID INT
)
AS
BEGIN
  SET @Einmalig = ISNULL(@Einmalig, 1)
  SET @Datum = ISNULL(@Datum, GETDATE());

  INSERT INTO @Result(IkForderungBgKostenartHistID, BgKostenartID)
    SELECT 
      IkForderungBgKostenartHistID,
      BgKostenartID
    FROM dbo.IkForderungBgKostenartHist FKH WITH (READUNCOMMITTED)
    WHERE @Datum BETWEEN ISNULL(DatumVon, '17530101') AND ISNULL(DatumBis, '99991231')
      AND ((@Einmalig = 1 
            AND IkForderungEinmaligCode = @IkForderungCode)
        OR (@Einmalig = 0 
            AND IkForderungPeriodischCode = @IkForderungCode
            AND IstAlbvBerechtigt = @IstAlbvBerechtigt
            AND IstAlbvUeberMax = @IstAlbvUeberMax
            AND IstUnterstuetzungsfall = @IstUnterstuetzt)
          );

  RETURN;
END;
GO
