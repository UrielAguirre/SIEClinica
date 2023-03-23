namespace SIEClinica.Presentacion
{
    partial class ControlAltaModificaCita
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.PanelReg = new System.Windows.Forms.Panel();
            this.lblTipoCita = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.cbEstatus = new System.Windows.Forms.ComboBox();
            this.rbCitaRapida = new System.Windows.Forms.RadioButton();
            this.rbCitaAgentada = new System.Windows.Forms.RadioButton();
            this.dtgBusquedaPacientes = new System.Windows.Forms.DataGridView();
            this.Calendario = new System.Windows.Forms.MonthCalendar();
            this.label7 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.dtHoraFin = new System.Windows.Forms.DateTimePicker();
            this.dtHoraIni = new System.Windows.Forms.DateTimePicker();
            this.label4 = new System.Windows.Forms.Label();
            this.cbConsultorio = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.cbMedico = new System.Windows.Forms.ComboBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.txtNombrePaciente = new System.Windows.Forms.TextBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.txtPaciente = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.pbFoto = new System.Windows.Forms.PictureBox();
            this.panel14 = new System.Windows.Forms.Panel();
            this.btnGuardar = new System.Windows.Forms.Button();
            this.btnRegresar = new System.Windows.Forms.Button();
            this.txtEMail = new System.Windows.Forms.TextBox();
            this.panel5 = new System.Windows.Forms.Panel();
            this.txtMotivo = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.PanelReg.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBusquedaPacientes)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).BeginInit();
            this.panel14.SuspendLayout();
            this.SuspendLayout();
            // 
            // PanelReg
            // 
            this.PanelReg.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.PanelReg.Controls.Add(this.lblTipoCita);
            this.PanelReg.Controls.Add(this.label12);
            this.PanelReg.Controls.Add(this.cbEstatus);
            this.PanelReg.Controls.Add(this.rbCitaRapida);
            this.PanelReg.Controls.Add(this.rbCitaAgentada);
            this.PanelReg.Controls.Add(this.dtgBusquedaPacientes);
            this.PanelReg.Controls.Add(this.Calendario);
            this.PanelReg.Controls.Add(this.label7);
            this.PanelReg.Controls.Add(this.label6);
            this.PanelReg.Controls.Add(this.label5);
            this.PanelReg.Controls.Add(this.dtHoraFin);
            this.PanelReg.Controls.Add(this.dtHoraIni);
            this.PanelReg.Controls.Add(this.label4);
            this.PanelReg.Controls.Add(this.cbConsultorio);
            this.PanelReg.Controls.Add(this.label1);
            this.PanelReg.Controls.Add(this.cbMedico);
            this.PanelReg.Controls.Add(this.panel2);
            this.PanelReg.Controls.Add(this.txtNombrePaciente);
            this.PanelReg.Controls.Add(this.panel1);
            this.PanelReg.Controls.Add(this.txtPaciente);
            this.PanelReg.Controls.Add(this.label3);
            this.PanelReg.Controls.Add(this.pbFoto);
            this.PanelReg.Controls.Add(this.panel14);
            this.PanelReg.Controls.Add(this.txtEMail);
            this.PanelReg.Controls.Add(this.panel5);
            this.PanelReg.Controls.Add(this.txtMotivo);
            this.PanelReg.Controls.Add(this.label2);
            this.PanelReg.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PanelReg.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.PanelReg.Location = new System.Drawing.Point(0, 0);
            this.PanelReg.Name = "PanelReg";
            this.PanelReg.Size = new System.Drawing.Size(960, 605);
            this.PanelReg.TabIndex = 4;
            // 
            // lblTipoCita
            // 
            this.lblTipoCita.AutoSize = true;
            this.lblTipoCita.ForeColor = System.Drawing.Color.White;
            this.lblTipoCita.Location = new System.Drawing.Point(749, 26);
            this.lblTipoCita.Name = "lblTipoCita";
            this.lblTipoCita.Size = new System.Drawing.Size(86, 20);
            this.lblTipoCita.TabIndex = 40;
            this.lblTipoCita.Text = "Hora inicial";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.ForeColor = System.Drawing.Color.White;
            this.label12.Location = new System.Drawing.Point(518, 89);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(64, 20);
            this.label12.TabIndex = 39;
            this.label12.Text = "Estatus";
            this.label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbEstatus
            // 
            this.cbEstatus.FormattingEnabled = true;
            this.cbEstatus.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.cbEstatus.Items.AddRange(new object[] {
            "Pendiente",
            "Confirmado"});
            this.cbEstatus.Location = new System.Drawing.Point(593, 86);
            this.cbEstatus.Name = "cbEstatus";
            this.cbEstatus.Size = new System.Drawing.Size(119, 28);
            this.cbEstatus.TabIndex = 38;
            this.cbEstatus.TabStop = false;
            // 
            // rbCitaRapida
            // 
            this.rbCitaRapida.AutoSize = true;
            this.rbCitaRapida.ForeColor = System.Drawing.Color.White;
            this.rbCitaRapida.Location = new System.Drawing.Point(546, 56);
            this.rbCitaRapida.Name = "rbCitaRapida";
            this.rbCitaRapida.Size = new System.Drawing.Size(103, 24);
            this.rbCitaRapida.TabIndex = 37;
            this.rbCitaRapida.Text = "Cita rápida";
            this.rbCitaRapida.UseVisualStyleBackColor = true;
            // 
            // rbCitaAgentada
            // 
            this.rbCitaAgentada.AutoSize = true;
            this.rbCitaAgentada.ForeColor = System.Drawing.Color.White;
            this.rbCitaAgentada.Location = new System.Drawing.Point(546, 26);
            this.rbCitaAgentada.Name = "rbCitaAgentada";
            this.rbCitaAgentada.Size = new System.Drawing.Size(131, 24);
            this.rbCitaAgentada.TabIndex = 36;
            this.rbCitaAgentada.Text = "Cita agendada";
            this.rbCitaAgentada.UseVisualStyleBackColor = true;
            // 
            // dtgBusquedaPacientes
            // 
            this.dtgBusquedaPacientes.AllowUserToAddRows = false;
            this.dtgBusquedaPacientes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dtgBusquedaPacientes.Location = new System.Drawing.Point(17, 313);
            this.dtgBusquedaPacientes.Name = "dtgBusquedaPacientes";
            this.dtgBusquedaPacientes.ReadOnly = true;
            this.dtgBusquedaPacientes.Size = new System.Drawing.Size(520, 150);
            this.dtgBusquedaPacientes.TabIndex = 35;
            this.dtgBusquedaPacientes.Visible = false;
            this.dtgBusquedaPacientes.CellDoubleClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgBusquedaPacientes_CellDoubleClick_1);
            this.dtgBusquedaPacientes.KeyDown += new System.Windows.Forms.KeyEventHandler(this.dtgBusquedaPacientes_KeyDown_1);
            // 
            // Calendario
            // 
            this.Calendario.Location = new System.Drawing.Point(9, 42);
            this.Calendario.Name = "Calendario";
            this.Calendario.TabIndex = 34;
            this.Calendario.TabStop = false;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.ForeColor = System.Drawing.Color.White;
            this.label7.Location = new System.Drawing.Point(399, 42);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(77, 20);
            this.label7.TabIndex = 33;
            this.label7.Text = "Hora final";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.ForeColor = System.Drawing.Color.White;
            this.label6.Location = new System.Drawing.Point(269, 42);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(86, 20);
            this.label6.TabIndex = 32;
            this.label6.Text = "Hora inicial";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.ForeColor = System.Drawing.Color.White;
            this.label5.Location = new System.Drawing.Point(13, 13);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(54, 20);
            this.label5.TabIndex = 31;
            this.label5.Text = "Fecha";
            // 
            // dtHoraFin
            // 
            this.dtHoraFin.CustomFormat = "hh:mm tt";
            this.dtHoraFin.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraFin.Location = new System.Drawing.Point(403, 65);
            this.dtHoraFin.Name = "dtHoraFin";
            this.dtHoraFin.ShowUpDown = true;
            this.dtHoraFin.Size = new System.Drawing.Size(107, 26);
            this.dtHoraFin.TabIndex = 30;
            this.dtHoraFin.TabStop = false;
            // 
            // dtHoraIni
            // 
            this.dtHoraIni.CustomFormat = "hh:mm tt";
            this.dtHoraIni.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtHoraIni.Location = new System.Drawing.Point(273, 65);
            this.dtHoraIni.Name = "dtHoraIni";
            this.dtHoraIni.ShowUpDown = true;
            this.dtHoraIni.Size = new System.Drawing.Size(106, 26);
            this.dtHoraIni.TabIndex = 29;
            this.dtHoraIni.TabStop = false;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.ForeColor = System.Drawing.Color.White;
            this.label4.Location = new System.Drawing.Point(269, 158);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 20);
            this.label4.TabIndex = 27;
            this.label4.Text = "Consultorio";
            this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbConsultorio
            // 
            this.cbConsultorio.FormattingEnabled = true;
            this.cbConsultorio.Location = new System.Drawing.Point(370, 150);
            this.cbConsultorio.Name = "cbConsultorio";
            this.cbConsultorio.Size = new System.Drawing.Size(342, 28);
            this.cbConsultorio.TabIndex = 26;
            this.cbConsultorio.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(295, 119);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(60, 20);
            this.label1.TabIndex = 25;
            this.label1.Text = "Médico";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbMedico
            // 
            this.cbMedico.FormattingEnabled = true;
            this.cbMedico.Location = new System.Drawing.Point(370, 116);
            this.cbMedico.Name = "cbMedico";
            this.cbMedico.Size = new System.Drawing.Size(342, 28);
            this.cbMedico.TabIndex = 24;
            this.cbMedico.TabStop = false;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.White;
            this.panel2.Location = new System.Drawing.Point(224, 242);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(299, 2);
            this.panel2.TabIndex = 7;
            // 
            // txtNombrePaciente
            // 
            this.txtNombrePaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtNombrePaciente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtNombrePaciente.Enabled = false;
            this.txtNombrePaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNombrePaciente.ForeColor = System.Drawing.Color.White;
            this.txtNombrePaciente.Location = new System.Drawing.Point(224, 217);
            this.txtNombrePaciente.Name = "txtNombrePaciente";
            this.txtNombrePaciente.Size = new System.Drawing.Size(299, 19);
            this.txtNombrePaciente.TabIndex = 6;
            this.txtNombrePaciente.TabStop = false;
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Location = new System.Drawing.Point(93, 242);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(108, 2);
            this.panel1.TabIndex = 23;
            // 
            // txtPaciente
            // 
            this.txtPaciente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtPaciente.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtPaciente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtPaciente.ForeColor = System.Drawing.Color.White;
            this.txtPaciente.Location = new System.Drawing.Point(93, 217);
            this.txtPaciente.Name = "txtPaciente";
            this.txtPaciente.Size = new System.Drawing.Size(108, 19);
            this.txtPaciente.TabIndex = 0;
            this.txtPaciente.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtPaciente_KeyDown_1);
            this.txtPaciente.Leave += new System.EventHandler(this.txtPaciente_Leave);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(13, 224);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(71, 20);
            this.label3.TabIndex = 22;
            this.label3.Text = "Paciente";
            // 
            // pbFoto
            // 
            this.pbFoto.Image = global::SIEClinica.Properties.Resources.camara;
            this.pbFoto.Location = new System.Drawing.Point(579, 217);
            this.pbFoto.Name = "pbFoto";
            this.pbFoto.Size = new System.Drawing.Size(133, 140);
            this.pbFoto.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pbFoto.TabIndex = 20;
            this.pbFoto.TabStop = false;
            // 
            // panel14
            // 
            this.panel14.Controls.Add(this.btnGuardar);
            this.panel14.Controls.Add(this.btnRegresar);
            this.panel14.Location = new System.Drawing.Point(56, 405);
            this.panel14.Name = "panel14";
            this.panel14.Size = new System.Drawing.Size(779, 100);
            this.panel14.TabIndex = 19;
            // 
            // btnGuardar
            // 
            this.btnGuardar.BackgroundImage = global::SIEClinica.Properties.Resources.guardar_el_archivo128;
            this.btnGuardar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnGuardar.FlatAppearance.BorderSize = 0;
            this.btnGuardar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGuardar.Location = new System.Drawing.Point(573, 12);
            this.btnGuardar.Name = "btnGuardar";
            this.btnGuardar.Size = new System.Drawing.Size(89, 74);
            this.btnGuardar.TabIndex = 5;
            this.btnGuardar.TabStop = false;
            this.btnGuardar.UseVisualStyleBackColor = true;
            this.btnGuardar.Click += new System.EventHandler(this.btnGuardar_Click_1);
            // 
            // btnRegresar
            // 
            this.btnRegresar.BackgroundImage = global::SIEClinica.Properties.Resources.regreso128;
            this.btnRegresar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnRegresar.FlatAppearance.BorderSize = 0;
            this.btnRegresar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRegresar.Location = new System.Drawing.Point(678, 12);
            this.btnRegresar.Name = "btnRegresar";
            this.btnRegresar.Size = new System.Drawing.Size(89, 74);
            this.btnRegresar.TabIndex = 6;
            this.btnRegresar.TabStop = false;
            this.btnRegresar.UseVisualStyleBackColor = true;
            this.btnRegresar.Click += new System.EventHandler(this.btnRegresar_Click_1);
            // 
            // txtEMail
            // 
            this.txtEMail.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtEMail.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtEMail.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtEMail.ForeColor = System.Drawing.Color.White;
            this.txtEMail.Location = new System.Drawing.Point(129, 375);
            this.txtEMail.Name = "txtEMail";
            this.txtEMail.Size = new System.Drawing.Size(333, 19);
            this.txtEMail.TabIndex = 8;
            // 
            // panel5
            // 
            this.panel5.BackColor = System.Drawing.Color.White;
            this.panel5.Location = new System.Drawing.Point(93, 291);
            this.panel5.Name = "panel5";
            this.panel5.Size = new System.Drawing.Size(430, 2);
            this.panel5.TabIndex = 7;
            // 
            // txtMotivo
            // 
            this.txtMotivo.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtMotivo.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtMotivo.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotivo.ForeColor = System.Drawing.Color.White;
            this.txtMotivo.Location = new System.Drawing.Point(93, 266);
            this.txtMotivo.Name = "txtMotivo";
            this.txtMotivo.Size = new System.Drawing.Size(430, 19);
            this.txtMotivo.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(29, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Motivo";
            this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ControlAltaModificaCita
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.PanelReg);
            this.Name = "ControlAltaModificaCita";
            this.Size = new System.Drawing.Size(960, 605);
            this.PanelReg.ResumeLayout(false);
            this.PanelReg.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgBusquedaPacientes)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pbFoto)).EndInit();
            this.panel14.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelReg;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cbEstatus;
        private System.Windows.Forms.RadioButton rbCitaRapida;
        private System.Windows.Forms.RadioButton rbCitaAgentada;
        private System.Windows.Forms.DataGridView dtgBusquedaPacientes;
        private System.Windows.Forms.MonthCalendar Calendario;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.DateTimePicker dtHoraFin;
        private System.Windows.Forms.DateTimePicker dtHoraIni;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbConsultorio;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cbMedico;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.TextBox txtNombrePaciente;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.TextBox txtPaciente;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.PictureBox pbFoto;
        private System.Windows.Forms.Panel panel14;
        private System.Windows.Forms.Button btnGuardar;
        private System.Windows.Forms.Button btnRegresar;
        private System.Windows.Forms.TextBox txtEMail;
        private System.Windows.Forms.Panel panel5;
        private System.Windows.Forms.TextBox txtMotivo;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblTipoCita;
    }
}
