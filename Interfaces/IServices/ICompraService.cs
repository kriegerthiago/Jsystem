using JucaSystem.Dto;
using JucaSystem.Models;
using System.Collections.Generic;

namespace JucaSystem.Interfaces.IServices
{
    public interface ICompraService
    {
        List<Compra> GetComprasPorPessoa(int pessoaId);
        bool NovaCompra(CompraDto compra);
        Compra UpdateCompra(Compra compra);
        bool DeleteCompra(int compraId);
    }
}
