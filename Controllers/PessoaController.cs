using JucaSystem.Dto;
using JucaSystem.Interfaces.IServices;
using JucaSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JucaSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PessoaController : Controller
    {
        private readonly Context _context;
        private readonly IPessoaService _pessoaService;
        public PessoaController(Context context, IPessoaService pessoaService)
        {
            _context = context;
            _pessoaService = pessoaService;
        }
        // GET: PessoaController
        #region Get

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var pessoas = await _context.Pessoas.Include(p => p.Compras).ToListAsync();
            if (pessoas.Count == 0)
                throw new System.Exception("Não foram encontrados registros de pessoas.");
            return Ok(pessoas);
        }
        /// <summary>
        /// busca pessoa por id
        /// </summary>
        /// <param name="id"></param>      
        [HttpGet("{id}")]
        public List<Pessoa> GetById(int id)
        {
            var pessoas = _pessoaService.GetPessoaById(id);
            return pessoas;
        }

        #endregion

        #region Post
        /// <param name="entidade"></param>  
        [HttpPost("InserirPessoa")]
        public bool PostPessoa([FromBody] PessoaDto entidade)
        {
            try
            {
                if (entidade != null)
                {
                    var pessoaAdicionada = _pessoaService.InserirNovaPessoa(entidade);
                    return pessoaAdicionada;
                }
                else
                {
                    throw new System.Exception("Não foi encontrado pessoa para adicionar");
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }



        #endregion

        #region Put
        /// <param name="pessoaId"></param>  
        [HttpPut]
        public Pessoa PutPessoa([FromBody] Pessoa pessoaModel)
        {
            try
            {
                var pessoa = _pessoaService.UpdatePessoa(pessoaModel);
                return pessoa;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        #endregion

        #region Delete
        /// <param name="pessoaId"></param>  
        [HttpDelete]
        public bool DeletePessoa(int pessoaId)
        {
            try
            {
                var pessoa = _pessoaService.DeletePessoa(pessoaId);

                return pessoa;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        #endregion
    }
}


