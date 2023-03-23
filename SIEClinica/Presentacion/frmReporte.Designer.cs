
namespace SIEClinica.Presentacion
{
    partial class frmReporte
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
            this.panelReporte = new System.Windows.Forms.Panel();
            this.reportViewer1 = new Telerik.ReportViewer.WinForms.ReportViewer();
            this.panelReporte.SuspendLayout();
            this.SuspendLayout();
            // 
            // panelReporte
            // 
            this.panelReporte.Controls.Add(this.reportViewer1);
            this.panelReporte.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelReporte.Location = new System.Drawing.Point(0, 0);
            this.panelReporte.Name = "panelReporte";
            this.panelReporte.Size = new System.Drawing.Size(1044, 711);
            this.panelReporte.TabIndex = 60;
            // 
            // reportViewer1
            // 
            this.reportViewer1.AccessibilityKeyMap = null;
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.Size = new System.Drawing.Size(1044, 711);
            this.reportViewer1.TabIndex = 0;
            // 
            // frmReporte
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(1044, 711);
            this.Controls.Add(this.panelReporte);
            this.Name = "frmReporte";
            this.Text = "Reporte";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.panelReporte.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panelReporte;
        private Telerik.ReportViewer.WinForms.ReportViewer reportViewer1;
    }
}