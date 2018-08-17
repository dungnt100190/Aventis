SET QUOTED_IDENTIFIER ON
GO
SET ANSI_NULLS ON
GO
IF EXISTS (SELECT * FROM dbo.sysobjects WHERE id = OBJECT_ID(N'[dbo].[spAddReplaceBFSWert]') AND OBJECTPROPERTY(id, N'IsProcedure') = 1)
DROP PROCEDURE [dbo].[spAddReplaceBFSWert]
GO
CREATE procedure [dbo].[spAddReplaceBFSWert] (
  @VarName     varchar(10),
  @Wert        sql_variant,
  @DmgPersonID int,
  @Jahr        int,
  @Stichtag    smallint)
as
  if @DmgPersonID is null or
     @VarName     is null or
     @Jahr        is null or
     @Stichtag    is null return

  declare @XBFSFrageID int
  declare @XBFSWertID int

  set @XBFSFrageID = (select XBFSFrageID from XBFSFrage where VarName = @VarName)
  if @XBFSFrageID is null begin
     print 'spAddReplaceBFSVarName: BFS-Variable ' + @VarName + ' nicht gefunden!'
     return;
  end

  set @XBFSWertID = null
  select @XBFSWertID = XBFSWertID
  from   XBFSWert
  where  XBFSFrageID = @XBFSFrageID  and
         DmgPersonID = @DmgPersonID and
         Jahr        = @Jahr and
         Stichtag    = @Stichtag

  if @XBFSWertID is not null
    update XBFSWert
    set    Wert = @Wert
    where  XBFSWertID = @XBFSWertID
  else
    insert XBFSWert (XBFSFrageID,  DmgPersonID, Jahr, Stichtag, Wert)
    values          (@XBFSFrageID, @DmgPersonID,@Jahr,@Stichtag,@Wert)

