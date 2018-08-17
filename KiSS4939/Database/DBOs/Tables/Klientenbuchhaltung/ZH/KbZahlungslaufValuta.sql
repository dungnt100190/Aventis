CREATE TABLE [dbo].[KbZahlungslaufValuta](
	[KbZahlungslaufValutaID] [int] IDENTITY(1,1) NOT NULL,
	[Jahr] [int] NOT NULL,
	[Monat] [int] NOT NULL,
	[DatMonatlich] [datetime] NULL,
	[DatTeil1] [datetime] NULL,
	[DatTeil2] [datetime] NULL,
	[Dat14Tage1] [datetime] NULL,
	[Dat14Tage2] [datetime] NULL,
	[Dat14Tage3] [datetime] NULL,
	[DatWoche1] [datetime] NULL,
	[DatWoche2] [datetime] NULL,
	[DatWoche3] [datetime] NULL,
	[DatWoche4] [datetime] NULL,
	[DatWoche5] [datetime] NULL,
	[KbZahlungslaufValutaTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KbZahlungslaufValuta] PRIMARY KEY CLUSTERED 
(
	[KbZahlungslaufValutaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_KbZahlungslaufValuta_Jahr_Monat]    Script Date: 11/23/2011 15:59:34 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_KbZahlungslaufValuta_Jahr_Monat] ON [dbo].[KbZahlungslaufValuta] 
(
	[Jahr] ASC,
	[Monat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]