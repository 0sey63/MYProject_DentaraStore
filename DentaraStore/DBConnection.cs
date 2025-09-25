using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DentaraStore
{
    internal class DBConnection
    {
        public string serverName;
        public string sqlServerConnection;

        public DBConnection(string server)
        {
            serverName = server;
            sqlServerConnection = $"Data Source={serverName};Initial Catalog=DentalStoreDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True";
            //;Trust Server Certificate=True
        }
    }
}
//Data Source=ZBOOK15G5-ALDUB;Initial Catalog=DentalStoreDB;Integrated Security=True;Encrypt=True;Trust Server Certificate=True