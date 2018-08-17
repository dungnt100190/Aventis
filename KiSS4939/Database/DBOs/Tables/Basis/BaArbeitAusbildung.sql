CREATE TABLE [dbo].[BaArbeitAusbildung](
	[BaPersonID] [int] NOT NULL,
	[ErwerbssituationStatus1Code] [int] NULL,
	[ErwerbssituationStatus2Code] [int] NULL,
	[ErwerbssituationStatus3Code] [int] NULL,
	[ErwerbssituationStatus4Code] [int] NULL,
	[BeschaeftigungsGradCode] [int] NULL,
	[GrundTeilzeitarbeit1Code] [int] NULL,
	[GrundTeilzeitarbeit2Code] [int] NULL,
	[BrancheCode] [int] NULL,
	[ErlernterBerufCode] [int] NULL,
	[BerufCode] [int] NULL,
	[BaInstitutionID] [int] NULL,
	[HoechsteAusbildungCode] [int] NULL,
	[AbgebrochenAusbildungCode] [int] NULL,
	[AnstellungCode] [int] NULL,
	[Arbeitszeit] [numeric](2, 0) NULL,
	[IsVariableArbeitszeit] [bit] NOT NULL,
	[StempelDatum] [datetime] NULL,
	[WieOftArbeitslos] [int] NULL,
	[AusgesteuertUnbekanntCode] [int] NULL,
	[AusgesteuertDatum] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[BaArbeitAusbildungTS] [timestamp] NOT NULL,
	[IntegrationsstandCode] [int] NULL,
	[FinanziellUnabhaengig] [bit] NOT NULL,
 CONSTRAINT [PK_BaArbeitAusbildung] PRIMARY KEY CLUSTERED 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_BaArbeitAusbildung_BaInstitutionID] ON [dbo].[BaArbeitAusbildung] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für BaArbeitAusbildung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaArbeitAusbildung', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_BaArbeitAusbildung_BaInstitution) => BaInstitution.BaInstitutionID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaArbeitAusbildung', @level2type=N'COLUMN',@level2name=N'BaInstitutionID'
GO

ALTER TABLE [dbo].[BaArbeitAusbildung]  WITH CHECK ADD  CONSTRAINT [FK_BaArbeitAusbildung_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaArbeitAusbildung] CHECK CONSTRAINT [FK_BaArbeitAusbildung_BaInstitution]
GO

ALTER TABLE [dbo].[BaArbeitAusbildung]  WITH CHECK ADD  CONSTRAINT [FK_BaArbeitAusbildung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[BaArbeitAusbildung] CHECK CONSTRAINT [FK_BaArbeitAusbildung_BaPerson]
GO

ALTER TABLE [dbo].[BaArbeitAusbildung] ADD  CONSTRAINT [DF_BaArbeitAusbildung_IsVariableArbeitszeit]  DEFAULT ((0)) FOR [IsVariableArbeitszeit]
GO

ALTER TABLE [dbo].[BaArbeitAusbildung] ADD  CONSTRAINT [DF_BaArbeitAusbildung_FinanziellUnabhaengig]  DEFAULT ((0)) FOR [FinanziellUnabhaengig]
GO