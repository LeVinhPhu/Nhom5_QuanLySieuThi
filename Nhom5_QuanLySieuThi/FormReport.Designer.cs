
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
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(800, 450);
            this.reportViewer1.TabIndex = 0;
            // 
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
            // getRevenueListETableAdapter
            // 
            this.getRevenueListETableAdapter.ClearBeforeFill = true;
            // 
            // FormReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.reportViewer1);
            this.Name = "FormReport";
            this.Text = "FormReport";
            this.Load += new System.EventHandler(this.FormReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.QuanLySieuThiDataSet2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.getRevenueListEBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource getRevenueListEBindingSource;
        private QuanLySieuThiDataSet2 QuanLySieuThiDataSet2;
        private QuanLySieuThiDataSet2TableAdapters.getRevenueListETableAdapter getRevenueListETableAdapter;
    }
}