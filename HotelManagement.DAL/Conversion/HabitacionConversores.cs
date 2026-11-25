using HotelManagement.Entities;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace HotelManagement.DAL.Conversion
{
    /// <summary>
    /// Convierte los enums a texto y viceversa sin cambiar el tipo SQL de las columnas
    /// (siguen siendo nvarchar(max) NOT NULL). "SinDefinir" se escribe como cadena vacía,
    /// igual que hacía el código anterior, y las filas antiguas con cadena vacía se leen
    /// sin errores.
    /// </summary>
    public sealed class TipoHabitacionValorConverter : ValueConverter<TipoHabitacionValor, string>
    {
        public TipoHabitacionValorConverter()
            : base(
                valor => valor == TipoHabitacionValor.SinDefinir ? string.Empty : valor.ToString(),
                texto => texto == "Simple" ? TipoHabitacionValor.Simple
                    : texto == "Doble" ? TipoHabitacionValor.Doble
                    : texto == "Suite" ? TipoHabitacionValor.Suite
                    : texto == "Premium" ? TipoHabitacionValor.Premium
                    : TipoHabitacionValor.SinDefinir)
        {
        }
    }

    /// <summary>Equivalente a <see cref="TipoHabitacionValorConverter"/> para el estado.</summary>
    public sealed class EstadoHabitacionConverter : ValueConverter<EstadoHabitacion, string>
    {
        public EstadoHabitacionConverter()
            : base(
                valor => valor == EstadoHabitacion.SinDefinir ? string.Empty : valor.ToString(),
                texto => texto == "Disponible" ? EstadoHabitacion.Disponible
                    : texto == "Reservada" ? EstadoHabitacion.Reservada
                    : texto == "Ocupada" ? EstadoHabitacion.Ocupada
                    : texto == "Limpieza" ? EstadoHabitacion.Limpieza
                    : texto == "Mantenimiento" ? EstadoHabitacion.Mantenimiento
                    : EstadoHabitacion.SinDefinir)
        {
        }
    }
}
