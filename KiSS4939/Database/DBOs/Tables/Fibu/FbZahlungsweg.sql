CREATE TABLE [dbo].[FbZahlungsweg] (
	[FbZahlungswegID] [int] IDENTITY (1, 1) NOT NULL ,
	[FbKreditorID] [int] NOT NULL ,
	[BaBankID] [int] NULL ,
	[PCKontoNr] [varchar] (50) NULL ,
	[BankKontoNr] [varchar] (50) NULL ,
	[IBAN] [varchar] (50) NULL,
  [ZahlungsArtCode] [int] NULL ,
	[Zahlungsfrist] [int] NULL ,
	[BelegBankKontoNr] [varchar] (50) NULL ,
	[IsActive] [bit] NOT NULL CONSTRAINT [DF__FbZahlung__IsAct__2F85CD1E] DEFAULT (1),
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FbZahlungswegTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FbZahlungsweg] PRIMARY KEY  Clustered
	(
		[FbZahlungswegID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_FbZahlungsweg_BaBank] FOREIGN KEY
	(
		[BaBankID]
	) REFERENCES [dbo].[BaBank] (
		[BaBankID]
	),
	CONSTRAINT [FK_FbZahlungsweg_FbKreditor] FOREIGN KEY
	(
		[FbKreditorID]
	) REFERENCES [dbo].[FbKreditor] (
		[FbKreditorID]
	)
) ON [DATEN2]
GO
 CREATE  INDEX [IX_FbZahlungsweg_FbKreditorID] ON [dbo].[FbZahlungsweg]([FbKreditorID]) ON [DATEN2]
GO
 CREATE  INDEX [IX_FbZahlungsweg_BaBankID] ON [dbo].[FbZahlungsweg]([BaBankID]) ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbZahlungsweg Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbZahlungsweg', N'column', N'FbZahlungswegID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FbZahlungsweg_FbKreditor) => FbKreditor.FbKreditorID', N'user', N'dbo', N'table', N'FbZahlungsweg', N'column', N'FbKreditorID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FbZahlungsweg_BaBank) => BaBank.BaBankID', N'user', N'dbo', N'table', N'FbZahlungsweg', N'column', N'BaBankID'
GO

EXEC sp_addextendedproperty N'MS_Description', 'Konto-Nr des Kreditors im internationalen Format.', N'user', N'dbo', N'table', N'FbZahlungsweg', N'column', N'IBAN'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbZahlungsweg', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbZahlungsweg', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbZahlungsweg', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbZahlungsweg', @level2type=N'COLUMN',@level2name=N'Modified'
GO

ALTER TABLE [dbo].[FbZahlungsweg] ADD  CONSTRAINT [DF_FbZahlungsweg_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FbZahlungsweg] ADD  CONSTRAINT [DF_FbZahlungsweg_Modified]  DEFAULT (getdate()) FOR [Modified]
GO