using JucaSystem.Dto;
using JucaSystem.Helper;
using JucaSystem.Interfaces.IServices;
using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JucaSystem.Services
{
    public class ItemCompraService : IItemCompraService
    {
        private readonly Context _context;
        private readonly IIncrementoHelperService _incrementoHelpService;

        public ItemCompraService(Context context, IIncrementoHelperService incrementoHelperService)
        {
            _context = context;
            _incrementoHelpService = incrementoHelperService;
        }

        public List<ItemCompra> GetItensPorCompra(int compraId)
        {
            try
            {
                var itemCompra = _context.ItensCompras.Where(p => p.ItemCompraId == compraId).ToList();
                return itemCompra;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool NovoItemCompra(ItemCompraDto itemCompra)
        {
            try
            {
                var itemCompraId = _incrementoHelpService.ValidaIncremento(_context.ItensCompras, l => l.ItemCompraId);
                var sequenciaItemCompra = _incrementoHelpService.ValidaIncremento(_context.ItensCompras, l => l.SequenciaItemCompra);
                var novaCompra = new ItemCompra()
                {
                    ItemCompraId = itemCompraId,
                    CompraId = itemCompra.CompraId,
                    ProdutoId = itemCompra.ProdutoId,
                    QuantidadeComprada = itemCompra.QuantidadeComprada,
                    ValorItem = itemCompra.ValorItem,
                    SequenciaItemCompra = sequenciaItemCompra
                };
                _context.ItensCompras.Add(novaCompra);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }



        public ItemCompra UpdateItemCompra(ItemCompra itemCompra)
        {
            try
            {
                var entidade = _context.ItensCompras.AsNoTracking().Where(p => p.ItemCompraId == itemCompra.ItemCompraId && p.SequenciaItemCompra == itemCompra.SequenciaItemCompra).FirstOrDefault();
                var objAlteracao = new ItemCompra()
                {
                    ItemCompraId = entidade.ItemCompraId,
                    CompraId = itemCompra.CompraId,
                    ProdutoId = itemCompra.ProdutoId,
                    QuantidadeComprada = itemCompra.QuantidadeComprada,
                    ValorItem = itemCompra.ValorItem,
                    SequenciaItemCompra = itemCompra.SequenciaItemCompra
                };
                return objAlteracao;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool DeleteItemCompra(int itemCompraId)
        {
            var id = _context.ItensCompras.AsNoTracking().Where(p => p.ItemCompraId == itemCompraId).FirstOrDefault();
            if (id != null)
            {
                _context.ItensCompras.Remove(id);
                _context.SaveChanges();
                return true;
            }
            return false;
        }
    }
}

