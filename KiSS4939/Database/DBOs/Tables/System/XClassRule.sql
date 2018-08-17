CREATE TABLE [dbo].[XClassRule] (
	[XClassRuleID] [int] IDENTITY (1, 1) NOT NULL ,
	[ClassName] [varchar] (255) NOT NULL ,
	[ControlName] [varchar] (255) NULL ,
	[ComponentName] [varchar] (255) NULL ,
	[XRuleID] [int] NOT NULL ,
	[SortKey] [int] NOT NULL CONSTRAINT [DF_XClassRule_SortOrder] DEFAULT ((100)),
	[Active] [bit] NOT NULL CONSTRAINT [DF_XClassRule_Active] DEFAULT ((1)),
	[XClassRuleTS] [timestamp] NOT NULL ,
	CONSTRAINT [PK_XClassRule] PRIMARY KEY  NONCLUSTERED
	(
		[XClassRuleID]
	) WITH  FILLFACTOR = 90  ON [PRIMARY] ,
	CONSTRAINT [FK_XClassRule_XClass] FOREIGN KEY
	(
		[ClassName]
	) REFERENCES [dbo].[XClass] (
		[ClassName]
	) ON DELETE CASCADE  ON UPDATE CASCADE ,
	CONSTRAINT [FK_XClassRule_XClassComponent] FOREIGN KEY
	(
		[ClassName],
		[ComponentName]
	) REFERENCES [dbo].[XClassComponent] (
		[ClassName],
		[ComponentName]
	),
	CONSTRAINT [FK_XClassRule_XClassControl] FOREIGN KEY
	(
		[ClassName],
		[ControlName]
	) REFERENCES [dbo].[XClassControl] (
		[ClassName],
		[ControlName]
	),
	CONSTRAINT [FK_XClassRule_XRule] FOREIGN KEY
	(
		[XRuleID]
	) REFERENCES [dbo].[XRule] (
		[XRuleID]
	) ON UPDATE CASCADE
) ON [PRIMARY]
GO
 CREATE  Clustered  INDEX [IX_XClassRule] ON [dbo].[XClassRule]([ClassName], [ControlName], [ComponentName]) WITH  FILLFACTOR = 90 ON [PRIMARY]
GO
EXEC sp_addextendedproperty N'MS_Description', N'Beinhaltet sämtliche Regeln (C#-Code) einer Klasse', N'user', N'dbo', N'table', N'XClassRule'
GO
EXEC sp_addextendedproperty N'Used_in', N'KiSS Core, Business Designer', N'user', N'dbo', N'table', N'XClassRule'
GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Primärschlüssel für XClassRule Records (nach Primärschlüssel-Standards)', N'user', N'dbo', N'table', N'XClassRule', N'column', N'XClassRuleID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XClassRule_XClassControl) => XClassControl.ClassName, Name der Klasse, zu welcher die Regel gehört', N'user', N'dbo', N'table', N'XClassRule', N'column', N'ClassName'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XClassRule_XClassControl) => XClassControl.ControlName, Optionaler Name des Controls, welche die Regel betrifft', N'user', N'dbo', N'table', N'XClassRule', N'column', N'ControlName'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XClassRule_XClassComponent) => XClassComponent.ComponentName, Optionaler Name des Components, welche die Regel betrifft', N'user', N'dbo', N'table', N'XClassRule', N'column', N'ComponentName'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Fremdschlüssel (FK_XClassRule_XRule) => XRule.XRuleID, ID der Regel, welche den Code und weitere Angaben beinhaltet', N'user', N'dbo', N'table', N'XClassRule', N'column', N'XRuleID'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Sortierungsinformation der einzelnen Regel', N'user', N'dbo', N'table', N'XClassRule', N'column', N'SortKey'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Flag, ob die Regel aktiv ist oder nicht ausgewertet wird beim Compile', N'user', N'dbo', N'table', N'XClassRule', N'column', N'Active'
GO

GO

GO
EXEC sp_addextendedproperty N'MS_Description', N'Timestamp, wird für die Änderungsverfolgung verwendet', N'user', N'dbo', N'table', N'XClassRule', N'column', N'XClassRuleTS'
GO

GO
