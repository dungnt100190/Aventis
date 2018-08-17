CREATE TABLE [dbo].[XClassComponent](
	[ClassName] [varchar](255) NOT NULL,
	[ComponentName] [varchar](255) NOT NULL,
	[TypeName] [varchar](500) NOT NULL,
	[ComponentTID] [int] NULL,
	[SelectStatement] [varchar](max) NULL,
	[TableName] [varchar](255) NULL,
	[PropertiesXML] [varchar](max) NULL,
	[System] [bit] NOT NULL,
	[XClassComponentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XClassComponent] PRIMARY KEY CLUSTERED 
(
	[ClassName] ASC,
	[ComponentName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XClassComponent Records (nach Primärschlüssel-Standards), Primärschlüssel zusammen mit ComponentName (Unique), Fremdschlüssel auf XClass.ClassName.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'ClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XClassComponent Records (nach Primärschlüssel-Standards), Primärschlüssel zusammen mit ClassName (Unique), Name einer Component der jeweiligen Klasse.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'ComponentName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'C#-Typenbezeichnung der jeweiligen Component' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'TypeName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mehrsprachigkeits-TID für die Übersetzung einiger Component-Eigenschaften (z.B. Caption der GridColumns) (Referenz zu XLangText.TID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'ComponentTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzliches SQL-Statement, welches bei Components des Typs ''KiSS4.DB.SqlQuery'' als SelectStatement angegeben werden kann' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'SelectStatement'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzlicher Tabellenname, welcher bei Components des Typs ''KiSS4.DB.SqlQuery'' als TableName angegeben werden kann' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'TableName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eigenschaften in Form von XML, welche für das Component aus den Layout-Properties des Businessdesigners generiert werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'PropertiesXML'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, welches bestimmt, ob es sich um ein System-Component (System=1) oder um ein angepasstes Component (System=0) handelt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'System'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Wird bisher nicht oder kaum verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'System'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent', @level2type=N'COLUMN',@level2name=N'XClassComponentTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Daniel Mast (?)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet sämtliche Components einer Klasse, wobei je Klasse der Name der Component eindeutig sein muss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'KiSS Core, Business Designer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassComponent'
GO

ALTER TABLE [dbo].[XClassComponent]  WITH CHECK ADD  CONSTRAINT [FK_XClassComponent_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XClassComponent] CHECK CONSTRAINT [FK_XClassComponent_XClass]
GO

ALTER TABLE [dbo].[XClassComponent] ADD  CONSTRAINT [DF_XClassComponent_System]  DEFAULT ((0)) FOR [System]
GO