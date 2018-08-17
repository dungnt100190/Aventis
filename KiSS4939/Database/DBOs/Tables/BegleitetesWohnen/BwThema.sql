CREATE TABLE [dbo].[BwThema](
	[BwThemaID] [int] IDENTITY(1,1) NOT NULL,
	[Text] [varchar](50) NOT NULL,
	[TextTID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_BwThema_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_BwThema_Modified]  DEFAULT (getdate()),
	[BwThemaTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BwThema] PRIMARY KEY CLUSTERED 
(
	[BwThemaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_BwThema_BwThemaID_Text_TextTID]    Script Date: 11/10/2009 09:11:56 ******/
CREATE NONCLUSTERED INDEX [IX_BwThema_BwThemaID_Text_TextTID] ON [dbo].[BwThema] 
(
	[BwThemaID] ASC,
	[Text] ASC,
	[TextTID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel in Form einer ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwThema', @level2type=N'COLUMN',@level2name=N'BwThemaID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name des Themas' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwThema', @level2type=N'COLUMN',@level2name=N'Text'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID für die Übersetzung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwThema', @level2type=N'COLUMN',@level2name=N'TextTID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwThema', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Eintrag erstellt wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwThema', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag als letzter modifiziert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwThema', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann wurde der Eintrag als letztes modifiziert.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwThema', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für Konsistenzprüfung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwThema', @level2type=N'COLUMN',@level2name=N'BwThemaTS'