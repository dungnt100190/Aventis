CREATE TABLE [dbo].[BwEinsatz](
	[BwEinsatzID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[XUser_BwEinsatzvereinbarungID] [int] NOT NULL,
	[Beginn] [datetime] NOT NULL,
	[Ende] [datetime] NOT NULL,
	[TypCode] [int] NOT NULL,
	[StatusCode] [int] NULL,
	[Bemerkungen] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_BwEinsatz_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_BwEinsatz_Modified]  DEFAULT (getdate()),
	[BwEinsatzTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BwEinsatz] PRIMARY KEY CLUSTERED 
(
	[BwEinsatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_BwEinsatz_FaLeistungID]    Script Date: 11/10/2009 09:10:41 ******/
CREATE NONCLUSTERED INDEX [IX_BwEinsatz_FaLeistungID] ON [dbo].[BwEinsatz] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_BwEinsatz_XUser_BwEinsatzvereinbarungID]    Script Date: 11/10/2009 09:10:41 ******/
CREATE NONCLUSTERED INDEX [IX_BwEinsatz_XUser_BwEinsatzvereinbarungID] ON [dbo].[BwEinsatz] 
(
	[XUser_BwEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'BwEinsatzID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FaLeistung.FaLeistungID (unique)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XUser_EdEinsatzvereinbarung.XUser_EdEinsatzvereinbarungID, wird für die möglichen Entlaster benötigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'XUser_BwEinsatzvereinbarungID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Einsatz-Beginn Datum und Zeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'Beginn'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Einsatz-Ende Datum und Zeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'Ende'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code aus der Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'TypCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code aus der Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'StatusCode'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zum Einsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag als letzer modifiziert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Eintrag als letztes modifiziert wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatz', @level2type=N'COLUMN',@level2name=N'BwEinsatzTS'
GO
ALTER TABLE [dbo].[BwEinsatz]  WITH CHECK ADD  CONSTRAINT [FK_BwEinsatz_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[BwEinsatz] CHECK CONSTRAINT [FK_BwEinsatz_FaLeistung]
GO
ALTER TABLE [dbo].[BwEinsatz]  WITH CHECK ADD  CONSTRAINT [FK_BwEinsatz_XUser_BwEinsatzvereinbarung] FOREIGN KEY([XUser_BwEinsatzvereinbarungID])
REFERENCES [dbo].[XUser_BwEinsatzvereinbarung] ([XUser_BwEinsatzvereinbarungID])
GO
ALTER TABLE [dbo].[BwEinsatz] CHECK CONSTRAINT [FK_BwEinsatz_XUser_BwEinsatzvereinbarung]