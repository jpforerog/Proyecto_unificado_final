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

namespace ClienteVideojuego
{
    public partial class FormListarArma : Form
    {
        public FormListarArma()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_listar_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Arma/");
            

            try
            {
                var response = client.Execute(request, Method.Get);

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

    }
}
