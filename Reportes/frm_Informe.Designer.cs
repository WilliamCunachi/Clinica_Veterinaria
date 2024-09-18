namespace Clinica_Veterinaria.Reportes
{
    partial class frm_Informe
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.mascotasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clinicaVeterinariaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.clinica_VeterinariaDataSet = new Clinica_Veterinaria.Clinica_VeterinariaDataSet();
            this.citasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.citasTableAdapter = new Clinica_Veterinaria.Clinica_VeterinariaDataSetTableAdapters.CitasTableAdapter();
            this.mascotasTableAdapter = new Clinica_Veterinaria.Clinica_VeterinariaDataSetTableAdapters.MascotasTableAdapter();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.mascotasBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicaVeterinariaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinica_VeterinariaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.citasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // mascotasBindingSource
            // 
            this.mascotasBindingSource.DataMember = "Mascotas";
            this.mascotasBindingSource.DataSource = this.clinicaVeterinariaDataSetBindingSource;
            // 
            // clinicaVeterinariaDataSetBindingSource
            // 
            this.clinicaVeterinariaDataSetBindingSource.DataSource = this.clinica_VeterinariaDataSet;
            this.clinicaVeterinariaDataSetBindingSource.Position = 0;
            // 
            // clinica_VeterinariaDataSet
            // 
            this.clinica_VeterinariaDataSet.DataSetName = "Clinica_VeterinariaDataSet";
            this.clinica_VeterinariaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // citasBindingSource
            // 
            this.citasBindingSource.DataMember = "Citas";
            this.citasBindingSource.DataSource = this.clinicaVeterinariaDataSetBindingSource;
            // 
            // citasTableAdapter
            // 
            this.citasTableAdapter.ClearBeforeFill = true;
            // 
            // mascotasTableAdapter
            // 
            this.mascotasTableAdapter.ClearBeforeFill = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource1.Name = "DataSet1";
            reportDataSource1.Value = this.mascotasBindingSource;
            reportDataSource2.Name = "DataSet2";
            reportDataSource2.Value = this.citasBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "Clinica_Veterinaria.Reportes.Informe.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1093, 486);
            this.reportViewer1.TabIndex = 0;
            // 
            // frm_Informe
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 486);
            this.Controls.Add(this.reportViewer1);
            this.Name = "frm_Informe";
            this.Text = "frm_Informe";
            this.Load += new System.EventHandler(this.frm_Informe_Load);
            ((System.ComponentModel.ISupportInitialize)(this.mascotasBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinicaVeterinariaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.clinica_VeterinariaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.citasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.BindingSource clinicaVeterinariaDataSetBindingSource;
        private Clinica_VeterinariaDataSet clinica_VeterinariaDataSet;
        private System.Windows.Forms.BindingSource citasBindingSource;
        private Clinica_VeterinariaDataSetTableAdapters.CitasTableAdapter citasTableAdapter;
        private System.Windows.Forms.BindingSource mascotasBindingSource;
        private Clinica_VeterinariaDataSetTableAdapters.MascotasTableAdapter mascotasTableAdapter;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
    }
}