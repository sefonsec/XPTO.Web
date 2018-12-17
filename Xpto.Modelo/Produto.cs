using System.Collections.Generic;
using System.ComponentModel;

namespace Xpto.Modelo
{
    public class Produto
    {
        public long Id { get; set; }

        public int IdArquivo { get; set; }

        [DisplayName("Descrição")]
        public string Descricao { get; set; }        
    }
}
