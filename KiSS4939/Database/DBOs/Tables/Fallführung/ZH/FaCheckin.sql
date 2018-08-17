CREATE TABLE [dbo].[FaCheckin](
	[FaCheckinID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[ErstkontaktDatum] [datetime] NOT NULL,
	[ErstkontaktUserID] [int] NULL,
	[ErstKontaktOrgUnitID] [int] NULL,
	[KontaktartCode] [int] NULL,
	[KontaktPerson] [varchar](200) NULL,
	[KontaktgrundCode] [int] NULL,
	[FallartZAVCode] [int] NULL,
	[ZustaendigkeitGeprueftDatum] [datetime] NULL,
	[ZustaendigUserID] [int] NULL,
	[ZustaendigOrgUnitID] [int] NULL,
	[Situationsbeschrieb] [varchar](2000) NULL,
	[AntragAbgegebenDatum] [datetime] NULL,
	[AntragAbgegebenUserID] [int] NULL,
	[AntragEingegangenDatum] [datetime] NULL,
	[AntragEingegangenUserID] [int] NULL,
	[AntragVollstaendigDatum] [datetime] NULL,
	[AntragVollstaendigUserID] [int] NULL,
	[AbschlussDatum] [datetime] NULL,
	[AbschlussUserID] [int] NULL,
	[FallabschlussGrundCode] [int] NULL,
	[GespraecheGemacht] [bit] NOT NULL CONSTRAINT [DF_FaCheckin_GespraecheGemacht]  DEFAULT ((0)),
	[FaRessourcenPaketCode] [int] NULL,
	[FaKriteriumCode] [int] NULL,
	[QuartierTeamID] [int] NULL,
	[QTUebergabeDatum] [datetime] NULL,
	[TaskID] [int] NULL,
	[FaCheckinTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaCheckin] PRIMARY KEY CLUSTERED 
(
	[FaCheckinID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_FaCheckin_AbschlussUserID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_AbschlussUserID] ON [dbo].[FaCheckin] 
(
	[AbschlussUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_AntragAbgegebenUserID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_AntragAbgegebenUserID] ON [dbo].[FaCheckin] 
(
	[AntragAbgegebenUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_AntragEingegangenUserID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_AntragEingegangenUserID] ON [dbo].[FaCheckin] 
(
	[AntragEingegangenUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_AntragVollstaendigUserID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_AntragVollstaendigUserID] ON [dbo].[FaCheckin] 
(
	[AntragVollstaendigUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_ErstKontaktOrgUnitID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_ErstKontaktOrgUnitID] ON [dbo].[FaCheckin] 
(
	[ErstKontaktOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_ErstkontaktUserID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_ErstkontaktUserID] ON [dbo].[FaCheckin] 
(
	[ErstkontaktUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_FaLeistungID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_FaLeistungID] ON [dbo].[FaCheckin] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_QuartierTeamID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_QuartierTeamID] ON [dbo].[FaCheckin] 
(
	[QuartierTeamID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_TaskID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_TaskID] ON [dbo].[FaCheckin] 
(
	[TaskID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_ZustaendigOrgUnitID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_ZustaendigOrgUnitID] ON [dbo].[FaCheckin] 
(
	[ZustaendigOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckin_ZustaendigUserID]    Script Date: 11/23/2011 14:42:59 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckin_ZustaendigUserID] ON [dbo].[FaCheckin] 
(
	[ZustaendigUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaAnmeldung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaAnmeldung_FaLeistung]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaAnmeldung_XUser] FOREIGN KEY([ErstkontaktUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaAnmeldung_XUser]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaAnmeldung_XUser1] FOREIGN KEY([AntragAbgegebenUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaAnmeldung_XUser1]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaAnmeldung_XUser2] FOREIGN KEY([AntragEingegangenUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaAnmeldung_XUser2]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaAnmeldung_XUser3] FOREIGN KEY([AntragVollstaendigUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaAnmeldung_XUser3]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaAnmeldung_XUser4] FOREIGN KEY([AbschlussUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaAnmeldung_XUser4]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaCheckin_XOrgUnit] FOREIGN KEY([QuartierTeamID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaCheckin_XOrgUnit]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaCheckin_XOrgUnit_ErstKontakt] FOREIGN KEY([ErstKontaktOrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaCheckin_XOrgUnit_ErstKontakt]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaCheckin_XOrgUnit_Zustaendig] FOREIGN KEY([ZustaendigOrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaCheckin_XOrgUnit_Zustaendig]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaCheckin_XTask] FOREIGN KEY([TaskID])
REFERENCES [dbo].[XTask] ([XTaskID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaCheckin_XTask]
GO
ALTER TABLE [dbo].[FaCheckin]  WITH CHECK ADD  CONSTRAINT [FK_FaCheckin_XUser] FOREIGN KEY([ZustaendigUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaCheckin] CHECK CONSTRAINT [FK_FaCheckin_XUser]