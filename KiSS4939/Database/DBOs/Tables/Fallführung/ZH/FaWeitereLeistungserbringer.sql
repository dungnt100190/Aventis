CREATE TABLE [dbo].[FaWeitereLeistungserbringer](
	[FaLeistungserbringerID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[FaTeilLeistungBereichCode] [int] NOT NULL,
	[UserID] [int] NULL,
	[Name] [varchar](100) NOT NULL,
	[Telefon] [varchar](80) NULL,
	[EMail] [varchar](80) NULL,
	[Bemerkung] [text] NULL,
	[FaWeitereLeistungserbringerTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaWeitereLeistungserbringer] PRIMARY KEY NONCLUSTERED 
(
	[FaLeistungserbringerID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_FaWeitereLeistungserbringer]    Script Date: 11/23/2011 15:06:04 ******/
CREATE CLUSTERED INDEX [IX_FaWeitereLeistungserbringer] ON [dbo].[FaWeitereLeistungserbringer] 
(
	[FaLeistungID] ASC,
	[DatumVon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaWeitereLeistungserbringer]  WITH CHECK ADD  CONSTRAINT [FK_FaWeitereLeistungserbringer_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[FaWeitereLeistungserbringer] CHECK CONSTRAINT [FK_FaWeitereLeistungserbringer_FaLeistung]