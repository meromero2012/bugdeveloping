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
            this.label8 = new System.Windows.Forms.Label();
            this.label9_Comienzo = new System.Windows.Forms.Label();
            this.dateTimePicker_FechaBajaNuevaC = new System.Windows.Forms.DateTimePicker();
            this.label_Finaliza = new System.Windows.Forms.Label();
            this.dateTimePicker_FechaBajaNuevaF = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.button_MandarAServicio = new System.Windows.Forms.Button();
            this.label_Patente = new System.Windows.Forms.Label();
            this.button_Volver = new System.Windows.Forms.Button();
            this.button_baja = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(43, 38);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(47, 13);
            this.label8.TabIndex = 53;
            this.label8.Text = "Patente:";
            // 
            // label9_Comienzo
            // 
            this.label9_Comienzo.AutoSize = true;
            this.label9_Comienzo.Location = new System.Drawing.Point(38, 142);
            this.label9_Comienzo.Name = "label9_Comienzo";
            this.label9_Comienzo.Size = new System.Drawing.Size(36, 13);
            this.label9_Comienzo.TabIndex = 75;
            this.label9_Comienzo.Text = "Salida";
            // 
            // dateTimePicker_FechaBajaNuevaC
            // 
            this.dateTimePicker_FechaBajaNuevaC.Location = new System.Drawing.Point(127, 138);
            this.dateTimePicker_FechaBajaNuevaC.Name = "dateTimePicker_FechaBajaNuevaC";
            this.dateTimePicker_FechaBajaNuevaC.Size = new System.Drawing.Size(153, 20);
            this.dateTimePicker_FechaBajaNuevaC.TabIndex = 74;
            // 
            // label_Finaliza
            // 
            this.label_Finaliza.AutoSize = true;
            this.label_Finaliza.Location = new System.Drawing.Point(38, 177);
            this.label_Finaliza.Name = "label_Finaliza";
            this.label_Finaliza.Size = new System.Drawing.Size(85, 13);
            this.label_Finaliza.TabIndex = 77;
            this.label_Finaliza.Text = "Reincorporacion";
            // 
            // dateTimePicker_FechaBajaNuevaF
            // 
            this.dateTimePicker_FechaBajaNuevaF.Location = new System.Drawing.Point(127, 173);
            this.dateTimePicker_FechaBajaNuevaF.Name = "dateTimePicker_FechaBajaNuevaF";
            this.dateTimePicker_FechaBajaNuevaF.Size = new System.Drawing.Size(153, 20);
            this.dateTimePicker_FechaBajaNuevaF.TabIndex = 76;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(38, 113);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(90, 13);
            this.label2.TabIndex = 78;
            this.label2.Text = "Fuera de Servicio";
            // 
            // button_MandarAServicio
            // 
            this.button_MandarAServicio.Location = new System.Drawing.Point(41, 210);
            this.button_MandarAServicio.Name = "button_MandarAServicio";
            this.button_MandarAServicio.Size = new System.Drawing.Size(114, 26);
            this.button_MandarAServicio.TabIndex = 79;
            this.button_MandarAServicio.Text = "Mandar A servicio";
            this.button_MandarAServicio.UseVisualStyleBackColor = true;
            this.button_MandarAServicio.Click += new System.EventHandler(this.button_Confirmar_Click);
            // 
            // label_Patente
            // 
            this.label_Patente.AutoSize = true;
            this.label_Patente.Location = new System.Drawing.Point(124, 38);
            this.label_Patente.Name = "label_Patente";
            this.label_Patente.Size = new System.Drawing.Size(40, 13);
            this.label_Patente.TabIndex = 80;
            this.label_Patente.Text = "Codigo";
            // 
            // button_Volver
            // 
            this.button_Volver.Location = new System.Drawing.Point(41, 253);
            this.button_Volver.Name = "button_Volver";
            this.button_Volver.Size = new System.Drawing.Size(114, 26);
            this.button_Volver.TabIndex = 81;
            this.button_Volver.Text = "Volver";
            this.button_Volver.UseVisualStyleBackColor = true;
            this.button_Volver.Click += new System.EventHandler(this.button_Volver_Click);
            // 
            // button_baja
            // 
            this.button_baja.Location = new System.Drawing.Point(41, 68);
            this.button_baja.Name = "button_baja";
            this.button_baja.Size = new System.Drawing.Size(114, 23);
            this.button_baja.TabIndex = 82;
            this.button_baja.Text = "Dar de Baja";
            this.button_baja.UseVisualStyleBackColor = true;
            this.button_baja.Click += new System.EventHandler(this.button_baja_Click);
            // 
            // MicroBaja
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(304, 291);
            this.Controls.Add(this.button_baja);
            this.Controls.Add(this.button_Volver);
            this.Controls.Add(this.label_Patente);
            this.Controls.Add(this.button_MandarAServicio);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label_Finaliza);
            this.Controls.Add(this.dateTimePicker_FechaBajaNuevaF);
            this.Controls.Add(this.label9_Comienzo);
            this.Controls.Add(this.dateTimePicker_FechaBajaNuevaC);
            this.Controls.Add(this.label8);
            this.Name = "MicroBaja";
            this.Text = "Baja Micro";
            this.Load += new System.EventHandler(this.MicroBaja_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9_Comienzo;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FechaBajaNuevaC;
        private System.Windows.Forms.Label label_Finaliza;
        private System.Windows.Forms.DateTimePicker dateTimePicker_FechaBajaNuevaF;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button_MandarAServicio;
        private System.Windows.Forms.Label label_Patente;
        private System.Windows.Forms.Button button_Volver;
        private System.Windows.Forms.Button button_baja;
    }
}