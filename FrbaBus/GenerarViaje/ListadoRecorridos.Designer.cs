namespace FrbaBus.GenerarViaje
{
    partial class ListadoRecorridos
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
            this.dataGridView_Recorridos = new System.Windows.Forms.DataGridView();
            this.bFiltrar = new System.Windows.Forms.Button();
            this.comboBoxTipoServicio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.textBoxCiudadOrigen = new System.Windows.Forms.TextBox();
            this.textBoxCiudadDestino = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Recorridos)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Recorridos
            // 
            this.dataGridView_Recorridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Recorridos.Location = new System.Drawing.Point(25, 157);
            this.dataGridView_Recorridos.Name = "dataGridView_Recorridos";
            this.dataGridView_Recorridos.Size = new System.Drawing.Size(459, 263);
            this.dataGridView_Recorridos.TabIndex = 0;
            this.dataGridView_Recorridos.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataRecorridos_CellDoubleClick);
            this.dataGridView_Recorridos.CellContentDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataRecorridos_CellDoubleClick);
            // 
            // bFiltrar
            // 
            this.bFiltrar.Location = new System.Drawing.Point(342, 12);
            this.bFiltrar.Name = "bFiltrar";
            this.bFiltrar.Size = new System.Drawing.Size(117, 26);
            this.bFiltrar.TabIndex = 28;
            this.bFiltrar.Text = "Buscar";
            this.bFiltrar.UseVisualStyleBackColor = true;
            this.bFiltrar.Click += new System.EventHandler(this.buscarRecorrido_Click);
            // 
            // comboBoxTipoServicio
            // 
            this.comboBoxTipoServicio.FormattingEnabled = true;
            this.comboBoxTipoServicio.Location = new System.Drawing.Point(169, 84);
            this.comboBoxTipoServicio.Name = "comboBoxTipoServicio";
            this.comboBoxTipoServicio.Size = new System.Drawing.Size(131, 21);
            this.comboBoxTipoServicio.TabIndex = 34;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(63, 87);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 31;
            this.label3.Text = "Tipo de Servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(63, 60);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 30;
            this.label2.Text = "Ciudad Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(63, 33);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 29;
            this.label1.Text = "Ciudad Origen";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(342, 56);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 26);
            this.button1.TabIndex = 35;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // textBoxCiudadOrigen
            // 
            this.textBoxCiudadOrigen.Location = new System.Drawing.Point(169, 30);
            this.textBoxCiudadOrigen.Name = "textBoxCiudadOrigen";
            this.textBoxCiudadOrigen.Size = new System.Drawing.Size(131, 20);
            this.textBoxCiudadOrigen.TabIndex = 36;
            // 
            // textBoxCiudadDestino
            // 
            this.textBoxCiudadDestino.Location = new System.Drawing.Point(169, 57);
            this.textBoxCiudadDestino.Name = "textBoxCiudadDestino";
            this.textBoxCiudadDestino.Size = new System.Drawing.Size(131, 20);
            this.textBoxCiudadDestino.TabIndex = 37;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 134);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 13);
            this.label4.TabIndex = 38;
            this.label4.Text = "Seleccionar un recorrido haciendo doble click en la fila indicada.";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(342, 96);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 26);
            this.button2.TabIndex = 45;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // ListadoRecorridos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(513, 436);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCiudadDestino);
            this.Controls.Add(this.textBoxCiudadOrigen);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.comboBoxTipoServicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.bFiltrar);
            this.Controls.Add(this.dataGridView_Recorridos);
            this.Name = "ListadoRecorridos";
            this.Text = "Listado de Recorridos";
            this.Load += new System.EventHandler(this.ListadoRecorridos_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Recorridos)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Recorridos;
        private System.Windows.Forms.Button bFiltrar;
        private System.Windows.Forms.ComboBox comboBoxTipoServicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox textBoxCiudadOrigen;
        private System.Windows.Forms.TextBox textBoxCiudadDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
    }
}