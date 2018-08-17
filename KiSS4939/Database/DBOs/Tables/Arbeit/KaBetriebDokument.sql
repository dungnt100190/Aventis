CREATE TABLE [dbo].[KaBetriebDokument] (
	[KaBetriebDokumentID] [int] IDENTITY (1, 1) NOT NULL ,
	[KaBetriebID] [int] NULL ,
	[Datum] [datetime] NULL ,
	[AbsenderID] [int] NULL ,
	[AdressatID] [int] NULL ,
	[Stichwort] [varchar] (100) NULL ,
	[DokumentDocID] [int] NULL ,
	[KaBetriebDokumentTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaBetriebDokument] PRIMARY KEY  Clustered
	(
		[KaBetriebDokumentID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_KaBetriebDokument_KaBetrieb] FOREIGN KEY
	(
		[KaBetriebID]
	) REFERENCES [dbo].[KaBetrieb] (
		[KaBetriebID]
	)
) ON [DATEN1]
GO
 CREATE  INDEX [IX_KaBetriebDokument_KaBetriebID] ON [dbo].[KaBetriebDokument]([KaBetriebID]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaBetriebDokument Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaBetriebDokument', N'column', N'KaBetriebDokumentID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaBetriebDokument_KaBetrieb) => KaBetrieb.KaBetriebID', N'user', N'dbo', N'table', N'KaBetriebDokument', N'column', N'KaBetriebID'
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
