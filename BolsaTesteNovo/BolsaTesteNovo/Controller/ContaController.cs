using BolsaTesteNovo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using BolsaTesteNovo.Models;

namespace BolsaTesteNovo.Controller
{
    public class ContaController
    {
        private readonly BolsaContext _context;

        public ContaController(BolsaContext context)
        {
            _context = context;
        }

        public Conta GetConta()
        {
            return _context.Contas.First();
        }

        public void UpdateConta(Conta conta)
        {
            if (GetConta().Id == conta.Id)
            {
                try
                {
                    _context.Contas.Update(conta);
                    _context.SaveChanges();
                }
                catch (Exception)
                {

                    throw;
                }
            }
        }
    }
}
