using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using pruebacontroladores.Models.Enum;

namespace pruebacontroladores.Models.Entities
{
    public class Movimiento : BaseEntity
    {
        [Required]
        public TipoMovimiento Tipo { get; set; }

        [Required]
        [Range(1, int.MaxValue)]
        public int Cantidad { get; set; }

        [Required]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [StringLength(300)]
        public string? Observaciones { get; set; }

        [Required]
        [ForeignKey("Producto")]
        public int idProducto { get; set; }
        public Producto? Producto { get; set; }

        [ForeignKey("DepositoOrigen")]
        public int? idDepositoOrigen { get; set; }
        public Deposito? DepositoOrigen { get; set; }

        [ForeignKey("DepositoDestino")]
        public int? idDepositoDestino { get; set; }

        [ForeignKey("Proveedor")]
        public int? idProveedor { get; set; }
        public Proveedor? Proveedor { get; set; }

        [ForeignKey("Cliente")]
        public int? idCliente { get; set; }
        public Cliente? Cliente { get; set; }

        [StringLength(100)]
        public string UsuarioRegistro { get; set; } = "sistema";
    }
}
