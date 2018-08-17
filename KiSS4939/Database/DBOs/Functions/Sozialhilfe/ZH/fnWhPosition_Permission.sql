SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject fnWhPosition_Permission
GO
/*===============================================================================================
  $Revision: 7 $
=================================================================================================
  Description
  Überprüft, ob der User die Budgetposition bewilligen darf.

  Ist der User Leistungsverantwortlicher, dann werden die Eigenkompetenzen geprüft.
  Ist der User nicht Leistungsverantwortlicher, dann werden die Fremdkompetenzen geprüft.

  Bei zusätzlicher Leistung wird geschaut, ob es eine Kompetenz der Positionsart gibt, bei welcher
  der Betrag grösser ist als der Betrag der Position.

  Bei allen anderen Budgetkategorien wird geschaut, ob es eine Kompetenz gibt, bei welcher
  der Betrag grösser ist als der Betrag der Position und bei der die Kompetenz folgenden PermissionCode aufweist:
   - 1: WH: FP Regulär - Lebenshaltungkosten
   - 2: WH: FP Regulär - Wiederkehrende SIL's
   - 15: WH: Notfall - Lebenshaltungskosten
   - 16: WH: Notfall - wiederkehrende SIL's
   - 5: Sozialhilfe: FP Überbrückung - Lebenshaltungkosten
   - 6: Sozialhilfe: FP Überbrückung - Wiederkehrende SIL's

-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @BgPositionID: Die Id der Position (in der Regel Einzelzahlung oder zusätzliche Leistung).
    @UserID: Die Id des Users
  -
  RETURNS: 0, wenn der User die Position nicht bewilligen darf. 1, wenn er die Position bewilligen darf.
  -
=================================================================================================
  TEST:    .
=================================================================================================*/

