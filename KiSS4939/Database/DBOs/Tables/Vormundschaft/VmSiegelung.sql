CREATE TABLE [dbo].[VmSiegelung](
	[VmSiegelungID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[Gesperrt] [bit] NULL,
	[UserID] [int] NULL,
	[BezirkNr] [int] NULL,
	[LaufNr] [int] NULL,
	[Jahr] [int] NULL,
	[TodesmeldungDatum] [datetime] NULL,
	[SiegelungsDatum] [datetime] NULL,
	[SiegelungsFristEingehalten] [bit] NULL,
	[VersandDatum] [datetime] NULL,
	[KopieErbschaftsdienst] [bit] NULL,
	[KopieTestamentsdienst] [bit] NULL,
	[KopieAndere] [varchar](100) NULL,
	[VerfuegungsSperren] [int] NULL,
	[Durchsuchungen] [int] NULL,
	[PliQuittung] [varchar](50) NULL,
	[GesuchUeBestattung] [bit] NULL,
	[Ausschlagung] [bit] NULL,
	[VmErbschaftInventarCode] [int] NULL,
	[NotarID] [int] NULL,
	[MassaVerwalter] [varchar](100) NULL,
	[EntsiegelungsDatum] [datetime] NULL,
	[OhneGebuehr] [bit] NULL,
	[RechnungsNr] [varchar](50) NULL,
	[RechnungsDatum] [datetime] NULL,
	[RechnungsBetrag] [money] NULL,
	[RechnungAn] [varchar](100) NULL,
	[SiegelungsProtokollDokID] [int] NULL,
	[SDabgeschlossen] [bit] NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmSiegelungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmSiegelung] PRIMARY KEY CLUSTERED 
(
	[VmSiegelungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmSiegelung_FaLeistungID] ON [dbo].[VmSiegelung] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO


CREATE NONCLUSTERED INDEX [IX_VmSiegelung_UserID] ON [dbo].[VmSiegelung] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmSiegelung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSiegelung', @level2type=N'COLUMN',@level2name=N'VmSiegelungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmSiegelung_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSiegelung', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmSiegelung_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSiegelung', @level2type=N'COLUMN',@level2name=N'UserID'
GO

ALTER TABLE [dbo].[VmSiegelung]  WITH CHECK ADD  CONSTRAINT [FK_VmSiegelung_BaInstitution] FOREIGN KEY([NotarID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[VmSiegelung] CHECK CONSTRAINT [FK_VmSiegelung_BaInstitution]
GO

ALTER TABLE [dbo].[VmSiegelung]  WITH CHECK ADD  CONSTRAINT [FK_VmSiegelung_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VmSiegelung] CHECK CONSTRAINT [FK_VmSiegelung_FaLeistung]
GO

ALTER TABLE [dbo].[VmSiegelung]  WITH CHECK ADD  CONSTRAINT [FK_VmSiegelung_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmSiegelung] CHECK CONSTRAINT [FK_VmSiegelung_XUser]
GO

ALTER TABLE [dbo].[VmSiegelung] ADD  CONSTRAINT [DF__VmSiegelu__Gespe__32649BCE]  DEFAULT ((0)) FOR [Gesperrt]
GO