CREATE TABLE [dbo].[IkGlaeubiger](
	[IkGlaeubigerID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[IkRechtstitelID] [int] NULL,
	[BaPersonID] [int] NOT NULL,
	[BaPersonID_AntragStellendePerson] [int] NULL,
	[BaZahlungswegID] [int] NULL,
	[Ausbildung] [varchar](1024) NULL,
	[Bemerkung] [varchar](max) NULL,
	[Aktiv] [bit] NOT NULL,
	[IkGlaeubigerTS] [timestamp] NOT NULL,
	[AuszahlungVermittlungStoppen] [bit] NOT NULL,
 CONSTRAINT [PK_IkGlaeubiger] PRIMARY KEY CLUSTERED 
(
	[IkGlaeubigerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_IkGlaeubiger_BaPersonID] ON [dbo].[IkGlaeubiger] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


/****** Object:  Index [IX_IkGlaeubiger_BaPersonID_AntragStellendePerson]    Script Date: 08/22/2014 16:05:26 ******/
CREATE NONCLUSTERED INDEX [IX_IkGlaeubiger_BaPersonID_AntragStellendePerson] ON [dbo].[IkGlaeubiger] 
(
	[BaPersonID_AntragStellendePerson] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_IkGlaeubiger_BaPersonIDIkRechtstitelIDFaLeistungID_Unique]    Script Date: 08/22/2014 16:05:26 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_IkGlaeubiger_BaPersonIDIkRechtstitelIDFaLeistungID_Unique] ON [dbo].[IkGlaeubiger] 
(
	[BaPersonID] ASC,
	[IkRechtstitelID] ASC,
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_IkGlaeubiger_BaZahlungswegID] ON [dbo].[IkGlaeubiger] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_IkGlaeubiger_FaLeistungID] ON [dbo].[IkGlaeubiger] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_IkGlaeubiger_IkRechtstitelID] ON [dbo].[IkGlaeubiger] 
(
	[IkRechtstitelID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für IkGlaeubiger Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkGlaeubiger', @level2type=N'COLUMN',@level2name=N'IkGlaeubigerID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkGlaeubiger_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkGlaeubiger', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkGlaeubiger_IkRechtstitel) => IkRechtstitel.IkRechtstitelID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkGlaeubiger', @level2type=N'COLUMN',@level2name=N'IkRechtstitelID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkGlaeubiger_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkGlaeubiger', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkGlaeubiger_BaZahlungsweg) => BaZahlungsweg.BaZahlungswegID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkGlaeubiger', @level2type=N'COLUMN',@level2name=N'BaZahlungswegID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag zum definieren ob die Auszahlung von Alimentenvermittlung erstellt werden muss beim verbuchen des Zahlungseingangs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkGlaeubiger', @level2type=N'COLUMN',@level2name=N'AuszahlungVermittlungStoppen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_IkGlaeubiger_AntragStellendePerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkGlaeubiger', @level2type=N'COLUMN',@level2name=N'BaPersonID_AntragStellendePerson'
GO

ALTER TABLE [dbo].[IkGlaeubiger]  WITH CHECK ADD  CONSTRAINT [FK_IkGlaeubiger_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[IkGlaeubiger] CHECK CONSTRAINT [FK_IkGlaeubiger_BaPerson]
GO

ALTER TABLE [dbo].[IkGlaeubiger]  WITH CHECK ADD  CONSTRAINT [FK_IkGlaeubiger_BaPerson_AntragStellendePerson] FOREIGN KEY([BaPersonID_AntragStellendePerson])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[IkGlaeubiger] CHECK CONSTRAINT [FK_IkGlaeubiger_BaPerson_AntragStellendePerson]
GO

ALTER TABLE [dbo].[IkGlaeubiger]  WITH CHECK ADD  CONSTRAINT [FK_IkGlaeubiger_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[IkGlaeubiger] CHECK CONSTRAINT [FK_IkGlaeubiger_BaZahlungsweg]
GO

ALTER TABLE [dbo].[IkGlaeubiger]  WITH CHECK ADD  CONSTRAINT [FK_IkGlaeubiger_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[IkGlaeubiger] CHECK CONSTRAINT [FK_IkGlaeubiger_FaLeistung]
GO

ALTER TABLE [dbo].[IkGlaeubiger]  WITH CHECK ADD  CONSTRAINT [FK_IkGlaeubiger_IkRechtstitel] FOREIGN KEY([IkRechtstitelID])
REFERENCES [dbo].[IkRechtstitel] ([IkRechtstitelID])
GO

ALTER TABLE [dbo].[IkGlaeubiger] CHECK CONSTRAINT [FK_IkGlaeubiger_IkRechtstitel]
GO

ALTER TABLE [dbo].[IkGlaeubiger] ADD  CONSTRAINT [DF_IkGlaeubiger_Aktiv]  DEFAULT ((0)) FOR [Aktiv]
GO

ALTER TABLE [dbo].[IkGlaeubiger] ADD  CONSTRAINT [DF_IkGlaeubiger_AuszahlungVermittlungStoppen]  DEFAULT ((0)) FOR [AuszahlungVermittlungStoppen]
GO