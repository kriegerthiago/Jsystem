using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JucaSystem.Models
{
    public class ItemCompra
    {
        public int ItemCompraId { get; set; }
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeComprada { get; set; }
        public decimal ValorItem { get; set; }
        public int SequenciaItemCompra { get; set; }
        #region Relacionamento
        public Produto Produto { get; set; }
        public Compra Compra { get; set; }
        #endregion
    }
}
