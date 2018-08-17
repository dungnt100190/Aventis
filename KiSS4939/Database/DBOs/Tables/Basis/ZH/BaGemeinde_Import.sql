CREATE TABLE [dbo].[BaGemeinde_Import](
	[GDEKT] [varchar](2) NOT NULL,
	[GDEBZNR] [int] NOT NULL,
	[GDENR] [int] NOT NULL,
	[GDENAME] [varchar](40) NOT NULL,
	[GDENAMK] [varchar](24) NOT NULL,
	[GDEBZNA] [varchar](40) NOT NULL,
	[GDEKTNA] [varchar](40) NOT NULL,
	[GDEMUTDAT] [varchar](10) NOT NULL
) ON [PRIMARY]

GO
SET ANSI_PADDING ON