SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnEditMaskText
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

CREATE FUNCTION dbo.fnEditMaskText
 (@EditMask int,
  @bewilligt bit)
 RETURNS varchar(200)
AS 

BEGIN
  DECLARE @Text varchar(2000)

  IF @bewilligt = 1
	SET @EditMask = (@EditMask & 0xFFF000) / 4096  --shift right 3 positions
  ELSE
	SET @EditMask = @EditMask & 0x000FFF

  SET @Text = ''
  IF (@EditMask & 0x0001) = 0x0001 SET @Text = @Text + ',Lö'
  IF (@EditMask & 0x0002) = 0x0002 SET @Text = @Text + ',CHF-'
  IF (@EditMask & 0x0004) = 0x0004 SET @Text = @Text + ',CHF+'
  IF (@EditMask & 0x0008) = 0x0008 SET @Text = @Text + ',Neu'
  IF (@EditMask & 0x0010) = 0x0010 SET @Text = @Text + ',Grp'
  IF (@EditMask & 0x0020) = 0x0020 SET @Text = @Text + ',Art'
  IF (@EditMask & 0x0040) = 0x0040 SET @Text = @Text + ',Txt'
  IF (@EditMask & 0x0080) = 0x0080 SET @Text = @Text + ',Prs'
  IF (@EditMask & 0x0100) = 0x0100 SET @Text = @Text + ',Bem'
  IF (@EditMask & 0x0200) = 0x0200 SET @Text = @Text + ',CHF-R'
  IF (@EditMask & 0x0400) = 0x0400 SET @Text = @Text + ',GrpF'

  IF Len(@Text) > 0 SET @Text = SubString(@Text,2,2000)
  RETURN @Text
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
