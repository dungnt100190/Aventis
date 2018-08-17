SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnGetAge;
GO
/*===============================================================================================
  $Revision: 6 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Calculate the approximate age using birthday and reference date
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Geburtsdatum:  The birthday date to use (has to be <= @Referenzdatum)
    @Referenzdatum: The reference date to use to calculate the age
  -
  RETURNS: Approximate age depending on given birthday-date and reference date or NULL if invalid
=================================================================================================
  TEST:    SELECT dbo.fnGetAge('2000-01-01', GETDATE());
           SELECT dbo.fnGetAge('2000-01-01', '1999-12-31');
           --
           SELECT dbo.fnGetAge(PRS.Geburtsdatum, ISNULL(PRS.Sterbedatum, GETDATE())));
=================================================================================================*/

CREATE FUNCTION dbo.fnGetAge
(
  @Geburtsdatum  DATETIME,
  @Referenzdatum DATETIME
)
RETURNS INT WITH SCHEMABINDING
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- validate parameters
  -----------------------------------------------------------------------------
  IF (@Geburtsdatum = NULL OR @Referenzdatum = NULL)
  BEGIN
    RETURN NULL;
  END;
  
  -----------------------------------------------------------------------------
  -- check if birthday is not yet over
  -----------------------------------------------------------------------------
  IF (@Referenzdatum < @Geburtsdatum)
  BEGIN
    -- no age yet
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- calculate and return approximate age
  -----------------------------------------------------------------------------
  RETURN (CONVERT(INT, ((DATEDIFF(dd, @Geburtsdatum, @Referenzdatum) + 0.5) / 365.25)));
END;
GO