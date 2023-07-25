using JucaSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace JucaSystem.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemCompraController : Controller
    {
        private readonly Context _context;
        public ItemCompraController(Context context)
        {
            _context = context;
        }

        #region Get

        /// <summary>
        /// busca pessoa por id
        /// </summary>
        /// <param name="compraId"></param>      
        [HttpGet("{compraId}")]
        public List<ItemCompra> GetItensPorCompra(int compraId)
        {
            var itensDaCompra = _context.ItensCompras.Where(p => p.CompraId == compraId).ToList();

            return itensDaCompra;
        }

        #endregion

        #region Post
        /// <param name="entidade"></param>  
        [HttpPost]
        public bool PostItemCompra([FromBody] ItemCompra entidade)
        {
            try
            {
                if (entidade == null)
                {
                    return false;
                }
                else
                {
                    _context.ItensCompras.Add(entidade);
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
        /// <param name="pessoaId"></param>  
        [HttpPut]
        public bool PutCompras([FromBody] ItemCompra itemcompra, int compraId)
        {
            try
            {
                var entidade = _context.ItensCompras.Where(p => p.CompraId == compraId).FirstOrDefault();
                if (entidade == null)
                {
                    return false;
                }
                else
                {
                    var obj = new ItemCompra()
                    {
                        CompraId = entidade.CompraId,
                        ItemCompraId = entidade.ItemCompraId,
                        ProdutoId = itemcompra.ProdutoId,
                        QuantidadeComprada = itemcompra.QuantidadeComprada,
                        ValorItem = itemcompra.ValorItem
                    };
                    _context.ItensCompras.Update(obj);
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
        /// <param name="compraId"></param>  
        [HttpDelete]
        public bool DeleteItemCompra([FromBody] int itemCompraId)
        {
            try
            {
                var compra = _context.ItensCompras.Where(p => p.ItemCompraId == itemCompraId).FirstOrDefault();
                _context.ItensCompras.Remove(compra);
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
