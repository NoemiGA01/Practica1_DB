using Modelo;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
namespace Datos
{
    public class AreasDAO
    {
        public List<Areas> GetAreas()
        {
            List<Areas> lista = new List<Areas>();
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (SELECT)
                    String select = @"SELECT *
                FROM AREAS ";
                    //Definir un datatable para que sea llenado
                    DataTable dt = new DataTable();
                    //Crear el dataadapter
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = sentencia;
                    //Llenar el datatable
                    da.Fill(dt);
                    //Crear un objeto categoría por cada fila de la tabla y añadirlo a la lista
                    foreach (DataRow fila in dt.Rows)
                    {
                        Areas area = new Areas(
                            Convert.ToInt32(fila["id"]),
                            fila["nombre"].ToString(),
                            fila["ubicacion"].ToString()
                        );
                        lista.Add(area);
                    }

                    return lista;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return null;
            }
        }

        public int Eliminar(int id)
        {
            if (Conexion.Conectar())
            {
                try
                {
                    string eliminar = "DELETE FROM AREAS WHERE id=@id";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = eliminar;
                    sentencia.Parameters.AddWithValue("@id", id);
                    sentencia.Connection = Conexion.conexion;
                    int filaAfectada = Convert.ToInt32(sentencia.ExecuteNonQuery());
                    return filaAfectada;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                return -1;
            }
        }

        public int Insertar(int id, string nombre, string ubicacion)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (INSERT)
                    String insert = "INSERT INTO AREAS (id, nombre, ubicacion) VALUES (@id, @nombre, @ubicacion);";

                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = insert;
                    sentencia.Parameters.AddWithValue("@id", id);
                    sentencia.Parameters.AddWithValue("@nombre", nombre);
                    sentencia.Parameters.AddWithValue("@ubicacion", ubicacion);
                    sentencia.Connection = Conexion.conexion;

                    int filasAfectadas = Convert.ToInt32(sentencia.ExecuteNonQuery());

                    return filasAfectadas;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                //Devolvemos un cero indicando que no se editó nada
                return -1;
            }
        }

        public int Editar(int id, string nombre, string ubicacion)
        {
            //Conectarme
            if (Conexion.Conectar())
            {
                try
                {
                    //Crear la sentencia a ejecutar (UPDATE)
                    String update = "UPDATE AREAS SET nombre=@nombre, ubicacion=@ubicacion WHERE id=@id;";

                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = update;
                    sentencia.Parameters.AddWithValue("@nombre", nombre);
                    sentencia.Parameters.AddWithValue("@ubicacion", ubicacion);
                    sentencia.Parameters.AddWithValue("@id", id);
                    sentencia.Connection = Conexion.conexion;

                    int filasAfectadas = Convert.ToInt32(sentencia.ExecuteNonQuery());

                    return filasAfectadas;
                }
                finally
                {
                    Conexion.Desconectar();
                }
            }
            else
            {
                //Devolvemos un cero indicando que no se editó nada
                return -1;
            }
        }

    }
}
