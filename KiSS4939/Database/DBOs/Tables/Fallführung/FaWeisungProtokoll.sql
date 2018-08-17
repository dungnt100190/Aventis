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
EXEC sp_addextendedproperty N'MS_Description', N'Prim�rschl�ssel von FaWeisung_Protokoll Records', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'FaWeisungProtokollID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschl�ssel auf FaWeisung', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'FaWeisungID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Aktion die f�r die Weisung gemacht wurde', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Aktion'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Bemerkung f�r die Weisung', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Bemerkung'
GO
EXEC sp_addextendedproperty N'MS_Description', N'N�chster Termin', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Termin'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Verantwortliche Person f�r die n�chste Aktion', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Verantwortlich'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Angaben zum Benutzer, welcher den Datensatz erstellt hat', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Creator'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Wann der Datensatz erstellt wurde', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Created'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Angaben zum Benutzer, welcher den Datensatz zuletzt ge�ndert hat', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Modifier'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Wann der Datensatz zuletzt ge�ndert wurde', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'Modified'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp, wird f�r die �nderungsverfolgung verwendet', N'user', N'dbo', N'table', N'FaWeisungProtokoll', N'column', N'FaWeisung_ProtokollTS'
GO
