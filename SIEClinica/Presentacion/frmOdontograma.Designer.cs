
namespace SIEClinica.Presentacion
{
    partial class frmOdontograma
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtError = new System.Windows.Forms.TextBox();
            this.txtPunto = new System.Windows.Forms.TextBox();
            this.btnLimpia = new System.Windows.Forms.Button();
            this.btnOdontogramaRegresar = new System.Windows.Forms.Button();
            this.rdbRed = new System.Windows.Forms.RadioButton();
            this.rdbBlue = new System.Windows.Forms.RadioButton();
            this.btnBorrar = new System.Windows.Forms.Button();
            this.pbOdontograma = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOdontograma)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.panel1.Controls.Add(this.pbOdontograma);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.panel1.ForeColor = System.Drawing.Color.Black;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(510, 623);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.panel2.Controls.Add(this.btnLimpia);
            this.panel2.Controls.Add(this.btnOdontogramaRegresar);
            this.panel2.Controls.Add(this.txtError);
            this.panel2.Controls.Add(this.txtPunto);
            this.panel2.Controls.Add(this.rdbRed);
            this.panel2.Controls.Add(this.rdbBlue);
            this.panel2.Controls.Add(this.btnBorrar);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel2.Location = new System.Drawing.Point(0, 512);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(510, 111);
            this.panel2.TabIndex = 4;
            // 
            // txtError
            // 
            this.txtError.Location = new System.Drawing.Point(694, 50);
            this.txtError.Name = "txtError";
            this.txtError.Size = new System.Drawing.Size(100, 20);
            this.txtError.TabIndex = 4;
            // 
            // txtPunto
            // 
            this.txtPunto.Location = new System.Drawing.Point(694, 14);
            this.txtPunto.Name = "txtPunto";
            this.txtPunto.Size = new System.Drawing.Size(100, 20);
            this.txtPunto.TabIndex = 1;
            // 
            // btnLimpia
            // 
            this.btnLimpia.BackgroundImage = global::SIEClinica.Properties.Resources.nuevo_documento32;
            this.btnLimpia.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.btnLimpia.FlatAppearance.BorderSize = 0;
            this.btnLimpia.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnLimpia.Location = new System.Drawing.Point(3, 51);
            this.btnLimpia.Name = "btnLimpia";
            this.btnLimpia.Size = new System.Drawing.Size(86, 42);
            this.btnLimpia.TabIndex = 8;
            this.btnLimpia.UseVisualStyleBackColor = true;
            this.btnLimpia.Click += new System.EventHandler(this.btnLimpia_Click);
            // 
            // btnOdontogramaRegresar
            // 
            this.btnOdontogramaRegresar.BackgroundImage = global::SIEClinica.Properties.Resources.regreso128;
            this.btnOdontogramaRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnOdontogramaRegresar.FlatAppearance.BorderSize = 0;
            this.btnOdontogramaRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnOdontogramaRegresar.Location = new System.Drawing.Point(409, 14);
            this.btnOdontogramaRegresar.Name = "btnOdontogramaRegresar";
            this.btnOdontogramaRegresar.Size = new System.Drawing.Size(89, 74);
            this.btnOdontogramaRegresar.TabIndex = 7;
            this.btnOdontogramaRegresar.TabStop = false;
            this.btnOdontogramaRegresar.UseVisualStyleBackColor = true;
            this.btnOdontogramaRegresar.Click += new System.EventHandler(this.btnOdontogramaRegresar_Click_1);
            // 
            // rdbRed
            // 
            this.rdbRed.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.rdbRed.BackgroundImage = global::SIEClinica.Properties.Resources.rojo24;
            this.rdbRed.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rdbRed.ForeColor = System.Drawing.Color.Red;
            this.rdbRed.Location = new System.Drawing.Point(118, 57);
            this.rdbRed.Name = "rdbRed";
            this.rdbRed.Size = new System.Drawing.Size(93, 37);
            this.rdbRed.TabIndex = 5;
            this.rdbRed.UseVisualStyleBackColor = false;
            // 
            // rdbBlue
            // 
            this.rdbBlue.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.rdbBlue.BackgroundImage = global::SIEClinica.Properties.Resources.azul24;
            this.rdbBlue.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.rdbBlue.Checked = true;
            this.rdbBlue.ForeColor = System.Drawing.Color.Black;
            this.rdbBlue.Location = new System.Drawing.Point(118, 8);
            this.rdbBlue.Name = "rdbBlue";
            this.rdbBlue.Size = new System.Drawing.Size(90, 42);
            this.rdbBlue.TabIndex = 4;
            this.rdbBlue.TabStop = true;
            this.rdbBlue.UseVisualStyleBackColor = false;
            // 
            // btnBorrar
            // 
            this.btnBorrar.BackgroundImage = global::SIEClinica.Properties.Resources.borrador24;
            this.btnBorrar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnBorrar.FlatAppearance.BorderSize = 0;
            this.btnBorrar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnBorrar.Location = new System.Drawing.Point(3, 0);
            this.btnBorrar.Name = "btnBorrar";
            this.btnBorrar.Size = new System.Drawing.Size(86, 42);
            this.btnBorrar.TabIndex = 3;
            this.btnBorrar.UseVisualStyleBackColor = true;
            this.btnBorrar.Click += new System.EventHandler(this.btnBorrar_Click_1);
            // 
            // pbOdontograma
            // 
            this.pbOdontograma.BackgroundImage = global::SIEClinica.Properties.Resources.OdontogramaPNG;
            this.pbOdontograma.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pbOdontograma.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbOdontograma.Location = new System.Drawing.Point(0, 0);
            this.pbOdontograma.Name = "pbOdontograma";
            this.pbOdontograma.Size = new System.Drawing.Size(510, 623);
            this.pbOdontograma.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pbOdontograma.TabIndex = 0;
            this.pbOdontograma.TabStop = false;
            this.pbOdontograma.Click += new System.EventHandler(this.pbOdontograma_Click);
            this.pbOdontograma.Paint += new System.Windows.Forms.PaintEventHandler(this.pbOdontograma_Paint);
            this.pbOdontograma.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbOdontograma_MouseDown);
            this.pbOdontograma.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbOdontograma_MouseMove);
            this.pbOdontograma.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbOdontograma_MouseUp);
            // 
            // frmOdontograma
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(26)))), ((int)(((byte)(26)))), ((int)(((byte)(26)))));
            this.ClientSize = new System.Drawing.Size(510, 623);
            this.ControlBox = false;
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frmOdontograma";
            this.ShowIcon = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Odontograma";
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pbOdontograma)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pbOdontograma;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnOdontogramaRegresar;
        private System.Windows.Forms.TextBox txtError;
        private System.Windows.Forms.TextBox txtPunto;
        private System.Windows.Forms.RadioButton rdbRed;
        private System.Windows.Forms.RadioButton rdbBlue;
        private System.Windows.Forms.Button btnBorrar;
        private System.Windows.Forms.Button btnLimpia;
    }
}