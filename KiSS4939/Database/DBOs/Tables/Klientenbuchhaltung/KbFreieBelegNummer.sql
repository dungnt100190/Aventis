CREATE TABLE [dbo].[KbFreieBelegNummer] (
	[KbBelegKreisID] [int] NOT NULL ,
	[BelegNr] [int] NOT NULL ,
	[KbFreieBelegNummerTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbFreieBelegNummer] PRIMARY KEY  Clustered
	(
		[KbBelegKreisID],
		[BelegNr]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_KbFreieBelegNummer_KbBelegKreis] FOREIGN KEY
	(
		[KbBelegKreisID]
	) REFERENCES [dbo].[KbBelegKreis] (
		[KbBelegKreisID]
	)
) ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbFreieBelegNummer Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbFreieBelegNummer', N'column', N'KbBelegKreisID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbFreieBelegNummer Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbFreieBelegNummer', N'column', N'BelegNr'
GO

GO

GO

GO

GO
