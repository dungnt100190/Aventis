SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[HistoryVersion](
	[VerID] [int] IDENTITY(1,1) NOT NULL,
	[VersionDate] [datetime] NOT NULL,
	[HostName] [varchar](100) NOT NULL,
	[SystemUser] [varchar](100) NOT NULL,
	[AppName] [varchar](100) NOT NULL,
	[dbUser] [sysname] NOT NULL,
	[SessionID] [int] NOT NULL,
	[AppUser] [varchar](100) NULL,
	[UserAction] [varchar](1000) NULL,
 CONSTRAINT [PK_HistoryVersion] PRIMARY KEY CLUSTERED 
(
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_HistoryVersion_SessionID_VerID]    Script Date: 04/05/2011 09:22:28 ******/
CREATE NONCLUSTERED INDEX [IX_HistoryVersion_SessionID_VerID] ON [dbo].[HistoryVersion] 
(
	[SessionID] ASC,
	[VerID] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


/****** Object:  Index [IX_HistoryVersion_VerID_VersionDate]    Script Date: 04/05/2011 09:22:28 ******/
CREATE NONCLUSTERED INDEX [IX_HistoryVersion_VerID_VersionDate] ON [dbo].[HistoryVersion] 
(
	[VerID] ASC,
	[VersionDate] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für HistoryVersion Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'HistoryVersion', @level2type=N'COLUMN',@level2name=N'VerID'
GO

/****** Object:  Trigger [dbo].[trHistoryVersion_I]    Script Date: 04/05/2011 09:22:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO



CREATE TRIGGER [dbo].[trHistoryVersion_I]
   ON  [dbo].[HistoryVersion]
   INSTEAD OF INSERT
AS 
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

  INSERT INTO dbo.HistoryVersion
    SELECT VersionDate = GETDATE(), 
           HostName    = ISNULL(HostName, host_name()), 
           SystemUser  = ISNULL(SystemUser, suser_sname()), 
           AppName     = ISNULL(AppName, app_name()), 
           dbUser      = ISNULL(dbUser, user_name()), 
           SessionID   = @@spid, 
           AppUser, 
           UserAction
    FROM inserted;

  -- Diese Zeile darf nicht auskommentiert werden (EF geht sonst nicht)!
  SELECT VerID = SCOPE_IDENTITY();  
END


GO

/****** Object:  Trigger [dbo].[trHistoryVersion_UD]    Script Date: 04/05/2011 09:22:28 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO


CREATE TRIGGER [dbo].[trHistoryVersion_UD]
  ON [dbo].[HistoryVersion]
  FOR UPDATE, DELETE
AS BEGIN

  SET NOCOUNT ON

  IF EXISTS (SELECT * FROM DELETED) OR EXISTS (SELECT * FROM INSERTED WHERE VersionDate != GetDate() OR dbUser != USER) BEGIN
    RAISERROR ('These columns should never be updated', 16, 1)
    ROLLBACK TRANSACTION
  END

END


GO
