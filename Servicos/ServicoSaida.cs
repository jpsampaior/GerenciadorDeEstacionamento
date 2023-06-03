using GerenciadorDeEstacionamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstacionamento.Servicos
{
    internal class ServicoSaida
    {
        public ServicoEntrada ServicoEntrada { get; set; }
        public TimeSpan HoraSaida { get; set; }
        public float ValorPrimeirasHoras { get; set; }
        public float ValorFracaoHora { get; set; }
        public double TempoEstacionado { get; set; }

        public ServicoSaida(ServicoEntrada servicoEntrada, TimeSpan horaSaida, float valorPrimeirasHoras, float valorFracaoHora)
        {
            ServicoEntrada = servicoEntrada;
            HoraSaida = horaSaida;
            ValorPrimeirasHoras = valorPrimeirasHoras;
            ValorFracaoHora = valorFracaoHora;
            TempoEstacionado = (HoraSaida - ServicoEntrada.HoraEntrada).TotalHours;
        }

        public double calcularValor()
        {
            if (TempoEstacionado > 0.25)
            {
                if (TempoEstacionado > 3)
                {
                    return ValorPrimeirasHoras + (Math.Ceiling(TempoEstacionado - 3) * ValorFracaoHora);
                }
                else
                {
                    return ValorPrimeirasHoras;
                }

            }
            return 0;
        }

        public void processarSaida()
        {
            double minutosDoCarro = (TempoEstacionado - Math.Floor(TempoEstacionado)) * 60;

            Console.WriteLine($"\nTempo Estacionado: {string.Format("{0:0}", TempoEstacionado)} horas e {string.Format("{0:0}", minutosDoCarro)} minutos.\n" +
                $"Valor a Pagar: R$ {string.Format("{0:0.00}", calcularValor())}.\n");
        }
    }
}
