using System;
using System.Collections.Generic;

namespace ProyectoCrudK.Models
{
    public partial class PersonaK
    {
        public int? Id { get; set; }
        public string? NombreK { get; set; }
        public string? ApellidoK { get; set; }
        public DateTime? FechaNacimientoK { get; set; }
        public decimal? SueldoK { get; set; }
        public string? EstatusK { get; set; }
    }
}
