CREATE TABLE [dbo].[IkBetreibungAusgleich] (
	[IkBetreibungAusgleichID] [int] IDENTITY (1, 1) NOT NULL ,
	[IkBetreibungID] [int] NOT NULL ,
	[AusgleichBuchungID] [int] NOT NULL ,
	[Betrag] [money] NOT NULL CONSTRAINT [DF_IkBetreibungAusgleich_Betrag] DEFAULT (0),
	[IkBetreibungAusgleichTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_IkBetreibungAusgleich] PRIMARY KEY  Clustered
	(
		[IkBetreibungAusgleichID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_IkBetreibungAusgleich_IkBetreibung] FOREIGN KEY
	(
		[IkBetreibungID]
	) REFERENCES [dbo].[IkBetreibung] (
		[IkBetreibungID]
	),
	CONSTRAINT [FK_IkBetreibungAusgleich_KbBuchung] FOREIGN KEY
	(
		[AusgleichBuchungID]
	) REFERENCES [dbo].[KbBuchung] (
		[KbBuchungID]
	)
) ON [DATEN2]
GO
 CREATE  INDEX [IX_IkBetreibungAusgleich_IkBetreibungID] ON [dbo].[IkBetreibungAusgleich]([IkBetreibungID]) ON [DATEN2]
GO
 CREATE  INDEX [IX_IkBetreibungAusgleich_AusgleichBuchungID] ON [dbo].[IkBetreibungAusgleich]([AusgleichBuchungID]) ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für IkBetreibungAusgleich Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'IkBetreibungAusgleich', N'column', N'IkBetreibungAusgleichID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_IkBetreibungAusgleich_IkBetreibung) => IkBetreibung.IkBetreibungID', N'user', N'dbo', N'table', N'IkBetreibungAusgleich', N'column', N'IkBetreibungID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_IkBetreibungAusgleich_KbBuchung) => KbBuchung.KbBuchungID', N'user', N'dbo', N'table', N'IkBetreibungAusgleich', N'column', N'AusgleichBuchungID'
GO

GO

GO

GO

GO

GO

GO

GO
