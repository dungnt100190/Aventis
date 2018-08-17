CREATE TABLE [dbo].[VmErnennung] (
	[VmErnennungID] [int] IDENTITY (1, 1) NOT NULL ,
	[VmMassnahmeID] [int] NOT NULL ,
	[UserID] [int] NULL ,
	[VmPriMaID] [int] NULL ,
	[Ernennung] [datetime] NULL ,
	[ErnennungsurkundeDokID] [int] NULL ,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmErnennungTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_VmErnennung] PRIMARY KEY  Clustered
	(
		[VmErnennungID]
	)  ON [DATEN3] ,
	CONSTRAINT [FK_VmErnennung_VmMassnahme] FOREIGN KEY
	(
		[VmMassnahmeID]
	) REFERENCES [dbo].[VmMassnahme] (
		[VmMassnahmeID]
	),
	CONSTRAINT [FK_VmErnennung_VmPriMa] FOREIGN KEY
	(
		[VmPriMaID]
	) REFERENCES [dbo].[VmPriMa] (
		[VmPriMaID]
	),
	CONSTRAINT [FK_VmErnennung_XUser] FOREIGN KEY
	(
		[UserID]
	) REFERENCES [dbo].[XUser] (
		[UserID]
	)
) ON [DATEN3]
GO
 CREATE  INDEX [IX_VmErnennung_VmMassnahmeID] ON [dbo].[VmErnennung]([VmMassnahmeID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_VmErnennung_UserID] ON [dbo].[VmErnennung]([UserID]) ON [DATEN3]
GO
 CREATE  INDEX [IX_VmErnennung_VmPriMaID] ON [dbo].[VmErnennung]([VmPriMaID]) ON [DATEN3]
GO

ALTER TABLE [dbo].[VmErnennung] ADD  CONSTRAINT [DF_VmErnennung_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmErnennung] ADD  CONSTRAINT [DF_VmErnennung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmErnennung] ADD  CONSTRAINT [DF_VmErnennung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für VmErnennung Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'VmErnennung', N'column', N'VmErnennungID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_VmErnennung_VmMassnahme) => VmMassnahme.VmMassnahmeID', N'user', N'dbo', N'table', N'VmErnennung', N'column', N'VmMassnahmeID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_VmErnennung_XUser) => XUser.UserID', N'user', N'dbo', N'table', N'VmErnennung', N'column', N'UserID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Fremdschlüssel (FK_VmErnennung_VmPriMa) => VmPriMa.VmPriMaID', N'user', N'dbo', N'table', N'VmErnennung', N'column', N'VmPriMaID'
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
