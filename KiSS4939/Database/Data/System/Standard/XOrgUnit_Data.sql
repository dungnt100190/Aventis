SET NOCOUNT ON
BEGIN TRANSACTION
GO
DISABLE TRIGGER trHist_XOrgUnit ON XOrgUnit;
GO
DELETE FROM [XOrgUnit]
GO
SET IDENTITY_INSERT [XOrgUnit] ON
GO
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (5, 29, 3, N'IDZS', NULL, N'Fax 031 321 72 72', N'inkassodienst.bss@bern.ch', N'www.bern.ch', 4, 4, 2027, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl280\slmult0\expndtw6\f0\fs18 Sozialamt\par
\pard\sl240\slmult0 Inkassodienst/Zentralsekretariat\par
Predigergasse 5, Postfach 573\par
3000 Bern 7\par
\pard\expndtw0\f1\par
}', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl280\slmult0\expndtw8\f0\fs20 M. Kunkler\par
Bereichsleiter\par
\pard\expndtw0\f1\fs18\par
}', N'', N'', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl240\slmult0\expndtw6\f0\fs18 Predigergasse 5\par
Postfach 573\par
\pard 3000 Bern 7\expndtw0\f1\fs20\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (6, 29, 1, N'KI', NULL, NULL, NULL, NULL, 6, 6, 400, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (7, 29, 2, N'EKS', NULL, NULL, NULL, NULL, 5, 5, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Amt f\''fcr Erwachsenen- und Kindesschutz\par
Predigergasse 10\par
3011 Bern\fs22\par
\b\par
}
', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (8, 29, 10, N'Kursraum 316', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (10, 7, 8, N'EKS Behördensekretariat', N'031 321 67 57', N'031 321 72 70', NULL, NULL, 5, 5, 180, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Erwachsenen- und Kindesschutzkommission\par
Beh\''f6rdensekretariat\par
Predigergasse 10, Postfach 292\par
3000 Bern 7\par
}
', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (11, 29, 6, N'DFD', N'031 321 63 27', N'031 321 69 90', NULL, NULL, 3, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (13, 30, 11, N'SD BL/ZA West', NULL, NULL, NULL, NULL, 3, 3, 758, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst West\par
Frankenstrasse 1, Postfach 712\par
3018 Bern\par
\par
Telefon 031 997 88 88\par
Fax 031 997 88 89\par
\pard www.bern.ch\par
}', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Frankenstrasse 1\par
Postfach 712\par
3018 Bern\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (18, 30, 4, N'Team B', NULL, NULL, NULL, NULL, 3, NULL, 90, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst\par
Predigergasse 10, Postfach 579\par
3000 Bern 7\par
\par
\par
Fax 031 321 72 54\par
www.bern.ch\par
}
', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10\par
Postfach 579\par
3000 Bern 7\par
}
', 624, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (19, 30, 5, N'Fachstelle', NULL, NULL, NULL, NULL, 3, 3, 103, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst\par
Predigergasse 10, Postfach 579\par
3000 Bern 7\par
\par
Fax 031 321 72 54\par
www.bern.ch\par
}
', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10\par
Postfach 579\par
3000 Bern 7\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (20, 30, 6, N'Team A', NULL, NULL, NULL, NULL, 3, 3, 358, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst\par
Predigergasse 10, Postfach 579\par
3000 Bern 7\par
\par
\par
Fax 031 321 72 54\par
www.bern.ch\par
}
', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10\par
Postfach 579\par
3000 Bern 7\fs18\par
\fs20\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (21, 30, 7, N'Team C', NULL, NULL, NULL, NULL, 3, 3, 332, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst West\par
Frankenstrasse 1, Postfach 712\par
3018 Bern\par
\par
Telefon 031 997 88 88\par
Fax 031 997 88 89\par
www.bern.ch\par
}
', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Frankenstrasse 1\par
Postfach 712\par
3018 Bern\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (22, 30, 8, N'Team D', NULL, NULL, NULL, NULL, 3, 3, 501, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst West\par
Frankenstrasse 1, Postfach 712\par
3018 Bern\par
\par
Telefon 031 997 88 88\par
Fax 031 997 88 89\par
www.bern.ch\par
}
', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Frankenstrasse 1\par
Postfach 712\par
3018 Bern\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (23, 29, 7, N'Stab', NULL, NULL, NULL, NULL, 3, 3, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (24, 30, 3, N'Intake', NULL, NULL, NULL, NULL, 3, 3, 426, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst\par
Predigergasse 10, Postfach 579\par
3000 Bern 7\par
\par
\par
Fax 031 321 72 54\par
www.bern.ch\par
}
', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10\par
Postfach 579\par
3000 Bern 7\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (25, NULL, NULL, N'Ehemalige MIA', NULL, NULL, NULL, NULL, NULL, NULL, 2000, N'', N'', N'', N'', N'', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (26, 7, 7, N'EKS Intake Center', NULL, N'031 321 72 70', NULL, NULL, 5, 5, 350, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Amt f\''fcr Erwachsenen - und Kindesschutz\par
Bereich Intake Center\par
Predigergasse 10 \par
Postfach 427\par
3000 Bern 7\par
}
', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10 \par
Postfach 427\par
3000 Bern 7\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (28, 29, 4, N'Jugendamt', NULL, NULL, NULL, N'www.bern.ch', 0, 0, 438, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (29, NULL, NULL, N'BSS', NULL, NULL, NULL, NULL, NULL, NULL, 2001, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (30, 29, 5, N'Sozialdienst', NULL, NULL, NULL, NULL, 3, 3, 758, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (34, 7, 1, N'EKS Erbschaftsamt', NULL, N'031 321 75 00', NULL, NULL, 5, 5, 474, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (35, 34, 1, N'EA Siegelung', NULL, N'031 321 75 00', NULL, NULL, 5, 5, 481, N'{\rtf1\ansi\ansicpg1252\deff0\deflang1033{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 asdf\par
}', NULL, NULL, NULL, NULL, 745, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (36, 34, 2, N'EA Testamentsdienst', NULL, N'031 321 75 00', NULL, NULL, 5, 5, 481, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (37, 34, 3, N'Erbschaftsdienst', NULL, N'031 321 75 00', NULL, NULL, 5, 5, 481, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (38, 7, 11, N'EKSK', NULL, NULL, NULL, NULL, 5, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (39, 28, 1, N'JA Team 2', N'031 321 67 50', N'031 321 67 74', N'beratungsstellejugendamt@bern.ch', N'www.bern.ch', 3, 3, 438, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl240\slmult0\expndtw6\f0\fs18 Jugendamt\par
Beratungsstelle Bern-Stadt\par
Effingerstrasse 21\par
\pard\sl280\slmult0 Postfach 3001 Bern\expndtw0\f1\par
}', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl280\slmult0\expndtw8\f0\fs20 Jugendamt\par
Beratungsstelle Bern-Stadt\par
Effingerstrasse 21\par
Postfach 3001 Bern\expndtw0\f1\fs18\par
}', NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl240\slmult0\expndtw6\fs20 Effingerstrasse 21\par
\pard Postfach\par
3001 Bern\expndtw0\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (43, 7, 4, N'EKS SC & MC, Team B', NULL, N'031 321 72 71', NULL, NULL, 5, 5, 164, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Amt f\''fcr Erwachsenen- und Kindesschutz\par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Predigergasse 10, Postfach 154\par
3000 Bern 7\par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 EKS (Amt f\''fcr Erwachsenen- und Kindesschutz), Postfach 154, 3000 Bern 7\fs18\par
}', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 PC Konto-Nr. 30-742556-1\fs18\par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10\par
Postfach 154\par
3000 Bern 7\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (44, 28, 2, N'JA Team 3', N'031 991 96 47', N'031 991 86 57', N'beratungsstellejugendamt@bern.ch', N'www.bern.ch', 3, 3, 438, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl240\slmult0\expndtw6\f0\fs18 Jugendamt\par
Beratungsstelle Bern-West\par
Frankenstrasse 1\par
Postfach 3018 Bern\expndtw0\f1\par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}{\f1\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl280\slmult0\expndtw8\f0\fs20 Jugendamt\par
Beratungsstelle Bern-West\par
Frankenstrasse 1\par
Postfach 3018 Bern\expndtw0\f1\fs18\par
}', NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl240\slmult0\expndtw6\fs20 Frankenstrasse 1\par
\pard Postfach \par
3018 Bern\expndtw0\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (47, 7, 10, N'EKS GL', NULL, N'031 321 72 71', NULL, NULL, 5, 5, 319, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Amt f\''fcr Erwachsenen- und Kindesschutz\par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Predigergasse 10, Postfach 138\par
\pard 3000 Bern 7\par
}', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 EKS (Amt f\''fcr Erwachsenen- und Kindesschutz), Postfach 138, 3000 Bern 7\fs18\par
}', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Postkonto 30-693796-2\fs18\par
}', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10\par
Postfach 138\par
3000 Bern 7\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (49, 7, 6, N'EKS SC & MC, Team A', NULL, N'031 321 72 71', NULL, NULL, 5, 5, 164, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Amt f\''fcr Erwachsenen- und Kindesschutz \par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Predigergasse 10, Postfach 138\par
3000 Bern 7\par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 EKS (Amt f\''fcr Erwachsenen- und Kindesschutz), Postfach 138, 3000 Bern 7\fs18\par
}', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 PC Konto-Nr. 30-693796-2\fs18\par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10\par
Postfach 138\par
3000 Bern 7\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (52, 25, 4, N'Ehemalige ID ZS', NULL, NULL, NULL, NULL, 4, 4, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (53, 25, 5, N'Ehemalige JA', NULL, NULL, NULL, NULL, 0, 0, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (54, 25, 1, N'Ehemalige KI', NULL, NULL, NULL, NULL, 6, 6, NULL, N'', N'', N'', N'', N'', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (55, 7, 9, N'EKS Vaterschaften', NULL, N'031 321 72 71', NULL, NULL, 5, 5, 164, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Amt f\''fcr Erwachsenen- und Kindesschutz\fs18\par
}
', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10, Postfach 138\par
\pard 3000 Bern 7\fs18\par
}', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 EKS (Amt f\''fcr Erwachsenen- und Kindesschutz), Postfach 138, 3000 Bern 7\fs18\par
}', NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10\par
Postfach 138\par
\pard 3000 Bern 7\fs20\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (57, 25, 3, N'Ehemalige EKS', NULL, NULL, NULL, NULL, 5, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (60, 30, 10, N'SD BL/ZA Stadt', NULL, NULL, NULL, NULL, 3, 3, 758, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst\par
Predigergasse 10, Postfach 579\par
3000 Bern 7\par
\par
Telefon 031 321 60 27\par
Fax 031 321 72 54\par
\pard www.bern.ch\par
}', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Predigergasse 10\par
Postfach 579\par
3000 Bern 7\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (61, 7, 12, N'EKS PriMa', NULL, N'031 321 72 70', NULL, NULL, 5, 5, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (63, 28, 3, N'JA Team 1', N'031 321 67 50', N'031 321 67 74', N'beratungsstellejugendamt@bern.ch', N'www.bern.ch', 3, 3, 438, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fswiss\fprq2\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\sl240\slmult0\expndtw6\f0\fs18 Jugendamt\par
Beratungsstelle Bern-Stadt\par
Effingerstrasse 21\par
\pard Postfach 3001 Bern\expndtw0\f1\fs20\par
}
', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\sl240\slmult0\expndtw6\fs20 Effingerstrasse 21\par
\pard Postfach \par
3001 Bern\expndtw0\par
}
', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (66, 30, 12, N'Ehemalige Sozialdienst', NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (85, 29, 11, N'KA', N'031 321 62 72', N'031 321 62 70', N'kompetenzzentrum-arbeit@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 668, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs18 Kompetenzzentrum Arbeit KA\par
Lorrainestrasse 52\par
Postfach 3001 Bern \par
\pard\f1\fs20\par
}
', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (86, 85, 1, N'KA Abklärung', N'031 321 62 72', N'031 321 62 70', N'kompetenzzentrum-arbeit@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 684, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs18 Kompetenzzentrum Arbeit KA\par
Abkl\''e4rung\par
Lorrainestrasse 52\par
\pard Postfach 3001 Bern \f1\fs20\par
}
', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (88, 85, 2, N'KA Qualifizierung Erwachsene', N'031 321 62 72', N'031 321 62 70', N'kompetenzzentrum-arbeit@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 654, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs18 Kompetenzzentrum Arbeit KA\par
Qualifizierung Erwachsene\par
Lorrainestrasse 52\par
Postfach 3001 Bern \fs20\par
\pard\f1\par
}
', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (89, 88, 1, N'EPQ', N'031 321 62 72', N'031 321 62 70', N'kompetenzzentrum-arbeit@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 654, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs18 Kompetenzzentrum Arbeit KA\par
Qualifizierung Erwachsene\par
Lorrainestrasse 52\par
Postfach 3001 Bern \f1\fs20\par
}', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (91, 88, 2, N'Jobtimum', N'031 321 78 93', N'031 321 62 70', N'kompetenzzentrum-arbeit@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 711, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs18 Kompetenzzentrum Arbeit KA\par
Qualifizierung Erwachsene/berufliche Integration\par
Lorrainestrasse 52\par
Postfach 3001 Bern \f1\fs20\par
}', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (92, 85, 3, N'KA Qualifizierung Jugend', NULL, NULL, NULL, NULL, 7, 7, 693, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs20 Kompetenzzentrum Arbeit KA\par
Qualifizierung Jugend\fs18\par
Lorrainestrasse 52\par
\pard Postfach 3001 Bern \f1\fs20\par
}
', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (93, 92, 1, N'Freiburgstrasse', N'031 321 78 80', N'031 321 78 78', N'kompetenzzentrum-arbeit@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 666, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs18 Kompetenzzentrum Arbeit KA\par
Qualifizierung Jugend/Motivationssemester [to do]\par
Freiburgstrasse 139c\par
Postfach 3000 Bern 5\f1\fs20\par
}', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (95, 92, 2, N'Lorraine', N'031 321 62 72', N'031 321 62 70', N'kompetenzzentrum-arbeit@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 693, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs18 Kompetenzzentrum Arbeit KA\par
Qualifizierung Jugend/Motivationssemester [to do]\par
Lorrainestrasse 52\par
Postfach 3001 Bern \f1\fs20\par
}', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (96, 85, 4, N'KA Vermittlung', N'031 321 62 72', N'031 321 62 70', N'kompetenzzentrum-arbeit@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 2025, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs18 Kompetenzzentrum Arbeit KA\par
Vermittlung\par
Lorrainestrasse 42\par
Postfach 3001 Bern \f1\fs20\par
}', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (97, 85, 5, N'Administration/Finanzen', N'031 321 62 72', N'031 321 62 70', N'kompetenzzentrum-arbeit@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 670, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}{\f1\fnil Arial;}}
\viewkind4\uc1\pard\fs18 Kompetenzzentrum Arbeit KA\par
Lorrainestrasse 52\par
Postfach 3001 Bern \par
\f1\fs20\par
}', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (101, 29, 12, N'KISS Applikationsverantwortliche', NULL, NULL, NULL, NULL, 0, 0, 158, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (102, 101, 1, N'Admins', N'031 321__ 63 73 / 72 16', NULL, N'_R Applikationsverantwortliche.kiss, BSS IT', NULL, 0, 0, 158, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Admin Sozialamt, Sozialdienst West\par
Frankenstrasse 1, Postfach 712\par
3018 Bern\par
\par
Telefon 031 997 88 88\par
Fax 031 997 88 89\par
www.bern.ch\par
\par
}', NULL, NULL, NULL, NULL, 2001, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (103, 85, 6, N'KA inizio', N'031 321 62 72', N'031 321 62 70', N'inizio@bern.ch', N'www.kompetenzzentrum-arbeit.ch', 7, 7, 664, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Kompetenzzentrum KA\par
Projekt inizio\par
Lorrainestrasse 52\par
Postfach 3001 Bern\par
}', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (104, 25, 6, N'Ehemalige KA', NULL, NULL, NULL, NULL, 7, NULL, NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (105, 30, 13, N'Junge Erwachsene', NULL, NULL, NULL, NULL, 3, NULL, 103, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst West\par
Frankenstrasse 1, Postfach 712\par
3018 Bern\par
\par
Telefon 031 997 88 88\par
Fax 031 997 88 89\par
\pard www.bern.ch\fs20\par
}', NULL, NULL, NULL, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 Frankenstrasse 1\par
Postfach 712\par
\pard 3018 Bern\fs20\par
}', NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (107, 30, 14, N'Team E', NULL, NULL, NULL, NULL, 3, NULL, 60, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst\par
Predigergasse 10, Postfach 579\par
3000 Bern 7\par
\par
Fax 031 321 72 54\par
\pard www.bern.ch\fs20\par
}', N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs20 B. D\''e4pp \par
Sozialarbeiterin\par
}', NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (108, 30, 15, N'Sozialinspektorat-Revisorat Stadt', NULL, NULL, NULL, NULL, 3, NULL, 356, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst\par
Predigergasse 10, Postfach 579\par
3000 Bern 7\par
\par
Fax 031 321 72 54\par
\pard www.bern.ch\fs20\par
}', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (109, 30, 16, N'Sozialinspektorat-Revisorat West', NULL, NULL, NULL, NULL, 3, NULL, 356, N'{\rtf1\ansi\ansicpg1252\deff0\deflang2055{\fonttbl{\f0\fnil\fcharset0 Arial;}}
\viewkind4\uc1\pard\fs18 Sozialamt, Sozialdienst West\par
Frankenstrasse 1, Postfach 712\par
3018 Bern\par
\par
Telefon 031 997 88 88\par
Fax 031 997 88 89\par
\pard www.bern.ch\fs20\par
}', NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
INSERT INTO [XOrgUnit] ([OrgUnitID], [ParentID], [ParentPosition], [ItemName], [Phone], [Fax], [EMail], [WWW], [ModulID], [UserProfileCode], [ChiefID], [Text1], [Text2], [Text3], [Text4], [Adressat], [RechtsdienstUserID], [Creator], [Modifier]) VALUES (110, 29, 13, N'Rechtsdienst', NULL, NULL, NULL, NULL, 2, NULL, 2071, NULL, NULL, NULL, NULL, NULL, NULL, 'Creator', 'Modifier')
GO
SET IDENTITY_INSERT [XOrgUnit] OFF
GO
ENABLE TRIGGER trHist_XOrgUnit ON XOrgUnit;
GO
COMMIT
GO