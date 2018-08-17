CREATE TABLE [dbo].[FaAktennotizen](
	[FaAktennotizID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[UserID] [int] NULL,
	[Datum] [datetime] NULL,
	[Zeit] [datetime] NULL,
	[FaDauerCode] [int] NULL,
	[FaGespraechsStatusCode] [int] NULL,
	[FaThemaCodes] [varchar](255) NULL,
	[FaGespraechstypCode] [int] NULL,
	[Kontaktpartner] [varchar](200) NULL,
	[AlimentenstelleTypCode] [int] NULL,
	[BaPersonIDs] [varchar](200) NULL,
	[Stichwort] [varchar](200) NULL,
	[InhaltRTF] [varchar](max) NULL,
	[Vertraulich] [bit] NOT NULL,
	[BesprechungThema1] [bit] NULL,
	[BesprechungThema2] [bit] NULL,
	[BesprechungThema3] [bit] NULL,
	[BesprechungThema4] [bit] NULL,
	[BesprechungThemaText1] [varchar](200) NULL,
	[BesprechungThemaText2] [varchar](200) NULL,
	[BesprechungThemaText3] [varchar](200) NULL,
	[BesprechungThemaText4] [varchar](200) NULL,
	[BesprechungZiel1] [varchar](200) NULL,
	[BesprechungZiel2] [varchar](200) NULL,
	[BesprechungZiel3] [varchar](200) NULL,
	[BesprechungZiel4] [varchar](200) NULL,
	[BesprechungZielGrad1] [int] NULL,
	[BesprechungZielGrad2] [int] NULL,
	[BesprechungZielGrad3] [int] NULL,
	[BesprechungZielGrad4] [int] NULL,
	[FaKontaktartCode] [int] NULL,
	[Pendenz1] [varchar](200) NULL,
	[Pendenz2] [varchar](200) NULL,
	[Pendenz3] [varchar](200) NULL,
	[Pendenz4] [varchar](200) NULL,
	[PendenzErledigt1] [bit] NULL,
	[PendenzErledigt2] [bit] NULL,
	[PendenzErledigt3] [bit] NULL,
	[PendenzErledigt4] [bit] NULL,
	[IsDeleted] [bit] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL,
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL,
	[FaAktennotizTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaAktennotizen] PRIMARY KEY CLUSTERED 
(
	[FaAktennotizID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel des Records (nach Primärschlüssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'FaAktennotizID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf FaLeistung.FaLeistungID. Weisst die Aktennotiz zu einer Leistung zu.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel auf XUser.UserID. Weisst die Aktennotiz zu einem Mitarbeiter zu.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'UserID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Verschiedene Themen wie Wohnen, Gesundheit u.s.w.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'FaThemaCodes'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'BaPersonIDs der betroffenen Personen, kommasepariert' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'BaPersonIDs'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Mögliche Werte sind z.B. Telefon oder E-Mail.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'FaKontaktartCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Ob der Datensatz logisch gelöscht worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'IsDeleted'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz angelegt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'Creator'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz angelegt wroden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'Created'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wer den Datensatz zuletzt mutiert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'Modifier'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Datensatz zuletzt modifiziert worden ist.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'Modified'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp des Records, wird für die Änderungsverfolgung verwendet' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'FaAktennotizen', @level2type=N'COLUMN',@level2name=N'FaAktennotizTS'
GO

ALTER TABLE [dbo].[FaAktennotizen]  WITH CHECK ADD  CONSTRAINT [FK_FaAktennotizen_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[FaAktennotizen] CHECK CONSTRAINT [FK_FaAktennotizen_FaLeistung]
GO

ALTER TABLE [dbo].[FaAktennotizen]  WITH CHECK ADD  CONSTRAINT [FK_FaAktennotizen_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAktennotizen] CHECK CONSTRAINT [FK_FaAktennotizen_XUser]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_Vetraulich]  DEFAULT ((0)) FOR [Vertraulich]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_BesprechungThema1]  DEFAULT ((0)) FOR [BesprechungThema1]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_BesprechungThema2]  DEFAULT ((0)) FOR [BesprechungThema2]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_BesprechungThema3]  DEFAULT ((0)) FOR [BesprechungThema3]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_BesprechungThema4]  DEFAULT ((0)) FOR [BesprechungThema4]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_IsDeleted]  DEFAULT ((0)) FOR [IsDeleted]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_Created]  DEFAULT (getdate()) FOR [Created]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_Modified]  DEFAULT (getdate()) FOR [Modified]
GO


