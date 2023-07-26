using JucaSystem.Dto;
using JucaSystem.Models;

namespace JucaSystem.Interfaces.IServices
{
    public interface IProdutoService
    {
        Produto GetProdutoById(int produtoId);
        bool InserirNovoProduto(ProdutoDto produtoModel);
        Produto UpdateProduto(Produto produtoModel);
        bool ExcluirProduto(int id);
    }
}
