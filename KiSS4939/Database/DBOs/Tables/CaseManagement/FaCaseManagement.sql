CREATE TABLE [dbo].[FaCaseManagement](
	[FaCaseManagementID] [int] IDENTITY(1,1) NOT NULL,
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
	[FaCaseManagementTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaCaseManagement] PRIMARY KEY CLUSTERED 
(
	[FaCaseManagementID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FaCaseManagement_ElterID] ON [dbo].[FaCaseManagement] 
(
	[ElterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_FaCaseManagement_FaLeistungID] ON [dbo].[FaCaseManagement] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaCaseManagement', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaCaseManagement', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaCaseManagement', @level2type=N'COLUMN',@level2name=N'FaCaseManagementTS'
GO

ALTER TABLE [dbo].[FaCaseManagement]  WITH CHECK ADD  CONSTRAINT [FK_FaCaseManagement_FaCaseManagement] FOREIGN KEY([ElterID])
REFERENCES [dbo].[FaCaseManagement] ([FaCaseManagementID])
GO

ALTER TABLE [dbo].[FaCaseManagement] CHECK CONSTRAINT [FK_FaCaseManagement_FaCaseManagement]
GO

ALTER TABLE [dbo].[FaCaseManagement]  WITH CHECK ADD  CONSTRAINT [FK_FaCaseManagement_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[FaCaseManagement] CHECK CONSTRAINT [FK_FaCaseManagement_FaLeistung]
GO

ALTER TABLE [dbo].[FaCaseManagement] ADD  CONSTRAINT [DF_FaCaseManagement_IstHaupteintrag]  DEFAULT ((0)) FOR [IstHaupteintrag]
GO

ALTER TABLE [dbo].[FaCaseManagement] ADD  CONSTRAINT [DF_FaCaseManagement_IstRahmenziel]  DEFAULT ((0)) FOR [IstRahmenziel]
GO

ALTER TABLE [dbo].[FaCaseManagement] ADD  CONSTRAINT [DF_FaCaseManagement_IstHandlungsziel]  DEFAULT ((0)) FOR [IstHandlungsziel]
GO

ALTER TABLE [dbo].[FaCaseManagement] ADD  CONSTRAINT [DF_FaCaseManagement_IstMassnahme]  DEFAULT ((0)) FOR [IstMassnahme]
GO

ALTER TABLE [dbo].[FaCaseManagement] ADD  CONSTRAINT [DF_FaCaseManagement_Erledigt]  DEFAULT ((0)) FOR [Erledigt]
GO

ALTER TABLE [dbo].[FaCaseManagement] ADD  CONSTRAINT [DF_FaCaseManagement_Created]  DEFAULT (getdate()) FOR [Created]
GO