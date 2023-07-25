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
    public class ProdutoController : Controller
    {
        private readonly Context _context;

        public ProdutoController(Context context)
        {
            _context = context;
        }

        #region Get

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var produtos = await _context.Produtos.ToListAsync();
            if (produtos.Count == 0)
                throw new System.Exception("Não foram encontrados registros de produtos.");
            return Ok(produtos);
        }
        /// <summary>
        /// busca pessoa por id
        /// </summary>
        /// <param name="id"></param>      
        [HttpGet("{id}")]
        public async Task<IActionResult> GetById(int id)
        {
            var produtos = await _context.Produtos.FindAsync(id);

            return Ok(produtos);
        }

        #endregion

        #region Post
        /// <param name="entidade"></param>  
        [HttpPost]
        public bool PostPessoa([FromBody] Produto entidade)
        {
            try
            {
                if (entidade == null)
                {
                    return false;
                }
                else
                {
                    _context.Produtos.Add(entidade);
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
        /// <param name="produtoId"></param>  
        [HttpPut]
        public bool PutPessoa([FromBody] Produto produto, int produtoId)
        {
            try
            {
                var entidade = _context.Produtos.Where(p => p.ProdutoId == produtoId).FirstOrDefault();
                if (entidade == null)
                {
                    return false;
                }
                else
                {
                    var obj = new Produto()
                    {
                        ProdutoId = entidade.ProdutoId,
                        DescricaoObservacao = produto.DescricaoObservacao,
                        DescricaoProduto = produto.DescricaoObservacao,
                        ValorProduto = produto.ValorProduto
                    };
                    _context.Produtos.Update(obj);
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
        /// <param name="produtoId"></param>  
        [HttpDelete]
        public bool DeletePessoa([FromBody] int produtoId)
        {
            try
            {
                var produto = _context.Produtos.Where(p => p.ProdutoId == produtoId).FirstOrDefault();
                _context.Produtos.Remove(produto);
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
