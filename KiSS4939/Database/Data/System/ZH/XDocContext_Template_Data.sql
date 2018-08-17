SET NOCOUNT ON
BEGIN TRANSACTION
GO
DELETE FROM dbo.XDocContext_Template
GO
INSERT INTO dbo.XDocContext_Template([ParentID],[ParentPosition],[FolderName],[DocContextID],[DocTemplateID],[UserProfileCode])
VALUES                              (NULL,      1,               NULL,        113,           1,              NULL)
INSERT INTO dbo.XDocContext_Template([ParentID],[ParentPosition],[FolderName],[DocContextID],[DocTemplateID],[UserProfileCode])
VALUES                              (NULL,      2,               NULL,        113,           2,              NULL)
INSERT INTO dbo.XDocContext_Template([ParentID],[ParentPosition],[FolderName],[DocContextID],[DocTemplateID],[UserProfileCode])
VALUES                              (NULL,      3,               NULL,        113,           3,              NULL)
GO
COMMIT
GO