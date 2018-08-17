CREATE TABLE [dbo].[XOrgUnit](
	[OrgUnitID] [int] IDENTITY(1,1) NOT NULL,
	[ParentID] [int] NULL,
	[ModulID] [int] NULL,
	[ChiefID] [int] NULL,
	[RechtsdienstUserID] [int] NULL,
	[RepresentativeID] [int] NULL,
	[StellvertreterID] [int] NULL,
	[XProfileID] [int] NULL,
	[ItemName] [varchar](100) NOT NULL,
	[OEItemTypCode] [int] NULL,
	[ParentPosition] [int] NULL,
	[Kostenstelle] [int] NULL,
	[Mandantennummer] [int] NULL,
	[StundenLohnlaufNr] [int] NULL,
	[LeistungLohnlaufNr] [int] NULL,
	[Sammelkonto] [int] NULL,
	[PCKonto] [varchar](100) NULL,
	[AD_Abteilung] [varchar](2000) NULL,
	[Logo] [varchar](max) NULL,
	[Adressat] [varchar](2000) NULL,
	[Adresse] [varchar](2000) NULL,
	[AdresseKGS] [varchar](100) NULL,
	[AdresseAbteilung] [varchar](100) NULL,
	[AdresseStrasse] [varchar](100) NULL,
	[Postfach] [varchar](100) NULL,
	[PostfachOhneNr] [bit] NOT NULL,
	[AdresseHausNr] [varchar](10) NULL,
	[AdressePLZ] [varchar](10) NULL,
	[AdresseOrt] [varchar](50) NULL,
	[Phone] [varchar](100) NULL,
	[Telefon] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[WWW] [varchar](100) NULL,
	[Internet] [varchar](100) NULL,
	[UserProfileCode] [int] NULL,
	[Text1] [varchar](2000) NULL,
	[Text2] [varchar](2000) NULL,
	[Text3] [varchar](2000) NULL,
	[Text4] [varchar](2000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VerID] [int] NULL,
	[XOrgUnitTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XOrgUnit] PRIMARY KEY CLUSTERED 
(
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_XOrgUnit_ParentID_ParentPosition] UNIQUE NONCLUSTERED 
(
	[ParentID] ASC,
	[ParentPosition] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_ChiefID] ON [dbo].[XOrgUnit] 
(
	[ChiefID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_Kostenstelle] ON [dbo].[XOrgUnit] 
(
	[Kostenstelle] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_Mandantennummer] ON [dbo].[XOrgUnit] 
(
	[Mandantennummer] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_ModulID] ON [dbo].[XOrgUnit] 
(
	[ModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_OEItemTypCode] ON [dbo].[XOrgUnit] 
(
	[OEItemTypCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_OrgUnitID_ItemName] ON [dbo].[XOrgUnit] 
(
	[OrgUnitID] ASC,
	[ItemName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_OrgUnitID_Kostenstelle_ItemName] ON [dbo].[XOrgUnit] 
(
	[OrgUnitID] ASC,
	[Kostenstelle] ASC,
	[ItemName] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_OrgUnitID_OEItemTypCode] ON [dbo].[XOrgUnit] 
(
	[OrgUnitID] ASC,
	[OEItemTypCode] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_OrgUnitID_ParentID] ON [dbo].[XOrgUnit] 
(
	[OrgUnitID] ASC,
	[ParentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_OrgUnitID_ParentID_MandantenNr_LohnlaufNrn_Sammelkonto] ON [dbo].[XOrgUnit] 
(
	[OrgUnitID] ASC,
	[ParentID] ASC,
	[Mandantennummer] ASC,
	[StundenLohnlaufNr] ASC,
	[LeistungLohnlaufNr] ASC,
	[Sammelkonto] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_RechtsdienstUserID] ON [dbo].[XOrgUnit] 
(
	[RechtsdienstUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_RepresentativeID] ON [dbo].[XOrgUnit] 
(
	[RepresentativeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_XOrgUnit_XProfileID] ON [dbo].[XOrgUnit] 
(
	[XProfileID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für XOrgUnit Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: XOrgUnit.ParentID => XOrgUnit.OrgUnitID, Verweis auf das das Elternelement in der hierarchischen Abteilungsstruktur' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'ParentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: XOrgUnit.ModulD => XModul.ModulID, wird für die Filterung gewisser Datensätze verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'ModulID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: XOrgUnit.ChiefID => XUser.UserID, ID des Leiters der Abteilung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'ChiefID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: XOrgUnit.RechtsdienstUserID => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'RechtsdienstUserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel: XOrgUnit.ReprensentativeID => XUser.UserID, Stellvertreter des XOrgUnit.ChiefID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'RepresentativeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zur Tabelle XProfile. Das Profil dient als Filter für Vorlagen bei der Dokumentgeneration.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'XProfileID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Abteilung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'ItemName'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Typ der Abteilung gemäss Werteliste: OrganisationsEinheitTyp' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'OEItemTypCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Position innerhalb derselben ParentID Hierarchiestruktur' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'ParentPosition'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kostenstelle der Abteilung (kann jede Abteilung eine eigene haben)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Kostenstelle'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mandantennummer der Abteilung. Dies wird in der Businesslogik definiert, dass dieselbe Mandantennummer der Elternabteilung(en) gilt, sofern nicht selber eine eigene definiert wird' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Mandantennummer'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lohnlaufnummer für die Stundenlohnschnittstelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'StundenLohnlaufNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Lohnlaufnummer für die Leistungsdatenschnittstelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'LeistungLohnlaufNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Sammelkontonummer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Sammelkonto'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'PC-Kontonummer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'PCKonto'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Logo der Abteilung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Logo'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Adresse der Abteilung als Ganzes (Standard)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Adressat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Adresse der Abteilung als Ganzes (ZH)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Adresse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der KGS für die Adresse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'AdresseKGS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Name der Abteilung für die Adresse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'AdresseAbteilung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Strasse der Adresse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'AdresseStrasse'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Postfach der Adresse' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Postfach'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob das Postfach eine Nummer hat oder lediglich mit Postfach angeschrieben werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'PostfachOhneNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Hausnummer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'AdresseHausNr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Postleitzahl' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'AdressePLZ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ortschaft' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'AdresseOrt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telefonnummer der Abteilung (TODO: Telefon vs. Phone)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Phone'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Telefonnummer der Abteilung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Telefon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Faxnummer der Abteilung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Fax'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Emailadresse der Abteilung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'EMail'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Internet-/Intranet-Seite der Abteilung (TODO: WWW vs. Internet)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'WWW'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Internet-/Intranet-Seite der Abteilung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Internet'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzerprofil (TODO: XProfileID --> Neue Vorlagenverwaltung)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'UserProfileCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitext 1' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Text1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitext 2' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Text2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitext 3' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Text3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Freitext 4' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Text4'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VersionsID des Records für die Historisierung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit', @level2type=N'COLUMN',@level2name=N'VerID'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi (angepasst)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet sämtliche Abteilungen für die Benutzerverwaltung in hierarchischer Struktur' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'System' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'XOrgUnit'
GO

SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE TRIGGER [dbo].[trHist_XOrgUnit]
  ON [dbo].[XOrgUnit]
  FOR INSERT, UPDATE, DELETE
AS BEGIN
  SET NOCOUNT ON
  DECLARE @VerID     INT

  SELECT TOP 1 @VerID = VerID FROM HistoryVersion
  WHERE SessionID = @@SPID AND DateDiff(n, VersionDate, GetDate()) < 60
  ORDER BY VerID DESC

  IF @VerID IS NULL BEGIN
    RAISERROR ('Table [XOrgUnit] is under Version Control you must first create a new HistoryVersion entry', 16, 1)
    ROLLBACK TRANSACTION
  END

  DECLARE @Changes TABLE (
    [OrgUnitID] int NOT NULL,
    VerID         int NULL,
    ActionCode    int NOT NULL
    PRIMARY KEY (ActionCode, [OrgUnitID])
  )

  INSERT INTO @Changes
    SELECT IsNull(INS.[OrgUnitID], DEL.[OrgUnitID]), TBL.VerID,
      CASE WHEN (INS.[OrgUnitID] IS NULL) THEN 3 WHEN (DEL.[OrgUnitID] IS NULL) THEN 1 ELSE 2 END
    FROM INSERTED                                INS
      FULL OUTER JOIN DELETED                    DEL ON DEL.[OrgUnitID] = INS.[OrgUnitID]
      LEFT       JOIN [Hist_XOrgUnit]  TBL ON TBL.[OrgUnitID] = DEL.[OrgUnitID] AND TBL.VerID_DELETED IS NULL
    WHERE (INS.[OrgUnitID] IS NULL) OR (DEL.[OrgUnitID] IS NULL)
      OR CHECKSUM(INS.[OrgUnitID], INS.[ParentID], INS.[ModulID], INS.[ChiefID], INS.[RechtsdienstUserID], INS.[RepresentativeID], INS.[StellvertreterID], INS.[XProfileID], INS.[ItemName], INS.[OEItemTypCode], INS.[ParentPosition], INS.[Kostenstelle], INS.[Mandantennummer], INS.[StundenLohnlaufNr], INS.[LeistungLohnlaufNr], INS.[Sammelkonto], INS.[PCKonto], INS.[AD_Abteilung], INS.[Logo], INS.[Adressat], INS.[Adresse], INS.[AdresseKGS], INS.[AdresseAbteilung], INS.[AdresseStrasse], INS.[Postfach], INS.[PostfachOhneNr], INS.[AdresseHausNr], INS.[AdressePLZ], INS.[AdresseOrt], INS.[Phone], INS.[Telefon], INS.[Fax], INS.[EMail], INS.[WWW], INS.[Internet], INS.[UserProfileCode], INS.[Text1], INS.[Text2], INS.[Text3], INS.[Text4], INS.[Creator], INS.[Created], INS.[Modifier], INS.[Modified])
      <> CHECKSUM(TBL.[OrgUnitID], TBL.[ParentID], TBL.[ModulID], TBL.[ChiefID], TBL.[RechtsdienstUserID], TBL.[RepresentativeID], TBL.[StellvertreterID], TBL.[XProfileID], TBL.[ItemName], TBL.[OEItemTypCode], TBL.[ParentPosition], TBL.[Kostenstelle], TBL.[Mandantennummer], TBL.[StundenLohnlaufNr], TBL.[LeistungLohnlaufNr], TBL.[Sammelkonto], TBL.[PCKonto], TBL.[AD_Abteilung], TBL.[Logo], TBL.[Adressat], TBL.[Adresse], TBL.[AdresseKGS], TBL.[AdresseAbteilung], TBL.[AdresseStrasse], TBL.[Postfach], TBL.[PostfachOhneNr], TBL.[AdresseHausNr], TBL.[AdressePLZ], TBL.[AdresseOrt], TBL.[Phone], TBL.[Telefon], TBL.[Fax], TBL.[EMail], TBL.[WWW], TBL.[Internet], TBL.[UserProfileCode], TBL.[Text1], TBL.[Text2], TBL.[Text3], TBL.[Text4], TBL.[Creator], TBL.[Created], TBL.[Modifier], TBL.[Modified])
     
     

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode = 2)
    DELETE TBL
    FROM [Hist_XOrgUnit]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode = 2 AND UPD.[OrgUnitID] = TBL.[OrgUnitID]
    WHERE TBL.VerID = @VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode > 1)
    UPDATE TBL
      SET VerID_DELETED = @VerID
    FROM [Hist_XOrgUnit]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode > 1 AND UPD.[OrgUnitID] = TBL.[OrgUnitID] AND UPD.VerID = TBL.VerID

  IF EXISTS (SELECT * FROM @Changes UPD WHERE ActionCode < 3) BEGIN
    INSERT INTO Hist_XOrgUnit ([OrgUnitID], [ParentID], [ModulID], [ChiefID], [RechtsdienstUserID], [RepresentativeID], [StellvertreterID], [XProfileID], [ItemName], [OEItemTypCode], [ParentPosition], [Kostenstelle], [Mandantennummer], [StundenLohnlaufNr], [LeistungLohnlaufNr], [Sammelkonto], [PCKonto], [AD_Abteilung], [Logo], [Adressat], [Adresse], [AdresseKGS], [AdresseAbteilung], [AdresseStrasse], [Postfach], [PostfachOhneNr], [AdresseHausNr], [AdressePLZ], [AdresseOrt], [Phone], [Telefon], [Fax], [EMail], [WWW], [Internet], [UserProfileCode], [Text1], [Text2], [Text3], [Text4], [Creator], [Created], [Modifier], [Modified], VerID)
      SELECT TBL.[OrgUnitID], TBL.[ParentID], TBL.[ModulID], TBL.[ChiefID], TBL.[RechtsdienstUserID], TBL.[RepresentativeID], TBL.[StellvertreterID], TBL.[XProfileID], TBL.[ItemName], TBL.[OEItemTypCode], TBL.[ParentPosition], TBL.[Kostenstelle], TBL.[Mandantennummer], TBL.[StundenLohnlaufNr], TBL.[LeistungLohnlaufNr], TBL.[Sammelkonto], TBL.[PCKonto], TBL.[AD_Abteilung], TBL.[Logo], TBL.[Adressat], TBL.[Adresse], TBL.[AdresseKGS], TBL.[AdresseAbteilung], TBL.[AdresseStrasse], TBL.[Postfach], TBL.[PostfachOhneNr], TBL.[AdresseHausNr], TBL.[AdressePLZ], TBL.[AdresseOrt], TBL.[Phone], TBL.[Telefon], TBL.[Fax], TBL.[EMail], TBL.[WWW], TBL.[Internet], TBL.[UserProfileCode], TBL.[Text1], TBL.[Text2], TBL.[Text3], TBL.[Text4], TBL.[Creator], TBL.[Created], TBL.[Modifier], TBL.[Modified], @VerID
      FROM [XOrgUnit]  TBL
        INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[OrgUnitID] = TBL.[OrgUnitID]

    UPDATE TBL
      SET VerID = @VerID
    FROM [XOrgUnit]  TBL
      INNER JOIN @Changes  UPD ON UPD.ActionCode < 3 AND UPD.[OrgUnitID] = TBL.[OrgUnitID]
    WHERE IsNull(TBL.VerID, -1) != @VerID
  END
  SET NOCOUNT OFF
END
GO

ALTER TABLE [dbo].[XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_XModul] FOREIGN KEY([ModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO

ALTER TABLE [dbo].[XOrgUnit] CHECK CONSTRAINT [FK_XOrgUnit_XModul]
GO

ALTER TABLE [dbo].[XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_XOrgUnit] FOREIGN KEY([ParentID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO

ALTER TABLE [dbo].[XOrgUnit] CHECK CONSTRAINT [FK_XOrgUnit_XOrgUnit]
GO

ALTER TABLE [dbo].[XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_XProfile] FOREIGN KEY([XProfileID])
REFERENCES [dbo].[XProfile] ([XProfileID])
GO

ALTER TABLE [dbo].[XOrgUnit] CHECK CONSTRAINT [FK_XOrgUnit_XProfile]
GO

ALTER TABLE [dbo].[XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_XUser_ChiefID] FOREIGN KEY([ChiefID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XOrgUnit] CHECK CONSTRAINT [FK_XOrgUnit_XUser_ChiefID]
GO

ALTER TABLE [dbo].[XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_XUser_RechtsdienstUserID] FOREIGN KEY([RechtsdienstUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XOrgUnit] CHECK CONSTRAINT [FK_XOrgUnit_XUser_RechtsdienstUserID]
GO

ALTER TABLE [dbo].[XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_XOrgUnit_XUser_RepresentativeID] FOREIGN KEY([RepresentativeID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[XOrgUnit] CHECK CONSTRAINT [FK_XOrgUnit_XUser_RepresentativeID]
GO

ALTER TABLE [dbo].[XOrgUnit] ADD  CONSTRAINT [DF_XOrgUnit_PostfachOhneNr]  DEFAULT ((0)) FOR [PostfachOhneNr]
GO

ALTER TABLE [dbo].[XOrgUnit] ADD  CONSTRAINT [DF_XOrgUnit_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[XOrgUnit] ADD  CONSTRAINT [DF_XOrgUnit_Modified]  DEFAULT (getdate()) FOR [Modified]
GO