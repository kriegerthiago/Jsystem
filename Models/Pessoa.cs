using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JucaSystem.Models
{
    public class Pessoa
    {
        public int PessoaId { get; set; }
        public string DescricaoNome { get; set; }
        public string NumeroTelefone { get; set; }
        public string NumeroDDD { get; set; }
        public string DescricaoObservacaoReferencia { get; set; }

        #region Relacionamentos
        public Compra Compras { get; set; }
        #endregion
    }
}
