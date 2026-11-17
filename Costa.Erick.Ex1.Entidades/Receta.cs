namespace Costa.Erick.Ex1.Entidades
{
    // Una fila de la tabla Receta; viaja entre las capas
    public class Receta
    {
        public int RecetaId { get; set; }
        public string Nombre { get; set; }
        public string PaisOrigen { get; set; }
        public string Ingredientes { get; set; }
        public int TiempoPreparacion { get; set; }
        public bool Vegetariana { get; set; }
    }
}
