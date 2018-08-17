SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spZSetIDs
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
CREATE  PROCEDURE dbo.spZSetIDs
(
  @BaPersonSeed      int,
  @BaInstitutionSeed int,
  @idAA              bigint,
  @idALIM            bigint,
  @idE7              bigint,
  @idE9              bigint,
  @idIK              bigint,
  @idMG              bigint,
  @idS2              bigint,
  @idS3              bigint,
  @idS4              bigint,
  @idS5              bigint,
  @idST              bigint,
  @idWSH1            bigint,
  @idWV              bigint
)
AS


DBCC CHECKIDENT('BaPerson',      RESEED, @BaPersonSeed)
DBCC CHECKIDENT('BaInstitution', RESEED, @BaInstitutionSeed)

UPDATE PscdKeySource
SET NextID = @idAA
WHERE KeyName = 'AA'

UPDATE PscdKeySource
SET NextID = @idALIM
WHERE KeyName = 'ALIM'

UPDATE PscdKeySource
SET NextID = @idE7
WHERE KeyName = 'E7'

UPDATE PscdKeySource
SET NextID = @idE9
WHERE KeyName = 'E9'

UPDATE PscdKeySource
SET NextID = @idIK
WHERE KeyName = 'IK'

UPDATE PscdKeySource
SET NextID = @idMG
WHERE KeyName = 'MG'

UPDATE PscdKeySource
SET NextID = @idS2
WHERE KeyName = 'S2'

UPDATE PscdKeySource
SET NextID = @idS3
WHERE KeyName = 'S3'

UPDATE PscdKeySource
SET NextID = @idS4
WHERE KeyName = 'S4'

UPDATE PscdKeySource
SET NextID = @idS5
WHERE KeyName = 'S5'

UPDATE PscdKeySource
SET NextID = @idST
WHERE KeyName = 'ST'

UPDATE PscdKeySource
SET NextID = @idWSH1
WHERE KeyName = 'WSH1'

UPDATE PscdKeySource
SET NextID = @idWV
WHERE KeyName = 'WV'
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
