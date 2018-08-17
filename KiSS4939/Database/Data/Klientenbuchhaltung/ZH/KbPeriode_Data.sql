SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [KbPeriode]
GO
SET IDENTITY_INSERT [KbPeriode] ON
GO
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantCode], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (1, 1, CONVERT(datetime, '20070101', 112), CONVERT(datetime, '20071231', 112), 1)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantCode], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (2, 1, CONVERT(datetime, '20080101', 112), CONVERT(datetime, '20081231', 112), 1)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantCode], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (3, 1, CONVERT(datetime, '20090101', 112), CONVERT(datetime, '20091231', 112), 1)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantCode], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (4, 1, CONVERT(datetime, '20100101', 112), CONVERT(datetime, '20101231', 112), 1)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantCode], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (5, 1, CONVERT(datetime, '20110101', 112), CONVERT(datetime, '20111231', 112), 1)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantCode], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (6, 1, CONVERT(datetime, '20120101', 112), CONVERT(datetime, '20121231', 112), 1)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantCode], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (7, 1, CONVERT(datetime, '20130101', 112), CONVERT(datetime, '20131231', 112), 1)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantCode], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (8, 1, CONVERT(datetime, '20140101', 112), CONVERT(datetime, '20141231', 112), 1)
INSERT INTO [KbPeriode] ([KbPeriodeID], [KbMandantCode], [PeriodeVon], [PeriodeBis], [PeriodeStatusCode]) VALUES (9, 1, CONVERT(datetime, '20150101', 112), CONVERT(datetime, '20151231', 112), 1)
GO
SET IDENTITY_INSERT [KbPeriode] OFF
GO
COMMIT
GO