CREATE TABLE [dbo].[PscdSentBaZahlungsweg](
	[BaZahlungswegID] [int] NOT NULL,
	[BaZahlungswegTS_Sent] [binary](8) NOT NULL,
	[SentToPscd] [datetime] NOT NULL,
	[SapID] [int] NULL,
	[SapIDAddress] [int] NULL,
 CONSTRAINT [PK_PscdSentBaZahlungsweg] PRIMARY KEY CLUSTERED 
(
	[BaZahlungswegID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON