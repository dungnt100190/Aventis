CREATE TABLE [dbo].[KaJobtimalVertrag] (
	[KaJobtimalVertragID] [int] IDENTITY (1, 1) NOT NULL ,
	[KaVermittlungVorschlagID] [int] NULL ,
	[Datum] [datetime] NULL ,
	[KaJobtimalVertragTypCode] [int] NOT NULL ,
	[DocumentID] [int] NULL ,
	[KaJobtimalVertragTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaJobtimalVertrag] PRIMARY KEY  Clustered
	(
		[KaJobtimalVertragID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_KaJobtimalVertrag_KaVermittlungVorschlag] FOREIGN KEY
	(
		[KaVermittlungVorschlagID]
	) REFERENCES [dbo].[KaVermittlungVorschlag] (
		[KaVermittlungVorschlagID]
	)
) ON [DATEN3]
GO
 CREATE  INDEX [IX_KaJobtimalVertrag_KaVermittlungVorschlagID] ON [dbo].[KaJobtimalVertrag]([KaVermittlungVorschlagID]) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaJobtimalVertrag Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaJobtimalVertrag', N'column', N'KaJobtimalVertragID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaJobtimalVertrag_KaVermittlungVorschlag) => KaVermittlungVorschlag.KaVermittlungVorschlagID', N'user', N'dbo', N'table', N'KaJobtimalVertrag', N'column', N'KaVermittlungVorschlagID'
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
