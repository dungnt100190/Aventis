/****** Object:  Table [dbo].[FbKreditor]    Script Date: 10/08/2012 16:02:54 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FbKreditor](
	[FbKreditorID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [varchar](100) NOT NULL,
	[KurzName] [varchar](20) NULL,
	[Zusatz] [varchar](50) NULL,
	[Strasse] [varchar](200) NULL,
	[PLZ] [varchar](8) NOT NULL,
	[Ort] [varchar](50) NOT NULL,
	[Aktiv] [bit] NOT NULL,
	[AufwandKonto] [int] NULL,
	[BaLandID] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FbKreditorTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FbKreditor] PRIMARY KEY CLUSTERED 
(
	[FbKreditorID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FbKreditor_Name]    Script Date: 10/08/2012 16:02:54 ******/
CREATE NONCLUSTERED INDEX [IX_FbKreditor_Name] ON [dbo].[FbKreditor] 
(
	[Name] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für FbKreditor Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbKreditor', @level2type=N'COLUMN',@level2name=N'FbKreditorID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbKreditor', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbKreditor', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbKreditor', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbKreditor', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbKreditor', @level2type=N'COLUMN',@level2name=N'FbKreditorTS'
GO

ALTER TABLE [dbo].[FbKreditor]  WITH CHECK ADD  CONSTRAINT [FK_FbKreditor_BaLand] FOREIGN KEY([BaLandID])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[FbKreditor] CHECK CONSTRAINT [FK_FbKreditor_BaLand]
GO

ALTER TABLE [dbo].[FbKreditor] ADD  CONSTRAINT [DF_FbKreditor_Aktiv]  DEFAULT ((1)) FOR [Aktiv]
GO

ALTER TABLE [dbo].[FbKreditor] ADD  CONSTRAINT [DF_FbKreditor_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FbKreditor] ADD  CONSTRAINT [DF_FbKreditor_Modified]  DEFAULT (getdate()) FOR [Modified]
GO