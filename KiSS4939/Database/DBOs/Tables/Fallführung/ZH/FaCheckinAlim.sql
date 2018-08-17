CREATE TABLE [dbo].[FaCheckinAlim](
	[FaCheckinAlimID] [int] IDENTITY(1,1) NOT NULL,
	[FaLeistungID] [int] NOT NULL,
	[WohnsitzGeprueftDatum] [datetime] NULL,
	[ErstkontaktDatum] [datetime] NULL,
	[ErstkontaktUserID] [int] NULL,
	[AnlassCode] [int] NULL,
	[AnfrageDatum] [datetime] NULL,
	[AnfrageUserID] [int] NULL,
	[UnterlagenEingangDatum] [datetime] NULL,
	[UnterlagenEingangUserID] [int] NULL,
	[Bemerkung] [varchar](200) NULL,
	[FaCheckInAlimTS] [timestamp] NULL,
 CONSTRAINT [PK_FaCheckinAlim] PRIMARY KEY CLUSTERED 
(
	[FaCheckinAlimID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON
GO

/****** Object:  Index [IX_FaCheckinAlim_AnfrageUserID]    Script Date: 11/23/2011 14:43:13 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckinAlim_AnfrageUserID] ON [dbo].[FaCheckinAlim] 
(
	[AnfrageUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckinAlim_ErstkontaktUserID]    Script Date: 11/23/2011 14:43:13 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckinAlim_ErstkontaktUserID] ON [dbo].[FaCheckinAlim] 
(
	[ErstkontaktUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckinAlim_FaLeistungID]    Script Date: 11/23/2011 14:43:13 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckinAlim_FaLeistungID] ON [dbo].[FaCheckinAlim] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO

/****** Object:  Index [IX_FaCheckinAlim_UnterlagenEingangUserID]    Script Date: 11/23/2011 14:43:13 ******/
CREATE NONCLUSTERED INDEX [IX_FaCheckinAlim_UnterlagenEingangUserID] ON [dbo].[FaCheckinAlim] 
(
	[UnterlagenEingangUserID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON, FILLFACTOR = 90) ON [PRIMARY]
GO
ALTER TABLE [dbo].[FaCheckinAlim]  WITH CHECK ADD  CONSTRAINT [FK_FaCheckinAlim_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO
ALTER TABLE [dbo].[FaCheckinAlim] CHECK CONSTRAINT [FK_FaCheckinAlim_FaLeistung]
GO
ALTER TABLE [dbo].[FaCheckinAlim]  WITH CHECK ADD  CONSTRAINT [FK_FaCheckinAlim_XUser] FOREIGN KEY([ErstkontaktUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaCheckinAlim] CHECK CONSTRAINT [FK_FaCheckinAlim_XUser]
GO
ALTER TABLE [dbo].[FaCheckinAlim]  WITH CHECK ADD  CONSTRAINT [FK_FaCheckinAlim_XUser_Anfrage] FOREIGN KEY([AnfrageUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaCheckinAlim] CHECK CONSTRAINT [FK_FaCheckinAlim_XUser_Anfrage]
GO
ALTER TABLE [dbo].[FaCheckinAlim]  WITH CHECK ADD  CONSTRAINT [FK_FaCheckinAlim_XUser1] FOREIGN KEY([UnterlagenEingangUserID])
REFERENCES [dbo].[XUser] ([UserID])
GO
ALTER TABLE [dbo].[FaCheckinAlim] CHECK CONSTRAINT [FK_FaCheckinAlim_XUser1]