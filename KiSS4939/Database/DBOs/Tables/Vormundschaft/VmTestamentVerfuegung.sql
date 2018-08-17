CREATE TABLE [dbo].[VmTestamentVerfuegung](
	[VmTestamentVerfuegungID] [int] IDENTITY(1,1) NOT NULL,
	[VmTestamentID] [int] NOT NULL,
	[EingangsDatum] [datetime] NOT NULL,
	[VerfuegungsDatum] [datetime] NULL,
	[EroeffnungsDatum] [datetime] NULL,
	[VerfuegungText] [varchar](max) NULL,
	[Verschlossen] [bit] NULL,
	[TestamentsformCode] [int] NULL,
	[AnzSeiten] [int] NULL,
	[AufbewahrungsOrt] [int] NULL,
	[ABOvorherCode] [int] NULL,
	[ABOvorherText] [varchar](100) NULL,
	[ABOnachherCode] [int] NULL,
	[ABOnachherText] [varchar](100) NULL,
	[InventarCode] [int] NULL,
	[Bemerkung] [varchar](max) NULL,
	[VmTestamentVerfuegungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmTestamentVerfuegung] PRIMARY KEY CLUSTERED 
(
	[VmTestamentVerfuegungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
) ON [DATEN1]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_VmTestamentVerfuegung_VmTestamentID] ON [dbo].[VmTestamentVerfuegung] 
(
	[VmTestamentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel für VmTestamentVerfuegung Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestamentVerfuegung', @level2type=N'COLUMN',@level2name=N'VmTestamentVerfuegungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_VmTestamentVerfuegung_VmTestament) => VmTestament.VmTestamentID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmTestamentVerfuegung', @level2type=N'COLUMN',@level2name=N'VmTestamentID'
GO

ALTER TABLE [dbo].[VmTestamentVerfuegung]  WITH CHECK ADD  CONSTRAINT [FK_VmTestamentVerfuegung_VmTestament] FOREIGN KEY([VmTestamentID])
REFERENCES [dbo].[VmTestament] ([VmTestamentID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO

ALTER TABLE [dbo].[VmTestamentVerfuegung] CHECK CONSTRAINT [FK_VmTestamentVerfuegung_VmTestament]
GO