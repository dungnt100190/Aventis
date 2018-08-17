SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnGetAgeMortal
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnGetAgeMortal
 (@Geburtsdatum  datetime,
  @Referenzdatum datetime,
  @Todesdatum    datetime = NULL)
 RETURNS int
AS 

BEGIN

  IF( @Todesdatum IS NOT NULL AND @Todesdatum < @Referenzdatum ) BEGIN
--    RETURN '†' + CONVERT( varchar,(CONVERT(int, ((DateDiff(dd, @Geburtsdatum, @Todesdatum) + .5)/365.25)) ))
    RETURN CONVERT(int, ((DateDiff(dd, @Geburtsdatum, @Todesdatum) + .5)/365.25))
  END
  ELSE BEGIN
    RETURN (CONVERT(int, (DateDiff(dd, @Geburtsdatum, @Referenzdatum) + .5)/365.25) )
  END

  RETURN NULL
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
