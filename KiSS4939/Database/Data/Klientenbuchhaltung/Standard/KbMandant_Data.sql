SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [KbMandant]
GO
SET IDENTITY_INSERT [KbMandant] ON
GO
INSERT INTO [KbMandant] ([KbMandantID], [Mandant]) VALUES (-6, N'Asylkoordination (ARCHIV)')
INSERT INTO [KbMandant] ([KbMandantID], [Mandant]) VALUES (-1, N'Klientenbuchhaltung (ARCHIV)')
INSERT INTO [KbMandant] ([KbMandantID], [Mandant]) VALUES (1, N'Klientenbuchhaltung')
INSERT INTO [KbMandant] ([KbMandantID], [Mandant]) VALUES (6, N'Asylkoordination')
INSERT INTO [KbMandant] ([KbMandantID], [Mandant]) VALUES (99, N'Testmandant')
GO
SET IDENTITY_INSERT [KbMandant] OFF
GO
COMMIT
GO 