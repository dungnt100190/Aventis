CREATE TABLE [dbo].[VmBericht](
	[VmBerichtID] [int] IDENTITY(1,1) NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[DatumBerichtMT] [datetime] NULL,
	[DatumVersandAnVB] [datetime] NULL,
	[DatumGenehmigung1] [datetime] NULL,
	[DatumGenehmigung2] [datetime] NULL,
	[Bemerkung] [text] NULL,
	[VmBerichtTS] [timestamp] NOT NULL,
	[BetragSpesen] [money] NULL,
	[DatumEingangSDS] [datetime] NULL,
	[DatumAusgangSDS] [datetime] NULL,
	[DatumFristerstreckung] [datetime] NULL,
	[DocumentID] [int] NULL,
	[DatumBerichtsTermin] [datetime] NULL,
	[Berichtsart] [varchar](50) NULL,
	[DatumMahnung1] [datetime] NULL,
	[DatumMahnung2] [datetime] NULL,
	[DatumMahnung3] [datetime] NULL,
	[MandatsTraegerName] [varchar](100) NULL,
	[MAKlibuUserID] [int] NULL,
	[VIS_BK_ID] [uniqueidentifier] NULL,
	[VmMassnahmeID] [int] NOT NULL,
	[VermoegensabrechnungDocumentID] [int] NULL,
	[VIS_MandateId] [uniqueidentifier] NULL,
	[IstAktiv] [bit] NOT NULL,
	[VIS_Berichtsnummer] [int] NULL,
 CONSTRAINT [PK_VmBericht] PRIMARY KEY CLUSTERED 
(
	[VmBerichtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK zum VIS-Bericht. Dieser FK ist bei den migrierten Berichten NULL, wenn sie keinem VIS-Bericht zugeordnet werden konnten bei der Migration.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBericht', @level2type=N'COLUMN',@level2name=N'VIS_BK_ID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'FK zur KiSS-Massnahme. ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBericht', @level2type=N'COLUMN',@level2name=N'VmMassnahmeID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf VIS-Mandatsträger' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBericht', @level2type=N'COLUMN',@level2name=N'VIS_MandateId'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag zum wissen ob es der aktiven Bericht eines Mandats ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBericht', @level2type=N'COLUMN',@level2name=N'IstAktiv'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'VIS-Berichtsnummer (früher MAND_ID)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBericht', @level2type=N'COLUMN',@level2name=N'VIS_Berichtsnummer'
GO

ALTER TABLE [dbo].[VmBericht]  WITH CHECK ADD  CONSTRAINT [FK_VmBericht_VmMassnahmeID] FOREIGN KEY([VmMassnahmeID])
REFERENCES [dbo].[VmMassnahme] ([VmMassnahmeID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VmBericht] CHECK CONSTRAINT [FK_VmBericht_VmMassnahmeID]
GO

ALTER TABLE [dbo].[VmBericht] ADD  DEFAULT ((0)) FOR [IstAktiv]
GO


