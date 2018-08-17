CREATE TABLE [dbo].[VmMassnahme](
	[VmMassnahmeID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[ZGBCodes] [varchar](50) NULL,
	[WeitereZGB] [varchar](120) NULL,
	[ElterlicheSorgeCode] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmMassnahmeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmMassnahme] PRIMARY KEY CLUSTERED 
(
	[VmMassnahmeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmMassnahme_FaLeistungID]    Script Date: 11/17/2010 14:53:53 ******/
CREATE NONCLUSTERED INDEX [IX_VmMassnahme_FaLeistungID] ON [dbo].[VmMassnahme] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmMassnahme Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN',@level2name=N'VmMassnahmeID'
GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmMassnahme_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz logisch gelöscht worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt modifiziert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt modifiziert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmMassnahme', @level2type=N'COLUMN',@level2name=N'Modified'
GO


GO


GO


GO

ALTER TABLE [dbo].[VmMassnahme]  WITH CHECK ADD  CONSTRAINT [FK_VmMassnahme_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmMassnahme] CHECK CONSTRAINT [FK_VmMassnahme_FaLeistung]
GO

ALTER TABLE [dbo].[VmMassnahme] ADD  CONSTRAINT [DF_VmMassnahme_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmMassnahme] ADD  CONSTRAINT [DF_VmMassnahme_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmMassnahme] ADD  CONSTRAINT [DF_VmMassnahme_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


