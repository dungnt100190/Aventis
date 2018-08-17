CREATE TABLE [dbo].[BaGesundheit](
  [BaGesundheitID] [int] IDENTITY(1,1) NOT NULL,
  [BaPersonID] [int] NOT NULL,
  [Jahr] [int] NOT NULL,
  [KVGOrganisationID] [int] NULL,
  [KVGKontaktPerson] [varchar](100) NULL,
  [KVGKontaktTelefon] [varchar](100) NULL,
  [KVGMitgliedNr] [varchar](50) NULL,
  [KVGVersichertSeit] [datetime] NULL,
  [KVGGrundPraemie] [money] NULL,
  [KVGUnfallPraemie] [money] NULL,
  [KVGGesundFoerdPraemie] [money] NULL,
  [KVGZuschussBetrag] [money] NULL,
  [KVGUmweltabgabeBetrag] [money] NULL,
  [KVGPraemie] [money] NULL,
  [KVGFranchise] [money] NULL,
  [KVGZahlungsPeriodeCode] [int] NULL,
  [VVGOrganisationID] [int] NULL,
  [VVGKontaktPerson] [varchar](100) NULL,
  [VVGKontaktTelefon] [varchar](100) NULL,
  [VVGMitgliedNr] [varchar](50) NULL,
  [VVGVersichertSeit] [datetime] NULL,
  [VVGPraemie] [money] NULL,
  [VVGFranchise] [money] NULL,
  [VVGZahlungsPeriodeCode] [int] NULL,
  [VVGZusaetzeRTF] [varchar](2000) NULL,
  [ZuschussInAbklaerungFlag] [bit] NULL,
  [IVEingliederungsmassnahmeCode] [int] NULL,
  [PflegeDurchCode] [int] NULL,
  [PflegebeduerftigFlag] [bit] NULL,
  [DatumVon] [datetime] NULL,
  [ASVSAbmeldung] [datetime] NULL,
  [ASVSAnmeldung] [datetime] NULL,
  [Bemerkung] [varchar](max) NULL,
  [AbtretungKK] [bit] NOT NULL,
  [EVAZDatum] [datetime] NULL,
  [ZahnarztBaInstitutionID] [int] NULL,
  [BaGesundheitTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaGesundheit] PRIMARY KEY CLUSTERED 
(
  [BaGesundheitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY],
 CONSTRAINT [UK_BaGesundheit_BaPersonID_Jahr] UNIQUE NONCLUSTERED 
(
  [BaPersonID] ASC,
  [Jahr] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_BaGesundheit_BaPersonID_Jahr] ON [dbo].[BaGesundheit] 
(
  [BaPersonID] ASC,
  [Jahr] DESC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaGesundheit Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'BaGesundheitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaGesundheit_BaPerson) => BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Jahr des Datensatzes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'Jahr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaGesundheit_BaInstitution_KVG) => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGOrganisationID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitextangabe. Gedacht für Kontaktperson der zugehörigen KVG-Krankenkasse (KVGOrganisationID)  ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGKontaktPerson'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitextangabe. Gedacht für Telefonnummer der zugehörigen KVG-Krankenkasse (KVGOrganisationID) bzw. deren Kontaktperson (KVGKontaktPerson)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGKontaktTelefon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitextangabe. Gedacht für Mitglied-Nr der zugehörigen KVG-Krankenkasse (KVGOrganisationID).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGMitgliedNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Vertragsbeginns mit der zugehörigen KVG-Krankenkasse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGVersichertSeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der KVG Grundprämie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGGrundPraemie'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der KVG-Unfallprämie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGUnfallPraemie'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der KVG Gesundheits-Förderungs-Prämie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGGesundFoerdPraemie'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag des KVG-Zuschuss (Prämienverbilligung)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGZuschussBetrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der KVG-Umweltabgabe' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGUmweltabgabeBetrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der KVG-Prämie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGPraemie'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der KVG-Franchise' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGFranchise'
GO

EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'monatlich, zweimonatlich, vierteljährlich, halbjährlich, jährlich, 2 x pro Monat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGZahlungsPeriodeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zahlungs-Periode der KVG-Krankenkasse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGZahlungsPeriodeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'LOVName: ZahlungsPeriode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'KVGZahlungsPeriodeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaGesundheit_BaInstitution_VVG) => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGOrganisationID'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'VVG-Krankenkasse (Versicherungs-Vertrags-Gesetz)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGOrganisationID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitextangabe. Gedacht für Kontaktperson der zugehörigen VVG-Krankenkasse (VVGOrganisationID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGKontaktPerson'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitextangabe. Gedacht für Telefonnummer der zugehörigen VVG-Krankenkasse (VVGOrganisationID) bzw. deren Kontaktperson (VVGKontaktPerson)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGKontaktTelefon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitextangabe. Gedacht für Mitglied-Nr der zugehörigen VVG-Krankenkasse (VVGOrganisationID).' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGMitgliedNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Vertragsbeginns mit der zugehörigen VVG-Krankenkasse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGVersichertSeit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der VVG-Prämie' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGPraemie'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der VVG-Franchise' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGFranchise'
GO

EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'monatlich, zweimonatlich, vierteljährlich, halbjährlich, jährlich, 2 x pro Monat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGZahlungsPeriodeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zahlungs-Periode der VVG-Krankenkasse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGZahlungsPeriodeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'LOVName: ZahlungsPeriode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGZahlungsPeriodeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'Unfalleinschluss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGZusaetzeRTF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitextfeld zur Erfassung weitere Zusatzversicherungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'VVGZusaetzeRTF'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob KVG Prämienverbilligung zurzeit abgeklärt wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'ZuschussInAbklaerungFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'TODO rename!' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'ZuschussInAbklaerungFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'ja, nein, in Abklärung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'IVEingliederungsmassnahmeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angabe ob Person IV erhält' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'IVEingliederungsmassnahmeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'LOVName: InAbklaerung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'IVEingliederungsmassnahmeCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'Haushaltsmitglieder, Organisation / Institution (Gemeinde, Kirche, Hilfswerk),  andere, nicht festgestellt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'PflegeDurchCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angabe durch wen Person geflegt wird.   Darf nur Wert enthalten, wenn PflegebeduerftigFlag = 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'PflegeDurchCode'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'LOVName: PflegeDurch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'PflegeDurchCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob Person pflegebedürftig ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'PflegebeduerftigFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'Example', @value=N'TODO: DELETE!' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'TODO: DELETE! War wohl für Historisierung gedacht' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'TODO: DELETE!' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'DatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Abmeldung ASV (Amt für Sozialversicherung)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'ASVSAbmeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Anmeldung ASV (Amt für Sozialversicherung)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'ASVSAnmeldung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitextfeld Maske BaGesundheit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'RTF Feld' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum EVAZ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'EVAZDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaGesundheit_BaInstitution) => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'ZahnarztBaInstitutionID'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Institution-ID des Zahnarztes' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaGesundheit', @level2type=N'COLUMN',@level2name=N'ZahnarztBaInstitutionID'
GO

ALTER TABLE [dbo].[BaGesundheit]  WITH CHECK ADD  CONSTRAINT [FK_BaGesundheit_BaInstitution] FOREIGN KEY([ZahnarztBaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaGesundheit] CHECK CONSTRAINT [FK_BaGesundheit_BaInstitution]
GO

ALTER TABLE [dbo].[BaGesundheit]  WITH CHECK ADD  CONSTRAINT [FK_BaGesundheit_BaInstitution_KVG] FOREIGN KEY([KVGOrganisationID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaGesundheit] CHECK CONSTRAINT [FK_BaGesundheit_BaInstitution_KVG]
GO

ALTER TABLE [dbo].[BaGesundheit]  WITH CHECK ADD  CONSTRAINT [FK_BaGesundheit_BaInstitution_VVG] FOREIGN KEY([VVGOrganisationID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaGesundheit] CHECK CONSTRAINT [FK_BaGesundheit_BaInstitution_VVG]
GO

ALTER TABLE [dbo].[BaGesundheit]  WITH CHECK ADD  CONSTRAINT [FK_BaGesundheit_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaGesundheit] CHECK CONSTRAINT [FK_BaGesundheit_BaPerson]
GO

ALTER TABLE [dbo].[BaGesundheit] ADD  CONSTRAINT [DF_BaGesundheit_Jahr]  DEFAULT (datepart(year,getdate())) FOR [Jahr]
GO

ALTER TABLE [dbo].[BaGesundheit] ADD  CONSTRAINT [DF_BaGesundheit_ZuschussInAbklaerungFlag]  DEFAULT ((0)) FOR [ZuschussInAbklaerungFlag]
GO

ALTER TABLE [dbo].[BaGesundheit] ADD  CONSTRAINT [DF_BaGesundheit_PflegebeduerftigFlag]  DEFAULT ((0)) FOR [PflegebeduerftigFlag]
GO

ALTER TABLE [dbo].[BaGesundheit] ADD  CONSTRAINT [DF_BaGesundheit_AbtretungKK]  DEFAULT ((0)) FOR [AbtretungKK]
GO
