namespace HotelServices
{
    partial class RezervacijaForma
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
            this.datePickPrijava = new System.Windows.Forms.DateTimePicker();
            this.datePickOdjava = new System.Windows.Forms.DateTimePicker();
            this.comboTip = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboSoba = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboGost = new System.Windows.Forms.ComboBox();
            this.btnSacuvaj = new System.Windows.Forms.Button();
            this.btnOtkazi = new System.Windows.Forms.Button();
            this.txtUkCena = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.comboTipFilter = new System.Windows.Forms.ComboBox();
            this.filterBrKreveta = new System.Windows.Forms.NumericUpDown();
            this.label7 = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterBrKreveta)).BeginInit();
            this.SuspendLayout();
            // 
            // datePickPrijava
            // 
            this.datePickPrijava.Location = new System.Drawing.Point(37, 48);
            this.datePickPrijava.Name = "datePickPrijava";
            this.datePickPrijava.Size = new System.Drawing.Size(492, 26);
            this.datePickPrijava.TabIndex = 0;
            this.datePickPrijava.ValueChanged += new System.EventHandler(this.datePickPrijava_ValueChanged);
            // 
            // datePickOdjava
            // 
            this.datePickOdjava.Location = new System.Drawing.Point(37, 109);
            this.datePickOdjava.Name = "datePickOdjava";
            this.datePickOdjava.Size = new System.Drawing.Size(492, 26);
            this.datePickOdjava.TabIndex = 1;
            this.datePickOdjava.ValueChanged += new System.EventHandler(this.datePickOdjava_ValueChanged);
            // 
            // comboTip
            // 
            this.comboTip.DropDownHeight = 80;
            this.comboTip.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboTip.FormattingEnabled = true;
            this.comboTip.IntegralHeight = false;
            this.comboTip.Location = new System.Drawing.Point(37, 176);
            this.comboTip.Name = "comboTip";
            this.comboTip.Size = new System.Drawing.Size(492, 27);
            this.comboTip.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(40, 25);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(114, 19);
            this.label1.TabIndex = 3;
            this.label1.Text = "Datum prijave";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(40, 87);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(114, 19);
            this.label2.TabIndex = 4;
            this.label2.Text = "Datum odjave";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(40, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(120, 19);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tip rezervacije";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(40, 309);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(49, 19);
            this.label4.TabIndex = 7;
            this.label4.Text = "Soba";
            // 
            // comboSoba
            // 
            this.comboSoba.DropDownHeight = 80;
            this.comboSoba.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboSoba.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboSoba.FormattingEnabled = true;
            this.comboSoba.IntegralHeight = false;
            this.comboSoba.Location = new System.Drawing.Point(37, 331);
            this.comboSoba.MaxDropDownItems = 5;
            this.comboSoba.Name = "comboSoba";
            this.comboSoba.Size = new System.Drawing.Size(492, 24);
            this.comboSoba.TabIndex = 3;
            this.comboSoba.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(40, 369);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(45, 19);
            this.label5.TabIndex = 9;
            this.label5.Text = "Gost";
            // 
            // comboGost
            // 
            this.comboGost.DropDownHeight = 80;
            this.comboGost.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboGost.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.comboGost.FormattingEnabled = true;
            this.comboGost.IntegralHeight = false;
            this.comboGost.Location = new System.Drawing.Point(37, 391);
            this.comboGost.Name = "comboGost";
            this.comboGost.Size = new System.Drawing.Size(492, 24);
            this.comboGost.TabIndex = 4;
            this.comboGost.SelectedIndexChanged += new System.EventHandler(this.comboBox3_SelectedIndexChanged);
            // 
            // btnSacuvaj
            // 
            this.btnSacuvaj.Location = new System.Drawing.Point(292, 461);
            this.btnSacuvaj.Name = "btnSacuvaj";
            this.btnSacuvaj.Size = new System.Drawing.Size(237, 43);
            this.btnSacuvaj.TabIndex = 5;
            this.btnSacuvaj.Text = "Sačuvaj";
            this.btnSacuvaj.UseVisualStyleBackColor = true;
            this.btnSacuvaj.Click += new System.EventHandler(this.btnSacuvaj_Click);
            // 
            // btnOtkazi
            // 
            this.btnOtkazi.Location = new System.Drawing.Point(37, 461);
            this.btnOtkazi.Name = "btnOtkazi";
            this.btnOtkazi.Size = new System.Drawing.Size(237, 43);
            this.btnOtkazi.TabIndex = 11;
            this.btnOtkazi.Text = "Otkaži";
            this.btnOtkazi.UseVisualStyleBackColor = true;
            this.btnOtkazi.Click += new System.EventHandler(this.btnOtkazi_Click);
            // 
            // txtUkCena
            // 
            this.txtUkCena.Enabled = false;
            this.txtUkCena.Location = new System.Drawing.Point(156, 430);
            this.txtUkCena.Name = "txtUkCena";
            this.txtUkCena.Size = new System.Drawing.Size(373, 26);
            this.txtUkCena.TabIndex = 12;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(40, 433);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(110, 19);
            this.label6.TabIndex = 13;
            this.label6.Text = "Ukupna cena";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.label10);
            this.panel1.Controls.Add(this.label9);
            this.panel1.Controls.Add(this.label8);
            this.panel1.Controls.Add(this.comboTipFilter);
            this.panel1.Controls.Add(this.filterBrKreveta);
            this.panel1.Controls.Add(this.label7);
            this.panel1.Location = new System.Drawing.Point(37, 213);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(491, 93);
            this.panel1.TabIndex = 14;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Arial", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 63);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(142, 16);
            this.label10.TabIndex = 20;
            this.label10.Text = "0 - Bilo koji broj kreveta";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(251, 37);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(75, 19);
            this.label9.TabIndex = 18;
            this.label9.Text = "Tip sobe";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(3, 37);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(101, 19);
            this.label8.TabIndex = 15;
            this.label8.Text = "Broj kreveta";
            // 
            // comboTipFilter
            // 
            this.comboTipFilter.FormattingEnabled = true;
            this.comboTipFilter.Location = new System.Drawing.Point(332, 34);
            this.comboTipFilter.Name = "comboTipFilter";
            this.comboTipFilter.Size = new System.Drawing.Size(156, 27);
            this.comboTipFilter.TabIndex = 17;
            this.comboTipFilter.SelectedIndexChanged += new System.EventHandler(this.comboTipFilter_SelectedIndexChanged);
            // 
            // filterBrKreveta
            // 
            this.filterBrKreveta.Location = new System.Drawing.Point(110, 34);
            this.filterBrKreveta.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.filterBrKreveta.Name = "filterBrKreveta";
            this.filterBrKreveta.Size = new System.Drawing.Size(120, 26);
            this.filterBrKreveta.TabIndex = 16;
            this.filterBrKreveta.ValueChanged += new System.EventHandler(this.filterBrKreveta_ValueChanged);
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(3, 2);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 19);
            this.label7.TabIndex = 15;
            this.label7.Text = "Filtriraj sobe";
            // 
            // RezervacijaForma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(10F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(584, 509);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtUkCena);
            this.Controls.Add(this.btnOtkazi);
            this.Controls.Add(this.btnSacuvaj);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboGost);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.comboSoba);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.comboTip);
            this.Controls.Add(this.datePickOdjava);
            this.Controls.Add(this.datePickPrijava);
            this.Font = new System.Drawing.Font("Arial", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(5, 4, 5, 4);
            this.Name = "RezervacijaForma";
            this.Text = "RezervacijaForma";
            this.Load += new System.EventHandler(this.RezervacijaForma_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.filterBrKreveta)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DateTimePicker datePickPrijava;
        private System.Windows.Forms.DateTimePicker datePickOdjava;
        private System.Windows.Forms.ComboBox comboTip;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboSoba;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboGost;
        private System.Windows.Forms.Button btnSacuvaj;
        private System.Windows.Forms.Button btnOtkazi;
        private System.Windows.Forms.TextBox txtUkCena;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox comboTipFilter;
        private System.Windows.Forms.NumericUpDown filterBrKreveta;
        private System.Windows.Forms.Label label7;
    }
}