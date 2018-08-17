CREATE TABLE [dbo].[WhAbrechnung](
	[WhAbrechnungID] [int] IDENTITY(1,1) NOT NULL,
	[FaFallID] [int] NULL,
	[DatumVon] [datetime] NULL,
	[DatumBis] [datetime] NULL,
	[BaPersonID] [int] NULL,
	[WhAbrechnungVisumCode] [int] NOT NULL,
	[DocumentID] [int] NULL,
	[ForderungDokumentID] [int] NULL,
	[Bemerkung] [varchar](600) NULL,
	[WhAbrechnungTS] [timestamp] NOT NULL,
	[DatumVisum] [datetime] NULL,
	[DatumAnfrage] [datetime] NULL,
	[UserID_Visum] [int] NULL,
	[UserID_AnfrageAn] [int] NULL,
	[UserID_AnfrageVon] [int] NULL,
 CONSTRAINT [PK_WhAbrechnung] PRIMARY KEY CLUSTERED 
(
	[WhAbrechnungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_WhAbrechnung_BaPersonID]    Script Date: 11/23/2011 16:39:42 ******/
CREATE NONCLUSTERED INDEX [IX_WhAbrechnung_BaPersonID] ON [dbo].[WhAbrechnung] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_WhAbrechnung_DocumentID]    Script Date: 11/23/2011 16:39:42 ******/
CREATE NONCLUSTERED INDEX [IX_WhAbrechnung_DocumentID] ON [dbo].[WhAbrechnung] 
(
	[DocumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_WhAbrechnung_FaFallID]    Script Date: 11/23/2011 16:39:42 ******/
CREATE NONCLUSTERED INDEX [IX_WhAbrechnung_FaFallID] ON [dbo].[WhAbrechnung] 
(
	[FaFallID] ASC
)
INCLUDE ( [BaPersonID],
[DatumVon],
[DatumBis],
[WhAbrechnungVisumCode],
[DocumentID],
[ForderungDokumentID],
[Bemerkung],
[WhAbrechnungTS],
[UserID_Visum],
[UserID_AnfrageAn],
[UserID_AnfrageVon]) WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_WhAbrechnung_ForderungDokumentID]    Script Date: 11/23/2011 16:39:42 ******/
CREATE NONCLUSTERED INDEX [IX_WhAbrechnung_ForderungDokumentID] ON [dbo].[WhAbrechnung] 
(
	[ForderungDokumentID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_WhAbrechnung_UserID_AnfrageAn]    Script Date: 11/23/2011 16:39:42 ******/
CREATE NONCLUSTERED INDEX [IX_WhAbrechnung_UserID_AnfrageAn] ON [dbo].[WhAbrechnung] 
(
	[UserID_AnfrageAn] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_WhAbrechnung_UserID_AnfrageVon]    Script Date: 11/23/2011 16:39:42 ******/
CREATE NONCLUSTERED INDEX [IX_WhAbrechnung_UserID_AnfrageVon] ON [dbo].[WhAbrechnung] 
(
	[UserID_AnfrageVon] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Index [IX_WhAbrechnung_UserID_Visum]    Script Date: 11/23/2011 16:39:42 ******/
CREATE NONCLUSTERED INDEX [IX_WhAbrechnung_UserID_Visum] ON [dbo].[WhAbrechnung] 
(
	[UserID_Visum] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [DATEN2]
GO

/****** Object:  Trigger [dbo].[WhAbrechnung_OnDelete]    Script Date: 11/23/2011 16:39:42 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER OFF
GO

CREATE TRIGGER [dbo].[WhAbrechnung_OnDelete]
ON [dbo].[WhAbrechnung]
AFTER DELETE
AS
	SET NOCOUNT ON -- Da Variablenzuweisungen im Trigger geschehen muss NOCOUNT gesetzt sein
	DECLARE @istVisiert bit
	SET @istVisiert = 0
	SELECT @istVisiert = CASE WHEN @istVisiert = 1 OR WhAbrechnungVisumCode = 3 THEN 1 ELSE 0 END -- 3 = erteilt
	FROM deleted
	IF @istVisiert = 1 BEGIN
		RAISERROR (N'Visierte Abrechnungen können nicht gelöscht werden',1,0)
	END

GO
ALTER TABLE [dbo].[WhAbrechnung]  WITH CHECK ADD  CONSTRAINT [FK_WhAbrechnung_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO
ALTER TABLE [dbo].[WhAbrechnung] CHECK CONSTRAINT [FK_WhAbrechnung_BaPerson]
GO
ALTER TABLE [dbo].[WhAbrechnung]  WITH CHECK ADD  CONSTRAINT [FK_WhAbrechnung_FaFall] FOREIGN KEY([FaFallID])
REFERENCES [dbo].[FaFall] ([FaFallID])
GO
ALTER TABLE [dbo].[WhAbrechnung] CHECK CONSTRAINT [FK_WhAbrechnung_FaFall]
GO
ALTER TABLE [dbo].[WhAbrechnung]  WITH CHECK ADD  CONSTRAINT [FK_WhAbrechnung_UserID_AnfrageAn] FOREIGN KEY([UserID_AnfrageAn])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[WhAbrechnung] CHECK CONSTRAINT [FK_WhAbrechnung_UserID_AnfrageAn]
GO
ALTER TABLE [dbo].[WhAbrechnung]  WITH CHECK ADD  CONSTRAINT [FK_WhAbrechnung_UserID_AnfrageVon] FOREIGN KEY([UserID_AnfrageVon])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[WhAbrechnung] CHECK CONSTRAINT [FK_WhAbrechnung_UserID_AnfrageVon]
GO
ALTER TABLE [dbo].[WhAbrechnung]  WITH CHECK ADD  CONSTRAINT [FK_WhAbrechnung_UserID_Visum] FOREIGN KEY([UserID_Visum])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[WhAbrechnung] CHECK CONSTRAINT [FK_WhAbrechnung_UserID_Visum]