namespace Nhom5_QuanLySieuThi
{
    partial class FormHistory
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
            this.orderViewsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // orderViewsPanel
            // 
            this.orderViewsPanel.AutoScroll = true;
            this.orderViewsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.orderViewsPanel.Location = new System.Drawing.Point(0, 0);
            this.orderViewsPanel.Name = "orderViewsPanel";
            this.orderViewsPanel.Size = new System.Drawing.Size(958, 459);
            this.orderViewsPanel.TabIndex = 0;
            // 
            // FormHistory
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 459);
            this.Controls.Add(this.orderViewsPanel);
            this.MinimumSize = new System.Drawing.Size(976, 506);
            this.Name = "FormHistory";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "ForrmHistory";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel orderViewsPanel;
    }
}