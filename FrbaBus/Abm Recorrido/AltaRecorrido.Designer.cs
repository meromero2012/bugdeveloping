namespace FrbaBus.Abm_Recorrido
{
    partial class AltaRecorrido
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
            this.button_Aceptar = new System.Windows.Forms.Button();
            this.button_Volver = new System.Windows.Forms.Button();
            this.comboBox_CiudadOrigen = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_CiudadDestino = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBox_TipoServicio = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.textBox_PrecioKG = new System.Windows.Forms.TextBox();
            this.textBox_PrecioPasaje = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // button_Aceptar
            // 
            this.button_Aceptar.Location = new System.Drawing.Point(168, 192);
            this.button_Aceptar.Name = "button_Aceptar";
            this.button_Aceptar.Size = new System.Drawing.Size(75, 23);
            this.button_Aceptar.TabIndex = 0;
            this.button_Aceptar.Text = "Guardar";
            this.button_Aceptar.UseVisualStyleBackColor = true;
            this.button_Aceptar.Click += new System.EventHandler(this.button_Aceptar_Click);
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(49, 192);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(75, 23);
            this.button_Volver.TabIndex = 1;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // comboBox_CiudadOrigen
            // 
            this.comboBox_CiudadOrigen.FormattingEnabled = true;
            this.comboBox_CiudadOrigen.Location = new System.Drawing.Point(142, 50);
            this.comboBox_CiudadOrigen.Name = "comboBox_CiudadOrigen";
            this.comboBox_CiudadOrigen.Size = new System.Drawing.Size(101, 21);
            this.comboBox_CiudadOrigen.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(25, 53);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Ciudad Origen";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(25, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "Ciudad Destino";
            // 
            // comboBox_CiudadDestino
            // 
            this.comboBox_CiudadDestino.FormattingEnabled = true;
            this.comboBox_CiudadDestino.Location = new System.Drawing.Point(142, 86);
            this.comboBox_CiudadDestino.Name = "comboBox_CiudadDestino";
            this.comboBox_CiudadDestino.Size = new System.Drawing.Size(101, 21);
            this.comboBox_CiudadDestino.TabIndex = 7;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(25, 128);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(55, 13);
            this.label4.TabIndex = 8;
            this.label4.Text = "Precio KG";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(25, 154);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 13);
            this.label5.TabIndex = 9;
            this.label5.Text = "Precio Pasaje";
            // 
            // comboBox_TipoServicio
            // 
            this.comboBox_TipoServicio.FormattingEnabled = true;
            this.comboBox_TipoServicio.Location = new System.Drawing.Point(142, 19);
            this.comboBox_TipoServicio.Name = "comboBox_TipoServicio";
            this.comboBox_TipoServicio.Size = new System.Drawing.Size(101, 21);
            this.comboBox_TipoServicio.TabIndex = 10;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(25, 22);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 13);
            this.label6.TabIndex = 11;
            this.label6.Text = "Tipo Servicio";
            // 
            // textBox_PrecioKG
            // 
            this.textBox_PrecioKG.Location = new System.Drawing.Point(142, 125);
            this.textBox_PrecioKG.Name = "textBox_PrecioKG";
            this.textBox_PrecioKG.Size = new System.Drawing.Size(101, 20);
            this.textBox_PrecioKG.TabIndex = 12;
            // 
            // textBox_PrecioPasaje
            // 
            this.textBox_PrecioPasaje.Location = new System.Drawing.Point(142, 151);
            this.textBox_PrecioPasaje.Name = "textBox_PrecioPasaje";
            this.textBox_PrecioPasaje.Size = new System.Drawing.Size(101, 20);
            this.textBox_PrecioPasaje.TabIndex = 13;
            // 
            // AltaRecorrido
            // 
            this.ClientSize = new System.Drawing.Size(271, 236);
            this.Controls.Add(this.textBox_PrecioPasaje);
            this.Controls.Add(this.textBox_PrecioKG);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.comboBox_TipoServicio);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_CiudadDestino);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboBox_CiudadOrigen);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.button_Aceptar);
            this.Name = "AltaRecorrido";
            this.Text = "Alta Recorrido";
            this.Load += new System.EventHandler(this.AltaRecorrido_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button_Aceptar;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.ComboBox comboBox_CiudadOrigen;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_CiudadDestino;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBox_TipoServicio;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox textBox_PrecioKG;
        private System.Windows.Forms.TextBox textBox_PrecioPasaje;

      }
}