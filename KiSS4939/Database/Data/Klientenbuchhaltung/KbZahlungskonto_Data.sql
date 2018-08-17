SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [KbZahlungskonto]
GO
SET IDENTITY_INSERT [KbZahlungskonto] ON
GO
INSERT INTO [KbZahlungskonto] ([KbZahlungskontoID], [Name], [VertragNr], [KontoNr], [BaBankID], [KbFinanzInstitutCode]) VALUES (1, N'Direktion für Bildung, Soziales und Sport', N'10019675', N'30-823-3', NULL, 0)
GO
SET IDENTITY_INSERT [KbZahlungskonto] OFF
GO
COMMIT
GO