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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ClienteVideojuego
{
    public partial class FormFiltrarArma : Form
    {
        public FormFiltrarArma()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            int vida_minima = (int)numericUpDown2.Value;
            int dano_minimo = (int)numericUpDown1.Value;
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Arma/filtrar");


            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {
                vida_minima,
                dano_minimo
            });


            try
            {
                var response = client.Execute(request, Method.Post);

                if (response.IsSuccessful)
                {
                    var armas = JsonSerializer.Deserialize<List<Arma>>(response.Content);


                    CargarArmasEnTabla(armas);
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

        private void CargarArmasEnTabla(List<Arma> armas)
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("daño", "Daño");
            dataGridView1.Columns.Add("municion", "Municion");
            dataGridView1.Columns.Add("vida", "Vida");
            dataGridView1.Columns.Add("velocidad", "Velocidad");
            dataGridView1.Columns.Add("fechaCreacion", "FechaCreacion");
            dataGridView1.Columns.Add("nombreMunicion", "NombreMunicion");
            dataGridView1.Columns.Add("cadencia", "Cadencia");
            dataGridView1.Columns.Add("danoArea", "DanoArea");


            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;

            foreach (var arma in armas)
            {
                string fechaFormateada = arma.FechaCreacionDate.ToString("dd/MM/yyyy HH:mm:ss");

                dataGridView1.Rows.Add(
                    arma.nombre,
                    arma.daño,
                    arma.municion,
                    arma.vida,
                    arma.velocidad,
                    fechaFormateada,
                    arma.tipoMunicion.nombreMunicion,
                    arma.tipoMunicion.cadencia,
                    arma.tipoMunicion.dañoArea


                );
            }


        }

        private void FormFiltrarArma_Load(object sender, EventArgs e)
        {

        }
    }
}
