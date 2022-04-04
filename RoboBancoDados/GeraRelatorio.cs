using AndreAirLinesWebApplication.Model;
using AndreAirLinesWebApplication.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Robo
{
    public class GeraRelatorio
    {
        public static void GeraRelatorioComprasPasagens()
        {
            RelatoriosService.RelatorioComprasPassagem().Wait();

            Console.WriteLine("O relatorio foi gerado com sucesso!");
            Console.ReadLine();
        }
        public static void GeraRelatorioPrecoBaseRecente()
        {
            RelatoriosService.RelatorioPrecoRecente().Wait();

            Console.WriteLine("O relatorio foi gerado com sucesso!");
            Console.ReadLine();
        }
    }
}
