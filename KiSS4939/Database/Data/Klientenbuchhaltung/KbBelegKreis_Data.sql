﻿SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [KbBelegKreis]
GO
SET IDENTITY_INSERT [KbBelegKreis] ON
GO
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (1, 11, 1, N'9999.999', 2, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (7, 11, 4, NULL, 500001, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (8, 11, 7, NULL, 600001, 600001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (9, 11, 3, NULL, 700001, 700001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (10, 11, 2, NULL, 800001, 800001, 9999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (11, 21, 6, NULL, 1, 1, 10000)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (12, 21, 1, N'1001.301', 10001, 10001, 49999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (13, 21, 5, NULL, 50001, 50001, 999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (14, 12, 1, N'9999.999', 84, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (20, 12, 4, NULL, 500001, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (21, 12, 7, NULL, 600001, 600001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (22, 12, 3, NULL, 704670, 700001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (23, 12, 2, NULL, 800001, 800001, 9999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (24, 13, 1, N'9999.999', 87, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (30, 13, 4, NULL, 500001, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (31, 13, 7, NULL, 600001, 600001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (32, 13, 3, NULL, 705543, 700001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (33, 13, 2, NULL, 800001, 800001, 9999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (34, 14, 1, N'9999.999', 61, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (40, 14, 4, NULL, 500001, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (41, 14, 7, NULL, 600001, 600001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (42, 14, 3, NULL, 706645, 700001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (43, 14, 2, NULL, 800001, 800001, 9999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (44, 15, 1, N'9999.999', 108, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (50, 15, 4, NULL, 500001, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (51, 15, 7, NULL, 600001, 600001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (52, 15, 3, NULL, 707595, 700001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (53, 15, 2, NULL, 800001, 800001, 9999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (54, 16, 1, N'9999.999', 95, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (60, 16, 4, NULL, 500001, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (61, 16, 7, NULL, 600001, 600001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (62, 16, 3, NULL, 708889, 700001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (63, 16, 2, NULL, 800001, 800001, 9999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (64, 17, 1, N'9999.999', 104, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (70, 17, 4, NULL, 500001, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (71, 17, 7, NULL, 600001, 600001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (72, 17, 3, NULL, 710188, 700001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (73, 17, 2, NULL, 800001, 800001, 9999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (74, 18, 1, N'9999.999', 107, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (80, 18, 4, NULL, 500001, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (81, 18, 7, NULL, 600001, 600001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (82, 18, 3, NULL, 711243, 700001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (83, 18, 2, NULL, 800001, 800001, 9999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (84, 19, 1, N'9999.999', 52, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (90, 19, 4, NULL, 500001, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (91, 19, 7, NULL, 600001, 600001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (92, 19, 3, NULL, 703027, 700001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (93, 19, 2, NULL, 800001, 800001, 9999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (94, 22, 6, NULL, 1, 1, 10000)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (95, 22, 1, N'1001.301', 10001, 10001, 49999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (96, 22, 5, NULL, 50001, 50001, 999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (97, 23, 6, NULL, 1, 1, 10000)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (98, 23, 1, N'1001.301', 10001, 10001, 49999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (99, 23, 5, NULL, 50001, 50001, 999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (100, 24, 6, NULL, 1, 1, 10000)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (101, 24, 1, N'1001.301', 10001, 10001, 49999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (102, 24, 5, NULL, 50001, 50001, 999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (103, 30, 1, N'1001.301', 3363, 1, 79999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (104, 30, 1, N'1000.301', 80012, 80001, 89999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (105, 30, 1, N'1002.302', 90086, 90001, 99999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (106, 30, 1, N'1001.336', 106095, 100001, 299999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (107, 30, 1, N'1001.306', 303176, 300001, 399999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (108, 30, 1, N'1001.308', 401735, 400001, 499999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (109, 30, 4, NULL, 591129, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (110, 30, 7, NULL, 697249, 600001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (111, 30, 3, NULL, 3005175, 3000001, 3299999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (112, 30, 2, NULL, 847812, 800001, 2999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (113, 31, 6, NULL, 39, 1, 10000)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (114, 31, 1, N'1001.301', 10001, 10001, 49999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (115, 31, 5, NULL, 52684, 50001, 999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (117, 31, 7, NULL, 102527, 100001, 199999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (118, 31, 1, N'1001.309', 20001, 20001, 29999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (119, 30, 8, NULL, 5000027, 5000001, 5999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (120, 31, 8, NULL, 200040, 200001, 299999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (121, 32, 6, NULL, 1, 1, 10000)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (122, 32, 1, N'1001.301', 10001, 10001, 49999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (123, 32, 5, NULL, 52852, 50001, 999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (124, 32, 7, NULL, 102848, 100001, 199999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (125, 32, 1, N'1001.309', 20001, 20001, 29999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (126, 32, 8, NULL, 200002, 200001, 299999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (127, 33, 1, N'1001.301', 7212, 1, 9999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (128, 33, 1, N'1000.301', 82465, 80001, 89999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (129, 33, 1, N'1002.302', 90133, 90001, 99999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (130, 33, 1, N'1001.336', 108919, 100001, 199999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (131, 33, 1, N'1001.306', 305460, 300001, 399999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (132, 33, 1, N'1001.308', 405212, 400001, 499999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (133, 33, 4, NULL, 590677, 500001, 599999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (134, 33, 7, NULL, 759948, 600001, 799999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (135, 33, 3, NULL, 3008755, 3000001, 3299999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (136, 33, 2, NULL, 876221, 800001, 2999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (137, 33, 8, NULL, 5000020, 5000001, 5999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (138, 35, 6, NULL, 1, 1, 10000)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (139, 35, 1, N'1001.301', 10001, 10001, 49999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (140, 35, 5, NULL, 50001, 50001, 999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (141, 36, 1, N'1001.301', 2826, 1, 19999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (142, 36, 1, N'1000.301', 84753, 80001, 98999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (143, 36, 1, N'1002.302', 99058, 99001, 99999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (144, 36, 1, N'1001.336', 103463, 100001, 199999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (145, 36, 1, N'1001.306', 302233, 300001, 399999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (146, 36, 1, N'1001.308', 400733, 400001, 499999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (147, 36, 4, NULL, 698237, 500001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (148, 36, 7, NULL, 1070509, 1000001, 1999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (149, 36, 3, NULL, 3003639, 3000001, 3299999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (150, 36, 2, NULL, 831560, 800001, 999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (151, 36, 8, NULL, 5000012, 5000001, 5999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (152, 37, 6, NULL, 1, 1, 10000)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (153, 37, 1, N'1001.301', 10001, 10001, 49999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (154, 37, 5, NULL, 51770, 50001, 59999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (155, 37, 7, NULL, 102116, 100001, 199999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (156, 37, 1, N'1001.309', 20001, 20001, 29999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (157, 37, 8, NULL, 200004, 200001, 299999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (158, 37, 1, N'1000.301', 80385, 80001, 99999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (159, 38, 1, N'1001.301', 1, 1, 19999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (160, 38, 1, N'1000.301', 80001, 80001, 98999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (161, 38, 1, N'1002.302', 99001, 99001, 99999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (162, 38, 1, N'1001.336', 100001, 100001, 199999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (163, 38, 1, N'1001.306', 300001, 300001, 399999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (164, 38, 1, N'1001.308', 400001, 400001, 499999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (165, 38, 4, NULL, 500001, 500001, 699999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (166, 38, 7, NULL, 1000001, 1000001, 1999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (167, 38, 3, NULL, 3000001, 3000001, 3299999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (168, 38, 2, NULL, 800001, 800001, 999999)
INSERT INTO [KbBelegKreis] ([KbBelegKreisID], [KbPeriodeID], [KbBelegKreisCode], [KontoNr], [NaechsteBelegNr], [BelegNrVon], [BelegNrBis]) VALUES (169, 38, 8, NULL, 5000001, 5000001, 5999999)
GO
SET IDENTITY_INSERT [KbBelegKreis] OFF
GO
COMMIT
GO