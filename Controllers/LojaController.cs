using JucaSystemWebApi.Dto;
using JucaSystemWebApi.Interfaces.IServices;
using JucaSystemWebApi.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JucaSystemWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LojaController : Controller
    {
        private readonly Context _context;
        private readonly ILojaService _lojaService;
        public LojaController(Context context, ILojaService lojaService)
        {
            _context = context;
            _lojaService = lojaService;
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var lojas = await _context.Lojas.ToListAsync();
            if (lojas.Count == 0)
                throw new System.Exception("Não foram encontrados registros de lojas.");
            return Ok(lojas);
        }
        /// <summary>
        /// busca pessoa por id
        /// </summary>
        /// <param name="id"></param>      
        [HttpGet("{id}")]
        public Loja GetById(int id)
        {
            var loja = _lojaService.GetLojaById(id);

            return loja;
        }

        #endregion

        #region Post
        /// <param name="entidade"></param>  
        [HttpPost]
        public bool PostLoja([FromBody] LojaDto entidade)
        {
            var novaLoja = _lojaService.InserirNovaLoja(entidade);

            return novaLoja;
        }



        #endregion

        #region Put
        /// <param name="loja"></param>  
        [HttpPut]
        public Loja PutLoja([FromBody] Loja loja)
        {
            var lojaAlterada = _lojaService.UpdateLoja(loja);
            return lojaAlterada;
        }
        #endregion
        
        #region Delete
        /// <param name="lojaId"></param>  
        [HttpDelete]
        public bool DeleteLoja(int lojaId)
        {
            var lojaExcluida = _lojaService.DeleteLoja(lojaId);
            return lojaExcluida;
        }
        #endregion

    }
}
