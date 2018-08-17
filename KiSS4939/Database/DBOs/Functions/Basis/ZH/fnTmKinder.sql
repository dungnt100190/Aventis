SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnTmKinder
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Für Textmarken Kinder: Listet alle Kinder des Klienten auf
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    SELECT KinderVornamen = dbo.fnTmKinder(4424, 'VornamenAlter', 0)
           SELECT KinderVornamen = dbo.fnTmKinder(4424, 'VornamenJahrgang', 0)
=================================================================================================*/

CREATE FUNCTION dbo.fnTmKinder (
  @BaPersonID INT,
  @Type VARCHAR(50),
  @Zeilenumbruch BIT,
  @LeiblicheKinder BIT
)

RETURNS varchar(5000)
AS 

BEGIN
  DECLARE @Result VARCHAR(5000)
  DECLARE @Value VARCHAR(200)
  SET @Result = ''

  -- Kinder sind:
  -- 1 = Eltern : Kind  
  -- 6 = Pflegeltern : Pflegkind
  -- 7 = Stiefeltern : Stiefkind

  DECLARE csrKinder CURSOR FOR 

  SELECT CASE 
    WHEN @Type = 'Vornamen' THEN 
      P.Vorname 
    WHEN @Type = 'NamenVornamen' THEN 
      P.Name + IsNull(', ' + P.Vorname, '')
    WHEN @Type = 'VornamenAlter' THEN 
      P.Vorname + ' (' + ISNULL(CONVERT(VARCHAR, dbo.fnGetAge(P.Geburtsdatum,GETDATE())), '??') + ')'
    WHEN @Type = 'VornamenJahrgang' THEN 
      P.Vorname + ' (' + ISNULL(SUBSTRING(CONVERT(VARCHAR, P.Geburtsdatum, 104), 7, 4), '????') + ')'
    WHEN @Type = 'NamenVornamenJahr' THEN 
      P.Name + ISNULL(' ' + P.Vorname, '') + ' (' + ISNULL(CONVERT(VARCHAR, P.Geburtsdatum, 104), '??.??.????') + ')'
    WHEN @Type = 'NamenVornamenJahrHeimat' THEN
	  P.Name + IsNull(' ' + P.Vorname, '') + IsNull(', ' + CONVERT(VARCHAR, P.Geburtsdatum, 104), '') + IsNull(', ' + P.Nationalitaet, '') + IsNull(', ' + P.AufenthaltOrt, '')
  END
  FROM dbo.vwPerson P
  WHERE P.BaPersonID IN (
    SELECT R1.BaPersonID_2 FROM dbo.BaPerson_Relation R1 WITH (READUNCOMMITTED) 
    WHERE R1.BaPersonID_1 = @BaPersonID 
		AND ((@LeiblicheKinder = 0 AND R1.BaRelationID IN (1,6,7)) OR (@LeiblicheKinder = 1 AND R1.BaRelationID = 1))
		AND GETDATE() BETWEEN ISNULL(R1.DatumVon, GETDATE()) AND ISNULL(R1.DatumBis, GETDATE()) )
  ORDER BY dbo.fnGetAge(P.Geburtsdatum,GETDATE()) DESC 

  OPEN csrKinder

  WHILE 1 = 1 BEGIN
    FETCH NEXT FROM csrKinder INTO @Value
    IF NOT @@FETCH_STATUS = 0 BREAK
    IF NOT @Result = '' BEGIN 
		IF @Zeilenumbruch = 1 BEGIN 
			SET @Result = @Result + CHAR(13) + CHAR(10) 
		END ELSE BEGIN
			SET @Result = @Result + ', '
		END
	END
    SET @Result = @Result + ISNULL(@Value, '')
  END

  CLOSE csrKinder
  DEALLOCATE csrKinder

  RETURN @Result
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
