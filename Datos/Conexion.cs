using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Datos
{
    public class Conexion
    {
        private static string server = "20.66.36.28", user = "redesplus", password = "1234";
        public static MySqlConnection conexion;
        public static bool Conectar()
        {
            try
            {
                if (conexion != null && conexion.State == System.Data.ConnectionState.Open) return true;
                MySqlBaseConnectionStringBuilder builder = new MySqlConnectionStringBuilder();
                builder.Server = server;
                builder.UserID = user;
                builder.Password = password;
                builder.Database = "Inventarios";
                conexion = new MySqlConnection(builder.ConnectionString);
                conexion.Open();
                return true;


            }
            catch (MySqlException ex) { return false; }
            catch (Exception ex) { return false; }

        }
        public static void Desconectar()
        {
            if (conexion != null && conexion.State == System.Data.ConnectionState.Open)
                conexion.Close();
        }
    }
}
