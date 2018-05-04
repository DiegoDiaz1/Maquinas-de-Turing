using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TuringMachines
{
    public class Machine
    {
        char[] cinta;
        char[] dictionary;
        string inicialState;
        char blank = 'b';
        bool endState;
        Dictionary<string, string> movimientos = new Dictionary<string, string>();

        public Machine(char[] strCinta,char[] alfabeto,string inicial) {

            cinta = strCinta;
            dictionary = alfabeto;
            inicialState = inicial;
            endState = false;
        }

        public void addState(string key, string value)
        {
            movimientos.Add(key, value);
        }

        public string momement(string llave) {
            return movimientos[llave];
        }
    }
}
