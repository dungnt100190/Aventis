CREATE TABLE [dbo].[VmSchulden](
	[VmSchuldenID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[VmSchuldtitelCode] [int] NULL,
	[Datum] [datetime] NULL,
	[Betrag] [money] NULL,
	[TilgungDatum] [datetime] NULL,
	[DocumentID] [int] NULL,
	[Bemerkungen] [varchar](200) NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[VmSchuldenTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_VmSchulden] PRIMARY KEY CLUSTERED 
(
	[VmSchuldenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel von VmSchulden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'VmSchuldenID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf die Leistung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Schuldtitel. Beispiele: Verlustschein, Darlehensvertrag, Hypothek' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'VmSchuldtitelCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Datum' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripton', @value=N'Betrag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'Betrag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripton', @value=N'Wann die Schulden getilgt worden sind.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'TilgungDatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Descripton', @value=N'Dokument Id des physikalischen Dokumentes.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'DocumentID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen zu den Schulden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz logisch gelöscht ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz  erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde ' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt geändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für optimistic Locking' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden', @level2type=N'COLUMN',@level2name=N'VmSchuldenTS'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Vormundschaftliche Massnahme - Finanzen - Schulden' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'VmSchulden'
GO

ALTER TABLE [dbo].[VmSchulden]  WITH CHECK ADD  CONSTRAINT [FK_VmSchulden_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[VmSchulden] CHECK CONSTRAINT [FK_VmSchulden_FaLeistung]
GO

ALTER TABLE [dbo].[VmSchulden] ADD  CONSTRAINT [DF_VmSchulden_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[VmSchulden] ADD  CONSTRAINT [DF_VmSchulden_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[VmSchulden] ADD  CONSTRAINT [DF_VmSchulden_Modified]  DEFAULT (getdate()) FOR [Modified]
GO

