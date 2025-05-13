using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using RestSharp;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TextBox;

namespace ClienteVideojuego
{
    public partial class FormCrearArma : Form
    {

        private List<Municion> municionesLista;
        public FormCrearArma()

        {
            InitializeComponent();



            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Municion/");
            var response = client.Get(request);

            

            var municiones = JsonSerializer.Deserialize<List<Municion>>(response.Content);

            
        }
        private void button2_Click(object sender, EventArgs e)
        {
            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Municion/");
            var response = client.Get(request);

           

            var municiones = JsonSerializer.Deserialize<List<Municion>>(response.Content);
            municionesLista = municiones;

            CargarMunicionesEnTabla(municiones);
        }

        private void CargarMunicionesEnTabla(List<Municion> municiones)
        {


            dataGridView1.Columns.Clear();
            dataGridView1.Rows.Clear();

            dataGridView1.Columns.Add("nombre", "Nombre");
            dataGridView1.Columns.Add("cadencia", "Cadencia");
            dataGridView1.Columns.Add("danoArea", "Daño en Área");
            dataGridView1.Columns.Add("indice", "Índice");
            dataGridView1.ReadOnly = true;
            dataGridView1.AllowUserToAddRows = false;
            foreach (var Municion in municiones)
            {
                dataGridView1.Rows.Add(Municion.nombreMunicion, Municion.cadencia, Municion.dañoArea, Municion.id);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {


            var nombre = textNombre.Text.Trim();
            int daño = (int)numericUpDown1.Value;
            int vida = (int)numericUpDown2.Value;
            double velocidad = (double)numericUpDown3.Value;
            int municion = (int)numericUpDown4.Value;
            DateTime fechaSeleccionada = monthCalendar1.SelectionStart;

            // Si quieres añadir hora actual:
            DateTime fechaConHora = new DateTime(
                fechaSeleccionada.Year,
                fechaSeleccionada.Month,
                fechaSeleccionada.Day,
                DateTime.Now.Hour,
                DateTime.Now.Minute,
                DateTime.Now.Second
            );
            string fechaFormateada = fechaConHora.ToString("yyyy-MM-ddTHH:mm:ss");


            Municion municion1;
            if (dataGridView1.CurrentRow == null)
            {
                municion1 = new Municion();
            }
            else
            {
                int filaSeleccionada = dataGridView1.CurrentRow.Index;
                string nom = dataGridView1.CurrentRow.Cells[0].Value.ToString();
                municion1 = new Municion();
                foreach(Municion m in municionesLista)
                {
                    if (m.nombreMunicion.Equals(nom))
                    {
                        municion1 = m;
                    }
                }
                
            }
                
            
            



            var options = new RestClientOptions("http://localhost:8080")
            {
                ThrowOnAnyError = false,
            };
            var client = new RestClient(options);
            var request = new RestRequest("/Arma/");

            request.RequestFormat = DataFormat.Json;
            
            request.AddBody(new
            {

                daño = daño,
                municion = municion,
                nombre = nombre,
                vida = vida,
                velocidad = velocidad,
                fechaCreacion = fechaFormateada,
                tipoMunicion = new
                {
                    nombre = municion1.nombreMunicion,
                    danoArea = municion1.dañoArea,
                    cadencia = municion1.cadencia,

                }

            });
            try
            {
                var response = client.Execute(request, Method.Post);

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


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        

        private void numericUpDown4_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FormCrearArma_Load(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void numericUpDown2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void numericUpDown3_ValueChanged(object sender, EventArgs e)
        {

        }

        

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
