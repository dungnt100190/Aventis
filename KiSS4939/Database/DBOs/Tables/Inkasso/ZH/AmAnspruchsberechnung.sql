CREATE TABLE [dbo].[AmAnspruchsberechnung](
	[AmAnspruchsberechnungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Bezeichnung] [varchar](100) NULL,
	[BerechnungDatumAb] [datetime] NOT NULL,
	[AmBerechnungTypCode] [int] NULL,
	[AmBerechnungsStatusCode] [int] NULL,
	[AmEinkommensvarianteCode] [int] NULL,
	[ErstkontaktDatum] [datetime] NULL,
	[UserID] [int] NULL,
	[Mandant_UserID] [int] NULL,
	[Mandant_InstitutionID] [int] NULL,
	[Verfuegung_DocumentID] [int] NULL,
	[Berechnung_DocumentID] [int] NULL,
	[ArbeitspensumKKBBProz] [int] NULL,
	[KinderbetreuungKKBBTgWoche] [money] NULL,
	[AmVerfuegungID] [int] NULL,
	[BedingungKKBBErfuellt] [bit] NOT NULL,
	[AmAnspruchsberechnungTS] [timestamp] NULL,
 CONSTRAINT [PK_AmAnspruchsberechnung] PRIMARY KEY CLUSTERED 
(
	[AmAnspruchsberechnungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_AmAnspruchsberechnung_Mandant_InstitutionID]    Script Date: 03/22/2012 10:19:13 ******/
CREATE NONCLUSTERED INDEX [IX_AmAnspruchsberechnung_Mandant_InstitutionID] ON [dbo].[AmAnspruchsberechnung] 
(
	[Mandant_InstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_AmAnspruchsberechnung_Mandant_UserID]    Script Date: 03/22/2012 10:19:13 ******/
CREATE NONCLUSTERED INDEX [IX_AmAnspruchsberechnung_Mandant_UserID] ON [dbo].[AmAnspruchsberechnung] 
(
	[Mandant_UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_AmAnspruchsberechnung_UserID]    Script Date: 03/22/2012 10:19:13 ******/
CREATE NONCLUSTERED INDEX [IX_AmAnspruchsberechnung_UserID] ON [dbo].[AmAnspruchsberechnung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO


/****** Object:  Index [IX_AmAnspruchsberechnung_FaLeistungID]    Script Date: 03/22/2012 10:19:13 ******/
CREATE NONCLUSTERED INDEX [IX_AmAnspruchsberechnung_FaLeistungID] ON [dbo].[AmAnspruchsberechnung] 
(
	[FaLeistungID] ASC,
	[AmBerechnungsStatusCode] ASC,
	[BerechnungDatumAb] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung]  WITH CHECK ADD  CONSTRAINT [FK_AmAnspruchsberechnung_AmVerfuegung] FOREIGN KEY([AmVerfuegungID])
REFERENCES [dbo].[AmVerfuegung] ([AmVerfuegungID])
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung] CHECK CONSTRAINT [FK_AmAnspruchsberechnung_AmVerfuegung]
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung]  WITH CHECK ADD  CONSTRAINT [FK_AmAnspruchsberechnung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung] CHECK CONSTRAINT [FK_AmAnspruchsberechnung_FaLeistung]
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung]  WITH CHECK ADD  CONSTRAINT [FK_AmAnspruchsberechnung_MandantInstitution] FOREIGN KEY([Mandant_InstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung] CHECK CONSTRAINT [FK_AmAnspruchsberechnung_MandantInstitution]
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung]  WITH CHECK ADD  CONSTRAINT [FK_AmAnspruchsberechnung_MandantUser] FOREIGN KEY([Mandant_UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung] CHECK CONSTRAINT [FK_AmAnspruchsberechnung_MandantUser]
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung]  WITH CHECK ADD  CONSTRAINT [FK_AmAnspruchsberechnung_User] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung] CHECK CONSTRAINT [FK_AmAnspruchsberechnung_User]
GO

ALTER TABLE [dbo].[AmAnspruchsberechnung] ADD  CONSTRAINT [DF_AmAnspruchsberechnung_BedingungKKBBErfuellt]  DEFAULT ((0)) FOR [BedingungKKBBErfuellt]
GO

