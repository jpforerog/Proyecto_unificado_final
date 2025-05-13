using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using System.Text.Json;
using System.Text.Json.Nodes;

namespace ClienteVideojuego
{
    public partial class FormCambiarMunicion : Form
    {
        private Municion municionActual;

        
        public FormCambiarMunicion()
        {

            
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nombre = textNombre.Text;
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Municion/buscarNombre/");

            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {

                nombre = nombre
            });


            try
            {
                var response = client.Execute(request, Method.Post);

                if (response.IsSuccessful)
                {
                    JsonNode jsonNode = JsonNode.Parse(response.Content);
                    string danoAreaValue = jsonNode["danoArea"]?.ToString();
                    int indexValue = jsonNode["id"] != null ? (int)jsonNode["id"] : 0;



                    var municion = JsonSerializer.Deserialize<Municion>(response.Content);
                    municion.dañoArea = danoAreaValue?.ToLower() == "true";
                    municion.id = indexValue;

                    mostrarMunicion(municion);
                    municionActual = municion;
                    
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

        private void mostrarMunicion(Municion municion)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            txt_Nombre.Text = municion.nombreMunicion;
            numeric_cadencia.Value = municion.cadencia;
            
            comboBox1.Text = municion.dañoArea.ToString();

            
            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("cadencia", "Cadencia");
            dataGridView1.Columns.Add("danoArea", "Daño en Área");
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Add(municion.nombreMunicion, municion.cadencia, municion.dañoArea);

        }

        

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_cambiar_Click(object sender, EventArgs e)
        {

            if (municionActual == null)
            {
                MessageBox.Show("Primero debes buscar una munición.");
                return;
            }

            // Actualizar solo si los campos no están vacíos
            if (!string.IsNullOrWhiteSpace(txt_Nombre.Text))
                municionActual.nombreMunicion = txt_Nombre.Text;

            if (numeric_cadencia.Value > 0)
            {
                municionActual.cadencia = (int)numeric_cadencia.Value;
            }

            if (comboBox1.SelectedItem != null)
            {
                municionActual.dañoArea = bool.Parse(comboBox1.SelectedItem.ToString().ToLower());
            }
            else
            {
                MessageBox.Show("Selecciona una opción en Daño en Área.");
                return;
            }



            // Enviamos la actualización al backend
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Municion/");
            
            string json = JsonSerializer.Serialize(municionActual);
            
            request.AddJsonBody(municionActual);

            try
            {
                var response = client.Execute(request, Method.Put);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Se creó el arma correctamente", "Éxito");
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


        private void txt_Nombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Cadencia_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_DanoArea_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
