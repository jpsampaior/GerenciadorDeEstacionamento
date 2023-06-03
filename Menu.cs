using GerenciadorDeEstacionamento.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace GerenciadorDeEstacionamento
{
    internal class Menu
    {
        Estacionamento estacionamento;
        float valorPrimeirasHoras;
        float valorFracaoHora;
        string placaCarro;
        int hora;
        int minuto;

        public string MsgMenuInicial()
        {
            return "Bem vindo ao menu inicial, qual ação você deseja iniciar?\n" +
                "[1] Configurar informações do estacionamento \n" +
                "[2] Adicionar carro no sistema de estacionamento \n" +
                "[3] Remover carro do sistema de estacionamento \n" +
                "[4] Informações do estacionamento \n" +
                "Sua Escolha: ";
        }

        public void MenuInicial()
        {
            Console.Write(MsgMenuInicial());
            int escolha = int.Parse(Console.ReadLine());

            Console.WriteLine();

            switch (escolha)
            {
                case 1:
                    AdicionarValorPrimeirasHoras();
                    break;
                case 2:
                    AdicionarPlacaEntrada();
                    break;
                case 3:
                    AdicionarPlacaSaida();
                    break;
                case 4:
                    imprimirEstacionamento();
                    break;
            }
        }

        public void AdicionarValorPrimeirasHoras()
        {
            Console.WriteLine("Valor a ser cobrado para as primeiras 3 horas estacionado:");
            Console.Write("R$: ");
            valorPrimeirasHoras = float.Parse(Console.ReadLine());

            AdicionarValorFracaoHora();
        }

        public void AdicionarValorFracaoHora()
        {
            Console.WriteLine("Valor a ser cobrado para demais frações de horas:");
            Console.Write("R$: ");
            valorFracaoHora = float.Parse(Console.ReadLine());
            estacionamento = new Estacionamento(valorPrimeirasHoras, valorFracaoHora);
            Console.WriteLine();
            Console.WriteLine("Cadastro dos valores concluído!");

            Console.WriteLine();
            MenuInicial();
        }

        public void AdicionarPlacaEntrada()
        {
            Console.WriteLine("Digite a placa do veículo a ser estacionado:");
            Console.Write("Placa: ");
            placaCarro = Console.ReadLine();
            if (estacionamento.verificaPlaca(placaCarro))
            {
                AdicionarHoraEntrada();
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Tente novamente. \nA placa do carro deve seguir os padrões: AAA0AOO ou AAA0000\n");
                MenuInicial();
            }
        }

        public void AdicionarHoraEntrada()
        {
            Console.WriteLine("Digite a hora e minuto em que o veículo entrou no estacionamento (Formato 24Hrs):");
            Console.Write("Hora: ");
            hora = int.Parse(Console.ReadLine());
            AdicionarMinutoEntrada();
        }

        public void AdicionarMinutoEntrada()
        {
            Console.Write("Minuto: ");
            minuto = int.Parse(Console.ReadLine());
            estacionamento.EstacionarCarro(placaCarro, new TimeSpan(hora, minuto, 0));
            Console.WriteLine();

            MenuInicial();
        }

        public void AdicionarPlacaSaida()
        {
            Console.WriteLine("Digite a placa do veículo que saiu do estacionamento:");
            Console.Write("Placa: ");
            placaCarro = Console.ReadLine();
            if (estacionamento.verificaPlaca(placaCarro))
            {
                if (estacionamento.carIsParked(placaCarro))
                {
                    AdicionarHoraSaida();
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine("Esse carro de placa: " + placaCarro + " não está no estacionamento.\nTente novamente.\n");
                    MenuInicial();
                }
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine("Tente novamente. \nA placa do carro deve seguir os padrões: AAA0AOO ou AAA0000\n");
                MenuInicial();
            }
        }


        public void AdicionarHoraSaida()
        {
            Console.WriteLine("Digite a hora e minuto em que o veículo saiu do estacionamento (Formato 24Hrs):");
            Console.Write("Hora: ");
            hora = int.Parse(Console.ReadLine());
            AdicionarMinutoSaida();
        }

        public void AdicionarMinutoSaida()
        {
            Console.Write("Minuto: ");
            minuto = int.Parse(Console.ReadLine());
            estacionamento.RetirarCarro(placaCarro, new TimeSpan(hora, minuto, 0));

            MenuInicial();
        }
        public void imprimirEstacionamento()
        {
            Console.WriteLine(estacionamento.ToString());
            Console.WriteLine();
            MenuInicial();
        }
    }
}
