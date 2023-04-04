using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Xml;

namespace Compilador
{
    public partial class Form1 : Form
    {
        public string imp { set; get; }
        private AnalisisLexico analisisLexico;
        public Form1()
        {
            InitializeComponent();
        }


        private void AnalizarCodigo(string codigo)
        {
            // Crear instancia de AnalisisLexico y asignar texto
            AnalisisLexico analizadorLexico = new AnalisisLexico();
            analizadorLexico.Texto = codigo;

            // Analizar texto y obtener lista de tokens
            List<Token> tokens = analizadorLexico.AnalizarTexto();

            // Crear instancia de AnalisisSintactico y analizar los tokens
            AnalisisSintactico analizadorSintactico = new AnalisisSintactico(analizadorLexico);
            analizadorSintactico.Analizar();
        }


        private void button1_Click(object sender, EventArgs e)
        {
            // Abrir OpenFileDialog
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Archivos de texto (*.txt)|*.txt";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                // Leer archivo
                string contenido = File.ReadAllText(openFileDialog.FileName);
                lstFuente.Items.Add(contenido);

                // Crear instancia de AnalisisLexico y asignar texto
                AnalisisLexico analizadorLexico = new AnalisisLexico();
                analizadorLexico.Texto = contenido;

                // Analizar texto y mostrar tokens en ListBox
                List<Token> tokens = analizadorLexico.AnalizarTexto();
                lstTokens.Items.Clear();
                foreach (Token token in tokens)
                {
                    lstTokens.Items.Add(string.Format("{0} - {1}", token.Tipo, token.Valor));
                }

                // Realizar análisis sintáctico
                AnalisisSintactico analizadorSintactico = new AnalisisSintactico(analizadorLexico);
                try
                {
                    analizadorSintactico.Analizar();
                    lstSintac.Items.Add("La sintaxis del código es correcta.");
                }
                catch (Exception ex)
                {
                    lstSintac.Items.Add("Error: " + ex.Message);
                }
            }
        }


        // no tocar
    }
}

