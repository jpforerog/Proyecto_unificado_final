using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json.Nodes;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace ClienteVideojuego
{
    public partial class FormBuscarMunicion : Form
    {
        private Municion municionActual;
        public FormBuscarMunicion()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var nombre = textBox1.Text.Trim();
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
                    int indexValue = jsonNode["index"] != null ? (int)jsonNode["index"] : 0;


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
            dataGridView1.Visible = true;
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("cadencia", "Cadencia");
            dataGridView1.Columns.Add("danoArea", "Daño en Área");
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Add(municion.nombreMunicion, municion.cadencia, municion.dañoArea);
        }
    }
}
