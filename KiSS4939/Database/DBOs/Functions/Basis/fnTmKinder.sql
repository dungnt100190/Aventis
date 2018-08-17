SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnTmKinder;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Für Textmarken Kinder: Listet alle Kinder des Klienten auf
   @BaPersonID:    .
   @Type:          .
   @Zeilenumbruch: .
  -
  RETURNS: -
=================================================================================================
  TEST:    SELECT KinderVornamen = dbo.fnTmKinder(4424, 'VornamenAlter', 0);
           SELECT KinderVornamen = dbo.fnTmKinder(4424, 'VornamenJahrgang', 0);
           --
           SELECT TOP 100 
                  Vornamen          = dbo.fnTmKinder(BaPersonID, 'Vornamen', 0),
                  VornamenAlter     = dbo.fnTmKinder(BaPersonID, 'VornamenAlter', 0),
                  VornamenJahrgang  = dbo.fnTmKinder(BaPersonID, 'VornamenJahrgang', 0),
                  NamenVornamenJahr = dbo.fnTmKinder(BaPersonID, 'NamenVornamenJahr', 0)
           FROM dbo.BaPerson WITH (READUNCOMMITTED);
 =================================================================================================*/

CREATE FUNCTION dbo.fnTmKinder 
(
  @BaPersonID INT,
  @Type VARCHAR(50),
  @Zeilenumbruch BIT
)
RETURNS VARCHAR(5000)
AS 
BEGIN
  DECLARE @Result VARCHAR(5000);
  DECLARE @Value VARCHAR(200);
  SET @Result = '';

  -- Kinder sind:
  -- 1 = Eltern : Kind
  -- 5 = Adoptiveltern : Adoptivkind
  -- 6 = Pflegeltern : Pflegkind
  -- 7 = Stiefeltern : Stiefkind
  DECLARE csrKinder CURSOR FOR
    SELECT Value =  CASE
      WHEN @Type = 'Vornamen' 
        THEN PRS.Vorname
      WHEN @Type = 'VornamenAlter' 
        THEN PRS.Vorname + ' (' + ISNULL(CONVERT(VARCHAR, dbo.fnGetAge(PRS.Geburtsdatum,GETDATE())), '??') + ')'
      WHEN @Type = 'VornamenJahrgang' 
        THEN PRS.Vorname + ' (' + ISNULL(SUBSTRING(CONVERT(VARCHAR, PRS.Geburtsdatum, 104), 7, 4), '????') + ')'
      WHEN @Type = 'NamenVornamenJahr' 
        THEN PRS.Name + ISNULL(' ' + PRS.Vorname, '') + ' (' + ISNULL(CONVERT(VARCHAR, PRS.Geburtsdatum, 104), '??.??.????') + ')'
      WHEN @Type = 'NamenVornamenGeburtInCH' 
        THEN PRS.Name + ISNULL(' ' + PRS.Vorname, '') + ', ' + ISNULL(CONVERT(VARCHAR, PRS.Geburtsdatum, 104), '??.??.????') + 
             ISNULL(CONVERT(VARCHAR, PRS.InCHSeit, 104), '')      
      ELSE ''
    END
    FROM dbo.BaPerson PRS WITH (READUNCOMMITTED)
    WHERE PRS.BaPersonID IN (SELECT REL.BaPersonID_2 
                             FROM BaPerson_Relation REL
                             WHERE REL.BaPersonID_1 = @BaPersonID 
                               AND REL.BaRelationID IN (1, 5, 6, 7)
                               AND GETDATE() BETWEEN ISNULL(REL.DatumVon, GETDATE()) AND ISNULL(REL.DatumBis, GETDATE())
                            )
    ORDER BY dbo.fnGetAge(PRS.Geburtsdatum,GETDATE()) DESC;
  
  OPEN csrKinder
  WHILE 1 = 1 
  BEGIN
    FETCH NEXT FROM csrKinder INTO @Value;
    
    IF (NOT @@FETCH_STATUS = 0)
    BEGIN
      BREAK;
    END;
    
    IF (NOT @Result = '')
    BEGIN
      IF @Zeilenumbruch = 1 BEGIN
        SET @Result = @Result + char(13) + char(10)
      END ELSE BEGIN
        SET @Result = @Result + ', '
      END
    END;
    
    SET @Result = @Result + ISNULL(@Value, '');
  END;
  
  CLOSE csrKinder;
  DEALLOCATE csrKinder;
  
  RETURN @Result;
END; 