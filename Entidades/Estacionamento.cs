using GerenciadorDeEstacionamento.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace GerenciadorDeEstacionamento.Entidades
{
    internal class Estacionamento
    {
        Carro[,] vagas;
        List<ServicoEntrada> servicosEntradas;
        List<ServicoSaida> servicoSaidas;
        float valorPrimeiraHora;
        float valorFracaoHora;

        public Estacionamento(float valorPrimeiraHora, float valorFracaoHora)
        {
            this.vagas = new Carro[5, 5];
            this.servicosEntradas = new List<ServicoEntrada>();
            this.servicoSaidas = new List<ServicoSaida>();
            this.valorPrimeiraHora = valorPrimeiraHora;
            this.valorFracaoHora = valorFracaoHora;
        }
        public bool verificaPlaca(string placa)
        {
            const string padraoPlacaNova = @"^[A-Z][A-Z][A-Z][0-9][A-Z][0-9][0-9]$";
            const string padraoPlacaVelha = @"^[A-Z][A-Z][A-Z][0-9][0-9][0-9][0-9]$";

            bool boolean_placaVelha = Regex.IsMatch(placa, padraoPlacaVelha);
            bool boolean_placaNova = Regex.IsMatch(placa, padraoPlacaNova);

            if (boolean_placaVelha || boolean_placaNova)
            {
                return true;
            }
            else
            {
                return false;
            }
        }


        public bool carIsParked(string placa)
        {

            if (servicosEntradas.Find(x => x.Carro.Placa == placa) != null)
            {
                return true;
            }
            else { return false; }



        }

        public void EstacionarCarro(string placa, TimeSpan time)
        {
            Carro novoCarro = new Carro(placa);

            bool encontrouVazia = false;
            int linhaVazia = -1;
            int colunaVazia = -1;

            for (int i = 0; i < vagas.GetLength(0); i++)
            {
                for (int j = 0; j < vagas.GetLength(1); j++)
                {
                    if (vagas[i, j] == null)
                    {
                        linhaVazia = i;
                        colunaVazia = j;
                        encontrouVazia = true;
                        break;
                    }
                }

                if (encontrouVazia)
                {
                    vagas[linhaVazia, colunaVazia] = novoCarro;
                    break;
                }

            }

            int[] posicao = { linhaVazia, colunaVazia };
            servicosEntradas.Add(new ServicoEntrada(novoCarro, posicao, time));
        }

        public void RetirarCarro(string placa, TimeSpan time)
        {
            ServicoSaida servicoSaida = new ServicoSaida(servicosEntradas.Find(x => x.Carro.Placa == placa), time, valorPrimeiraHora, valorFracaoHora);

            vagas[servicoSaida.ServicoEntrada.Posicao[0], servicoSaida.ServicoEntrada.Posicao[1]] = null;
            servicoSaida.processarSaida();
            servicoSaidas.Add(servicoSaida);
            servicosEntradas.Remove(servicosEntradas.Find(x => x.Carro.Placa == placa));
        }

        public string printMatriz()
        {
            string retorno = "";

            for (int contadorLinha = 0; contadorLinha < vagas.GetLength(0); contadorLinha++)
            {
                for (int contadorColuna = 0; contadorColuna < vagas.GetLength(1); contadorColuna++)
                {
                    Carro atual = vagas[contadorLinha, contadorColuna];
                    if (atual == null) retorno += "Vazio ";
                    else retorno += atual.Placa + " ";
                }

                retorno += "\n";
            }
            return retorno;
        }
        public override string ToString()
        {
            return "Valor a ser cobrado para as primeiras 3 horas estacionado: " + valorPrimeiraHora +
                "\nValor a ser cobrado para demais frações de horas: " + valorFracaoHora +
                "\n\nCarros estacionados:\n" + printMatriz();
        }
    }
}

