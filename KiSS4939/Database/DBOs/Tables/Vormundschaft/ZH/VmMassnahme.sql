CREATE TABLE [dbo].[VmMassnahme](
	[VmMassnahmeID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[ZGB] [varchar](500) NULL,
	[Mandatstyp] [varchar](500) NULL,
	[Waisenrat] [varchar](255) NULL,
  [IstNeurechtlich] [bit] NOT NULL,
	[VIS_VormschID] [int] NULL,
	[VIS_FallNr] [int] NULL,
	[VIS_ArrangementId] [uniqueidentifier] NULL,
  [VIS_ArrangementId_Neurechtlich] [uniqueidentifier] NULL,
	[VIS_DossierId] [uniqueidentifier] NULL,
	[VmMassnahmeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmMassnahme] PRIMARY KEY CLUSTERED 
(
	[VmMassnahmeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmMassnahme_FaLeistungID]    Script Date: 07/18/2014 13:57:20 ******/
CREATE NONCLUSTERED INDEX [IX_VmMassnahme_FaLeistungID] ON [dbo].[VmMassnahme] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Definiert, ob diese Massnahme neurechtlich ist (Arrangement.IsNewLaw)', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN', @level2name=N'IstNeurechtlich'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf VIS-Massnahme (Arrangement.Id)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN',@level2name=N'VIS_ArrangementId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf neurechtliche VIS-Massnahme', @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN', @level2name=N'VIS_ArrangementId_Neurechtlich'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf VIS-Dossier (Arrangement.DossierId)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN',@level2name=N'VIS_DossierId'
GO

ALTER TABLE [dbo].[VmMassnahme]  WITH CHECK ADD  CONSTRAINT [FK_VmMassnahme_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VmMassnahme] CHECK CONSTRAINT [FK_VmMassnahme_FaLeistung]
GO

ALTER TABLE [dbo].[VmMassnahme] ADD  CONSTRAINT [DF_VmMassnahme_IstNeurechtlich]  DEFAULT ((0)) FOR [IstNeurechtlich]
GO
