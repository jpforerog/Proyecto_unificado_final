namespace ClienteVideojuego
{
    partial class FormCambiarArma
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
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lbl_Index = new System.Windows.Forms.Label();
            this.lbl_DanoArea = new System.Windows.Forms.Label();
            this.lbl_Cadencia = new System.Windows.Forms.Label();
            this.lbl_Nombre = new System.Windows.Forms.Label();
            this.txt_Velocidad = new System.Windows.Forms.TextBox();
            this.txt_Municion = new System.Windows.Forms.TextBox();
            this.txt_Daño = new System.Windows.Forms.TextBox();
            this.txt_Nombre = new System.Windows.Forms.TextBox();
            this.btn_cambiar = new System.Windows.Forms.Button();
            this.txt_vida = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.textNombre = new System.Windows.Forms.TextBox();
            this.monthCalendar1 = new System.Windows.Forms.MonthCalendar();
            this.dataGridView2 = new System.Windows.Forms.DataGridView();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).BeginInit();
            this.SuspendLayout();
            // 
            // btn_listar
            // 
            this.btn_listar.Location = new System.Drawing.Point(49, 129);
            this.btn_listar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_listar.Name = "btn_listar";
            this.btn_listar.Size = new System.Drawing.Size(237, 89);
            this.btn_listar.TabIndex = 5;
            this.btn_listar.Text = "Buscar arma";
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
            this.Velocidad,
            this.Index});
            this.dataGridView1.Location = new System.Drawing.Point(329, 141);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(4);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.Size = new System.Drawing.Size(725, 77);
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
            // Index
            // 
            this.Index.HeaderText = "Index";
            this.Index.MinimumWidth = 6;
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            this.Index.Width = 125;
            // 
            // lbl_Index
            // 
            this.lbl_Index.AutoSize = true;
            this.lbl_Index.Location = new System.Drawing.Point(781, 251);
            this.lbl_Index.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Index.Name = "lbl_Index";
            this.lbl_Index.Size = new System.Drawing.Size(69, 16);
            this.lbl_Index.TabIndex = 21;
            this.lbl_Index.Text = "Velocidad";
            this.lbl_Index.Click += new System.EventHandler(this.lbl_Index_Click);
            // 
            // lbl_DanoArea
            // 
            this.lbl_DanoArea.AutoSize = true;
            this.lbl_DanoArea.Location = new System.Drawing.Point(648, 249);
            this.lbl_DanoArea.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_DanoArea.Name = "lbl_DanoArea";
            this.lbl_DanoArea.Size = new System.Drawing.Size(60, 16);
            this.lbl_DanoArea.TabIndex = 20;
            this.lbl_DanoArea.Text = "Municion";
            this.lbl_DanoArea.Click += new System.EventHandler(this.lbl_DanoArea_Click);
            // 
            // lbl_Cadencia
            // 
            this.lbl_Cadencia.AutoSize = true;
            this.lbl_Cadencia.Location = new System.Drawing.Point(507, 249);
            this.lbl_Cadencia.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Cadencia.Name = "lbl_Cadencia";
            this.lbl_Cadencia.Size = new System.Drawing.Size(40, 16);
            this.lbl_Cadencia.TabIndex = 19;
            this.lbl_Cadencia.Text = "Daño";
            this.lbl_Cadencia.Click += new System.EventHandler(this.lbl_Cadencia_Click);
            // 
            // lbl_Nombre
            // 
            this.lbl_Nombre.AutoSize = true;
            this.lbl_Nombre.Location = new System.Drawing.Point(361, 249);
            this.lbl_Nombre.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lbl_Nombre.Name = "lbl_Nombre";
            this.lbl_Nombre.Size = new System.Drawing.Size(56, 16);
            this.lbl_Nombre.TabIndex = 18;
            this.lbl_Nombre.Text = "Nombre";
            this.lbl_Nombre.Click += new System.EventHandler(this.lbl_Nombre_Click);
            // 
            // txt_Velocidad
            // 
            this.txt_Velocidad.Location = new System.Drawing.Point(749, 286);
            this.txt_Velocidad.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Velocidad.Name = "txt_Velocidad";
            this.txt_Velocidad.Size = new System.Drawing.Size(132, 22);
            this.txt_Velocidad.TabIndex = 17;
            this.txt_Velocidad.TextChanged += new System.EventHandler(this.txt_Velocidad_TextChanged);
            // 
            // txt_Municion
            // 
            this.txt_Municion.Location = new System.Drawing.Point(608, 286);
            this.txt_Municion.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Municion.Name = "txt_Municion";
            this.txt_Municion.Size = new System.Drawing.Size(132, 22);
            this.txt_Municion.TabIndex = 16;
            this.txt_Municion.TextChanged += new System.EventHandler(this.txt_Municion_TextChanged);
            // 
            // txt_Daño
            // 
            this.txt_Daño.Location = new System.Drawing.Point(469, 286);
            this.txt_Daño.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Daño.Name = "txt_Daño";
            this.txt_Daño.Size = new System.Drawing.Size(132, 22);
            this.txt_Daño.TabIndex = 15;
            this.txt_Daño.TextChanged += new System.EventHandler(this.txt_Daño_TextChanged);
            // 
            // txt_Nombre
            // 
            this.txt_Nombre.Location = new System.Drawing.Point(329, 286);
            this.txt_Nombre.Margin = new System.Windows.Forms.Padding(4);
            this.txt_Nombre.Name = "txt_Nombre";
            this.txt_Nombre.Size = new System.Drawing.Size(132, 22);
            this.txt_Nombre.TabIndex = 14;
            this.txt_Nombre.TextChanged += new System.EventHandler(this.txt_Nombre_TextChanged);
            // 
            // btn_cambiar
            // 
            this.btn_cambiar.Location = new System.Drawing.Point(49, 312);
            this.btn_cambiar.Margin = new System.Windows.Forms.Padding(4);
            this.btn_cambiar.Name = "btn_cambiar";
            this.btn_cambiar.Size = new System.Drawing.Size(237, 74);
            this.btn_cambiar.TabIndex = 13;
            this.btn_cambiar.Text = "Cambiar";
            this.btn_cambiar.UseVisualStyleBackColor = true;
            this.btn_cambiar.Click += new System.EventHandler(this.btn_cambiar_Click);
            // 
            // txt_vida
            // 
            this.txt_vida.Location = new System.Drawing.Point(891, 286);
            this.txt_vida.Margin = new System.Windows.Forms.Padding(4);
            this.txt_vida.Name = "txt_vida";
            this.txt_vida.Size = new System.Drawing.Size(132, 22);
            this.txt_vida.TabIndex = 22;
            this.txt_vida.TextChanged += new System.EventHandler(this.txt_vida_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.label1.Location = new System.Drawing.Point(933, 251);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 16);
            this.label1.TabIndex = 23;
            this.label1.Text = "Vida";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(49, 87);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(237, 22);
            this.textNombre.TabIndex = 24;
            this.textNombre.TextChanged += new System.EventHandler(this.textNombre_TextChanged);
            // 
            // monthCalendar1
            // 
            this.monthCalendar1.Location = new System.Drawing.Point(329, 312);
            this.monthCalendar1.Name = "monthCalendar1";
            this.monthCalendar1.TabIndex = 25;
            this.monthCalendar1.DateChanged += new System.Windows.Forms.DateRangeEventHandler(this.monthCalendar1_DateChanged);
            // 
            // dataGridView2
            // 
            this.dataGridView2.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView2.Location = new System.Drawing.Point(749, 328);
            this.dataGridView2.Name = "dataGridView2";
            this.dataGridView2.RowHeadersWidth = 51;
            this.dataGridView2.RowTemplate.Height = 24;
            this.dataGridView2.Size = new System.Drawing.Size(413, 124);
            this.dataGridView2.TabIndex = 26;
            this.dataGridView2.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView2_CellContentClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(750, 459);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(412, 28);
            this.button1.TabIndex = 27;
            this.button1.Text = "Listar Municiones";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // FormCambiarArma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1180, 554);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView2);
            this.Controls.Add(this.monthCalendar1);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_vida);
            this.Controls.Add(this.lbl_Index);
            this.Controls.Add(this.lbl_DanoArea);
            this.Controls.Add(this.lbl_Cadencia);
            this.Controls.Add(this.lbl_Nombre);
            this.Controls.Add(this.txt_Velocidad);
            this.Controls.Add(this.txt_Municion);
            this.Controls.Add(this.txt_Daño);
            this.Controls.Add(this.txt_Nombre);
            this.Controls.Add(this.btn_cambiar);
            this.Controls.Add(this.btn_listar);
            this.Controls.Add(this.dataGridView1);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FormCambiarArma";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.FormCambiarArma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_listar;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label lbl_Index;
        private System.Windows.Forms.Label lbl_DanoArea;
        private System.Windows.Forms.Label lbl_Cadencia;
        private System.Windows.Forms.Label lbl_Nombre;
        private System.Windows.Forms.TextBox txt_Velocidad;
        private System.Windows.Forms.TextBox txt_Municion;
        private System.Windows.Forms.TextBox txt_Daño;
        private System.Windows.Forms.TextBox txt_Nombre;
        private System.Windows.Forms.Button btn_cambiar;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Daño;
        private System.Windows.Forms.DataGridViewTextBoxColumn Municion;
        private System.Windows.Forms.DataGridViewTextBoxColumn Velocidad;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.TextBox txt_vida;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textNombre;
        private System.Windows.Forms.MonthCalendar monthCalendar1;
        private System.Windows.Forms.DataGridView dataGridView2;
        private System.Windows.Forms.Button button1;
    }
}