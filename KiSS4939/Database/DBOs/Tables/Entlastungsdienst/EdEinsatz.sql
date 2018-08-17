CREATE TABLE [dbo].[EdEinsatz](
	[EdEinsatzID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[XUser_EdEinsatzvereinbarungID] [int] NOT NULL,
	[Beginn] [datetime] NOT NULL,
	[Ende] [datetime] NOT NULL,
	[TypCode] [int] NOT NULL,
	[StatusCode] [int] NULL,
	[Bemerkungen] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[EdEinsatzTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdEinsatz] PRIMARY KEY CLUSTERED 
(
	[EdEinsatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_EdEinsatz_FaLeistungID] ON [dbo].[EdEinsatz] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_EdEinsatz_XUser_EdEinsatzvereinbarungID] ON [dbo].[EdEinsatz] 
(
	[XUser_EdEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PrimaryKey, wird als ID benutzt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'EdEinsatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FaLeistung.FaLeistungID (unique)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XUser_EdEinsatzvereinbarung.XUser_EdEinsatzvereinbarungID, wird für die möglichen Entlaster benötigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'XUser_EdEinsatzvereinbarungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Einsatz-Beginn Datum und Zeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'Beginn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Einsatz-Ende Datum und Zeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'Ende'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code aus der Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'TypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code aus der Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'StatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zum Einsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag als letzter modifiziert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann wurde der Eintrag als letztes bearbeitet.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz', @level2type=N'COLUMN',@level2name=N'EdEinsatzTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Customer_Only', @value=N'Pro Infirmis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wird für die Einsätze der Entlaster/innen verwendet, welche in der ED-Einsatzvereinbarung definiert wurden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Entlastungsdienst' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdEinsatz'
GO

ALTER TABLE [dbo].[EdEinsatz]  WITH CHECK ADD  CONSTRAINT [FK_EdEinsatz_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[EdEinsatz] CHECK CONSTRAINT [FK_EdEinsatz_FaLeistung]
GO

ALTER TABLE [dbo].[EdEinsatz]  WITH CHECK ADD  CONSTRAINT [FK_EdEinsatz_XUser_EdEinsatzvereinbarung] FOREIGN KEY([XUser_EdEinsatzvereinbarungID])
REFERENCES [dbo].[XUser_EdEinsatzvereinbarung] ([XUser_EdEinsatzvereinbarungID])
GO

ALTER TABLE [dbo].[EdEinsatz] CHECK CONSTRAINT [FK_EdEinsatz_XUser_EdEinsatzvereinbarung]
GO

ALTER TABLE [dbo].[EdEinsatz] ADD  CONSTRAINT [DF_EdEinsatz_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[EdEinsatz] ADD  CONSTRAINT [DF_EdEinsatz_Modified]  DEFAULT (getdate()) FOR [Modified]
GO