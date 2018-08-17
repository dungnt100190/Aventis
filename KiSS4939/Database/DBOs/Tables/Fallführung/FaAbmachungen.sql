CREATE TABLE [dbo].[FaAbmachungen](
	[FaAbmachungenID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[UserID] [int] NULL,
	[Erstellung] [datetime] NOT NULL,
	[PerDatum] [datetime] NOT NULL,
	[Erledigt] [bit] NOT NULL,
	[DienstleistungCode] [int] NOT NULL,
	[Stichworte] [varchar](2000) NULL,
	[Text] [text] NULL,
	[BeteiligtePersonen] [varchar](255) NULL,
	[ThemenCodes] [varchar](255) NULL,
	[FaAbmachungenTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaAbmachungen] PRIMARY KEY CLUSTERED 
(
	[FaAbmachungenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

ALTER TABLE [dbo].[FaAbmachungen]  WITH CHECK ADD  CONSTRAINT [FK_FaAbmachungen_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaAbmachungen] CHECK CONSTRAINT [FK_FaAbmachungen_BaPerson]
GO

ALTER TABLE [dbo].[FaAbmachungen]  WITH CHECK ADD  CONSTRAINT [FK_FaAbmachungen_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO

ALTER TABLE [dbo].[FaAbmachungen] CHECK CONSTRAINT [FK_FaAbmachungen_XUser]
GO

ALTER TABLE [dbo].[FaAbmachungen] ADD  CONSTRAINT [DF_FaAbmachungen_Erledigt]  DEFAULT ((0)) FOR [Erledigt]
GO