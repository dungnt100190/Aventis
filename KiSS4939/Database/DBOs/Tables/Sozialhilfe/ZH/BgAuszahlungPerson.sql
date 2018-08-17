CREATE TABLE [dbo].[BgAuszahlungPerson](
	[BgAuszahlungPersonID] [int] IDENTITY(1,1) NOT NULL,
	[BgPositionID] [int] NULL,
	[BaPersonID] [int] NULL,
	[KbAuszahlungsArtCode] [int] NULL,
	[BgAuszahlungsTerminCode] [int] NULL CONSTRAINT [DF_BgAuszahlungPerson_BgAuszahlungsterminCode]  DEFAULT ((1)),
	[BgWochentagCodes] [varchar](20) NULL,
	[BaZahlungswegID] [int] NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[MitteilungZeile1] [varchar](35) NULL,
	[MitteilungZeile2] [varchar](35) NULL,
	[MitteilungZeile3] [varchar](35) NULL,
	[MitteilungZeile4] [varchar](35) NULL,
	[BgAuszahlungPersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BgAuszahlungPerson] PRIMARY KEY CLUSTERED 
(
	[BgAuszahlungPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BgAuszahlungPerson_BaZahlungswegID]    Script Date: 11/23/2011 11:44:27 ******/
CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPerson_BaZahlungswegID] ON [dbo].[BgAuszahlungPerson] 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_BgAuszahlungPerson_BgPersonID]    Script Date: 11/23/2011 11:44:27 ******/
CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPerson_BgPersonID] ON [dbo].[BgAuszahlungPerson] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_BgAuszahlungPerson_BgPosition]    Script Date: 11/23/2011 11:44:27 ******/
CREATE NONCLUSTERED INDEX [IX_BgAuszahlungPerson_BgPosition] ON [dbo].[BgAuszahlungPerson] 
(
	[BgPositionID] ASC
)
INCLUDE ( [BaPersonID],
[KbAuszahlungsArtCode],
[BaZahlungswegID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO
ALTER TABLE [dbo].[BgAuszahlungPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgAuszahlungPerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BgAuszahlungPerson] CHECK CONSTRAINT [FK_BgAuszahlungPerson_BaPerson]
GO
ALTER TABLE [dbo].[BgAuszahlungPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgAuszahlungPerson_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO
ALTER TABLE [dbo].[BgAuszahlungPerson] CHECK CONSTRAINT [FK_BgAuszahlungPerson_BaZahlungsweg]
GO
ALTER TABLE [dbo].[BgAuszahlungPerson]  WITH CHECK ADD  CONSTRAINT [FK_BgAuszahlungPerson_BgPosition] FOREIGN KEY([BgPositionID])
REFERENCES [dbo].[BgPosition] ([BgPositionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BgAuszahlungPerson] CHECK CONSTRAINT [FK_BgAuszahlungPerson_BgPosition]