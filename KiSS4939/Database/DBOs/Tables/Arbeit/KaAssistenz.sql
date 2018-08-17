/*===============================================================================================
  $Revision: 3 $
=================================================================================================
  Description
=================================================================================================*/

-------------------------------------------------------------------------------
-- init
-------------------------------------------------------------------------------
SET ANSI_NULLS ON;
GO
SET QUOTED_IDENTIFIER ON;
GO
SET ANSI_PADDING ON;
GO

-------------------------------------------------------------------------------
-- table structure
-------------------------------------------------------------------------------
CREATE TABLE [dbo].[KaAssistenz](
  [KaAssistenzID] [int] IDENTITY(1, 1) NOT NULL,
  [FaLeistungID] [int] NOT NULL,
  [Abgemeldet] [bit] NOT NULL,
  [NichtErschienen] [bit] NOT NULL,
  [GespraechStattgefunden] [bit] NOT NULL,
  [Programmbeginn] [bit] NOT NULL,
  [Einsatzplatz] [varchar](500),
  [Stufe] [varchar](50),
  [Personalien] [bit] NOT NULL,
  [Vereinbarung] [bit] NOT NULL,
  [Zielvereinbarung] [bit] NOT NULL,
  [Schlussbericht] [bit] NOT NULL,
  [Testat] [bit] NOT NULL,
  [Bemerkungen] [varchar](2000),
  [KaAssistenzprojektAustrittsgrundCode] [int],
  [Austrittsdatum] [datetime],
  [Creator] [varchar](50) NOT NULL,
  [Created] [datetime] NOT NULL,
  [Modifier] [varchar](50) NOT NULL,
  [Modified] [datetime] NOT NULL,
  [KaAssistenzTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaAssistenz] PRIMARY KEY CLUSTERED 
(
  [KaAssistenzID] ASC
)WITH (PAD_INDEX = OFF, 
       STATISTICS_NORECOMPUTE = OFF, 
       IGNORE_DUP_KEY = OFF, 
       ALLOW_ROW_LOCKS = ON, 
       ALLOW_PAGE_LOCKS = ON) ON [DATEN1]
) ON [DATEN1];
GO

