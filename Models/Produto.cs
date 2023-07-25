using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JucaSystem.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        public string DescricaoProduto { get; set; }
        public decimal ValorProduto { get; set; }
        public decimal? QuantidadeMultiploProduto { get; set; }
        public string DescricaoObservacao { get; set; }


        #region Relacionamento
        public ItemCompra ItemCompra { get; set; }
        #endregion
    }
}