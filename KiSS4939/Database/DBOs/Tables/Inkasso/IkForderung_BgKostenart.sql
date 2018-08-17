CREATE TABLE [dbo].[IkForderung_BgKostenart](
	[IkForderung_BgKostenartID] [int] IDENTITY(1,1) NOT NULL,
	[BgKostenartID_Auszahlung] [int] NOT NULL,
	[BgKostenartID_Forderung] [int] NOT NULL,
	[IkForderungEinmaligCode] [int] NULL,
	[IkForderungPeriodischCode] [int] NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[IkForderung_BgKostenartTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_IkForderung_BgKostenart] PRIMARY KEY CLUSTERED 
(
	[IkForderung_BgKostenartID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel der Tabelle IkForderung_BgKostenart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'IkForderung_BgKostenartID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Auszahlungskostenart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'BgKostenartID_Auszahlung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel der Auszahlungskostenart' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'BgKostenartID_Forderung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code in der LOV IkForedungEinmalig' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'IkForderungEinmaligCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code in der LOV IkForedungPeriodisch' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'IkForderungPeriodischCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'COLUMN',@level2name=N'IkForderung_BgKostenartTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Nicolas Weber' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tabelle um die Kostenarten die Auszahlungen generieren zu handeln' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart'
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart]  WITH CHECK ADD  CONSTRAINT [FK_IkForderung_BgKostenart_BgKostenart_Auszahlung] FOREIGN KEY([BgKostenartID_Auszahlung])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart] CHECK CONSTRAINT [FK_IkForderung_BgKostenart_BgKostenart_Auszahlung]
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart]  WITH CHECK ADD  CONSTRAINT [FK_IkForderung_BgKostenart_BgKostenart_Forderung] FOREIGN KEY([BgKostenartID_Forderung])
REFERENCES [dbo].[BgKostenart] ([BgKostenartID])
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart] CHECK CONSTRAINT [FK_IkForderung_BgKostenart_BgKostenart_Forderung]
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart]  WITH NOCHECK ADD  CONSTRAINT [CK_IkForderung_BgKostenart_DataIntegrity] CHECK  (([dbo].[fnIkCKIkForderung_BgKostenartIntegrity]([IkForderung_BgKostenartID])=(0)))
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart] CHECK CONSTRAINT [CK_IkForderung_BgKostenart_DataIntegrity]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Checks for valid IkForderung_BgKostenart records' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'IkForderung_BgKostenart', @level2type=N'CONSTRAINT',@level2name=N'CK_IkForderung_BgKostenart_DataIntegrity'
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart]  WITH CHECK ADD  CONSTRAINT [CK_IkForderung_IkForderungCode] CHECK  (([IkForderungEinmaligCode] IS NOT NULL OR [IkForderungPeriodischCode] IS NOT NULL))
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart] CHECK CONSTRAINT [CK_IkForderung_IkForderungCode]
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart] ADD  CONSTRAINT [DF_IkForderung_BgKostenart_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[IkForderung_BgKostenart] ADD  CONSTRAINT [DF_IkForderung_BgKostenart_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


