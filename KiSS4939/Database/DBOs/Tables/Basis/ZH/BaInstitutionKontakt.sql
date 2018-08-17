CREATE TABLE [dbo].[BaInstitutionKontakt](
	[BaInstitutionKontaktID] [int] IDENTITY(1,1) NOT NULL,
	[BaInstitutionID] [int] NOT NULL,
	[Anrede] [varchar](50) NULL,
	[Person] [varchar](100) NOT NULL,
	[SprachCode] [int] NULL,
	[Telefon] [varchar](100) NULL,
	[Fax] [varchar](100) NULL,
	[EMail] [varchar](100) NULL,
	[Bemerkung] [text] NULL,
	[Aktiv] [bit] NOT NULL CONSTRAINT [DF_BaInstitutionKontakt_Aktiv]  DEFAULT ((1)),
	[BaInstitutionKontaktTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaInstitutionKontakt] PRIMARY KEY CLUSTERED 
(
	[BaInstitutionKontaktID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_BaInstitutionKontakt_BaInstitutionID]    Script Date: 11/23/2011 10:41:33 ******/
CREATE NONCLUSTERED INDEX [IX_BaInstitutionKontakt_BaInstitutionID] ON [dbo].[BaInstitutionKontakt] 
(
	[BaInstitutionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaInstitutionKontakt]  WITH CHECK ADD  CONSTRAINT [FK_BaInstitutionKontakt_BaInstitution] FOREIGN KEY([BaInstitutionID])
REFERENCES [dbo].[BaInstitution] ([BaInstitutionID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BaInstitutionKontakt] CHECK CONSTRAINT [FK_BaInstitutionKontakt_BaInstitution]