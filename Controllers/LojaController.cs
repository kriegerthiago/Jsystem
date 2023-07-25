using JucaSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace JucaSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LojaController : Controller
    {

        private readonly Context _context;
        public LojaController(Context context)
        {
            _context = context;
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
        public async Task<IActionResult> GetById(int id)
        {
            var pessoas = await _context.Lojas.FindAsync(id);

            return Ok(pessoas);
        }

        #endregion

        #region Post
        /// <param name="entidade"></param>  
        [HttpPost]
        public bool PostLoja([FromBody] Loja entidade)
        {
            try
            {
                if (entidade == null)
                {
                    return false;
                }
                else
                {
                    _context.Lojas.Add(entidade);
                    _context.SaveChanges();

                    return true;
                }

            }
            catch (System.Exception)
            {
                throw;
            }
        }



        #endregion

        #region Put
        /// <param name="loja"></param>  
        /// <param name="lojaId"></param>  
        [HttpPut]
        public bool PutLoja([FromBody] Loja loja, int lojaId)
        {
            try
            {
                var entidade = _context.Lojas.Where(p => p.LojaId == lojaId).FirstOrDefault();
                if (entidade == null)
                {
                    return false;
                }
                else
                {
                    var obj = new Loja()
                    {
                        DescricaoEndereco = loja.DescricaoEndereco,
                        DescricaoNome = loja.DescricaoNome,
                        LojaId = entidade.LojaId
                    };
                    _context.Lojas.Update(obj);
                    _context.SaveChanges();
                    return true;
                }

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
        public bool DeleteLoja([FromBody] int lojaId)
        {
            try
            {
                var loja = _context.Lojas.Where(p => p.LojaId == lojaId).FirstOrDefault();
                _context.Lojas.Remove(loja);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        #endregion

    }
}
