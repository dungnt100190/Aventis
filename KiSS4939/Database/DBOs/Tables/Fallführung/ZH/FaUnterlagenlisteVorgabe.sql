CREATE TABLE [dbo].[FaUnterlagenlisteVorgabe](
	[FaUnterlagenlisteVorgabeID] [int] IDENTITY(1,1) NOT NULL,
	[Kurzname] [varchar](50) NOT NULL,
	[Name] [varchar](400) NOT NULL,
	[Gruppe] [varchar](50) NOT NULL,
	[Sortierung] [int] NOT NULL,
	[Default_Notwendig] [bit] NOT NULL CONSTRAINT [DF_FaUnterlagenlisteVorgabe_Default_Notwendig]  DEFAULT ((1)),
	[HatZusatzfeld] [bit] NOT NULL,
	[TabSeite] [int] NOT NULL CONSTRAINT [DF_FaUnterlagenlisteVorgabe_TabSeite]  DEFAULT ((0)),
	[FaUnterlagenlisteVorgabeTS] [timestamp] NOT NULL,
	[FaUnterlagenKategorieVorgabeCode] [int] NULL,
 CONSTRAINT [PK_FaUnterlagenlisteVorgabe] PRIMARY KEY CLUSTERED 
(
	[FaUnterlagenlisteVorgabeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON