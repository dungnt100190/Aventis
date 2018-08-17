CREATE TABLE [dbo].[XClassControl](
	[ClassName] [varchar](255) NOT NULL,
	[ControlName] [varchar](255) NOT NULL,
	[ParentControl] [varchar](255) NULL,
	[TypeName] [varchar](255) NOT NULL,
	[ControlTID] [int] NULL,
	[DataMember] [varchar](255) NULL,
	[DataSource] [varchar](255) NULL,
	[LOVName] [varchar](255) NULL,
	[TabIndex] [int] NOT NULL,
	[X] [int] NOT NULL,
	[Y] [int] NOT NULL,
	[Width] [int] NOT NULL,
	[Height] [int] NOT NULL,
	[PropertiesXML] [varchar](max) NULL,
	[System] [bit] NOT NULL,
	[XClassControlTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XClassControl] PRIMARY KEY CLUSTERED 
(
	[ClassName] ASC,
	[ControlName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XClassControl Records (nach Primärschlüssel-Standards), Primärschlüssel zusammen mit ControlName (Unique), Fremdschlüssel auf XClass.ClassName.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'ClassName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XClassControl Records (nach Primärschlüssel-Standards), Primärschlüssel zusammen mit ClassName (Unique), Name eines Controls der jeweiligen Klasse.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'ControlName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Control-Name des Eltern-Controls, zu welchem das jeweilige Control gehört. Wird für verschachtelte Layout-Anordnungen benötigt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'ParentControl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'C#-Typenbezeichnung der jeweiligen Controls' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'TypeName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mehrsprachigkeits-TID für die Übersetzung einiger Control-Eigenschaften (z.B. Text des KissLabels) (Referenz zu XLangText.TID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'ControlTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wird für das DataBinding verwendet, Name der anzubindenen Spalte der gegebenen DataSource' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'DataMember'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wird für das DataBinding verwendet, Name der Datenquelle, welche vergebunden werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'DataSource'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Werteliste, welche zum Beispiel bei Auswahlfeldern verwendet werden soll (Referenz auf XLOV.LOVName)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'LOVName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Der zu verwendende TabIndex des jeweiligen Controls. Dieser Wert gibt gleichzeitig die Ladereihenfolge innerhalb des BusinessDesigners vor.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'TabIndex'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Left-Position in Pixel auf der horizontalen Achse des Eltern-Controls innerhalb des Layouts (positiv ist nach rechts)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'X'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Top-Position in Pixel auf der vertikalen Achse des Eltern-Controls innerhalb des Layouts (positiv ist nach unten)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'Y'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Breite des Controls in Pixel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'Width'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Höhe des Controls in Pixel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'Height'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eigenschaften in Form von XML, welche für das Control aus den Layout-Properties des Businessdesigners generiert werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'PropertiesXML'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, welches bestimmt, ob es sich um ein System-Control (System=1) oder um ein angepasstes Control (System=0) handelt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'System'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Wird bisher nicht oder kaum verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'System'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl', @level2type=N'COLUMN',@level2name=N'XClassControlTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Daniel Mast (?)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet sämtliche Controls einer Klasse, wobei je Klasse der Name des Controls eindeutig sein muss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'KiSS Core, Business Designer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XClassControl'
GO

ALTER TABLE [dbo].[XClassControl]  WITH CHECK ADD  CONSTRAINT [FK_XClassControl_XClass] FOREIGN KEY([ClassName])
REFERENCES [dbo].[XClass] ([ClassName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XClassControl] CHECK CONSTRAINT [FK_XClassControl_XClass]
GO

ALTER TABLE [dbo].[XClassControl] ADD  CONSTRAINT [DF_XClassControl_System]  DEFAULT ((0)) FOR [System]
GO