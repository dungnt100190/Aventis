CREATE TABLE [dbo].[IkRatenplan](
	[IkRatenplanID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[IkRatenplanVereinbarungCode] [int] NULL,
	[Bezeichnung] [varchar](200) NULL,
	[VereinbarungVom] [datetime] NULL,
	[GesamtBetrag] [money] NULL,
	[BetragProMonat] [money] NOT NULL,
	[Bemerkung] [varchar](500) NULL,
	[IkRatenplanTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkRatenplan] PRIMARY KEY CLUSTERED 
(
	[IkRatenplanID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_IkRatenplan_FaLeistungID]    Script Date: 11/23/2011 15:48:40 ******/
CREATE NONCLUSTERED INDEX [IX_IkRatenplan_FaLeistungID] ON [dbo].[IkRatenplan] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[IkRatenplan]  WITH CHECK ADD  CONSTRAINT [FK_IkRatenplan_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[IkRatenplan] CHECK CONSTRAINT [FK_IkRatenplan_FaLeistung]