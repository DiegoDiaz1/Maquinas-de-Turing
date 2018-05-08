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
        public char blank = '»';
        bool endState;
        string lastState;
        string currentState;
        Dictionary<string, string> movimientos = new Dictionary<string, string>();

        public Machine(char[] strCinta,char[] alfabeto,string inicial,string endST) {

            cinta = strCinta;
            dictionary = alfabeto;
            inicialState = inicial;
            currentState = "q0";
            lastState = endST;
            endState = false;
        }

        public void addState(string key, string value)
        {
            movimientos.Add(key, value);
        }

        public string momement(string llave) {
            try
            {
                return movimientos[llave];
            }
            catch (Exception)
            {
                return null;
                throw;
            }

        }

        public void setCurrent(string newCurrent) {
            currentState = newCurrent;
        }

        public string getCurrent()
        {
            return currentState;
        }

        public bool itsEnd(string cadena) {
            string[] str = cadena.Split(',');
            if (str[0] == lastState)
            {
                endState = true;
                return endState;
            }

            endState = false;
            return endState;
        }
    }
}
