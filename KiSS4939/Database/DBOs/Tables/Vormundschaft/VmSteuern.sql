CREATE TABLE [dbo].[VmSteuern](
	[VmSteuernID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[DocumentID] [int] NULL,
	[SteuerJahr] [int] NULL,
	[SteuererklaerungExternErledigt] [bit] NOT NULL,
	[SteuererklaerungInternErledigt] [bit] NOT NULL,
	[ErledigungDurch] [varchar](255) NULL,
	[SteuererklaerungEingereicht] [datetime] NULL,
	[Artikel41] [bit] NOT NULL,
	[FristverlaengerungBeantragt] [datetime] NULL,
	[EingangDefVeranlagung] [datetime] NULL,
	[DatumEntscheidErlass] [datetime] NULL,
	[Erlass] [bit] NOT NULL,
	[Teilerlass] [bit] NOT NULL,
	[Abelehnt] [bit] NOT NULL,
	[Bemerkungen] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmSteuernTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmSteuern] PRIMARY KEY CLUSTERED 
(
	[VmSteuernID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel von VmSteuern' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'VmSteuernID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XDokument für das Korrespondenz-Dokument' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Das Steuerjahr' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'SteuerJahr'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Steuererklärung extern erledigt ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'SteuererklaerungExternErledigt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Steuererklärung intern erledigt ist' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'SteuererklaerungInternErledigt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer die Steuererklärung erledigt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'ErledigungDurch'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann die Steuererklärung eingereicht wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'SteuererklaerungEingereicht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob Artikel 41 ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'Artikel41'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum der Beantragung einer Fristverlängerung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'FristverlaengerungBeantragt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Eingangs der definitiven Veranlagung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'EingangDefVeranlagung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum des Entscheids eines Steuererlasses' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'DatumEntscheidErlass'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Steuern erlassen werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'Erlass'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Steuern teilweise erlassen werden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'Teilerlass'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob die Steuern nicht erlassen werden (abgelehnt)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'Abelehnt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zusätzliche Bemerkungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz logisch gelöscht ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz  erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern', @level2type=N'COLUMN',@level2name=N'VmSteuernTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Christoph Jäggi' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vormundschaftliche Massnahme - Administration - Steuern' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSteuern'
GO

ALTER TABLE [dbo].[VmSteuern]  WITH CHECK ADD  CONSTRAINT [FK_VmSteuern_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmSteuern] CHECK CONSTRAINT [FK_VmSteuern_FaLeistung]
GO

ALTER TABLE [dbo].[VmSteuern] ADD  CONSTRAINT [DF_VmSteuern_SteuererklaerungExternErledigt]  DEFAULT ((0)) FOR [SteuererklaerungExternErledigt]
GO

ALTER TABLE [dbo].[VmSteuern] ADD  CONSTRAINT [DF_VmSteuern_SteuererklaerungInternErledigt]  DEFAULT ((0)) FOR [SteuererklaerungInternErledigt]
GO

ALTER TABLE [dbo].[VmSteuern] ADD  CONSTRAINT [DF_VmSteuern_Artikel41]  DEFAULT ((0)) FOR [Artikel41]
GO

ALTER TABLE [dbo].[VmSteuern] ADD  CONSTRAINT [DF_VmSteuern_Erlass]  DEFAULT ((0)) FOR [Erlass]
GO

ALTER TABLE [dbo].[VmSteuern] ADD  CONSTRAINT [DF_VmSteuern_Teilerlass]  DEFAULT ((0)) FOR [Teilerlass]
GO

ALTER TABLE [dbo].[VmSteuern] ADD  CONSTRAINT [DF_VmSteuern_Abelehnt]  DEFAULT ((0)) FOR [Abelehnt]
GO

ALTER TABLE [dbo].[VmSteuern] ADD  CONSTRAINT [DF_VmSteuern_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmSteuern] ADD  CONSTRAINT [DF_VmSteuern_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmSteuern] ADD  CONSTRAINT [DF_VmSteuern_Modified]  DEFAULT (getdate()) FOR [Modified]
GO