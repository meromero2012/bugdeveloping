namespace FrbaBus.Abm_Permisos
{
    partial class FiltrarRol
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
            this.label2 = new System.Windows.Forms.Label();
            this.bFiltrar = new System.Windows.Forms.Button();
            this.txtbNombre = new System.Windows.Forms.TextBox();
            this.bLimpiar = new System.Windows.Forms.Button();
            this.dgvRoles = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.bFiltrar);
            this.groupBox1.Controls.Add(this.txtbNombre);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(403, 88);
            this.groupBox1.TabIndex = 34;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Filtro de Búsqueda:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 27);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 26;
            this.label2.Text = "Nombre";
            // 
            // bFiltrar
            // 
            this.bFiltrar.Location = new System.Drawing.Point(270, 56);
            this.bFiltrar.Name = "bFiltrar";
            this.bFiltrar.Size = new System.Drawing.Size(117, 26);
            this.bFiltrar.TabIndex = 27;
            this.bFiltrar.Text = "Filtrar";
            this.bFiltrar.UseVisualStyleBackColor = true;
            this.bFiltrar.Click += new System.EventHandler(this.bFiltrar_Click);
            // 
            // txtbNombre
            // 
            this.txtbNombre.Location = new System.Drawing.Point(74, 27);
            this.txtbNombre.Name = "txtbNombre";
            this.txtbNombre.Size = new System.Drawing.Size(313, 20);
            this.txtbNombre.TabIndex = 25;
            // 
            // bLimpiar
            // 
            this.bLimpiar.Location = new System.Drawing.Point(298, 310);
            this.bLimpiar.Name = "bLimpiar";
            this.bLimpiar.Size = new System.Drawing.Size(117, 26);
            this.bLimpiar.TabIndex = 32;
            this.bLimpiar.Text = "Limpiar";
            this.bLimpiar.UseVisualStyleBackColor = true;
            this.bLimpiar.Click += new System.EventHandler(this.bLimpiar_Click);
            // 
            // dgvRoles
            // 
            this.dgvRoles.AllowUserToAddRows = false;
            this.dgvRoles.AllowUserToDeleteRows = false;
            this.dgvRoles.AllowUserToResizeColumns = false;
            this.dgvRoles.AllowUserToResizeRows = false;
            this.dgvRoles.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.dgvRoles.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.dgvRoles.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvRoles.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.dgvRoles.Enabled = false;
            this.dgvRoles.Location = new System.Drawing.Point(12, 115);
            this.dgvRoles.MultiSelect = false;
            this.dgvRoles.Name = "dgvRoles";
            this.dgvRoles.ReadOnly = true;
            this.dgvRoles.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.dgvRoles.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.dgvRoles.Size = new System.Drawing.Size(403, 189);
            this.dgvRoles.TabIndex = 33;
            this.dgvRoles.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 69;
            // 
            // FiltrarRol
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 358);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bLimpiar);
            this.Controls.Add(this.dgvRoles);
            this.Name = "FiltrarRol";
            this.Text = "Filtrar Rol";
            this.Load += new System.EventHandler(this.FormFiltrarRol_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvRoles)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button bFiltrar;
        private System.Windows.Forms.TextBox txtbNombre;
        private System.Windows.Forms.Button bLimpiar;
        private System.Windows.Forms.DataGridView dgvRoles;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
    }
}