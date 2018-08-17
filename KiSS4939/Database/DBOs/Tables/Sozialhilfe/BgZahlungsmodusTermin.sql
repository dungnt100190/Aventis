CREATE TABLE [dbo].[BgZahlungsmodusTermin] (
	[BgZahlungsmodusTerminID] [int] IDENTITY (1, 1) NOT NULL ,
	[BgZahlungsmodusID] [int] NOT NULL ,
	[Datum] [datetime] NULL ,
	[TagImMonat] [int] NULL ,
	[ImVormonat] [bit] NOT NULL CONSTRAINT [DF_BgZahlungsmodusTermin_ImVormonat] DEFAULT (0),
	[nMonatlich] [smallint] NOT NULL CONSTRAINT [DF_BgZahlungsmodusTermin_nMonatlich] DEFAULT (1),
	[BetragGleich] [bit] NOT NULL CONSTRAINT [DF_BgZahlungsmodusTermin_BetragGleich] DEFAULT (1),
	[BgZahlungsmodusTerminTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_BgZahlungsmodusTermin] PRIMARY KEY  Clustered
	(
		[BgZahlungsmodusTerminID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_BgZahlungsmodusTermin_BgZahlungsmodus] FOREIGN KEY
	(
		[BgZahlungsmodusID]
	) REFERENCES [dbo].[BgZahlungsmodus] (
		[BgZahlungsmodusID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [DATEN1]
GO
 CREATE  INDEX [IX_BgZahlungsmodusTermin_BgZahlungsmodusID] ON [dbo].[BgZahlungsmodusTermin]([BgZahlungsmodusID]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für BgZahlungsmodusTermin Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'BgZahlungsmodusTermin', N'column', N'BgZahlungsmodusTerminID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_BgZahlungsmodusTermin_BgZahlungsmodus) => BgZahlungsmodus.BgZahlungsmodusID', N'user', N'dbo', N'table', N'BgZahlungsmodusTermin', N'column', N'BgZahlungsmodusID'
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
