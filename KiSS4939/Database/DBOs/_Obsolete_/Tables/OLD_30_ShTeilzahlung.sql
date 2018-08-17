CREATE TABLE [dbo].[OLD_30_ShTeilzahlung](
	[ShTeilzahlungID] [int] IDENTITY(1,1) NOT NULL,
	[ShBelegID] [int] NOT NULL,
	[BaPersonID] [int] NULL,
	[BgZahlungsmodusID] [int] NULL,
	[KbAuszahlungsArtCode] [int] NOT NULL,
	[Buchungstext] [varchar](200) NULL,
	[BaZahlungswegID] [int] NULL,
	[ReferenzNummer] [varchar](50) NULL,
	[ShTeilzahlungStatusCode] [int] NOT NULL,
	[ValutaDatum] [datetime] NULL,
	[ShTeilzahlungTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_ShTeilzahlung] PRIMARY KEY NONCLUSTERED 
(
	[ShTeilzahlungID] ASC
) ON [PRIMARY]
) ON [PRIMARY]

GO


CREATE CLUSTERED INDEX [IX_ShTeilzahlung] ON [dbo].[OLD_30_ShTeilzahlung] 
(
	[ShBelegID] ASC,
	[BaPersonID] ASC,
	[ValutaDatum] ASC
) ON [PRIMARY]
GO


CREATE NONCLUSTERED INDEX [IX_ShTeilzahlung_ShTeilzahlungStatusCode] ON [dbo].[OLD_30_ShTeilzahlung] 
(
	[ShTeilzahlungStatusCode] ASC
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[OLD_30_ShTeilzahlung]  WITH CHECK ADD  CONSTRAINT [FK_ShTeilzahlung_FlZahlungsweg] FOREIGN KEY([BaZahlungswegID])
REFERENCES [OLD_30_FlZahlungsweg] ([FlZahlungswegID])
GO

ALTER TABLE [dbo].[OLD_30_ShTeilzahlung]  WITH CHECK ADD  CONSTRAINT [FK_ShTeilzahlung_ShBeleg] FOREIGN KEY([ShBelegID])
REFERENCES [OLD_30_ShBeleg] ([ShBelegID])
ON UPDATE CASCADE
ON DELETE CASCADE
GO