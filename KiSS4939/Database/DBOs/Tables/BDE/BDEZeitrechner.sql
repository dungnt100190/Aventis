CREATE TABLE [dbo].[BDEZeitrechner](
	[BDEZeitrechnerID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NOT NULL,
	[Datum] [datetime] NOT NULL,
	[ZeitVon] [datetime] NOT NULL,
	[ZeitBis] [datetime] NULL,
	[Verbucht] [datetime] NULL,
	[BDEZeitrechnerTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BDEZeitrechner] PRIMARY KEY CLUSTERED 
(
	[BDEZeitrechnerID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO

ALTER TABLE [dbo].[BDEZeitrechner]  WITH CHECK ADD  CONSTRAINT [FK_BDEZeitrechner_XUser] FOREIGN KEY([UserID])
REFERENCES [XUser] ([UserID])
GO

ALTER TABLE [dbo].[BDEZeitrechner] CHECK CONSTRAINT [FK_BDEZeitrechner_XUser]
GO