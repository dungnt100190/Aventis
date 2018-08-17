CREATE TABLE [dbo].[IkRatenplanForderung] (
	[IkRatenplanForderungID] [int] IDENTITY (1, 1) NOT NULL ,
	[IkRatenplanID] [int] NULL ,
	[IkRechtstitelID] [int] NULL ,
	[IkPositionID] [int] NULL ,
	[IkForderungID] [int] NULL ,
	[IkRatenplanForderungTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_IkRatenplanForderung] PRIMARY KEY  Clustered
	(
		[IkRatenplanForderungID]
	)  ON [DATEN1] ,
	CONSTRAINT [FK_IkRatenplanForderung_IkForderung] FOREIGN KEY
	(
		[IkForderungID]
	) REFERENCES [dbo].[IkForderung] (
		[IkForderungID]
	),
	CONSTRAINT [FK_IkRatenplanForderung_IkPosition] FOREIGN KEY
	(
		[IkPositionID]
	) REFERENCES [dbo].[IkPosition] (
		[IkPositionID]
	),
	CONSTRAINT [FK_IkRatenplanForderung_IkRatenplan] FOREIGN KEY
	(
		[IkRatenplanID]
	) REFERENCES [dbo].[IkRatenplan] (
		[IkRatenplanID]
	),
	CONSTRAINT [FK_IkRatenplanForderung_IkRechtstitel] FOREIGN KEY
	(
		[IkRechtstitelID]
	) REFERENCES [dbo].[IkRechtstitel] (
		[IkRechtstitelID]
	)
) ON [DATEN1]
GO
 CREATE  INDEX [IX_IkRatenplanForderung_IkRatenplanID] ON [dbo].[IkRatenplanForderung]([IkRatenplanID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_IkRatenplanForderung_IkRechtstitelID] ON [dbo].[IkRatenplanForderung]([IkRechtstitelID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_IkRatenplanForderung_IkPositionID] ON [dbo].[IkRatenplanForderung]([IkPositionID]) ON [DATEN1]
GO
 CREATE  INDEX [IX_IkRatenplanForderung_IkForderungID] ON [dbo].[IkRatenplanForderung]([IkForderungID]) ON [DATEN1]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für IkRatenplanForderung Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'IkRatenplanForderung', N'column', N'IkRatenplanForderungID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_IkRatenplanForderung_IkRatenplan) => IkRatenplan.IkRatenplanID', N'user', N'dbo', N'table', N'IkRatenplanForderung', N'column', N'IkRatenplanID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_IkRatenplanForderung_IkRechtstitel) => IkRechtstitel.IkRechtstitelID', N'user', N'dbo', N'table', N'IkRatenplanForderung', N'column', N'IkRechtstitelID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_IkRatenplanForderung_IkPosition) => IkPosition.IkPositionID', N'user', N'dbo', N'table', N'IkRatenplanForderung', N'column', N'IkPositionID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_IkRatenplanForderung_IkForderung) => IkForderung.IkForderungID', N'user', N'dbo', N'table', N'IkRatenplanForderung', N'column', N'IkForderungID'
GO

GO

GO

GO

GO
