using System;

namespace JucaSystem.Dto
{
    public class CompraDto
    {
        public int PessoaId { get; set; }
        public int LojaId { get; set; }
        public int QuantidadeProduto { get; set; }
        public DateTime DataCompra { get; set; }
        public string DescricaoObservacao { get; set; }
        public short FoiPago { get; set; }
    }
}
