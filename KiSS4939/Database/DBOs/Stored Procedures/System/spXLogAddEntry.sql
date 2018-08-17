SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject spXLogAddEntry;
GO
/*===============================================================================================
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Adds a new entry in log table XLog with given paramters
    @Source:         Source of the log-entry, defined as Namespace.ClassName
    @SourceKey:      Additional optional code within source to indentify any specific key within one
                     source (e.g. any specific type of logging entry)
    @LogLevel:       0 = Debug, 1 = Info, 2 = Warning, 3 = Error, 4 = Fatal
    @LogMessage:     Log-message or error-message
    @Comment:        Additional comment for given log-entry
    @ReferenceTable: Name of any referenced table for given log-entry. Combined with ReferenceID,
                     this will identify the affected data-row within given table
    @ReferenceID:    Unique key (primarykey) within given ReferenceTable that is affected for
                     current log-entry
    @NonPurgeable:   Flag, if an log-entry can be deleted when purging (=0) or has remain forever (=1)
    @UserID:         UserID of the user who creates the new log-entry
  -
  RETURNS: Nothing to return
=================================================================================================
  TEST:    EXEC dbo.spXLogAddEntry 'source', 0, 1, 'log message', 'comment', 'table', -1, 0, 2
=================================================================================================*/

CREATE PROCEDURE dbo.spXLogAddEntry
(
  @Source VARCHAR(255),
  @SourceKey INT = 0,
  @LogLevel INT,
  @LogMessage VARCHAR(MAX),
  @Comment VARCHAR(MAX),
  @ReferenceTable VARCHAR(100),
  @ReferenceID INT,
  @NonPurgeable BIT = 0,
  @UserID INT = -1
)
AS 
BEGIN
  -------------------------------------------------------------------------------
  -- start call
  -------------------------------------------------------------------------------
  SET NOCOUNT ON;
  
  -------------------------------------------------------------------------------
  -- get creator/modifier
  -------------------------------------------------------------------------------
  DECLARE @DBRowCreatorModifier VARCHAR(255);
  SET @DBRowCreatorModifier = dbo.fnGetDBRowCreatorModifier(@UserID);
  
  -------------------------------------------------------------------------------
  -- insert entry
  -------------------------------------------------------------------------------
  INSERT INTO dbo.XLog (Source, SourceKey, XLogLevelCode, Message, Comment, ReferenceTable, ReferenceID, NonPurgeable, Creator, Modifier)
  VALUES (@Source, @SourceKey, @LogLevel, @LogMessage, @Comment, @ReferenceTable, @ReferenceID, @NonPurgeable, @DBRowCreatorModifier, @DBRowCreatorModifier);
END;
GO