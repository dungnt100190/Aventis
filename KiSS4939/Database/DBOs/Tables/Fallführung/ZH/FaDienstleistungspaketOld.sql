CREATE TABLE [dbo].[FaDienstleistungspaketOld](
	[FaDienstleistungspaketID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[DLPBedarfBezeichnungCode] [int] NULL,
	[DLPBedarfKriteriumCode] [int] NULL,
	[DLPBedarfDatumVon] [datetime] NULL,
	[DLPIstBezeichnungCode] [int] NULL,
	[DLPIstKriteriumCode] [int] NULL,
	[DLPIstProfilCode] [int] NULL,
	[DLPIstDatumVon] [datetime] NULL,
	[FallfuehrenderID] [int] NULL,
	[CoFallfuehrenderID] [int] NULL,
	[SachbearbeiterID] [int] NULL,
	[DLPIstDatumAbschluss] [datetime] NULL,
 CONSTRAINT [PK_Dienstleistungspaket] PRIMARY KEY CLUSTERED 
(
	[FaDienstleistungspaketID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
ALTER TABLE [dbo].[FaDienstleistungspaketOld]  WITH CHECK ADD  CONSTRAINT [FK_FaDienstleistungspaket_XUser] FOREIGN KEY([FallfuehrenderID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaDienstleistungspaketOld] CHECK CONSTRAINT [FK_FaDienstleistungspaket_XUser]
GO
ALTER TABLE [dbo].[FaDienstleistungspaketOld]  WITH CHECK ADD  CONSTRAINT [FK_FaDienstleistungspaket_XUser1] FOREIGN KEY([CoFallfuehrenderID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaDienstleistungspaketOld] CHECK CONSTRAINT [FK_FaDienstleistungspaket_XUser1]
GO
ALTER TABLE [dbo].[FaDienstleistungspaketOld]  WITH CHECK ADD  CONSTRAINT [FK_FaDienstleistungspaket_XUser2] FOREIGN KEY([SachbearbeiterID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaDienstleistungspaketOld] CHECK CONSTRAINT [FK_FaDienstleistungspaket_XUser2]