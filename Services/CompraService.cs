using JucaSystem.Dto;
using JucaSystem.Helper;
using JucaSystem.Interfaces.IServices;
using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace JucaSystem.Services
{
    public class CompraService : ICompraService
    {
        private readonly Context _context;
        private readonly IIncrementoHelperService _incrementoHelpService;

        public CompraService(Context context, IIncrementoHelperService incrementoHelperService)
        {
            _context = context;
            _incrementoHelpService = incrementoHelperService;
        }

        public List<Compra> GetComprasPorPessoa(int pessoaId)
        {
            try
            {
                var compra = _context.Compras.Where(p => p.PessoaId == pessoaId).ToList();
                return compra;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool NovaCompra(CompraDto compra)
        {
            try
            {
                var compraId = _incrementoHelpService.ValidaIncremento(_context.Compras, l => l.CompraId);
                var novaCompra = new Compra()
                {
                    CompraId = compraId,
                    DataCompra = compra.DataCompra,
                    DescricaoObservacao = compra.DescricaoObservacao,
                    FoiPago = compra.FoiPago,
                    PessoaId = compra.PessoaId,
                    LojaId = compra.LojaId,
                    QuantidadeProduto = compra.QuantidadeProduto

                };
                _context.Compras.Add(novaCompra);
                _context.SaveChanges();
                return true;

            }
            catch (System.Exception)
            {

                throw;
            }

        }

        public Compra UpdateCompra(Compra compra)
        {
            try
            {
                var entidade = _context.Compras.AsNoTracking().Where(p => p.CompraId == compra.CompraId).FirstOrDefault();
                var compraAlteracao = new Compra()
                {
                    CompraId = entidade.CompraId,
                    DataCompra = compra.DataCompra,
                    DescricaoObservacao = compra.DescricaoObservacao,
                    FoiPago = compra.FoiPago,
                    PessoaId = compra.PessoaId,
                    LojaId = compra.LojaId,
                    QuantidadeProduto = compra.QuantidadeProduto
                };
                _context.Compras.Update(compraAlteracao);
                _context.SaveChanges();
                return compraAlteracao;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public bool DeleteCompra(int compraId)
        {
            try
            {
                var compra = _context.Compras.AsNoTracking().Where(p => p.CompraId == compraId).FirstOrDefault();
                _context.Compras.Remove(compra);
                _context.SaveChanges();
                return true;
            }
            catch (System.Exception)
            {

                throw;
            }
        }

    }
}
