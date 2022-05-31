using System;
using System.Collections.Generic;

namespace Farmacia.Models
{
    public partial class Medicamento
    {
        public Medicamento()
        {
            DatosClinicos = new HashSet<DatosClinico>();
        }

        public int Id { get; set; }
        public string? Nombre { get; set; }
        public string? Composicion { get; set; }
        public string? FormaFarmaceutica { get; set; }

        public virtual ICollection<DatosClinico> DatosClinicos { get; set; }
    }
}
