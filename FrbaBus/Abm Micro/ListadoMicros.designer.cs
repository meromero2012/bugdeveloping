namespace FrbaBus.Abm_Micro
{
    partial class ListadoMicros
    {
        /// <summary>
        /// Variable del diseñador requerida.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén utilizando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben eliminar; false en caso contrario, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido del método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.label4 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_Patente = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.textBox_Modelo = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox_Servicio = new System.Windows.Forms.ComboBox();
            this.label_Marca = new System.Windows.Forms.Label();
            this.comboBox_Marca = new System.Windows.Forms.ComboBox();
            this.button_Volver = new System.Windows.Forms.Button();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.bFiltrar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dataGridView_Micros = new System.Windows.Forms.DataGridView();
            this.textBox_NumeroMicro = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Micros)).BeginInit();
            this.SuspendLayout();
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(255, 51);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(88, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Numero de Micro";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(48, 15);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 32;
            this.label8.Text = "Patente";
            // 
            // textBox_Patente
            // 
            this.textBox_Patente.Location = new System.Drawing.Point(120, 12);
            this.textBox_Patente.Name = "textBox_Patente";
            this.textBox_Patente.Size = new System.Drawing.Size(121, 20);
            this.textBox_Patente.TabIndex = 31;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 83);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(42, 13);
            this.label5.TabIndex = 30;
            this.label5.Text = "Modelo";
            // 
            // textBox_Modelo
            // 
            this.textBox_Modelo.Location = new System.Drawing.Point(120, 83);
            this.textBox_Modelo.Name = "textBox_Modelo";
            this.textBox_Modelo.Size = new System.Drawing.Size(121, 20);
            this.textBox_Modelo.TabIndex = 29;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(277, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(45, 13);
            this.label1.TabIndex = 28;
            this.label1.Text = "Servicio";
            // 
            // comboBox_Servicio
            // 
            this.comboBox_Servicio.FormattingEnabled = true;
            this.comboBox_Servicio.Location = new System.Drawing.Point(349, 12);
            this.comboBox_Servicio.Name = "comboBox_Servicio";
            this.comboBox_Servicio.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Servicio.TabIndex = 27;
            // 
            // label_Marca
            // 
            this.label_Marca.AutoSize = true;
            this.label_Marca.Location = new System.Drawing.Point(48, 48);
            this.label_Marca.Name = "label_Marca";
            this.label_Marca.Size = new System.Drawing.Size(37, 13);
            this.label_Marca.TabIndex = 26;
            this.label_Marca.Text = "Marca";
            // 
            // comboBox_Marca
            // 
            this.comboBox_Marca.FormattingEnabled = true;
            this.comboBox_Marca.Location = new System.Drawing.Point(120, 48);
            this.comboBox_Marca.Name = "comboBox_Marca";
            this.comboBox_Marca.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Marca.TabIndex = 25;
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(487, 93);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(117, 26);
            this.button_Volver.TabIndex = 59;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(487, 15);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(117, 26);
            this.button_Limpiar.TabIndex = 58;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button_Limpiar_Click);
            // 
            // bFiltrar
            // 
            this.bFiltrar.Location = new System.Drawing.Point(487, 51);
            this.bFiltrar.Name = "bFiltrar";
            this.bFiltrar.Size = new System.Drawing.Size(117, 26);
            this.bFiltrar.TabIndex = 57;
            this.bFiltrar.Text = "Buscar";
            this.bFiltrar.UseVisualStyleBackColor = true;
            this.bFiltrar.Click += new System.EventHandler(this.bFiltrar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(78, 122);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(311, 13);
            this.label2.TabIndex = 61;
            this.label2.Text = "Seleccionar un recorrido haciendo doble click en la fila indicada.";
            // 
            // dataGridView_Micros
            // 
            this.dataGridView_Micros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Micros.Location = new System.Drawing.Point(81, 152);
            this.dataGridView_Micros.Name = "dataGridView_Micros";
            this.dataGridView_Micros.Size = new System.Drawing.Size(459, 263);
            this.dataGridView_Micros.TabIndex = 60;
            this.dataGridView_Micros.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Micros_CellDoubleClick);
            // 
            // textBox_NumeroMicro
            // 
            this.textBox_NumeroMicro.Location = new System.Drawing.Point(349, 49);
            this.textBox_NumeroMicro.Name = "textBox_NumeroMicro";
            this.textBox_NumeroMicro.Size = new System.Drawing.Size(121, 20);
            this.textBox_NumeroMicro.TabIndex = 62;
            // 
            // ListadoMicros
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(627, 443);
            this.Controls.Add(this.textBox_NumeroMicro);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dataGridView_Micros);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.button_Limpiar);
            this.Controls.Add(this.bFiltrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.textBox_Patente);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.textBox_Modelo);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_Servicio);
            this.Controls.Add(this.label_Marca);
            this.Controls.Add(this.comboBox_Marca);
            this.Name = "ListadoMicros";
            this.Text = "Listado de Micros";
            this.Load += new System.EventHandler(this.ListadoMicros_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Micros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_Patente;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox textBox_Modelo;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox_Servicio;
        private System.Windows.Forms.Label label_Marca;
        private System.Windows.Forms.ComboBox comboBox_Marca;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.Button bFiltrar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView dataGridView_Micros;
        private System.Windows.Forms.TextBox textBox_NumeroMicro;
    }
}