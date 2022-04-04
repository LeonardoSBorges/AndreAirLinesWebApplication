using AndreAirLinesWebApplication.Model;
using AndreAirLinesWebApplication.Service;
using Robo;
using System;
using System.Collections.Generic;

namespace RoboBancoDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Gerar Relatorio de precos mais recentes\n2 - Gerar um relatorio para analisar ");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    GeraRelatorio.GeraRelatorioComprasPasagens();
                    break;
                case "2":
                    GeraRelatorio.GeraRelatorioPrecoBaseRecente();
                    break;
            }
        }
    }
}
