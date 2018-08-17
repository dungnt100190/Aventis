CREATE TABLE [dbo].[KbZahlungslaufValuta] (
	[KbZahlungslaufValutaID] [int] IDENTITY (1, 1) NOT NULL ,
	[Jahr] [int] NOT NULL ,
	[Monat] [int] NOT NULL ,
	[DatMonatlich] [datetime] NULL ,
	[DatTeil1] [datetime] NULL ,
	[DatTeil2] [datetime] NULL ,
	[Dat14Tage1] [datetime] NULL ,
	[Dat14Tage2] [datetime] NULL ,
	[Dat14Tage3] [datetime] NULL ,
	[DatWoche1] [datetime] NULL ,
	[DatWoche2] [datetime] NULL ,
	[DatWoche3] [datetime] NULL ,
	[DatWoche4] [datetime] NULL ,
	[DatWoche5] [datetime] NULL ,
	[KbZahlungslaufValutaTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbZahlungslaufValuta] PRIMARY KEY  Clustered
	(
		[KbZahlungslaufValutaID]
	)  ON [DATEN3]
) ON [DATEN3]
GO
 CREATE  Unique  INDEX [IX_KbZahlungslaufValuta_JahrMonat_Unique] ON [dbo].[KbZahlungslaufValuta]([Jahr], [Monat]) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbZahlungslaufValuta Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbZahlungslaufValuta', N'column', N'KbZahlungslaufValutaID'
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
