CREATE TABLE [dbo].[FaWeisungProtokoll] (
	[FaWeisungProtokollID] [int] IDENTITY (1, 1) NOT NULL ,
	[FaWeisungID] [int] NOT NULL ,
	[Aktion] [varchar] (100) NULL ,
	[Bemerkung] [varchar] (200) NULL ,
	[Termin] [datetime] NULL ,
	[Verantwortlich] [varchar] (50) NULL ,
	[Creator] [varchar] (50) NOT NULL ,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_FaWeisungProtokoll_Created] DEFAULT (GetDate()),
	[Modifier] [varchar] (50) NOT NULL ,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_FaWeisungProtokoll_Modified] DEFAULT (GetDate()),
	[FaWeisung_ProtokollTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_FaWeisungProtokoll] PRIMARY KEY  Clustered
	(
		[FaWeisungProtokollID]
	)  ON [PRIMARY] ,
	CONSTRAINT [FK_FaWeisungProtokoll_FaWeisung] FOREIGN KEY
	(
		[FaWeisungID]
	) REFERENCES [dbo].[FaWeisung] (
		[FaWeisungID]
	) ON DELETE CASCADE
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Beinhaltet das Protokoll jeder Weisungen', N'user', N'dbo', N'table', N'FaWeisungProtokoll'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel von FaWeisung_Protokoll Records', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'FaWeisungProtokollID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel auf FaWeisung', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'FaWeisungID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Aktion die für die Weisung gemacht wurde', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Aktion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Bemerkung für die Weisung', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Bemerkung'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Nächster Termin', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Termin'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Verantwortliche Person für die nächste Aktion', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Verantwortlich'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Angaben zum Benutzer, welcher den Datensatz erstellt hat', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Creator'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Wann der Datensatz erstellt wurde', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Created'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Modifier'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Wann der Datensatz zuletzt geändert wurde', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Modified'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp, wird für die Änderungsverfolgung verwendet', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'FaWeisung_ProtokollTS'
GO
