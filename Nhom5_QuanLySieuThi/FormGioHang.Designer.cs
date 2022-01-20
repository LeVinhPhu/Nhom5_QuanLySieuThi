
namespace Nhom5_QuanLySieuThi
{
    partial class FormGioHang
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormGioHang));
            this.orderedProductsPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.emptyCart = new System.Windows.Forms.Button();
            this.totalPrice = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.numberOfProducts = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.viewHistoryButton = new System.Windows.Forms.Button();
            this.purchaseButton = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // orderedProductsPanel
            // 
            this.orderedProductsPanel.AutoScroll = true;
            this.orderedProductsPanel.BackColor = System.Drawing.Color.Gainsboro;
            this.orderedProductsPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.orderedProductsPanel.Location = new System.Drawing.Point(0, 0);
            this.orderedProductsPanel.Name = "orderedProductsPanel";
            this.orderedProductsPanel.Size = new System.Drawing.Size(958, 419);
            this.orderedProductsPanel.TabIndex = 0;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Controls.Add(this.emptyCart);
            this.panel1.Controls.Add(this.totalPrice);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.numberOfProducts);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.viewHistoryButton);
            this.panel1.Controls.Add(this.purchaseButton);
            this.panel1.Location = new System.Drawing.Point(0, 419);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(958, 86);
            this.panel1.TabIndex = 1;
            // 
            // emptyCart
            // 
            this.emptyCart.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.emptyCart.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.emptyCart.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.emptyCart.FlatAppearance.BorderSize = 0;
            this.emptyCart.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.emptyCart.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.emptyCart.ForeColor = System.Drawing.Color.OrangeRed;
            this.emptyCart.Image = ((System.Drawing.Image)(resources.GetObject("emptyCart.Image")));
            this.emptyCart.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.emptyCart.Location = new System.Drawing.Point(432, 16);
            this.emptyCart.Name = "emptyCart";
            this.emptyCart.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.emptyCart.Size = new System.Drawing.Size(169, 53);
            this.emptyCart.TabIndex = 3;
            this.emptyCart.Text = " EMPTY CART";
            this.emptyCart.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.emptyCart.UseVisualStyleBackColor = false;
            this.emptyCart.Click += new System.EventHandler(this.emptyCart_Click);
            // 
            // totalPrice
            // 
            this.totalPrice.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.totalPrice.AutoSize = true;
            this.totalPrice.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.totalPrice.ForeColor = System.Drawing.Color.OrangeRed;
            this.totalPrice.Location = new System.Drawing.Point(207, 47);
            this.totalPrice.Name = "totalPrice";
            this.totalPrice.Size = new System.Drawing.Size(20, 22);
            this.totalPrice.TabIndex = 2;
            this.totalPrice.Text = "0";
            // 
            // label2
            // 
            this.label2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.OrangeRed;
            this.label2.Location = new System.Drawing.Point(30, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(120, 22);
            this.label2.TabIndex = 2;
            this.label2.Text = "TOTAL PRICE:";
            // 
            // numberOfProducts
            // 
            this.numberOfProducts.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.numberOfProducts.AutoSize = true;
            this.numberOfProducts.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.numberOfProducts.Location = new System.Drawing.Point(208, 16);
            this.numberOfProducts.Name = "numberOfProducts";
            this.numberOfProducts.Size = new System.Drawing.Size(15, 16);
            this.numberOfProducts.TabIndex = 2;
            this.numberOfProducts.Text = "0";
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(31, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(169, 16);
            this.label1.TabIndex = 2;
            this.label1.Text = "NUMBER OF PRODUCTS:";
            // 
            // viewHistoryButton
            // 
            this.viewHistoryButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.viewHistoryButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.viewHistoryButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.viewHistoryButton.FlatAppearance.BorderSize = 0;
            this.viewHistoryButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.viewHistoryButton.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.viewHistoryButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.viewHistoryButton.Image = ((System.Drawing.Image)(resources.GetObject("viewHistoryButton.Image")));
            this.viewHistoryButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.viewHistoryButton.Location = new System.Drawing.Point(617, 16);
            this.viewHistoryButton.Name = "viewHistoryButton";
            this.viewHistoryButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.viewHistoryButton.Size = new System.Drawing.Size(132, 53);
            this.viewHistoryButton.TabIndex = 1;
            this.viewHistoryButton.Text = " HISTORY";
            this.viewHistoryButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.viewHistoryButton.UseVisualStyleBackColor = false;
            this.viewHistoryButton.Click += new System.EventHandler(this.viewHistoryButton_Click);
            // 
            // purchaseButton
            // 
            this.purchaseButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.purchaseButton.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.purchaseButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.purchaseButton.FlatAppearance.BorderSize = 0;
            this.purchaseButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.purchaseButton.Font = new System.Drawing.Font("Microsoft Tai Le", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.purchaseButton.ForeColor = System.Drawing.Color.OrangeRed;
            this.purchaseButton.Image = ((System.Drawing.Image)(resources.GetObject("purchaseButton.Image")));
            this.purchaseButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.purchaseButton.Location = new System.Drawing.Point(764, 16);
            this.purchaseButton.Name = "purchaseButton";
            this.purchaseButton.Padding = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.purchaseButton.Size = new System.Drawing.Size(155, 53);
            this.purchaseButton.TabIndex = 0;
            this.purchaseButton.Text = "  PURCHASE";
            this.purchaseButton.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageBeforeText;
            this.purchaseButton.UseVisualStyleBackColor = false;
            this.purchaseButton.Click += new System.EventHandler(this.purchaseButton_Click);
            // 
            // FormGioHang
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(192)))));
            this.ClientSize = new System.Drawing.Size(958, 505);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.orderedProductsPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormGioHang";
            this.Text = "FormGioHang";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel orderedProductsPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button viewHistoryButton;
        private System.Windows.Forms.Button purchaseButton;
        private System.Windows.Forms.Label totalPrice;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label numberOfProducts;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button emptyCart;
    }
}