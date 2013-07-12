namespace FrbaBus.Abm_Permisos
{
    partial class FormModifRol
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
            this.clbFuncionalidades = new System.Windows.Forms.CheckedListBox();
            this.cbActivo = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.bLimpiar = new System.Windows.Forms.Button();
            this.bModificar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.txtbNombre = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(20, 60);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 13);
            this.label1.TabIndex = 43;
            this.label1.Text = "Funcionalidades:";
            // 
            // clbFuncionalidades
            // 
            this.clbFuncionalidades.CheckOnClick = true;
            this.clbFuncionalidades.FormattingEnabled = true;
            this.clbFuncionalidades.Location = new System.Drawing.Point(113, 60);
            this.clbFuncionalidades.Name = "clbFuncionalidades";
            this.clbFuncionalidades.Size = new System.Drawing.Size(163, 169);
            this.clbFuncionalidades.Sorted = true;
            this.clbFuncionalidades.TabIndex = 42;
            // 
            // cbActivo
            // 
            this.cbActivo.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbActivo.FormattingEnabled = true;
            this.cbActivo.Items.AddRange(new object[] {
            "Activo",
            "Desactivado"});
            this.cbActivo.Location = new System.Drawing.Point(113, 245);
            this.cbActivo.Name = "cbActivo";
            this.cbActivo.Size = new System.Drawing.Size(163, 21);
            this.cbActivo.TabIndex = 38;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(20, 245);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 13);
            this.label6.TabIndex = 41;
            this.label6.Text = "Estado Lógico";
            // 
            // bLimpiar
            // 
            this.bLimpiar.Location = new System.Drawing.Point(23, 291);
            this.bLimpiar.Name = "bLimpiar";
            this.bLimpiar.Size = new System.Drawing.Size(117, 26);
            this.bLimpiar.TabIndex = 39;
            this.bLimpiar.Text = "Limpiar";
            this.bLimpiar.UseVisualStyleBackColor = true;
            this.bLimpiar.Click += new System.EventHandler(this.bLimpiar_Click);
            // 
            // bModificar
            // 
            this.bModificar.Location = new System.Drawing.Point(159, 291);
            this.bModificar.Name = "bModificar";
            this.bModificar.Size = new System.Drawing.Size(117, 26);
            this.bModificar.TabIndex = 40;
            this.bModificar.Text = "Modificar";
            this.bModificar.UseVisualStyleBackColor = true;
            this.bModificar.Click += new System.EventHandler(this.bModificar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(20, 19);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 37;
            this.label2.Text = "Nombre";
            // 
            // txtbNombre
            // 
            this.txtbNombre.Location = new System.Drawing.Point(112, 19);
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.Size = new System.Drawing.Size(164, 20);
            this.txtbNombre.TabIndex = 36;
            // 
            // FormModifRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 325);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.clbFuncionalidades);
            this.Controls.Add(this.cbActivo);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bLimpiar);
            this.Controls.Add(this.bModificar);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtbNombre);
            this.Name = "FormModifRol";
            this.Text = "Modificar Rol";
            this.Load += new System.EventHandler(this.FormModifRol_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.CheckedListBox clbFuncionalidades;
        private System.Windows.Forms.ComboBox cbActivo;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button bLimpiar;
        private System.Windows.Forms.Button bModificar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtbNombre;
    }
}