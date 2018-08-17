CREATE TABLE [dbo].[BgZahlungsmodus] (
	[BgZahlungsmodusID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaLeistungID] [int] NOT NULL ,
	[NameZahlungsmodus] [varchar] (100) NOT NULL ,
	[KbAuszahlungsArtCode] [int] NOT NULL ,
	[KontoKlient] [bit] NOT NULL CONSTRAINT [DF_BgZahlungsmodus_KontoKlient] DEFAULT (0),
	[BaZahlungswegID] [int] NULL ,
	[ReferenzNummer] [varchar] (50) NULL ,
	[DatumVon] [datetime] NOT NULL CONSTRAINT [DF_BgZahlungsmodus_DatumVon] DEFAULT (GetDate()),
	[DatumBis] [datetime] NULL ,
	[OldID] [int] NULL ,
	[BgZahlungsmodusTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_BgZahlungsmodus] PRIMARY KEY  Clustered
	(
		[BgZahlungsmodusID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_BgZahlungsmodus_BaZahlungsweg] FOREIGN KEY
	(
		[BaZahlungswegID]
	) REFERENCES [dbo].[BaZahlungsweg] (
		[BaZahlungswegID]
	),
	CONSTRAINT [FK_BgZahlungsmodus_FaLeistung] FOREIGN KEY
	(
		[FaLeistungID]
	) REFERENCES [dbo].[FaLeistung] (
		[FaLeistungID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [DATEN3]
GO
 CREATE  INDEX [IX_BgZahlungsmodus_FaLeistungID] ON [dbo].[BgZahlungsmodus]([FaLeistungID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_BgZahlungsmodus_BaZahlungswegID] ON [dbo].[BgZahlungsmodus]([BaZahlungswegID]) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für BgZahlungsmodus Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'BgZahlungsmodus', N'column', N'BgZahlungsmodusID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_BgZahlungsmodus_FaLeistung) => FaLeistung.FaLeistungID', N'user', N'dbo', N'table', N'BgZahlungsmodus', N'column', N'FaLeistungID'
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
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_BgZahlungsmodus_BaZahlungsweg) => BaZahlungsweg.BaZahlungswegID', N'user', N'dbo', N'table', N'BgZahlungsmodus', N'column', N'BaZahlungswegID'
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
