CREATE TABLE [dbo].[FaDokumente](
	[FaDokumenteID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[AutorID] [int] NOT NULL,
	[AutorAdressTypCode] [int] NOT NULL,
	[Datum] [datetime] NULL,
	[AdressatID] [int] NULL,
	[AdressatAdressTypCode] [int] NULL,
	[AdressatText] [varchar](2000) NULL,
	[DienstleistungCode] [int] NULL,
	[Stichworte] [varchar](100) NULL,
	[DokumentDocID] [int] NULL,
	[ThemenCodes] [varchar](100) NULL,
	[Bemerkungen] [text] NULL,
	[FaDokumenteTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaDokumente] PRIMARY KEY CLUSTERED 
(
	[FaDokumenteID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
) ON [DATEN2] TEXTIMAGE_ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO


CREATE NONCLUSTERED INDEX [IX_FaDokumente_BaPersonID] ON [dbo].[FaDokumente] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN2]
GO

ALTER TABLE [dbo].[FaDokumente]  WITH CHECK ADD  CONSTRAINT [FK_FaDokumente_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[FaDokumente] CHECK CONSTRAINT [FK_FaDokumente_BaPerson]
GO