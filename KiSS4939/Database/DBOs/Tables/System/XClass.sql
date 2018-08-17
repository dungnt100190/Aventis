CREATE TABLE [dbo].[XClass](
  [XClassID] [int] IDENTITY(1,1) NOT NULL,
  [ClassName] [varchar](255) NOT NULL,
  [ClassNameViewModel] [varchar](255) NULL,
  [ModulID] [int] NOT NULL,
  [MaskName] [varchar](100) NULL,
  [BaseType] [varchar](500) NOT NULL,
  [ClassCode] [int] NULL,
  [ClassTID] [int] NULL,
  [PropertiesXML] [varchar](max) NULL,
  [Designer] [int] NOT NULL,
  [Description] [varchar](max) NULL,
  [CodeGenerated] [varchar](max) NULL,
  [Resource] [image] NULL,
  [Assembly] [image] NULL,
  [Branch] [varchar](128) NULL,
  [BuildNr] [int] NOT NULL,
  [System] [bit] NOT NULL,
  [CheckOut_UserID] [int] NULL,
  [CheckOut_Date] [datetime] NULL,
  [NamespaceExtension] [varchar](50) NULL,
  [XClassTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XClass] PRIMARY KEY CLUSTERED 
(
  [XClassID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UK_XClass_ClassName] UNIQUE NONCLUSTERED 
(
  [ClassName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_XClass_ClassName] ON [dbo].[XClass] 
(
  [ClassName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_XClass_ModulID] ON [dbo].[XClass] 
(
  [ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XClass Records (nach Primärschlüssel-Standards). Eindeutiger Name der Klasse.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'XClassID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eindeutiger Name der Klasse.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'ClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XClass_XModul) => XModul.ModulID. Zugehörigkeit der Klasse zu Modul.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'ModulID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Maske innerhalb der Benutzerrechte, Recht-Bezeichnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'MaskName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Basisklasse, auf welcher die Klasse aufbaut (von Werteliste ''Class'' den Value1)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'BaseType'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Basisklassen-TypCode, auf welcher die Klasse aufbaut (von Werteliste ''Class'' den Code)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'ClassCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mehrsprachigkeits-TID für die Übersetzung des Fenstertitels bei Form-Klassen (Referenz zu XLangText.TID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'ClassTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eigenschaften in Form von XML, welche aus den Layout-Properties des Businessdesigners generiert werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'PropertiesXML'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'Designer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'Designer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob Assembly der Klasse aus der Datenbank (Wert=1: Design, Wert=2: HotFix) oder aus KiSS-Core (Wert=0) geladen wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'Designer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzliche Beschreibung der Klasse, obtionale Bemerkungen, etc.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Falls das Flag ''Designer=1'' gesetzt ist, ist hier der vom Businessdesigner erstellte C#-Code hinterlegt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'CodeGenerated'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Binary-Feld für zusätzliches Ressourcen-File der im Businessdesigner erzeugten Klasse. Aus dem Binary-Stream entsteht die *.resx-Datei.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'Resource'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das aus dem C#-Code compilierte Assembly der Businessdesigner-Klassen. Dieses Assembly wird bei Flag ''Designer=1'' dynamisch aus der DB geholt und als zuätzliche Dll zusätzlich zum KiSS-Core geladen.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'Assembly'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'DB-Name des Branches der Klasse, Herkunftsbezeichnung (entspricht bei neuen oder veränderten Klassen jeweils dem aktuellen DB-Namen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'Branch'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Automatisch hochgezählte BuildNr der Businessdesigner-Klassen, wird nur bei erfolgreichem Build der Klasse erhöht (CtlDesignerLoader.Build())' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'BuildNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, welches bestimmt, ob es sich um eine System-Klasse (System=1) oder um eine kundenspezifische Klasse (System=0) handelt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'System'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserID des Benutzers, welche die Klasse zurzeit augechecked hat (betrifft Spalte XUser.UserID). Falls NULL, ist die Klasse nicht ausgechecked.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'CheckOut_UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum inklusive Zeit, wann der Benutzer aus CheckOut_UserID die Klasse ausgechecked hat. Falls NULL, ist die Klasse nicht augechecked.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'CheckOut_Date'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Namespace-Erweiterung, welche zusätzlich zum Namespace des Modules vor den Klassennamen gesetzt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'NamespaceExtension'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass', @level2type=N'COLUMN',@level2name=N'XClassTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Daniel Mast (?)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet alle verfügbaren Klassen, welche in der jeweiligen Anwendung von KiSS benötigt werden (CORE und Businessdesigner Klassen)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'KiSS Core, Business Designer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClass'
GO

ALTER TABLE [dbo].[XClass]  WITH CHECK ADD  CONSTRAINT [FK_XClass_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[XClass] CHECK CONSTRAINT [FK_XClass_XModul]
GO

ALTER TABLE [dbo].[XClass] ADD  CONSTRAINT [DF_XClass_Designer]  DEFAULT ((0)) FOR [Designer]
GO

ALTER TABLE [dbo].[XClass] ADD  CONSTRAINT [DF_XClass_BuildNr]  DEFAULT ((0)) FOR [BuildNr]
GO

ALTER TABLE [dbo].[XClass] ADD  CONSTRAINT [DF_XClass_System]  DEFAULT ((0)) FOR [System]
GO