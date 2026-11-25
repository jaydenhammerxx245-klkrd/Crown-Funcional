namespace HotelManagement.Entities
{
    /// <summary>
    /// Valores válidos de <see cref="Habitacion.Tipo"/>. Se guarda como texto en la base de datos
    /// (sin cambios de esquema) pero el compilador evita valores arbitrarios.
    /// </summary>
    public enum TipoHabitacionValor
    {
        /// <summary>Sin tipo asignado (equivale a la cadena vacía de antes).</summary>
        SinDefinir = 0,
        Simple = 1,
        Doble = 2,
        Suite = 3,
        Premium = 4,
    }
}
