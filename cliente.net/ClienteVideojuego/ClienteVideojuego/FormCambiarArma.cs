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
 
    public partial class FormCambiarArma : Form
    {
        private List<Municion> municionesLista;
        private Arma armaActual;
        public FormCambiarArma()
        {
            InitializeComponent();
        }

        private void lbl_Cadencia_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Index_Click(object sender, EventArgs e)
        {

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

            txt_Nombre.Text = arma.nombre;
            txt_Daño.Text = arma.daño.ToString();
            txt_Municion.Text = arma.municion.ToString();
            txt_Velocidad.Text = arma.velocidad.ToString();
            txt_vida.Text = arma.vida.ToString();


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

        private void btn_cambiar_Click(object sender, EventArgs e)
        {
            var nombre = txt_Nombre.Text;
            var dano = txt_Daño.Text;
            var municion = txt_Municion.Text;
            var velocidad = txt_Velocidad.Text ;
            var vida = txt_vida.Text;
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
            if (dataGridView2.CurrentRow == null)
            {
                municion1 = new Municion();
            }
            else
            {
                int filaSeleccionada = dataGridView2.CurrentRow.Index;
                string nom = dataGridView2.CurrentRow.Cells[0].Value.ToString();
                municion1 = new Municion();
                foreach (Municion m in municionesLista)
                {
                    if (m.nombreMunicion.Equals(nom))
                    {
                        municion1 = m;
                    }
                }

            }




            var options = new RestClientOptions("http://localhost:8080");
            var client = new RestClient(options);
            var request = new RestRequest("/Arma/");

            request.RequestFormat = DataFormat.Json;

            request.AddBody(new
            {

                nombre = nombre,
                daño= dano,
                municion= municion,
                vida= vida,
                velocidad= velocidad,
                fechaCreacion=fechaFormateada,
                tipoMunicion=new
                {
                    nombre = municion1.nombreMunicion,
                    danoArea = municion1.dañoArea,
                    cadencia = municion1.cadencia,

                },
                tipo ="Rifle",
                id= armaActual.id
            });

            try
            {
                var response = client.Execute(request, Method.Put);

                if (response.IsSuccessful)
                {
                    MessageBox.Show("Se actualizo el arma correctamente", "Éxito");
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

        private void label1_Click(object sender, EventArgs e)
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
                    municionesLista = municiones;

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


            dataGridView2.Columns.Clear();
            dataGridView2.Rows.Clear();

            dataGridView2.Columns.Add("nombre", "Nombre");
            dataGridView2.Columns.Add("cadencia", "Cadencia");
            dataGridView2.Columns.Add("danoArea", "Daño en Área");
            dataGridView2.Columns.Add("indice", "Índice");
            dataGridView2.ReadOnly = true;
            dataGridView2.AllowUserToAddRows = false;
            foreach (var Municion in municiones)
            {
                dataGridView2.Rows.Add(Municion.nombreMunicion, Municion.cadencia, Municion.dañoArea, Municion.id);
            }
        }

        private void FormCambiarArma_Load(object sender, EventArgs e)
        {

        }

        private void monthCalendar1_DateChanged(object sender, DateRangeEventArgs e)
        {

        }

        private void textNombre_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_vida_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_DanoArea_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Nombre_Click(object sender, EventArgs e)
        {

        }

        private void txt_Velocidad_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Municion_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_Daño_TextChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
