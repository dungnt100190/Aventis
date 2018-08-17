CREATE TABLE [dbo].[VmTestament](
	[VmTestamentID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[LaufNr] [int] NULL,
	[UserID] [int] NULL,
	[KopieAnCodes] [varchar](20) NULL,
	[ZeugnisseCodes] [varchar](20) NULL,
	[EroeffnungsRechnungBetrag] [money] NULL,
	[EroeffnungsRechnungSAPNr] [varchar](10) NULL,
	[ZusatzRechnungBetrag] [money] NULL,
	[ZusatzRechnungSAPNr] [varchar](10) NULL,
	[EroeffnungDokID] [int] NULL,
	[EroeffnungAuszugDokID] [int] NULL,
	[EroeffnungAdressenDokID] [int] NULL,
	[EroeffnungAbgeschlossenDatum] [datetime] NULL,
	[PublikationFrist] [datetime] NULL,
	[PublikationDatum] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmTestamentTS] [timestamp] NOT NULL,
	[NotarID] [int] NULL,
	[Jahr] [int] NULL,
 CONSTRAINT [PK_VmTestament] PRIMARY KEY CLUSTERED 
(
	[VmTestamentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmTestament_FaLeistungID] ON [dbo].[VmTestament] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_VmTestament_UserID] ON [dbo].[VmTestament] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmTestament Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestament', @level2type=N'COLUMN',@level2name=N'VmTestamentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmTestament_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestament', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmTestament_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestament', @level2type=N'COLUMN',@level2name=N'UserID'
GO

ALTER TABLE [dbo].[VmTestament]  WITH CHECK ADD  CONSTRAINT [FK_VmTestament_BaInstitution] FOREIGN KEY([NotarID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[VmTestament] CHECK CONSTRAINT [FK_VmTestament_BaInstitution]
GO

ALTER TABLE [dbo].[VmTestament]  WITH CHECK ADD  CONSTRAINT [FK_VmTestament_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmTestament] CHECK CONSTRAINT [FK_VmTestament_FaLeistung]
GO

ALTER TABLE [dbo].[VmTestament]  WITH CHECK ADD  CONSTRAINT [FK_VmTestament_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmTestament] CHECK CONSTRAINT [FK_VmTestament_XUser]
GO