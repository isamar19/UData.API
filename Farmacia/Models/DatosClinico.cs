using System;
using System.Collections.Generic;

namespace Farmacia.Models
{
    public partial class DatosClinico
    {
        public int Id { get; set; }
        public string? Posologia { get; set; }
        public string? Indicaciones { get; set; }
        public string? Contraindicaciones { get; set; }
        public string? Precauciones { get; set; }
        public int? MedicamentoId { get; set; }

        public virtual Medicamento? Medicamento { get; set; }
    }
}
