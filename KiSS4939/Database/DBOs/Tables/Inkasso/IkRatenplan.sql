CREATE TABLE [dbo].[IkRatenplan] (
	[IkRatenplanID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaLeistungID] [int] NOT NULL ,
	[DatumVon] [datetime] NOT NULL ,
	[DatumBis] [datetime] NULL ,
	[IkRatenplanVereinbarungCode] [int] NULL ,
	[Bezeichnung] [varchar] (200) NULL ,
	[VereinbarungVom] [datetime] NULL ,
	[GesamtBetrag] [money] NOT NULL ,
	[BetragProMonat] [money] NOT NULL ,
	[LetzterProMonat] [money] NOT NULL ,
	[Bemerkung] [varchar] (500) NULL ,
	[IkRatenplanTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_IkRatenplan] PRIMARY KEY  Clustered
	(
		[IkRatenplanID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_IkRatenplan_FaLeistung] FOREIGN KEY
	(
		[FaLeistungID]
	) REFERENCES [dbo].[FaLeistung] (
		[FaLeistungID]
	)
) ON [DATEN3]
GO
 CREATE  INDEX [IX_IkRatenplan_FaLeistungID] ON [dbo].[IkRatenplan]([FaLeistungID]) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für IkRatenplan Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'IkRatenplan', N'column', N'IkRatenplanID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_IkRatenplan_FaLeistung) => FaLeistung.FaLeistungID', N'user', N'dbo', N'table', N'IkRatenplan', N'column', N'FaLeistungID'
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

GO

GO

GO

GO

GO

GO
