CREATE TABLE [dbo].[WhHeimatKantonNr_Rekurs](
	[WhHeimatKantonNr_RekursID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[WVCode] [int] NOT NULL,
	[BEDCode] [int] NOT NULL,
	[HeimatkantonNr] [varchar](20) NULL,
	[Rekurs] [datetime] NULL,
	[RekursMutiertUserID] [int] NULL,
	[RekursMutiertDatum] [datetime] NULL,
	[RekursAbgeschlossen] [datetime] NULL,
	[RekursAbgeschlossenMutiertUserID] [int] NULL,
	[RekursAbgeschlossenMutiertDatum] [datetime] NULL,
	[DatumZuletztEingegeben] [datetime] NOT NULL,
 CONSTRAINT [PK_WhHeimatKantonNr_Rekurs] PRIMARY KEY CLUSTERED 
(
	[WhHeimatKantonNr_RekursID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_WhHeimatKantonNr_Rekurs_BaPersonID]    Script Date: 11/23/2011 16:40:49 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_WhHeimatKantonNr_Rekurs_BaPersonID] ON [dbo].[WhHeimatKantonNr_Rekurs] 
(
	[BaPersonID] ASC,
	[WVCode] ASC,
	[BEDCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]