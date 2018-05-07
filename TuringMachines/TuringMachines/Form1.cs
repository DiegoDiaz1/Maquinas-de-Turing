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
        int cont = 0;
        string estado = "";
        bool flag = false;
        Machine multiplicacion;
        Machine sumatoria;
        Machine resta;
        Machine palindromo;
        Machine copiaSTR;

        public void createMachines(){

            //Alfabeto y simbolos posibles de la cinta de las mquinas de Turing
            string cinta = "10BXY*=+-abc";
            string alphabet = "10*=+-abc";

            //Inicializacion de las Maquinas de Turing
            multiplicacion = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","q7");
            sumatoria = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","q3");
            resta = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","q13");
            palindromo = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","q10");
            copiaSTR = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","");

            //////////////////////////////////////////////////
            ////// SE DECLARAN LOS ESTADOS DE LA MAQUINA /////
            //////               DE LA                   /////
            //////            MULTIPLICACION             /////
            //////////////////////////////////////////////////

            multiplicacion.addState("q0,*", "q6,b,1");
            multiplicacion.addState("q0,1", "q1,b,1");
            multiplicacion.addState("q1,*", "q2,*,1");
            multiplicacion.addState("q1,1", "q1,1,1");
            multiplicacion.addState("q2,*", "q5,*,-1");
            multiplicacion.addState("q2,=", "q5,=,-1");
            multiplicacion.addState("q2,1", "q3,Y,1");
            multiplicacion.addState("q3,=", "q3,=,1");
            multiplicacion.addState("q3,1", "q3,1,1");
            multiplicacion.addState("q3,b", "q4,1,-1");
            multiplicacion.addState("q4,=", "q4,=,-1");
            multiplicacion.addState("q4,*", "q4,*,-1");
            multiplicacion.addState("q4,1", "q4,1,-1");
            multiplicacion.addState("q4,Y", "q2,Y,1");
            multiplicacion.addState("q5,Y", "q5,1,-1");
            multiplicacion.addState("q5,*","q5,*,-1");
            multiplicacion.addState("q5,1", "q5,1,-1");
            multiplicacion.addState("q5,b", "q0,b,1");
            multiplicacion.addState("q6,=", "q7,=,1");
            multiplicacion.addState("q6,1", "q6,b,1");



            //////////////////////////////////////////////////
            ////// SE DECLARAN LOS ESTADOS DE LA MAQUINA /////
            //////               DE LA                   /////
            //////                SUMA                   /////
            //////////////////////////////////////////////////

            sumatoria.addState("q0,+", "q0,X,1");
            sumatoria.addState("q0,=", "q3,=,1");
            sumatoria.addState("q0,1", "q1,X,1");
            sumatoria.addState("q1,=", "q1,=,1");
            sumatoria.addState("q1,+", "q1,+,1");
            sumatoria.addState("q1,1", "q1,1,1");
            sumatoria.addState("q1,b", "q2,1,-1");
            sumatoria.addState("q2,=", "q2,=,-1");
            sumatoria.addState("q2,+", "q2,+,-1");
            sumatoria.addState("q2,1", "q2,1,-1");
            sumatoria.addState("q2,X", "q0,X,1");



            //////////////////////////////////////////////////
            ////// SE DECLARAN LOS ESTADOS DE LA MAQUINA /////
            //////               DE LA                   /////
            //////               RESTA                   /////
            //////////////////////////////////////////////////

            resta.addState("q0,-", "q3,-,1");
            resta.addState("q0,1", "q1,X,1");
            resta.addState("q1,1", "q1,1,1");
            resta.addState("q1,=", "q1,=,1");
            resta.addState("q1,-", "q1,-,1");
            resta.addState("q1,b", "q2,1,-1");
            resta.addState("q2,-", "q2,-,-1");
            resta.addState("q2,=", "q2,=,-1");
            resta.addState("q2,1", "q2,1,-1");
            resta.addState("q2,X", "q0,X,1");
            resta.addState("q3,=", "q13,=,1");
            resta.addState("q3,1", "q4,Y,1");
            resta.addState("q4,1", "q4,1,1");
            resta.addState("q4,=", "q4,=,1");
            resta.addState("q4,b", "q5,b,-1");
            resta.addState("q5,=", "q7,=,1");
            resta.addState("q5,1", "q6,b,-1");
            resta.addState("q6,1", "q6,1,-1");
            resta.addState("q6,=", "q6,=,-1");
            resta.addState("q6,Y", "q3,Y,1");
            resta.addState("q7,b", "q8,-,1");
            resta.addState("q8,b", "q9,1,-1");
            resta.addState("q9,1", "q9,1,-1");
            resta.addState("q9,=", "q9,=,-1");
            resta.addState("q9,-", "q9,-,-1");
            resta.addState("q9,Y", "q10,Y,1");
            resta.addState("q10,=", "q13,=,1");
            resta.addState("q10,1", "q11,Y,1");
            resta.addState("q11,-", "q11,-,1");
            resta.addState("q11,=", "q11,=,1");
            resta.addState("q11,1", "q11,1,1");
            resta.addState("q11,b", "q12,1,-1");
            resta.addState("q12,-", "q12,-,-1");
            resta.addState("q12,=", "q12,=,-1");
            resta.addState("q12,1", "q12,1,-1");
            resta.addState("q12,Y", "q10,Y,1");


            //////////////////////////////////////////////////
            ////// SE DECLARAN LOS ESTADOS DE LA MAQUINA /////
            //////                DEL                    /////
            //////           PALINDROMO                  /////
            //////////////////////////////////////////////////

            palindromo.addState("q0,a", "q1,b,1");
            palindromo.addState("q0,B", "q4,b,1");
            palindromo.addState("q0,c", "q7,b,1");
            palindromo.addState("q1,a", "q1,a,1");
            palindromo.addState("q1,B", "q1,B,1");
            palindromo.addState("q1,c", "q1,c,1");
            palindromo.addState("q1,b", "q2,b,-1");
            palindromo.addState("q2,a", "q3,b,-1");
            palindromo.addState("q2,b", "q10,b,1");
            palindromo.addState("q3,a", "q3,a,-1");
            palindromo.addState("q3,B", "q3,B,-1");
            palindromo.addState("q3,c", "q3,c,-1");
            palindromo.addState("q3,b", "q0,b,1");
            palindromo.addState("q4,a", "q4,a,1");
            palindromo.addState("q4,B", "q4,B,1");
            palindromo.addState("q4,c", "q4,c,1");
            palindromo.addState("q4,b", "q5,b,-1");
            palindromo.addState("q5,b", "q10,b,1");
            palindromo.addState("q5,B", "q6,b,-1");
            palindromo.addState("q6,a", "q6,a,-1");
            palindromo.addState("q6,B", "q6,B,-1");
            palindromo.addState("q6,c", "q6,c,-1");
            palindromo.addState("q6,b", "q0,b,1");
            palindromo.addState("q7,a", "q7,a,1");
            palindromo.addState("q7,B", "q7,B,1");
            palindromo.addState("q7,c", "q7,c,1");
            palindromo.addState("q7,b", "q8,b,-1");
            palindromo.addState("q8,c", "q9,b,-1");
            palindromo.addState("q8,b", "q10,b,1");
            palindromo.addState("q9,a", "q9,a,-1");
            palindromo.addState("q9,B", "q9,B,-1");
            palindromo.addState("q9,C", "q9,c,-1");
            palindromo.addState("q9,b", "q0,b,1");



            //FALATA COPIA DE TEXTO

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
        //Solo Llena el Data Grid View
        private void button1_Click(object sender, EventArgs e)
        {
            cadena = textBox1.Text;
            subStrings = cadena.ToCharArray();

            label2.Text = "__";
            label4.Text = "__";
            if (radioButton3.Checked)
            {
                for (int i = 0; i <= cadena.Length + 1; i++)
                {
                    if ((i == cadena.Length) || (i == cadena.Length + 1))
                    {
                        int cons = cadena.Length;
                        while (cons <= cadena.Length * 7)
                        {
                            this.dataGridView1.Columns.Add("blank" + cons, "b");
                            this.dataGridView1.Rows[0].Cells[cons].Value = "b";
                            cons++;
                        }
                    }
                    else
                    {
                        this.dataGridView1.Columns.Add("string" + i, subStrings[i].ToString());
                        this.dataGridView1.Rows[0].Cells[i].Value = subStrings[i].ToString();
                    }
                }
            }
            if((radioButton1.Checked)||(radioButton2.Checked)||(radioButton4.Checked)||(radioButton5.Checked))
            {
                for (int i = 0; i <= cadena.Length + 1; i++)
                {
                    if ((i == cadena.Length) || (i == cadena.Length + 1))
                    {
                        int cons = cadena.Length;
                        while (cons <= cadena.Length * 2)
                        {
                            this.dataGridView1.Columns.Add("blank" + cons, "b");
                            this.dataGridView1.Rows[0].Cells[cons].Value = "b";
                            cons++;
                        }
                    }
                    else
                    {
                        this.dataGridView1.Columns.Add("string" + i, subStrings[i].ToString());
                        this.dataGridView1.Rows[0].Cells[i].Value = subStrings[i].ToString();
                    }
                }
            }
            else
            {
                MessageBox.Show("Seleccione una maquina de turing");
            }
        }
            

        private void button2_Click(object sender, EventArgs e)
        {
            string[] temp;
            int i = 0;

            flag = false;
            //Agregar demas Mauinas
            if (radioButton1.Checked)
            {
                while (!flag)
                {
                    if (sumatoria.momement(sumatoria.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value) != null)
                    {
                        temp = sumatoria.momement(sumatoria.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value).Split(',');
                        sumatoria.setCurrent(temp[0]);
                        //Agregar Color a la Cabezilla de la maquina

                        //Se Manejan los indicadores visuales de pasos y Estado actual.
                        cont++;
                        label4.Text = cont.ToString();
                        estado = sumatoria.getCurrent();
                        label2.Text = estado;

                        //Se Cambia el dato en dataGridView
                        this.dataGridView1.Rows[0].Cells[i].Value = temp[1];

                        if (temp[2] == "1")
                            i++;
                        else
                            i--;
                        if (sumatoria.itsEnd(sumatoria.getCurrent()))
                        {
                            flag = true;
                            i = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Estado no definido revise el formato de entrada.");
                        flag = true;
                    }
                }
            }
            if (radioButton2.Checked)
            {
                while (!flag)
                {
                    if (resta.momement(resta.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value) != null)
                    {
                        temp = resta.momement(resta.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value).Split(',');
                        resta.setCurrent(temp[0]);
                        //Agregar Color a la Cabezilla de la maquina

                        //Se Manejan los indicadores visuales de pasos y Estado actual.
                        cont++;
                        label4.Text = cont.ToString();
                        estado = resta.getCurrent();
                        label2.Text = estado;

                        //Se Cambia el dato en dataGridView
                        this.dataGridView1.Rows[0].Cells[i].Value = temp[1];

                        if (temp[2] == "1")
                            i++;
                        else
                            i--;
                        if (resta.itsEnd(resta.getCurrent()))
                        {
                            flag = true;
                            i = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Estado no definido revise el formato de entrada.");
                        flag = true;
                    }
                }
            }
            if (radioButton3.Checked)
            {
                while (!flag)
                {
                    if (multiplicacion.momement(multiplicacion.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value) != null)
                    {
                        temp = multiplicacion.momement(multiplicacion.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value).Split(',');
                        multiplicacion.setCurrent(temp[0]);
                        //Agregar Color a la Cabezilla de la maquina

                        //Se Manejan los indicadores visuales de pasos y Estado actual.
                        cont++;
                        label4.Text = cont.ToString();
                        estado = multiplicacion.getCurrent();
                        label2.Text = estado;

                        //Se Cambia el dato en dataGridView
                        this.dataGridView1.Rows[0].Cells[i].Value = temp[1];

                        if (temp[2] == "1")
                            i++;
                        else
                            i--;
                        if (multiplicacion.itsEnd(multiplicacion.getCurrent()))
                        {
                            flag = true;
                            i = 0;
                        }
                    }
                    else
                    {
                        MessageBox.Show("ERROR: Estado no definido revise el formato de entrada.");
                        flag = true;
                    }
                }
            }
            if (radioButton4.Checked)
            {

            }
            if (radioButton5.Checked)
            {

            }
        }
    }
}
