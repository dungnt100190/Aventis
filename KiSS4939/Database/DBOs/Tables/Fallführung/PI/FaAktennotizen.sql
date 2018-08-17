CREATE TABLE [dbo].[FaAktennotizen](
	[FaAktennotizenID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[UserID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[KontaktArtCode] [int] NULL,
	[DienstleistungCode] [int] NULL,
	[Stichworte] [varchar](100) NULL,
	[Inhalt] [text] NULL,
	[BeteiligtePersonen] [varchar](255) NULL,
	[ThemenCodes] [varchar](255) NULL,
	[Schreibgeschuetzt] [bit] NOT NULL,
	[FaAktennotizenTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaAktennotizen] PRIMARY KEY CLUSTERED 
(
	[FaAktennotizenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
) ON [DATEN3] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FaAktennotizen_BaPersonID] ON [dbo].[FaAktennotizen] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO


CREATE NONCLUSTERED INDEX [IX_FaAktennotizen_UserID] ON [dbo].[FaAktennotizen] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN3]
GO

ALTER TABLE [dbo].[FaAktennotizen]  WITH CHECK ADD  CONSTRAINT [FK_FaAktennotizen_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaAktennotizen] CHECK CONSTRAINT [FK_FaAktennotizen_BaPerson]
GO

ALTER TABLE [dbo].[FaAktennotizen]  WITH CHECK ADD  CONSTRAINT [FK_FaAktennotizen_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAktennotizen] CHECK CONSTRAINT [FK_FaAktennotizen_XUser]
GO

ALTER TABLE [dbo].[FaAktennotizen] ADD  CONSTRAINT [DF_FaAktennotizen_Schreibgeschuetzt]  DEFAULT ((0)) FOR [Schreibgeschuetzt]
GO