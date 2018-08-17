CREATE TABLE [dbo].[XMigrationFehler] (
	[XMigrationFehlerID] [int] IDENTITY (1, 1) NOT NULL ,
	[FehlerCode] [int] NOT NULL ,
	[PK] [int] NOT NULL ,
	[Wert] [varchar] (1000) NULL ,
	[Erledigt] [bit] NOT NULL CONSTRAINT [DF_XMigrationFehler_Erledigt] DEFAULT (0),
	[XMigrationFehlerTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XMigrationFehler] PRIMARY KEY  NONCLUSTERED
	(
		[XMigrationFehlerID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY]
) ON [PRIMARY]
GO
 CREATE  Clustered  INDEX [IX_XMigrationFehler] ON [dbo].[XMigrationFehler]([FehlerCode], [PK]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO

GO
EXEC sp_addextendedproperty N'MS_Description', 'Primärschlüssel für XMigrationFehler Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XMigrationFehler', N'column', N'XMigrationFehlerID'
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
