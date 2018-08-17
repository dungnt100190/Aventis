/****** Object:  Table [dbo].[BgSpezkontoAbschluss]    Script Date: 11/11/2010 16:12:53 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[BgSpezkontoAbschluss](
	[BgSpezkontoAbschlussID] [int] IDENTITY(1,1) NOT NULL,
	[BgSpezkontoID] [int] NOT NULL,
	[Betrag] [money] NOT NULL,
	[Text] [varchar](200) NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BgSpezkontoAbschlussTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgSpezkontoAbschluss] PRIMARY KEY CLUSTERED 
(
	[BgSpezkontoAbschlussID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle BgSpezkontoAbschluss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss', @level2type=N'COLUMN',@level2name=N'BgSpezkontoAbschlussID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel des Spezialkonto' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss', @level2type=N'COLUMN',@level2name=N'BgSpezkontoID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abschlussbetrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abschlusstext' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss', @level2type=N'COLUMN',@level2name=N'BgSpezkontoAbschlussTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle um einen Spezialkonto abzuschliessen. (neu für Abzahlungskonto in Ticket #4918)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BgSpezkontoAbschluss'
GO

ALTER TABLE [dbo].[BgSpezkontoAbschluss]  WITH CHECK ADD  CONSTRAINT [FK_BgSpezkontoAbschluss_BgSpezkonto] FOREIGN KEY([BgSpezkontoID])
REFERENCES [dbo].[BgSpezkonto] ([BgSpezkontoID])
GO

ALTER TABLE [dbo].[BgSpezkontoAbschluss] CHECK CONSTRAINT [FK_BgSpezkontoAbschluss_BgSpezkonto]
GO

ALTER TABLE [dbo].[BgSpezkontoAbschluss] ADD  CONSTRAINT [DF_BgSpezkontoAbschluss_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BgSpezkontoAbschluss] ADD  CONSTRAINT [DF_BgSpezkontoAbschluss_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


