  -----------------------------------------------------------------------------
  -- <Cursor Informationen>
  -----------------------------------------------------------------------------
  -- setup vars
  <Cursor-Variablen-Deklarationenen>;

  -- setup cursor
  DECLARE cur<Name> CURSOR FAST_FORWARD FOR
    SELECT <Columns>
    FROM dbo.<TableName> <Alias> WITH (READUNCOMMITTED)
    WHERE <Condition>;

  -- iterate through cursor
  OPEN cur<Name>;
  WHILE (1 = 1)
  BEGIN
    -- read next row and check if we have one
    FETCH NEXT 
    FROM cur<Name> 
    INTO <CursorVariablen kommasepariert anhand von SELECT>;
    
    IF (@@FETCH_STATUS != 0)
    BEGIN
      BREAK;
    END;

    -- do cursor specific action
    -- <Hier zusäztlicher Code>;
  END; -- [WHILE cursor]

  -- clean up cursor
  CLOSE cur<Name>;
  DEALLOCATE cur<Name>;
