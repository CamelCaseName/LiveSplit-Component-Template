namespace LiveSplit.UI.Components
{
    partial class Settings
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(35, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "label1";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Items.AddRange(new object[] {
            "TOPLESS% Amy",
            "TOPLESS% Ashley",
            "TOPLESS% Brittney",
            "TOPLESS% Katherine",
            "TOPLESS% Leah",
            "TOPLESS% Lety",
            "TOPLESS% Madison",
            "TOPLESS% Rachael",
            "TOPLESS% Stephanie",
            "TOPLESS% Vickie",
            "ALL REWARDS 0.14",
            "ALL REWARDS 0.15",
            "ALL REWARDS 0.16",
            "ALL REWARDS 0.17",
            "ALL REWARDS 0.18",
            "ALL REWARDS 0.19",
            "ALL REWARDS 0.20",
            "REWARD% Amy",
            "REWARD% Ashley",
            "REWARD% Derek",
            "REWARD% Frank",
            "REWARD% Katherine",
            "REWARD% Leah",
            "REWARD% Lety",
            "REWARD% Madison",
            "REWARD% Patrick",
            "REWARD% Rachael",
            "REWARD% Stephanie",
            "REWARD% Vickie",
            "THREESOME% 0.20"});
            this.listBox1.Location = new System.Drawing.Point(15, 43);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(178, 56);
            this.listBox1.TabIndex = 1;
            this.listBox1.SelectedIndexChanged += new System.EventHandler(this.listBox1_SelectedIndexChanged);
            // 
            // Settings
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.listBox1);
            this.Controls.Add(this.label1);
            this.Name = "Settings";
            this.Size = new System.Drawing.Size(219, 133);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox listBox1;
    }
}