CREATE NONCLUSTERED INDEX [IX_KaAssistenz_FaLeistungID] ON [dbo].[KaAssistenz] 
(
	[FaLeistungID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [DATEN1]
GO

-------------------------------------------------------------------------------
-- extended properties
-------------------------------------------------------------------------------
-- table
EXEC sys.sp_addextendedproperty @name = N'Author', @value = N'Thomas Abegglen' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KaAssistenz'
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Daten der methodischen Leistung: Assistenz.' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KaAssistenz'
GO

EXEC sys.sp_addextendedproperty @name = N'Used_In', @value = N'KA' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KaAssistenz'
GO

-- columns
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Primärschlüssel der Tabelle' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KaAssistenz', 
                                @level2type = N'COLUMN', @level2name = N'KaAssistenzID';
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschlüssel (FK_KaAssistenz_FaLeistung) => FaLeistung.FaLeistungID' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz',
                                @level2type=N'COLUMN',@level2name=N'FaLeistungID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob der Klient vom ALV abgemeldet ist.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Abgemeldet'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob der Klient ohne Abmeldung nicht erschienen ist.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'NichtErschienen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob mit dem Klienten ein Gespräch stattgefunden hat.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'GespraechStattgefunden'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob mit einem Programm begonnen wird.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Programmbeginn'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Einsatzplatz des Klienten.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Einsatzplatz'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stufe des Einsatzes.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Stufe'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob Personalien des Klienten erfasst wurden.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Personalien'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob Vereinbarung mit dem Klienten abgeschlossen wurde.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Vereinbarung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob Zielvereinbarung mit dem Klienten abgeschlossen wurde.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Zielvereinbarung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob Schlussbericht erstellt wurde.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Schlussbericht'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag ob Testat ausgestellt wurde.' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Testat'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkungen' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Bemerkungen'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Austrittsgrund' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'KaAssistenzprojektAustrittsgrundCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Austrittsdatum' , 
                                @level0type=N'SCHEMA',@level0name=N'dbo', 
                                @level1type=N'TABLE',@level1name=N'KaAssistenz', 
                                @level2type=N'COLUMN',@level2name=N'Austrittsdatum'
GO
EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz erstellt hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KaAssistenz', 
                                @level2type = N'COLUMN', @level2name = N'Creator';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz erstellt wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KaAssistenz', 
                                @level2type = N'COLUMN', @level2name = N'Created';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Angaben zum Benutzer, welcher den Datensatz zuletzt geändert hat' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KaAssistenz', 
                                @level2type = N'COLUMN', @level2name = N'Modifier';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Wann der Datensatz zuletzt geändert wurde' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KaAssistenz', 
                                @level2type = N'COLUMN', @level2name = N'Modified';
GO

EXEC sys.sp_addextendedproperty @name = N'MS_Description', @value = N'Timestamp des Eintrags - wird für die Änderungsverfolgung benötigt (optimistic locking)' , 
                                @level0type = N'SCHEMA', @level0name = N'dbo', 
                                @level1type = N'TABLE', @level1name = N'KaAssistenz', 
                                @level2type = N'COLUMN', @level2name = N'KaAssistenzTS';
GO

-------------------------------------------------------------------------------
-- defaults
-------------------------------------------------------------------------------
ALTER TABLE [dbo].[KaAssistenz] ADD  CONSTRAINT [DF_KaAssistenz_Abgemeldet]  DEFAULT ((0)) FOR [Abgemeldet]
GO

ALTER TABLE [dbo].[KaAssistenz] ADD  CONSTRAINT [DF_KaAssistenz_NichtErschienen]  DEFAULT ((0)) FOR [NichtErschienen]
GO

ALTER TABLE [dbo].[KaAssistenz] ADD  CONSTRAINT [DF_KaAssistenz_GespraechStattgefunden]  DEFAULT ((0)) FOR [GespraechStattgefunden]
GO

ALTER TABLE [dbo].[KaAssistenz] ADD  CONSTRAINT [DF_KaAssistenz_Programmbeginn]  DEFAULT ((0)) FOR [Programmbeginn]
GO

ALTER TABLE [dbo].[KaAssistenz] ADD  CONSTRAINT [DF_KaAssistenz_Personalien]  DEFAULT ((0)) FOR [Personalien]
GO

ALTER TABLE [dbo].[KaAssistenz] ADD  CONSTRAINT [DF_KaAssistenz_Vereinbarung]  DEFAULT ((0)) FOR [Vereinbarung]
GO

ALTER TABLE [dbo].[KaAssistenz] ADD  CONSTRAINT [DF_KaAssistenz_Zielvereinbarung]  DEFAULT ((0)) FOR [Zielvereinbarung]
GO

ALTER TABLE [dbo].[KaAssistenz] ADD  CONSTRAINT [DF_KaAssistenz_Schlussbericht]  DEFAULT ((0)) FOR [Schlussbericht]
GO

ALTER TABLE [dbo].[KaAssistenz] ADD  CONSTRAINT [DF_KaAssistenz_Testat]  DEFAULT ((0)) FOR [Testat]
GO

ALTER TABLE [dbo].[KaAssistenz] ADD CONSTRAINT [DF_KaAssistenz_Created] DEFAULT (GETDATE()) FOR [Created];
GO

ALTER TABLE [dbo].[KaAssistenz] ADD CONSTRAINT [DF_KaAssistenz_Modified] DEFAULT (GETDATE()) FOR [Modified];
GO

ALTER TABLE [dbo].[KaAssistenz] WITH CHECK ADD  CONSTRAINT [FK_KaAssistenz_FaLeistung] FOREIGN KEY([FaLeistungID])
REFERENCES [dbo].[FaLeistung] ([FaLeistungID])
GO

ALTER TABLE [dbo].[KaAssistenz] CHECK CONSTRAINT [FK_KaAssistenz_FaLeistung]
GO

