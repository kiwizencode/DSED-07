﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtractPDF.Lib.DAO
{
    public static class ConnectionHelper
    {
        public static string ConnectionString =
            //"Data Source=tcp:fishinabox.database.windows.net,1433;Initial Catalog=FIAB;Persist Security Info=False;"+
            "Server=tcp:fishinabox.database.windows.net,1433;Initial Catalog=fishinabox;Persist Security Info=False;" +
            "User ID=FIAB;Password=Monday99;" + 
            "MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
    }
}
