CREATE TABLE [dbo].[PscdSentFaLeistung_Person](
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[SentToPscd] [datetime] NOT NULL,
	[PscdSentFaLeistung_PersonID] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_PscdSentFaLeistung_Person] PRIMARY KEY CLUSTERED 
(
	[PscdSentFaLeistung_PersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_PscdSentFaLeistung_Person_Sicherung]    Script Date: 11/23/2011 16:27:22 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_PscdSentFaLeistung_Person_Sicherung] ON [dbo].[PscdSentFaLeistung_Person] 
(
	[FaLeistungID] ASC,
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]