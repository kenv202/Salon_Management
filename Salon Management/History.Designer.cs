namespace Salon_Management
{
    partial class History
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
            this.pbPrintPreview = new System.Windows.Forms.PictureBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cbTicketNumber = new System.Windows.Forms.ComboBox();
            this.bShow = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pbPrintPreview)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pbPrintPreview
            // 
            this.pbPrintPreview.Location = new System.Drawing.Point(6, 3);
            this.pbPrintPreview.Name = "pbPrintPreview";
            this.pbPrintPreview.Size = new System.Drawing.Size(253, 263);
            this.pbPrintPreview.TabIndex = 0;
            this.pbPrintPreview.TabStop = false;
            this.pbPrintPreview.Paint += new System.Windows.Forms.PaintEventHandler(this.pbPrintPreview_Paint);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cbTicketNumber);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(146, 71);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Ticket Number";
            // 
            // cbTicketNumber
            // 
            this.cbTicketNumber.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cbTicketNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 18F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbTicketNumber.FormattingEnabled = true;
            this.cbTicketNumber.Location = new System.Drawing.Point(6, 19);
            this.cbTicketNumber.Name = "cbTicketNumber";
            this.cbTicketNumber.Size = new System.Drawing.Size(121, 37);
            this.cbTicketNumber.TabIndex = 0;
            // 
            // bShow
            // 
            this.bShow.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bShow.Location = new System.Drawing.Point(164, 20);
            this.bShow.Name = "bShow";
            this.bShow.Size = new System.Drawing.Size(110, 59);
            this.bShow.TabIndex = 9;
            this.bShow.Text = "Show";
            this.bShow.UseVisualStyleBackColor = true;
            this.bShow.Click += new System.EventHandler(this.bShow_Click);
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.pbPrintPreview);
            this.panel1.Location = new System.Drawing.Point(12, 89);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(262, 552);
            this.panel1.TabIndex = 10;
            // 
            // History
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 653);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.bShow);
            this.Controls.Add(this.groupBox1);
            this.Name = "History";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "History";
            this.TopMost = true;
            ((System.ComponentModel.ISupportInitialize)(this.pbPrintPreview)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pbPrintPreview;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.ComboBox cbTicketNumber;
        private System.Windows.Forms.Button bShow;
        private System.Windows.Forms.Panel panel1;
    }
}