CREATE TABLE [dbo].[FbDTAZugang] (
	[FbDTAZugangID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (50) NOT NULL ,
	[VertragNr] [varchar] (20) NOT NULL ,
	[KontoNr] [varchar] (50) NOT NULL ,
	[BaBankID] [int] NULL ,
	[FbTeamID] [int] NULL ,
	[KbFinanzInstitutCode] [int] NOT NULL ,
	[FbDTAZugangTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FbDTAZugang] PRIMARY KEY  Clustered
	(
		[FbDTAZugangID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_FbDTAZugang_BaBank] FOREIGN KEY
	(
		[BaBankID]
	) REFERENCES [dbo].[BaBank] (
		[BaBankID]
	),
	CONSTRAINT [FK_FbDTAZugang_FbTeam] FOREIGN KEY
	(
		[FbTeamID]
	) REFERENCES [dbo].[FbTeam] (
		[FbTeamID]
	) ON DELETE CASCADE  ON UPDATE CASCADE
) ON [DATEN1]
GO
 CREATE  INDEX [IX_FbDTAZugang_BaBankID] ON [dbo].[FbDTAZugang]([BaBankID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_FbDTAZugang_FbTeamID] ON [dbo].[FbDTAZugang]([FbTeamID]) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code um das Format der Zahlungsdatei zu unterscheiden. LOV: KbFinanzinstitutCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FbDTAZugang', @level2type=N'COLUMN',@level2name=N'KbFinanzInstitutCode'
GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für FbDTAZugang Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'FbDTAZugang', N'column', N'FbDTAZugangID'
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
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FbDTAZugang_BaBank) => BaBank.BaBankID', N'user', N'dbo', N'table', N'FbDTAZugang', N'column', N'BaBankID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_FbDTAZugang_FbTeam) => FbTeam.FbTeamID', N'user', N'dbo', N'table', N'FbDTAZugang', N'column', N'FbTeamID'
GO

GO

GO

GO

GO
