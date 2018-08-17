-- =============================================
-- Create Table KaQJPZAssessment
-- =============================================

CREATE TABLE [dbo].[KaQJPZAssessment](
	[KaQJPZAssessmentID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[DatumAssessment] [datetime] NULL,
	[AufgA] [bit] NOT NULL,
	[AufgB] [bit] NOT NULL,
	[AufgC] [bit] NOT NULL,
	[AufgD] [bit] NOT NULL,
	[KandDokIn] [bit] NULL,
	[ProjGefaehrFlag] [bit] NOT NULL,
	[ProjGefaehrGrund] [varchar](max) NULL,
	[NichtAufgFlag] [bit] NOT NULL,
	[NichtAufgGrund] [varchar](max) NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[KaQJPZAssessmentTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaQJPZAssessment] PRIMARY KEY CLUSTERED 
(
	[KaQJPZAssessmentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[KaQJPZAssessment]  WITH CHECK ADD  CONSTRAINT [FK_KaQJPZAssessment_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[KaQJPZAssessment] CHECK CONSTRAINT [FK_KaQJPZAssessment_FaLeistung]
GO

ALTER TABLE [dbo].[KaQJPZAssessment] ADD  CONSTRAINT [DF_KaQJAssessment_AufgA]  DEFAULT ((0)) FOR [AufgA]
GO

ALTER TABLE [dbo].[KaQJPZAssessment] ADD  CONSTRAINT [DF_KaQJAssessment_AufgB]  DEFAULT ((0)) FOR [AufgB]
GO

ALTER TABLE [dbo].[KaQJPZAssessment] ADD  CONSTRAINT [DF_KaQJAssessment_AufgC]  DEFAULT ((0)) FOR [AufgC]
GO

ALTER TABLE [dbo].[KaQJPZAssessment] ADD  CONSTRAINT [DF_KaQJAssessment_AufgD]  DEFAULT ((0)) FOR [AufgD]
GO

ALTER TABLE [dbo].[KaQJPZAssessment] ADD  CONSTRAINT [DF_KaQJAssessment_ProjGefaehrFlag]  DEFAULT ((0)) FOR [ProjGefaehrFlag]
GO

ALTER TABLE [dbo].[KaQJPZAssessment] ADD  CONSTRAINT [DF_KaQJAssessment_NichtAufgFlag]  DEFAULT ((0)) FOR [NichtAufgFlag]
GO

ALTER TABLE [dbo].[KaQJPZAssessment] ADD  CONSTRAINT [DF_KaQJAssessment_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[KaQJPZAssessment] ADD  CONSTRAINT [DF_KaQJAssessment_Modified]  DEFAULT (getdate()) FOR [Modified]
GO
