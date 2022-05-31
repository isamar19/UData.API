using Farmacia.Models;
using Microsoft.AspNetCore.Mvc;

namespace Farmacia.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MedicamentoController : ControllerBase
    {
        private readonly LaboratorioContext _contexto;

        public MedicamentoController(LaboratorioContext contexto)
        {
            _contexto = contexto;
        }

        [HttpGet(Name = "ObtenerLista")]
        public List<Medicamento> ObtenerLista()
        {
            return _contexto.Medicamentos.ToList();
        }
    }
}