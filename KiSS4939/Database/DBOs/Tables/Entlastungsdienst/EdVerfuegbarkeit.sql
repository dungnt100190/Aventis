CREATE TABLE [dbo].[EdVerfuegbarkeit](
	[EdVerfuegbarkeitID] [int] IDENTITY(1,1) NOT NULL,
	[EdMitarbeiterID] [int] NOT NULL,
	[GrundangabenFahrausweis] [bit] NOT NULL,
	[GrundangabenEigenesFahrzeug] [bit] NOT NULL,
	[GrundangabenMobilitaetBemerkungen] [varchar](255) NULL,
	[GrundangabenFrequenzCodes] [varchar](100) NULL,
	[GrundangabenKeineEinsatzzeitDefiniert] [bit] NOT NULL,
	[GrundangabenMitarbeitInGruppen] [bit] NOT NULL,
	[GrundangabenBemerkungen] [varchar](max) NULL,
	[EinsatzorteOrtCodes] [varchar](100) NULL,
	[EinsatzorteRegionCodes] [varchar](100) NULL,
	[AktuelleBegleitungen] [varchar](1000) NULL,
	[EhemaligeBegleitungen] [varchar](1000) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[EdVerfuegbarkeitTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdVerfuegbarkeit] PRIMARY KEY CLUSTERED 
(
	[EdVerfuegbarkeitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE UNIQUE NONCLUSTERED INDEX [IX_EdVerfuegbarkeit_EdMitarbeiterID_Unique] ON [dbo].[EdVerfuegbarkeit] 
(
	[EdMitarbeiterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Register Einsatzplanung, Aktuelle Begleitungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdVerfuegbarkeit', @level2type=N'COLUMN',@level2name=N'AktuelleBegleitungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Register Einsatzplanung, Ehemalige Begleitungen' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdVerfuegbarkeit', @level2type=N'COLUMN',@level2name=N'EhemaligeBegleitungen'
GO


ALTER TABLE [dbo].[EdVerfuegbarkeit]  WITH CHECK ADD  CONSTRAINT [FK_EdVerfuegbarkeit_EdMitarbeiter] FOREIGN KEY([EdMitarbeiterID])
REFERENCES [dbo].[EdMitarbeiter] ([EdMitarbeiterID])
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit] CHECK CONSTRAINT [FK_EdVerfuegbarkeit_EdMitarbeiter]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_GrundangabenFahrausweis]  DEFAULT ((0)) FOR [GrundangabenFahrausweis]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_GrundangabenEigenesFahrzeug]  DEFAULT ((0)) FOR [GrundangabenEigenesFahrzeug]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_GrundangabenKeineEinsatzzeitDefiniert]  DEFAULT ((0)) FOR [GrundangabenKeineEinsatzzeitDefiniert]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_GrundangabenMitarbeitInGruppen]  DEFAULT ((0)) FOR [GrundangabenMitarbeitInGruppen]
GO

ALTER TABLE [dbo].[EdVerfuegbarkeit] ADD  CONSTRAINT [DF_EdVerfuegbarkeit_Created]  DEFAULT (getdate()) FOR [Created]
GO