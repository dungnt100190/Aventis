CREATE TABLE [dbo].[KbWVLauf] (
	[KbWVLaufID] [int] IDENTITY (1, 1) NOT NULL ,
	[UserID] [int] NOT NULL ,
	[KbPeriodeID] [int] NOT NULL ,
	[DatumBisWVLauf] [datetime] NOT NULL ,
	[StartDatum] [datetime] NOT NULL CONSTRAINT [DF_KbWVLauf_StartDatum] DEFAULT (GetDate()),
	[EndDatum] [datetime] NULL ,
	[Testlauf] [bit] NOT NULL CONSTRAINT [DF_KbWVLauf_Testlauf] DEFAULT ((0)),
	[KbWVLaufTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_KbWVLauf] PRIMARY KEY  Clustered
	(
		[KbWVLaufID]
	)  ON [DATEN2] ,
	CONSTRAINT [FK_KbWVLauf_KbPeriode] FOREIGN KEY
	(
		[KbPeriodeID]
	) REFERENCES [dbo].[KbPeriode] (
		[KbPeriodeID]
	),
	CONSTRAINT [FK_KbWVLauf_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	)
) ON [DATEN2]
GO
 CREATE  INDEX [IX_KbWVLauf_UserID] ON [dbo].[KbWVLauf]([UserID]) ON [DATEN2]
GO
 CREATE  INDEX [IX_KbWVLauf_KbPeriodeID] ON [dbo].[KbWVLauf]([KbPeriodeID]) ON [DATEN2]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für KbWVLauf Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'KbWVLauf', N'column', N'KbWVLaufID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVLauf_XUser) => XUser.UserID', N'user', N'dbo', N'table', N'KbWVLauf', N'column', N'UserID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_KbWVLauf_KbPeriode) => KbPeriode.KbPeriodeID', N'user', N'dbo', N'table', N'KbWVLauf', N'column', N'KbPeriodeID'
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
