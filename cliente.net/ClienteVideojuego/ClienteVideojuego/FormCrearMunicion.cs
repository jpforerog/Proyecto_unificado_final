using RestSharp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteVideojuego
{
   


    public partial class FormCrearMunicion : Form
    {
        private bool dArea = false; // Correctly declared as a field inside the class

        public FormCrearMunicion()
        {
            InitializeComponent();
        }

        private void FormCrearMunicion_Load(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void btn_Enviar_Click(object sender, EventArgs e)
        {
            var nombre = textNombre.Text.Trim();
            var dArea = comboBox1.Text.Trim();
            int cadencia = (int)numericUpDown1.Value;  // ✅
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Municion/");

            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {
                nombre = nombre,
                cadencia = cadencia,
                danoArea = dArea
            });

            try
            {
                var response = client.Execute(request, Method.Post);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Se creó la municion correctamente", "Éxito");
                }
                else
                {
                    // El mensaje de error está directamente en response.Content como string
                    MessageBox.Show($"Error ({(int)response.StatusCode}): {response.Content}", "Error");
                }
            }
            catch (Exception ex)
            {
                // Este bloque solo capturará errores de conexión o problemas similares
                MessageBox.Show($"Error de conexión: {ex.Message}", "Error");
            }


            
        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBox1.Text == "true")
            {
                dArea = true; // Removed redundant 'var' declaration
            }
            else
            {
                dArea = false; // Removed redundant 'var' declaration
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
