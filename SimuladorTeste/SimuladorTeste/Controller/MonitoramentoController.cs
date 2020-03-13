using SimuladorTeste.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimuladorTeste.Controller
{
    public class MonitoramentoController
    {
        private readonly Model1 _context;

        public MonitoramentoController(Model1 context)
        {
            _context = context;
        }

        public void InserirtMonitoramento(Monitoramento monitoramento)
        {
            if (monitoramento != null)
            {
                _context.Monitoramentos.Add(monitoramento);
                _context.SaveChanges();
            }
        }
    }
}
