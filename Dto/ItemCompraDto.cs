namespace JucaSystem.Dto
{
    public class ItemCompraDto
    {
        public int CompraId { get; set; }
        public int ProdutoId { get; set; }
        public int QuantidadeComprada { get; set; }
        public decimal ValorItem { get; set; }
        public int SequenciaItemCompra { get; set; }
    }
}
