SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnFaGetProcessInfo;
GO
/*===============================================================================================
  $Revision: 5 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
   @BaPersonID:  The id of the BaPerson to get data for
   @ModulID:     The id of the module to get data for (see table XModul for data)
   @DatumVon:    The start date for searching the data
   @DatumBis:    The end date for searching the data
   @ResultMode:  The desired result to get
                 - 'processuser':       The responsible user (LastName, FirstName) who was resposible
                                        for last process of given module within search-datespan.
                 - 'processopenend':    The open-date of the first process within search-datespan.
                                        Date can be before @DatumVon if process is not finished till @DatumVon.
                 - 'processclosed':     The end-date of the last process within search-datespan.
                                        If the process ends after @DatumBis, this value will be NULL.
                 - 'closurereason':     The reason why the last process within search-datespan was closed.
                                        If the process ends after @DatumBis, this value will be NULL.
                 - 'amountofprocesses': The amount of processes of the same module within given 
                                        datespan (including those who started before and ended after
                                        given datespan).
                 - 'reopened':          Flag if there is a process before the current last process at @DatumBis
  -
  RETURNS: The desired value depending on given parameter. If something was wrong, the value '<err:...>' will be returned.
  -
  TEST:    SELECT [dbo].[fnFaGetProcessInfo](2, 2, '2008-01-01', '2008-05-01', 'processuser')
           SELECT [dbo].[fnFaGetProcessInfo](2, 7, '2000-11-06', '2000-11-08', 'processuser')
           -
           SELECT [dbo].[fnFaGetProcessInfo](2, 7, '2000-11-06', '2000-11-07', 'processopenend')
           -
           SELECT [dbo].[fnFaGetProcessInfo](2, 2, '2000-11-06', '2008-12-29', 'processclosed')
           -
           SELECT [dbo].[fnFaGetProcessInfo](2, 2, '2000-11-06', '2008-12-29', 'closurereason')
           -
           SELECT [dbo].[fnFaGetProcessInfo](75658, 2, '2000-01-01', '2009-01-08', 'amountofprocesses')
           -
           SELECT [dbo].[fnFaGetProcessInfo](75658, 2, '2004-01-01', '2005-11-16', 'reopened')
=================================================================================================*/

