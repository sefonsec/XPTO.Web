using System.ComponentModel;

namespace Xpto.Modelo
{
    public class ClienteProduto
    {
        public long Id { get; set; }

        [DisplayName("Cliente")]
        public long ClienteId { get; set; }

        [DisplayName("Cliente")]
        public Cliente Cliente { get; set; }

        [DisplayName("`Produto")]
        public long ProdutoId { get; set; }

        [DisplayName("`Produto")]
        public Produto Produto { get; set; }
    }
}
