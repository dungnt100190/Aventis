CREATE TABLE [dbo].[BaWohnsituation](
	[BaWohnsituationID] [int] IDENTITY(1,1) NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[WohnsituationCode] [int] NOT NULL,
	[WohnungsgroesseCode] [int] NULL,
	[Miete] [money] NULL,
	[Nebenkosten] [money] NULL,
	[MieteAnteil] [money] NULL,
	[NebenkostenAnteil] [money] NULL,
	[BaInstitutionID] [int] NULL,
	[SicherheitsleistungArtCode] [int] NULL,
	[SicherheitsleistungBetrag] [money] NULL,
	[SicherheitsleistungUebernahmeVonCode] [int] NULL,
	[Bemerkung] [text] NULL,
	[BaWohnsituationTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaWohnsituation] PRIMARY KEY CLUSTERED 
(
	[BaWohnsituationID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO


/****** Object:  Index [IX_BaWohnsituation_BaInstitutionID]    Script Date: 03/22/2012 11:09:43 ******/
CREATE NONCLUSTERED INDEX [IX_BaWohnsituation_BaInstitutionID] ON [dbo].[BaWohnsituation] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO


/****** Object:  Index [IX_BaWohnsituation_BaWohnsituationID_DatumVon_Datum_Bis_BaInstitutionID]    Script Date: 03/22/2012 11:09:43 ******/
CREATE NONCLUSTERED INDEX [IX_BaWohnsituation_BaWohnsituationID_DatumVon_Datum_Bis_BaInstitutionID] ON [dbo].[BaWohnsituation] 
(
	[BaWohnsituationID] ASC
)
INCLUDE ( [DatumVon],
[DatumBis],
[BaInstitutionID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BaWohnsituation]  WITH CHECK ADD  CONSTRAINT [FK_BaWohnsituation_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaWohnsituation] CHECK CONSTRAINT [FK_BaWohnsituation_BaInstitution]
GO

