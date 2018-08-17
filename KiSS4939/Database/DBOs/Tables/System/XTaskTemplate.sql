CREATE TABLE [dbo].[XTaskTemplate] (
	[XTaskTemplateID] [int] IDENTITY (1, 1) NOT NULL ,
	[TaskTypeCode] [int] NOT NULL ,
	[TaskStatusCode] [int] NOT NULL ,
	[TaskSubject] [varchar] (100) NOT NULL ,
	[TaskSubjectTID] [int] NULL ,
	[TaskDescription] [varchar] (2500) NOT NULL ,
	[TaskDescriptionTID] [int] NULL ,
	[Creator] [varchar] (50) NOT NULL ,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_XTaskTemplate_Created] DEFAULT (GetDate()),
	[Modifier] [varchar] (50) NOT NULL ,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_XTaskTemplate_Modified] DEFAULT (GetDate()),
	[XTaskTemplateTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XTaskTemplate] PRIMARY KEY  Clustered
	(
		[XTaskTemplateID]
	)  ON [PRIMARY]
) ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel der Tabelle', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'XTaskTemplateID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Typ der Pendenz. Ist in der TaskType-LOV definiert.', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'TaskTypeCode'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Status der Pendenz. Ist in der TaskStatus-LOV definiert.', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'TaskStatusCode'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Betreff der Pendenz', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'TaskSubject'
GO
EXEC sp_addextendedproperty N'MS_Description', N'TID für die Mehrsprachigkeit des Betreffs.', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'TaskSubjectTID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Beschreibung der Pendenz', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'TaskDescription'
GO
EXEC sp_addextendedproperty N'MS_Description', N'TID für die Mehrsprachigkeit der Beschreibung.', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'TaskDescriptionTID'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Angaben zum Benutzer, welcher den Datensatz erstellt hat', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'Creator'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Wann der Datensatz erstellt wurde', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'Created'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'Modifier'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Wann der Datensatz zuletzt geändert wurde', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'Modified'
GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp, wird für die Änderungsverfolgung verwendet', N'user', N'dbo', N'table', N'XTaskTemplate', N'column', N'XTaskTemplateTS'
GO
 