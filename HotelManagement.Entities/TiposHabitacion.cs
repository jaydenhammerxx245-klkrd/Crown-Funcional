namespace HotelManagement.Entities
{
    /// <summary>
    /// Nombres canónicos de los tipos de habitación, centralizados para que la semilla,
    /// las vistas y el catálogo no repitan literales (DRY) sin acoplar capas.
    /// </summary>
    public static class TiposHabitacion
    {
        public const string Simple = "Simple";
        public const string Doble = "Doble";
        public const string Suite = "Suite";
        public const string Premium = "Premium";
    }
}
