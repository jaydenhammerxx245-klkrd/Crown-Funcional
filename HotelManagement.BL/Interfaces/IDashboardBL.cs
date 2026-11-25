using HotelManagement.Entities;

namespace HotelManagement.BL.Interfaces
{
    public interface IDashboardBL
    {
        Task<ResumenInicio> ObtenerResumenAsync();
    }
}
