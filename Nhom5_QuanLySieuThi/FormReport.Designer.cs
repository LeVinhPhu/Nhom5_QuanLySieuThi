
namespace Nhom5_QuanLySieuThi
{
    partial class FormReport
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
<<<<<<< HEAD
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.getRevenueListEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.QuanLySieuThiDataSet = new Nhom5_QuanLySieuThi.QuanLySieuThiDataSet1();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.getRevenueListETableAdapter = new Nhom5_QuanLySieuThi.QuanLySieuThiDataSet1TableAdapters.getRevenueListETableAdapter();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.getRevenueListEBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLySieuThiDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // getRevenueListEBindingSource
            // 
            this.getRevenueListEBindingSource.DataMember = "getRevenueListE";
            this.getRevenueListEBindingSource.DataSource = this.QuanLySieuThiDataSet;
            // 
            // QuanLySieuThiDataSet
            // 
            this.QuanLySieuThiDataSet.DataSetName = "QuanLySieuThiDataSet";
            this.QuanLySieuThiDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "DataSet1";
            reportDataSource3.Value = this.getRevenueListEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Nhom5_QuanLySieuThi.Report.rdlc";
=======
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.QuanLySieuThiDataSet2 = new Nhom5_QuanLySieuThi.QuanLySieuThiDataSet2();
            this.getRevenueListEBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.getRevenueListETableAdapter = new Nhom5_QuanLySieuThi.QuanLySieuThiDataSet2TableAdapters.getRevenueListETableAdapter();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLySieuThiDataSet2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.getRevenueListEBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.getRevenueListEBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Nhom5_QuanLySieuThi.Report1.rdlc";
>>>>>>> 3487230753c025e9025c14d3dcc52402a630eb3b
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
<<<<<<< HEAD
=======
            // QuanLySieuThiDataSet2
            // 
            this.QuanLySieuThiDataSet2.DataSetName = "QuanLySieuThiDataSet2";
            this.QuanLySieuThiDataSet2.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // getRevenueListEBindingSource
            // 
            this.getRevenueListEBindingSource.DataMember = "getRevenueListE";
            this.getRevenueListEBindingSource.DataSource = this.QuanLySieuThiDataSet2;
            // 
>>>>>>> 3487230753c025e9025c14d3dcc52402a630eb3b
            // getRevenueListETableAdapter
            // 
            this.getRevenueListETableAdapter.ClearBeforeFill = true;
            // 
<<<<<<< HEAD
            // pictureBox1
            // 
            this.pictureBox1.Image = global::Nhom5_QuanLySieuThi.Properties.Resources.icons8_print_30;
            this.pictureBox1.Location = new System.Drawing.Point(252, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(26, 26);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
=======
>>>>>>> 3487230753c025e9025c14d3dcc52402a630eb3b
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
<<<<<<< HEAD
            this.Controls.Add(this.pictureBox1);
=======
>>>>>>> 3487230753c025e9025c14d3dcc52402a630eb3b
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.Load += new System.EventHandler(this.FormReport_Load);
<<<<<<< HEAD
            ((System.ComponentModel.ISupportInitialize)(this.getRevenueListEBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.QuanLySieuThiDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
=======
            ((System.ComponentModel.ISupportInitialize)(this.QuanLySieuThiDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getRevenueListEBindingSource)).EndInit();
>>>>>>> 3487230753c025e9025c14d3dcc52402a630eb3b
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getRevenueListEBindingSource;
<<<<<<< HEAD
        private QuanLySieuThiDataSet1 QuanLySieuThiDataSet;
        private QuanLySieuThiDataSet1TableAdapters.getRevenueListETableAdapter getRevenueListETableAdapter;
        private System.Windows.Forms.PictureBox pictureBox1;
=======
        private QuanLySieuThiDataSet2 QuanLySieuThiDataSet2;
        private QuanLySieuThiDataSet2TableAdapters.getRevenueListETableAdapter getRevenueListETableAdapter;
>>>>>>> 3487230753c025e9025c14d3dcc52402a630eb3b
    }
}