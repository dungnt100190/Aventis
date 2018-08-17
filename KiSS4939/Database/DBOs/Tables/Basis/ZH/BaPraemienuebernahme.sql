CREATE TABLE [dbo].[BaPraemienuebernahme](
	[BaPraemienuebernahmeID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Folgenummer] [int] NULL,
	[AnzahlVerlustscheine] [int] NULL,
	[Krankenkasse] [varchar](100) NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[BetroffenePersonen] [varchar](20) NULL,
	[BetragLetztePU] [money] NULL,
	[Ueberpruefungspflichtig] [varchar](10) NULL,
	[BaPraemienuebernahmeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaPraemienuebernahme] PRIMARY KEY CLUSTERED 
(
	[BaPraemienuebernahmeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BaPraemienuebernahme_BaPersonID]    Script Date: 11/23/2011 10:45:04 ******/
CREATE NONCLUSTERED INDEX [IX_BaPraemienuebernahme_BaPersonID] ON [dbo].[BaPraemienuebernahme] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaPraemienuebernahme]  WITH CHECK ADD  CONSTRAINT [FK_BaPraemienuebernahme_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BaPraemienuebernahme] CHECK CONSTRAINT [FK_BaPraemienuebernahme_BaPerson]