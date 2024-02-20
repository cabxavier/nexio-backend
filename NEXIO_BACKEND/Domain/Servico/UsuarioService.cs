using Domain.Interface.IUsuario;
using Domain.Interface.Service;
using Entities.Entidade;

namespace Domain.Servico
{
    // aqui entra a validação da classe notificar
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuario IUsuario;

        public UsuarioService(IUsuario IUsuario)
        {
            this.IUsuario = IUsuario;
        }

        public async Task Insert(Usuario Usuario)
        {
            await this.IUsuario.Insert(Usuario);
        }

        public async Task Update(Usuario Usuario)
        {
            await this.IUsuario.Update(Usuario);
        }
    }
}
