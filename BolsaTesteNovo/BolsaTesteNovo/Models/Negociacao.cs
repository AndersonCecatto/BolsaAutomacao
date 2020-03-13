using System;
using System.Collections.Generic;
using System.Text;

namespace BolsaTesteNovo.Models
{
    public class Negociacao
    {
        public int Id { get; set; }
        public int MonitoramentoId { get; set; }
        public Monitoramento Monitoramento { get; set; }
        public decimal ValorNegociado { get; set; }
        public DateTime DataHora { get; set; }
        public int Quantidade { get; set; }
        public string TipoOperacao { get; set; }
    }
}
