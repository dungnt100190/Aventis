CREATE TABLE [dbo].[Hist_BDELeistung](
	[BDELeistungID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[BDELeistungsartID] [int] NOT NULL,
	[KostenstelleOrgUnitID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[Datum] [datetime] NOT NULL,
	[Dauer] [money] NULL,
	[Anzahl] [int] NULL,
	[LohnartCode] [int] NULL,
	[Bemerkung] [varchar](500) NULL,
  [KeinExport] [bit] NOT NULL,
	[HistKostentraeger] [int] NOT NULL,
	[HistKostenstelle] [int] NOT NULL,
	[HistKostenart] [int] NOT NULL,
	[HistMandantNr] [int] NOT NULL,
	[Freigegeben] [bit] NOT NULL,
	[Visiert] [bit] NOT NULL,
	[Verbucht] [datetime] NULL,
	[VerbuchtLD] [datetime] NULL,
  [Fakturiert] [bit] NOT NULL,
	[VerID] [int] NOT NULL,
	[VerID_DELETED] [int] NULL,
 CONSTRAINT [PK_Hist_BDELeistung] PRIMARY KEY CLUSTERED 
(
	[BDELeistungID] ASC,
	[VerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_BaPersonID] ON [dbo].[Hist_BDELeistung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_BDELeistungsartID] ON [dbo].[Hist_BDELeistung] 
(
	[BDELeistungsartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_Datum] ON [dbo].[Hist_BDELeistung] 
(
	[Datum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_Datum_Dauer_UserID] ON [dbo].[Hist_BDELeistung] 
(
	[Datum] ASC,
	[Dauer] ASC,
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_Dauer] ON [dbo].[Hist_BDELeistung] 
(
	[Dauer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_Freigegeben] ON [dbo].[Hist_BDELeistung] 
(
	[Freigegeben] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_KostenstelleOrgUnitID] ON [dbo].[Hist_BDELeistung] 
(
	[KostenstelleOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_UserID] ON [dbo].[Hist_BDELeistung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_Verbucht] ON [dbo].[Hist_BDELeistung] 
(
	[Verbucht] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_VerbuchtLD] ON [dbo].[Hist_BDELeistung] 
(
	[VerbuchtLD] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_Hist_BDELeistung_Visiert] ON [dbo].[Hist_BDELeistung] 
(
	[Visiert] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO