using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace pruebacontroladores.Models.ViewModels.Movimiento
{
    public class TransferenciaViewModel
    {
        public int id { get; set; }

        public DateTime Fecha { get; set; } = DateTime.Now;

        [Display(Name = "Producto")]
        [Required(ErrorMessage = "Debe seleccionar un producto.")]
        public int? idProducto { get; set; }
        public List<SelectListItem>? Productos { get; set; }
        public string? ProductoNombre { get; set; }

        public int Cantidad { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Deposito.")]
        [Display(Name = "Depósito Origen")]
        public int? idDepositoOrigen { get; set; }
        public string? DepositoOrigenNombre { get; set; }

        [Required(ErrorMessage = "Debe seleccionar un Deposito.")]
        [Display(Name = "Depósito Destino")]
        public int? idDepositoDestino { get; set; }
        public string? DepositoDestinoNombre { get; set; }
        public List<SelectListItem>? Depositos { get; set; }

        public string? Observaciones { get; set; }

        [Display(Name = "Stock Disponible")]
        public int StockDisponible { get; set; }
    }
}
