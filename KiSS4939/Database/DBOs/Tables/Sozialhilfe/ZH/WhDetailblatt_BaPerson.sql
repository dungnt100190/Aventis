CREATE TABLE [dbo].[WhDetailblatt_BaPerson](
	[WhDetailblatt_BaPersonID] [int] IDENTITY(1,1) NOT NULL,
	[WhDetailblattID] [int] NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[Inkl] [bit] NOT NULL,
	[ZusaetzlicheLAs] [varchar](600) NULL,
	[EffektivAbgerechneteLAs] [varchar](max) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[WhDetailblatt_BaPersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_WhDetailblatt_BaPerson] PRIMARY KEY CLUSTERED 
(
	[WhDetailblatt_BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 70) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_WhDetailblatt_BaPerson_BaPersonID]    Script Date: 07/24/2012 15:56:53 ******/
CREATE NONCLUSTERED INDEX [IX_WhDetailblatt_BaPerson_BaPersonID] ON [dbo].[WhDetailblatt_BaPerson] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_WhDetailblatt_BaPerson_WhDetailblattID]    Script Date: 07/24/2012 15:56:53 ******/
CREATE NONCLUSTERED INDEX [IX_WhDetailblatt_BaPerson_WhDetailblattID] ON [dbo].[WhDetailblatt_BaPerson] 
(
	[WhDetailblattID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primaerschluessel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'WhDetailblatt_BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschluessel zu WhDetailblatt' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'WhDetailblattID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschluessel zu BaPerson' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bitfeld Inkl' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'Inkl'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kommaseparierte Liste der zusaetzlichen LAs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'ZusaetzlicheLAs'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Kommaseparierte Liste der effektiv abgerechneten LAs' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'EffektivAbgerechneteLAs'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Zeitstempel' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson', @level2type=N'COLUMN',@level2name=N'WhDetailblatt_BaPersonTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Peter Salajan' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Beinhaltet die WhDetailblatt_BaPerson Records' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'WhDetailblatt_BaPerson'
GO

ALTER TABLE [dbo].[WhDetailblatt_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_WhDetailblatt_BaPerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WhDetailblatt_BaPerson] CHECK CONSTRAINT [FK_WhDetailblatt_BaPerson_BaPerson]
GO

ALTER TABLE [dbo].[WhDetailblatt_BaPerson]  WITH CHECK ADD  CONSTRAINT [FK_WhDetailblatt_BaPerson_WhDetailblatt] FOREIGN KEY([WhDetailblattID])
REFERENCES [dbo].[WhDetailblatt] ([WhDetailblattID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[WhDetailblatt_BaPerson] CHECK CONSTRAINT [FK_WhDetailblatt_BaPerson_WhDetailblatt]
GO

ALTER TABLE [dbo].[WhDetailblatt_BaPerson] ADD  CONSTRAINT [DF_WhDetailblatt_BaPerson_Inkl]  DEFAULT ((1)) FOR [Inkl]
GO

ALTER TABLE [dbo].[WhDetailblatt_BaPerson] ADD  CONSTRAINT [DF_WhDetailblatt_BaPerson_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[WhDetailblatt_BaPerson] ADD  CONSTRAINT [DF_WhDetailblatt_BaPerson_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

