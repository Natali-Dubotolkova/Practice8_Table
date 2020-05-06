namespace XMLGUI.Forms
{
    partial class FilterProperties
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
            this.paramTxtBox = new System.Windows.Forms.TextBox();
            this.btnApply = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // paramTxtBox
            // 
            this.paramTxtBox.Location = new System.Drawing.Point(48, 40);
            this.paramTxtBox.Name = "paramTxtBox";
            this.paramTxtBox.Size = new System.Drawing.Size(230, 22);
            this.paramTxtBox.TabIndex = 0;
            // 
            // btnApply
            // 
            this.btnApply.Location = new System.Drawing.Point(181, 78);
            this.btnApply.Name = "btnApply";
            this.btnApply.Size = new System.Drawing.Size(97, 24);
            this.btnApply.TabIndex = 1;
            this.btnApply.Text = "Apply";
            this.btnApply.UseVisualStyleBackColor = true;
            this.btnApply.Click += new System.EventHandler(this.OnBtnApplyClick);
            // 
            // FilterProperties
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(313, 149);
            this.Controls.Add(this.btnApply);
            this.Controls.Add(this.paramTxtBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FilterProperties";
            this.Text = "Filter properties";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox paramTxtBox;
        private System.Windows.Forms.Button btnApply;
    }
}