namespace Salon_Management
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.flpUser = new System.Windows.Forms.FlowLayoutPanel();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bTotal = new System.Windows.Forms.Button();
            this.flpUser.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpUser
            // 
            this.flpUser.AutoScroll = true;
            this.flpUser.BackColor = System.Drawing.Color.Transparent;
            this.flpUser.Controls.Add(this.button1);
            this.flpUser.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flpUser.Location = new System.Drawing.Point(950, 43);
            this.flpUser.Name = "flpUser";
            this.flpUser.Size = new System.Drawing.Size(299, 600);
            this.flpUser.TabIndex = 0;
            this.flpUser.WrapContents = false;
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(3, 3);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(293, 59);
            this.button1.TabIndex = 0;
            this.button1.Text = "Admin";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(1063, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 31);
            this.label1.TabIndex = 1;
            this.label1.Text = "User";
            // 
            // bTotal
            // 
            this.bTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bTotal.Location = new System.Drawing.Point(12, 584);
            this.bTotal.Name = "bTotal";
            this.bTotal.Size = new System.Drawing.Size(293, 59);
            this.bTotal.TabIndex = 2;
            this.bTotal.Text = "Total";
            this.bTotal.UseVisualStyleBackColor = true;
            this.bTotal.Click += new System.EventHandler(this.bTotal_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1261, 655);
            this.Controls.Add(this.bTotal);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.flpUser);
            this.Name = "Main";
            this.Text = "Pro Nails";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.flpUser.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpUser;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button bTotal;
    }
}

