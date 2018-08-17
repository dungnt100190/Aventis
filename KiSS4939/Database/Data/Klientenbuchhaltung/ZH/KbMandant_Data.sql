SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [KbMandant]
GO
SET IDENTITY_INSERT [KbMandant] ON
GO
INSERT INTO [KbMandant] ([KbMandantID], [Mandant], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (1, N'Wirtschaftliche Hilfe', CONVERT(datetime, '20070101', 112), NULL, 1)
GO
SET IDENTITY_INSERT [KbMandant] OFF
GO
COMMIT
GO