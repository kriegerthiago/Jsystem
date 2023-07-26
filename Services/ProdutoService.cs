using JucaSystem.Dto;
using JucaSystem.Helper;
using JucaSystem.Interfaces.IServices;
using JucaSystem.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace JucaSystem.Services
{
    public class ProdutoService : IProdutoService
    {
        private readonly Context _context;
        private readonly IIncrementoHelperService _incrementoHelpService;

        public ProdutoService(Context context, IIncrementoHelperService incrementoHelperService)
        {
            _context = context;
            _incrementoHelpService = incrementoHelperService;
        }


        public Produto GetProdutoById(int produtoId)
        {
            var produto = _context.Produtos.Where(p => p.ProdutoId == produtoId).FirstOrDefault();

            return produto;
        }

        public bool InserirNovoProduto(ProdutoDto produtoModel)
        {

            try
            {
                if (produtoModel != null)
                {
                    int produtoId = _incrementoHelpService.ValidaIncremento(_context.Produtos, p => p.ProdutoId);

                    var objProduto = new Produto()
                    {

                        ProdutoId = produtoId,
                        DescricaoObservacao = produtoModel.DescricaoObservacao,
                        DescricaoProduto = produtoModel.DescricaoProduto,
                        QuantidadeMultiploProduto = produtoModel.QuantidadeMultiploProduto,
                        ValorProduto = produtoModel.ValorProduto
                    };
                    _context.Produtos.Add(objProduto);
                    _context.SaveChanges();
                }
                return true;

            }
            catch (System.Exception)
            {

                throw;
            }
        }

        public Produto UpdateProduto(Produto produtoModel)
        {

            var entidade = _context.Produtos.AsNoTracking().Where(p => p.ProdutoId == produtoModel.ProdutoId).FirstOrDefault();

            var objProduto = new Produto()
            {

                ProdutoId = entidade.ProdutoId,
                DescricaoObservacao = produtoModel.DescricaoObservacao,
                DescricaoProduto = produtoModel.DescricaoProduto,
                QuantidadeMultiploProduto = produtoModel.QuantidadeMultiploProduto,
                ValorProduto = produtoModel.ValorProduto
            };

            _context.Update(objProduto);
            _context.SaveChanges();

            return objProduto;

        }

        public bool ExcluirProduto(int id)
        {
            try
            {
                var produto = _context.Produtos.Where(p => p.ProdutoId == id).FirstOrDefault();
                if (produto != null)
                {
                    _context.Produtos.Remove(produto);
                    _context.SaveChanges();
                }
                return true;

            }
            catch (System.Exception)
            {

                throw;
            }
        }


    }
}
