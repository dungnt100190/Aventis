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

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Prim�rschl�ssel f�r XLangText Records (nach Prim�rschl�ssel-Standards). TID=Text-ID, zusammen mit LanguageCode als eindeutiger Schl�ssel f�r einen Text je Sprache.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'TID'
GO

EXEC sys.sp_addextendedproperty @name=N'LOVName', @value=N'Sprache' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'LanguageCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Prim�rschl�ssel f�r XLangText Records (nach Prim�rschl�ssel-Standards). Sprach-Code des Textes, zusammen mit TID als eindeutiger Schl�ssel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'LanguageCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Text, welcher f�r TID und Sprache gef�hrt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'Text'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'F�r grosse Texte, wird aber zurzeit nicht verwendet (weder in KiSS Core, noch sonst)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'LargeText'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Wird zurzeit nicht verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'LargeText'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird f�r die �nderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText', @level2type=N'COLUMN',@level2name=N'XLangTextTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sprachtabelle f�r alle Deutschen und Mehrsprachigen Texte aus Controls, Components, sonstigem Code, wie auch der Datenbank. Die Standardsprache wird automatisch von KiSS Core gef�llt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'KiSS Core' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XLangText'
GO