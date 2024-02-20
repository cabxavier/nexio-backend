﻿using Domain.Interface.IPessoa;
using Domain.Interface.Service;
using Entities.Entidade;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PessoaController : ControllerBase
    {
        private readonly IPessoa IPessoa;
        private readonly IPessoaService IPessoaService;

        public PessoaController(IPessoa IPessoa, IPessoaService IPessoaService)
        {
            this.IPessoa = IPessoa;
            this.IPessoaService = IPessoaService;
        }

        [HttpGet("/api/pessoa/ListarPessoa")]
        [Produces("application/json")]
        public async Task<object> ListarPessoa()
        {
            return await this.IPessoa.ListarPessoa();
        }

        [HttpPost("/api/pessoa/Insert")]
        [Produces("application/json")]
        public async Task<object> Insert(Pessoa Pessoa)
        {
            await this.IPessoaService.Insert(Pessoa);

            return Task.FromResult(Pessoa);
        }

        [HttpPut("/api/pessoa/Update")]
        [Produces("application/json")]
        public async Task<object> Update(Pessoa Pessoa)
        {
            await this.IPessoaService.Update(Pessoa);

            return Task.FromResult(Pessoa);
        }

        [HttpDelete("/api/pessoa/Delete")]
        [Produces("application/json")]
        public async Task<object> Delete(int IdPessoa)
        {
            var Pessoa = await this.IPessoa.GetEntityById(IdPessoa);

            if (Pessoa != null)
            {
                await this.IPessoa.Delete(Pessoa);

                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
