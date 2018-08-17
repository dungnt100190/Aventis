/****** Object:  Table [dbo].[FaFinanzgesuche]    Script Date: 12/11/2012 16:35:51 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

SET ANSI_PADDING ON
GO

CREATE TABLE [dbo].[FaFinanzgesuche](
	[FaFinanzgesucheID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[DienstleistungCode] [int] NULL,
	[DokumenttypCode] [int] NULL,
	[FondStiftung] [varchar](255) NULL,
	[DokumentDocID] [int] NULL,
	[Beantragt] [money] NULL,
	[StatusCode] [int] NULL,
	[BewilligterBetrag] [money] NULL,
	[Selbstbehalt] [money] NULL,
	[AuszahlungAn] [varchar](255) NULL,
	[Rueckforderung] [money] NULL,
	[Rueckzahlungsverpflichtung] [bit] NOT NULL,
	[DatumRueckforderung] [datetime] NULL,
	[ZurueckBezahlt] [bit] NOT NULL,
	[Bemerkungen] [text] NULL,
	[Stichwort] [varchar](100) NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaFinanzgesucheTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaFinanzenGesuche] PRIMARY KEY CLUSTERED 
(
	[FaFinanzgesucheID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


/****** Object:  Index [IX_FaFinanzgesuche_BaPersonID]    Script Date: 12/11/2012 16:35:51 ******/
CREATE NONCLUSTERED INDEX [IX_FaFinanzgesuche_BaPersonID] ON [dbo].[FaFinanzgesuche] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO


/****** Object:  Index [IX_FaFinanzgesuche_UserID]    Script Date: 12/11/2012 16:35:51 ******/
CREATE NONCLUSTERED INDEX [IX_FaFinanzgesuche_UserID] ON [dbo].[FaFinanzgesuche] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Betrag der Rückforderung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaFinanzgesuche', @level2type=N'COLUMN',@level2name=N'Rueckforderung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag, ob eine Zahlung zurückbezahlt werden muss' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaFinanzgesuche', @level2type=N'COLUMN',@level2name=N'Rueckzahlungsverpflichtung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fälligkeitsdatum, bis wann eine Rückforderung zurückbezahlt werden soll' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaFinanzgesuche', @level2type=N'COLUMN',@level2name=N'DatumRueckforderung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Feld gibt an, ob eine Rückforderung zurückbezahlt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaFinanzgesuche', @level2type=N'COLUMN',@level2name=N'ZurueckBezahlt'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaFinanzgesuche', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaFinanzgesuche', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaFinanzgesuche', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaFinanzgesuche', @level2type=N'COLUMN',@level2name=N'Modified'
GO

ALTER TABLE [dbo].[FaFinanzgesuche]  WITH CHECK ADD  CONSTRAINT [FK_FaFinanzgesuche_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaFinanzgesuche] CHECK CONSTRAINT [FK_FaFinanzgesuche_BaPerson]
GO

ALTER TABLE [dbo].[FaFinanzgesuche]  WITH CHECK ADD  CONSTRAINT [FK_FaFinanzgesuche_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaFinanzgesuche] CHECK CONSTRAINT [FK_FaFinanzgesuche_XUser]
GO

ALTER TABLE [dbo].[FaFinanzgesuche] ADD  CONSTRAINT [DF_FaFinanzgesuche_Rueckzahlungsverpflichtung]  DEFAULT ((0)) FOR [Rueckzahlungsverpflichtung]
GO

ALTER TABLE [dbo].[FaFinanzgesuche] ADD  CONSTRAINT [DF_FaFinanzgesuche_ZurueckBezahlt]  DEFAULT ((0)) FOR [ZurueckBezahlt]
GO

ALTER TABLE [dbo].[FaFinanzgesuche] ADD  CONSTRAINT [DF_FaFinanzgesuche_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaFinanzgesuche] ADD  CONSTRAINT [DF_FaFinanzgesuche_Modified]  DEFAULT (getdate()) FOR [Modified]
GO