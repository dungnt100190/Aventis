CREATE TABLE [dbo].[IkForderungPosition] (
	[IkForderungPositionID] [int] IDENTITY (1, 1) NOT NULL ,
	[IkForderungID] [int] NOT NULL ,
	[IkPositionID] [int] NOT NULL ,
	[IkForderungPositionTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_IkForderungPosition] PRIMARY KEY  Clustered
	(
		[IkForderungPositionID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_IkForderungPosition_IkForderung] FOREIGN KEY
	(
		[IkForderungID]
	) REFERENCES [dbo].[IkForderung] (
		[IkForderungID]
	) ON DELETE CASCADE ,
	CONSTRAINT [FK_IkForderungPosition_IkPosition] FOREIGN KEY
	(
		[IkPositionID]
	) REFERENCES [dbo].[IkPosition] (
		[IkPositionID]
	) ON DELETE CASCADE
) ON [DATEN1]
GO
 CREATE  INDEX [IX_IkForderungPosition_IkForderunngID] ON [dbo].[IkForderungPosition]([IkForderungID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_IkForderungPosition_IkPositionID] ON [dbo].[IkForderungPosition]([IkPositionID]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für IkForderungPosition Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'IkForderungPosition', N'column', N'IkForderungPositionID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_IkForderungPosition_IkForderung) => IkForderung.IkForderungID', N'user', N'dbo', N'table', N'IkForderungPosition', N'column', N'IkForderungID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_IkForderungPosition_IkPosition) => IkPosition.IkPositionID', N'user', N'dbo', N'table', N'IkForderungPosition', N'column', N'IkPositionID'
GO

GO

GO

GO

GO
