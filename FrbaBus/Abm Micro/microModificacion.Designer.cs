namespace FrbaBus.Abm_Micro
{
    partial class Micro_Modificacion
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
            this.label8 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_KG = new System.Windows.Forms.TextBox();
            this.button_Guardar = new System.Windows.Forms.Button();
            this.button_Cancelar = new System.Windows.Forms.Button();
            this.button_Editar = new System.Windows.Forms.Button();
            this.label2_NumeroDeMicro = new System.Windows.Forms.Label();
            this.label11_ModeloNuevo = new System.Windows.Forms.Label();
            this.textBox_Modelo = new System.Windows.Forms.TextBox();
            this.label13_MarcaNuevo = new System.Windows.Forms.Label();
            this.comboBox_Marca = new System.Windows.Forms.ComboBox();
            this.textBox_Patente = new System.Windows.Forms.TextBox();
            this.textBox_NumeroMicro = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 54);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 46;
            this.label8.Text = "Patente";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 196);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 13);
            this.label6.TabIndex = 42;
            this.label6.Text = "Espacio Encomiendas (KG)";
            // 
            // textBox_KG
            // 
            this.textBox_KG.Enabled = false;
            this.textBox_KG.Location = new System.Drawing.Point(181, 193);
            this.textBox_KG.Name = "textBox_KG";
            this.textBox_KG.Size = new System.Drawing.Size(100, 20);
            this.textBox_KG.TabIndex = 41;
            // 
            // button_Guardar
            // 
            this.button_Guardar.Location = new System.Drawing.Point(253, 259);
            this.button_Guardar.Name = "button_Guardar";
            this.button_Guardar.Size = new System.Drawing.Size(75, 23);
            this.button_Guardar.TabIndex = 30;
            this.button_Guardar.Text = "Guardar";
            this.button_Guardar.UseVisualStyleBackColor = true;
            this.button_Guardar.Click += new System.EventHandler(this.button_Guardar_Click);
            // 
            // button_Cancelar
            // 
            this.button_Cancelar.Location = new System.Drawing.Point(24, 259);
            this.button_Cancelar.Name = "button_Cancelar";
            this.button_Cancelar.Size = new System.Drawing.Size(75, 23);
            this.button_Cancelar.TabIndex = 29;
            this.button_Cancelar.Text = "Limpiar";
            this.button_Cancelar.UseVisualStyleBackColor = true;
            this.button_Cancelar.Click += new System.EventHandler(this.button_Cancelar_Click);
            // 
            // button_Editar
            // 
            this.button_Editar.Location = new System.Drawing.Point(140, 259);
            this.button_Editar.Name = "button_Editar";
            this.button_Editar.Size = new System.Drawing.Size(75, 23);
            this.button_Editar.TabIndex = 53;
            this.button_Editar.Text = "Volver";
            this.button_Editar.UseVisualStyleBackColor = true;
            this.button_Editar.Click += new System.EventHandler(this.button_Editar_Click);
            // 
            // label2_NumeroDeMicro
            // 
            this.label2_NumeroDeMicro.AutoSize = true;
            this.label2_NumeroDeMicro.Location = new System.Drawing.Point(39, 158);
            this.label2_NumeroDeMicro.Name = "label2_NumeroDeMicro";
            this.label2_NumeroDeMicro.Size = new System.Drawing.Size(88, 13);
            this.label2_NumeroDeMicro.TabIndex = 66;
            this.label2_NumeroDeMicro.Text = "Numero de Micro";
            // 
            // label11_ModeloNuevo
            // 
            this.label11_ModeloNuevo.AutoSize = true;
            this.label11_ModeloNuevo.Location = new System.Drawing.Point(39, 121);
            this.label11_ModeloNuevo.Name = "label11_ModeloNuevo";
            this.label11_ModeloNuevo.Size = new System.Drawing.Size(42, 13);
            this.label11_ModeloNuevo.TabIndex = 59;
            this.label11_ModeloNuevo.Text = "Modelo";
            // 
            // textBox_Modelo
            // 
            this.textBox_Modelo.Location = new System.Drawing.Point(160, 118);
            this.textBox_Modelo.Name = "textBox_Modelo";
            this.textBox_Modelo.Size = new System.Drawing.Size(121, 20);
            this.textBox_Modelo.TabIndex = 58;
            // 
            // label13_MarcaNuevo
            // 
            this.label13_MarcaNuevo.AutoSize = true;
            this.label13_MarcaNuevo.Location = new System.Drawing.Point(39, 86);
            this.label13_MarcaNuevo.Name = "label13_MarcaNuevo";
            this.label13_MarcaNuevo.Size = new System.Drawing.Size(37, 13);
            this.label13_MarcaNuevo.TabIndex = 55;
            this.label13_MarcaNuevo.Text = "Marca";
            // 
            // comboBox_Marca
            // 
            this.comboBox_Marca.FormattingEnabled = true;
            this.comboBox_Marca.Location = new System.Drawing.Point(160, 86);
            this.comboBox_Marca.Name = "comboBox_Marca";
            this.comboBox_Marca.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Marca.TabIndex = 54;
            // 
            // textBox_Patente
            // 
            this.textBox_Patente.Enabled = false;
            this.textBox_Patente.Location = new System.Drawing.Point(160, 47);
            this.textBox_Patente.Name = "textBox_Patente";
            this.textBox_Patente.Size = new System.Drawing.Size(121, 20);
            this.textBox_Patente.TabIndex = 67;
            // 
            // textBox_NumeroMicro
            // 
            this.textBox_NumeroMicro.Enabled = false;
            this.textBox_NumeroMicro.Location = new System.Drawing.Point(160, 155);
            this.textBox_NumeroMicro.Name = "textBox_NumeroMicro";
            this.textBox_NumeroMicro.Size = new System.Drawing.Size(121, 20);
            this.textBox_NumeroMicro.TabIndex = 68;
            // 
            // Micro_Modificacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(350, 312);
            this.Controls.Add(this.textBox_NumeroMicro);
            this.Controls.Add(this.textBox_Patente);
            this.Controls.Add(this.label2_NumeroDeMicro);
            this.Controls.Add(this.label11_ModeloNuevo);
            this.Controls.Add(this.textBox_Modelo);
            this.Controls.Add(this.label13_MarcaNuevo);
            this.Controls.Add(this.comboBox_Marca);
            this.Controls.Add(this.button_Editar);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.textBox_KG);
            this.Controls.Add(this.button_Guardar);
            this.Controls.Add(this.button_Cancelar);
            this.Name = "Micro_Modificacion";
            this.Text = "Micro_Modificacion";
            this.Load += new System.EventHandler(this.Micro_Modificacion_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_KG;
        private System.Windows.Forms.Button button_Guardar;
        private System.Windows.Forms.Button button_Cancelar;
        private System.Windows.Forms.Button button_Editar;
        private System.Windows.Forms.Label label2_NumeroDeMicro;
        private System.Windows.Forms.Label label11_ModeloNuevo;
        private System.Windows.Forms.TextBox textBox_Modelo;
        private System.Windows.Forms.Label label13_MarcaNuevo;
        private System.Windows.Forms.ComboBox comboBox_Marca;
        private System.Windows.Forms.TextBox textBox_Patente;
        private System.Windows.Forms.TextBox textBox_NumeroMicro;

    }
}