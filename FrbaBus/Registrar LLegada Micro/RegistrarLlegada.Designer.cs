namespace FrbaBus.Registrar_LLegada_Micro
{
    partial class RegistrarLlegada
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
            this.dateTimePicker_fechaLlegada = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox_Micro = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox_Origen = new System.Windows.Forms.ComboBox();
            this.comboBox_Arribo = new System.Windows.Forms.ComboBox();
            this.button4 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 24);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(93, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Fecha de Llegada";
            // 
            // dateTimePicker_fechaLlegada
            // 
            this.dateTimePicker_fechaLlegada.Location = new System.Drawing.Point(111, 20);
            this.dateTimePicker_fechaLlegada.Name = "dateTimePicker_fechaLlegada";
            this.dateTimePicker_fechaLlegada.Size = new System.Drawing.Size(200, 20);
            this.dateTimePicker_fechaLlegada.TabIndex = 1;
            this.dateTimePicker_fechaLlegada.ValueChanged += new System.EventHandler(this.dateTimePicker1_ValueChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(12, 60);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 13);
            this.label4.TabIndex = 20;
            this.label4.Text = "Seleccionar Micro";
            // 
            // comboBox_Micro
            // 
            this.comboBox_Micro.FormattingEnabled = true;
            this.comboBox_Micro.Location = new System.Drawing.Point(111, 57);
            this.comboBox_Micro.Name = "comboBox_Micro";
            this.comboBox_Micro.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Micro.TabIndex = 21;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(64, 13);
            this.label2.TabIndex = 22;
            this.label2.Text = "Proviene de";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 23;
            this.label3.Text = "Arribo a";
            // 
            // comboBox_Origen
            // 
            this.comboBox_Origen.FormattingEnabled = true;
            this.comboBox_Origen.Location = new System.Drawing.Point(111, 93);
            this.comboBox_Origen.Name = "comboBox_Origen";
            this.comboBox_Origen.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Origen.TabIndex = 24;
            this.comboBox_Origen.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // comboBox_Arribo
            // 
            this.comboBox_Arribo.FormattingEnabled = true;
            this.comboBox_Arribo.Location = new System.Drawing.Point(111, 128);
            this.comboBox_Arribo.Name = "comboBox_Arribo";
            this.comboBox_Arribo.Size = new System.Drawing.Size(100, 21);
            this.comboBox_Arribo.TabIndex = 25;
            this.comboBox_Arribo.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(123, 168);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(75, 23);
            this.button4.TabIndex = 29;
            this.button4.Text = "Limpiar";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.buttonLimpiar_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(219, 168);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 28;
            this.button2.Text = "Volver";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(26, 168);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(75, 23);
            this.button3.TabIndex = 27;
            this.button3.Text = "Confirmar";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.buttonConfirmar_Click);
            // 
            // RegistrarLlegada
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(334, 204);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.comboBox_Arribo);
            this.Controls.Add(this.comboBox_Origen);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboBox_Micro);
            this.Controls.Add(this.dateTimePicker_fechaLlegada);
            this.Controls.Add(this.label1);
            this.Name = "RegistrarLlegada";
            this.Text = "Registrar Llegada";
            this.Load += new System.EventHandler(this.RegistrarLlegada2_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dateTimePicker_fechaLlegada;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox_Micro;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox_Origen;
        private System.Windows.Forms.ComboBox comboBox_Arribo;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
    }
}