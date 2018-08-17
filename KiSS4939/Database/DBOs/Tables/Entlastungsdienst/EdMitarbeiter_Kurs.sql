CREATE TABLE [dbo].[EdMitarbeiter_Kurs](
	[EdMitarbeiter_KursID] [int] IDENTITY(1,1) NOT NULL,
	[EdMitarbeiterID] [int] NOT NULL,
	[EdKursID] [int] NOT NULL,
	[ZuAbsolvierenBis] [datetime] NULL,
	[AbsolviertAm] [datetime] NULL,
	[Dispensiert] [bit] NOT NULL,
	[Bemerkungen] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[EdMitarbeiter_KursTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdMitarbeiter_Kurs] PRIMARY KEY CLUSTERED 
(
	[EdMitarbeiter_KursID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_EdMitarbeiter_Kurs] ON [dbo].[EdMitarbeiter_Kurs] 
(
	[EdKursID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_EdMitarbeiter_Mitarbeiter] ON [dbo].[EdMitarbeiter_Kurs] 
(
	[EdMitarbeiterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'EdMitarbeiter_KursID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf EdMitarbeiter.EdMitarbeiterID, Referenz auf dem Mitarbeiter, der den Kurs zu leisten hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'EdMitarbeiterID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf EdKurs.EdKursID, Referenz auf den zu leistenden Kurs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'EdKursID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bis wann der Kurs zu absolvieren ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'ZuAbsolvierenBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Kurs absolviert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'AbsolviertAm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob der Mitarbeiter für den Kurs dispensiert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'Dispensiert'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zum erfassten Kurs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Von wem der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Von wem der Datensatz mutiert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz mutiert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_Kurs', @level2type=N'COLUMN',@level2name=N'EdMitarbeiter_KursTS'
GO

ALTER TABLE [dbo].[EdMitarbeiter_Kurs]  WITH CHECK ADD  CONSTRAINT [FK_EdMitarbeiter_Kurs_EdKurs] FOREIGN KEY([EdKursID])
REFERENCES [dbo].[EdKurs] ([EdKursID])
GO

ALTER TABLE [dbo].[EdMitarbeiter_Kurs] CHECK CONSTRAINT [FK_EdMitarbeiter_Kurs_EdKurs]
GO

ALTER TABLE [dbo].[EdMitarbeiter_Kurs]  WITH CHECK ADD  CONSTRAINT [FK_EdMitarbeiter_Kurs_EdMitarbeiter] FOREIGN KEY([EdMitarbeiterID])
REFERENCES [dbo].[EdMitarbeiter] ([EdMitarbeiterID])
GO

ALTER TABLE [dbo].[EdMitarbeiter_Kurs] CHECK CONSTRAINT [FK_EdMitarbeiter_Kurs_EdMitarbeiter]
GO

ALTER TABLE [dbo].[EdMitarbeiter_Kurs] ADD  CONSTRAINT [DF_EdMitarbeiter_Kurs_Dispensiert]  DEFAULT ((0)) FOR [Dispensiert]
GO

ALTER TABLE [dbo].[EdMitarbeiter_Kurs] ADD  CONSTRAINT [DF_EdMitarbeiter_Kurs_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[EdMitarbeiter_Kurs] ADD  CONSTRAINT [DF_EdMitarbeiter_Kurs_Modified]  DEFAULT (getdate()) FOR [Modified]
GO