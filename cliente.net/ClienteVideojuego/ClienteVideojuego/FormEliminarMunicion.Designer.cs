namespace ClienteVideojuego
{
    partial class FormEliminarMunicion
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
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.Nombre = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Cadencia = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.DañoArea = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Index = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btn_Eliminar = new System.Windows.Forms.Button();
            this.textNombre = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(66, 112);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(178, 72);
            this.button1.TabIndex = 3;
            this.button1.Text = "Listar Municiones";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Nombre,
            this.Cadencia,
            this.DañoArea,
            this.Index});
            this.dataGridView1.Location = new System.Drawing.Point(304, 54);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.Size = new System.Drawing.Size(448, 150);
            this.dataGridView1.TabIndex = 2;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            // 
            // Nombre
            // 
            this.Nombre.Frozen = true;
            this.Nombre.HeaderText = "Nombre";
            this.Nombre.Name = "Nombre";
            this.Nombre.ReadOnly = true;
            // 
            // Cadencia
            // 
            this.Cadencia.Frozen = true;
            this.Cadencia.HeaderText = "Cadencia";
            this.Cadencia.Name = "Cadencia";
            this.Cadencia.ReadOnly = true;
            // 
            // DañoArea
            // 
            this.DañoArea.Frozen = true;
            this.DañoArea.HeaderText = "DañoArea";
            this.DañoArea.Name = "DañoArea";
            this.DañoArea.ReadOnly = true;
            // 
            // Index
            // 
            this.Index.Frozen = true;
            this.Index.HeaderText = "Index";
            this.Index.Name = "Index";
            this.Index.ReadOnly = true;
            // 
            // btn_Eliminar
            // 
            this.btn_Eliminar.Location = new System.Drawing.Point(88, 294);
            this.btn_Eliminar.Name = "btn_Eliminar";
            this.btn_Eliminar.Size = new System.Drawing.Size(131, 47);
            this.btn_Eliminar.TabIndex = 4;
            this.btn_Eliminar.Text = "Eliminar";
            this.btn_Eliminar.UseVisualStyleBackColor = true;
            this.btn_Eliminar.Click += new System.EventHandler(this.btn_Eliminar_Click);
            // 
            // textNombre
            // 
            this.textNombre.Location = new System.Drawing.Point(108, 54);
            this.textNombre.Name = "textNombre";
            this.textNombre.Size = new System.Drawing.Size(100, 20);
            this.textNombre.TabIndex = 7;
            // 
            // FormEliminarMunicion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.textNombre);
            this.Controls.Add(this.btn_Eliminar);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "FormEliminarMunicion";
            this.Text = "Form4";
            this.Load += new System.EventHandler(this.FormEliminarMunicion_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Nombre;
        private System.Windows.Forms.DataGridViewTextBoxColumn Cadencia;
        private System.Windows.Forms.DataGridViewTextBoxColumn DañoArea;
        private System.Windows.Forms.DataGridViewTextBoxColumn Index;
        private System.Windows.Forms.Button btn_Eliminar;
        private System.Windows.Forms.TextBox textNombre;
    }
}