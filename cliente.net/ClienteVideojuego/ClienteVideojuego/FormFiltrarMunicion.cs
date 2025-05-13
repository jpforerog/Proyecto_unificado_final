using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ClienteVideojuego
{
    public partial class FormFiltrarMunicion : Form
    {
        private bool dArea = false;
        public FormFiltrarMunicion()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int cadencia = (int)numericUpDown1.Value;
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Municion/filtrarMunicion");
            

            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {
                cadencia_minima = cadencia,
                danoArea = dArea
            });

            try
            {
                var response = client.Execute(request, Method.Post);

                if (response.IsSuccessful)
                {
                    JsonNode jsonNode = JsonNode.Parse(response.Content);

                    var municiones = JsonSerializer.Deserialize<List<Municion>>(response.Content);

                    if (jsonNode is JsonArray jsonArray)
                    {
                        for (int i = 0; i < jsonArray.Count && i < municiones.Count; i++)
                        {
                            var municionNode = jsonArray[i];

                            // Obtener los valores específicos para cada munición
                            string danoAreaValue = municionNode["dañoArea"]?.ToString();
                            int indexValue = municionNode["index"] != null ? (int)municionNode["index"] : 0;

                            // Asignar los valores correctos a cada objeto Municion
                            municiones[i].dañoArea = danoAreaValue?.ToLower() == "true";
                            municiones[i].id = indexValue;

                        }
                    }

                    CargarMunicionesEnTabla(municiones);
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
        private void CargarMunicionesEnTabla(List<Municion> municiones)
        {


            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("cadencia", "Cadencia");
            dataGridView1.Columns.Add("danoArea", "Daño en Área");

            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            foreach (var Municion in municiones)
            {
                dataGridView1.Rows.Add(Municion.nombreMunicion, Municion.cadencia, Municion.dañoArea);
            }
        }
        

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
    }
}
