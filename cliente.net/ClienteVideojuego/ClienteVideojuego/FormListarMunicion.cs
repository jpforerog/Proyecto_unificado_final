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

    
    public partial class FormListarMunicion : Form
    {
       

        
        

        public FormListarMunicion()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Municion/");
            try
            {
                var response = client.Execute(request, Method.Get);

                if (response.IsSuccessful)
                {
                    var municiones = JsonSerializer.Deserialize<List<Municion>>(response.Content);

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

        private void dataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
