CREATE TABLE [dbo].[KaExterneBildungZahlung] (
	[KaExterneBildungZahlungID] [int] IDENTITY (1, 1) NOT NULL ,
	[KaExterneBildungID] [int] NULL ,
	[Datum] [datetime] NULL ,
	[Betrag] [money] NULL ,
	[Zweck] [varchar] (200) NULL ,
	[KaExterneBildungZahlungTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaExterneBildungZahlung] PRIMARY KEY  Clustered
	(
		[KaExterneBildungZahlungID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_KaExterneBildungZahlung_KaExterneBildung] FOREIGN KEY
	(
		[KaExterneBildungID]
	) REFERENCES [dbo].[KaExterneBildung] (
		[KaExterneBildungID]
	)
) ON [DATEN1]
GO
 CREATE  INDEX [IX_KaExterneBildungZahlung_KaExterneBildungID] ON [dbo].[KaExterneBildungZahlung]([KaExterneBildungID]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaExterneBildungZahlung Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaExterneBildungZahlung', N'column', N'KaExterneBildungZahlungID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaExterneBildungZahlung_KaExterneBildung) => KaExterneBildung.KaExterneBildungID', N'user', N'dbo', N'table', N'KaExterneBildungZahlung', N'column', N'KaExterneBildungID'
GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO

GO
