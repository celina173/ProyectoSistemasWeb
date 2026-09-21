using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc.Rendering;
using pruebacontroladores.Models.Enum;

namespace pruebacontroladores.Models.ViewModels.Movimiento
{
    public class MovimientosHistorialViewModel
    {
        public List<Entities.Movimiento> Movimientos { get; set; } = new();

        [Display(Name = "Tipo")]
        public TipoMovimiento? TipoFiltro { get; set; }

        [Display(Name = "Producto")]
        public int? ProductoidFiltro { get; set; }

        [Display(Name = "Depósito")]
        public int? DepositoidFiltro { get; set; }

        [Display(Name = "Desde")]
        [DataType(DataType.Date)]
        public DateTime? FechaDesde { get; set; }

        [Display(Name = "Hasta")]
        [DataType(DataType.Date)]
        public DateTime? FechaHasta { get; set; }

        public List<SelectListItem> Productos { get; set; } = new();
        public List<SelectListItem> Depositos { get; set; } = new();
    }
}
