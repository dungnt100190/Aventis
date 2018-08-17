CREATE TABLE [dbo].[IkZahlungslaufValuta](
	[IkZahlungslaufValutaID] [int] IDENTITY(1,1) NOT NULL,
	[Jahr] [int] NOT NULL,
	[Monat] [int] NOT NULL,
	[Datum1] [datetime] NULL,
	[Datum2] [datetime] NULL,
	[Datum3] [datetime] NULL,
	[Datum4] [datetime] NULL,
	[Datum5] [datetime] NULL,
	[Datum6] [datetime] NULL,
	[Datum7] [datetime] NULL,
	[Datum8] [datetime] NULL,
	[Datum9] [datetime] NULL,
	[IkZahlungslaufValutaTS] [timestamp] NOT NULL,
	[Datum10] [datetime] NULL,
 CONSTRAINT [PK_IkZahlungslaufValuta] PRIMARY KEY CLUSTERED 
(
	[IkZahlungslaufValutaID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_IkZahlungslaufValuta_Jahr_Monat]    Script Date: 11/23/2011 15:50:28 ******/
CREATE NONCLUSTERED INDEX [IX_IkZahlungslaufValuta_Jahr_Monat] ON [dbo].[IkZahlungslaufValuta] 
(
	[Jahr] ASC,
	[Monat] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]