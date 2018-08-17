CREATE TABLE [dbo].[FaWeisung](
	[FaWeisungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID_Creator] [int] NOT NULL,
	[UserID_VerantwortlichRD] [int] NULL,
	[UserID_VerantwortlichSAR] [int] NULL,
	[XTaskID_SAR] [int] NULL,
	[StatusCode] [int] NOT NULL,
	[WeisungsartCode] [int] NOT NULL,
	[Betreff] [varchar](100) NOT NULL,
	[Ausganslage] [varchar](max) NULL,
	[Auflage] [varchar](max) NULL,
	[KonsequenzCodeAngedroht] [int] NOT NULL,
	[KuerzungGBAngedroht] [int] NOT NULL,
	[TerminWeisung] [datetime] NULL,
	[XDocumentID_Weisung] [int] NULL,
	[TerminMahnung1] [datetime] NULL,
	[XDocumentID_Mahnung1] [int] NULL,
	[TerminMahnung2] [datetime] NULL,
	[XDocumentID_Mahnung2] [int] NULL,
	[TerminMahnung3] [datetime] NULL,
	[XDocumentID_Mahnung3] [int] NULL,
	[DatumVerfuegung] [datetime] NULL,
	[XDocumentID_Verfuegung] [int] NULL,
	[KonsequenzCodeVerfuegt] [int] NULL,
	[KonsequenzDatumVon] [datetime] NULL,
	[KonsequenzDatumBis] [datetime] NULL,
	[KuerzungGBVerfuegt] [int] NULL,
	[KuerzungDatumVon] [datetime] NULL,
	[KuerzungDatumBis] [datetime] NULL,
	[WeisungVerschoben] [bit] NOT NULL,
	[WeisungErfuellt] [bit] NOT NULL,
	[CanDelete] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaWeisungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaWeisung] PRIMARY KEY CLUSTERED 
(
	[FaWeisungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Weisung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'FaWeisungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel einer FaLeistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel vom Benutzer, welcher den Datensatz erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'UserID_Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserID vom verantwortliche RD' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'UserID_VerantwortlichRD'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'UserID vom verantwortliche SAR' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'UserID_VerantwortlichSAR'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'StatusCode der Weisung, ein Enum im C# Code. Der Name des Enum ist FaWeisung.Status.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'StatusCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Weisungsart. Ist ein Enum im C# Code (schriftlich, mündlich). Der Name des Enum ist FaWeisung.Weisungsart.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'WeisungsartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betreff der Weisung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'Betreff'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Ausgangslage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'Ausganslage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Auflage' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'Auflage'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'angedrohte Konsequenz. KonsequenzCode aus LOV Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'KonsequenzCodeAngedroht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'angedrohte Kürzung zwischen 0 und Konfig-Wert KuerzungMaxProzentsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'KuerzungGBAngedroht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Termin der Weisung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'TerminWeisung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Document der Weisung. Fremdschlüssel aud XDocument.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'XDocumentID_Weisung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Termin der 1. Mahnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'TerminMahnung1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Document der 1. Mahnung. Fremdschlüssel aud XDocument.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'XDocumentID_Mahnung1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Termin der 2. Mahnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'TerminMahnung2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Document der 2. Mahnung. Fremdschlüssel aud XDocument.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'XDocumentID_Mahnung2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Termin der 3. Mahnung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'TerminMahnung3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Document der 3. Mahnung. Fremdschlüssel aud XDocument.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'XDocumentID_Mahnung3'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Verfügung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'DatumVerfuegung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Document der Verfügung. Fremdschlüssel aud XDocument.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'XDocumentID_Verfuegung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'verfügte Konsequenz. KonsequenzCode aus LOV Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'KonsequenzCodeVerfuegt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Konsequenz gültig von Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'KonsequenzDatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Konsequenz gültig bis Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'KonsequenzDatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'verfügte Kürzung zwischen 0 und Konfig-Wert KuerzungMaxProzentsatz' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'KuerzungGBVerfuegt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kürzung gültig von Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'KuerzungDatumVon'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kürzung gültig bis Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'KuerzungDatumBis'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zum wissen ob die Weisung verschoben wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'WeisungVerschoben'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Die Weisung ist erfüllt (=1)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'WeisungErfuellt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung', @level2type=N'COLUMN',@level2name=N'FaWeisungTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'beinhaltet Weisungen Einträge.
Eine zwischen Tabelle für die Termine und Dokumente wurde Datenstrukturmässig schönner sein, aber komplexer im C# Code. Da wir nur 5 Termine und Dokumente haben sind sie direkt auf der Weisungstabelle.
Die zwischen Tabelle FaWeisung_TerminDocument (oder änlich) wurde die folgende Felder haben:
- FaWeisung_TerminDocumentID int identity
- FaWeisungID int
- XDocumentID int
- Termin datetime
- TerminTyp int (Weisung, Mahnung1, Mahnung2, Mahnung3, Verfuegung)
' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaWeisung'
GO

ALTER TABLE [dbo].[FaWeisung]  WITH CHECK ADD  CONSTRAINT [FK_FaWeisung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaWeisung] CHECK CONSTRAINT [FK_FaWeisung_FaLeistung]
GO

ALTER TABLE [dbo].[FaWeisung]  WITH CHECK ADD  CONSTRAINT [FK_FaWeisung_XTask] FOREIGN KEY([XTaskID_SAR])
REFERENCES [dbo].[XTask] ([XTaskID])
GO

ALTER TABLE [dbo].[FaWeisung] CHECK CONSTRAINT [FK_FaWeisung_XTask]
GO

ALTER TABLE [dbo].[FaWeisung]  WITH CHECK ADD  CONSTRAINT [FK_FaWeisung_XUser_Creator] FOREIGN KEY([UserID_Creator])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaWeisung] CHECK CONSTRAINT [FK_FaWeisung_XUser_Creator]
GO

ALTER TABLE [dbo].[FaWeisung]  WITH CHECK ADD  CONSTRAINT [FK_FaWeisung_XUser_VerantwortlichRD] FOREIGN KEY([UserID_VerantwortlichRD])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaWeisung] CHECK CONSTRAINT [FK_FaWeisung_XUser_VerantwortlichRD]
GO

