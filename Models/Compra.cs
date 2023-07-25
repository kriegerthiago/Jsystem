using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace JucaSystem.Models
{
    public class Compra
    {
        public int CompraId { get; set; }
        public int PessoaId { get; set; }
        public int LojaId { get; set; }
        public int QuantidadeProduto { get; set; }
        public DateTime DataCompra { get; set; }
        public string DescricaoObservacao { get; set; }
        public short FoiPago { get; set; }

        #region Relacionamento
        public Pessoa Pessoa { get; set; }
        public List<ItemCompra> ItensCompra { get; set; }
        public Loja Loja { get; set; }

        #endregion
    }
}