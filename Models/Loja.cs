using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace JucaSystem.Models
{
    public class Loja
    {
        public int LojaId { get; set; }
        public string DescricaoNome { get; set; }
        public string DescricaoEndereco { get; set; }


        #region Relacionamentos
        public Compra Compras { get; set; }
        #endregion
    }
}
