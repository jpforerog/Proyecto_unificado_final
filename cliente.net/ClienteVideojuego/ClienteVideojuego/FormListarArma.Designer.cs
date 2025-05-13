namespace ClienteVideojuego
{
    partial class FormListarArma
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_listar = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.daño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.municion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.vida = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.velocidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fechaCreacion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nombreMunicion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.danoArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.cadencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_listar
            // 
            this.btn_listar.Location = new System.Drawing.Point(91, 183);
            this.btn_listar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btn_listar.Name = "btn_listar";
            this.btn_listar.Size = new System.Drawing.Size(237, 89);
            this.btn_listar.TabIndex = 3;
            this.btn_listar.Text = "Listar armas";
            this.btn_listar.UseVisualStyleBackColor = true;
            this.btn_listar.Click += new System.EventHandler(this.btn_listar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.nombre,
            this.daño,
            this.municion,
            this.vida,
            this.velocidad,
            this.fechaCreacion,
            this.nombreMunicion,
            this.danoArea,
            this.cadencia});
            this.dataGridView1.Location = new System.Drawing.Point(387, 155);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(981, 185);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // nombre
            // 
            this.nombre.HeaderText = "nombre";
            this.nombre.MinimumWidth = 6;
            this.nombre.Name = "nombre";
            this.nombre.ReadOnly = true;
            this.nombre.Width = 125;
            // 
            // daño
            // 
            this.daño.HeaderText = "daño";
            this.daño.MinimumWidth = 6;
            this.daño.Name = "daño";
            this.daño.ReadOnly = true;
            this.daño.Width = 125;
            // 
            // municion
            // 
            this.municion.HeaderText = "municion";
            this.municion.MinimumWidth = 6;
            this.municion.Name = "municion";
            this.municion.ReadOnly = true;
            this.municion.Width = 125;
            // 
            // vida
            // 
            this.vida.HeaderText = "vida";
            this.vida.MinimumWidth = 6;
            this.vida.Name = "vida";
            this.vida.ReadOnly = true;
            this.vida.Width = 125;
            // 
            // velocidad
            // 
            this.velocidad.HeaderText = "velocidad";
            this.velocidad.MinimumWidth = 6;
            this.velocidad.Name = "velocidad";
            this.velocidad.ReadOnly = true;
            this.velocidad.Width = 125;
            // 
            // fechaCreacion
            // 
            this.fechaCreacion.HeaderText = "fechaCreacion";
            this.fechaCreacion.MinimumWidth = 6;
            this.fechaCreacion.Name = "fechaCreacion";
            this.fechaCreacion.ReadOnly = true;
            this.fechaCreacion.Width = 125;
            // 
            // nombreMunicion
            // 
            this.nombreMunicion.HeaderText = "nombreMunicion";
            this.nombreMunicion.MinimumWidth = 6;
            this.nombreMunicion.Name = "nombreMunicion";
            this.nombreMunicion.ReadOnly = true;
            this.nombreMunicion.Width = 125;
            // 
            // danoArea
            // 
            this.danoArea.HeaderText = "danoArea";
            this.danoArea.MinimumWidth = 6;
            this.danoArea.Name = "danoArea";
            this.danoArea.ReadOnly = true;
            this.danoArea.Width = 125;
            // 
            // cadencia
            // 
            this.cadencia.HeaderText = "cadencia";
            this.cadencia.MinimumWidth = 6;
            this.cadencia.Name = "cadencia";
            this.cadencia.ReadOnly = true;
            this.cadencia.Width = 125;
            // 
            // FormListarArma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1794, 554);
            this.Controls.Add(this.btn_listar);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "FormListarArma";
            this.Text = "Form3";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btn_listar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn daño;
        private System.Windows.Forms.DataGridViewTextBoxColumn municion;
        private System.Windows.Forms.DataGridViewTextBoxColumn vida;
        private System.Windows.Forms.DataGridViewTextBoxColumn velocidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn fechaCreacion;
        private System.Windows.Forms.DataGridViewTextBoxColumn nombreMunicion;
        private System.Windows.Forms.DataGridViewTextBoxColumn danoArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn cadencia;
    }
}