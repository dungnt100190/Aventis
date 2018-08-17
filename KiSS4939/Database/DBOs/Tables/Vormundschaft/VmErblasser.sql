CREATE TABLE [dbo].[VmErblasser](
	[VmErblasserID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[TodesDatum] [datetime] NULL,
	[TodesDatumText] [varchar](50) NULL,
	[TodesOrt] [varchar](50) NULL,
	[AHVNummer] [varchar](16) NULL,
	[Anrede] [varchar](10) NULL,
	[FamilienNamen] [varchar](100) NOT NULL,
	[LedigName] [varchar](50) NULL,
	[Vornamen] [varchar](100) NOT NULL,
	[Elternnamen] [varchar](100) NULL,
	[Zivilstand] [varchar](100) NULL,
	[ZivilstandCode] [int] NULL,
	[Geburtsdatum] [varchar](20) NULL,
	[Heimatorte] [varchar](150) NULL,
	[Strasse] [varchar](100) NULL,
	[Ort] [varchar](80) NULL,
	[Aufenthalt] [varchar](100) NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmErblasserTS] [timestamp] NOT NULL,
	[Versichertennummer] [varchar](18) NULL,
 CONSTRAINT [PK_VmErblasser] PRIMARY KEY CLUSTERED 
(
	[VmErblasserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmErblasser_FaLeistungID] ON [dbo].[VmErblasser] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmErblasser Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmErblasser', @level2type=N'COLUMN',@level2name=N'VmErblasserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmErblasser_FaLeistung) => FaLeistung.FaLeistungID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmErblasser', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

ALTER TABLE [dbo].[VmErblasser]  WITH CHECK ADD  CONSTRAINT [FK_VmErblasser_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VmErblasser] CHECK CONSTRAINT [FK_VmErblasser_FaLeistung]
GO