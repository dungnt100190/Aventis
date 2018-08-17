CREATE TABLE [dbo].[KaArbeitsrapport](
	[KaArbeitsrapportID] [int] IDENTITY(1,1) NOT NULL,
	[BaPersonID] [int] NOT NULL,
	[KaEinsatzID] [int] NOT NULL,
	[Datum] [datetime] NULL,
	[AM_AnwCode] [int] NULL,
	[AM_Std] [real] NULL,
	[AM_Bemerkung] [varchar](max) NULL,
	[PM_AnwCode] [int] NULL,
	[PM_Std] [real] NULL,
	[PM_Bemerkung] [varchar](max) NULL,
	[SichtbarSDFlag] [bit] NOT NULL,
	[KaArbeitsrapportTS] [timestamp] NOT NULL,
 CONSTRAINT [PK_KaArbeitsrapport] PRIMARY KEY CLUSTERED 
(
	[KaArbeitsrapportID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]

GO

SET ANSI_PADDING ON
GO

CREATE NONCLUSTERED INDEX [IX_KaArbeitsrapport_BaPersonID] ON [dbo].[KaArbeitsrapport] 
(
	[BaPersonID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

CREATE NONCLUSTERED INDEX [IX_KaArbeitsrapport_KaEinsatzID] ON [dbo].[KaArbeitsrapport] 
(
	[KaEinsatzID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Prim�rschl�ssel f�r KaArbeitsrapport Records (nach Prim�rschl�ssel-Standards)' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'KaArbeitsrapportID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschl�ssel (FK_KaArbeitsrapport_BaPerson) => BaPerson.BaPersonID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'BaPersonID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Fremdschl�ssel (TODO) => KaEinsatz.KaEinsatzID' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'KaEinsatzID'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Tag f�r die Erfassung der Pr�senzzeit' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Es wird im Code automatisch f�r jeden Tag ein Eintrag erstellt mit DatumVon und DatumBis von KaEinsatz.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'Datum'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code Vormittag aus Werteliste KaPraesenzCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'AM_AnwCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stunden f�r den Vormittag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'AM_Std'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung f�r den Vormittag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'AM_Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Code Nachmittag aus Werteliste KaPraesenzCode' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'PM_AnwCode'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Stunden f�r den Nachmittag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'PM_Std'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Bemerkung f�r den Nachmittag' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'PM_Bemerkung'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Flag zur Steuerung der Sichtbarkeit f�r den SD Bern' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'SichtbarSDFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'Remarks', @value=N'Wenn das Flag auf 1 gesetzt ist, so k�nnen nur Mitarbeiter vom KA den Eintrag sehen.  Das Flag wird pro Eintrag gesetzt, weil es sein kann dass der SD ein paar der Eintr�ge sehen darf.    Bezieht sich nur auf die Sichtbarkeit des Eintrages und nicht der Person.    Wird im Personenstamm oder beim er�ffnen einer Phase im Modul KA gesetzt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'SichtbarSDFlag'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Timestamp f�r Tabelle KaArbeitsrapport' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport', @level2type=N'COLUMN',@level2name=N'KaArbeitsrapportTS'
GO

EXEC sys.sp_addextendedproperty @name=N'Author', @value=N'Leonhard Greulich' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport'
GO

EXEC sys.sp_addextendedproperty @name=N'Customer_only', @value=N'Kunde ist Kompetenzzentrum f�r Arbeit (KA). KiSS wird zusammen mit SD Bern benutzt.' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport'
GO

EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'Daten der Pr�senzzeiterfassung' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport'
GO

EXEC sys.sp_addextendedproperty @name=N'Used_in', @value=N'Modul KA' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'KaArbeitsrapport'
GO

ALTER TABLE [dbo].[KaArbeitsrapport]  WITH CHECK ADD  CONSTRAINT [FK_KaArbeitsrapport_BaPerson] FOREIGN KEY([BaPersonID])
REFERENCES [dbo].[BaPerson] ([BaPersonID])
GO

ALTER TABLE [dbo].[KaArbeitsrapport] CHECK CONSTRAINT [FK_KaArbeitsrapport_BaPerson]
GO

ALTER TABLE [dbo].[KaArbeitsrapport]  WITH NOCHECK ADD  CONSTRAINT [FK_KaArbeitsrapport_KaEinsatz] FOREIGN KEY([KaEinsatzID])
REFERENCES [dbo].[KaEinsatz] ([KaEinsatzID])
GO

ALTER TABLE [dbo].[KaArbeitsrapport] CHECK CONSTRAINT [FK_KaArbeitsrapport_KaEinsatz]
GO

ALTER TABLE [dbo].[KaArbeitsrapport] ADD  CONSTRAINT [DF__KaArbeits__Sicht__0334AB99]  DEFAULT ((0)) FOR [SichtbarSDFlag]
GO