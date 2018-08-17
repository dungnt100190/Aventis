CREATE TABLE [dbo].[FbPeriode](
	[FbPeriodeID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[PeriodeVon] [datetime] NOT NULL,
	[PeriodeBis] [datetime] NOT NULL,
	[PeriodeStatusCode] [int] NOT NULL,
	[FbTeamID] [int] NULL,
	[JournalablageortCode] [int] NULL,
	[FbPeriodeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FbPeriode] PRIMARY KEY CLUSTERED 
(
	[FbPeriodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO


CREATE NONCLUSTERED INDEX [IX_FbPeriode_BaPersonID] ON [dbo].[FbPeriode] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_FbPeriode_FbTeamID] ON [dbo].[FbPeriode] 
(
	[FbTeamID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für FbPeriode Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbPeriode', @level2type=N'COLUMN',@level2name=N'FbPeriodeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FbPeriode_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbPeriode', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum an welchem die Periode beginnt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbPeriode', @level2type=N'COLUMN',@level2name=N'PeriodeVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum an welchem die Periode endet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbPeriode', @level2type=N'COLUMN',@level2name=N'PeriodeBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Status der Periode - LOV FbPeriodeStatus' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbPeriode', @level2type=N'COLUMN',@level2name=N'PeriodeStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_FbPeriode_FbTeam) => FbTeam.FbTeamID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbPeriode', @level2type=N'COLUMN',@level2name=N'FbTeamID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ablageort der Belege pro Periode - LOV FbJournalablageort' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbPeriode', @level2type=N'COLUMN',@level2name=N'JournalablageortCode'
GO

ALTER TABLE [dbo].[FbPeriode]  WITH CHECK ADD  CONSTRAINT [FK_FbPeriode_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FbPeriode] CHECK CONSTRAINT [FK_FbPeriode_BaPerson]
GO

ALTER TABLE [dbo].[FbPeriode]  WITH CHECK ADD  CONSTRAINT [FK_FbPeriode_FbTeam] FOREIGN KEY([FbTeamID])
REFERENCES [dbo].[FbTeam] ([FbTeamID])
GO

ALTER TABLE [dbo].[FbPeriode] CHECK CONSTRAINT [FK_FbPeriode_FbTeam]
GO