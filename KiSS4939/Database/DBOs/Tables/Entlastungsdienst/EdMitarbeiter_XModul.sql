CREATE TABLE [dbo].[EdMitarbeiter_XModul](
	[EdMitarbeiter_XModulID] [int] IDENTITY(1,1) NOT NULL,
	[EdMitarbeiterID] [int] NOT NULL,
	[XModulID] [int] NOT NULL,
	[IstAktiv] [bit] NOT NULL CONSTRAINT [DF_EdMitarbeiter_XModul_IstAktiv]  DEFAULT ((0)),
	[ModulTypCodes] [varchar](100) NOT NULL,
	[Creator] [varchar](255) NOT NULL,
	[Created] [datetime] NOT NULL CONSTRAINT [DF_EdMitarbeiter_XModul_Created]  DEFAULT (getdate()),
	[Modifier] [varchar](255) NOT NULL,
	[Modified] [datetime] NOT NULL CONSTRAINT [DF_EdMitarbeiter_XModul_Modified]  DEFAULT (getdate()),
	[EdMitarbeiter_XModulTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_EdMitarbeiter_XModul] PRIMARY KEY CLUSTERED 
(
	[EdMitarbeiter_XModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY],
 CONSTRAINT [UK_EdMitarbeiter_XModul_EdMitarbeiterID_XModulID] UNIQUE NONCLUSTERED 
(
	[EdMitarbeiterID] ASC,
	[XModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING OFF
GO

/****** Object:  Index [IX_EdMitarbeiter_XModul_EdMitarbeiterID]    Script Date: 11/19/2009 10:16:48 ******/
CREATE NONCLUSTERED INDEX [IX_EdMitarbeiter_XModul_EdMitarbeiterID] ON [dbo].[EdMitarbeiter_XModul] 
(
	[EdMitarbeiterID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_EdMitarbeiter_XModul_EdMitarbeiterID_XModulID_IstAktiv]    Script Date: 11/19/2009 10:16:48 ******/
CREATE NONCLUSTERED INDEX [IX_EdMitarbeiter_XModul_EdMitarbeiterID_XModulID_IstAktiv] ON [dbo].[EdMitarbeiter_XModul] 
(
	[EdMitarbeiterID] ASC,
	[XModulID] ASC,
	[IstAktiv] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

/****** Object:  Index [IX_EdMitarbeiter_XModul_XModulID]    Script Date: 11/19/2009 10:16:48 ******/
CREATE NONCLUSTERED INDEX [IX_EdMitarbeiter_XModul_XModulID] ON [dbo].[EdMitarbeiter_XModul] 
(
	[XModulID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'CSV Liste der Ausgewählten codes für den Benutzer des Moduls' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'EdMitarbeiter_XModul', @level2type=N'COLUMN',@level2name=N'ModulTypCodes'
GO
ALTER TABLE [dbo].[EdMitarbeiter_XModul]  WITH CHECK ADD  CONSTRAINT [FK_EdMitarbeiter_XModul_EdMitarbeiter] FOREIGN KEY([EdMitarbeiterID])
REFERENCES [dbo].[EdMitarbeiter] ([EdMitarbeiterID])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[EdMitarbeiter_XModul] CHECK CONSTRAINT [FK_EdMitarbeiter_XModul_EdMitarbeiter]
GO
ALTER TABLE [dbo].[EdMitarbeiter_XModul]  WITH CHECK ADD  CONSTRAINT [FK_EdMitarbeiter_XModul_XModul] FOREIGN KEY([XModulID])
REFERENCES [dbo].[XModul] ([ModulID])
GO
ALTER TABLE [dbo].[EdMitarbeiter_XModul] CHECK CONSTRAINT [FK_EdMitarbeiter_XModul_XModul]