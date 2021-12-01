using System.Collections.Generic;

namespace API.Models
{
    public class Carrinho
    {
        public int Id { get; set; }
        public string Cliente { get; set; }
        public List<ItemVenda> ItensDoCarrinho { get; set; }
        public FormasDePagamento FormaPagamento { get; set; }
    }
}
