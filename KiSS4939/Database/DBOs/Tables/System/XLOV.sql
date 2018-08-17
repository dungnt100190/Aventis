CREATE TABLE [dbo].[XLOV](
  [XLOVID] [int] IDENTITY(1,1) NOT NULL,
  [LOVName] [varchar](100) NOT NULL,
  [Description] [varchar](500) NULL,
  [System] [bit] NOT NULL,
  [Expandable] [bit] NOT NULL,
  [ModulID] [int] NULL,
  [LastUpdated] [datetime] NULL,
  [Translatable] [bit] NOT NULL,
  [NameValue1] [varchar](100) NULL,
  [NameValue2] [varchar](100) NULL,
  [NameValue3] [varchar](100) NULL,
  [XLOVTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XLOV] PRIMARY KEY CLUSTERED 
(
  [XLOVID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UK_XLOV_LOVName] UNIQUE NONCLUSTERED 
(
  [LOVName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XLOV Records (nach Primärschlüssel-Standards). Eindeutiger Name einer Werteliste, wobei in der Regel als Prefix das Modul gewählt wird (z.B. BaXYZ)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'XLOVID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eindeutiger Name einer Werteliste, wobei in der Regel als Prefix das Modul gewählt wird (z.B. BaXYZ)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'LOVName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung der Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'Description'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob eine Werteliste Systemrelevant ist und daher nur mit entsprechendem Wissen geändert werden sollte (0=Kunde, 1=System)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'System'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob eine Werteliste erweiterbar ist, d.h. neue Codes enthalten kann' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'Expandable'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XLOV_XModul) => XModul.ModulID, ID des Modules, zu welcher eine Werteliste gehört.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'ModulID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitstempel, wann eine Werteliste zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'LastUpdated'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob eine Werteliste mehrsprachig geführt werden kann (0=nur Standard, 1=Auch Mehrsprachig möglich)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'Translatable'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name/Begriff der Zusatzspalte Value1, wird im KiSS bei der Bearbeitung der Werteliste für Value 1 angezeigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'NameValue1'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name/Begriff der Zusatzspalte Value2, wird im KiSS bei der Bearbeitung der Werteliste für Value 2 angezeigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'NameValue2'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name/Begriff der Zusatzspalte Value3, wird im KiSS bei der Bearbeitung der Werteliste für Value 3 angezeigt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'NameValue3'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV', @level2type=N'COLUMN',@level2name=N'XLOVTS'
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet sämtliche Wertelisten (Codes sind in XLOVCode)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'KiSS Core' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOV'
GO

ALTER TABLE [dbo].[XLOV]  WITH CHECK ADD  CONSTRAINT [FK_XLOV_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[XLOV] CHECK CONSTRAINT [FK_XLOV_XModul]
GO

ALTER TABLE [dbo].[XLOV] ADD  CONSTRAINT [DF_XLOV_System]  DEFAULT ((0)) FOR [System]
GO

ALTER TABLE [dbo].[XLOV] ADD  CONSTRAINT [DF_XLOV_Expandable]  DEFAULT ((1)) FOR [Expandable]
GO

ALTER TABLE [dbo].[XLOV] ADD  CONSTRAINT [DF_XLOV_Translateable]  DEFAULT ((1)) FOR [Translatable]
GO

