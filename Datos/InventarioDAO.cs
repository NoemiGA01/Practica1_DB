using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Modelo;
using MySql.Data.MySqlClient;

namespace Datos
{
    public class InventarioDAO
    {
        public List<Inventario> GetInventario()
        {
            List<Inventario> lista = new List<Inventario>();
            // Conectarse
            if (Conexion.Conectar())
            {
                try
                {
                    // Crear la sentencia a ejecutar (SELECT)
                    String select = @"SELECT ID, NombreCorto, Descripcion, Serie, Color, FechaAdquisicion, TipoAdquisicion, Observaciones, areas_id
                              FROM INVENTARIO";
                    // Definir un DataTable para que sea llenado
                    DataTable dt = new DataTable();
                    // Crear el DataAdapter
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = select;
                    sentencia.Connection = Conexion.conexion;
                    MySqlDataAdapter da = new MySqlDataAdapter();
                    da.SelectCommand = sentencia;
                    // Llenar el DataTable
                    da.Fill(dt);
                    // Crear un objeto Inventario por cada fila de la tabla y añadirlo a la lista
                    foreach (DataRow fila in dt.Rows)
                    {
                        Inventario inventario = new Inventario(
                            Convert.ToInt32(fila["ID"]),
                            fila["NombreCorto"].ToString(),
                            fila["Descripcion"].ToString(),
                            fila["Serie"].ToString(),
                            fila["Color"].ToString(),
                            Convert.IsDBNull(fila["FechaAdquisicion"]) ? string.Empty : fila["FechaAdquisicion"].ToString(),
                            fila["TipoAdquisicion"].ToString(),
                            fila["Observaciones"].ToString(),
                            Convert.ToInt32(fila["areas_id"])
                        );

                        lista.Add(inventario);
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
                    string eliminar = "DELETE FROM INVENTARIO WHERE ID=@id_inventario";
                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = eliminar;
                    sentencia.Parameters.AddWithValue("@id_inventario", id);
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

        public int insertar(int id, string nombreCorto, string descripcion, string serie, string color, string fechaAdquisicion, string tipoAdquisicion, string observaciones, int areas_id)
        {

            // Conectarse
            if (Conexion.Conectar())
            {
                try
                {
                    // Crear la sentencia a ejecutar (INSERT)
                    String update = "INSERT INTO INVENTARIO (id, NombreCorto, Descripcion, Serie, Color, FechaAdquisicion, TipoAdquisicion, Observaciones, areas_id) VALUES (@id, @nombreCorto, @descripcion, @serie, @color, @fechaAdquisicion, @tipoAdquisicion, @observaciones, @areas_id);";

                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = update;
                    sentencia.Parameters.AddWithValue("@id", id);
                    sentencia.Parameters.AddWithValue("@nombreCorto", nombreCorto);
                    sentencia.Parameters.AddWithValue("@descripcion", descripcion);
                    sentencia.Parameters.AddWithValue("@serie", serie);
                    sentencia.Parameters.AddWithValue("@color", color);
                    sentencia.Parameters.AddWithValue("@fechaAdquisicion", fechaAdquisicion);
                    sentencia.Parameters.AddWithValue("@tipoAdquisicion", tipoAdquisicion);
                    sentencia.Parameters.AddWithValue("@observaciones", observaciones);
                    sentencia.Parameters.AddWithValue("@areas_id", areas_id);


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
                // Devolvemos un -1 indicando que no se editó nada
                return -1;
            }
        }

        public int editar(int id, string nombreCorto, string descripcion, string serie, string color, string fechaAdquisicion, string tipoAdquisicion, string observaciones, int areas_id)
        {

            // Conectarse
            if (Conexion.Conectar())
            {
                try
                {
                    // Crear la sentencia a ejecutar (INSERT)
                    String update = "UPDATE INVENTARIO SET NombreCorto=@nombreCorto, Descripcion=@descripcion, Serie=@serie, Color=@color, FechaAdquisicion=@fechaAdquisicion, TipoAdquisicion=@tipoAdquisicion, Observaciones=@observaciones, areas_id=@areas_id WHERE ID=@id;";

                    MySqlCommand sentencia = new MySqlCommand();
                    sentencia.CommandText = update;
                    sentencia.Parameters.AddWithValue("@id", id);
                    sentencia.Parameters.AddWithValue("@nombreCorto", nombreCorto);
                    sentencia.Parameters.AddWithValue("@descripcion", descripcion);
                    sentencia.Parameters.AddWithValue("@serie", serie);
                    sentencia.Parameters.AddWithValue("@color", color);
                    sentencia.Parameters.AddWithValue("@fechaAdquisicion", fechaAdquisicion);
                    sentencia.Parameters.AddWithValue("@tipoAdquisicion", tipoAdquisicion);
                    sentencia.Parameters.AddWithValue("@observaciones", observaciones);
                    sentencia.Parameters.AddWithValue("@areas_id", areas_id);


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
                // Devolvemos un -1 indicando que no se editó nada
                return -1;
            }
        }

    }
}
