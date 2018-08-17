CREATE TABLE [dbo].[FaSituationsbeschreibung](
	[FaSituationsbeschreibungID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[UebersichtBeschreibung] [varchar](max) NULL,
	[UebersichtThemen] [varchar](max) NULL,
	[UebersichtStellen] [varchar](max) NULL,
	[UebersichtBemerkungen] [varchar](max) NULL,
	[UebersichtCMUeberpruefen] [bit] NOT NULL,
	[UebersichtDatumMerkblatt] [varchar](max) NULL,
	[LebensbereicheArbeitAusbildung] [varchar](max) NULL,
	[LebensbereicheTagesstruktur] [varchar](max) NULL,
	[LebensbereicheFinanzen] [varchar](max) NULL,
	[LebensbereicheGesundheit] [varchar](max) NULL,
	[LebensbereicheSozialeKontakte] [varchar](max) NULL,
	[LebensbereicheSituationKinder] [varchar](max) NULL,
	[LebensbereicheFreizeit] [varchar](max) NULL,
	[LebensbereicheWohnen] [varchar](max) NULL,
	[LebensbereicheLebensplan] [varchar](max) NULL,
	[LebensbereicheSozialversicherung] [varchar](max) NULL,
	[RessourcenPersoenlich] [varchar](max) NULL,
	[RessourcenSozial] [varchar](max) NULL,
	[RessourcenMateriell] [varchar](max) NULL,
	[RessourcenInstitutionell] [varchar](max) NULL,
	[SichtweisenSA] [varchar](max) NULL,
	[SichtweisenFachstellen] [varchar](max) NULL,
	[SichtweisenKlient] [varchar](max) NULL,
	[SichtweisenBemerkungen] [varchar](max) NULL,
	[LetzteAenderung] [datetime] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[FaSituationsbeschreibungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaSituationsbeschreibung] PRIMARY KEY CLUSTERED 
(
	[FaSituationsbeschreibungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[FaSituationsbeschreibung]  WITH CHECK ADD  CONSTRAINT [FK_FaSituationsbeschreibung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaSituationsbeschreibung] CHECK CONSTRAINT [FK_FaSituationsbeschreibung_BaPerson]
GO

ALTER TABLE [dbo].[FaSituationsbeschreibung] ADD  CONSTRAINT [DF_FaSituationsbeschreibung_UebersichtCMUeberpruefen]  DEFAULT ((0)) FOR [UebersichtCMUeberpruefen]
GO

ALTER TABLE [dbo].[FaSituationsbeschreibung] ADD  CONSTRAINT [DF_FaSituationsbeschreibung_Created]  DEFAULT (getdate()) FOR [Created]
GO