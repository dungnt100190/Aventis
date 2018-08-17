CREATE TABLE [dbo].[VmVaterschaft](
	[VmVaterschaftID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[ZGBCodes] [varchar](50) NULL,
	[AnerkennungDatum] [datetime] NULL,
	[AnerkennungOrt] [varchar](100) NULL,
	[UHVDatum] [datetime] NULL,
	[UHVBetrag] [money] NULL,
	[UHVAbschlussGrundCode] [int] NULL,
	[SorgerechtVereinbDatum] [datetime] NULL,
	[VAnfechtungsurteil] [datetime] NULL,
	[VUrteilDatum] [datetime] NULL,
	[VUrteilBetrag] [money] NULL,
	[UnterhaltsurteilDatum] [datetime] NULL,
	[UnterhaltsurteilBetrag] [money] NULL,
	[SchlussberichtAnKommission] [datetime] NULL,
	[SchlussberichtGenehmigung] [datetime] NULL,
	[GeburtsmitteilungDatum] [datetime] NULL,
	[GeburtsmitteilungOrt] [varchar](100) NULL,
	[GebuehrDatum] [datetime] NULL,
	[GebuehrErlass] [bit] NULL,
	[PendenzText] [varchar](250) NULL,
	[PendenzFrist] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmVaterschaftTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmVaterschaft] PRIMARY KEY CLUSTERED 
(
	[VmVaterschaftID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmVaterschaft_FaLeistungID] ON [dbo].[VmVaterschaft] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmVaterschaft Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmVaterschaft', @level2type=N'COLUMN',@level2name=N'VmVaterschaftID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmVaterschaft_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmVaterschaft', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[VmVaterschaft]  WITH CHECK ADD  CONSTRAINT [FK_VmVaterschaft_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmVaterschaft] CHECK CONSTRAINT [FK_VmVaterschaft_FaLeistung]
GO