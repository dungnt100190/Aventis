CREATE TABLE [dbo].[BaErsatzeinkommen](
	[BaErsatzeinkommenID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[BaErsatzeinkommenCode] [int] NULL,
	[DatumAntrag] [datetime] NULL,
	[DatumAbgelehnt] [datetime] NULL,
	[DatumAnspruchAb] [datetime] NULL,
	[DatumBeendet] [datetime] NULL,
	[Betrag] [money] NULL,
	[BetragALBV] [money] NULL,
	[Bemerkung] [text] NULL,
	[BaErsatzeinkommenTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BaErsatzeinkommen] PRIMARY KEY CLUSTERED 
(
	[BaErsatzeinkommenID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO

/****** Object:  Index [IX_BaErsatzeinkommen_]    Script Date: 11/23/2011 10:38:33 ******/
CREATE NONCLUSTERED INDEX [IX_BaErsatzeinkommen_] ON [dbo].[BaErsatzeinkommen] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[BaErsatzeinkommen]  WITH CHECK ADD  CONSTRAINT [FK_BaErsatzeinkommen_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[BaErsatzeinkommen] CHECK CONSTRAINT [FK_BaErsatzeinkommen_BaPerson]