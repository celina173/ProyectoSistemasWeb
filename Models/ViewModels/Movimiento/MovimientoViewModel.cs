using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using pruebacontroladores.Models.Enum;

namespace pruebacontroladores.Models.ViewModels.Movimiento
{
    public class MovimientoViewModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un tipo de movimiento.")]
        [Display(Name = "Tipo")]
        public TipoMovimiento Tipo { get; set; }

        [Required(ErrorMessage = "Debe ingresar la cantidad.")]
        [Range(1, int.MaxValue, ErrorMessage = "La cantidad debe ser mayor a cero")]
        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe ingresar la fecha.")]
        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; } = DateTime.Now;

        [StringLength(300, ErrorMessage = "Máximo 300 caracteres")]
        [Display(Name = "Observaciones")]
        public string? Observaciones { get; set; }

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Debe seleccionar un producto.")]
        public int? idProducto { get; set; }
        public string? ProductoNombre { get; set; }
        public List<SelectListItem>? Productos { get; set; }

        [Required(ErrorMessage = "Debe ingresar el deposito.")]
        [Display(Name = "Depósito Origen")]
        public int? idDepositoOrigen { get; set; }
        public List<SelectListItem>? DepositosOrigen { get; set; }
        public string? DepositoOrigenNombre { get; set; }

        [Display(Name = "Depósito Destino")]
        public int? idDepositoDestino { get; set; }
        public List<SelectListItem>? DepositosDestino { get; set; }
        public string? DepositoDestinoNombre { get; set; }

        [Display(Name = "Proveedor")]
        public int? idProveedor { get; set; }
        public List<SelectListItem>? Proveedores { get; set; }
        public string? Proveedor { get; set; }

        [Display(Name = "Cliente")]
        public int? idCliente { get; set; }
        public List<SelectListItem>? Clientes { get; set; }
        public string? Cliente { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "Máximo 100 caracteres")]
        [Display(Name = "Usuario")]
        public string UsuarioRegistro { get; set; } = "sistema";
    }
}
