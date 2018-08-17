CREATE TABLE [dbo].[VmKlientenbudget](
	[VmKlientenbudgetID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[VmKlientenbudgetStatusCode] [int] NOT NULL,
	[GueltigAb] [datetime] NOT NULL,
	[VmKlientenbudgetMutationsgrundCode] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmKlientenbudgetTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmKlientenbudget] PRIMARY KEY CLUSTERED 
(
	[VmKlientenbudgetID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmKlientenbudget_FaLeistungID] ON [dbo].[VmKlientenbudget] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_VmKlientenbudget_UserID] ON [dbo].[VmKlientenbudget] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'VmKlientenbudgetID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FaLeistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XUser um den Autor zu definieren' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status-Code des Budget aus LOV VmKlientenbudgetStatus (auch enum in C# VmKlientenbudgetStatus)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'VmKlientenbudgetStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum ab wenn das Budget gültig ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'GueltigAb'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grund zur Erstellung des Klientenbudgets. LOV VmKlientenbudgetMutationsgrund' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'VmKlientenbudgetMutationsgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget', @level2type=N'COLUMN',@level2name=N'VmKlientenbudgetTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle um Klientenbudgets in Vormundschaftliche Massnahmen zu erfassen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Vormundschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmKlientenbudget'
GO

ALTER TABLE [dbo].[VmKlientenbudget]  WITH CHECK ADD  CONSTRAINT [FK_VmKlientenbudget_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmKlientenbudget] CHECK CONSTRAINT [FK_VmKlientenbudget_FaLeistung]
GO

ALTER TABLE [dbo].[VmKlientenbudget]  WITH CHECK ADD  CONSTRAINT [FK_VmKlientenbudget_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmKlientenbudget] CHECK CONSTRAINT [FK_VmKlientenbudget_XUser]
GO

ALTER TABLE [dbo].[VmKlientenbudget] ADD  CONSTRAINT [DF_VmKlientenbudget_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmKlientenbudget] ADD  CONSTRAINT [DF_VmKlientenbudget_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
