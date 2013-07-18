namespace FrbaBus.Canje_de_Ptos
{
    partial class CanjePuntos
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
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.dniLabel = new System.Windows.Forms.Label();
            this.dniTextBox = new System.Windows.Forms.TextBox();
            this.buscarDniButton = new System.Windows.Forms.Button();
            this.puntosDisponiblesLabel = new System.Windows.Forms.Label();
            this.productosLabel = new System.Windows.Forms.Label();
            this.productosComboBox = new System.Windows.Forms.ComboBox();
            this.canjearButton = new System.Windows.Forms.Button();
            this.volverButton = new System.Windows.Forms.Button();
            this.descripcionLabel = new System.Windows.Forms.Label();
            this.errorLabel = new System.Windows.Forms.Label();
            this.puntosLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.dniLabel, 0, 1);
            this.tableLayoutPanel1.Controls.Add(this.dniTextBox, 1, 1);
            this.tableLayoutPanel1.Controls.Add(this.buscarDniButton, 0, 3);
            this.tableLayoutPanel1.Controls.Add(this.puntosDisponiblesLabel, 0, 4);
            this.tableLayoutPanel1.Controls.Add(this.productosLabel, 0, 5);
            this.tableLayoutPanel1.Controls.Add(this.productosComboBox, 1, 5);
            this.tableLayoutPanel1.Controls.Add(this.canjearButton, 0, 6);
            this.tableLayoutPanel1.Controls.Add(this.volverButton, 1, 6);
            this.tableLayoutPanel1.Controls.Add(this.descripcionLabel, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.errorLabel, 0, 2);
            this.tableLayoutPanel1.Controls.Add(this.puntosLabel, 1, 4);
            this.tableLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 7;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28572F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 14.28571F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(276, 257);
            this.tableLayoutPanel1.TabIndex = 0;
            // 
            // dniLabel
            // 
            this.dniLabel.AutoSize = true;
            this.dniLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dniLabel.Location = new System.Drawing.Point(3, 36);
            this.dniLabel.Name = "dniLabel";
            this.dniLabel.Size = new System.Drawing.Size(132, 36);
            this.dniLabel.TabIndex = 1;
            this.dniLabel.Text = "DNI:";
            this.dniLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // dniTextBox
            // 
            this.dniTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dniTextBox.Location = new System.Drawing.Point(141, 39);
            this.dniTextBox.Name = "dniTextBox";
            this.dniTextBox.Size = new System.Drawing.Size(132, 20);
            this.dniTextBox.TabIndex = 2;
            this.dniTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.dniTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox_KeyPress);
            // 
            // buscarDniButton
            // 
            this.tableLayoutPanel1.SetColumnSpan(this.buscarDniButton, 2);
            this.buscarDniButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buscarDniButton.Location = new System.Drawing.Point(3, 111);
            this.buscarDniButton.Name = "buscarDniButton";
            this.buscarDniButton.Size = new System.Drawing.Size(270, 30);
            this.buscarDniButton.TabIndex = 3;
            this.buscarDniButton.Text = "Buscar DNI";
            this.buscarDniButton.UseVisualStyleBackColor = true;
            this.buscarDniButton.Click += new System.EventHandler(this.buscarDniButton_Click);
            // 
            // puntosDisponiblesLabel
            // 
            this.puntosDisponiblesLabel.AutoSize = true;
            this.puntosDisponiblesLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.puntosDisponiblesLabel.Location = new System.Drawing.Point(3, 144);
            this.puntosDisponiblesLabel.Name = "puntosDisponiblesLabel";
            this.puntosDisponiblesLabel.Size = new System.Drawing.Size(132, 36);
            this.puntosDisponiblesLabel.TabIndex = 4;
            this.puntosDisponiblesLabel.Text = "Puntos disponibles:";
            this.puntosDisponiblesLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productosLabel
            // 
            this.productosLabel.AutoSize = true;
            this.productosLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productosLabel.Location = new System.Drawing.Point(3, 180);
            this.productosLabel.Name = "productosLabel";
            this.productosLabel.Size = new System.Drawing.Size(132, 36);
            this.productosLabel.TabIndex = 6;
            this.productosLabel.Text = "Productos que puede canjear con sus puntos:";
            this.productosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // productosComboBox
            // 
            this.productosComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productosComboBox.Enabled = false;
            this.productosComboBox.FormattingEnabled = true;
            this.productosComboBox.Location = new System.Drawing.Point(141, 183);
            this.productosComboBox.Name = "productosComboBox";
            this.productosComboBox.Size = new System.Drawing.Size(132, 21);
            this.productosComboBox.TabIndex = 7;
            // 
            // canjearButton
            // 
            this.canjearButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.canjearButton.Enabled = false;
            this.canjearButton.Location = new System.Drawing.Point(3, 219);
            this.canjearButton.Name = "canjearButton";
            this.canjearButton.Size = new System.Drawing.Size(132, 35);
            this.canjearButton.TabIndex = 8;
            this.canjearButton.Text = "Realizar Canje";
            this.canjearButton.UseVisualStyleBackColor = true;
            this.canjearButton.Click += new System.EventHandler(this.canjearButton_Click);
            // 
            // volverButton
            // 
            this.volverButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volverButton.Location = new System.Drawing.Point(141, 219);
            this.volverButton.Name = "volverButton";
            this.volverButton.Size = new System.Drawing.Size(132, 35);
            this.volverButton.TabIndex = 9;
            this.volverButton.Text = "Volver";
            this.volverButton.UseVisualStyleBackColor = true;
            this.volverButton.Click += new System.EventHandler(this.volverButton_Click);
            // 
            // descripcionLabel
            // 
            this.descripcionLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.descripcionLabel, 2);
            this.descripcionLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.descripcionLabel.Location = new System.Drawing.Point(3, 0);
            this.descripcionLabel.Name = "descripcionLabel";
            this.descripcionLabel.Size = new System.Drawing.Size(270, 36);
            this.descripcionLabel.TabIndex = 10;
            this.descripcionLabel.Text = "Ingrese el DNI del cliente para realizar el canje.";
            this.descripcionLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // errorLabel
            // 
            this.errorLabel.AutoSize = true;
            this.tableLayoutPanel1.SetColumnSpan(this.errorLabel, 2);
            this.errorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorLabel.ForeColor = System.Drawing.Color.Red;
            this.errorLabel.Location = new System.Drawing.Point(3, 72);
            this.errorLabel.Name = "errorLabel";
            this.errorLabel.Size = new System.Drawing.Size(270, 36);
            this.errorLabel.TabIndex = 11;
            this.errorLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // puntosLabel
            // 
            this.puntosLabel.AutoSize = true;
            this.puntosLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.puntosLabel.Location = new System.Drawing.Point(141, 144);
            this.puntosLabel.Name = "puntosLabel";
            this.puntosLabel.Size = new System.Drawing.Size(132, 36);
            this.puntosLabel.TabIndex = 12;
            this.puntosLabel.Text = "-";
            this.puntosLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // CanjePuntos
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(276, 257);
            this.Controls.Add(this.tableLayoutPanel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "CanjePuntos";
            this.Text = "Canje de puntos acumulados";
            this.Load += new System.EventHandler(this.CanjePuntos_Load);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label dniLabel;
        private System.Windows.Forms.TextBox dniTextBox;
        private System.Windows.Forms.Button buscarDniButton;
        private System.Windows.Forms.Label puntosDisponiblesLabel;
        private System.Windows.Forms.Label productosLabel;
        private System.Windows.Forms.ComboBox productosComboBox;
        private System.Windows.Forms.Button canjearButton;
        private System.Windows.Forms.Button volverButton;
        private System.Windows.Forms.Label descripcionLabel;
        private System.Windows.Forms.Label errorLabel;
        private System.Windows.Forms.Label puntosLabel;

    }
}