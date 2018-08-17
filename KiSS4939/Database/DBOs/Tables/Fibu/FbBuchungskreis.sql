CREATE TABLE [dbo].[FbBuchungskreis] (
	[FbBuchungskreisID] [int] IDENTITY (1, 1) NOT NULL ,
	[FbBuchungskreisCode] [int] NOT NULL ,
	[BaPersonID] [int] NOT NULL ,
	[BuchungsDatum] [datetime] NULL ,
	[SollKtoNr] [int] NOT NULL ,
	[HabenKtoNr] [int] NOT NULL ,
	[Betrag] [money] NULL ,
	[Text] [varchar] (200) NOT NULL ,
	[FbBuchungskreisTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FbBuchungskreis] PRIMARY KEY  Clustered
	(
		[FbBuchungskreisID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_FbBuchungskreis_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [DATEN1]
GO
 CREATE  INDEX [IX_FbBuchungskreis_BaPersonID] ON [dbo].[FbBuchungskreis]([BaPersonID]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbBuchungskreis Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbBuchungskreis', N'column', N'FbBuchungskreisID'
GO

GO

GO

GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FbBuchungskreis_BaPerson) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'FbBuchungskreis', N'column', N'BaPersonID'
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
