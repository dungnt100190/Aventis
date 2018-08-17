SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO

-------------------------------------------------------------------------------------------------
-- drop default constraint in XUser.PasswordHash first
-------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1 
            FROM dbo.sysobjects 
            WHERE id = OBJECT_ID(N'[DF_XUser_PasswordHash]') 
              AND type = 'D'))
BEGIN
  ALTER TABLE [dbo].[XUser] 
    DROP CONSTRAINT [DF_XUser_PasswordHash];
END;
GO

-------------------------------------------------------------------------------------------------
-- drop dbo
-------------------------------------------------------------------------------------------------
EXECUTE dbo.spDropObject fnXGetUserRNDPwd;
GO

/*===============================================================================================
  $Revision: 4 $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Use this function to get a random password for the user
    @UID: A unique identifier used for randomize
  -
  RETURNS: A random password for the user
=================================================================================================
  TEST:    SELECT dbo.fnXGetUserRNDPwd(NEWID())
=================================================================================================*/

CREATE FUNCTION dbo.fnXGetUserRNDPwd
(
  @UID UNIQUEIDENTIFIER
)
RETURNS VARCHAR(255)
AS 
BEGIN
  -----------------------------------------------------------------------------
  -- vars
  -----------------------------------------------------------------------------
  DECLARE @Password VARCHAR(255);
  DECLARE @Number_Builder INT;
  DECLARE @Result VARCHAR(255);
  DECLARE @Char1 SMALLINT;
  DECLARE @Char2 SMALLINT;
  DECLARE @Char3 SMALLINT;
  DECLARE @Char4 SMALLINT;
  DECLARE @i INT;
  
  SET @Result = '';
  
  -----------------------------------------------------------------------------
  -- get value
  -----------------------------------------------------------------------------
  SET @Password = CONVERT(VARCHAR(255), (CAST(CAST(@UID AS BINARY(4)) AS INT)));
  
  -----------------------------------------------------------------------------
  -- get base64 code
  -----------------------------------------------------------------------------
  WHILE (LEN(@Password) > 0)
  BEGIN
    SET @i = 1;
    SET @Number_Builder = 0;
    
    WHILE (@i <= 3)
    BEGIN
        -- constructing a 3 character base 256 number
        -- each character advancement multiplies by 256.... because this is base 256...
        IF (@i > LEN(@Password))
        BEGIN
          SET @Number_Builder = @Number_Builder*256;
        END
        ELSE
        BEGIN
          SET @Number_Builder = @Number_Builder*256 + ASCII(SUBSTRING(@Password, @i, 1));
        END;
        
        SET @i = @i +1;
    END;
    
    -- remove the base 256 characters we have just used
    IF (LEN(@Password) > 3)
    BEGIN
      SET @Password = RIGHT(@Password, LEN(@Password) - 3);
    END
    ELSE
    BEGIN
      SET @Password = '';
    END;
    
    -- at this stage we have a base10/2 number, we can now get our base64 numbers out
    SET @Char1 = @Number_Builder/262144;    -- 64^3 (first number)
    SET @Number_Builder = @Number_Builder & 262143;
    SET @Char2 = @Number_Builder/4096;      --64^2 (second number)
    SET @Number_Builder = @Number_Builder & 4095;
    SET @Char3 = @Number_Builder/64;        --64^1 (third number)
    SET @Number_Builder = @Number_Builder & 63;
    SET @Char4 = @Number_Builder;           --64^0 (fifth number)
    
    -- convert from actual base64 to ascii representation of base 64
    SET @Char1 = @Char1 + CASE 
                            WHEN @Char1 BETWEEN 0 AND 25  THEN ASCII('A')
                            WHEN @Char1 BETWEEN 26 AND 51 THEN ASCII('a') - 26
                            WHEN @Char1 BETWEEN 52 AND 63 THEN ASCII('0') - 52 
                          END;
    
    SET @Char2 = @Char2 + CASE 
                            WHEN @Char2 BETWEEN 0 AND 25  THEN ASCII('A')
                            WHEN @Char2 BETWEEN 26 AND 51 THEN ASCII('a') - 26
                            WHEN @Char2 BETWEEN 52 AND 63 THEN ASCII('0') - 52
                          END;
    
    SET @Char3 = @Char3 + CASE 
                            WHEN @Char3 BETWEEN 0 AND 25  THEN ASCII('A')
                            WHEN @Char3 BETWEEN 26 AND 51 THEN ASCII('a') - 26
                            WHEN @Char3 BETWEEN 52 AND 63 THEN ASCII('0') - 52
                          END;
    
    SET @Char4 = @Char4 + CASE 
                            WHEN @Char4 BETWEEN 0 AND 25  THEN ASCII('A')
                            WHEN @Char4 BETWEEN 26 AND 51 THEN ASCII('a') - 26
                            WHEN @Char4 BETWEEN 52 AND 63 THEN ASCII('0') - 52
                          END;
    
    -- add these four characters to the string
    SET @Result = @Result + CHAR(@Char1) + CHAR(@Char2) + CHAR(@Char3) + CHAR(@Char4);
  END;
  
  -----------------------------------------------------------------------------
  -- return value
  -----------------------------------------------------------------------------  
  RETURN ISNULL(@Result, NULL);
END;
GO

-------------------------------------------------------------------------------------------------
-- recreate default constraint on XUser.PasswordHash
-------------------------------------------------------------------------------------------------
IF (EXISTS (SELECT TOP 1 1 
            FROM sys.columns 
            WHERE OBJECT_NAME(object_id) = N'XUser'
              AND name = 'PasswordHash'))
BEGIN
  ALTER TABLE [dbo].[XUser] 
    ADD CONSTRAINT [DF_XUser_PasswordHash]
    DEFAULT ([dbo].[fnXGetUserRNDPwd](NEWID())) FOR [PasswordHash];
END;
GO