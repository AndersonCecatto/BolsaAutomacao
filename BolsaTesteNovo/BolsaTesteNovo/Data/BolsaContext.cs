using BolsaTesteNovo.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BolsaTesteNovo.Data
{
    public class BolsaContext : DbContext
    {
        public BolsaContext()
        {

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Integrated Security=SSPI;Persist Security Info=False;User ID=sa;Initial Catalog=DBBolsa;Data Source=ANDERSON\\MSSQLSERVER01");
        }

        public DbSet<Conta> Contas { get; set; }
        public DbSet<Monitoramento> Monitoramentos { get; set; }
        public DbSet<Negociacao> Negociacaos { get; set; }
    }
}
