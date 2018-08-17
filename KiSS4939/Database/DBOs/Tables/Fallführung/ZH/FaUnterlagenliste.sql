CREATE TABLE [dbo].[FaUnterlagenliste](
	[FaUnterlagenlisteID] [int] IDENTITY(1,1) NOT NULL,
	[FaUnterlagenID] [int] NOT NULL,
	[FaUnterlagenlisteVorgabeID] [int] NOT NULL,
	[Kurzname] [varchar](50) NOT NULL,
	[Name] [varchar](400) NOT NULL,
	[Gruppe] [varchar](50) NOT NULL,
	[Sortierung] [int] NOT NULL,
	[Notwendig] [bit] NOT NULL,
	[Erhalten] [bit] NOT NULL,
	[HatZusatzFeld] [bit] NOT NULL CONSTRAINT [DF_FaUnterlagenliste_HatZusatzFeld]  DEFAULT ((0)),
	[Zusatz] [varchar](255) NULL,
	[Datum] [datetime] NULL,
	[Bemerkung] [text] NULL,
	[TabSeite] [int] NOT NULL,
	[FaUnterlagenlisteTS] [timestamp] NOT NULL,
	[FaUnterlagenKategorieID] [int] NULL,
	[ErhaltenDatum] [datetime] NULL,
 CONSTRAINT [PK_FaUnterlagenliste] PRIMARY KEY CLUSTERED 
(
	[FaUnterlagenlisteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_FaUnterlagenliste_FaUnterlagenID]    Script Date: 11/23/2011 15:05:04 ******/
CREATE NONCLUSTERED INDEX [IX_FaUnterlagenliste_FaUnterlagenID] ON [dbo].[FaUnterlagenliste] 
(
	[FaUnterlagenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO
ALTER TABLE [dbo].[FaUnterlagenliste]  WITH CHECK ADD  CONSTRAINT [FK_FaUnterlagenliste_FaUnterlagen] FOREIGN KEY([FaUnterlagenID])
REFERENCES [dbo].[FaUnterlagen] ([FaUnterlagenID])
GO
ALTER TABLE [dbo].[FaUnterlagenliste] CHECK CONSTRAINT [FK_FaUnterlagenliste_FaUnterlagen]