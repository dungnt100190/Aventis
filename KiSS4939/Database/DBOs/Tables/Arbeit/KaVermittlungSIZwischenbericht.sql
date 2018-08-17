CREATE TABLE [dbo].[KaVermittlungSIZwischenbericht] (
	[KaVermittlungSIZwischenberichtID] [int] IDENTITY (1, 1) NOT NULL ,
	[KaVermittlungVorschlagID] [int] NULL ,
	[Anfrage] [datetime] NULL ,
	[Mahnung] [datetime] NULL ,
	[Eingang] [datetime] NULL ,
	[Bemerkung] [varchar] (2000) NULL ,
	[InterventionCode] [int] NULL ,
	[VorgeseheneMassnahmenCode] [int] NULL ,
	[ZwischenberichtSD] [datetime] NULL ,
	[KaVermittlungSIZwischenberichtTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaVermittlungSIZwischenbericht] PRIMARY KEY  Clustered
	(
		[KaVermittlungSIZwischenberichtID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_KaVermittlungSIZwischenbericht_KaVermittlungVorschlag] FOREIGN KEY
	(
		[KaVermittlungVorschlagID]
	) REFERENCES [dbo].[KaVermittlungVorschlag] (
		[KaVermittlungVorschlagID]
	)
) ON [DATEN3]
GO
 CREATE  INDEX [IX_KaVermittlungSIZwischenbericht_KaVermittlungVorschlagID] ON [dbo].[KaVermittlungSIZwischenbericht]([KaVermittlungVorschlagID]) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaVermittlungSIZwischenbericht Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaVermittlungSIZwischenbericht', N'column', N'KaVermittlungSIZwischenberichtID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KaVermittlungSIZwischenbericht_KaVermittlungVorschlag) => KaVermittlungVorschlag.KaVermittlungVorschlagID', N'user', N'dbo', N'table', N'KaVermittlungSIZwischenbericht', N'column', N'KaVermittlungVorschlagID'
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
