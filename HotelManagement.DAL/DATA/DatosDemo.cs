using HotelManagement.DAL.Context;
using HotelManagement.Entities;
using Microsoft.EntityFrameworkCore;

namespace HotelManagement.DAL.Seeding
{
     public static class DatosDemo
    {
        private static readonly string[] Hoteles =
        [
            "Hotel Crown",
            "Hotel Paradise",
            "Hotel Caribe",
            "Hotel Luxury",
        ];

        private const int PisosPorHotel = 5;

         private const decimal PrecioSimple = 350m;
        private const decimal PrecioPremium = 650m;

         private static readonly (string Nombre, string Descripcion)[] Tipos =
        [
            (TiposHabitacion.Simple, "1 huésped · tarifa accesible"),
            (TiposHabitacion.Doble, "2 huéspedes"),
            (TiposHabitacion.Suite, "2 adultos + 1 menor"),
            (TiposHabitacion.Premium, "2-3 huéspedes · tarifa superior"),
        ];

        public static void Sembrar(HotelDbContext context)
        {
            using (context.Database.BeginTransaction())
            {
                SembrarTipos(context);

                 if (context.Builds.Any(b => Hoteles.Contains(b.Nombre)))
                {
                    context.Database.CurrentTransaction!.Commit();
                    return;
                }

                var hoteles = CrearHoteles(context);
                CrearPisosYHabitaciones(context, hoteles);

                context.SaveChanges();
                context.Database.CurrentTransaction!.Commit();
            }
        }

        private static List<Build> CrearHoteles(HotelDbContext context)
        {
            var hoteles = new List<Build>(Hoteles.Length);

            foreach (var nombre in Hoteles)
            {
                var hotel = new Build
                {
                    Nombre = nombre,
                    Descripcion = $"Disponible · {PisosPorHotel} pisos · habitaciones {TiposHabitacion.Simple} y {TiposHabitacion.Premium}",
                    CantidadPisos = PisosPorHotel,
                };
                context.Builds.Add(hotel);
                hoteles.Add(hotel);
            }

            context.SaveChanges();
            return hoteles;
        }

        private static void CrearPisosYHabitaciones(HotelDbContext context, IReadOnlyList<Build> hoteles)
        {
            for (var i = 0; i < hoteles.Count; i++)
            {
                var hotel = hoteles[i];

                for (var pisoNumero = 1; pisoNumero <= hotel.CantidadPisos; pisoNumero++)
                {
                    var piso = new Piso
                    {
                        NumeroPiso = pisoNumero,
                        IdBuild = hotel.IdBuild,
                        Nombre = $"{hotel.Nombre} - Piso {pisoNumero}",
                    };
                    context.Pisos.Add(piso);
                    context.SaveChanges();

                    var prefijo = (i + 1) * 1000 + pisoNumero * 100;
                    var ultimoPiso = pisoNumero == hotel.CantidadPisos;

                    context.Habitaciones.AddRange(
                        new Habitacion
                        {
                            Numero = $"{prefijo + 1}",
                            Capacidad = 2,
                            PrecioNoche = PrecioSimple,
                            Precio = PrecioSimple,
                            Disponible = true,
                            IdPiso = piso.IdPiso,
                            Tipo = TipoHabitacionValor.Simple,
                            Estado = EstadoHabitacion.Disponible,
                        },
                        new Habitacion
                        {
                            Numero = $"{prefijo + 2}",
                            Capacidad = 3,
                            PrecioNoche = PrecioPremium,
                            Precio = PrecioPremium,
                            Disponible = !ultimoPiso,
                            IdPiso = piso.IdPiso,
                            Tipo = TipoHabitacionValor.Premium,
                            Estado = ultimoPiso ? EstadoHabitacion.Ocupada : EstadoHabitacion.Disponible,
                        });
                }
            }
        }

        private static void SembrarTipos(HotelDbContext context)
        {
             var conexion = context.Database.GetDbConnection();
            if (conexion.State != System.Data.ConnectionState.Open)
                conexion.Open();

            using (var comando = conexion.CreateCommand())
            {
                comando.CommandText =
                    context.Database.ProviderName?.Contains("Sqlite", StringComparison.OrdinalIgnoreCase) == true
                        ? "CREATE TABLE IF NOT EXISTS TipoHabitacion (IdTipoHabitacion INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT, Nombre TEXT NOT NULL, Descripcion TEXT NULL);"
                        : "IF OBJECT_ID(N'dbo.TipoHabitacion', N'U') IS NULL CREATE TABLE dbo.TipoHabitacion (IdTipoHabitacion INT IDENTITY(1,1) NOT NULL PRIMARY KEY, Nombre NVARCHAR(100) NOT NULL, Descripcion NVARCHAR(300) NULL);";
                comando.ExecuteNonQuery();
            }

            if (context.TiposHabitacion.Any())
                return;

            foreach (var (nombre, descripcion) in Tipos)
                context.TiposHabitacion.Add(new TipoHabitacion { Nombre = nombre, Descripcion = descripcion });

            context.SaveChanges();
        }
    }
}
