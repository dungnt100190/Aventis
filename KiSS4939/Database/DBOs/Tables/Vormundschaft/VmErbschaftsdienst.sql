CREATE TABLE [dbo].[VmErbschaftsdienst](
	[VmErbschaftsdienstID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[LaufNr] [int] NULL,
	[Jahr] [int] NULL,
	[MassnahmenCodes] [varchar](200) NULL,
	[AnschriftErbenDokID] [int] NULL,
	[AnschriftErbenDatum] [datetime] NULL,
	[InventarCode] [int] NULL,
	[InventarNotarID] [int] NULL,
	[Aktiv] [bit] NULL,
	[VertretungsBeistandschaft] [bit] NULL,
	[Ausschlagung] [bit] NULL,
	[El] [bit] NULL,
	[KopieAnCodes] [varchar](20) NULL,
	[UeberweisungRSTADokID] [int] NULL,
	[UeberweisungRSTA] [datetime] NULL,
	[Massnahme] [varchar](max) NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmErbschaftsdienstTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmErbschaftsdienst] PRIMARY KEY CLUSTERED 
(
	[VmErbschaftsdienstID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmErbschaftsdienst_FaLeistungID] ON [dbo].[VmErbschaftsdienst] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO


CREATE NONCLUSTERED INDEX [IX_VmErbschaftsdienst_UserID] ON [dbo].[VmErbschaftsdienst] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmErbschaftsdienst Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmErbschaftsdienst', @level2type=N'COLUMN',@level2name=N'VmErbschaftsdienstID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmErbschaftsdienst_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmErbschaftsdienst', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmErbschaftsdienst_XUser) => XUser.UserID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmErbschaftsdienst', @level2type=N'COLUMN',@level2name=N'UserID'
GO

ALTER TABLE [dbo].[VmErbschaftsdienst]  WITH CHECK ADD  CONSTRAINT [FK_VmErbschaftsdienst_BaInstitution] FOREIGN KEY([InventarNotarID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO

ALTER TABLE [dbo].[VmErbschaftsdienst] CHECK CONSTRAINT [FK_VmErbschaftsdienst_BaInstitution]
GO

ALTER TABLE [dbo].[VmErbschaftsdienst]  WITH CHECK ADD  CONSTRAINT [FK_VmErbschaftsdienst_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VmErbschaftsdienst] CHECK CONSTRAINT [FK_VmErbschaftsdienst_FaLeistung]
GO

ALTER TABLE [dbo].[VmErbschaftsdienst]  WITH CHECK ADD  CONSTRAINT [FK_VmErbschaftsdienst_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[VmErbschaftsdienst] CHECK CONSTRAINT [FK_VmErbschaftsdienst_XUser]
GO