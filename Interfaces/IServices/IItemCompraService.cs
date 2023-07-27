using JucaSystem.Dto;
using JucaSystem.Models;
using System.Collections.Generic;

namespace JucaSystem.Interfaces.IServices
{
    public interface IItemCompraService
    {
        List<ItemCompra> GetItensPorCompra(int compraId);
        bool NovoItemCompra(ItemCompraDto compra);
        ItemCompra UpdateItemCompra(ItemCompra itemCompra);
        bool DeleteItemCompra(int itemCompraId);
    }
}
