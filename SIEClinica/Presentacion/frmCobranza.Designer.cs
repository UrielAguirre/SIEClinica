namespace SIEClinica.Presentacion
{
    partial class frmCobranza
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFecha = new System.Windows.Forms.DateTimePicker();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtImporte = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panel9 = new System.Windows.Forms.Panel();
            this.txtConcepto = new System.Windows.Forms.TextBox();
            this.label18 = new System.Windows.Forms.Label();
            this.optAbono = new System.Windows.Forms.RadioButton();
            this.optCargo = new System.Windows.Forms.RadioButton();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.btnGuardar);
            this.panel1.Controls.Add(this.btnRegresar);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.dtFecha);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.txtImporte);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.panel9);
            this.panel1.Controls.Add(this.txtConcepto);
            this.panel1.Controls.Add(this.label18);
            this.panel1.Controls.Add(this.optAbono);
            this.panel1.Controls.Add(this.optCargo);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(483, 251);
            this.panel1.TabIndex = 1;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::SIEClinica.Properties.Resources.guardar_el_archivo128;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(269, 165);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(92, 74);
            this.btnGuardar.TabIndex = 44;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackgroundImage = global::SIEClinica.Properties.Resources.regreso128;
            this.btnRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Location = new System.Drawing.Point(374, 165);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(92, 74);
            this.btnRegresar.TabIndex = 45;
            this.btnRegresar.TabStop = false;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(42, 29);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 20);
            this.label2.TabIndex = 43;
            this.label2.Text = "Fecha";
            // 
            // dtFecha
            // 
            this.dtFecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFecha.Location = new System.Drawing.Point(112, 22);
            this.dtFecha.Name = "dtFecha";
            this.dtFecha.Size = new System.Drawing.Size(108, 26);
            this.dtFecha.TabIndex = 42;
            this.dtFecha.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(150, 130);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(108, 2);
            this.panel2.TabIndex = 41;
            // 
            // txtImporte
            // 
            this.txtImporte.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtImporte.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtImporte.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtImporte.ForeColor = System.Drawing.Color.White;
            this.txtImporte.Location = new System.Drawing.Point(150, 105);
            this.txtImporte.Name = "txtImporte";
            this.txtImporte.Size = new System.Drawing.Size(108, 19);
            this.txtImporte.TabIndex = 1;
            this.txtImporte.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtImporte_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(56, 112);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 40;
            this.label1.Text = "Importe";
            // 
            // panel9
            // 
            this.panel9.BackColor = System.Drawing.Color.White;
            this.panel9.Location = new System.Drawing.Point(150, 86);
            this.panel9.Name = "panel9";
            this.panel9.Size = new System.Drawing.Size(108, 2);
            this.panel9.TabIndex = 38;
            // 
            // txtConcepto
            // 
            this.txtConcepto.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtConcepto.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtConcepto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtConcepto.ForeColor = System.Drawing.Color.White;
            this.txtConcepto.Location = new System.Drawing.Point(150, 61);
            this.txtConcepto.Name = "txtConcepto";
            this.txtConcepto.Size = new System.Drawing.Size(108, 19);
            this.txtConcepto.TabIndex = 0;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.ForeColor = System.Drawing.Color.White;
            this.label18.Location = new System.Drawing.Point(3, 68);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(117, 20);
            this.label18.TabIndex = 37;
            this.label18.Text = "Forma de pago";
            // 
            // optAbono
            // 
            this.optAbono.AutoSize = true;
            this.optAbono.ForeColor = System.Drawing.Color.White;
            this.optAbono.Location = new System.Drawing.Point(322, 54);
            this.optAbono.Name = "optAbono";
            this.optAbono.Size = new System.Drawing.Size(74, 24);
            this.optAbono.TabIndex = 4;
            this.optAbono.Text = "Abono";
            this.optAbono.UseVisualStyleBackColor = true;
            // 
            // optCargo
            // 
            this.optCargo.AutoSize = true;
            this.optCargo.ForeColor = System.Drawing.Color.White;
            this.optCargo.Location = new System.Drawing.Point(322, 24);
            this.optCargo.Name = "optCargo";
            this.optCargo.Size = new System.Drawing.Size(70, 24);
            this.optCargo.TabIndex = 3;
            this.optCargo.Text = "Cargo";
            this.optCargo.UseVisualStyleBackColor = true;
            // 
            // frmCobranza
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.ClientSize = new System.Drawing.Size(483, 251);
            this.Controls.Add(this.panel1);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmCobranza";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Cargos y abonos";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFecha;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtImporte;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel9;
        private System.Windows.Forms.TextBox txtConcepto;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.RadioButton optAbono;
        private System.Windows.Forms.RadioButton optCargo;
    }
}