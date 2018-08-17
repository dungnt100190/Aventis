CREATE TABLE [dbo].[FaInvolvierteInstitution](
	[FaInvolvierteInstitutionID] [int] IDENTITY(1,1) NOT NULL,
	[FaFallID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[BaInstitutionID] [int] NOT NULL,
	[UserID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[Ansprechperson] [varchar](100) NULL,
	[AnsprechpersonTelefon] [varchar](100) NULL,
	[AnsprechpersonEMail] [varchar](100) NULL,
	[Bemerkung] [text] NULL,
	[FaInvolvierteInstitutionTS] [timestamp] NOT NULL,
	[InstitutionZusatzCode] [int] NULL,
 CONSTRAINT [PK_FaInvolvierteInstitution] PRIMARY KEY CLUSTERED 
(
	[FaInvolvierteInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_FaInvolvierteInstitution_BaInstitutionID]    Script Date: 11/23/2011 14:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_FaInvolvierteInstitution_BaInstitutionID] ON [dbo].[FaInvolvierteInstitution] 
(
	[BaInstitutionID] ASC
)
INCLUDE ( [FaFallID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaInvolvierteInstitution_BaPersonID]    Script Date: 11/23/2011 14:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_FaInvolvierteInstitution_BaPersonID] ON [dbo].[FaInvolvierteInstitution] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaInvolvierteInstitution_FaFallID]    Script Date: 11/23/2011 14:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_FaInvolvierteInstitution_FaFallID] ON [dbo].[FaInvolvierteInstitution] 
(
	[FaFallID] ASC
)
INCLUDE ( [BaInstitutionID]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaInvolvierteInstitution_UserID]    Script Date: 11/23/2011 14:57:55 ******/
CREATE NONCLUSTERED INDEX [IX_FaInvolvierteInstitution_UserID] ON [dbo].[FaInvolvierteInstitution] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaInvolvierteInstitution]  WITH CHECK ADD  CONSTRAINT [FK_FaInvolvierteInstitution_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
GO
ALTER TABLE [dbo].[FaInvolvierteInstitution] CHECK CONSTRAINT [FK_FaInvolvierteInstitution_BaInstitution]
GO
ALTER TABLE [dbo].[FaInvolvierteInstitution]  WITH CHECK ADD  CONSTRAINT [FK_FaInvolvierteInstitution_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[FaInvolvierteInstitution] CHECK CONSTRAINT [FK_FaInvolvierteInstitution_BaPerson]
GO
ALTER TABLE [dbo].[FaInvolvierteInstitution]  WITH CHECK ADD  CONSTRAINT [FK_FaInvolvierteInstitution_FaFall] FOREIGN KEY([FaFallID])
REFERENCES [dbo].[FaFall] ([FaFallID])
GO
ALTER TABLE [dbo].[FaInvolvierteInstitution] CHECK CONSTRAINT [FK_FaInvolvierteInstitution_FaFall]
GO
ALTER TABLE [dbo].[FaInvolvierteInstitution]  WITH CHECK ADD  CONSTRAINT [FK_FaInvolvierteInstitution_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaInvolvierteInstitution] CHECK CONSTRAINT [FK_FaInvolvierteInstitution_XUser]