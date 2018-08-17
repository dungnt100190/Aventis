CREATE TABLE [dbo].[KbMandant] (
	[KbMandantID] [int] IDENTITY (1, 1) NOT NULL ,
	[Mandant] [varchar] (100) NOT NULL ,
	[MandantTID] [int] NULL ,
	[KbMandantTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbMandant] PRIMARY KEY  Clustered
	(
		[KbMandantID]
	)  ON [DATEN3]
) ON [DATEN3]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbMandant Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbMandant', N'column', N'KbMandantID'
GO

GO

GO

GO

GO

GO

GO

GO
