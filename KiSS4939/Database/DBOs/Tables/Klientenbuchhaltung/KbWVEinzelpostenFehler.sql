CREATE TABLE [dbo].[KbWVEinzelpostenFehler] (
	[KbWVEinzelpostenFehlerID] [int] IDENTITY (1, 1) NOT NULL ,
	[KbWVLaufID] [int] NOT NULL ,
	[KbBuchungKostenartID] [int] NOT NULL ,
	[BaPersonID] [int] NOT NULL ,
	[WVFehlermeldung] [varchar] (2000) NOT NULL ,
	[KbWVEinzelpostenFehlerTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbWVEinzelpostenFehler] PRIMARY KEY  Clustered
	(
		[KbWVEinzelpostenFehlerID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_KbWVEinzelpostenFehler_BaPerson] FOREIGN KEY
	(
		[BaPersonID]
	) REFERENCES [dbo].[BaPerson] (
		[BaPersonID]
	),
	CONSTRAINT [FK_KbWVEinzelpostenFehler_KbBuchungKostenart] FOREIGN KEY
	(
		[KbBuchungKostenartID]
	) REFERENCES [dbo].[KbBuchungKostenart] (
		[KbBuchungKostenartID]
	),
	CONSTRAINT [FK_KbWVEinzelpostenFehler_KbWVLauf] FOREIGN KEY
	(
		[KbWVLaufID]
	) REFERENCES [dbo].[KbWVLauf] (
		[KbWVLaufID]
	)
) ON [DATEN1]
GO
 CREATE  INDEX [IX_KbWVEinzelpostenFehler_KbWVLaufID] ON [dbo].[KbWVEinzelpostenFehler]([KbWVLaufID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_KbWVEinzelpostenFehler_KbBuchungKostenartID] ON [dbo].[KbWVEinzelpostenFehler]([KbBuchungKostenartID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_KbWVEinzelpostenFehler_BaPersonID] ON [dbo].[KbWVEinzelpostenFehler]([BaPersonID]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbWVEinzelpostenFehler Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbWVEinzelpostenFehler', N'column', N'KbWVEinzelpostenFehlerID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelpostenFehler_KbWVLauf) => KbWVLauf.KbWVLaufID', N'user', N'dbo', N'table', N'KbWVEinzelpostenFehler', N'column', N'KbWVLaufID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelpostenFehler_KbBuchungKostenart) => KbBuchungKostenart.KbBuchungKostenartID', N'user', N'dbo', N'table', N'KbWVEinzelpostenFehler', N'column', N'KbBuchungKostenartID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVEinzelpostenFehler_BaPerson) => BaPerson.BaPersonID', N'user', N'dbo', N'table', N'KbWVEinzelpostenFehler', N'column', N'BaPersonID'
GO

GO

GO

GO

GO

GO

GO

GO
