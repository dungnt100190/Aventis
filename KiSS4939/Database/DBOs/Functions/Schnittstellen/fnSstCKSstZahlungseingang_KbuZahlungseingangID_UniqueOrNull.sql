SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnSstCKSstZahlungseingang_KbuZahlungseingangID_UniqueOrNull;
GO
/*===============================================================================================
  $Revision: 1 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Checks if the given KbuZahlungseingangID is either NULL or UNIQUE within the table
           SstZahlungseingang.
    @SstZahlungseingangID: The id of the current row to insert or update
    @KbuZahlungseingangID: The id of the KbuZahlungseingang which has to be NULL or UNIQUE
  -
  RETURNS: 0 if no problems were detected or 1 if the KbuZahlungseingang is not UNIQUE
=================================================================================================
  TEST:    SELECT dbo.fnSstCKSstZahlungseingang_KbuZahlungseingangID_UniqueOrNull(NULL, NULL);
=================================================================================================*/

CREATE FUNCTION dbo.fnSstCKSstZahlungseingang_KbuZahlungseingangID_UniqueOrNull
(
  @SstZahlungseingangID INT,
  @KbuZahlungseingangID INT
)
RETURNS BIT
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- check
  -----------------------------------------------------------------------------
  IF (@KbuZahlungseingangID IS NULL OR
      NOT EXISTS (SELECT TOP 1 1
                  FROM dbo.SstZahlungseingang SZE
                  WHERE SZE.SstZahlungseingangID <> ISNULL(@SstZahlungseingangID, -1)
                    AND SZE.KbuZahlungseingangID IS NOT NULL
                    AND SZE.KbuZahlungseingangID = ISNULL(@KbuZahlungseingangID, -1)))
  BEGIN
    -- valid
    RETURN 0;
  END;
  
  -----------------------------------------------------------------------------
  -- invalid
  -----------------------------------------------------------------------------
  RETURN 1;
END;
GO
