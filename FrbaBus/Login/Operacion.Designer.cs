namespace FrbaBus.Login
{
    partial class Operacion
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
            this.clienteRadioButton = new System.Windows.Forms.RadioButton();
            this.usuarioRegistradoRadioButton = new System.Windows.Forms.RadioButton();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.continuarButton = new System.Windows.Forms.Button();
            this.salirButton = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // clienteRadioButton
            // 
            this.clienteRadioButton.AutoSize = true;
            this.clienteRadioButton.Location = new System.Drawing.Point(6, 21);
            this.clienteRadioButton.Name = "clienteRadioButton";
            this.clienteRadioButton.Size = new System.Drawing.Size(57, 17);
            this.clienteRadioButton.TabIndex = 0;
            this.clienteRadioButton.TabStop = true;
            this.clienteRadioButton.Text = "Cliente";
            this.clienteRadioButton.UseVisualStyleBackColor = true;
            // 
            // usuarioRegistradoRadioButton
            // 
            this.usuarioRegistradoRadioButton.AutoSize = true;
            this.usuarioRegistradoRadioButton.Location = new System.Drawing.Point(6, 44);
            this.usuarioRegistradoRadioButton.Name = "usuarioRegistradoRadioButton";
            this.usuarioRegistradoRadioButton.Size = new System.Drawing.Size(115, 17);
            this.usuarioRegistradoRadioButton.TabIndex = 1;
            this.usuarioRegistradoRadioButton.TabStop = true;
            this.usuarioRegistradoRadioButton.Text = "Usuario Registrado";
            this.usuarioRegistradoRadioButton.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.clienteRadioButton);
            this.groupBox1.Controls.Add(this.usuarioRegistradoRadioButton);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(127, 67);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Elija el tipo de usuario";
            // 
            // continuarButton
            // 
            this.continuarButton.Location = new System.Drawing.Point(145, 12);
            this.continuarButton.Name = "continuarButton";
            this.continuarButton.Size = new System.Drawing.Size(75, 23);
            this.continuarButton.TabIndex = 3;
            this.continuarButton.Text = "Continuar";
            this.continuarButton.UseVisualStyleBackColor = true;
            this.continuarButton.Click += new System.EventHandler(this.continuarButton_Click);
            // 
            // salirButton
            // 
            this.salirButton.Location = new System.Drawing.Point(146, 55);
            this.salirButton.Name = "salirButton";
            this.salirButton.Size = new System.Drawing.Size(75, 23);
            this.salirButton.TabIndex = 4;
            this.salirButton.Text = "Salir";
            this.salirButton.UseVisualStyleBackColor = true;
            this.salirButton.Click += new System.EventHandler(this.salirButton_Click);
            // 
            // Operacion
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(231, 87);
            this.Controls.Add(this.salirButton);
            this.Controls.Add(this.continuarButton);
            this.Controls.Add(this.groupBox1);
            this.Name = "Operacion";
            this.Text = "Usuarios";
            this.Load += new System.EventHandler(this.Operacion_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.RadioButton clienteRadioButton;
        private System.Windows.Forms.RadioButton usuarioRegistradoRadioButton;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button continuarButton;
        private System.Windows.Forms.Button salirButton;
    }
}