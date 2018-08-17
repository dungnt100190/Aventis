CREATE TABLE [dbo].[EdMitarbeiter](
	[EdMitarbeiterID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[UserIDInterview] [int] NULL,
	[UserIDVorgesetzter] [int] NULL,
	[ZusatzZivilstandCode] [int] NULL,
	[ZusatzAnzahlKinder] [int] NULL,
	[ZusatzWeitereSprachen] [varchar](255) NULL,
	[ZusatzNationalitaetLandCode] [int] NULL,
	[ZusatzAufenthaltsbewilligungCode] [int] NULL,
	[ZusatzStrafregisterauszugDatum] [datetime] NULL,
	[ZusatzStrafregisterauszugBemerkungen] [varchar](1000) NULL,
	[ZusatzAusbildung] [varchar](2000) NULL,
	[ZusatzTaetigkeit] [varchar](2000) NULL,
	[InterviewDatum] [datetime] NULL,
	[InterviewZusammenfassung] [varchar](max) NULL,
	[InterviewBeurteilung] [varchar](max) NULL,
	[PersoenlichkeitErfahrungen] [varchar](5000) NULL,
	[PersoenlichkeitErfahrungenAlter] [varchar](5000) NULL,
	[PersoenlichkeitVorlieben] [varchar](5000) NULL,
	[PersoenlichkeitPersoenlichkeit] [varchar](5000) NULL,
	[PersoenlichkeitGesundheit] [varchar](5000) NULL,
	[KenntnisseMehrfachbehinderung] [varchar](255) NULL,
	[KenntnisseIMC] [varchar](255) NULL,
	[KenntnisseGehirnschaedigung] [varchar](255) NULL,
	[KenntnisseEpilepsie] [varchar](255) NULL,
	[KenntnisseGeistigeBehinderung] [varchar](255) NULL,
	[KenntnisseVerhaltensstoerung] [varchar](255) NULL,
	[KenntnisseAggression] [varchar](255) NULL,
	[KenntnisseHilfsmittel] [varchar](255) NULL,
	[KenntnisseTransport] [varchar](255) NULL,
	[KenntnisseKommunikation] [varchar](255) NULL,
	[KenntnisseWeitere] [varchar](2000) NULL,
	[Versichertennummer] [varchar](18) NULL,
	[FreieKapazitaet] [varchar](1000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[EdMitarbeiterTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdMitarbeiter] PRIMARY KEY CLUSTERED 
(
	[EdMitarbeiterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_EdMitarbeiter_UserID_Unique]    Script Date: 08/27/2014 11:11:06 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_EdMitarbeiter_UserID_Unique] ON [dbo].[EdMitarbeiter] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_EdMitarbeiter_ZusatzNationalitaetLandCode]    Script Date: 08/27/2014 11:11:06 ******/
CREATE NONCLUSTERED INDEX [IX_EdMitarbeiter_ZusatzNationalitaetLandCode] ON [dbo].[EdMitarbeiter] 
(
	[ZusatzNationalitaetLandCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Markus Boss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter', @level2type=N'COLUMN',@level2name=N'EdMitarbeiterID'
GO

EXEC sys.sp_addextendedproperty @name=N'Customer only', @value=N'Pro Infirmis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter', @level2type=N'COLUMN',@level2name=N'EdMitarbeiterID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für EdMitarbeiter Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter', @level2type=N'COLUMN',@level2name=N'EdMitarbeiterID'
GO

EXEC sys.sp_addextendedproperty @name=N'Obsolete', @value=N'0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter', @level2type=N'COLUMN',@level2name=N'EdMitarbeiterID'
GO

EXEC sys.sp_addextendedproperty @name=N'Read only', @value=N'0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter', @level2type=N'COLUMN',@level2name=N'EdMitarbeiterID'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Entlastungsdienst' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter', @level2type=N'COLUMN',@level2name=N'EdMitarbeiterID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XUser.UserID (Unique)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Versichertennummer des Benutzers' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter', @level2type=N'COLUMN',@level2name=N'Versichertennummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Textfeld Freie Kapazität' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter', @level2type=N'COLUMN',@level2name=N'FreieKapazitaet'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Markus Boss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter'
GO

EXEC sys.sp_addextendedproperty @name=N'Customer only', @value=N'Pro Infirmis' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mitarbeiter Entlastungsdienst' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter'
GO

EXEC sys.sp_addextendedproperty @name=N'Obsolete', @value=N'0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter'
GO

EXEC sys.sp_addextendedproperty @name=N'Read only', @value=N'0' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Entlastungsdienst' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter'
GO

ALTER TABLE [dbo].[EdMitarbeiter]  WITH CHECK ADD  CONSTRAINT [FK_EdMitarbeiter_BaLand_ZusatzNationalitaetLandCode] FOREIGN KEY([ZusatzNationalitaetLandCode])
REFERENCES [dbo].[BaLand] ([BaLandID])
GO

ALTER TABLE [dbo].[EdMitarbeiter] CHECK CONSTRAINT [FK_EdMitarbeiter_BaLand_ZusatzNationalitaetLandCode]
GO

ALTER TABLE [dbo].[EdMitarbeiter]  WITH CHECK ADD  CONSTRAINT [FK_EdMitarbeiter_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[EdMitarbeiter] CHECK CONSTRAINT [FK_EdMitarbeiter_XUser]
GO

ALTER TABLE [dbo].[EdMitarbeiter]  WITH CHECK ADD  CONSTRAINT [FK_EdMitarbeiter_XUser_Interview] FOREIGN KEY([UserIDInterview])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[EdMitarbeiter] CHECK CONSTRAINT [FK_EdMitarbeiter_XUser_Interview]
GO

ALTER TABLE [dbo].[EdMitarbeiter]  WITH CHECK ADD  CONSTRAINT [FK_EdMitarbeiter_XUser_Vorgesetzter] FOREIGN KEY([UserIDVorgesetzter])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[EdMitarbeiter] CHECK CONSTRAINT [FK_EdMitarbeiter_XUser_Vorgesetzter]
GO

ALTER TABLE [dbo].[EdMitarbeiter] ADD  CONSTRAINT [DF_EdMitarbeiter_Created]  DEFAULT (getdate()) FOR [Created]
GO

