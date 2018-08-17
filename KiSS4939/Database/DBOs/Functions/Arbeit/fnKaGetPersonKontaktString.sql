SET QUOTED_IDENTIFIER OFF;
GO
SET ANSI_NULLS ON;
GO
EXECUTE dbo.spDropObject fnKaGetPersonKontaktString;
GO
/*===============================================================================================
  $Revision: $
=================================================================================================
  Description
-------------------------------------------------------------------------------------------------
  SUMMARY: Returns a VARCHAR of the form:
           <@Name>, <@Vorname> (<@Mobiltelefon> (M), <@Email>)
           or
           <@Name>, <@Vorname> (<@Telefon> (T), <@Email>)
           If both, @Mobiltelefon and @Telefon are specified, @Mobiltelefon is taken.

    @Name: The Name of the Kontakt
    @Vorname: The Vorname of the Kontakt
    @Mobiltelefon: The Mobilelefon number of the Kontakt
    @Telefon: The Telefon number of the Kontakt
    @Email: The Email address of the Kontakt
  -
  RETURNS: a VARCHAR(450) of the above mentioned form.
=================================================================================================
  TEST:    
          SELECT dbo.fnKaGetPersonKontaktString('Vorname', 'Name', 'Mobiltelefon', 'Telefon', 'Email');
          SELECT dbo.fnKaGetPersonKontaktString('Vorname', 'Name', 'Mobiltelefon', NULL, 'Email');
          SELECT dbo.fnKaGetPersonKontaktString('Vorname', 'Name', NULL, 'Telefon', 'Email');
          SELECT dbo.fnKaGetPersonKontaktString('Vorname', 'Name', 'Mobiltelefon', 'Telefon', NULL);
          SELECT dbo.fnKaGetPersonKontaktString('Vorname', 'Name', 'Mobiltelefon', NULL, NULL);
          SELECT dbo.fnKaGetPersonKontaktString('Vorname', 'Name', NULL, 'Telefon', NULL);
          SELECT dbo.fnKaGetPersonKontaktString(NULL, 'Name', 'Mobiltelefon', 'Telefon', 'Email');
          SELECT dbo.fnKaGetPersonKontaktString(NULL, 'Name', 'Mobiltelefon', NULL, 'Email');
          SELECT dbo.fnKaGetPersonKontaktString(NULL, 'Name', NULL, 'Telefon', 'Email');
          SELECT dbo.fnKaGetPersonKontaktString(NULL, 'Name', 'Mobiltelefon', 'Telefon', NULL);
          SELECT dbo.fnKaGetPersonKontaktString(NULL, 'Name', 'Mobiltelefon', NULL, NULL);
          SELECT dbo.fnKaGetPersonKontaktString(NULL, 'Name', NULL, 'Telefon', NULL);
          SELECT dbo.fnKaGetPersonKontaktString('Vorname', NULL, NULL, NULL, 'Email');
=================================================================================================*/

CREATE FUNCTION dbo.fnKaGetPersonKontaktString
(
  @Vorname      VARCHAR(100),
  @Name         VARCHAR(100),
  @Mobiltelefon VARCHAR(100),
  @Telefon      VARCHAR(100),
  @Email        VARCHAR(100)
)
RETURNS VARCHAR(450)
AS
BEGIN
  RETURN dbo.fnGetLastFirstName(NULL, @Name, @Vorname) + 
    CASE WHEN COALESCE(@Mobiltelefon, @Telefon, @Email) IS NULL 
      THEN ''
      ELSE ' (' + ISNULL(ISNULL(@Mobiltelefon + ' (M)', @Telefon + ' (T)') + ISNULL(', ' + @Email, ''), ISNULL(@Email, '')) + ')'
    END;
END;
GO
