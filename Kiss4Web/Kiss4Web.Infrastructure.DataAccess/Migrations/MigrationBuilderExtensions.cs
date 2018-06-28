using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Kiss4Web.Infrastructure.DataAccess.Migrations
{
    public static class MigrationBuilderExtensions
    {
        public static void MakeTemporalTable(this MigrationBuilder builder, string tableName)
        {
            var newline = Environment.NewLine;
            builder.Sql($"ALTER TABLE {tableName}" + newline +
                        "   ADD" + newline +
                        $"      SysStartTime DATETIME2(2) GENERATED ALWAYS AS ROW START HIDDEN CONSTRAINT DF_{tableName}_SysStart DEFAULT SYSUTCDATETIME()," + newline +
                        $"      SysEndTime   DATETIME2(2) GENERATED ALWAYS AS ROW END   HIDDEN CONSTRAINT DF_{tableName}_SysEnd   DEFAULT CONVERT(DATETIME2(2), '99991231 23:59:59.99')," + newline +
                        "      PERIOD FOR SYSTEM_TIME(SysStartTime, SysEndTime);" + newline +
                        newline +
                        $"ALTER TABLE {tableName}" + newline +
                        $"   SET(SYSTEM_VERSIONING = ON(HISTORY_TABLE = history.{tableName}));" + newline);
        }
    }
}