CREATE TABLE [dbo].[VmBericht](
	[VmBerichtID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BerichtsperiodeVon] [datetime] NULL,
	[BerichtsperiodeBis] [datetime] NULL,
	[Erstellung] [datetime] NULL,
	[Mahnung] [datetime] NULL,
	[Mahnung2] [datetime] NULL,
	[Passation1] [datetime] NULL,
	[Passation2] [datetime] NULL,
	[Versand] [datetime] NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmBerichtTS] [timestamp] NOT NULL,
	[Entschaedigung] [money] NULL,
 CONSTRAINT [PK_VmBericht] PRIMARY KEY CLUSTERED 
(
	[VmBerichtID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmBericht_FaLeistungID] ON [dbo].[VmBericht] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmBericht Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBericht', @level2type=N'COLUMN',@level2name=N'VmBerichtID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmBericht_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmBericht', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[VmBericht]  WITH CHECK ADD  CONSTRAINT [FK_VmBericht_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmBericht] CHECK CONSTRAINT [FK_VmBericht_FaLeistung]
GO