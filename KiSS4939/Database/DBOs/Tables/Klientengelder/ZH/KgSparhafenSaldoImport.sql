CREATE TABLE [dbo].[KgSparhafenSaldoImport](
	[KgSparhafenSaldoImportID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[DatumSaldo] [datetime] NOT NULL,
	[DatumImport] [datetime] NULL,
	[ImportErfolgreich] [bit] NOT NULL,
	[DocumentID] [int] NULL,
	[KgSparhafenSaldoImportTS] [timestamp] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[KgSparhafenSaldoImportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO

/****** Object:  Index [IX_KgSparhafenSaldoImport_UserID]    Script Date: 11/23/2011 16:04:57 ******/
CREATE NONCLUSTERED INDEX [IX_KgSparhafenSaldoImport_UserID] ON [dbo].[KgSparhafenSaldoImport] 
(
	[UserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN1]
GO
ALTER TABLE [dbo].[KgSparhafenSaldoImport]  WITH CHECK ADD  CONSTRAINT [FK_KgSparhafenSaldoImport_XUser] FOREIGN KEY([UserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[KgSparhafenSaldoImport] CHECK CONSTRAINT [FK_KgSparhafenSaldoImport_XUser]