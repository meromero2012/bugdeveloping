namespace FrbaBus.Consulta_Puntos_Adquiridos
{
    partial class ConsultaPuntos
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cantidadLabel = new System.Windows.Forms.Label();
            this.puntosLabel = new System.Windows.Forms.Label();
            this.volverButton = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bFiltrar = new System.Windows.Forms.Button();
            this.txtbDNI = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cantidadLabel);
            this.groupBox1.Controls.Add(this.puntosLabel);
            this.groupBox1.Controls.Add(this.volverButton);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bFiltrar);
            this.groupBox1.Controls.Add(this.txtbDNI);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(471, 126);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ingrese su DNI:";
            // 
            // cantidadLabel
            // 
            this.cantidadLabel.AutoSize = true;
            this.cantidadLabel.Location = new System.Drawing.Point(181, 60);
            this.cantidadLabel.Name = "cantidadLabel";
            this.cantidadLabel.Size = new System.Drawing.Size(0, 13);
            this.cantidadLabel.TabIndex = 37;
            // 
            // puntosLabel
            // 
            this.puntosLabel.AutoSize = true;
            this.puntosLabel.Location = new System.Drawing.Point(71, 60);
            this.puntosLabel.Name = "puntosLabel";
            this.puntosLabel.Size = new System.Drawing.Size(103, 13);
            this.puntosLabel.TabIndex = 36;
            this.puntosLabel.Text = "Puntos acumulados:";
            // 
            // volverButton
            // 
            this.volverButton.Location = new System.Drawing.Point(191, 90);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(108, 26);
            this.volverButton.TabIndex = 35;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "DNI";
            // 
            // bFiltrar
            // 
            this.bFiltrar.Location = new System.Drawing.Point(74, 90);
            this.bFiltrar.Name = "bFiltrar";
            this.bFiltrar.Size = new System.Drawing.Size(111, 26);
            this.bFiltrar.TabIndex = 27;
            this.bFiltrar.Text = "Buscar";
            this.bFiltrar.UseVisualStyleBackColor = true;
            this.bFiltrar.Click += new System.EventHandler(this.bFiltrar_Click);
            // 
            // txtbDNI
            // 
            this.txtbDNI.Location = new System.Drawing.Point(74, 27);
            this.txtbDNI.Name = "txtbDNI";
            this.txtbDNI.Size = new System.Drawing.Size(384, 20);
            this.txtbDNI.TabIndex = 25;
            this.txtbDNI.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // ConsultaPuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(492, 145);
            this.Controls.Add(this.groupBox1);
            this.Name = "ConsultaPuntos";
            this.Text = "Consulta de Puntos Acumulados";
            this.Load += new System.EventHandler(this.FormFiltrarRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bFiltrar;
        private System.Windows.Forms.TextBox txtbDNI;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Label puntosLabel;
        private System.Windows.Forms.Label cantidadLabel;
    }
}