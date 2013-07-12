namespace FrbaBus.DateSystem
{
    partial class ConfiguracionFecha
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
            this.anioLabel = new System.Windows.Forms.Label();
            this.anioTextBox = new System.Windows.Forms.TextBox();
            this.mesLabel = new System.Windows.Forms.Label();
            this.mesTextBox = new System.Windows.Forms.TextBox();
            this.diaLabel = new System.Windows.Forms.Label();
            this.diaTextBox = new System.Windows.Forms.TextBox();
            this.tituloLabel = new System.Windows.Forms.Label();
            this.siguienteButton = new System.Windows.Forms.Button();
            this.salirButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // anioLabel
            // 
            this.anioLabel.AutoSize = true;
            this.anioLabel.Location = new System.Drawing.Point(12, 39);
            this.anioLabel.Name = "anioLabel";
            this.anioLabel.Size = new System.Drawing.Size(63, 13);
            this.anioLabel.TabIndex = 0;
            this.anioLabel.Text = "Año (AAAA)";
            // 
            // anioTextBox
            // 
            this.anioTextBox.Location = new System.Drawing.Point(80, 36);
            this.anioTextBox.Name = "anioTextBox";
            this.anioTextBox.Size = new System.Drawing.Size(100, 20);
            this.anioTextBox.TabIndex = 1;
            this.anioTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // mesLabel
            // 
            this.mesLabel.AutoSize = true;
            this.mesLabel.Location = new System.Drawing.Point(12, 71);
            this.mesLabel.Name = "mesLabel";
            this.mesLabel.Size = new System.Drawing.Size(54, 13);
            this.mesLabel.TabIndex = 2;
            this.mesLabel.Text = "Mes (MM)";
            // 
            // mesTextBox
            // 
            this.mesTextBox.Location = new System.Drawing.Point(80, 71);
            this.mesTextBox.Name = "mesTextBox";
            this.mesTextBox.Size = new System.Drawing.Size(100, 20);
            this.mesTextBox.TabIndex = 3;
            this.mesTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // diaLabel
            // 
            this.diaLabel.AutoSize = true;
            this.diaLabel.Location = new System.Drawing.Point(15, 108);
            this.diaLabel.Name = "diaLabel";
            this.diaLabel.Size = new System.Drawing.Size(50, 13);
            this.diaLabel.TabIndex = 4;
            this.diaLabel.Text = "Día (DD)";
            // 
            // diaTextBox
            // 
            this.diaTextBox.Location = new System.Drawing.Point(80, 105);
            this.diaTextBox.Name = "diaTextBox";
            this.diaTextBox.Size = new System.Drawing.Size(100, 20);
            this.diaTextBox.TabIndex = 5;
            this.diaTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // tituloLabel
            // 
            this.tituloLabel.AutoSize = true;
            this.tituloLabel.Location = new System.Drawing.Point(12, 9);
            this.tituloLabel.Name = "tituloLabel";
            this.tituloLabel.Size = new System.Drawing.Size(206, 13);
            this.tituloLabel.TabIndex = 6;
            this.tituloLabel.Text = "Ingrese la hora del sistema para continuar:";
            // 
            // siguienteButton
            // 
            this.siguienteButton.Location = new System.Drawing.Point(33, 139);
            this.siguienteButton.Name = "siguienteButton";
            this.siguienteButton.Size = new System.Drawing.Size(75, 23);
            this.siguienteButton.TabIndex = 7;
            this.siguienteButton.Text = "Siguiente";
            this.siguienteButton.UseVisualStyleBackColor = true;
            this.siguienteButton.Click += new System.EventHandler(this.siguienteButton_Click);
            // 
            // salirButton
            // 
            this.salirButton.Location = new System.Drawing.Point(114, 139);
            this.salirButton.Name = "salirButton";
            this.salirButton.Size = new System.Drawing.Size(75, 23);
            this.salirButton.TabIndex = 8;
            this.salirButton.Text = "Salir";
            this.salirButton.UseVisualStyleBackColor = true;
            this.salirButton.Click += new System.EventHandler(this.salirButton_Click);
            // 
            // ConfiguracionFecha
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(233, 174);
            this.Controls.Add(this.salirButton);
            this.Controls.Add(this.siguienteButton);
            this.Controls.Add(this.tituloLabel);
            this.Controls.Add(this.diaTextBox);
            this.Controls.Add(this.diaLabel);
            this.Controls.Add(this.mesTextBox);
            this.Controls.Add(this.mesLabel);
            this.Controls.Add(this.anioTextBox);
            this.Controls.Add(this.anioLabel);
            this.Name = "ConfiguracionFecha";
            this.Text = "Reloj del Sistema";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label anioLabel;
        private System.Windows.Forms.TextBox anioTextBox;
        private System.Windows.Forms.Label mesLabel;
        private System.Windows.Forms.TextBox mesTextBox;
        private System.Windows.Forms.Label diaLabel;
        private System.Windows.Forms.TextBox diaTextBox;
        private System.Windows.Forms.Label tituloLabel;
        private System.Windows.Forms.Button siguienteButton;
        private System.Windows.Forms.Button salirButton;

    }
}

