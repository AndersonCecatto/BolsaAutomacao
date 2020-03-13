namespace SimuladorTeste.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Monitoramentos")]
    public partial class Monitoramento
    {
        public int Id { get; set; }

        public string Empresa { get; set; }

        public decimal PrecoCompra { get; set; }

        public decimal PrecoVenda { get; set; }
    }
}
