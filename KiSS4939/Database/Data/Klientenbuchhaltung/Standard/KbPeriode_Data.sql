SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [KbPeriode]
GO
SET IDENTITY_INSERT [KbPeriode] ON
GO
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (1, -1, CONVERT(datetime, '20000101', 112), CONVERT(datetime, '20001231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (2, -1, CONVERT(datetime, '20010101', 112), CONVERT(datetime, '20011231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (3, -1, CONVERT(datetime, '20020101', 112), CONVERT(datetime, '20021231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (4, -1, CONVERT(datetime, '20030101', 112), CONVERT(datetime, '20031231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (5, -1, CONVERT(datetime, '20040101', 112), CONVERT(datetime, '20041231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (6, -1, CONVERT(datetime, '20050101', 112), CONVERT(datetime, '20051231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (7, -1, CONVERT(datetime, '20060101', 112), CONVERT(datetime, '20061231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (8, -1, CONVERT(datetime, '20070101', 112), CONVERT(datetime, '20071231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (9, -1, CONVERT(datetime, '20080101', 112), CONVERT(datetime, '20080331', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (11, 1, CONVERT(datetime, '20000101', 112), CONVERT(datetime, '20001231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (12, 1, CONVERT(datetime, '20010101', 112), CONVERT(datetime, '20011231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (13, 1, CONVERT(datetime, '20020101', 112), CONVERT(datetime, '20021231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (14, 1, CONVERT(datetime, '20030101', 112), CONVERT(datetime, '20031231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (15, 1, CONVERT(datetime, '20040101', 112), CONVERT(datetime, '20041231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (16, 1, CONVERT(datetime, '20050101', 112), CONVERT(datetime, '20051231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (17, 1, CONVERT(datetime, '20060101', 112), CONVERT(datetime, '20061231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (18, 1, CONVERT(datetime, '20070101', 112), CONVERT(datetime, '20071231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (19, 1, CONVERT(datetime, '20080101', 112), CONVERT(datetime, '20080430', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (21, -6, CONVERT(datetime, '20050101', 112), CONVERT(datetime, '20051231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (22, -6, CONVERT(datetime, '20060101', 112), CONVERT(datetime, '20061231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (23, -6, CONVERT(datetime, '20070101', 112), CONVERT(datetime, '20071231', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (24, -6, CONVERT(datetime, '20080101', 112), CONVERT(datetime, '20080331', 112), 3, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (30, 1, CONVERT(datetime, '20080501', 112), CONVERT(datetime, '20081231', 112), 2, CONVERT(datetime, '20080502', 112))
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (31, 6, CONVERT(datetime, '20080501', 112), CONVERT(datetime, '20081231', 112), 2, CONVERT(datetime, '20080502', 112))
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (32, 6, CONVERT(datetime, '20090101', 112), CONVERT(datetime, '20091231', 112), 2, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (33, 1, CONVERT(datetime, '20090101', 112), CONVERT(datetime, '20091231', 112), 2, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (34, -1, CONVERT(datetime, '20090101', 112), CONVERT(datetime, '20091231', 112), 1, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (35, -6, CONVERT(datetime, '20110101', 112), CONVERT(datetime, '20111231', 112), 1, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (36, 1, CONVERT(datetime, '20100101', 112), CONVERT(datetime, '20101231', 112), 2, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (37, 6, CONVERT(datetime, '20100101', 112), CONVERT(datetime, '20101231', 112), 1, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (38, 1, CONVERT(datetime, '20110101', 112), CONVERT(datetime, '20111231', 112), 1, NULL)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantID], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode], [VerbuchtBis]) VALUES (39, 6, CONVERT(datetime, '20110101', 112), CONVERT(datetime, '20111231', 112), 1, NULL)
GO
SET IDENTITY_INSERT [KbPeriode] OFF
GO
COMMIT
GO