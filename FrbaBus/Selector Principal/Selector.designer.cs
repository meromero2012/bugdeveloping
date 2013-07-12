namespace FrbaBus.Selector_Principal
{
    partial class SelectorPrincipal
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
            this.selectorFuncionalidades = new System.Windows.Forms.DataGridView();
            this.Seleccionar = new System.Windows.Forms.DataGridViewButtonColumn();
            ((System.ComponentModel.ISupportInitialize)(this.selectorFuncionalidades)).BeginInit();
            this.SuspendLayout();
            // 
            // selectorFuncionalidades
            // 
            this.selectorFuncionalidades.AllowUserToAddRows = false;
            this.selectorFuncionalidades.AllowUserToDeleteRows = false;
            this.selectorFuncionalidades.AllowUserToResizeColumns = false;
            this.selectorFuncionalidades.AllowUserToResizeRows = false;
            this.selectorFuncionalidades.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.selectorFuncionalidades.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.selectorFuncionalidades.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.selectorFuncionalidades.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Seleccionar});
            this.selectorFuncionalidades.Enabled = false;
            this.selectorFuncionalidades.Location = new System.Drawing.Point(12, 27);
            this.selectorFuncionalidades.MultiSelect = false;
            this.selectorFuncionalidades.Name = "selectorFuncionalidades";
            this.selectorFuncionalidades.ReadOnly = true;
            this.selectorFuncionalidades.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing;
            this.selectorFuncionalidades.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.CellSelect;
            this.selectorFuncionalidades.Size = new System.Drawing.Size(403, 302);
            this.selectorFuncionalidades.TabIndex = 33;
            this.selectorFuncionalidades.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvRoles_CellContentClick);
            // 
            // Seleccionar
            // 
            this.Seleccionar.HeaderText = "Seleccionar";
            this.Seleccionar.Name = "Seleccionar";
            this.Seleccionar.ReadOnly = true;
            this.Seleccionar.Width = 69;
            // 
            // SelectorPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(449, 358);
            this.Controls.Add(this.selectorFuncionalidades);
            this.Name = "SelectorPrincipal";
            this.Text = "Seleccione la Operacion Deseada";
            this.Load += new System.EventHandler(this.FormFiltrarRol_Load);
            ((System.ComponentModel.ISupportInitialize)(this.selectorFuncionalidades)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView selectorFuncionalidades;
        private System.Windows.Forms.DataGridViewButtonColumn Seleccionar;
    }
}