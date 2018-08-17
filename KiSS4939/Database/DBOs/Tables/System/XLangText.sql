CREATE TABLE [dbo].[XLangText](
	[TID] [int] IDENTITY(1,1) NOT NULL,
	[LanguageCode] [int] NOT NULL,
	[Text] [varchar](2000) NULL,
	[LargeText] [varchar](max) NULL,
	[XLangTextTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XLangText] PRIMARY KEY CLUSTERED 
(
	[TID] ASC,
	[LanguageCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XLangText Records (nach Primärschlüssel-Standards). TID=Text-ID, zusammen mit LanguageCode als eindeutiger Schlüssel für einen Text je Sprache.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'TID'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'Sprache' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'LanguageCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XLangText Records (nach Primärschlüssel-Standards). Sprach-Code des Textes, zusammen mit TID als eindeutiger Schlüssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'LanguageCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text, welcher für TID und Sprache geführt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Für grosse Texte, wird aber zurzeit nicht verwendet (weder in KiSS Core, noch sonst)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'LargeText'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Wird zurzeit nicht verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'LargeText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'XLangTextTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sprachtabelle für alle Deutschen und Mehrsprachigen Texte aus Controls, Components, sonstigem Code, wie auch der Datenbank. Die Standardsprache wird automatisch von KiSS Core gefüllt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'KiSS Core' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText'
GO