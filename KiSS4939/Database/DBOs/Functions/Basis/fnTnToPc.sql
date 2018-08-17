SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnTnToPc;
GO
/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
           --> see "vwKreditor_vwInstitution_vwPerson_DependingFNs.sql" for (re)creation!
    @Param1   .
    @Param20: .
  -
  RETURNS: .
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnTnToPc 
(
  @TN VARCHAR(9)
)
RETURNS VARCHAR(11) WITH SCHEMABINDING
AS 
BEGIN
  DECLARE @Result VARCHAR(11);
  SET @Result = @TN;

  IF (LEN(@TN) = 9)
  BEGIN
    DECLARE @MidPart VARCHAR(6);

    IF SUBSTRING(@TN, 3, 5) = '00000' 
      SET @MidPart = SUBSTRING(@TN, 8, 1)
    ELSE 
      IF SUBSTRING(@TN, 3, 4) = '0000' 
        SET @MidPart = SUBSTRING(@TN, 7, 2)
      ELSE 
        IF SUBSTRING(@TN, 3, 3) = '000' 
          SET @MidPart = SUBSTRING(@TN, 6, 3)
        ELSE 
          IF SUBSTRING(@TN, 3, 2) = '00' 
            SET @MidPart = SUBSTRING(@TN, 5, 4)
          ELSE 
            IF SUBSTRING(@TN, 3, 1) = '0' 
              SET @MidPart = SUBSTRING(@TN, 4, 5)
            ELSE 
              SET @MidPart = SUBSTRING(@TN, 3, 6)

    SET @Result = SUBSTRING(@TN, 1, 2) + '-' + @MidPart + '-' + SUBSTRING(@TN, 9, 1);
  END;
  
  RETURN @Result;
END;
GO