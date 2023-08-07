using Juca.Application.Dto;
using Juca.Application.Interfaces.IServices;
using Juca.Domain.Models;
using JucaSystemWebApi.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JucaSystemWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ItemCompraController : Controller
    {
        private readonly Context _context;
        private readonly IItemCompraService _itemCompraService;

        public ItemCompraController(Context context, IItemCompraService itemCompraService)
        {
            _context = context;
            _itemCompraService = itemCompraService;
        }

        #region Get

        /// <summary>
        /// busca pessoa por id
        /// </summary>
        /// <param name="compraId"></param>      
        [HttpGet("{compraId}")]
        public List<ItemCompra> GetItensPorCompra(int compraId)
        {
            var itensDaCompra = _itemCompraService.GetItensPorCompra(compraId);

            return itensDaCompra;
        }

        #endregion

        #region Post
        /// <param name="entidade"></param>  
        [HttpPost]
        public bool PostItemCompra([FromBody] ItemCompraDto entidade)
        {
            var result = _itemCompraService.NovoItemCompra(entidade);

            return result;
        }



        #endregion

        #region Put
        /// <param name="itemCompra"></param>  
        [HttpPut]
        public ItemCompra PutCompras([FromBody] ItemCompra itemcompra)
        {
            var result = _itemCompraService.UpdateItemCompra(itemcompra);
            return result;
        }
        #endregion

        #region Delete
        /// <param name="itemCompraId"></param>  
        [HttpDelete]
        public bool DeleteItemCompra(int itemCompraId)
        {
            try
            {
                var itemDeletado = _itemCompraService.DeleteItemCompra(itemCompraId);
                return itemDeletado;
            }
            catch (System.Exception)
            {

                throw;
            }
        }
        #endregion
    }
}
