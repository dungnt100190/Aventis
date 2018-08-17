CREATE TABLE [dbo].[XLOVCode](
	[XLOVCodeID] [int] IDENTITY(1,1) NOT NULL,
	[XLOVID] [int] NOT NULL,
	[LOVName] [varchar](100) NOT NULL,
	[Code] [int] NOT NULL,
	[Text] [varchar](200) NOT NULL,
	[TextTID] [int] NULL,
	[SortKey] [int] NULL,
	[ShortText] [varchar](20) NULL,
	[ShortTextTID] [int] NULL,
	[BFSCode] [int] NULL,
	[Value1] [varchar](2000) NULL,
	[Value1TID] [int] NULL,
	[Value2] [varchar](255) NULL,
	[Value2TID] [int] NULL,
	[Value3] [varchar](255) NULL,
	[Value3TID] [int] NULL,
	[Description] [varchar](1000) NULL,
	[LOVCodeName] [varchar](200) NULL,
	[IsActive] [bit] NOT NULL,
	[System] [bit] NOT NULL,
	[XLOVCodeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XLOVCode] PRIMARY KEY NONCLUSTERED 
(
	[XLOVCodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UK_XLOVCode_LOVName_Code] UNIQUE NONCLUSTERED 
(
	[LOVName] ASC,
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_XLOVCode_LOVName_SortKey]    Script Date: 11/04/2013 17:27:45 ******/
CREATE CLUSTERED INDEX [IX_XLOVCode_LOVName_SortKey] ON [dbo].[XLOVCode] 
(
	[LOVName] ASC,
	[SortKey] ASC,
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_XLOVCode_LOVName_Code]    Script Date: 11/04/2013 17:27:45 ******/
CREATE NONCLUSTERED INDEX [IX_XLOVCode_LOVName_Code] ON [dbo].[XLOVCode] 
(
	[LOVName] ASC,
	[Code] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_XLOVCode_LOVName_Code_SortKey_BFSCode]    Script Date: 11/04/2013 17:27:45 ******/
CREATE NONCLUSTERED INDEX [IX_XLOVCode_LOVName_Code_SortKey_BFSCode] ON [dbo].[XLOVCode] 
(
	[LOVName] ASC,
	[Code] ASC,
	[SortKey] ASC,
	[BFSCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_XLOVCode_Text]    Script Date: 11/04/2013 17:27:45 ******/
CREATE NONCLUSTERED INDEX [IX_XLOVCode_Text] ON [dbo].[XLOVCode] 
(
	[Text] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_XLOVCode_Value2]    Script Date: 11/04/2013 17:27:45 ******/
CREATE NONCLUSTERED INDEX [IX_XLOVCode_Value2] ON [dbo].[XLOVCode] 
(
	[Value2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_XLOVCode_Value3]    Script Date: 11/04/2013 17:27:45 ******/
CREATE NONCLUSTERED INDEX [IX_XLOVCode_Value3] ON [dbo].[XLOVCode] 
(
	[Value3] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XLOVCode Records (nach Primärschlüssel-Standards). Name der Werteliste, welche in XLOV eingetragen ist, Primärschlüssel zusammen mit Code.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'XLOVCodeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_XLOVCode_XLOV) => XLOVID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'XLOVID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Werteliste, welche in XLOV eingetragen ist, Primärschlüssel zusammen mit Code.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'LOVName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Eindeutiger Code der einzelnen Werteliste zusammen mit LOVName.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'Code'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text, welcher für den entsprechenden Code der einzelnen Werteliste verwendet wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TID für die Mehrsprachigkeit des Textes, abgelegt je Sprache auf XLangText' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'TextTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sortierung der einzelnen Codes innerhalb der Werteliste (wenn nicht nach Text oder Code sortiert)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'SortKey'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Abgekürzter Text der Spalte Text' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'ShortText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TID für die Mehrsprachigkeit des ShortTextes, abgelegt je Sprache auf XLangText' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'ShortTextTID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Für BFS relevante Wertelisten kann hier der zugehörige BFS-Code angegeben werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'BFSCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzlicher optionaler Steuerwert Nr. 1 für spezifische Funktionalitäten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'Value1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TID für die Mehrsprachigkeit des Value 1, abgelegt je Sprache auf XLangText' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'Value1TID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzlicher optionaler Steuerwert Nr. 2 für spezifische Funktionalitäten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'Value2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TID für die Mehrsprachigkeit des Value 2, abgelegt je Sprache auf XLangText' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'Value2TID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzlicher optionaler Steuerwert Nr. 3 für spezifische Funktionalitäten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'Value3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TID für die Mehrsprachigkeit des Value 3, abgelegt je Sprache auf XLangText' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'Value3TID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beschreibung des einzelnen Codes der jeweiligen Werteliste' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'Description'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name des LOVCode-Eintrags, welcher für die automatische Generierung der LOVs-Enums in C# verwendet wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'LOVCodeName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob ein spezifischer Code systemkritisch ist (0=Kunde, 1=Systemrelevant)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'System'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'COLUMN',@level2name=N'XLOVCodeTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Werte/Codes der in XLOV definierten Wertelisten' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'KiSS Core' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode'
GO

ALTER TABLE [dbo].[XLOVCode]  WITH CHECK ADD  CONSTRAINT [FK_XLOVCode_XLOV] FOREIGN KEY([XLOVID])
REFERENCES [dbo].[XLOV] ([XLOVID])
GO

ALTER TABLE [dbo].[XLOVCode] CHECK CONSTRAINT [FK_XLOVCode_XLOV]
GO

ALTER TABLE [dbo].[XLOVCode]  WITH CHECK ADD  CONSTRAINT [FK_XLOVCode_XLOV_LOVName] FOREIGN KEY([LOVName])
REFERENCES [dbo].[XLOV] ([LOVName])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[XLOVCode] CHECK CONSTRAINT [FK_XLOVCode_XLOV_LOVName]
GO

ALTER TABLE [dbo].[XLOVCode]  WITH NOCHECK ADD  CONSTRAINT [CK_XLOVCode_DataIntegrity] CHECK  (([dbo].[fnCKXLovCodeIntegrity]([XLOVCodeID],[XLOVID],[LOVName])=(0)))
GO

ALTER TABLE [dbo].[XLOVCode] CHECK CONSTRAINT [CK_XLOVCode_DataIntegrity]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for valid XLOVCode records' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLOVCode', @level2type=N'CONSTRAINT',@level2name=N'CK_XLOVCode_DataIntegrity'
GO

ALTER TABLE [dbo].[XLOVCode] ADD  CONSTRAINT [DF_XLOVCode_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO

ALTER TABLE [dbo].[XLOVCode] ADD  CONSTRAINT [DF_XLOVCode_System]  DEFAULT ((0)) FOR [System]
GO


