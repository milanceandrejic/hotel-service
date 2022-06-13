namespace HotelServices
{
    partial class SobaForma
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
            this.txtBrojSobe = new System.Windows.Forms.TextBox();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.txtCena = new System.Windows.Forms.TextBox();
            this.numBrKreveta = new System.Windows.Forms.NumericUpDown();
            this.txtPopust = new System.Windows.Forms.TextBox();
            this.numMinDana = new System.Windows.Forms.NumericUpDown();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.numBrKreveta)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDana)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(52, 28);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 19);
            this.label1.TabIndex = 0;
            this.label1.Text = "Broj sobe";
            // 
            // txtBrojSobe
            // 
            this.txtBrojSobe.Location = new System.Drawing.Point(141, 25);
            this.txtBrojSobe.Name = "txtBrojSobe";
            this.txtBrojSobe.Size = new System.Drawing.Size(175, 26);
            this.txtBrojSobe.TabIndex = 1;
            this.txtBrojSobe.TextChanged += new System.EventHandler(this.txtBrojSobe_TextChanged);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(18, 275);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(139, 43);
            this.btnOtkazi.TabIndex = 13;
            this.btnOtkazi.Text = "Otkazi";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(180, 275);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(139, 43);
            this.btnSacuvaj.TabIndex = 7;
            this.btnSacuvaj.Text = "Sacuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(34, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(101, 19);
            this.label2.TabIndex = 14;
            this.label2.Text = "Broj kreveta";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 90);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 19);
            this.label3.TabIndex = 15;
            this.label3.Text = "Tip sobe";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 121);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 19);
            this.label4.TabIndex = 16;
            this.label4.Text = "Cena";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(71, 152);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(64, 19);
            this.label5.TabIndex = 17;
            this.label5.Text = "Popust";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 183);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(120, 19);
            this.label6.TabIndex = 18;
            this.label6.Text = "Minimum dana";
            // 
            // txtCena
            // 
            this.txtCena.Location = new System.Drawing.Point(141, 118);
            this.txtCena.Name = "txtCena";
            this.txtCena.Size = new System.Drawing.Size(175, 26);
            this.txtCena.TabIndex = 4;
            // 
            // numBrKreveta
            // 
            this.numBrKreveta.Location = new System.Drawing.Point(141, 57);
            this.numBrKreveta.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numBrKreveta.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numBrKreveta.Name = "numBrKreveta";
            this.numBrKreveta.Size = new System.Drawing.Size(175, 26);
            this.numBrKreveta.TabIndex = 2;
            this.numBrKreveta.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // txtPopust
            // 
            this.txtPopust.Location = new System.Drawing.Point(141, 149);
            this.txtPopust.Name = "txtPopust";
            this.txtPopust.Size = new System.Drawing.Size(175, 26);
            this.txtPopust.TabIndex = 5;
            // 
            // numMinDana
            // 
            this.numMinDana.Location = new System.Drawing.Point(141, 181);
            this.numMinDana.Maximum = new decimal(new int[] {
            90,
            0,
            0,
            0});
            this.numMinDana.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.numMinDana.Name = "numMinDana";
            this.numMinDana.Size = new System.Drawing.Size(175, 26);
            this.numMinDana.TabIndex = 6;
            this.numMinDana.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(141, 87);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(175, 27);
            this.comboBox1.TabIndex = 3;
            // 
            // SobaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(348, 330);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.numMinDana);
            this.Controls.Add(this.txtPopust);
            this.Controls.Add(this.numBrKreveta);
            this.Controls.Add(this.txtCena);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.txtBrojSobe);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "SobaForma";
            this.Text = "SobaForma";
            this.Load += new System.EventHandler(this.SobaForma_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numBrKreveta)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numMinDana)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtBrojSobe;
        private System.Windows.Forms.Button btnOtkazi;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtCena;
        private System.Windows.Forms.NumericUpDown numBrKreveta;
        private System.Windows.Forms.TextBox txtPopust;
        private System.Windows.Forms.NumericUpDown numMinDana;
        private System.Windows.Forms.ComboBox comboBox1;
    }
}