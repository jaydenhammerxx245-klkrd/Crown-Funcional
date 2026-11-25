using HotelManagement.Entities;

namespace HotelManagement.BL.Interfaces
{
    public interface ITipoHabitacionBL
    {
        Task<List<TipoHabitacion>> ObtenerTodosAsync();
        Task<TipoHabitacion?> ObtenerPorIdAsync(int id);
        Task CrearAsync(TipoHabitacion tipo);
        Task<bool> ActualizarAsync(TipoHabitacion tipo);
        Task<bool> EliminarAsync(int id);
    }
}
