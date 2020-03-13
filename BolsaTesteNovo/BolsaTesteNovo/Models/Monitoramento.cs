using System;
using System.Collections.Generic;
using System.Text;

namespace BolsaTesteNovo.Models
{
    public class Monitoramento
    {
        public int Id { get; set; }
        public string Empresa { get; set; }
        public decimal PrecoCompra { get; set; }
        public decimal PrecoVenda { get; set; }
    }
}
