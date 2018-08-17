CREATE TABLE [dbo].[WhWVEinheit](
	[WhWVEinheitID] [int] IDENTITY(1,1) NOT NULL,
	[FaFallID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[BaPersonID] [int] NULL,
	[WVCode] [int] NOT NULL,
	[BEDCode] [int] NULL,
	[WhWVEinheitTS] [timestamp] NOT NULL,
	[SKZNummer] [int] NULL,
	[HeimatkantonNr] [varchar](20) NULL,
	[Ungueltig] [bit] NOT NULL CONSTRAINT [DF_WhWVEinheit_Ungueltig]  DEFAULT ((0)),
	[EinheitHerausgeloest] [bit] NOT NULL CONSTRAINT [DF_WhWVEinheit_EinheitHerausgeloest]  DEFAULT ((0)),
	[Rekurs] [datetime] NULL,
	[RekursMutiertUserID] [int] NULL,
	[RekursMutiertDatum] [datetime] NULL,
	[RekursAbgeschlossen] [datetime] NULL,
	[RekursAbgeschlossenMutiertUserID] [int] NULL,
	[RekursAbgeschlossenMutiertDatum] [datetime] NULL,
 CONSTRAINT [PK_WhWVEinheit] PRIMARY KEY CLUSTERED 
(
	[WhWVEinheitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_WhWVEinheit_FaFallID]    Script Date: 11/23/2011 16:42:03 ******/
CREATE NONCLUSTERED INDEX [IX_WhWVEinheit_FaFallID] ON [dbo].[WhWVEinheit] 
(
	[FaFallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[WhWVEinheit]  WITH CHECK ADD  CONSTRAINT [FK_WhWVEinheit_FaFall] FOREIGN KEY([FaFallID])
REFERENCES [dbo].[FaFall] ([FaFallID])
GO
ALTER TABLE [dbo].[WhWVEinheit] CHECK CONSTRAINT [FK_WhWVEinheit_FaFall]