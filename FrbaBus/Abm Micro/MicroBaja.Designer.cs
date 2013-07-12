namespace FrbaBus.Abm_Micro
{
    partial class MicroBaja
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
            this.comboBox_Patente = new System.Windows.Forms.ComboBox();
            this.label8 = new System.Windows.Forms.Label();
            this.textBox_FechaBaja = new System.Windows.Forms.TextBox();
            this.label_FechaBaja = new System.Windows.Forms.Label();
            this.button_DarDeBaja = new System.Windows.Forms.Button();
            this.label9_Comienzo = new System.Windows.Forms.Label();
            this.dateTimePicker_FechaBajaNuevaC = new System.Windows.Forms.DateTimePicker();
            this.label_Finaliza = new System.Windows.Forms.Label();
            this.dateTimePicker_FechaBajaNuevaF = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button_Confirmar = new System.Windows.Forms.Button();
            this.cancelarButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // comboBox_Patente
            // 
            this.comboBox_Patente.FormattingEnabled = true;
            this.comboBox_Patente.Location = new System.Drawing.Point(106, 33);
            this.comboBox_Patente.Name = "comboBox_Patente";
            this.comboBox_Patente.Size = new System.Drawing.Size(121, 21);
            this.comboBox_Patente.TabIndex = 54;
            this.comboBox_Patente.SelectedIndexChanged += new System.EventHandler(this.comboBox_Patente_SelectedIndexChanged);
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(34, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(44, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Patente";
            // 
            // textBox_FechaBaja
            // 
            this.textBox_FechaBaja.Location = new System.Drawing.Point(127, 75);
            this.textBox_FechaBaja.Name = "textBox_FechaBaja";
            this.textBox_FechaBaja.Size = new System.Drawing.Size(153, 20);
            this.textBox_FechaBaja.TabIndex = 72;
            // 
            // label_FechaBaja
            // 
            this.label_FechaBaja.AutoSize = true;
            this.label_FechaBaja.Location = new System.Drawing.Point(36, 78);
            this.label_FechaBaja.Name = "label_FechaBaja";
            this.label_FechaBaja.Size = new System.Drawing.Size(76, 13);
            this.label_FechaBaja.TabIndex = 71;
            this.label_FechaBaja.Text = "Fecha de Baja";
            // 
            // button_DarDeBaja
            // 
            this.button_DarDeBaja.Location = new System.Drawing.Point(297, 73);
            this.button_DarDeBaja.Name = "button_DarDeBaja";
            this.button_DarDeBaja.Size = new System.Drawing.Size(75, 23);
            this.button_DarDeBaja.TabIndex = 73;
            this.button_DarDeBaja.Text = "Dar Baja";
            this.button_DarDeBaja.UseVisualStyleBackColor = true;
            // 
            // label9_Comienzo
            // 
            this.label9_Comienzo.AutoSize = true;
            this.label9_Comienzo.Location = new System.Drawing.Point(38, 142);
            this.label9_Comienzo.Name = "label9_Comienzo";
            this.label9_Comienzo.Size = new System.Drawing.Size(53, 13);
            this.label9_Comienzo.TabIndex = 75;
            this.label9_Comienzo.Text = "Comienzo";
            this.label9_Comienzo.Visible = false;
            this.label9_Comienzo.Click += new System.EventHandler(this.label9_FechaDeBajaNuevo_Click);
            // 
            // dateTimePicker_FechaBajaNuevaC
            // 
            this.dateTimePicker_FechaBajaNuevaC.Location = new System.Drawing.Point(127, 138);
            this.dateTimePicker_FechaBajaNuevaC.Name = "dateTimePicker_FechaBajaNuevaC";
            this.dateTimePicker_FechaBajaNuevaC.Size = new System.Drawing.Size(153, 20);
            this.dateTimePicker_FechaBajaNuevaC.TabIndex = 74;
            this.dateTimePicker_FechaBajaNuevaC.Visible = false;
            this.dateTimePicker_FechaBajaNuevaC.ValueChanged += new System.EventHandler(this.dateTimePicker_FechaBajaNuevaC_ValueChanged);
            // 
            // label_Finaliza
            // 
            this.label_Finaliza.AutoSize = true;
            this.label_Finaliza.Location = new System.Drawing.Point(38, 177);
            this.label_Finaliza.Name = "label_Finaliza";
            this.label_Finaliza.Size = new System.Drawing.Size(42, 13);
            this.label_Finaliza.TabIndex = 77;
            this.label_Finaliza.Text = "Finaliza";
            this.label_Finaliza.Visible = false;
            // 
            // dateTimePicker_FechaBajaNuevaF
            // 
            this.dateTimePicker_FechaBajaNuevaF.Location = new System.Drawing.Point(127, 173);
            this.dateTimePicker_FechaBajaNuevaF.Name = "dateTimePicker_FechaBajaNuevaF";
            this.dateTimePicker_FechaBajaNuevaF.Size = new System.Drawing.Size(153, 20);
            this.dateTimePicker_FechaBajaNuevaF.TabIndex = 76;
            this.dateTimePicker_FechaBajaNuevaF.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Fuera de Servicio";
            this.label2.Visible = false;
            // 
            // button_Confirmar
            // 
            this.button_Confirmar.Location = new System.Drawing.Point(297, 153);
            this.button_Confirmar.Name = "button_Confirmar";
            this.button_Confirmar.Size = new System.Drawing.Size(75, 23);
            this.button_Confirmar.TabIndex = 79;
            this.button_Confirmar.Text = "Confirmar";
            this.button_Confirmar.UseVisualStyleBackColor = true;
            this.button_Confirmar.Click += new System.EventHandler(this.button_Confirmar_Click);
            // 
            // cancelarButton
            // 
            this.cancelarButton.Location = new System.Drawing.Point(152, 209);
            this.cancelarButton.Name = "cancelarButton";
            this.cancelarButton.Size = new System.Drawing.Size(75, 23);
            this.cancelarButton.TabIndex = 80;
            this.cancelarButton.Text = "Cancelar";
            this.cancelarButton.UseVisualStyleBackColor = true;
            this.cancelarButton.Click += new System.EventHandler(this.cancelarButton_Click);
            // 
            // MicroBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 244);
            this.Controls.Add(this.cancelarButton);
            this.Controls.Add(this.button_Confirmar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_Finaliza);
            this.Controls.Add(this.dateTimePicker_FechaBajaNuevaF);
            this.Controls.Add(this.label9_Comienzo);
            this.Controls.Add(this.dateTimePicker_FechaBajaNuevaC);
            this.Controls.Add(this.button_DarDeBaja);
            this.Controls.Add(this.textBox_FechaBaja);
            this.Controls.Add(this.label_FechaBaja);
            this.Controls.Add(this.comboBox_Patente);
            this.Controls.Add(this.label8);
            this.Name = "MicroBaja";
            this.Text = "Baja de Micros";
            this.Load += new System.EventHandler(this.MicroBaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox comboBox_Patente;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox textBox_FechaBaja;
        private System.Windows.Forms.Label label_FechaBaja;
        private System.Windows.Forms.Button button_DarDeBaja;
        private System.Windows.Forms.Label label9_Comienzo;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FechaBajaNuevaC;
        private System.Windows.Forms.Label label_Finaliza;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FechaBajaNuevaF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_Confirmar;
        private System.Windows.Forms.Button cancelarButton;
    }
}