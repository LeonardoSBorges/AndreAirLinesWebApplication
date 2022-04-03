using AndreAirLinesWebApplication.Controllers;
using GeradorDados.ManipulaArquivos;
using System;
namespace GeradorDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Pessoa\n2 - Aeroporto\n3 - Aeronave");
            string opcao = Console.ReadLine();
            Console.WriteLine("Digite o caminho do arquivo json que contem os dados para polular o Banco: ");
            string pathFile = Console.ReadLine();
            switch (opcao) {
                case "1":
                    IManipulaJson manipulaJson = new ManipulaJson();
                    manipulaJson.PassageirosDeserialize(pathFile);
                    break;
                case "2":
                    
                    break;
                case "3":
                    break;
            }
        }
    }
}
