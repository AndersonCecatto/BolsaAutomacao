using BolsaTesteNovo.Data;
using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Linq;
using BolsaTesteNovo.Models;
using BolsaTesteNovo.Models.Enum;

namespace BolsaTesteNovo.Controller
{
    public class NegociacaoController
    {
        private readonly BolsaContext _context;
        private MonitoramentoController _monitoramentoController;
        private ContaController _contaController;
        public NegociacaoController(BolsaContext context)
        {
            _context = context;
            _monitoramentoController = new MonitoramentoController(context);
            _contaController = new ContaController(context);
        }

        private List<Negociacao> GetNegociacaos()
        {
            return _context.Negociacaos.ToList();
        }

        private List<Negociacao> GetAcoes()
        {
            return _context.Negociacaos.Where(x => x.TipoOperacao == TipoOperacao.Compra.ToString()).ToList();
        }

        private List<Negociacao> GetNegociacaosPorTipo(TipoOperacao tipo)
        {
           return _context.Negociacaos.Where(x => x.TipoOperacao == tipo.ToString()).ToList();
        }

        public bool VerificarValorCompra(Monitoramento monitoramento, Conta conta)
        {
            return monitoramento.PrecoCompra <= conta.Saldo;
        }

        public void UpdateNegociacao(Monitoramento monitoramento, TipoOperacao tipoOperacao)
        {
            try
            {
                _context.Negociacaos.Add(new Negociacao()
                {
                    MonitoramentoId = monitoramento.Id,
                    Quantidade = 1,
                    ValorNegociado = tipoOperacao == TipoOperacao.Compra ? monitoramento.PrecoCompra : monitoramento.PrecoVenda,
                    TipoOperacao = tipoOperacao.ToString(),
                    DataHora = DateTime.Now
                });

                _context.SaveChanges();

            }
            catch (Exception)
            {
                throw;
            }
        }

        public void RegraCompra(List<Monitoramento> monitoramentos, Conta conta)
        {
            int contador = 0;

            while (contador < 100 || conta.Saldo < 0)
            {
                foreach (Monitoramento monitoramento in _monitoramentoController.GetUltimosMonitoramentos(monitoramentos))
                {
                    if (VerificarValorCompra(monitoramento, conta))
                    {
                        UpdateNegociacao(monitoramento, TipoOperacao.Compra);

                        conta.Saldo -= monitoramento.PrecoCompra;
                    }
                }

                monitoramentos = _monitoramentoController.GetMonitoramentos();
                contador++;
            }

            _contaController.UpdateConta(conta);
            RelatorioNegociacoes(TipoOperacao.Compra);
        }

        public void RegraVenda(Conta conta)
        {
            var acoes = GetAcoes().Count;

            while (acoes > 0 && conta.Saldo == 0)
            {
                Monitoramento monitoramento = _monitoramentoController.GetUltimoMonitoramento();

                UpdateNegociacao(monitoramento, TipoOperacao.Venda);

                conta.Saldo += monitoramento.PrecoVenda;

                acoes--;
            }

            _contaController.UpdateConta(conta);
            RelatorioNegociacoes(TipoOperacao.Venda);
        }


        public void RelatorioNegociacoes(TipoOperacao tipoOperacao)
        {
            var tipoRelatorio = tipoOperacao == TipoOperacao.Compra ? "relatorioCompra.txt" : "relatorioVenda.txt";

            StreamWriter stream = File.CreateText($"C:/Users/Anderson/Documents/Teste/{tipoRelatorio}"); ;

            stream.WriteLine("Relatório de Negociações");

            foreach (Negociacao negociacao in GetNegociacaosPorTipo(tipoOperacao))
            {
                stream.Write($"{negociacao.Monitoramento.Empresa}");
                stream.Write($" ");
                stream.Write($"{negociacao.Monitoramento.PrecoCompra}");
                stream.Write($" ");
                stream.Write($"{negociacao.ValorNegociado}");
                stream.WriteLine();
            }

            stream.Close();
        }
    }
}
