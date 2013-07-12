namespace FrbaBus.GenerarViaje
{
    partial class ListadoMicro
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
            this.dataGridView_Micros = new System.Windows.Forms.DataGridView();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.bFiltrar = new System.Windows.Forms.Button();
            this.comboBoxTipoServicio = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxCantKGS = new System.Windows.Forms.TextBox();
            this.comboBoxMarcaMicro = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Micros)).BeginInit();
            this.SuspendLayout();
            // 
            // dataGridView_Micros
            // 
            this.dataGridView_Micros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView_Micros.Location = new System.Drawing.Point(15, 165);
            this.dataGridView_Micros.Name = "dataGridView_Micros";
            this.dataGridView_Micros.Size = new System.Drawing.Size(459, 263);
            this.dataGridView_Micros.TabIndex = 1;
            this.dataGridView_Micros.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView_Micros_CellDoubleClick);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(24, 140);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(295, 13);
            this.label4.TabIndex = 39;
            this.label4.Text = "Seleccionar un micro haciendo doble click en la fila indicada.";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(341, 101);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(117, 26);
            this.button2.TabIndex = 48;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonVolver_Click);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(341, 61);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(117, 26);
            this.button1.TabIndex = 47;
            this.button1.Text = "Limpiar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // bFiltrar
            // 
            this.bFiltrar.Location = new System.Drawing.Point(341, 17);
            this.bFiltrar.Name = "bFiltrar";
            this.bFiltrar.Size = new System.Drawing.Size(117, 26);
            this.bFiltrar.TabIndex = 46;
            this.bFiltrar.Text = "Buscar";
            this.bFiltrar.UseVisualStyleBackColor = true;
            this.bFiltrar.Click += new System.EventHandler(this.buscarMicro_Click);
            // 
            // comboBoxTipoServicio
            // 
            this.comboBoxTipoServicio.FormattingEnabled = true;
            this.comboBoxTipoServicio.Location = new System.Drawing.Point(149, 59);
            this.comboBoxTipoServicio.Name = "comboBoxTipoServicio";
            this.comboBoxTipoServicio.Size = new System.Drawing.Size(131, 21);
            this.comboBoxTipoServicio.TabIndex = 50;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(43, 62);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(84, 13);
            this.label3.TabIndex = 49;
            this.label3.Text = "Tipo de Servicio";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(43, 32);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 13);
            this.label1.TabIndex = 51;
            this.label1.Text = "Marca del Micro";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(36, 93);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Capacidad en KG";
            // 
            // textBoxCantKGS
            // 
            this.textBoxCantKGS.Location = new System.Drawing.Point(149, 90);
            this.textBoxCantKGS.Name = "textBoxCantKGS";
            this.textBoxCantKGS.Size = new System.Drawing.Size(131, 20);
            this.textBoxCantKGS.TabIndex = 55;
            // 
            // comboBoxMarcaMicro
            // 
            this.comboBoxMarcaMicro.FormattingEnabled = true;
            this.comboBoxMarcaMicro.Location = new System.Drawing.Point(149, 29);
            this.comboBoxMarcaMicro.Name = "comboBoxMarcaMicro";
            this.comboBoxMarcaMicro.Size = new System.Drawing.Size(131, 21);
            this.comboBoxMarcaMicro.TabIndex = 56;
            // 
            // ListadoMicro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 441);
            this.Controls.Add(this.comboBoxMarcaMicro);
            this.Controls.Add(this.textBoxCantKGS);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBoxTipoServicio);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.bFiltrar);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.dataGridView_Micros);
            this.Name = "ListadoMicro";
            this.Text = "Listado de Micros";
            this.Load += new System.EventHandler(this.ListadoMicro_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView_Micros)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dataGridView_Micros;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button bFiltrar;
        private System.Windows.Forms.ComboBox comboBoxTipoServicio;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxCantKGS;
        private System.Windows.Forms.ComboBox comboBoxMarcaMicro;
    }
}