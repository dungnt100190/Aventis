SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnMigBuildLastname
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

CREATE FUNCTION dbo.fnMigBuildLastname
 (@Nachname          varchar(100),
  @Allianzname       varchar(100),
  @VoranstellungCode int,
  @JoinChar          varchar(1) )
 RETURNS varchar(200)
AS 

BEGIN

  RETURN CASE @VoranstellungCode
    WHEN 2 THEN -- Voranstellung 
      @Allianzname + ' ' + @Nachname
--    WHEN 3 THEN -- Weglassung
--      @Nachname
    ELSE
      @Nachname + @JoinChar + @Allianzname
  END

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
