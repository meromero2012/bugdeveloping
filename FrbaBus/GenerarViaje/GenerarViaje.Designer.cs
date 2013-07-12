namespace FrbaBus.GenerarViaje
{
    partial class GenerarViaje
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
            this.label1 = new System.Windows.Forms.Label();
            this.textBox_numeroRecorrido = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.dateTimePicker_fechaLlegadaEstimada = new System.Windows.Forms.DateTimePicker();
            this.dateTimePicker_fechaSalida = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.textBox_numeroPatenteMicro = new System.Windows.Forms.TextBox();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Numero de Recorrido";
            // 
            // textBox_numeroRecorrido
            // 
            this.textBox_numeroRecorrido.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox_numeroRecorrido.Enabled = false;
            this.textBox_numeroRecorrido.Location = new System.Drawing.Point(126, 21);
            this.textBox_numeroRecorrido.Name = "textBox_numeroRecorrido";
            this.textBox_numeroRecorrido.Size = new System.Drawing.Size(100, 20);
            this.textBox_numeroRecorrido.TabIndex = 1;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(247, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 2;
            this.button1.Text = "Seleccionar";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.buttonSeleccionarRecorrido_Click);
            // 
            // dateTimePicker_fechaLlegadaEstimada
            // 
            this.dateTimePicker_fechaLlegadaEstimada.Location = new System.Drawing.Point(142, 123);
            this.dateTimePicker_fechaLlegadaEstimada.Name = "dateTimePicker_fechaLlegadaEstimada";
            this.dateTimePicker_fechaLlegadaEstimada.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_fechaLlegadaEstimada.TabIndex = 23;
            this.dateTimePicker_fechaLlegadaEstimada.ValueChanged += new System.EventHandler(this.dateTimePicker_fechaLlegadaEstimada_ValueChanged);
            // 
            // dateTimePicker_fechaSalida
            // 
            this.dateTimePicker_fechaSalida.Location = new System.Drawing.Point(96, 91);
            this.dateTimePicker_fechaSalida.Name = "dateTimePicker_fechaSalida";
            this.dateTimePicker_fechaSalida.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_fechaSalida.TabIndex = 22;
            this.dateTimePicker_fechaSalida.ValueChanged += new System.EventHandler(this.dateTimePicker_fechaSalida_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(12, 127);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(124, 13);
            this.label7.TabIndex = 21;
            this.label7.Text = "Fecha Llegada Estimada";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(12, 95);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 20;
            this.label5.Text = "Fecha Salida";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 58);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Seleccionar Micro";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(238, 170);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 25;
            this.button2.Text = "Cancelar";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(45, 170);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 24;
            this.button3.Text = "Confirmar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(142, 170);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 26;
            this.button4.Text = "Limpiar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // textBox_numeroPatenteMicro
            // 
            this.textBox_numeroPatenteMicro.BackColor = System.Drawing.SystemColors.InactiveCaption;
            this.textBox_numeroPatenteMicro.Enabled = false;
            this.textBox_numeroPatenteMicro.Location = new System.Drawing.Point(126, 55);
            this.textBox_numeroPatenteMicro.Name = "textBox_numeroPatenteMicro";
            this.textBox_numeroPatenteMicro.Size = new System.Drawing.Size(100, 20);
            this.textBox_numeroPatenteMicro.TabIndex = 27;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(247, 53);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(75, 23);
            this.button5.TabIndex = 28;
            this.button5.Text = "Seleccionar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.buttonSeleccionarMicro_Click);
            // 
            // GenerarViaje
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(376, 205);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textBox_numeroPatenteMicro);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.dateTimePicker_fechaLlegadaEstimada);
            this.Controls.Add(this.dateTimePicker_fechaSalida);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.textBox_numeroRecorrido);
            this.Controls.Add(this.label1);
            this.Name = "GenerarViaje";
            this.Text = "Generar Viaje";
            this.Load += new System.EventHandler(this.GenerarViaje_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox_numeroRecorrido;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaLlegadaEstimada;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaSalida;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.TextBox textBox_numeroPatenteMicro;
        private System.Windows.Forms.Button button5;
    }
}