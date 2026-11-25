namespace HotelManagement.Entities
{
    /// <summary>Datos agregados del panel de inicio, calculados en la capa de negocio.</summary>
    public class ResumenInicio
    {
        public int Reservas { get; set; }
        public int Habitaciones { get; set; }
        public int HabitacionesDisponibles { get; set; }
        public int Clientes { get; set; }
        public int Empleados { get; set; }
        public decimal IngresosReservados { get; set; }
        public List<Reserva> ProximasReservas { get; set; } = [];
    }
}
