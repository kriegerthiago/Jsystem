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
    public class ProdutoController : Controller
    {
        private readonly Context _context;
        private readonly IProdutoService _produtoService;

        public ProdutoController(Context context, IProdutoService produtoService)
        {
            _context = context;
            _produtoService = produtoService;
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
        public Produto GetById(int id)
        {
            var produtos = _produtoService.GetProdutoById(id);
            return produtos;
        }

        #endregion

        #region Post
        /// <param name="entidade"></param>  
        [HttpPost]
        public bool PostPessoa([FromBody] ProdutoDto entidade)
        {
            try
            {
                var produto = _produtoService.InserirNovoProduto(entidade);

                return produto;

            }
            catch (System.Exception)
            {
                throw;
            }
        }



        #endregion

        #region Put
        /// <param name="produto"></param>  
        [HttpPut]
        public Produto PutProduto([FromBody] Produto produto)
        {
            try
            {
                var objProduto = _produtoService.UpdateProduto(produto);

                return objProduto;

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
        public bool DeletePessoa(int produtoId)
        {
            try
            {
                var produto = _produtoService.ExcluirProduto(produtoId);
                return produto;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
