CREATE TABLE [dbo].[KaQEEPQ](
	[KaQEEPQID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[XDocumentID_Standortbestimmung1] [int] NULL,
	[XDocumentID_Standortbestimmung2] [int] NULL,
	[XDocumentID_Vorstellungsgespraech] [int] NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[StaoDat] [datetime] NULL,
	[TaetigProgrammDokID] [int] NULL,
	[PersonalblattDokID] [int] NULL,
	[ZwBericht1DokID] [int] NULL,
	[ZwBericht2DokID] [int] NULL,
	[VerlaengerungFlag] [bit] NOT NULL,
	[VerlaengerungDat] [datetime] NULL,
	[Schlussbericht1DokID] [int] NULL,
	[Schlussbericht2DokID] [int] NULL,
	[ArbeitszeugnisDokID] [int] NULL,
	[ZwischenzeugnisDokID] [int] NULL,
	[EinladungDat1] [datetime] NULL,
	[EinladungDat2] [datetime] NULL,
	[Einladung1DokID] [int] NULL,
	[Einladung2DokID] [int] NULL,
	[IntakeCodes] [varchar](255) NULL,
	[ProgBeginn] [bit] NULL,
	[RueckanwortDokID] [int] NULL,
	[EinladungProgBeginn1DokID] [int] NULL,
	[EinladungProgBeginn2DokID] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[IndivZieleRAV] [varchar](max) NULL,
	[IndivZieleRAVDokID] [int] NULL,
	[IndivZieleRAVVerl] [varchar](max) NULL,
	[IndivZieleRAVVerlDokID] [int] NULL,
	[AustrittDatum] [datetime] NULL,
	[AustrittGrund] [int] NULL,
	[AustrittCode] [int] NULL,
	[AustrittBemerkung] [varchar](max) NULL,
	[muendAuffordDat1] [datetime] NULL,
	[muendAuffordDat2] [datetime] NULL,
	[muendAuffordBem1] [varchar](max) NULL,
	[muendAuffordBem2] [varchar](max) NULL,
	[Aufforderung1DokID] [int] NULL,
	[Aufforderung2DokID] [int] NULL,
	[Aufforderung3DokID] [int] NULL,
	[Vereinbarung1DokID] [int] NULL,
	[Vereinbarung2DokID] [int] NULL,
	[ProgAbbruchDokID] [int] NULL,
	[VerlaengerungDokID] [int] NULL,
	[VerwRegelverstossDokID] [int] NULL,
	[VerwNichterscheinenDokID] [int] NULL,
	[KaQEEPQTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQEEPQ] PRIMARY KEY CLUSTERED 
(
	[KaQEEPQID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_KaQEEPQ_FaLeistungID] ON [dbo].[KaQEEPQ] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQEEPQ Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQ', @level2type=N'COLUMN',@level2name=N'KaQEEPQID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQEEPQ_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQ', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des ersten Dokuments für die Standortbestimmung (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQ', @level2type=N'COLUMN',@level2name=N'XDocumentID_Standortbestimmung1'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des zweiten Dokuments für die Standortbestimmung (Prozessübersicht)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQ', @level2type=N'COLUMN',@level2name=N'XDocumentID_Standortbestimmung2'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID des Dokuments für das Vorstellungsgespräch (Intake)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQ', @level2type=N'COLUMN',@level2name=N'XDocumentID_Vorstellungsgespraech'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Leonhard Greulich' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQ'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Enthält die Daten für KA - Qualifizierung Erwachsene - EPQ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQEEPQ'
GO

ALTER TABLE [dbo].[KaQEEPQ]  WITH CHECK ADD  CONSTRAINT [FK_KaQEEPQ_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQEEPQ] CHECK CONSTRAINT [FK_KaQEEPQ_FaLeistung]
GO

ALTER TABLE [dbo].[KaQEEPQ] ADD  CONSTRAINT [DF_KaQEEPQ_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaQEEPQ] ADD  CONSTRAINT [DF_KaQEEPQ_VerlaengerungFlag]  DEFAULT ((0)) FOR [VerlaengerungFlag]
GO