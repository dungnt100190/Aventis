CREATE TABLE [dbo].[GvFonds_XOrgUnit](
	[GvFonds_XOrgUnitID] [int] IDENTITY(1,1) NOT NULL,
	[GvFondsID] [int] NOT NULL,
	[OrgUnitID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[GvFonds_XOrgUnitTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_GvFonds_XOrgUnit] PRIMARY KEY CLUSTERED 
(
	[GvFonds_XOrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_GvFonds_XOrgUnit_GvFondsID]    Script Date: 07/09/2012 08:06:50 ******/
CREATE NONCLUSTERED INDEX [IX_GvFonds_XOrgUnit_GvFondsID] ON [dbo].[GvFonds_XOrgUnit] 
(
	[GvFondsID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_GvFonds_XOrgUnit_OrgUnitID]    Script Date: 07/09/2012 08:06:50 ******/
CREATE NONCLUSTERED INDEX [IX_GvFonds_XOrgUnit_OrgUnitID] ON [dbo].[GvFonds_XOrgUnit] 
(
	[OrgUnitID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu GvFonds Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds_XOrgUnit', @level2type=N'COLUMN',@level2name=N'GvFondsID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel zu XOrgUnit Tabelle' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds_XOrgUnit', @level2type=N'COLUMN',@level2name=N'OrgUnitID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitstempfel für das Erstellen des Records' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds_XOrgUnit', @level2type=N'COLUMN',@level2name=N'GvFonds_XOrgUnitTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'André Wittwer' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds_XOrgUnit'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zwischentabelle für GvFonds sowie XOrgUnit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'GvFonds_XOrgUnit'
GO

ALTER TABLE [dbo].[GvFonds_XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_GvFonds_XOrgUnit_GvFonds] FOREIGN KEY([GvFondsID])
REFERENCES [dbo].[GvFonds] ([GvFondsID])
GO

ALTER TABLE [dbo].[GvFonds_XOrgUnit] CHECK CONSTRAINT [FK_GvFonds_XOrgUnit_GvFonds]
GO

ALTER TABLE [dbo].[GvFonds_XOrgUnit]  WITH CHECK ADD  CONSTRAINT [FK_GvFonds_XOrgUnit_XOrgUnit] FOREIGN KEY([OrgUnitID])
REFERENCES [dbo].[XOrgUnit] ([OrgUnitID])
GO

ALTER TABLE [dbo].[GvFonds_XOrgUnit] CHECK CONSTRAINT [FK_GvFonds_XOrgUnit_XOrgUnit]
GO

ALTER TABLE [dbo].[GvFonds_XOrgUnit] ADD  CONSTRAINT [DF_GvFonds_XOrgUnit_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[GvFonds_XOrgUnit] ADD  CONSTRAINT [DF_GvFonds_XOrgUnit_Modified]  DEFAULT (getdate()) FOR [Modified]
GO