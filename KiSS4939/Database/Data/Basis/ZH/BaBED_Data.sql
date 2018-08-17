SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM [BaBED]
GO

INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16001, 'Aargau', 'AG', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16002, 'Appenzell Ausserrhoden', 'AR', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16003, 'Appenzell innerrhoden', 'AI', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16004, 'Baselland', 'BL', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16005, 'Basel Stadt', 'BS', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16006, 'Bern', 'BE', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16007, 'Fribourg', 'FR', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16008, 'Genf', 'GE', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16009, 'Glarus', 'GL', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16010, 'Graubünden', 'GR', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16011, 'Jura', 'JU', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16012, 'Luzern', 'LU', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16013, 'Neuenburg', 'NE', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16014, 'Nidwalden', 'NW', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16015, 'Obwalden', 'OW', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16016, 'Schaffhausen', 'SH', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16017, 'Schwyz', 'SZ', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16018, 'Solothurn', 'SO', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16019, 'Sankt Gallen', 'SG', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16020, 'Tessin', 'TI', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16021, 'Thurgau', 'TG', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16022, 'Uri', 'UR', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16023, 'Waadt', 'VD', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16024, 'Wallis', 'VS', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16025, 'Zug', 'ZG', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16026, 'Zürich', 'ZH', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16027, 'Deutschland', 'D', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16028, 'Frankreich', 'F', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16029, 'Bund', 'Bund', 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16030, 'Fallpauschalen', NULL, 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16031, 'Keine Weiterverrechnung', NULL, 0)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16032, 'derzeit keine Definition', NULL, 0)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16033, 'Abrechnung durch QSB', NULL, 1)
INSERT INTO [dbo].[BaBED]([BaBedID],[Name],[Kurztext],[Weiterverrechenbar]) VALUES (16034, 'Fürstentum Lichtenstein', NULL, 1)

GO
COMMIT
GO