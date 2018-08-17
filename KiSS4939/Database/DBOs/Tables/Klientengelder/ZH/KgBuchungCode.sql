CREATE TABLE [dbo].[KgBuchungCode](
	[KgBuchungCodeID] [int] IDENTITY(1,1) NOT NULL,
	[Code] [varchar](10) NOT NULL,
	[SollKtoNr] [int] NULL,
	[HabenKtoNr] [int] NULL,
	[Betrag] [money] NULL,
	[Text] [varchar](200) NULL,
	[UserID] [int] NULL,
	[KgBuchungCodeTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KgBuchungCode] PRIMARY KEY CLUSTERED 
(
	[KgBuchungCodeID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_KgBuchungCode_UserID]    Script Date: 11/23/2011 16:01:07 ******/
CREATE NONCLUSTERED INDEX [IX_KgBuchungCode_UserID] ON [dbo].[KgBuchungCode] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[KgBuchungCode]  WITH CHECK ADD  CONSTRAINT [FK_KgBuchungCode_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[KgBuchungCode] CHECK CONSTRAINT [FK_KgBuchungCode_XUser]