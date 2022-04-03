using RoboInsereDados.Service;
using System;

namespace RoboInsereDados
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("1 - Inserir aeronaves");
            string opcao = Console.ReadLine();

            switch (opcao)
            {
                case "1":
                    Console.WriteLine("A acao foi iniciada");
                    InsereAeronaveHttp.PopulaAeronavePost();
                    Console.WriteLine("A acao foi um sucesso, aeronavez inseridas");
                break;
            }
        }
    }
}
