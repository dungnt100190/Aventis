CREATE TABLE [dbo].[KaQJIntake](
	[KaQJIntakeID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[ZuweiserID] [int] NULL,
	[ZuteilungCode] [int] NULL,
	[WerkstattCode] [int] NULL,
	[ExternFlag] [bit] NOT NULL,
	[Eintritt] [varchar](100) NULL,
	[WartelisteCode] [int] NULL,
	[KaQjIntakeSpracheCode_Hauptsprache] [int] NULL,
	[KaQjIntakeSpracheCode_Erstsprache] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[AbgemeldetALVFlag] [bit] NULL,
	[NichtErschFlag] [bit] NULL,
	[GesprStattgefFlag] [bit] NULL,
	[DocumentID_Intakegespraech] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaQJIntakeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJIntake] PRIMARY KEY CLUSTERED 
(
	[KaQJIntakeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KaQJIntake_FaLeistungID] ON [dbo].[KaQJIntake] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für KaQJIntake Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntake', @level2type=N'COLUMN',@level2name=N'KaQJIntakeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaQJIntake_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaQJIntake', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[KaQJIntake]  WITH CHECK ADD  CONSTRAINT [FK_KaQJIntake_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaQJIntake] CHECK CONSTRAINT [FK_KaQJIntake_FaLeistung]
GO

ALTER TABLE [dbo].[KaQJIntake] ADD  CONSTRAINT [DF_KaQJIntake_ExternFlag]  DEFAULT ((0)) FOR [ExternFlag]
GO

ALTER TABLE [dbo].[KaQJIntake] ADD  CONSTRAINT [DF_KaQJIntake_SichtbarSDFlag]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO

ALTER TABLE [dbo].[KaQJIntake] ADD  CONSTRAINT [DF_KaQJIntake_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaQJIntake] ADD  CONSTRAINT [DF_KaQJIntake_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
