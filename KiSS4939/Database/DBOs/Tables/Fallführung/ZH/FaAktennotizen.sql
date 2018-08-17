CREATE TABLE [dbo].[FaAktennotizen](
	[FaAktennotizID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[UserID_Autor] [int] NULL,
	[Erstelldatum] [datetime] NULL,
	[Datum] [datetime] NOT NULL,
	[Zeit] [datetime] NULL,
	[FaDauerCode] [int] NULL,
	[FaGespraechsStatusCode] [int] NULL,
	[FaGespraechstypCode] [int] NULL,
	[Kontaktpartner] [varchar](200) NULL,
	[AlimentenstelleTypCode] [int] NULL,
	[Stichwort] [varchar](200) NOT NULL,
	[InhaltRTF] [text] NULL,
	[Vertraulich] [bit] NOT NULL,	
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaAktennotizenTS] [timestamp] NOT NULL
 CONSTRAINT [PK_FaAktennotizen] PRIMARY KEY CLUSTERED 
(
	[FaAktennotizID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [DATEN2]
) ON [DATEN2] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_FaAktennotizen_FaLeistungID]    Script Date: 15.02.2017 07:39:37 ******/
CREATE NONCLUSTERED INDEX [IX_FaAktennotizen_FaLeistungID] ON [dbo].[FaAktennotizen]
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_FaAktennotizen_UserID]    Script Date: 15.02.2017 07:39:37 ******/
CREATE NONCLUSTERED INDEX [IX_FaAktennotizen_UserID] ON [dbo].[FaAktennotizen]
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_FaAktennotizen_UserID_Autor]    Script Date: 15.02.2017 07:39:37 ******/
CREATE NONCLUSTERED INDEX [IX_FaAktennotizen_UserID_Autor] ON [dbo].[FaAktennotizen]
(
	[UserID_Autor] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, FILLFACTOR = 90) ON [DATEN2]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_Vetraulich]  DEFAULT ((0)) FOR [Vertraulich]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  DEFAULT (getdate()) FOR [Modified]
GO

ALTER TABLE [dbo].[FaAktennotizen]  WITH CHECK ADD  CONSTRAINT [FK_FaAktennotizen_FaFall] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaAktennotizen] CHECK CONSTRAINT [FK_FaAktennotizen_FaFall]
GO

ALTER TABLE [dbo].[FaAktennotizen]  WITH CHECK ADD  CONSTRAINT [FK_FaAktennotizen_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAktennotizen] CHECK CONSTRAINT [FK_FaAktennotizen_XUser]
GO

ALTER TABLE [dbo].[FaAktennotizen]  WITH CHECK ADD  CONSTRAINT [FK_FaAktennotizen_XUser_Autor] FOREIGN KEY([UserID_Autor])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAktennotizen] CHECK CONSTRAINT [FK_FaAktennotizen_XUser_Autor]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Gibt an, welcher Benutzer den Datensatz erstellt hat und in Folge dessen ändern darf (nicht mutierbar)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'UserID_Autor'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde (nicht mutierbar)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'Erstelldatum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz erstellt wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt geändert wurde' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'Modified'
GO


