namespace FrbaBus.Abm_Recorrido
{
    partial class ModificacionRecorrido
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
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox_CodigoRecorrido = new System.Windows.Forms.ComboBox();
            this.textBox_PrecioPasaje_Actual = new System.Windows.Forms.TextBox();
            this.textBox_PrecioKG_Actual = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button_Volver = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.textBox_CiudadDestino_Actual = new System.Windows.Forms.TextBox();
            this.textBox_CiudadOrigen_Actual = new System.Windows.Forms.TextBox();
            this.textBox_Servicio_Actual = new System.Windows.Forms.TextBox();
            this.textBox_PrecioPasaje = new System.Windows.Forms.TextBox();
            this.textBox_PrecioKG = new System.Windows.Forms.TextBox();
            this.comboBox_TipoServicio = new System.Windows.Forms.ComboBox();
            this.comboBox_CiudadDestino = new System.Windows.Forms.ComboBox();
            this.comboBox_CiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.buttom_Editar = new System.Windows.Forms.Button();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.textBox_Activo_Actual = new System.Windows.Forms.TextBox();
            this.comboBox_Activo = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(112, 26);
            this.label2.TabIndex = 6;
            this.label2.Text = "Codigo Recorrido\r\n( Sin viajes asignados)";
            // 
            // comboBox_CodigoRecorrido
            // 
            this.comboBox_CodigoRecorrido.FormattingEnabled = true;
            this.comboBox_CodigoRecorrido.Location = new System.Drawing.Point(148, 14);
            this.comboBox_CodigoRecorrido.Name = "comboBox_CodigoRecorrido";
            this.comboBox_CodigoRecorrido.Size = new System.Drawing.Size(102, 21);
            this.comboBox_CodigoRecorrido.TabIndex = 7;
            this.comboBox_CodigoRecorrido.SelectedIndexChanged += new System.EventHandler(this.comboBox_CodigoRecorrido_SelectedIndexChanged);
            // 
            // textBox_PrecioPasaje_Actual
            // 
            this.textBox_PrecioPasaje_Actual.Location = new System.Drawing.Point(149, 205);
            this.textBox_PrecioPasaje_Actual.Name = "textBox_PrecioPasaje_Actual";
            this.textBox_PrecioPasaje_Actual.Size = new System.Drawing.Size(101, 20);
            this.textBox_PrecioPasaje_Actual.TabIndex = 25;
            // 
            // textBox_PrecioKG_Actual
            // 
            this.textBox_PrecioKG_Actual.Location = new System.Drawing.Point(149, 180);
            this.textBox_PrecioKG_Actual.Name = "textBox_PrecioKG_Actual";
            this.textBox_PrecioKG_Actual.Size = new System.Drawing.Size(101, 20);
            this.textBox_PrecioKG_Actual.TabIndex = 24;
            this.textBox_PrecioKG_Actual.TextChanged += new System.EventHandler(this.textBox_PrecioKG_Actual_TextChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(32, 76);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 23;
            this.label6.Text = "Tipo Servicio";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(32, 208);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 21;
            this.label5.Text = "Precio Pasaje";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(32, 182);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Precio KG";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 143);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 18;
            this.label3.Text = "Ciudad Destino";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 107);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 17;
            this.label1.Text = "Ciudad Origen";
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(35, 260);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(75, 23);
            this.button_Volver.TabIndex = 15;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(393, 13);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 14;
            this.button_Cancelar.Text = "Cancelar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // textBox_CiudadDestino_Actual
            // 
            this.textBox_CiudadDestino_Actual.Location = new System.Drawing.Point(148, 140);
            this.textBox_CiudadDestino_Actual.Name = "textBox_CiudadDestino_Actual";
            this.textBox_CiudadDestino_Actual.Size = new System.Drawing.Size(101, 20);
            this.textBox_CiudadDestino_Actual.TabIndex = 26;
            // 
            // textBox_CiudadOrigen_Actual
            // 
            this.textBox_CiudadOrigen_Actual.Location = new System.Drawing.Point(149, 107);
            this.textBox_CiudadOrigen_Actual.Name = "textBox_CiudadOrigen_Actual";
            this.textBox_CiudadOrigen_Actual.Size = new System.Drawing.Size(101, 20);
            this.textBox_CiudadOrigen_Actual.TabIndex = 27;
            // 
            // textBox_Servicio_Actual
            // 
            this.textBox_Servicio_Actual.Location = new System.Drawing.Point(149, 76);
            this.textBox_Servicio_Actual.Name = "textBox_Servicio_Actual";
            this.textBox_Servicio_Actual.Size = new System.Drawing.Size(101, 20);
            this.textBox_Servicio_Actual.TabIndex = 28;
            this.textBox_Servicio_Actual.TextChanged += new System.EventHandler(this.textBox_Servicio_Actual_TextChanged);
            // 
            // textBox_PrecioPasaje
            // 
            this.textBox_PrecioPasaje.Location = new System.Drawing.Point(295, 208);
            this.textBox_PrecioPasaje.Name = "textBox_PrecioPasaje";
            this.textBox_PrecioPasaje.Size = new System.Drawing.Size(101, 20);
            this.textBox_PrecioPasaje.TabIndex = 33;
            // 
            // textBox_PrecioKG
            // 
            this.textBox_PrecioKG.Location = new System.Drawing.Point(295, 182);
            this.textBox_PrecioKG.Name = "textBox_PrecioKG";
            this.textBox_PrecioKG.Size = new System.Drawing.Size(101, 20);
            this.textBox_PrecioKG.TabIndex = 32;
            // 
            // comboBox_TipoServicio
            // 
            this.comboBox_TipoServicio.FormattingEnabled = true;
            this.comboBox_TipoServicio.Location = new System.Drawing.Point(295, 76);
            this.comboBox_TipoServicio.Name = "comboBox_TipoServicio";
            this.comboBox_TipoServicio.Size = new System.Drawing.Size(101, 21);
            this.comboBox_TipoServicio.TabIndex = 31;
            // 
            // comboBox_CiudadDestino
            // 
            this.comboBox_CiudadDestino.FormattingEnabled = true;
            this.comboBox_CiudadDestino.Location = new System.Drawing.Point(295, 143);
            this.comboBox_CiudadDestino.Name = "comboBox_CiudadDestino";
            this.comboBox_CiudadDestino.Size = new System.Drawing.Size(101, 21);
            this.comboBox_CiudadDestino.TabIndex = 30;
            // 
            // comboBox_CiudadOrigen
            // 
            this.comboBox_CiudadOrigen.FormattingEnabled = true;
            this.comboBox_CiudadOrigen.Location = new System.Drawing.Point(295, 107);
            this.comboBox_CiudadOrigen.Name = "comboBox_CiudadOrigen";
            this.comboBox_CiudadOrigen.Size = new System.Drawing.Size(101, 21);
            this.comboBox_CiudadOrigen.TabIndex = 29;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(146, 56);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(86, 13);
            this.label7.TabIndex = 34;
            this.label7.Text = "Valores Actuales";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(292, 56);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(82, 13);
            this.label8.TabIndex = 35;
            this.label8.Text = "Nuevos Valores";
            // 
            // buttom_Editar
            // 
            this.buttom_Editar.Location = new System.Drawing.Point(295, 13);
            this.buttom_Editar.Name = "buttom_Editar";
            this.buttom_Editar.Size = new System.Drawing.Size(75, 23);
            this.buttom_Editar.TabIndex = 36;
            this.buttom_Editar.Text = "Editar";
            this.buttom_Editar.UseVisualStyleBackColor = true;
            this.buttom_Editar.Click += new System.EventHandler(this.Editar_Click);
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(295, 14);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 37;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(32, 234);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(37, 13);
            this.label9.TabIndex = 38;
            this.label9.Text = "Activo";
            // 
            // textBox_Activo_Actual
            // 
            this.textBox_Activo_Actual.Location = new System.Drawing.Point(148, 231);
            this.textBox_Activo_Actual.Name = "textBox_Activo_Actual";
            this.textBox_Activo_Actual.Size = new System.Drawing.Size(101, 20);
            this.textBox_Activo_Actual.TabIndex = 39;
            // 
            // comboBox_Activo
            // 
            this.comboBox_Activo.FormattingEnabled = true;
            this.comboBox_Activo.Location = new System.Drawing.Point(295, 234);
            this.comboBox_Activo.Name = "comboBox_Activo";
            this.comboBox_Activo.Size = new System.Drawing.Size(101, 21);
            this.comboBox_Activo.TabIndex = 40;
            this.comboBox_Activo.SelectedIndexChanged += new System.EventHandler(this.comboBox_Activo_SelectedIndexChanged);
            // 
            // ModificacionRecorrido
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(565, 305);
            this.Controls.Add(this.comboBox_Activo);
            this.Controls.Add(this.textBox_Activo_Actual);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.buttom_Editar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.textBox_PrecioPasaje);
            this.Controls.Add(this.textBox_PrecioKG);
            this.Controls.Add(this.comboBox_TipoServicio);
            this.Controls.Add(this.comboBox_CiudadDestino);
            this.Controls.Add(this.comboBox_CiudadOrigen);
            this.Controls.Add(this.textBox_Servicio_Actual);
            this.Controls.Add(this.textBox_CiudadOrigen_Actual);
            this.Controls.Add(this.textBox_CiudadDestino_Actual);
            this.Controls.Add(this.textBox_PrecioPasaje_Actual);
            this.Controls.Add(this.textBox_PrecioKG_Actual);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.button_Cancelar);
            this.Controls.Add(this.comboBox_CodigoRecorrido);
            this.Controls.Add(this.label2);
            this.Name = "ModificacionRecorrido";
            this.Text = "ModificacionRecorrido";
            this.Load += new System.EventHandler(this.ModificacionRecorrido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.Label label2;
        public System.Windows.Forms.ComboBox comboBox_CodigoRecorrido;
        public System.Windows.Forms.TextBox textBox_PrecioPasaje_Actual;
        public System.Windows.Forms.TextBox textBox_PrecioKG_Actual;
        public System.Windows.Forms.Label label6;
        public System.Windows.Forms.Label label5;
        public System.Windows.Forms.Label label4;
        public System.Windows.Forms.Label label3;
        public System.Windows.Forms.Label label1;
        public System.Windows.Forms.Button button_Volver;
        public System.Windows.Forms.Button button_Cancelar;
        public System.Windows.Forms.TextBox textBox_CiudadDestino_Actual;
        public System.Windows.Forms.TextBox textBox_CiudadOrigen_Actual;
        public System.Windows.Forms.TextBox textBox_Servicio_Actual;
        public System.Windows.Forms.TextBox textBox_PrecioPasaje;
        public System.Windows.Forms.TextBox textBox_PrecioKG;
        public System.Windows.Forms.ComboBox comboBox_TipoServicio;
        public System.Windows.Forms.ComboBox comboBox_CiudadDestino;
        public System.Windows.Forms.ComboBox comboBox_CiudadOrigen;
        public System.Windows.Forms.Label label7;
        public System.Windows.Forms.Label label8;
        private System.Windows.Forms.Button buttom_Editar;
        private System.Windows.Forms.Button button_Guardar;
        public System.Windows.Forms.Label label9;
        public System.Windows.Forms.TextBox textBox_Activo_Actual;
        public System.Windows.Forms.ComboBox comboBox_Activo;
    }
}