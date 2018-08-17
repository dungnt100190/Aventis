CREATE TABLE [dbo].[GvBewilligung](
	[GvBewilligungID] [int] IDENTITY(1,1) NOT NULL,
	[GvGesuchID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[GvBewilligungCode] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvBewilligungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvBewilligung] PRIMARY KEY CLUSTERED 
(
	[GvBewilligungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvBewilligung_GvGesuchID]    Script Date: 05/30/2012 15:22:03 ******/
CREATE NONCLUSTERED INDEX [IX_GvBewilligung_GvGesuchID] ON [dbo].[GvBewilligung] 
(
	[GvGesuchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_GvBewilligung_UserID]    Script Date: 05/30/2012 15:22:03 ******/
CREATE NONCLUSTERED INDEX [IX_GvBewilligung_UserID] ON [dbo].[GvBewilligung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für GvBewilligung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung', @level2type=N'COLUMN',@level2name=N'GvBewilligungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvBewilligung_GvGesuch) => GvGesuchID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung', @level2type=N'COLUMN',@level2name=N'GvGesuchID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvBewilligung_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV GvBewilligung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung', @level2type=N'COLUMN',@level2name=N'GvBewilligungCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung', @level2type=N'COLUMN',@level2name=N'GvBewilligungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Peter Salajan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen zu Bewilligungen in der Gesuchverwaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvBewilligung'
GO

ALTER TABLE [dbo].[GvBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_GvBewilligung_GvGesuch] FOREIGN KEY([GvGesuchID])
REFERENCES [dbo].[GvGesuch] ([GvGesuchID])
GO

ALTER TABLE [dbo].[GvBewilligung] CHECK CONSTRAINT [FK_GvBewilligung_GvGesuch]
GO

ALTER TABLE [dbo].[GvBewilligung]  WITH CHECK ADD  CONSTRAINT [FK_GvBewilligung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[GvBewilligung] CHECK CONSTRAINT [FK_GvBewilligung_XUser]
GO

ALTER TABLE [dbo].[GvBewilligung] ADD  CONSTRAINT [DF_GvBewilligung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvBewilligung] ADD  CONSTRAINT [DF_GvBewilligung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


