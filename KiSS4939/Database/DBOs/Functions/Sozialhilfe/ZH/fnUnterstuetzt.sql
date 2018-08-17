SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnUnterstuetzt
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Hat Bezugsperson @BaPersonID eine Unterstützung bzgl 
           Fallträger @FalltraegerID am Stichdatum @RefDate?
           1 = Ja, 0 = Nein
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnUnterstuetzt (
  @FalltraegerID int,
  @BaPersonID int,
  @RefDate datetime
)
RETURNS bit AS
BEGIN
  
  -- ist BaPersonID zum Zeitpunkt @RefDate in irgend einem Finanzplan unterstützt? 
  IF EXISTS (SELECT 1
             FROM   dbo.BgFinanzplan_BaPerson SDP WITH (READUNCOMMITTED)
                    INNER JOIN dbo.BgFinanzplan SFP WITH (READUNCOMMITTED) ON SFP.BgFinanzplanID = SDP.BgFinanzplanID
             WHERE  SDP.BaPersonID = @BaPersonID AND 
                    SDP.IstUnterstuetzt = 1 AND
                    @RefDate BETWEEN SFP.DatumVon AND IsNull(SFP.DatumBis, @RefDate))
    RETURN 1

  RETURN 0

END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
