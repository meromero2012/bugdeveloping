namespace FrbaBus.Abm_Recorrido
{
    partial class modRecorrido
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
            this.comboBox_TipoServicio = new System.Windows.Forms.ComboBox();
            this.comboBox_CiudadDestino = new System.Windows.Forms.ComboBox();
            this.comboBox_CiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label_CodigoRecorrido = new System.Windows.Forms.Label();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.textBox_PrecioPasaje = new System.Windows.Forms.TextBox();
            this.textBox_PrecioKG = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Volver = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // comboBox_TipoServicio
            // 
            this.comboBox_TipoServicio.FormattingEnabled = true;
            this.comboBox_TipoServicio.Location = new System.Drawing.Point(144, 60);
            this.comboBox_TipoServicio.Name = "comboBox_TipoServicio";
            this.comboBox_TipoServicio.Size = new System.Drawing.Size(101, 21);
            this.comboBox_TipoServicio.TabIndex = 58;
            this.comboBox_TipoServicio.SelectedIndexChanged += new System.EventHandler(this.comboBox_TipoServicio_SelectedIndexChanged);
            // 
            // comboBox_CiudadDestino
            // 
            this.comboBox_CiudadDestino.FormattingEnabled = true;
            this.comboBox_CiudadDestino.Location = new System.Drawing.Point(144, 124);
            this.comboBox_CiudadDestino.Name = "comboBox_CiudadDestino";
            this.comboBox_CiudadDestino.Size = new System.Drawing.Size(101, 21);
            this.comboBox_CiudadDestino.TabIndex = 57;
            // 
            // comboBox_CiudadOrigen
            // 
            this.comboBox_CiudadOrigen.FormattingEnabled = true;
            this.comboBox_CiudadOrigen.Location = new System.Drawing.Point(144, 91);
            this.comboBox_CiudadOrigen.Name = "comboBox_CiudadOrigen";
            this.comboBox_CiudadOrigen.Size = new System.Drawing.Size(101, 21);
            this.comboBox_CiudadOrigen.TabIndex = 56;
            // 
            // label_CodigoRecorrido
            // 
            this.label_CodigoRecorrido.AutoSize = true;
            this.label_CodigoRecorrido.Location = new System.Drawing.Point(145, 9);
            this.label_CodigoRecorrido.Name = "label_CodigoRecorrido";
            this.label_CodigoRecorrido.Size = new System.Drawing.Size(67, 13);
            this.label_CodigoRecorrido.TabIndex = 55;
            this.label_CodigoRecorrido.Text = "TextoCodigo";
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(336, 162);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 54;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // textBox_PrecioPasaje
            // 
            this.textBox_PrecioPasaje.Location = new System.Drawing.Point(388, 83);
            this.textBox_PrecioPasaje.Name = "textBox_PrecioPasaje";
            this.textBox_PrecioPasaje.Size = new System.Drawing.Size(101, 20);
            this.textBox_PrecioPasaje.TabIndex = 53;
            // 
            // textBox_PrecioKG
            // 
            this.textBox_PrecioKG.Location = new System.Drawing.Point(388, 58);
            this.textBox_PrecioKG.Name = "textBox_PrecioKG";
            this.textBox_PrecioKG.Size = new System.Drawing.Size(101, 20);
            this.textBox_PrecioKG.TabIndex = 52;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(27, 60);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 51;
            this.label6.Text = "Tipo Servicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(271, 86);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 50;
            this.label5.Text = "Precio Pasaje";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(271, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 49;
            this.label4.Text = "Precio KG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(27, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 48;
            this.label3.Text = "Ciudad Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 47;
            this.label1.Text = "Ciudad Origen";
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(233, 162);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(75, 23);
            this.button_Volver.TabIndex = 46;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(131, 162);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 45;
            this.button_Cancelar.Text = "Limpiar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(27, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 26);
            this.label2.TabIndex = 44;
            this.label2.Text = "Codigo Recorrido\r\n( Sin viajes asignados)";
            // 
            // modRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(541, 196);
            this.Controls.Add(this.comboBox_TipoServicio);
            this.Controls.Add(this.comboBox_CiudadDestino);
            this.Controls.Add(this.comboBox_CiudadOrigen);
            this.Controls.Add(this.label_CodigoRecorrido);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.textBox_PrecioPasaje);
            this.Controls.Add(this.textBox_PrecioKG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.label2);
            this.Name = "modRecorrido";
            this.Text = "Modificacion de Recorridos";
            this.Load += new System.EventHandler(this.modRecorrido_Load_1);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_TipoServicio;
        private System.Windows.Forms.ComboBox comboBox_CiudadDestino;
        private System.Windows.Forms.ComboBox comboBox_CiudadOrigen;
        private System.Windows.Forms.Label label_CodigoRecorrido;
        private System.Windows.Forms.Button button_Guardar;
        public System.Windows.Forms.TextBox textBox_PrecioPasaje;
        public System.Windows.Forms.TextBox textBox_PrecioKG;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_Volver;
        public System.Windows.Forms.Button button_Cancelar;
        public System.Windows.Forms.Label label2;
    }
}