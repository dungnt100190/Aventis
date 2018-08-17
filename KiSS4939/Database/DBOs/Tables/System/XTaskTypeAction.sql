CREATE TABLE [dbo].[XTaskTypeAction](
	[XTaskTypeActionID] [int] IDENTITY(1,1) NOT NULL,
	[XTaskTypeActionTypeCode] [int] NOT NULL,
	[TaskTypeCode] [int] NOT NULL,
	[Bezeichnung] [varchar](max) NOT NULL,
	[BezeichnungTID] [int] NULL,
	[Betreff] [varchar](max) NULL,
	[BetreffTID] [int] NULL,
	[Text] [varchar](max) NULL,
	[TextTID] [int] NULL,
	[BenachrichtigungAktiv] [bit] NOT NULL,
	[ErstellerDarfAusfuehren] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[XTaskTypeActionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XTaskTypeAction] PRIMARY KEY CLUSTERED 
(
	[XTaskTypeActionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'XTaskTypeActionID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV XTaskTypeActionType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'XTaskTypeActionTypeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV TaskType' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'TaskTypeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Bezeichnung der Aktion (Button in Pendenzenverwaltung)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'Bezeichnung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Betreff der Benachrichtigung, die beim Ausführen erstellt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'Betreff'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der Text der Benachrichtigung, die beim Ausführen erstellt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definiert, ob beim Ausführen eine Benachrichtigung generiert wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'BenachrichtigungAktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt an, ob der Ersteller der Pendenz diese Aktion ausführen darf' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'ErstellerDarfAusfuehren'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction', @level2type=N'COLUMN',@level2name=N'XTaskTypeActionTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Lucas Loreggia' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bezeichnet eine Aktion, die beim Erledigen einer Pendenz ausgeführt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_In', @value=N'Pendenzenverwaltung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XTaskTypeAction'
GO

ALTER TABLE [dbo].[XTaskTypeAction] ADD  CONSTRAINT [DF_XTaskTypeAction_BenachrichtigungAktiv]  DEFAULT ((0)) FOR [BenachrichtigungAktiv]
GO

ALTER TABLE [dbo].[XTaskTypeAction] ADD  CONSTRAINT [DF_XTaskTypeAction_ErstellerDarfAusfuehren]  DEFAULT ((0)) FOR [ErstellerDarfAusfuehren]
GO

ALTER TABLE [dbo].[XTaskTypeAction] ADD  CONSTRAINT [DF_XTaskTypeAction_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XTaskTypeAction] ADD  CONSTRAINT [DF_XTaskTypeAction_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

