using System;
using System.Collections.Generic;
using Costa.Erick.Ex1.AccesoDatos;
using Costa.Erick.Ex1.Entidades;

namespace Costa.Erick.Ex1.LogicaNegocio
{
    // Reglas de negocio: la presentación llama a esta capa y esta capa a la de datos
    public class RecetaBL
    {
        private RecetaDAL dal = new RecetaDAL();

        public List<Receta> Listar() { return dal.Listar(); }

        public Receta Obtener(int id) { return dal.Obtener(id); }

        public void Guardar(Receta r)
        {
            Validar(r);
            if (r.RecetaId == 0) dal.Insertar(r);
            else dal.Actualizar(r);
        }

        public void Eliminar(int id) { dal.Eliminar(id); }

        private void Validar(Receta r)
        {
            if (r.Nombre.Trim() == "") throw new ApplicationException("El nombre es obligatorio.");
            if (r.PaisOrigen.Trim() == "") throw new ApplicationException("El país de origen es obligatorio.");
            if (r.Ingredientes.Trim() == "") throw new ApplicationException("Los ingredientes son obligatorios.");
            if (r.TiempoPreparacion <= 0) throw new ApplicationException("El tiempo de preparación debe ser mayor a 0 minutos.");
        }
    }
}
