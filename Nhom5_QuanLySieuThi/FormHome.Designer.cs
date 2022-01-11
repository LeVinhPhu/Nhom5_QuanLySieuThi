
namespace Nhom5_QuanLySieuThi
{
    partial class FormHome
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormHome));
            this.productsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.categoriesPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.defaultThumbnails = new System.Windows.Forms.ImageList(this.components);
            this.SuspendLayout();
            // 
            // productsPanel
            // 
            this.productsPanel.AutoScroll = true;
            this.productsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.productsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.productsPanel.Location = new System.Drawing.Point(197, 0);
            this.productsPanel.Name = "productsPanel";
            this.productsPanel.Size = new System.Drawing.Size(761, 505);
            this.productsPanel.TabIndex = 4;
            // 
            // categoriesPanel
            // 
            this.categoriesPanel.AutoScroll = true;
            this.categoriesPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(206)))), ((int)(((byte)(212)))), ((int)(((byte)(218)))));
            this.categoriesPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.categoriesPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.categoriesPanel.Location = new System.Drawing.Point(0, 0);
            this.categoriesPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.categoriesPanel.Name = "categoriesPanel";
            this.categoriesPanel.Size = new System.Drawing.Size(197, 505);
            this.categoriesPanel.TabIndex = 5;
            this.categoriesPanel.WrapContents = false;
            // 
            // defaultThumbnails
            // 
            this.defaultThumbnails.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("defaultThumbnails.ImageStream")));
            this.defaultThumbnails.TransparentColor = System.Drawing.Color.Transparent;
            this.defaultThumbnails.Images.SetKeyName(0, "istockphoto-1193046540-612x612.jpg");
            // 
            // FormHome
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(958, 505);
            this.Controls.Add(this.productsPanel);
            this.Controls.Add(this.categoriesPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormHome";
            this.Text = "FormHome";
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel productsPanel;
        private System.Windows.Forms.FlowLayoutPanel categoriesPanel;
        private System.Windows.Forms.ImageList defaultThumbnails;
    }
}