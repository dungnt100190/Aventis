CREATE TABLE [dbo].[BaArbeit](
	[BaArbeitID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[BaInstitutionID] [int] NULL,
	[TypCode] [int] NULL,
	[BaGrundTeilzeitCode] [int] NULL,
	[Pensum] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[Bemerkung] [varchar](MAX) NULL,
	[Adresse] [varchar](MAX) NULL,
	[StellensuchendCode] [int] NULL,
	[BaArbeitTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaArbeit] PRIMARY KEY CLUSTERED 
(
	[BaArbeitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_BaArbeit_BaInstitutionID]    Script Date: 11/23/2011 10:34:30 ******/
CREATE NONCLUSTERED INDEX [IX_BaArbeit_BaInstitutionID] ON [dbo].[BaArbeit] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_BaArbeit_BaPersonID]    Script Date: 11/23/2011 10:34:30 ******/
CREATE NONCLUSTERED INDEX [IX_BaArbeit_BaPersonID] ON [dbo].[BaArbeit] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaArbeit]  WITH CHECK ADD  CONSTRAINT [FK_BaArbeitIntegration_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO
ALTER TABLE [dbo].[BaArbeit] CHECK CONSTRAINT [FK_BaArbeitIntegration_BaInstitution]
GO
ALTER TABLE [dbo].[BaArbeit]  WITH CHECK ADD  CONSTRAINT [FK_BaArbeitIntegration_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BaArbeit] CHECK CONSTRAINT [FK_BaArbeitIntegration_BaPerson]