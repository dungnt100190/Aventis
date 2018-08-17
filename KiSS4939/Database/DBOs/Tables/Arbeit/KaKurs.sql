CREATE TABLE [dbo].[KaKurs] (
	[KaKursID] [int] IDENTITY (1, 1) NOT NULL ,
	[Name] [varchar] (100) NOT NULL ,
	[Nr] [int] NOT NULL ,
	[AnzLektionen] [int] NULL ,
	[Plaetze] [int] NULL ,
	[SektionCode] [int] NOT NULL ,
	[ClosedFlag] [bit] NOT NULL CONSTRAINT [DF__KaKurs__ClosedFl__06111844] DEFAULT (0),
	[KaKursTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KaKurs] PRIMARY KEY  Clustered
	(
		[KaKursID]
	)  ON [DATEN1]
) ON [DATEN1]
GO
 CREATE  INDEX [IX_KaKurs_Name] ON [dbo].[KaKurs]([Name]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KaKurs Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KaKurs', N'column', N'KaKursID'
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
