SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [PscdKeySource]
GO
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'AA', 12000000000, 12000000000, 12999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'AK', 30000000000, 30000000000, 30999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'ALBV', 2000001, 2000001, 2999999, N'VG')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'E7', 57000000000, 57000000000, 57999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'E9', 59000000000, 59000000000, 59999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'IK', 56000000000, 56000000000, 56999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'INKW', 3000000, 3000000, 3999999, N'VG')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'KG', 1, 1, 999999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'MG', 51000000000, 51000000000, 51999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'PYGRP', 1, 1, 99999999, N'Umbuchung')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'S2', 52000000000, 52000000000, 52999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'S3', 53000000000, 53000000000, 53999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'S4', 54000000000, 54000000000, 54999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'S5', 55000000000, 55000000000, 55999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'ST', 1000000001, 1000000001, 1999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'TRANS', 1, 1, 999999999999, N'Trans')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'UB', 28000000000, 28000000000, 28999999999, N'Beleg')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'WSH1', 1000001, 1000001, 1999999, N'VG')
INSERT INTO [PscdKeySource] ([KeyName], [NextID], [FirstID], [LastID], [NumberCategory]) VALUES (N'WV', 60000000000, 60000000000, 60999999999, N'Beleg')
GO
COMMIT
GO