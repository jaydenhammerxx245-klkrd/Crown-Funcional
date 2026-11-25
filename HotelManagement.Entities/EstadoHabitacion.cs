namespace HotelManagement.Entities
{
    /// <summary>
    /// Valores válidos de <see cref="Habitacion.Estado"/>, coherentes con el catálogo SQL
    /// Disponible / Reservada / Ocupada / Limpieza / Mantenimiento.
    /// </summary>
    public enum EstadoHabitacion
    {
        /// <summary>Sin estado asignado (equivale a la cadena vacía de antes).</summary>
        SinDefinir = 0,
        Disponible = 1,
        Reservada = 2,
        Ocupada = 3,
        Limpieza = 4,
        Mantenimiento = 5,
    }
}
