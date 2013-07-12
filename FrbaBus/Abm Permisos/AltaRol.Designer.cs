namespace FrbaBus.Abm_Permisos
{
    partial class AltaRol
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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.textBoxNombreRol = new System.Windows.Forms.TextBox();
            this.checkedListBoxFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.botonAgregarRol = new System.Windows.Forms.Button();
            this.botonLimpiarSeleccion = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Nombre:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(13, 68);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(87, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Funcionalidades:";
            // 
            // textBoxNombreRol
            // 
            this.textBoxNombreRol.Location = new System.Drawing.Point(128, 18);
            this.textBoxNombreRol.Name = "textBoxNombreRol";
            this.textBoxNombreRol.Size = new System.Drawing.Size(147, 20);
            this.textBoxNombreRol.TabIndex = 2;
            // 
            // checkedListBoxFuncionalidades
            // 
            this.checkedListBoxFuncionalidades.FormattingEnabled = true;
            this.checkedListBoxFuncionalidades.Location = new System.Drawing.Point(128, 68);
            this.checkedListBoxFuncionalidades.Name = "checkedListBoxFuncionalidades";
            this.checkedListBoxFuncionalidades.Size = new System.Drawing.Size(147, 139);
            this.checkedListBoxFuncionalidades.TabIndex = 3;
            // 
            // botonAgregarRol
            // 
            this.botonAgregarRol.Location = new System.Drawing.Point(16, 223);
            this.botonAgregarRol.Name = "botonAgregarRol";
            this.botonAgregarRol.Size = new System.Drawing.Size(112, 31);
            this.botonAgregarRol.TabIndex = 4;
            this.botonAgregarRol.Text = "Agregar Rol";
            this.botonAgregarRol.UseVisualStyleBackColor = true;
            this.botonAgregarRol.Click += new System.EventHandler(this.buttonAgregarRol);
            // 
            // botonLimpiarSeleccion
            // 
            this.botonLimpiarSeleccion.Location = new System.Drawing.Point(148, 220);
            this.botonLimpiarSeleccion.Name = "botonLimpiarSeleccion";
            this.botonLimpiarSeleccion.Size = new System.Drawing.Size(109, 34);
            this.botonLimpiarSeleccion.TabIndex = 5;
            this.botonLimpiarSeleccion.Text = "Limpiar Selección";
            this.botonLimpiarSeleccion.UseVisualStyleBackColor = true;
            this.botonLimpiarSeleccion.Click += new System.EventHandler(this.buttonLimpiarSeleccion);
            // 
            // AltaRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(292, 273);
            this.Controls.Add(this.botonLimpiarSeleccion);
            this.Controls.Add(this.botonAgregarRol);
            this.Controls.Add(this.checkedListBoxFuncionalidades);
            this.Controls.Add(this.textBoxNombreRol);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "AltaRol";
            this.Text = "Agregar Rol";
            this.Load += new System.EventHandler(this.FormAbmRolLoad);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBoxNombreRol;
        private System.Windows.Forms.CheckedListBox checkedListBoxFuncionalidades;
        private System.Windows.Forms.Button botonAgregarRol;
        private System.Windows.Forms.Button botonLimpiarSeleccion;
    }
}