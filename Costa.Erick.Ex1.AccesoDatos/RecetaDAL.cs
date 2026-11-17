using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using Costa.Erick.Ex1.Entidades;

namespace Costa.Erick.Ex1.AccesoDatos
{
    // CRUD de la tabla Receta con ADO.NET
    public class RecetaDAL
    {
        // La cadena de conexión está en el Web.config de la capa de presentación
        private SqlConnection Conexion()
        {
            return new SqlConnection(ConfigurationManager.ConnectionStrings["RecetasCocina"].ConnectionString);
        }

        public List<Receta> Listar()
        {
            List<Receta> lista = new List<Receta>();
            using (SqlConnection cn = Conexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Receta ORDER BY RecetaId", cn);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                    lista.Add(Leer(dr));
            }
            return lista;
        }

        public Receta Obtener(int id)
        {
            using (SqlConnection cn = Conexion())
            {
                SqlCommand cmd = new SqlCommand("SELECT * FROM Receta WHERE RecetaId = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                SqlDataReader dr = cmd.ExecuteReader();
                return dr.Read() ? Leer(dr) : null;
            }
        }

        public void Insertar(Receta r)
        {
            Ejecutar("INSERT INTO Receta (Nombre, PaisOrigen, Ingredientes, TiempoPreparacion, Vegetariana) " +
                     "VALUES (@nombre, @pais, @ingredientes, @tiempo, @vegetariana)", r);
        }

        public void Actualizar(Receta r)
        {
            Ejecutar("UPDATE Receta SET Nombre = @nombre, PaisOrigen = @pais, Ingredientes = @ingredientes, " +
                     "TiempoPreparacion = @tiempo, Vegetariana = @vegetariana WHERE RecetaId = @id", r);
        }

        public void Eliminar(int id)
        {
            using (SqlConnection cn = Conexion())
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Receta WHERE RecetaId = @id", cn);
                cmd.Parameters.AddWithValue("@id", id);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        // Parámetros en lugar de concatenar texto: evita la inyección SQL
        private void Ejecutar(string sql, Receta r)
        {
            using (SqlConnection cn = Conexion())
            {
                SqlCommand cmd = new SqlCommand(sql, cn);
                cmd.Parameters.AddWithValue("@id", r.RecetaId);
                cmd.Parameters.AddWithValue("@nombre", r.Nombre);
                cmd.Parameters.AddWithValue("@pais", r.PaisOrigen);
                cmd.Parameters.AddWithValue("@ingredientes", r.Ingredientes);
                cmd.Parameters.AddWithValue("@tiempo", r.TiempoPreparacion);
                cmd.Parameters.AddWithValue("@vegetariana", r.Vegetariana);
                cn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private Receta Leer(SqlDataReader dr)
        {
            Receta r = new Receta();
            r.RecetaId = (int)dr["RecetaId"];
            r.Nombre = (string)dr["Nombre"];
            r.PaisOrigen = (string)dr["PaisOrigen"];
            r.Ingredientes = (string)dr["Ingredientes"];
            r.TiempoPreparacion = (int)dr["TiempoPreparacion"];
            r.Vegetariana = (bool)dr["Vegetariana"];
            return r;
        }
    }
}
