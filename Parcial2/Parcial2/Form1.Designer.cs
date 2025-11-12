namespace Parcial2
{
    partial class Form1
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
            this.txtlbs = new System.Windows.Forms.TextBox();
            this.txtkg2 = new System.Windows.Forms.TextBox();
            this.btnLk = new System.Windows.Forms.Button();
            this.btnKl = new System.Windows.Forms.Button();
            this.txtkg = new System.Windows.Forms.TextBox();
            this.txtlbs2 = new System.Windows.Forms.TextBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.btnMostrar = new System.Windows.Forms.Button();
            this.btnLimpiar = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(34, 59);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Libras a Kilogramos ";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 107);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(147, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Kilogramos a Libras";
            // 
            // txtlbs
            // 
            this.txtlbs.Location = new System.Drawing.Point(191, 53);
            this.txtlbs.Name = "txtlbs";
            this.txtlbs.Size = new System.Drawing.Size(128, 26);
            this.txtlbs.TabIndex = 2;
            // 
            // txtkg2
            // 
            this.txtkg2.Location = new System.Drawing.Point(191, 101);
            this.txtkg2.Name = "txtkg2";
            this.txtkg2.Size = new System.Drawing.Size(128, 26);
            this.txtkg2.TabIndex = 3;
            // 
            // btnLk
            // 
            this.btnLk.Location = new System.Drawing.Point(333, 53);
            this.btnLk.Name = "btnLk";
            this.btnLk.Size = new System.Drawing.Size(98, 26);
            this.btnLk.TabIndex = 4;
            this.btnLk.Text = "->";
            this.btnLk.UseVisualStyleBackColor = true;
            this.btnLk.Click += new System.EventHandler(this.btnLk_Click);
            // 
            // btnKl
            // 
            this.btnKl.Location = new System.Drawing.Point(333, 101);
            this.btnKl.Name = "btnKl";
            this.btnKl.Size = new System.Drawing.Size(98, 26);
            this.btnKl.TabIndex = 5;
            this.btnKl.Text = "->";
            this.btnKl.UseVisualStyleBackColor = true;
            this.btnKl.Click += new System.EventHandler(this.btnKl_Click);
            // 
            // txtkg
            // 
            this.txtkg.Location = new System.Drawing.Point(446, 53);
            this.txtkg.Name = "txtkg";
            this.txtkg.Size = new System.Drawing.Size(128, 26);
            this.txtkg.TabIndex = 6;
            // 
            // txtlbs2
            // 
            this.txtlbs2.Location = new System.Drawing.Point(446, 101);
            this.txtlbs2.Name = "txtlbs2";
            this.txtlbs2.Size = new System.Drawing.Size(128, 26);
            this.txtlbs2.TabIndex = 7;
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 20;
            this.listBox1.Location = new System.Drawing.Point(38, 159);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(535, 184);
            this.listBox1.TabIndex = 8;
            // 
            // btnMostrar
            // 
            this.btnMostrar.Location = new System.Drawing.Point(487, 370);
            this.btnMostrar.Name = "btnMostrar";
            this.btnMostrar.Size = new System.Drawing.Size(86, 31);
            this.btnMostrar.TabIndex = 9;
            this.btnMostrar.Text = "Mostrar";
            this.btnMostrar.UseVisualStyleBackColor = true;
            this.btnMostrar.Click += new System.EventHandler(this.btnMostrar_Click_1);
            // 
            // btnLimpiar
            // 
            this.btnLimpiar.Location = new System.Drawing.Point(395, 370);
            this.btnLimpiar.Name = "btnLimpiar";
            this.btnLimpiar.Size = new System.Drawing.Size(86, 31);
            this.btnLimpiar.TabIndex = 10;
            this.btnLimpiar.Text = "Limpiar";
            this.btnLimpiar.UseVisualStyleBackColor = true;
            this.btnLimpiar.Click += new System.EventHandler(this.btnLimpiar_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(606, 450);
            this.Controls.Add(this.btnLimpiar);
            this.Controls.Add(this.btnMostrar);
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.txtlbs2);
            this.Controls.Add(this.txtkg);
            this.Controls.Add(this.btnKl);
            this.Controls.Add(this.btnLk);
            this.Controls.Add(this.txtkg2);
            this.Controls.Add(this.txtlbs);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Conversor Numérico";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtlbs;
        private System.Windows.Forms.TextBox txtkg2;
        private System.Windows.Forms.Button btnLk;
        private System.Windows.Forms.Button btnKl;
        private System.Windows.Forms.TextBox txtkg;
        private System.Windows.Forms.TextBox txtlbs2;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.Button btnMostrar;
        private System.Windows.Forms.Button btnLimpiar;
    }
}