CREATE FUNCTION dbo.fnFaGetProcessInfo
(
  @BaPersonID INT,
  @ModulID INT,
  @DatumVon DATETIME,
  @DatumBis DATETIME,
  @ResultMode VARCHAR(50)
)
RETURNS VARCHAR(255)
AS BEGIN
  -----------------------------------------------------------------------------
  -- validate
  -----------------------------------------------------------------------------
  IF (@BaPersonID IS NULL OR @ModulID IS NULL OR @DatumVon IS NULL OR @DatumBis IS NULL OR 
      @ResultMode NOT IN ('processuser', 'processopenend', 'processclosed', 'closurereason', 'amountofprocesses', 'reopened'))
  BEGIN
    -- invalid parameters, return '-1'
    RETURN '<err:params>'
  END
  
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @ReturnValue VARCHAR(255)
  
  -----------------------------------------------------------------------------
  -- get specific value depending on given parameter
  -----------------------------------------------------------------------------
  IF (@ResultMode = 'processuser')
  BEGIN
    -- get responsible user of last process within given datespan
    SELECT TOP 1 
           @ReturnValue = dbo.fnGetLastFirstName(LEI.UserID, NULL, NULL)
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND    -- only for current person
          LEI.ModulID = @ModulID AND          -- only for given module
                                              -- only those who have some crossings with datespan
          ((dbo.fnDateOf(LEI.DatumVon) <= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumVon) OR
           (dbo.fnDateOf(LEI.DatumVon) <= @DatumBis AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumBis) OR
           (dbo.fnDateOf(LEI.DatumVon) >= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') <= @DatumBis))
    ORDER BY LEI.DatumVon DESC                -- get only last entry
  END
  -----------------------------------------------------------------------------
  ELSE IF (@ResultMode = 'processopenend')
  BEGIN
    -- get opened-date of first process within datespan
    SELECT TOP 1 
           @ReturnValue = CONVERT(VARCHAR(255), LEI.DatumVon)
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND    -- only for current person
          LEI.ModulID = @ModulID AND          -- only for given module
                                              -- only those who have some crossings with datespan
          ((dbo.fnDateOf(LEI.DatumVon) <= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumVon) OR
           (dbo.fnDateOf(LEI.DatumVon) <= @DatumBis AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumBis) OR
           (dbo.fnDateOf(LEI.DatumVon) >= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') <= @DatumBis))
    ORDER BY LEI.DatumVon ASC                -- get only first entry
  END
  -----------------------------------------------------------------------------
  ELSE IF (@ResultMode = 'processclosed')
  BEGIN
    -- get ended-date of last process within datespan (only if ended within date-span)
    SELECT TOP 1 
           @ReturnValue = CASE WHEN ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') <= @DatumBis THEN CONVERT(VARCHAR(255), LEI.DatumBis) -- closed within datespan
                               ELSE NULL
                          END
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND    -- only for current person
          LEI.ModulID = @ModulID AND          -- only for given module
                                              -- only those who have some crossings with datespan
          ((dbo.fnDateOf(LEI.DatumVon) <= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumVon) OR
           (dbo.fnDateOf(LEI.DatumVon) <= @DatumBis AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumBis) OR
           (dbo.fnDateOf(LEI.DatumVon) >= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') <= @DatumBis))
    ORDER BY LEI.DatumVon DESC                -- get only last entry
  END
  -----------------------------------------------------------------------------
  ELSE IF (@ResultMode = 'closurereason')
  BEGIN
    -- get ended-date of last process within datespan (only if ended within date-span)
    SELECT TOP 1 
           @ReturnValue = CASE WHEN ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') <= @DatumBis THEN LEI.AbschlussGrundCode -- closed within datespan
                               ELSE NULL
                          END
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND    -- only for current person
          LEI.ModulID = @ModulID AND          -- only for given module
                                              -- only those who have some crossings with datespan
          ((dbo.fnDateOf(LEI.DatumVon) <= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumVon) OR
           (dbo.fnDateOf(LEI.DatumVon) <= @DatumBis AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumBis) OR
           (dbo.fnDateOf(LEI.DatumVon) >= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') <= @DatumBis))
    ORDER BY LEI.DatumVon DESC                -- get only last entry
  END
  -----------------------------------------------------------------------------
  ELSE IF (@ResultMode = 'amountofprocesses')
  BEGIN
    -- get amount of same-type-processes within datespan
    SELECT @ReturnValue = COUNT(1)
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND    -- only for current person
          LEI.ModulID = @ModulID AND          -- only for given module
                                              -- only those who have some crossings with datespan
          ((dbo.fnDateOf(LEI.DatumVon) <= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumVon) OR
           (dbo.fnDateOf(LEI.DatumVon) <= @DatumBis AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumBis) OR
           (dbo.fnDateOf(LEI.DatumVon) >= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') <= @DatumBis))
  END
  -----------------------------------------------------------------------------
  ELSE IF (@ResultMode = 'reopened')
  BEGIN
    -- init var to store FaLeistungID at given end-date
    DECLARE @StartDateOfFaLeistungID DATETIME
  
    -- get last entry for given datespan
    SELECT TOP 1
           @StartDateOfFaLeistungID = LEI.DatumVon
    FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
    WHERE LEI.BaPersonID = @BaPersonID AND    -- only for current person
          LEI.ModulID = @ModulID AND          -- only for given module
                                              -- only those who have some crossings with datespan
          ((dbo.fnDateOf(LEI.DatumVon) <= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumVon) OR
           (dbo.fnDateOf(LEI.DatumVon) <= @DatumBis AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') >= @DatumBis) OR
           (dbo.fnDateOf(LEI.DatumVon) >= @DatumVon AND ISNULL(dbo.fnDateOf(LEI.DatumBis), '9999-12-31') <= @DatumBis))
    ORDER BY LEI.DatumVon DESC                -- get only last entry
    
    -- now, check if we have an entry before given date from above
    SET @ReturnValue = CASE WHEN EXISTS(SELECT TOP 1 1
                                        FROM dbo.FaLeistung LEI WITH (READUNCOMMITTED)
                                        WHERE LEI.BaPersonID = @BaPersonID AND         -- only for current person
                                              LEI.ModulID = @ModulID AND               -- only for given module
                                              LEI.DatumVon < @StartDateOfFaLeistungID) -- entry before given date
                                 THEN '1'
                            ELSE '0'
                       END
  END
  -----------------------------------------------------------------------------
  ELSE
  BEGIN
    -- invalid parameter, do not continue
    RETURN '<err:result>'
  END
  -----------------------------------------------------------------------------
    
  -----------------------------------------------------------------------------
  -- done, return value
  -----------------------------------------------------------------------------
  RETURN @ReturnValue
END
