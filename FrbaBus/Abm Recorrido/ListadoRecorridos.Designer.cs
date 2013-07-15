namespace FrbaBus.Abm_Recorrido
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
            this.button_Volver = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.textBoxCiudadDestino = new System.Windows.Forms.TextBox();
            this.textBoxCiudadOrigen = new System.Windows.Forms.TextBox();
            this.button_Limpiar = new System.Windows.Forms.Button();
            this.comboBoxTipoServicio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.bFiltrar = new System.Windows.Forms.Button();
            this.dataGridView_Recorridos = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Recorridos)).BeginInit();
            this.SuspendLayout();
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(344, 92);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(117, 26);
            this.button_Volver.TabIndex = 56;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(35, 130);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(311, 13);
            this.label4.TabIndex = 55;
            this.label4.Text = "Seleccionar un recorrido haciendo doble click en la fila indicada.";
            // 
            // textBoxCiudadDestino
            // 
            this.textBoxCiudadDestino.Location = new System.Drawing.Point(171, 53);
            this.textBoxCiudadDestino.Name = "textBoxCiudadDestino";
            this.textBoxCiudadDestino.Size = new System.Drawing.Size(131, 20);
            this.textBoxCiudadDestino.TabIndex = 54;
            // 
            // textBoxCiudadOrigen
            // 
            this.textBoxCiudadOrigen.Location = new System.Drawing.Point(171, 26);
            this.textBoxCiudadOrigen.Name = "textBoxCiudadOrigen";
            this.textBoxCiudadOrigen.Size = new System.Drawing.Size(131, 20);
            this.textBoxCiudadOrigen.TabIndex = 53;
            // 
            // button_Limpiar
            // 
            this.button_Limpiar.Location = new System.Drawing.Point(344, 52);
            this.button_Limpiar.Name = "button_Limpiar";
            this.button_Limpiar.Size = new System.Drawing.Size(117, 26);
            this.button_Limpiar.TabIndex = 52;
            this.button_Limpiar.Text = "Limpiar";
            this.button_Limpiar.UseVisualStyleBackColor = true;
            this.button_Limpiar.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBoxTipoServicio
            // 
            this.comboBoxTipoServicio.FormattingEnabled = true;
            this.comboBoxTipoServicio.Location = new System.Drawing.Point(171, 80);
            this.comboBoxTipoServicio.Name = "comboBoxTipoServicio";
            this.comboBoxTipoServicio.Size = new System.Drawing.Size(131, 21);
            this.comboBoxTipoServicio.TabIndex = 51;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(65, 83);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 50;
            this.label3.Text = "Tipo de Servicio";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(65, 56);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 13);
            this.label2.TabIndex = 49;
            this.label2.Text = "Ciudad Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(65, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 48;
            this.label1.Text = "Ciudad Origen";
            // 
            // bFiltrar
            // 
            this.bFiltrar.Location = new System.Drawing.Point(344, 8);
            this.bFiltrar.Name = "bFiltrar";
            this.bFiltrar.Size = new System.Drawing.Size(117, 26);
            this.bFiltrar.TabIndex = 47;
            this.bFiltrar.Text = "Buscar";
            this.bFiltrar.UseVisualStyleBackColor = true;
            this.bFiltrar.Click += new System.EventHandler(this.bFiltrar_Click);
            // 
            // dataGridView_Recorridos
            // 
            this.dataGridView_Recorridos.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Recorridos.Location = new System.Drawing.Point(27, 153);
            this.dataGridView_Recorridos.Name = "dataGridView_Recorridos";
            this.dataGridView_Recorridos.Size = new System.Drawing.Size(459, 263);
            this.dataGridView_Recorridos.TabIndex = 46;
            this.dataGridView_Recorridos.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Recorridos_CellDoubleClick);
            // 
            // ListadoRecorridos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(518, 438);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textBoxCiudadDestino);
            this.Controls.Add(this.textBoxCiudadOrigen);
            this.Controls.Add(this.button_Limpiar);
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

        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxCiudadDestino;
        private System.Windows.Forms.TextBox textBoxCiudadOrigen;
        private System.Windows.Forms.Button button_Limpiar;
        private System.Windows.Forms.ComboBox comboBoxTipoServicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bFiltrar;
        private System.Windows.Forms.DataGridView dataGridView_Recorridos;


    }
}