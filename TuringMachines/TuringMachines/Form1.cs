using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TuringMachines
{
    public partial class Form1 : Form
    {


        string cadena;
        char[] subStrings;

        public void createMachines(){
            //Alfabeto y simbolos posibles de la cinta de las mquinas de Turing
            string cinta = "10BXY*=+-abc";
            string alphabet = "10*=+-abc";



            Machine multiplicacion = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0");

            //////////////////////////////////////////////////
            ////// SE DECLARAN LOS ESTADOS DE LA MAQUINA /////
            //////               DE LA                   /////
            //////            MULTIPLICACION             /////
            //////////////////////////////////////////////////

            multiplicacion.addState("q0,0", "q6,B,1");
            multiplicacion.addState("q0,1", "q1,B,1");
            multiplicacion.addState("q1,*", "q2,*,1");
            multiplicacion.addState("q2,0", "q5,0,-1");
            multiplicacion.addState("q2,1", "q3,Y,1");
            multiplicacion.addState("q3,=", "q3,=,1");
            multiplicacion.addState("q3,1", "q3,1,1");
            multiplicacion.addState("q3,B", "q4,1,-1");
            multiplicacion.addState("q4,=", "q4,=,-1");
            multiplicacion.addState("q4,*", "q4,*,-1");
            multiplicacion.addState("q4,1", "q4,1,-1");
            multiplicacion.addState("q4,Y", "q2,Y,1");
            multiplicacion.addState("q5,Y", "q5,Y,-1");
            multiplicacion.addState("q5,B", "q0,B,1");
            multiplicacion.addState("q6,0", "q7,b,1");
            multiplicacion.addState("q6,1", "q6,b,1");
        }

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Add();
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            createMachines();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            cadena = textBox1.Text;
            subStrings = cadena.ToCharArray();

            for (int i = 0; i <= cadena.Length + 1; i++)
            {
                if ((i == cadena.Length) || (i == cadena.Length + 1))
                {
                    this.dataGridView1.Columns.Add("blank" + i, "b");
                    this.dataGridView1.Rows[0].Cells[i].Value = "b";
                }
                else
                {
                    this.dataGridView1.Columns.Add("string" + i, subStrings[i].ToString());
                    this.dataGridView1.Rows[0].Cells[i].Value = subStrings[i].ToString();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {

        }
    }
}
