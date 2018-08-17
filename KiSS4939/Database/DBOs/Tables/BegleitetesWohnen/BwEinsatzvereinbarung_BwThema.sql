CREATE TABLE [dbo].[BwEinsatzvereinbarung_BwThema](
	[BwEinsatzvereinbarung_BwThemaID] [int] IDENTITY(1,1) NOT NULL,
	[BwEinsatzvereinbarungID] [int] NOT NULL,
	[BwThemaID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_BwEinsatzvereinbarung_BwThema_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_BwEinsatzvereinbarung_BwThema_Modified]  DEFAULT (getdate()),
	[BwEinsatzvereinbarung_BwThemaTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BwEinsatzvereinbarung_BwThema] PRIMARY KEY CLUSTERED 
(
	[BwEinsatzvereinbarung_BwThemaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_BwEinsatzvereinbarung_BwThema_BwEinsatzvereinbarungID_BwThemaID] UNIQUE NONCLUSTERED 
(
	[BwEinsatzvereinbarungID] ASC,
	[BwThemaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_BwEinsatzvereinbarung_BwThema_BwEinsatzvereinbarungID]    Script Date: 11/17/2009 08:21:06 ******/
CREATE NONCLUSTERED INDEX [IX_BwEinsatzvereinbarung_BwThema_BwEinsatzvereinbarungID] ON [dbo].[BwEinsatzvereinbarung_BwThema] 
(
	[BwEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_BwEinsatzvereinbarung_BwThema_BwThemaID]    Script Date: 11/17/2009 08:21:06 ******/
CREATE NONCLUSTERED INDEX [IX_BwEinsatzvereinbarung_BwThema_BwThemaID] ON [dbo].[BwEinsatzvereinbarung_BwThema] 
(
	[BwThemaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel, eine ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwThema', @level2type=N'COLUMN',@level2name=N'BwEinsatzvereinbarung_BwThemaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Einsatzvereinbarung welche mit einem Thema verknüpft werden soll. Fremdschlüssel auf BwEinsatzvereinbarung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwThema', @level2type=N'COLUMN',@level2name=N'BwEinsatzvereinbarungID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des Themas welches mit einer Einsatzvereinbarung verknüpft werden soll. Fremdschlüssel auf BwThema' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwThema', @level2type=N'COLUMN',@level2name=N'BwThemaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwThema', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Eintrag erstellt wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwThema', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag als letzter bearbeitet hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwThema', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Eintrag als letztes verändert wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwThema', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für Konsistenzprüfung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwThema', @level2type=N'COLUMN',@level2name=N'BwEinsatzvereinbarung_BwThemaTS'
GO
ALTER TABLE [dbo].[BwEinsatzvereinbarung_BwThema]  WITH CHECK ADD  CONSTRAINT [FK_BwEinsatzvereinbarung_BwThema_BwEinsatzvereinbarung] FOREIGN KEY([BwEinsatzvereinbarungID])
REFERENCES [dbo].[BwEinsatzvereinbarung] ([BwEinsatzvereinbarungID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BwEinsatzvereinbarung_BwThema] CHECK CONSTRAINT [FK_BwEinsatzvereinbarung_BwThema_BwEinsatzvereinbarung]
GO
ALTER TABLE [dbo].[BwEinsatzvereinbarung_BwThema]  WITH CHECK ADD  CONSTRAINT [FK_BwEinsatzvereinbarung_BwThema_BwThema] FOREIGN KEY([BwThemaID])
REFERENCES [dbo].[BwThema] ([BwThemaID])
GO
ALTER TABLE [dbo].[BwEinsatzvereinbarung_BwThema] CHECK CONSTRAINT [FK_BwEinsatzvereinbarung_BwThema_BwThema]