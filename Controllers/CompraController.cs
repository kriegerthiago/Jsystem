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
    public class CompraController : Controller
    {
        private readonly Context _context;
        public CompraController(Context context)
        {
            _context = context;
        }

        #region Get

        /// <summary>
        /// busca pessoa por id
        /// </summary>
        /// <param name="pessoaId"></param>      
        [HttpGet("{pessoaId}")]
        public List<Compra> GetComprasPorPessoa(int pessoaId)
        {
            var compras = _context.Compras.Where(p => p.PessoaId == pessoaId).ToList();

            return compras;
        }

        #endregion

        #region Post
        /// <param name="entidade"></param>  
        [HttpPost]
        public bool PostCompra([FromBody] Compra entidade)
        {
            try
            {
                if (entidade == null)
                {
                    return false;
                }
                else
                {
                    _context.Compras.Add(entidade);
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
        public bool PutCompras([FromBody] Compra compra, int compraId)
        {
            try
            {
                var entidade = _context.Compras.Where(p => p.CompraId == compraId).FirstOrDefault();
                if (entidade == null)
                {
                    return false;
                }
                else
                {
                    var obj = new Compra()
                    {
                        CompraId = entidade.CompraId,
                        DataCompra = compra.DataCompra,
                        DescricaoObservacao = compra.DescricaoObservacao,
                        FoiPago = compra.FoiPago,
                        LojaId = compra.LojaId,
                        QuantidadeProduto = compra.QuantidadeProduto,
                        PessoaId = compra.PessoaId
                    };
                    _context.Compras.Update(obj);
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
        public bool DeleteCompra([FromBody] int compraId)
        {
            try
            {
                var compra = _context.Compras.Where(p => p.CompraId == compraId).FirstOrDefault();
                _context.Compras.Remove(compra);
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
