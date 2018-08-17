CREATE TABLE [dbo].[AmAbPositionsart](
	[AmAbPositionsartID] [int] NOT NULL,
	[ParentID] [int] NULL,
	[Text] [varchar](200) NOT NULL,
	[Typ] [int] NOT NULL,
	[Kind] [bit] NOT NULL,
	[Sortierung1] [varchar](2) NOT NULL,
	[Sortierung2] [varchar](50) NULL,
	[Mengeneinheit1] [varchar](50) NULL,
	[Mengeneinheit2] [varchar](50) NULL,
	[Editierbar1] [bit] NOT NULL CONSTRAINT [DF_AmAbPositionsart_Editierbar]  DEFAULT ((1)),
	[Editierbar2] [bit] NOT NULL,
	[Default1] [money] NULL,
	[Default2] [money] NULL,
	[ConfigName1] [varchar](50) NULL,
	[ConfigName2] [varchar](50) NULL,
	[Format1] [varchar](20) NULL,
	[Format2] [varchar](20) NULL,
	[Kommentar] [varchar](1000) NULL,
	[AmAbPositionartTS] [timestamp] NULL,
 CONSTRAINT [PK_AmAbPositionsart] PRIMARY KEY CLUSTERED 
(
	[AmAbPositionsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON