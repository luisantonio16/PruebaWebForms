using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CapaDatos.Repositorios
{
    public class ConexionDB
    {
        private static string ConnectionString;
        public ConexionDB()
        {
            ConnectionString = "Data Source=LUISMELENCIANO\\SQLEXPRESS; Initial catalog = pruebaWebForms; Trusted_Connection = true; TrustServerCertificate = True;";

        }
        protected static SqlConnection GetConnection()
        {
            return new SqlConnection(ConnectionString);
        }
    }
}
