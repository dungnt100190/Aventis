CREATE TABLE [dbo].[KbZahlungskonto] (
	[KbZahlungskontoID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) NOT NULL ,
	[VertragNr] [varchar] (20) NOT NULL ,
	[KontoNr] [varchar] (50) NOT NULL ,
	[BaBankID] [int] NULL ,
	[KbFinanzInstitutCode] [int] NOT NULL ,
	[KbDTAZugangTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbZahlungskonto] PRIMARY KEY  Clustered
	(
		[KbZahlungskontoID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_KbDTAZugang_BaBank] FOREIGN KEY
	(
		[BaBankID]
	) REFERENCES [dbo].[BaBank] (
		[BaBankID]
	)
) ON [DATEN1]
GO
 CREATE  INDEX [IX_KbZahlungskonto_BaBankID] ON [dbo].[KbZahlungskonto]([BaBankID]) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code um das Format der Zahlungsdatei zu unterscheiden. LOV: KbFinanzinstitutCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KbZahlungskonto', @level2type=N'COLUMN',@level2name=N'KbFinanzInstitutCode'
GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbZahlungskonto Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbZahlungskonto', N'column', N'KbZahlungskontoID'
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
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbDTAZugang_BaBank) => BaBank.BaBankID', N'user', N'dbo', N'table', N'KbZahlungskonto', N'column', N'BaBankID'
GO

GO

GO

GO

GO

GO

GO

GO
