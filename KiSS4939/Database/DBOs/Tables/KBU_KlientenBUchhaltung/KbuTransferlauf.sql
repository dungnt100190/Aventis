/****** Object:  Table [dbo].[KbuTransferlauf]    Script Date: 06/21/2011 08:51:52 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[KbuTransferlauf](
	[KbuTransferlaufID] [int] IDENTITY(1,1) NOT NULL,
	[Start] [datetime] NULL,
	[Ende] [datetime] NULL,
	[KbuTransferlaufStatusCode] [int] NOT NULL,
	[Bemerkung] [varchar](1000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KbuTransferlaufTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbuTransferlauf] PRIMARY KEY CLUSTERED 
(
	[KbuTransferlaufID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'KbuTransferlaufID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Startzeitpunkt des Transferlaufs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'Start'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitpunkt der Beendigung des Transferlaufs (unabhängig davon, ob der Lauf erfolgreich war)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'Ende'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zustand des Transferlaufs, siehe LOV' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'KbuTransferlaufStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Allfällige Bemerkungen zum Transferlauf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf', @level2type=N'COLUMN',@level2name=N'KbuTransferlaufTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Mathias Minder' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ein Transferlauf gruppiert 1-n Belege in einem Übertragungslauf, z.B. zu einem Umsystem' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Klientenbuchhaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbuTransferlauf'
GO

ALTER TABLE [dbo].[KbuTransferlauf]  WITH CHECK ADD  CONSTRAINT [CK_KbuTransferlauf] CHECK  (([dbo].[fnCKKbuTransferlaufRunningCount]()<=(1)))
GO

ALTER TABLE [dbo].[KbuTransferlauf] CHECK CONSTRAINT [CK_KbuTransferlauf]
GO

ALTER TABLE [dbo].[KbuTransferlauf] ADD  CONSTRAINT [DF_KbuTransferlauf_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KbuTransferlauf] ADD  CONSTRAINT [DF_KbuTransferlauf_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