CREATE FUNCTION dbo.fnWhPosition_Permission
(
  @BgPositionID   INT,
  @UserID         INT
)
RETURNS BIT
BEGIN

  -------------------------------------------------------------------------------
  -- init vars and table
  -------------------------------------------------------------------------------
  DECLARE @EntriesCount INT;
  DECLARE @EntriesIterator INT;

  DECLARE @ReturnValue BIT;

  DECLARE @PermissionGroupID  INT,
	  	  @BgKategorieCode    INT,
		  @BgPositionartID    INT,
		  @Betrag             MONEY,
		  @BetragFinanzplan   MONEY;

  DECLARE @Positions TABLE
  (
	  ID INT NOT NULL IDENTITY(1, 1) PRIMARY KEY CLUSTERED,
	  BgPositionID INT,
	  PermissionGroupID INT,
	  BgKategorieCode INT,
	  BgPositionsartID INT,
	  Betrag MONEY,
	  BetragFinanzplan MONEY
  );

  -------------------------------------------------------------------------------
  -- insert entries into loop table
  -------------------------------------------------------------------------------
  INSERT INTO @Positions(PermissionGroupID, BgPositionID, BgKategorieCode, BgPositionsartID, Betrag, BetragFinanzplan)
  SELECT
    PermissionGroupID = CASE
                           WHEN LST.UserID = @UserID THEN USR.PermissionGroupID
                           ELSE USR.GrantPermGroupID
                        END,
    BgPositionID      = BgPositionID,
    BgKategorieCode   = BgKategorieCode,
    BgPositionartID   = BgPositionsartID,
    Betrag            = Betrag,
	BetragFinanzplan  = BetragFinanzplan
  FROM dbo.vwBgPosition           BPO WITH (READUNCOMMITTED)
    INNER JOIN dbo.BgBudget       BBG WITH (READUNCOMMITTED) ON BBG.BgBudgetID     = BPO.BgBudgetID
    INNER JOIN dbo.BgFinanzplan   BFP WITH (READUNCOMMITTED) ON BFP.BgFinanzplanID = BBG.BgFinanzplanID
    INNER JOIN dbo.FaLeistung     LST WITH (READUNCOMMITTED) ON LST.FaLeistungID   = BFP.FaLeistungID
    INNER JOIN dbo.XUser          USR WITH (READUNCOMMITTED) ON USR.UserID = @UserID
  WHERE BgPositionID = @BgPositionID
    OR BgPositionID_Parent = @BgPositionID;

  -- prepare vars for loop
  SET @EntriesCount = @@ROWCOUNT;  -- needs to be done just after filling!
  SET @EntriesIterator = 1;        -- needs to start just at the same value as IDENTITY column on table

  -------------------------------------------------------------------------------
  -- loop all entries
  -------------------------------------------------------------------------------
  WHILE (@EntriesIterator <= @EntriesCount)
  BEGIN
	-- get current entry
	SELECT @PermissionGroupID = TMP.PermissionGroupID,
	       @BgPositionID = TMP.BgPositionID,
		   @BgKategorieCode = TMP.BgKategorieCode,
		   @BgPositionartID = TMP.BgPositionsartID,
		   @Betrag = TMP.Betrag,
		   @BetragFinanzplan = TMP.BetragFinanzplan,
		   @ReturnValue = 0
	FROM @Positions TMP
	WHERE TMP.ID = @EntriesIterator;

	IF @BgKategorieCode = 100 --Zusätzliche Leistung
	AND EXISTS (SELECT TOP 1 1
				FROM dbo.XPermissionValue WITH (READUNCOMMITTED) 
				WHERE PermissionGroupID = @PermissionGroupID
					AND BgPositionsartID = @BgPositionartID
					AND CONVERT(money, Value) >= @Betrag)
	BEGIN
	  SET @ReturnValue = 1;
	END;

    IF @BgKategorieCode <> 100 --  z.B. Einzelzahlung
		AND EXISTS (SELECT TOP 1 1
					FROM dbo.XPermissionValue WITH (READUNCOMMITTED) 
					WHERE PermissionGroupID = @PermissionGroupID
					  AND PermissionCode IN (1, 2, 15, 16, 5, 6)
					  AND CONVERT(money, Value) >= @Betrag)
	BEGIN
	  SET @ReturnValue = 1;
	END;

	DECLARE @KvgKonti VARCHAR(MAX);
	DECLARE @KontoNrPosition VARCHAR(10);

	SET @KvgKonti = dbo.fnXConfigVarchar('System\Sozialhilfe\KontoNrKVGPraemie', GETDATE());

	SELECT @KontoNrPosition = KontoNr
	FROM dbo.BgPosition             POS WITH (READUNCOMMITTED)
	  INNER JOIN dbo.BgPositionsart BPA WITH (READUNCOMMITTED) ON BPA.BgPositionsartID = POS.BgPositionsartID
	  INNER JOIN dbo.BgKostenart    BKA WITH (READUNCOMMITTED) ON BKA.BgKostenartID = BPA.BgKostenartID
	WHERE BgPositionID = @BgPositionID;

    IF (EXISTS(SELECT TOP 1 1
               FROM dbo.fnSplit(@KvgKonti, ',')
               WHERE [Value] = @KontoNrPosition)
        AND EXISTS (SELECT TOP 1 1
                    FROM dbo.XPermissionValue WITH (READUNCOMMITTED)
                    WHERE PermissionGroupID = @PermissionGroupID
                      AND PermissionCode = 20
                      AND CONVERT(MONEY, Value) >= @BetragFinanzplan))  --Damit der Auszahl-Betrag: VVG-Betrag ./. Prämienverbilligung mit der Kompetenz verglichen wird, muss @BetragFinanzplan geprüft werden
    BEGIN
      SET @ReturnValue = 1;
    END;

	IF(@ReturnValue = 0)
	BEGIN
	  RETURN @ReturnValue;
	END
	
	-- prepare for next entry
    SET @EntriesIterator = @EntriesIterator + 1;
  END

  RETURN @ReturnValue
END
GO
SET QUOTED_IDENTIFIER OFF
GO
SET ANSI_NULLS ON
GO
