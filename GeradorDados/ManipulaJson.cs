using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace GeradorDados
{
    public class ManipulaJson
    {
        public void PersonDeserialize(string pathFile)
        {
            var jsonString = JsonSerializer.Serialize(pathFile);
            return jsonString;
        }

    }
}
