﻿using GerenciadorDeEstacionamento.Entidades;
using GerenciadorDeEstacionamento.Servicos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GerenciadorDeEstacionamento
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu menu = new Menu();

            menu.MenuInicial();
        }
    }
}
