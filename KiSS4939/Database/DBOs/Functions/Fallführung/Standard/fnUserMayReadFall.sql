SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnUserMayReadFall
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description 
     Prüfen ob der Benutzer eine Leistung lesen darf.
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnUserMayReadFall
(
  @UserID        INT,
  @FaLeistungID  INT
)
RETURNS BIT
AS 
BEGIN
  
  -- Grundberechtigungen prüfen
  IF (dbo.fnUserMayReadFallBasicCheck(@UserID, @FaLeistungID) = 1)
  BEGIN
    RETURN 1;
  END;
   
  -- Anderen Prüfungen
  DECLARE @FallfuehrungImmerLesbar  BIT,
          @ModulID INT,
          @BaPersonID INT;
  
  SET @FallfuehrungImmerLesbar = CONVERT(BIT, dbo.fnXConfig('System\Fallfuehrung\ImmerLesbar', GETDATE()));
  
  SELECT TOP 1 
    @ModulID = FLE.ModulID ,
    @BaPersonID = FLE.BaPersonID   
  FROM dbo.FaLeistung FLE WITH (READUNCOMMITTED)  
  WHERE FLE.FaLeistungID = @FaLeistungID;
    
  IF  (@ModulID = 2 AND @FallfuehrungImmerLesbar = 1)
  BEGIN
    RETURN 1;
  END;
  
  IF  (@ModulID = 2 AND @FallfuehrungImmerLesbar = 0)
  BEGIN
    -- andere Leistungen der gleichen BaPerson berücksichtigen
    IF (EXISTS(SELECT TOP 1 1
               FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
               WHERE LEI.BaPersonID = @BaPersonID
                 AND LEI.ModulID <> 2
                 AND NOT EXISTS(SELECT TOP 1 1
                                FROM dbo.FaLeistungArchiv FLA WITH (READUNCOMMITTED)
                                WHERE FLA.FaLeistungID = LEI.FaLeistungID
                                  AND FLA.CheckOut IS NULL)
                 AND dbo.fnUserMayReadFall(@UserID, LEI.FaLeistungID) = 1))
    BEGIN
      RETURN 1;
    END;
    
    -- Leistungen den verknüpften BaPersonen berücksichtigen
    IF (EXISTS(SELECT TOP 1 1
               FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
               WHERE LEI.BaPersonID <> @BaPersonID
                 AND LEI.BaPersonID IN (SELECT BaPersonID_2
                                        FROM dbo.BaPerson_Relation REL WITH (READUNCOMMITTED)
                                        WHERE BaPersonID_1 = @BaPersonID
                                          AND BaRelationID IN (1, 5, 6, 13, 27, 28, 30, 31)
                                        UNION 
                                        SELECT BaPersonID_1
                                        FROM dbo.BaPerson_Relation REL WITH (READUNCOMMITTED)
                                        WHERE BaPersonID_2 = @BaPersonID
                                          AND BaRelationID IN (1, 5, 6, 13, 27, 28, 30, 31))
                 AND NOT EXISTS(SELECT TOP 1 1
                                FROM dbo.FaLeistungArchiv FLA WITH (READUNCOMMITTED)
                                WHERE FLA.FaLeistungID = LEI.FaLeistungID
                                  AND FLA.CheckOut IS NULL)
                 AND dbo.fnUserMayReadFallBasicCheck(@UserID, LEI.FaLeistungID) = 1))
    BEGIN
      RETURN 1;
    END;
  END;

  RETURN 0;
END

GO