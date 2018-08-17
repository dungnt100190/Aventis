CREATE TABLE [dbo].[GvGesuch](
	[GvGesuchID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[XUserID_Autor] [int] NOT NULL,
  [UserIDBewilligt] [int] NULL,
	[DocumentID] [int] NULL,
	[GvFondsID] [int] NOT NULL,
  [ErfasstesGesuchgeprueftdurchIKS_UserID] [int] NULL,
  [AbgeschlossenesGesuchdurchIKS_UserID] [int] NULL,
	[GvStatusCode] [int] NOT NULL,
	[GesuchsDatum] [datetime] NOT NULL,
  [ErfassungAbgeschlossen] [datetime] NULL,
	[BetragBewilligt] [money] NULL,
	[BewilligtAm] [datetime] NULL,
	[Begruendung] [varchar](max) NULL,
	[Bemerkung] [varchar](2000) NULL,
	[BetragBewilligtKompetenzstufe1] [money] NULL,
	[DatumBewilligtKompetenzstufe1] [datetime] NULL,
	[BemerkungBewilligungKompetenzstufe1] [varchar](max) NULL,
	[BetragBewilligtKompetenzstufe2] [money] NULL,
	[DatumBewilligtKompetenzstufe2] [datetime] NULL,
	[BemerkungBewilligungKompetenzstufe2] [varchar](max) NULL,
	[AbschlussDatum] [datetime] NULL,
	[GvAbschlussgrundCode] [int] NULL,
	[Gesuchsgrund] [varchar](40) NOT NULL,
	[IstEigenkompetenz] [bit] NOT NULL,
	[IstKompetenzBsl] [bit] NOT NULL,
	[IstKompetenzKanton] [bit] NOT NULL,
	[Extern] [bit] NOT NULL,
  [ErfasstesGesuchgeprueftam] [datetime] NULL,
  [ErfasstesGesuchBesprechen] [bit] NOT NULL,
  [ErfasstesGesuchBemerkung] [varchar](max) NULL,
  [AbgeschlossenesGesuchgeprueftam] [datetime] NULL,
  [AbgeschlossenesGesuchBesprechen] [bit] NOT NULL,
  [AbgeschlossenesGesuchBemerkung] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvGesuchTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvGesuch] PRIMARY KEY CLUSTERED 
(
	[GvGesuchID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvGesuch_BaPersonID]    Script Date: 11/14/2012 09:03:10 ******/
CREATE NONCLUSTERED INDEX [IX_GvGesuch_BaPersonID] ON [dbo].[GvGesuch] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_GvGesuch_GvFondsID]    Script Date: 11/14/2012 09:03:10 ******/
CREATE NONCLUSTERED INDEX [IX_GvGesuch_GvFondsID] ON [dbo].[GvGesuch] 
(
	[GvFondsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_GvGesuch_XUserID_Autor]    Script Date: 11/14/2012 09:03:10 ******/
CREATE NONCLUSTERED INDEX [IX_GvGesuch_XUserID_Autor] ON [dbo].[GvGesuch] 
(
	[XUserID_Autor] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_GvGesuch_ErfasstesGesuchgeprueftdurchIKS_UserID]  ******/
CREATE NONCLUSTERED INDEX [IX_GvGesuch_ErfasstesGesuchgeprueftdurchIKS_UserID] ON [dbo].[GvGesuch] 
(
	[ErfasstesGesuchgeprueftdurchIKS_UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_GvGesuch_AbgeschlossenesGesuchdurchIKS_UserID]  ******/
CREATE NONCLUSTERED INDEX [IX_GvGesuch_AbgeschlossenesGesuchdurchIKS_UserID] ON [dbo].[GvGesuch] 
(
	[AbgeschlossenesGesuchdurchIKS_UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO



EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für GvGesuch Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'GvGesuchID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvGesuch_BaPerson) => BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvGesuch_XUser) => XUserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'XUserID_Autor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK auf GvDocument' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_GvGesuch_GvFond) => GvFondsID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'GvFondsID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'LOV GvStatus' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'GvStatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Gesuchs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'GesuchsDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Erfassung (Abschluss)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'ErfassungAbgeschlossen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bewilligter Betrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'BetragBewilligt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Bewilligung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'BewilligtAm'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Begruendung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'Begruendung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kleine Bemerkung zum Gesuch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Von Kompetenzstufe 1 bewilligter Betrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'BetragBewilligtKompetenzstufe1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Bewillgung durch Kompetenzstufe 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'DatumBewilligtKompetenzstufe1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung zur Bewilligung durch Kompetenzstufe 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'BemerkungBewilligungKompetenzstufe1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Von Kompetenzstufe 2 bewilligter Betrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'BetragBewilligtKompetenzstufe2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum Bewillgung durch Kompetenzstufe 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'DatumBewilligtKompetenzstufe2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung zur Bewilligung durch Kompetenzstufe 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'BemerkungBewilligungKompetenzstufe2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum, wann das Gesuch abgeschlossen wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'AbschlussDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grund, weshalb das Gesuch abgeschlossen wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'GvAbschlussgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Grund des Gesuchs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'Gesuchsgrund'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Info Flag zum wissen ob das Gesuch Eigenkompetenz ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'IstEigenkompetenz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Info Flag zum wissen ob das Gesuch Kompetenz BSL ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'IstKompetenzBsl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Info Flag zum wissen ob das Gesuch Kompetenz Kanton FLB-Ko/KK ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'IstKompetenzKanton'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Info Flag, ob das Gesuch extern ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'Extern'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'GvGesuchTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Peter Salajan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die Informationen für Gesuche' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GvGesuch_ErfasstesGesuchgeprueftdurchIKS_UserID (Fremdschlüssel FK_GvGesuch_ErfasstesGesuchgeprueftdurchIKS_UserID) => UserID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'ErfasstesGesuchgeprueftdurchIKS_UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'GvGesuch_AbgeschlossenesGesuchdurchIKS_UserID (Fremdschlüssel FK_GvGesuch_AbgeschlossenesGesuchdurchIKS_UserID) => UserID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'AbgeschlossenesGesuchdurchIKS_UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ErfasstesGesuchBesprechen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'ErfasstesGesuchBesprechen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AbgeschlossenesGesuchBesprechen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'AbgeschlossenesGesuchBesprechen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ErfasstesGesuchgeprueftam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'ErfasstesGesuchgeprueftam'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AbgeschlossenesGesuchgeprueftam' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'AbgeschlossenesGesuchgeprueftam'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ErfasstesGesuchBemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'ErfasstesGesuchBemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'AbgeschlossenesGesuchBemerkung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvGesuch', @level2type=N'COLUMN',@level2name=N'AbgeschlossenesGesuchBemerkung'
GO



ALTER TABLE [dbo].[GvGesuch]  WITH CHECK ADD  CONSTRAINT [FK_GvGesuch_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[GvGesuch] CHECK CONSTRAINT [FK_GvGesuch_BaPerson]
GO

ALTER TABLE [dbo].[GvGesuch]  WITH CHECK ADD  CONSTRAINT [FK_GvGesuch_GvFonds] FOREIGN KEY([GvFondsID])
REFERENCES [dbo].[GvFonds] ([GvFondsID])
GO

ALTER TABLE [dbo].[GvGesuch] CHECK CONSTRAINT [FK_GvGesuch_GvFonds]
GO

ALTER TABLE [dbo].[GvGesuch]  WITH CHECK ADD  CONSTRAINT [FK_GvGesuch_XUser] FOREIGN KEY([XUserID_Autor])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[GvGesuch] CHECK CONSTRAINT [FK_GvGesuch_XUser]
GO

ALTER TABLE [dbo].[GvGesuch] ADD  CONSTRAINT [DF_GvGesuch_IstEigenkompetenz]  DEFAULT ((0)) FOR [IstEigenkompetenz]
GO

ALTER TABLE [dbo].[GvGesuch] ADD  CONSTRAINT [DF_GvGesuch_IstKompetenzBsl]  DEFAULT ((0)) FOR [IstKompetenzBsl]
GO

ALTER TABLE [dbo].[GvGesuch] ADD  CONSTRAINT [DF_GvGesuch_IstKompetenzKanton]  DEFAULT ((0)) FOR [IstKompetenzKanton]
GO

ALTER TABLE [dbo].[GvGesuch] ADD  CONSTRAINT [DF_GvGesuch_Extern]  DEFAULT ((0)) FOR [Extern]
GO

ALTER TABLE [dbo].[GvGesuch] ADD  CONSTRAINT [DF_GvGesuch_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvGesuch] ADD  CONSTRAINT [DF_GvGesuch_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

ALTER TABLE [dbo].[GvGesuch]  WITH CHECK ADD  CONSTRAINT [FK_GvGesuch_ErfasstesGesuchgeprueftdurchIKS_UserID] FOREIGN KEY([ErfasstesGesuchgeprueftdurchIKS_UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[GvGesuch] CHECK CONSTRAINT [FK_GvGesuch_ErfasstesGesuchgeprueftdurchIKS_UserID]
GO

ALTER TABLE [dbo].[GvGesuch]  WITH CHECK ADD  CONSTRAINT [FK_GvGesuch_AbgeschlossenesGesuchdurchIKS_UserID] FOREIGN KEY([AbgeschlossenesGesuchdurchIKS_UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[GvGesuch] CHECK CONSTRAINT [FK_GvGesuch_AbgeschlossenesGesuchdurchIKS_UserID]
GO

ALTER TABLE [dbo].[GvGesuch] ADD  CONSTRAINT [DF_GvGesuch_ErfasstesGesuchBesprechen]  DEFAULT ((0)) FOR [ErfasstesGesuchBesprechen]
GO

ALTER TABLE [dbo].[GvGesuch] ADD  CONSTRAINT [DF_GvGesuch_AbgeschlossenesGesuchBesprechen]  DEFAULT ((0)) FOR [AbgeschlossenesGesuchBesprechen]
GO