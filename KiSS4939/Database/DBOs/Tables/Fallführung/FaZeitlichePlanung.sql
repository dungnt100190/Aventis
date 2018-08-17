CREATE TABLE [dbo].[FaZeitlichePlanung](
	[FaZeitlichePlanungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Phase1Ende] [datetime] NULL,
	[Phase1SitAnalyse] [datetime] NULL,
	[Phase1Bemerkungen] [varchar](max) NULL,
	[Phase2Beginn] [datetime] NULL,
	[Phase2Ende] [datetime] NULL,
	[Phase2SitAnalyse] [datetime] NULL,
	[Phase2Bemerkungen] [varchar](max) NULL,
	[Phase3Beginn] [datetime] NULL,
	[Phase3SitAnalyse] [datetime] NULL,
	[Phase3Bemerkungen] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaZeitlichePlanungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaZeitlichePlanung] PRIMARY KEY CLUSTERED 
(
	[FaZeitlichePlanungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaZeitlichePlanung_FaLeistungID]    Script Date: 01/10/2012 14:57:22 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_FaZeitlichePlanung_FaLeistungID] ON [dbo].[FaZeitlichePlanung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaZeitlichePlanung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_DESCRIPTION', @value=N'Tabelle für Maske Zeitliche Planung (Fallführung SRK)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaZeitlichePlanung'
GO

ALTER TABLE [dbo].[FaZeitlichePlanung]  WITH CHECK ADD  CONSTRAINT [FK_FaZeitlichePlanung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaZeitlichePlanung] CHECK CONSTRAINT [FK_FaZeitlichePlanung_FaLeistung]
GO

ALTER TABLE [dbo].[FaZeitlichePlanung] ADD  CONSTRAINT [DF_FaZeitlichePlanung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaZeitlichePlanung] ADD  CONSTRAINT [DF_FaZeitlichePlanung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


