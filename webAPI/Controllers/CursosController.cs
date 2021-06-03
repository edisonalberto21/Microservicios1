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

        public async Task<ActionResult<List<Curso>>> Get()
        {
            return await mediator.Send(new Consultas.ListaCursos());
        }
         //http://localhost:5000/api/Cursos/1
        [HttpGet("{id}")]

        public async Task<ActionResult<Curso>> Detalle(int id)
        {
          return await mediator.Send(new ConsultasId.CursoUnico{Id = id});
        }

        [HttpPost]

        public async Task<ActionResult<Unit>> Crear(Nuevo.Ejecuta data)
        {
            return await mediator.Send(data);
        }

        [HttpPut("{id}")]

        public async Task<ActionResult<Unit>> Editar(int id, Editar.Ejecuta data)
        {
            data.CursoId = id;
            return await mediator.Send(data);
        }

        [HttpDelete("{id}")]

        public async Task<ActionResult<Unit>> Eliminar(int id){
            return await mediator.Send(new Eliminar.Ejecuta{Id= id});
        }
}

}