namespace FrbaBus.Abm_Permisos
{
    partial class RolMenu
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.altaButton = new System.Windows.Forms.Button();
            this.filtroButton = new System.Windows.Forms.Button();
            this.modificacionButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 80F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 10F));
            this.tableLayoutPanel1.Controls.Add(this.altaButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.filtroButton, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.modificacionButton, 1, 2);
            this.tableLayoutPanel1.Controls.Add(this.volverButton, 1, 3);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 4;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(168, 119);
            this.tableLayoutPanel1.TabIndex = 1;
            // 
            // altaButton
            // 
            this.altaButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.altaButton.Location = new System.Drawing.Point(19, 3);
            this.altaButton.Name = "altaButton";
            this.altaButton.Size = new System.Drawing.Size(128, 23);
            this.altaButton.TabIndex = 0;
            this.altaButton.Text = "Alta";
            this.altaButton.UseVisualStyleBackColor = true;
            this.altaButton.Click += new System.EventHandler(this.altaButton_Click);
            // 
            // filtroButton
            // 
            this.filtroButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filtroButton.Location = new System.Drawing.Point(19, 32);
            this.filtroButton.Name = "filtroButton";
            this.filtroButton.Size = new System.Drawing.Size(128, 23);
            this.filtroButton.TabIndex = 1;
            this.filtroButton.Text = "Filtro";
            this.filtroButton.UseVisualStyleBackColor = true;
            this.filtroButton.Click += new System.EventHandler(this.filtroButton_Click);
            // 
            // modificacionButton
            // 
            this.modificacionButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.modificacionButton.Location = new System.Drawing.Point(19, 61);
            this.modificacionButton.Name = "modificacionButton";
            this.modificacionButton.Size = new System.Drawing.Size(128, 23);
            this.modificacionButton.TabIndex = 2;
            this.modificacionButton.Text = "Modificacion";
            this.modificacionButton.UseVisualStyleBackColor = true;
            this.modificacionButton.Click += new System.EventHandler(this.modificacionButton_Click);
            // 
            // volverButton
            // 
            this.volverButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volverButton.Location = new System.Drawing.Point(19, 90);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(128, 26);
            this.volverButton.TabIndex = 3;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // RolMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(168, 119);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Name = "RolMenu";
            this.Text = "Menu de Roles";
            this.Load += new System.EventHandler(this.RolMenu_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Button altaButton;
        private System.Windows.Forms.Button filtroButton;
        private System.Windows.Forms.Button modificacionButton;
        private System.Windows.Forms.Button volverButton;
    }
}