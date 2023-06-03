using GerenciadorDeEstacionamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstacionamento.Servicos
{
    internal class ServicoEntrada
    {
        public Carro Carro { get; set; }
        public TimeSpan HoraEntrada { get; set; }
        public int[] Posicao { get; set; }

        public ServicoEntrada(Carro carro, int[] posicao, TimeSpan time)
        {
            Carro = carro;
            HoraEntrada = time;
            Posicao = posicao;
            gerarTicket();
        }

        public void gerarTicket()
        {
            Console.WriteLine("\nCarro Adicionado! \n" +
                $"Vaga: {Posicao[0] * 10 + Posicao[1] + 1} \n" +
                Carro.ToString());
        }
    }
}
