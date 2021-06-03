using System;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class Nuevo
    {
        public class Ejecuta:IRequest
        {
            
        
        public string Titulo { get; set; }

        public string  Descripcion { get; set; }

        public DateTime FechaPublicacion { get; set; }
       

        }
        public class Manejador : IRequestHandler<Ejecuta>
        {
            private readonly CursosOnlineContext context;

            public Manejador(CursosOnlineContext context)
            {
                this.context = context;
            }

            public async Task<Unit> Handle(Ejecuta request, CancellationToken cancellationToken)
            {
                var curso = new Curso{
                   Titulo = request.Titulo,
                   Descripcion = request.Descripcion,
                   FechaPublicacion = request.FechaPublicacion
                };

              context.Curso.Add(curso);
              var valor =await context.SaveChangesAsync();
              if(valor>0){
                  return Unit.Value;
              }

              throw new Exception("No se inserto el curso");
            }
        }
    }
}