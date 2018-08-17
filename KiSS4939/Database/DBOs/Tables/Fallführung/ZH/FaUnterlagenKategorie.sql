CREATE TABLE [dbo].[FaUnterlagenKategorie](
	[FaUnterlagenKategorieID] [int] IDENTITY(1,1) NOT NULL,
	[FaUnterlagenID] [int] NOT NULL,
	[Bezeichnung] [varchar](200) NOT NULL,
	[ReiterText] [varchar](100) NULL,
	[Sortierung] [int] NULL,
	[Beschreibung] [text] NULL,
	[Filter] [varchar](50) NULL,
	[FaUnterlagenKategorieTS] [timestamp] NOT NULL,
	[FaUnterlagenKategorieVorgabeCode] [int] NULL,
 CONSTRAINT [PK_FaUnterlagenKategorie] PRIMARY KEY CLUSTERED 
(
	[FaUnterlagenKategorieID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON