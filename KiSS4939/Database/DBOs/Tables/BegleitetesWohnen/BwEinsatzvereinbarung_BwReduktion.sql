CREATE TABLE [dbo].[BwEinsatzvereinbarung_BwReduktion](
	[BwEinsatzvereinbarung_BwReduktionID] [int] IDENTITY(1,1) NOT NULL,
	[BwEinsatzvereinbarungID] [int] NOT NULL,
	[BwReduktionID] [int] NOT NULL,
	[Creator] [varchar](50) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_BwEinsatzvereinbarung_BwReduktion_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](50) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_BwEinsatzvereinbarung_BwReduktion_Modified]  DEFAULT (getdate()),
	[BwEinsatzvereinbarung_BwReduktionTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_BwEinsatzvereinbarung_BwReduktion] PRIMARY KEY CLUSTERED 
(
	[BwEinsatzvereinbarung_BwReduktionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_BwEinsatzvereinbarung_BwReduktion_BwEinsatzvereinbarungID_BwReduktionID] UNIQUE NONCLUSTERED 
(
	[BwEinsatzvereinbarungID] ASC,
	[BwReduktionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_BwEinsatzvereinbarung_BwReduktion_BwEinsatzvereinbarungID]    Script Date: 11/17/2009 08:17:33 ******/
CREATE NONCLUSTERED INDEX [IX_BwEinsatzvereinbarung_BwReduktion_BwEinsatzvereinbarungID] ON [dbo].[BwEinsatzvereinbarung_BwReduktion] 
(
	[BwEinsatzvereinbarungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_BwEinsatzvereinbarung_BwReduktion_BwReduktionID]    Script Date: 11/17/2009 08:17:33 ******/
CREATE NONCLUSTERED INDEX [IX_BwEinsatzvereinbarung_BwReduktion_BwReduktionID] ON [dbo].[BwEinsatzvereinbarung_BwReduktion] 
(
	[BwReduktionID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Primärschlüssel, eine ID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwReduktion', @level2type=N'COLUMN',@level2name=N'BwEinsatzvereinbarung_BwReduktionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Einsatzvereinbarung welche mit einer Reduktion verknüpft werden soll. Fremdschlüssel auf BwEinsatzvereinbarung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwReduktion', @level2type=N'COLUMN',@level2name=N'BwEinsatzvereinbarungID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'ID der Reduktion welche mit einer Einsatzvereinbarung verknüpft werden soll. Fremdschlüssel auf BwReduktion.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwReduktion', @level2type=N'COLUMN',@level2name=N'BwReduktionID'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag erstellt hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwReduktion', @level2type=N'COLUMN',@level2name=N'Creator'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann der Eintrag erstellt wurde.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwReduktion', @level2type=N'COLUMN',@level2name=N'Created'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Benutzer welcher den Eintrag als letztes verändert hat.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwReduktion', @level2type=N'COLUMN',@level2name=N'Modifier'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Wann wurde der Eintrag als letztes verändert.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwReduktion', @level2type=N'COLUMN',@level2name=N'Modified'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp für Konsistenzprüfung.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'BwEinsatzvereinbarung_BwReduktion', @level2type=N'COLUMN',@level2name=N'BwEinsatzvereinbarung_BwReduktionTS'
GO
ALTER TABLE [dbo].[BwEinsatzvereinbarung_BwReduktion]  WITH CHECK ADD  CONSTRAINT [FK_BwEinsatzvereinbarung_BwReduktion_BwEinsatzvereinbarung] FOREIGN KEY([BwEinsatzvereinbarungID])
REFERENCES [dbo].[BwEinsatzvereinbarung] ([BwEinsatzvereinbarungID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[BwEinsatzvereinbarung_BwReduktion] CHECK CONSTRAINT [FK_BwEinsatzvereinbarung_BwReduktion_BwEinsatzvereinbarung]
GO
ALTER TABLE [dbo].[BwEinsatzvereinbarung_BwReduktion]  WITH CHECK ADD  CONSTRAINT [FK_BwEinsatzvereinbarung_BwReduktion_BwReduktion] FOREIGN KEY([BwReduktionID])
REFERENCES [dbo].[BwReduktion] ([BwReduktionID])
GO
ALTER TABLE [dbo].[BwEinsatzvereinbarung_BwReduktion] CHECK CONSTRAINT [FK_BwEinsatzvereinbarung_BwReduktion_BwReduktion]