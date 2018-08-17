CREATE TABLE [dbo].[XBFsWert](
	[XBFsWertID] [int] IDENTITY(1,1) NOT NULL,
	[DossierID] [int] NULL,
	[BaPersonID] [int] NOT NULL,
	[XBFsFrageID] [int] NOT NULL,
	[Wert_alt] [varchar](100) NULL,
	[Jahr] [smallint] NOT NULL CONSTRAINT [DF_XBFsWert_Datum]  DEFAULT (datepart(year,getdate())),
	[Stichtag] [smallint] NOT NULL CONSTRAINT [DF_XBFsWert_Stichtag]  DEFAULT ((1)),
	[Wert] [sql_variant] NULL,
	[XBFsWertTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_XBFsWert] PRIMARY KEY CLUSTERED 
(
	[XBFsWertID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]
) ON [SYSTEM]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_XBFsWert_BaPersonID_XBFsFrageID_Jahr_Stichtag]    Script Date: 11/23/2011 16:43:46 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_XBFsWert_BaPersonID_XBFsFrageID_Jahr_Stichtag] ON [dbo].[XBFsWert] 
(
	[BaPersonID] ASC,
	[XBFsFrageID] ASC,
	[Jahr] ASC,
	[Stichtag] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [SYSTEM]