using System;

namespace API.Models
{
    public class FormasDePagamento
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public bool ImprimirComprovante { get; set; }
        public DateTime CriadoEm { get; set; }
    }
}
