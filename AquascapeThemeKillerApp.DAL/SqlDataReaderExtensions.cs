using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text;

namespace AquascapeThemeKillerApp.DAL
{
    public static class SqlDataReaderExtensions
    {
        public static int SafeGetInt32(this SqlDataReader reader, string columnName)
        {
            int x = reader.GetOrdinal(columnName);

            if (!reader.IsDBNull(x))
            {
                return reader.GetInt32(x);
            }
            else
            {
                return 0;
            }
        }
    }
}
