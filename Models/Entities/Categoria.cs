using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace pruebacontroladores.Models.Entities
{
    public class Categoria : BaseEntity
    {
        [Required, StringLength(80)]
        public string Nombre { get; set; } = string.Empty;

        [StringLength(200)]
        public string? Descripcion { get; set; }

        // Navegación
        public ICollection<Producto> Productos { get; set; } = new List<Producto>();
    }
}