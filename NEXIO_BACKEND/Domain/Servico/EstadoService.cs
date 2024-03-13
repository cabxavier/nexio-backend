using Domain.Interface.IEstado;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    public class EstadoService : IEstadoService
    {

        private readonly IEstado IEstado;

        public EstadoService(IEstado IEstado)
        {
            this.IEstado = IEstado;
        }

        public async Task Insert(Estado Estado)
        {
            await this.IEstado.Insert(Estado);
        }

        public async Task Update(Estado Estado)
        {
            await this.IEstado.Update(Estado);
        }
    }
}
