using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace isoy_bamis
{
    class crud
    {
        public static string connection = System.IO.File.ReadAllText(System.Environment.CurrentDirectory + @"\sql_server_connection_string.txt");
    }
}
