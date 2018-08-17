CREATE TABLE [dbo].[SbSozialberatung](
	[SbSozialberatungID] [int] IDENTITY(1,1) NOT NULL,
	[ElterID] [int] NULL,
	[FaLeistungID] [int] NOT NULL,
	[IstHaupteintrag] [bit] NOT NULL,
	[IstRahmenziel] [bit] NOT NULL,
	[IstHandlungsziel] [bit] NOT NULL,
	[IstMassnahme] [bit] NOT NULL,
	[ErstellungZV] [datetime] NULL,
	[Grundsatzziel] [varchar](1000) NULL,
	[Datum] [datetime] NULL,
	[LebensbereichCode] [int] NULL,
	[BisWann] [datetime] NULL,
	[Wer] [varchar](255) NULL,
	[Text] [varchar](1000) NULL,
	[Indikatoren] [varchar](1000) NULL,
	[Kommentar] [varchar](max) NULL,
	[EvaluationCode] [int] NULL,
	[EvaluationDatum] [datetime] NULL,
	[EvaluationBegruendung] [varchar](1000) NULL,
	[Erledigt] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[SbSozialberatungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_SbSozialberatung] PRIMARY KEY CLUSTERED 
(
	[SbSozialberatungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING OFF
GO


/****** Object:  Index [IX_SbSozialberatung_ElterID]    Script Date: 01/07/2010 10:42:53 ******/
CREATE NONCLUSTERED INDEX [IX_SbSozialberatung_ElterID] ON [dbo].[SbSozialberatung] 
(
	[ElterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_SbSozialberatung_FaLeistungID]    Script Date: 01/07/2010 10:42:53 ******/
CREATE NONCLUSTERED INDEX [IX_SbSozialberatung_FaLeistungID] ON [dbo].[SbSozialberatung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SbSozialberatung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SbSozialberatung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'SbSozialberatung', @level2type=N'COLUMN',@level2name=N'SbSozialberatungTS'
GO

ALTER TABLE [dbo].[SbSozialberatung]  WITH CHECK ADD  CONSTRAINT [FK_SbSozialberatung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[SbSozialberatung] CHECK CONSTRAINT [FK_SbSozialberatung_FaLeistung]
GO

ALTER TABLE [dbo].[SbSozialberatung]  WITH CHECK ADD  CONSTRAINT [FK_SbSozialberatung_SbSozialberatung] FOREIGN KEY([ElterID])
REFERENCES [dbo].[SbSozialberatung] ([SbSozialberatungID])
GO

ALTER TABLE [dbo].[SbSozialberatung] CHECK CONSTRAINT [FK_SbSozialberatung_SbSozialberatung]
GO

ALTER TABLE [dbo].[SbSozialberatung] ADD  CONSTRAINT [DF_SbSozialberatung_IstHaupteintrag]  DEFAULT ((0)) FOR [IstHaupteintrag]
GO

ALTER TABLE [dbo].[SbSozialberatung] ADD  CONSTRAINT [DF_SbSozialberatung_IstRahmenziel]  DEFAULT ((0)) FOR [IstRahmenziel]
GO

ALTER TABLE [dbo].[SbSozialberatung] ADD  CONSTRAINT [DF_SbSozialberatung_IstHandlungsziel]  DEFAULT ((0)) FOR [IstHandlungsziel]
GO

ALTER TABLE [dbo].[SbSozialberatung] ADD  CONSTRAINT [DF_SbSozialberatung_IstMassnahme]  DEFAULT ((0)) FOR [IstMassnahme]
GO

ALTER TABLE [dbo].[SbSozialberatung] ADD  CONSTRAINT [DF_SbSozialberatung_Erledigt]  DEFAULT ((0)) FOR [Erledigt]
GO

ALTER TABLE [dbo].[SbSozialberatung] ADD  CONSTRAINT [DF_SbSozialberatung_Created]  DEFAULT (getdate()) FOR [Created]
GO
