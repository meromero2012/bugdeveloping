namespace FrbaBus.Login
{
    partial class Login
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
            this.buttonINGRESAR = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.textBoxUSER = new System.Windows.Forms.TextBox();
            this.textBoxPASSWORD = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonINGRESAR
            // 
            this.buttonINGRESAR.Location = new System.Drawing.Point(124, 158);
            this.buttonINGRESAR.Name = "buttonINGRESAR";
            this.buttonINGRESAR.Size = new System.Drawing.Size(125, 23);
            this.buttonINGRESAR.TabIndex = 0;
            this.buttonINGRESAR.Text = "Ingresar";
            this.buttonINGRESAR.UseVisualStyleBackColor = true;
            this.buttonINGRESAR.Click += new System.EventHandler(this.buttonINGRESAR_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Ingrese usuario";
            // 
            // textBoxUSER
            // 
            this.textBoxUSER.Location = new System.Drawing.Point(124, 35);
            this.textBoxUSER.Name = "textBoxUSER";
            this.textBoxUSER.Size = new System.Drawing.Size(222, 20);
            this.textBoxUSER.TabIndex = 2;
            this.textBoxUSER.Text = "juanPerez";
            // 
            // textBoxPASSWORD
            // 
            this.textBoxPASSWORD.Location = new System.Drawing.Point(124, 94);
            this.textBoxPASSWORD.Name = "textBoxPASSWORD";
            this.textBoxPASSWORD.Size = new System.Drawing.Size(222, 20);
            this.textBoxPASSWORD.TabIndex = 3;
            this.textBoxPASSWORD.Text = "w23e";
            this.textBoxPASSWORD.UseSystemPasswordChar = true;
            this.textBoxPASSWORD.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxPASSWORD_KeyPress);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 97);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(98, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Ingrese contraseña";
            // 
            // Login
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(381, 222);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textBoxPASSWORD);
            this.Controls.Add(this.textBoxUSER);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonINGRESAR);
            this.Name = "Login";
            this.Text = "Bienvenido - Debe loggearse para ingresar al Sistema";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonINGRESAR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBoxUSER;
        private System.Windows.Forms.TextBox textBoxPASSWORD;
        private System.Windows.Forms.Label label2;

    }
}