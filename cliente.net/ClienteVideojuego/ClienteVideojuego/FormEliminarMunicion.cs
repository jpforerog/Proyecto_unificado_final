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
    public partial class FormEliminarMunicion : Form
    {

        private Municion municionActual;

        public FormEliminarMunicion()
        {
            InitializeComponent();
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

            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("cadencia", "Cadencia");
            dataGridView1.Columns.Add("danoArea", "Daño en Área");
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Rows.Add(municion.nombreMunicion, municion.cadencia, municion.dañoArea);
        }


        private void CargarMunicionesEnTabla(List<Municion> municiones)
        {


            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("cadencia", "Cadencia");
            dataGridView1.Columns.Add("danoArea", "Daño en Área");
            dataGridView1.Columns.Add("Index", "Índice");
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            foreach (var Municion in municiones)
            {
                dataGridView1.Rows.Add(Municion.nombreMunicion, Municion.cadencia, Municion.dañoArea, Municion.id);
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void FormEliminarMunicion_Load(object sender, EventArgs e)
        {

        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {

            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Municion/");

            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {

                id = municionActual.id
            });


            try
            {
                var response = client.Execute(request, Method.Delete);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Se elimino la municion correctamente", "Éxito");
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

    }
}
