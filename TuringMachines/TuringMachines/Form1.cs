using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

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

            //Alfabeto y simbolos posibles de la cinta de las maquinas de Turing
            string cinta = "10BXYZS*=+-abc";
            string alphabet = "10*=+-aBc";

            //Inicializacion de las Maquinas de Turing
            multiplicacion = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","q7");
            sumatoria = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","q3");
            resta = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","q13");
            palindromo = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","q10");
            copiaSTR = new Machine(cinta.ToCharArray(), alphabet.ToCharArray(), "q0","q8");

            //////////////////////////////////////////////////
            ////// SE DECLARAN LOS ESTADOS DE LA MAQUINA /////
            //////               DE LA                   /////
            //////            MULTIPLICACION             /////
            //////////////////////////////////////////////////

            multiplicacion.addState("q0,*", "q6,»,1");
            multiplicacion.addState("q0,1", "q1,»,1");
            multiplicacion.addState("q1,*", "q2,*,1");
            multiplicacion.addState("q1,1", "q1,1,1");
            multiplicacion.addState("q2,*", "q5,*,-1");
            multiplicacion.addState("q2,=", "q5,=,-1");
            multiplicacion.addState("q2,1", "q3,Y,1");
            multiplicacion.addState("q3,=", "q3,=,1");
            multiplicacion.addState("q3,1", "q3,1,1");
            multiplicacion.addState("q3,»", "q4,1,-1");
            multiplicacion.addState("q4,=", "q4,=,-1");
            multiplicacion.addState("q4,*", "q4,*,-1");
            multiplicacion.addState("q4,1", "q4,1,-1");
            multiplicacion.addState("q4,Y", "q2,Y,1");
            multiplicacion.addState("q5,Y", "q5,1,-1");
            multiplicacion.addState("q5,*","q5,*,-1");
            multiplicacion.addState("q5,1", "q5,1,-1");
            multiplicacion.addState("q5,»", "q0,»,1");
            multiplicacion.addState("q6,=", "q7,=,1");
            multiplicacion.addState("q6,1", "q6,»,1");



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
            sumatoria.addState("q1,»", "q2,1,-1");
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
            resta.addState("q1,»", "q2,1,-1");
            resta.addState("q2,-", "q2,-,-1");
            resta.addState("q2,=", "q2,=,-1");
            resta.addState("q2,1", "q2,1,-1");
            resta.addState("q2,X", "q0,X,1");
            resta.addState("q3,=", "q13,=,1");
            resta.addState("q3,1", "q4,Y,1");
            resta.addState("q4,1", "q4,1,1");
            resta.addState("q4,=", "q4,=,1");
            resta.addState("q4,»", "q5,»,-1");
            resta.addState("q5,=", "q7,=,1");
            resta.addState("q5,1", "q6,»,-1");
            resta.addState("q6,1", "q6,1,-1");
            resta.addState("q6,=", "q6,=,-1");
            resta.addState("q6,Y", "q3,Y,1");
            resta.addState("q7,»", "q8,-,1");
            resta.addState("q8,»", "q9,1,-1");
            resta.addState("q9,1", "q9,1,-1");
            resta.addState("q9,=", "q9,=,-1");
            resta.addState("q9,-", "q9,-,-1");
            resta.addState("q9,Y", "q10,Y,1");
            resta.addState("q10,=", "q13,=,1");
            resta.addState("q10,1", "q11,Y,1");
            resta.addState("q11,-", "q11,-,1");
            resta.addState("q11,=", "q11,=,1");
            resta.addState("q11,1", "q11,1,1");
            resta.addState("q11,»", "q12,1,-1");
            resta.addState("q12,-", "q12,-,-1");
            resta.addState("q12,=", "q12,=,-1");
            resta.addState("q12,1", "q12,1,-1");
            resta.addState("q12,Y", "q10,Y,1");


            //////////////////////////////////////////////////
            ////// SE DECLARAN LOS ESTADOS DE LA MAQUINA /////
            //////                DEL                    /////
            //////           PALINDROMO                  /////
            //////////////////////////////////////////////////

            palindromo.addState("q0,a", "q1,»,1");
            palindromo.addState("q0,b", "q4,»,1");
            palindromo.addState("q0,c", "q7,»,1");
            palindromo.addState("q1,a", "q1,a,1");
            palindromo.addState("q1,b", "q1,b,1");
            palindromo.addState("q1,c", "q1,c,1");
            palindromo.addState("q1,»", "q2,»,-1");
            palindromo.addState("q2,a", "q3,»,-1");
            palindromo.addState("q2,»", "q10,»,1");
            palindromo.addState("q3,a", "q3,a,-1");
            palindromo.addState("q3,b", "q3,b,-1");
            palindromo.addState("q3,c", "q3,c,-1");
            palindromo.addState("q3,»", "q0,»,1");
            palindromo.addState("q4,a", "q4,a,1");
            palindromo.addState("q4,b", "q4,b,1");
            palindromo.addState("q4,c", "q4,c,1");
            palindromo.addState("q4,»", "q5,»,-1");
            palindromo.addState("q5,»", "q10,»,1");
            palindromo.addState("q5,b", "q6,»,-1");
            palindromo.addState("q6,a", "q6,a,-1");
            palindromo.addState("q6,b", "q6,b,-1");
            palindromo.addState("q6,c", "q6,c,-1");
            palindromo.addState("q6,»", "q0,»,1");
            palindromo.addState("q7,a", "q7,a,1");
            palindromo.addState("q7,b", "q7,b,1");
            palindromo.addState("q7,c", "q7,c,1");
            palindromo.addState("q7,»", "q8,»,-1");
            palindromo.addState("q8,c", "q9,»,-1");
            palindromo.addState("q8,»", "q10,»,1");
            palindromo.addState("q9,a", "q9,a,-1");
            palindromo.addState("q9,b", "q9,b,-1");
            palindromo.addState("q9,c", "q9,c,-1");
            palindromo.addState("q9,»", "q0,»,1");



            //////////////////////////////////////////////////
            ////// SE DECLARAN LOS ESTADOS DE LA MAQUINA /////
            //////                DEL                    /////
            //////       COPIADOR DE TEXTO              //////
            //////////////////////////////////////////////////

            copiaSTR.addState("q0,a","q1,A,1");
            copiaSTR.addState("q0,b","q3,B,1");
            copiaSTR.addState("q0,c","q5,C,1");
            copiaSTR.addState("q0,X", "q7,a,1");
            copiaSTR.addState("q0,Y", "q7,b,1");
            copiaSTR.addState("q0,Z", "q7,c,1");
            //grupo de estados movimiento derecha para A
            copiaSTR.addState("q1,Z", "q1,Z,1");
            copiaSTR.addState("q1,Y", "q1,Y,1");
            copiaSTR.addState("q1,X", "q1,X,1");
            copiaSTR.addState("q1,c", "q1,c,1");
            copiaSTR.addState("q1,b", "q1,b,1");
            copiaSTR.addState("q1,a", "q1,a,1");
            copiaSTR.addState("q1,»", "q2,X,-1");
            //Grupo de estados moviemento izquierda para A
            copiaSTR.addState("q2,Z", "q2,Z,-1");
            copiaSTR.addState("q2,Y", "q2,Y,-1");
            copiaSTR.addState("q2,X", "q2,X,-1");
            copiaSTR.addState("q2,a", "q2,a,-1");
            copiaSTR.addState("q2,b", "q2,b,-1");
            copiaSTR.addState("q2,c", "q2,c,-1");
            copiaSTR.addState("q2,A", "q0,a,1");
            //grupo de estados movimiento derecha para B
            copiaSTR.addState("q3,Z", "q3,Z,1");
            copiaSTR.addState("q3,Y", "q3,Y,1");
            copiaSTR.addState("q3,X", "q3,X,1");
            copiaSTR.addState("q3,c", "q3,c,1");
            copiaSTR.addState("q3,b", "q3,b,1");
            copiaSTR.addState("q3,a", "q3,a,1");
            copiaSTR.addState("q3,»", "q4,Y,-1");
            //Grupo de estados moviemento izquierda para B
            copiaSTR.addState("q4,Z", "q4,Z,-1");
            copiaSTR.addState("q4,Y", "q4,Y,-1");
            copiaSTR.addState("q4,X", "q4,X,-1");
            copiaSTR.addState("q4,a", "q4,a,-1");
            copiaSTR.addState("q4,b", "q4,b,-1");
            copiaSTR.addState("q4,c", "q4,c,-1");
            copiaSTR.addState("q4,B", "q0,b,1");
            //grupo de estados movimiento derecha para C
            copiaSTR.addState("q5,Z", "q5,Z,1");
            copiaSTR.addState("q5,Y", "q5,Y,1");
            copiaSTR.addState("q5,X", "q5,X,1");
            copiaSTR.addState("q5,c", "q5,c,1");
            copiaSTR.addState("q5,b", "q5,b,1");
            copiaSTR.addState("q5,a", "q5,a,1");
            copiaSTR.addState("q5,»", "q6,Z,-1");
            //Grupo de estados moviemento izquierda para C
            copiaSTR.addState("q6,Z", "q6,Z,-1");
            copiaSTR.addState("q6,Y", "q6,Y,-1");
            copiaSTR.addState("q6,X", "q6,X,-1");
            copiaSTR.addState("q6,a", "q6,a,-1");
            copiaSTR.addState("q6,b", "q6,b,-1");
            copiaSTR.addState("q6,c", "q6,c,-1");
            copiaSTR.addState("q6,C", "q0,c,1");
            //Movimientos en estado anterior al final
            copiaSTR.addState("q7,X", "q7,a,1");
            copiaSTR.addState("q7,Y", "q7,b,1");
            copiaSTR.addState("q7,Z", "q7,c,1");
            copiaSTR.addState("q7,»", "q8,»,1");
        }

        public Form1()
        {
            InitializeComponent();
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.Rows.Add();
            dataGridView1.MultiSelect = false;
            dataGridView1.AllowDrop = false;
            dataGridView1.AllowUserToDeleteRows = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.AllowUserToResizeRows = false;
            dataGridView1.ColumnHeadersVisible = false;
            dataGridView1.RowHeadersVisible = false;
            dataGridView1.AllowUserToResizeColumns = false;
            dataGridView1.AllowUserToOrderColumns = false;
            dataGridView1.BackgroundColor = Color.White;
            createMachines();
            label6.Text = multiplicacion.blank.ToString();

        }
        //Solo Llena el DataGridView
        private void button1_Click(object sender, EventArgs e)
        {
            cadena = textBox1.Text;
            subStrings = cadena.ToCharArray();

            label2.Text = "___";
            label4.Text = "___";
            if (radioButton3.Checked)
            {
                for (int i = 0; i <= cadena.Length + 1; i++)
                {
                    if ((i == cadena.Length) || (i == cadena.Length + 1))
                    {
                        int cons = cadena.Length;
                        while (cons <= cadena.Length * 7)
                        {
                            this.dataGridView1.Columns.Add("blank" + cons, "»");
                            this.dataGridView1.Rows[0].Cells[i + cons].Value = "»";
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
                            this.dataGridView1.Columns.Add("blank" + cons, "»");
                            this.dataGridView1.Rows[0].Cells[cons].Value = "»";
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

              /////////////////////////////////
             ////Instrucciones Sumatoria//////
            /////////////////////////////////

            if (radioButton1.Checked)
            {
                while (!flag)
                {
                    if (sumatoria.momement(sumatoria.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value) != null)
                    {
                        temp = sumatoria.momement(sumatoria.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value).Split(',');
                        sumatoria.setCurrent(temp[0]);
                        //Agregar Color a la Cabezilla de la maquina
                        //Thread.Sleep(250);
                        dataGridView1.CurrentCell = dataGridView1.Rows[0].Cells[i];
                        dataGridView1.Rows[0].Cells[i].Style.BackColor = Color.AliceBlue;
                        //Se Manejan los indicadores visuales de pasos y Estado actual.
                        cont++;
                        label4.Text = cont.ToString();
                        estado = sumatoria.getCurrent();
                        label2.Text = estado;
                        
                        //Se Cambia el dato en dataGridView
                        this.dataGridView1.Rows[0].Cells[i].Value = temp[1];
                        Thread.Sleep(250);
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

              ////////////////////////////////
             /////Instrucciones Resta////////
            ////////////////////////////////

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

             ////////////////////////////////////
            /////Instrucciones Multiplicacion///
           ////////////////////////////////////

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

              /////////////////////////////////
             /////Instrucciones Palindromo////
            /////////////////////////////////

            if (radioButton4.Checked)
            {
                while (!flag)
                {
                    if (palindromo.momement(palindromo.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value) != null)
                    {
                        temp = palindromo.momement(palindromo.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value).Split(',');
                        palindromo.setCurrent(temp[0]);
                        //Agregar Color a la Cabezilla de la maquina

                        //Se Manejan los indicadores visuales de pasos y Estado actual.
                        cont++;
                        label4.Text = cont.ToString();
                        estado = palindromo.getCurrent();
                        label2.Text = estado;

                        //Se Cambia el dato en dataGridView
                        this.dataGridView1.Rows[0].Cells[i].Value = temp[1];

                        if (temp[2] == "1")
                            i++;
                        else
                            i--;
                        if (palindromo.itsEnd(palindromo.getCurrent()))
                        {
                            flag = true;
                            i = 0;
                            MessageBox.Show("Es Palindromo");
                        }
                    }
                    else
                    {
                        MessageBox.Show("No Es palindromo");
                        flag = true;
                    }
                }
            }

              //////////////////////////////////////
             /////Instrucciones Copia De Texto/////
            //////////////////////////////////////

            if (radioButton5.Checked)
            {
                while (!flag)
                {
                    if (copiaSTR.momement(copiaSTR.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value) != null)
                    {
                        temp = copiaSTR.momement(copiaSTR.getCurrent() + "," + this.dataGridView1.Rows[0].Cells[i].Value).Split(',');
                        copiaSTR.setCurrent(temp[0]);
                        //Agregar Color a la Cabezilla de la maquina

                        //Se Manejan los indicadores visuales de pasos y Estado actual.
                        cont++;
                        label4.Text = cont.ToString();
                        estado = copiaSTR.getCurrent();
                        label2.Text = estado;

                        //Se Cambia el dato en dataGridView
                        this.dataGridView1.Rows[0].Cells[i].Value = temp[1];

                        if (temp[2] == "1")
                            i++;
                        else
                            i--;
                        if (copiaSTR.itsEnd(copiaSTR.getCurrent()))
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
        }


        //Boton para resetear el grid
        private void button3_Click(object sender, EventArgs e)
        {
            for (int i = dataGridView1.Columns.Count-1; i > 0; i--)
            {
                if (dataGridView1.Rows[0].Cells[i].Value != null)
                {
                    dataGridView1.Columns.RemoveAt(i);
                }
            }
            dataGridView1.Rows[0].Cells[0].Value = "";
            flag = false;
        }
    }
}
