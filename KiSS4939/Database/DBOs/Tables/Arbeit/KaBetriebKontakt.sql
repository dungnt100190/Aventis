CREATE TABLE [dbo].[KaBetriebKontakt](
	[KaBetriebKontaktID] [int] IDENTITY(1,1) NOT NULL,
	[KaBetriebID] [int] NULL,
	[Titel] [varchar](50) NULL,
	[Name] [varchar](100) NULL,
	[Vorname] [varchar](100) NULL,
	[Funktion] [varchar](100) NULL,
	[GeschlechtCode] [int] NULL,
	[Aktiv] [bit] NULL,
	[Telefon] [varchar](100) NULL,
	[TelefonMobil] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[Bemerkung] [varchar](7000) NULL,
	[KaBetriebKontaktTS] [timestamp] NOT NULL,
	[UseZusatzadresse] [bit] NOT NULL,
 CONSTRAINT [PK_KaBetriebKontakt] PRIMARY KEY CLUSTERED 
(
	[KaBetriebKontaktID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaBetriebKontakt_KaBetriebID] ON [dbo].[KaBetriebKontakt] 
(
	[KaBetriebID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaBetriebKontakt Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaBetriebKontakt', @level2type=N'COLUMN',@level2name=N'KaBetriebKontaktID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaBetriebKontakt_KaBetrieb) => KaBetrieb.KaBetriebID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaBetriebKontakt', @level2type=N'COLUMN',@level2name=N'KaBetriebID'
GO

ALTER TABLE [dbo].[KaBetriebKontakt]  WITH CHECK ADD  CONSTRAINT [FK_KaBetriebKontakt_KaBetrieb] FOREIGN KEY([KaBetriebID])
REFERENCES [dbo].[KaBetrieb] ([KaBetriebID])
GO

ALTER TABLE [dbo].[KaBetriebKontakt] CHECK CONSTRAINT [FK_KaBetriebKontakt_KaBetrieb]
GO

ALTER TABLE [dbo].[KaBetriebKontakt] ADD  CONSTRAINT [DF__KaBetrieb__Aktiv__63A6F1A7]  DEFAULT ((1)) FOR [Aktiv]
GO

ALTER TABLE [dbo].[KaBetriebKontakt] ADD  CONSTRAINT [DF_KaBetriebKontakt_UseZusatzadresse]  DEFAULT ((0)) FOR [UseZusatzadresse]
GO