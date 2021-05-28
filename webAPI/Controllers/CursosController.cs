using System.Collections.Generic;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Aplicacion.Cursos;

namespace webAPI.Controllers
{
    //http://localhost:5000/api/Cursos
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController : ControllerBase
    {
        private readonly IMediator mediator;

        public CursosController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpGet]

        public async Task<ActionResult<List<Curso>>> Get(){
            return await mediator.Send(new Consultas.ListaCursos());
        }
}

}