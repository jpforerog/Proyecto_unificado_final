using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;

namespace ClienteVideojuego
{
    public partial class FormEliminarArma : Form
    {

        Arma armaActual;

        public FormEliminarArma()
        {
            InitializeComponent();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void btn_listar_Click(object sender, EventArgs e)
        {
            var nombre = textNombre.Text;
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Arma/buscarNombre");

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
                    var arma = JsonSerializer.Deserialize<Arma>(response.Content);
                    mostrarArma(arma);
                    armaActual = arma;
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

        private void mostrarArma(Arma arma)
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
                arma.tipoMunicion.dañoArea);


                
            
        }

        private void btn_Eliminar_Click(object sender, EventArgs e)
        {

            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Arma/");

            request.RequestFormat = DataFormat.Json;
            
            
            request.AddBody(new
            {
                tipo = "Rifle",
                id = armaActual.id
            });


            try
            {
                var response = client.Execute(request, Method.Delete);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Se elimino el arma correctamente", "Éxito");
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

        private void txt_eliminar_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
