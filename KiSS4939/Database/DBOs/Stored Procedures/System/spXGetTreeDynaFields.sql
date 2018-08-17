SET QUOTED_IDENTIFIER OFF 
GO
SET ANSI_NULLS ON 
GO
EXECUTE dbo.spDropObject spXGetTreeDynaFields
GO
/*===============================================================================================
  $Archive: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXGetTreeDynaFields.sql $
  $Author: Ckaeser $
  $Modtime: 23.06.09 15:08 $
  $Revision: 2 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: .
    @Param1   .
    @Param20: .
  -
  RETURNS: .
  -
  TEST:    .
=================================================================================================
  $Log: /Database/KISS4_BSS_MasterDev/Stored Procedures/spXGetTreeDynaFields.sql $
 * 
 * 2     25.06.09 8:46 Ckaeser
 * Alter2Create
 * 
 * 1     13.09.08 17:07 Aklopfenstein
 * VSS First
=================================================================================================*/

/*
  KiSS 4.0
  --------
  DB-Object: spXGetTreeDynaFields
  Branch   : KiSS_40_CORE
  BuildNr  : 1
  Datum    : 21.06.2008 19:28
*/
CREATE PROCEDURE dbo.spXGetTreeDynaFields
 (@MaskName varchar(100),
  @LanguageCode int = 1)
AS BEGIN
  CREATE TABLE dbo.#tmp
    (ID              varchar(100),
     ParentID        varchar(100),
     Type            varchar(1),
     Name            varchar(200),
     DynaFieldID     int,
     TabPosition     int,
     IconID          int)

  DECLARE @TabNames varchar(200)
  DECLARE @Tabs     varchar(200)
  DECLARE @TabName  varchar(200)
  DECLARE @FirstTab varchar(200)
  DECLARE @P        int
  DECLARE @Idx      int

  SELECT @TabNames = TabNames FROM dbo.DynaMask WITH (READUNCOMMITTED) WHERE MaskName = @MaskName

  IF IsNull(@TabNames,'') = ''
    SET @TabNames = 'Ohne Register'

  SET @Idx  = 0
  SET @Tabs = '/'

  -- scan TabName AND CREATE a record in #tmp for each Tabname
  WHILE (@TabNames <> '')
  BEGIN
    SET @P = CharIndex(',',@TabNames)
    IF @P = 0 BEGIN
      SET @TabName  = LTrim(RTrim(@TabNames))
      SET @TabNames = ''
    END ELSE BEGIN
      SET @TabName  = LTrim(RTrim(LEFT(@TabNames,@P-1)))
      SET @TabNames = SubString(@TabNames,@P+1,999)
    END

    SET @Idx  = @Idx + 1
    SET @Tabs = @Tabs + @TabName + '/'

    IF @Idx = 1
      SET @FirstTab = @TabName

    INSERT #tmp VALUES (@TabName,'','R',@TabName, 0, @Idx-100,85)
  END

  INSERT #tmp
  SELECT
    ID =
      CASE WHEN CharIndex('.' + FLD.TabName + '.',@Tabs) > 0
      THEN FLD.TabName + str(TabPosition,3)
      ELSE @FirstTab + str(TabPosition,3)
      END,

    ParentID =
      CASE
      WHEN CharIndex('/' + IsNull(FLD.TabName,'') + '/',@Tabs) > 0
      THEN FLD.TabName
      ELSE @FirstTab
      END,
    Type = 'F',
    Name =
      CASE WHEN FieldCode in (1,13) THEN
        IsNull(FLD.DisplayText,'-')
      ELSE
        IsNull(FLD.FieldName, 'Feld' + CONVERT(varchar,FLD.TabPosition))
      END,
    FLD.DynaFieldID,
    FLD.TabPosition,
    IconID = CASE WHEN FieldCode = 1 THEN 68 ELSE 69 END
  FROM
    dbo.DynaField FLD WITH (READUNCOMMITTED) 
  WHERE
    FLD.MaskName = @MaskName

  SELECT T.ID,T.ParentID,T.Type,T.Name,T.IconID,
         FLD.*, MLText = IsNull(dbo.fnGetMLText(FLD.DisplayTextTID, @LanguageCode), FLD.DisplayText)
  FROM   #tmp T
         LEFT JOIN dbo.DynaField FLD WITH (READUNCOMMITTED) ON FLD.DynaFieldID = T.DynaFieldID
  ORDER BY T.TabPosition
END

GO