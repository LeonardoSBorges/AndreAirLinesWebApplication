using GeradorDados.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeradorDados.ManipulaArquivos
{
    public interface IManipulaJson
    {
        void PassageirosDeserialize(string pathFile);
    }
}
