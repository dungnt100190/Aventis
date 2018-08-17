CREATE TABLE [dbo].[KbPeriode] (
	[KbPeriodeID] [int] IDENTITY (1, 1) NOT NULL ,
	[KbMandantID] [int] NOT NULL ,
	[PeriodeVon] [datetime] NOT NULL ,
	[PeriodeBis] [datetime] NOT NULL ,
	[PeriodeStatusCode] [int] NOT NULL ,
	[VerbuchtBis] [datetime] NULL ,
	[KbPeriodeTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbPeriode] PRIMARY KEY  Clustered
	(
		[KbPeriodeID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_KbPeriode_KbMandant] FOREIGN KEY
	(
		[KbMandantID]
	) REFERENCES [dbo].[KbMandant] (
		[KbMandantID]
	)
) ON [DATEN2]
GO
 CREATE  INDEX [IX_KbPeriode_KbMandantID] ON [dbo].[KbPeriode]([KbMandantID]) ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Prim�rschl�ssel f�r KbPeriode Records (nach Prim�rschl�ssel-Standards)', N'user', N'dbo', N'table', N'KbPeriode', N'column', N'KbPeriodeID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschl�ssel (FK_KbPeriode_KbMandant) => KbMandant.KbMandantID', N'user', N'dbo', N'table', N'KbPeriode', N'column', N'KbMandantID'
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
