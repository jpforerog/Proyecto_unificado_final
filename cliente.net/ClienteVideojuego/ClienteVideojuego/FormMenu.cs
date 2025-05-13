using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteVideojuego
{

    
    public partial class FormMenu : Form
    {
        public FormMenu()
        {
            InitializeComponent();
        }

        private void btn_Iniciar_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Es necesario haber creado un arma primero");
        }

        private void municionToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void armaToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void acercaDeNostrosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("By: Juan Alvarez, Juan Forero, Sebastian Acosta.");
        }


        //Apartado Arma
        private void crearToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormCrearArma formCrearArma = new FormCrearArma();  // Crea una instancia del formulario
                formCrearArma.Show();               // Muestra el formulario (no bloquea el actual)
            }
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormListarArma formListaArma = new FormListarArma();  // Crea una instancia del formulario
                formListaArma.Show();               // Muestra el formulario (no bloquea el actual)
            }
        }

        private void actualizarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormCambiarArma formCambiarArma  = new FormCambiarArma();  // Crea una instancia del formulario
                formCambiarArma.Show();               // Muestra el formulario (no bloquea el actual)
            }
        }

        private void eliminarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            {
                FormEliminarArma formEliminarArma = new FormEliminarArma();  // Crea una instancia del formulario
                formEliminarArma.Show();               // Muestra el formulario (no bloquea el actual)
            }
        }



        //Apartado Municion



        private void crearToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                FormCrearMunicion formCrearMunicion = new FormCrearMunicion();  // Crea una instancia del formulario
                formCrearMunicion.Show();               // Muestra el formulario (no bloquea el actual)
            }
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                FormListarMunicion formListarMunicion = new FormListarMunicion();  // Crea una instancia del formulario
                formListarMunicion.Show();               // Muestra el formulario (no bloquea el actual)
            }
        }

        private void actualizarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                FormCambiarMunicion formCambiarMunicion = new FormCambiarMunicion();  // Crea una instancia del formulario
                formCambiarMunicion.Show();               // Muestra el formulario (no bloquea el actual)
            }
        }

        private void eliminarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            {
                FormEliminarMunicion formEliminarMunicion = new FormEliminarMunicion();  // Crea una instancia del formulario
                formEliminarMunicion.Show();               // Muestra el formulario (no bloquea el actual)
            }
        }

        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormFiltrarMunicion formFiltrarMunicion = new FormFiltrarMunicion();
            formFiltrarMunicion.Show();
        }

        private void filtrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormFiltrarArma formFiltrarArma = new FormFiltrarArma();
            formFiltrarArma.Show();
        }

        private void buscarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormBuscarArma form = new FormBuscarArma();
            form.Show();
        }

        private void buscarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            FormBuscarMunicion bus = new FormBuscarMunicion();
            bus.Show();
        }
    }
}
