CREATE TABLE [dbo].[BaZahlungswegDokument](
	[BaZahlungswegDokumentID] [INT] IDENTITY(1,1) NOT NULL,
	[BaZahlungswegID] [INT] NOT NULL,
	[DocumentID] [INT] NULL,
	[BaZahlungswegDokumentTypCode] [INT] NULL,
	[Stichwort] [VARCHAR](255) NULL,
	[Definitiv] [BIT] NOT NULL,
	[Creator] [VARCHAR](50) NOT NULL,
	[Created] [DATETIME] NOT NULL,
	[Modifier] [VARCHAR](50) NOT NULL,
	[Modified] [DATETIME] NOT NULL,
	[BaZahlungswegDokumentTS] [TIMESTAMP] NOT NULL,
 CONSTRAINT [PK_BaZahlungswegDokument] PRIMARY KEY CLUSTERED 
(
	[BaZahlungswegDokumentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[BaZahlungswegDokument] ADD  CONSTRAINT [DF_BaZahlungswegDokument_Definitiv] DEFAULT (0) FOR [Definitiv]
GO

ALTER TABLE [dbo].[BaZahlungswegDokument] ADD  CONSTRAINT [DF_BaZahlungswegDokument_Created]  DEFAULT (GETDATE()) FOR [Created]
GO

ALTER TABLE [dbo].[BaZahlungswegDokument] ADD  CONSTRAINT [DF_BaZahlungswegDokument_Modified]  DEFAULT (GETDATE()) FOR [Modified]
GO

ALTER TABLE [dbo].[BaZahlungswegDokument]  WITH CHECK ADD  CONSTRAINT [FK_BaZahlungswegDokument_BaZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [dbo].[BaZahlungsweg] ([BaZahlungswegID])
GO

ALTER TABLE [dbo].[BaZahlungswegDokument] CHECK CONSTRAINT [FK_BaZahlungswegDokument_BaZahlungsweg]
GO


