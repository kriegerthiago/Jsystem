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
    public class CompraController : Controller
    {
        private readonly Context _context;
        private readonly ICompraService _compraService;
        public CompraController(Context context, ICompraService compraService)
        {
            _context = context;
            _compraService = compraService;
        }

        #region Get

        /// <summary>
        /// busca pessoa por id
        /// </summary>
        /// <param name="pessoaId"></param>      
        [HttpGet("{pessoaId}")]
        public List<Compra> GetComprasPorPessoa(int pessoaId)
        {
            var compras = _compraService.GetComprasPorPessoa(pessoaId);
            return compras;
        }

        #endregion

        #region Post
        /// <param name="entidade"></param>  
        [HttpPost]
        public bool PostCompra([FromBody] CompraDto entidade)
        {
            var result = _compraService.NovaCompra(entidade);

            return result;
        }
        #endregion

        #region Put
        /// <param name="pessoaId"></param>  
        [HttpPut]
        public Compra PutCompras([FromBody] Compra compra)
        {
            var result = _compraService.UpdateCompra(compra);
            return result;
        }
        #endregion

        #region Delete
        /// <param name="compraId"></param>  
        [HttpDelete]
        public bool DeleteCompra(int compraId)
        {
            var result = _compraService.DeleteCompra(compraId);
            return result;
        }
        #endregion
    }
}
