CREATE TABLE [dbo].[FaInvolviertePerson](
	[FaInvolviertePersonID] [int] IDENTITY(1,1) NOT NULL,
	[FaFallID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[Name] [varchar](100) NOT NULL,
	[Vorname] [varchar](100) NULL,
	[GeschlechtCode] [int] NULL,
	[DatumVon] [datetime] NOT NULL,
	[DatumBis] [datetime] NULL,
	[RolleCode] [int] NULL,
	[RolleBemerkung] [varchar](50) NULL,
	[Adresse] [varchar](500) NULL,
	[Telefon_P] [varchar](100) NULL,
	[Telefon_G] [varchar](100) NULL,
	[MobilTel1] [varchar](100) NULL,
	[MobilTel2] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[Bemerkung] [text] NULL,
	[ErstelltUserID] [int] NULL,
	[ErstelltDatum] [datetime] NULL,
	[MutiertUserID] [int] NULL,
	[MutiertDatum] [datetime] NULL,
	[FaInvolviertePersonTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_FaInvolviertePerson] PRIMARY KEY CLUSTERED 
(
	[FaInvolviertePersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_FaInvolviertePerson_BaPersonID]    Script Date: 11/23/2011 14:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_FaInvolviertePerson_BaPersonID] ON [dbo].[FaInvolviertePerson] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaInvolviertePerson_ErstelltUserID]    Script Date: 11/23/2011 14:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_FaInvolviertePerson_ErstelltUserID] ON [dbo].[FaInvolviertePerson] 
(
	[ErstelltUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaInvolviertePerson_FaFallID]    Script Date: 11/23/2011 14:58:09 ******/
CREATE NONCLUSTERED INDEX [IX_FaInvolviertePerson_FaFallID] ON [dbo].[FaInvolviertePerson] 
(
	[FaFallID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaInvolviertePerson]  WITH CHECK ADD  CONSTRAINT [FK_FaInvolviertePerson_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[FaInvolviertePerson] CHECK CONSTRAINT [FK_FaInvolviertePerson_BaPerson]
GO
ALTER TABLE [dbo].[FaInvolviertePerson]  WITH CHECK ADD  CONSTRAINT [FK_FaInvolviertePerson_FaFall] FOREIGN KEY([FaFallID])
REFERENCES [dbo].[FaFall] ([FaFallID])
GO
ALTER TABLE [dbo].[FaInvolviertePerson] CHECK CONSTRAINT [FK_FaInvolviertePerson_FaFall]
GO
ALTER TABLE [dbo].[FaInvolviertePerson]  WITH CHECK ADD  CONSTRAINT [FK_FaInvolviertePerson_XUser1] FOREIGN KEY([ErstelltUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaInvolviertePerson] CHECK CONSTRAINT [FK_FaInvolviertePerson_XUser1]