ALTER TABLE [dbo].[FaWeisung]  WITH CHECK ADD  CONSTRAINT [FK_FaWeisung_XUser_VerantwortlichSAR] FOREIGN KEY([UserID_VerantwortlichSAR])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaWeisung] CHECK CONSTRAINT [FK_FaWeisung_XUser_VerantwortlichSAR]
GO

ALTER TABLE [dbo].[FaWeisung]  WITH CHECK ADD  CONSTRAINT [CK_FaWeisung_KuerzungGBAngedroht] CHECK  (([KuerzungGBAngedroht]>=(0) AND [KuerzungGBAngedroht]<=(CONVERT(INT,dbo.fnXConfig('System\Sozialhilfe\KuerzungMaxProzentsatz', GETDATE())))))
GO

ALTER TABLE [dbo].[FaWeisung] CHECK CONSTRAINT [CK_FaWeisung_KuerzungGBAngedroht]
GO

ALTER TABLE [dbo].[FaWeisung]  WITH CHECK ADD  CONSTRAINT [CK_FaWeisung_KuerzungGBVerfuegt] CHECK  (([KuerzungGBVerfuegt]>=(0) AND [KuerzungGBVerfuegt]<=(CONVERT(INT,dbo.fnXConfig('System\Sozialhilfe\KuerzungMaxProzentsatz', GETDATE())))))
GO

ALTER TABLE [dbo].[FaWeisung] CHECK CONSTRAINT [CK_FaWeisung_KuerzungGBVerfuegt]
GO

ALTER TABLE [dbo].[FaWeisung] ADD  CONSTRAINT [DF_FaWeisung_StatusCode]  DEFAULT ((1)) FOR [StatusCode]
GO

ALTER TABLE [dbo].[FaWeisung] ADD  CONSTRAINT [DF_FaWeisung_WeisungsartCode]  DEFAULT ((0)) FOR [WeisungsartCode]
GO

ALTER TABLE [dbo].[FaWeisung] ADD  CONSTRAINT [DF_FaWeisung_KonsequenzCodeAngedroht]  DEFAULT ((0)) FOR [KonsequenzCodeAngedroht]
GO

ALTER TABLE [dbo].[FaWeisung] ADD  CONSTRAINT [DF_FaWeisung_KuerzungGBAngedroht]  DEFAULT ((0)) FOR [KuerzungGBAngedroht]
GO

ALTER TABLE [dbo].[FaWeisung] ADD  CONSTRAINT [DF_FaWeisung_WeisungVerschoben]  DEFAULT ((0)) FOR [WeisungVerschoben]
GO

ALTER TABLE [dbo].[FaWeisung] ADD  CONSTRAINT [DF_FaWeisung_WeisungErfuellt]  DEFAULT ((0)) FOR [WeisungErfuellt]
GO

ALTER TABLE [dbo].[FaWeisung] ADD  CONSTRAINT [DF_FaWeisung_CanDelete]  DEFAULT ((1)) FOR [CanDelete]
GO

ALTER TABLE [dbo].[FaWeisung] ADD  CONSTRAINT [DF_FaWeisung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaWeisung] ADD  CONSTRAINT [DF_FaWeisung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO