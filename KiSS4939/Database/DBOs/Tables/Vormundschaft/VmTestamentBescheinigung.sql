CREATE TABLE [dbo].[VmTestamentBescheinigung](
	[VmTestamentBescheinigungID] [int] IDENTITY(1,1) NOT NULL,
	[VmTestamentID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[BescheinigungCode] [int] NULL,
	[BescheinigungText] [varchar](150) NULL,
	[BescheinigungDokID] [int] NULL,
	[Gebuehr] [money] NULL,
	[SAPNr] [varchar](10) NULL,
	[Bemerkung] [varchar](max) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmTestamentBescheinigungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmTestamentBescheinigung] PRIMARY KEY CLUSTERED 
(
	[VmTestamentBescheinigungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_VmTestamentBescheinigung_VmTestamentBescheinigungID]    Script Date: 11/17/2010 17:33:23 ******/
CREATE NONCLUSTERED INDEX [IX_VmTestamentBescheinigung_VmTestamentBescheinigungID] ON [dbo].[VmTestamentBescheinigung] 
(
	[VmTestamentBescheinigungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


/****** Object:  Index [IX_VmTestamentBescheinigung_VmTestamentID]    Script Date: 11/17/2010 17:33:23 ******/
CREATE NONCLUSTERED INDEX [IX_VmTestamentBescheinigung_VmTestamentID] ON [dbo].[VmTestamentBescheinigung] 
(
	[VmTestamentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


GO


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmTestamentBescheinigung_VmTestament) => VmTestament.VmTestamentID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestamentBescheinigung', @level2type=N'COLUMN',@level2name=N'VmTestamentID'
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


GO


GO


GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz logisch gelöscht worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestamentBescheinigung', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz anelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestamentBescheinigung', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestamentBescheinigung', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt verändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestamentBescheinigung', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestamentBescheinigung', @level2type=N'COLUMN',@level2name=N'Modified'
GO


GO


GO


GO

ALTER TABLE [dbo].[VmTestamentBescheinigung]  WITH CHECK ADD  CONSTRAINT [FK_VmTestamentBescheinigung_VmTestament] FOREIGN KEY([VmTestamentID])
REFERENCES [dbo].[VmTestament] ([VmTestamentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VmTestamentBescheinigung] CHECK CONSTRAINT [FK_VmTestamentBescheinigung_VmTestament]
GO

ALTER TABLE [dbo].[VmTestamentBescheinigung] ADD  CONSTRAINT [DF_VmTestamentBescheinigung_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmTestamentBescheinigung] ADD  CONSTRAINT [DF_VmTestamentBescheinigung_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmTestamentBescheinigung] ADD  CONSTRAINT [DF_VmTestamentBescheinigung_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


