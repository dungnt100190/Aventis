CREATE TABLE [dbo].[FaJournal](
	[FaJournalID] [int] IDENTITY(1,1) NOT NULL,
	[FaFallID] [int] NOT NULL,
	[FaLeistungID] [int] NULL,
	[BaPersonID] [int] NULL,
	[BaPersonName] [varchar](100) NULL,
	[BaPersonVorname] [varchar](100) NULL,
	[UserID] [int] NOT NULL,
	[UserLastName] [varchar](200) NULL,
	[UserFirstName] [varchar](200) NULL,
	[UserLogonName] [varchar](200) NULL,
	[OrgUnitID] [int] NULL,
	[OrgUnitItemName] [varchar](100) NULL,
	[Datum] [datetime] NOT NULL CONSTRAINT [DF_FaJournal_Datum]  DEFAULT (getdate()),
	[FaJournalCode] [int] NOT NULL CONSTRAINT [DF_FaJournal_FaJournalCode]  DEFAULT ((1)),
	[Text] [text] NOT NULL,
	[ManuellerEintrag] [bit] NOT NULL CONSTRAINT [DF_FaJournal_ManuellerEintrag]  DEFAULT ((0)),
	[FaJournalTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaJournal] PRIMARY KEY CLUSTERED 
(
	[FaJournalID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_FaJournal_BaPersonID]    Script Date: 11/23/2011 14:58:24 ******/
CREATE NONCLUSTERED INDEX [IX_FaJournal_BaPersonID] ON [dbo].[FaJournal] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_FaJournal_FaFallD]    Script Date: 11/23/2011 14:58:24 ******/
CREATE NONCLUSTERED INDEX [IX_FaJournal_FaFallD] ON [dbo].[FaJournal] 
(
	[FaFallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_FaJournal_FaLeistungID]    Script Date: 11/23/2011 14:58:24 ******/
CREATE NONCLUSTERED INDEX [IX_FaJournal_FaLeistungID] ON [dbo].[FaJournal] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]