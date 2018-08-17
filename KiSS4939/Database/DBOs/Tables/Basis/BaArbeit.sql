CREATE TABLE [dbo].[BaArbeit](
	[BaArbeit] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[BaInstitutionID] [int] NULL,
	[TypCode] [int] NULL,
	[PensumCode] [int] NULL,
	[BaSprachniveauCode] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[Adresse] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[BaArbeitTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaArbeitIntegration] PRIMARY KEY CLUSTERED 
(
	[BaArbeit] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS-Description', @value=N'Sprachniveau A1, A2, B1, B2, C1 oder C2.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BaArbeit', @level2type=N'COLUMN',@level2name=N'BaSprachniveauCode'
GO

ALTER TABLE [dbo].[BaArbeit]  WITH CHECK ADD  CONSTRAINT [FK_BaArbeit_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[BaArbeit] CHECK CONSTRAINT [FK_BaArbeit_BaInstitution]
GO

ALTER TABLE [dbo].[BaArbeit] ADD  CONSTRAINT [DF_BaArbeit_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[BaArbeit] ADD  CONSTRAINT [DF_BaArbeit_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
