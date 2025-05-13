namespace ClienteVideojuego
{
    partial class FormEliminarArma
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
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Daño = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Municion = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Velocidad = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_listar
            // 
            this.btn_listar.Location = new System.Drawing.Point(88, 138);
            this.btn_listar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_listar.Name = "btn_listar";
            this.btn_listar.Size = new System.Drawing.Size(237, 89);
            this.btn_listar.TabIndex = 5;
            this.btn_listar.Text = "Listar armas";
            this.btn_listar.UseVisualStyleBackColor = true;
            this.btn_listar.Click += new System.EventHandler(this.btn_listar_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Daño,
            this.Municion,
            this.Velocidad});
            this.dataGridView1.Location = new System.Drawing.Point(405, 138);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(649, 79);
            this.dataGridView1.TabIndex = 4;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.MinimumWidth = 6;
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            this.Nombre.Width = 125;
            // 
            // Daño
            // 
            this.Daño.HeaderText = "Daño";
            this.Daño.MinimumWidth = 6;
            this.Daño.Name = "Daño";
            this.Daño.ReadOnly = true;
            this.Daño.Width = 125;
            // 
            // Municion
            // 
            this.Municion.HeaderText = "Municion";
            this.Municion.MinimumWidth = 6;
            this.Municion.Name = "Municion";
            this.Municion.ReadOnly = true;
            this.Municion.Width = 125;
            // 
            // Velocidad
            // 
            this.Velocidad.HeaderText = "Velocidad";
            this.Velocidad.MinimumWidth = 6;
            this.Velocidad.Name = "Velocidad";
            this.Velocidad.ReadOnly = true;
            this.Velocidad.Width = 125;
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(141, 66);
            this.textNombre.Margin = new System.Windows.Forms.Padding(4);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(116, 22);
            this.textNombre.TabIndex = 8;
            this.textNombre.TextChanged += new System.EventHandler(this.txt_eliminar_TextChanged);
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(103, 352);
            this.btn_Eliminar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(175, 58);
            this.btn_Eliminar.TabIndex = 7;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // FormEliminarArma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1067, 554);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.btn_listar);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormEliminarArma";
            this.Text = "Form5";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_listar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daño;
        private System.Windows.Forms.DataGridViewTextBoxColumn Municion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Velocidad;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.Button btn_Eliminar;
    }
}