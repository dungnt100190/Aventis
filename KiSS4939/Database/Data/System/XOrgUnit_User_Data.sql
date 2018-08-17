﻿SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [XOrgUnit_User] WHERE UserID IN (SELECT UserID FROM XUser WHERE IsUserAdmin=1)
GO
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (5, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (5, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (5, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (5, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (6, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (6, 204, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (6, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (6, 2071, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (10, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (11, 1, 2, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (11, 4, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (11, 202, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (11, 204, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (13, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (13, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (18, 1, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (18, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (18, 202, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (18, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (18, 473, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (18, 2004, 2, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (18, 2071, 2, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (18, 2073, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (18, 2076, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (19, 1, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (19, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (19, 202, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (19, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (19, 473, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (19, 2081, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (20, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (20, 202, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (20, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (20, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (21, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (21, 202, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (21, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (22, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (22, 202, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (22, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (23, 202, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (24, 1, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (24, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (24, 202, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (24, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (24, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (24, 2002, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (24, 2076, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (24, 2081, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (24, 2085, 2, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (26, 4, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (26, 164, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (26, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (26, 2076, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (29, 2076, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (34, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (35, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (35, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (36, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (36, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (37, 4, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (37, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (37, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (39, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (39, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (39, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (43, 164, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (43, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (43, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (44, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (44, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (44, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (44, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (49, 4, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (49, 164, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (49, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (49, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (49, 2076, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (55, 4, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (55, 164, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (55, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (57, 2071, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (63, 4, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (63, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (66, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (86, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (86, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (86, 670, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (86, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (89, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (89, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (89, 670, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (89, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (91, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (91, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (91, 670, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (91, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (93, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (93, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (93, 670, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (93, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (95, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (95, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (95, 670, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (95, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (96, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (96, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (96, 670, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (96, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (97, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (97, 473, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (97, 670, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (97, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (97, 2076, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 4, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 473, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2000, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2001, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2006, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2008, 2, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2009, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2071, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2072, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2073, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2075, 2, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (102, 2082, 2, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (103, 670, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (103, 2002, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (104, 670, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (105, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (105, 2076, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (107, 204, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (108, 4, 3, 1, 1, 1)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (110, 2000, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (110, 2001, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (110, 2071, 3, 0, 0, 0)
INSERT INTO [XOrgUnit_User] ([OrgUnitID], [UserID], [OrgUnitMemberCode], [MayInsert], [MayUpdate], [MayDelete]) VALUES (110, 2073, 3, 0, 0, 0)
GO
COMMIT
GO