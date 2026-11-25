using System.ComponentModel.DataAnnotations;

namespace HotelManagement.Entities
{
    /// <summary>Catálogo de tipos de habitación (Simple, Doble, Suite, Premium).</summary>
    public class TipoHabitacion
    {
        public int IdTipoHabitacion { get; set; }

        [Required(ErrorMessage = "El nombre del tipo es obligatorio.")]
        [StringLength(100, ErrorMessage = "El nombre no puede superar los 100 caracteres.")]
        [Display(Name = "Nombre del tipo")]
        public required string Nombre { get; set; }

        [StringLength(300, ErrorMessage = "La descripción no puede superar los 300 caracteres.")]
        [Display(Name = "Descripción")]
        public string? Descripcion { get; set; }
    }
}
