using BolsaTesteNovo.Data;
using BolsaTesteNovo.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace BolsaTesteNovo.Controller
{
    public class MonitoramentoController
    {
        private readonly BolsaContext _context;

        public MonitoramentoController(BolsaContext context)
        {
            _context = context;
        }

        public List<Monitoramento> GetMonitoramentos()
        {
            return _context.Monitoramentos.ToList();
        }

        public List<Monitoramento> GetUltimosMonitoramentos(List<Monitoramento> MonitoramentosList)
        {
            List<Monitoramento> monitoramentosBanco = GetMonitoramentos();
            List<Monitoramento> monitoramentosNovos = new List<Monitoramento>();

            if (monitoramentosBanco.Count > MonitoramentosList.Count)
            {
                foreach (Monitoramento monitoramento in monitoramentosBanco)
                {
                    if (!MonitoramentosList.Contains(monitoramento))
                    {
                        monitoramentosNovos.Add(monitoramento);
                    }
                }

            }
                return monitoramentosNovos;
        }

        public Monitoramento GetUltimoMonitoramento()
        {
            return _context.Monitoramentos.OrderByDescending(x => x.Id).FirstOrDefault();
        }
    }
}
