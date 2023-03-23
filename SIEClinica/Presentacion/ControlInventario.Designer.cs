namespace SIEClinica.Presentacion
{
    partial class ControlInventario
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
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            this.PanelBusqueda = new System.Windows.Forms.Panel();
            this.label13 = new System.Windows.Forms.Label();
            this.cbStatusBusqueda = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.dtFechaFin = new System.Windows.Forms.DateTimePicker();
            this.dtFechaIni = new System.Windows.Forms.DateTimePicker();
            this.btnAgregar = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.panel3 = new System.Windows.Forms.Panel();
            this.txtBuscador = new System.Windows.Forms.TextBox();
            this.PanelPaginado = new System.Windows.Forms.Panel();
            this.panel15 = new System.Windows.Forms.Panel();
            this.btnUltimaPagina = new System.Windows.Forms.Button();
            this.btnPrimerPagina = new System.Windows.Forms.Button();
            this.lblPagina = new System.Windows.Forms.Label();
            this.lblTotalPaginas = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.btnPagAnterior = new System.Windows.Forms.Button();
            this.btnPagSiguiente = new System.Windows.Forms.Button();
            this.dataGridViewImageColumn1 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn2 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dataGridViewImageColumn3 = new System.Windows.Forms.DataGridViewImageColumn();
            this.dtgRegistros = new System.Windows.Forms.DataGridView();
            this.Editar = new System.Windows.Forms.DataGridViewImageColumn();
            this.PanelBusqueda.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.PanelPaginado.SuspendLayout();
            this.panel15.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegistros)).BeginInit();
            this.SuspendLayout();
            // 
            // PanelBusqueda
            // 
            this.PanelBusqueda.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.PanelBusqueda.Controls.Add(this.label13);
            this.PanelBusqueda.Controls.Add(this.cbStatusBusqueda);
            this.PanelBusqueda.Controls.Add(this.label9);
            this.PanelBusqueda.Controls.Add(this.label8);
            this.PanelBusqueda.Controls.Add(this.dtFechaFin);
            this.PanelBusqueda.Controls.Add(this.dtFechaIni);
            this.PanelBusqueda.Controls.Add(this.btnAgregar);
            this.PanelBusqueda.Controls.Add(this.pictureBox2);
            this.PanelBusqueda.Controls.Add(this.panel3);
            this.PanelBusqueda.Controls.Add(this.txtBuscador);
            this.PanelBusqueda.Dock = System.Windows.Forms.DockStyle.Top;
            this.PanelBusqueda.Location = new System.Drawing.Point(0, 0);
            this.PanelBusqueda.Name = "PanelBusqueda";
            this.PanelBusqueda.Size = new System.Drawing.Size(1140, 104);
            this.PanelBusqueda.TabIndex = 0;
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.ForeColor = System.Drawing.Color.White;
            this.label13.Location = new System.Drawing.Point(248, 16);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(42, 13);
            this.label13.TabIndex = 41;
            this.label13.Text = "Estatus";
            this.label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // cbStatusBusqueda
            // 
            this.cbStatusBusqueda.FormattingEnabled = true;
            this.cbStatusBusqueda.Items.AddRange(new object[] {
            "Pendiente",
            "Confirmado"});
            this.cbStatusBusqueda.Location = new System.Drawing.Point(296, 13);
            this.cbStatusBusqueda.Name = "cbStatusBusqueda";
            this.cbStatusBusqueda.Size = new System.Drawing.Size(119, 21);
            this.cbStatusBusqueda.TabIndex = 40;
            this.cbStatusBusqueda.TextChanged += new System.EventHandler(this.cbStatusBusqueda_TextChanged);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.ForeColor = System.Drawing.Color.White;
            this.label9.Location = new System.Drawing.Point(33, 46);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(62, 13);
            this.label9.TabIndex = 8;
            this.label9.Text = "Fecha Final";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.ForeColor = System.Drawing.Color.White;
            this.label8.Location = new System.Drawing.Point(28, 21);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(67, 13);
            this.label8.TabIndex = 7;
            this.label8.Text = "Fecha Inicial";
            // 
            // dtFechaFin
            // 
            this.dtFechaFin.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaFin.Location = new System.Drawing.Point(119, 39);
            this.dtFechaFin.Name = "dtFechaFin";
            this.dtFechaFin.Size = new System.Drawing.Size(111, 20);
            this.dtFechaFin.TabIndex = 6;
            this.dtFechaFin.CloseUp += new System.EventHandler(this.dtFechaFin_CloseUp);
            this.dtFechaFin.ValueChanged += new System.EventHandler(this.dtFechaFin_ValueChanged);
            // 
            // dtFechaIni
            // 
            this.dtFechaIni.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtFechaIni.Location = new System.Drawing.Point(119, 14);
            this.dtFechaIni.Name = "dtFechaIni";
            this.dtFechaIni.Size = new System.Drawing.Size(111, 20);
            this.dtFechaIni.TabIndex = 5;
            this.dtFechaIni.CloseUp += new System.EventHandler(this.dtFechaIni_CloseUp);
            this.dtFechaIni.ValueChanged += new System.EventHandler(this.dtFechaIni_ValueChanged);
            // 
            // btnAgregar
            // 
            this.btnAgregar.BackgroundImage = global::SIEClinica.Properties.Resources.mas128;
            this.btnAgregar.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAgregar.FlatAppearance.BorderSize = 0;
            this.btnAgregar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAgregar.Location = new System.Drawing.Point(547, 3);
            this.btnAgregar.Name = "btnAgregar";
            this.btnAgregar.Size = new System.Drawing.Size(116, 98);
            this.btnAgregar.TabIndex = 4;
            this.btnAgregar.TabStop = false;
            this.btnAgregar.UseVisualStyleBackColor = true;
            this.btnAgregar.Click += new System.EventHandler(this.btnAgregar_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::SIEClinica.Properties.Resources.buscar64;
            this.pictureBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.pictureBox2.Location = new System.Drawing.Point(370, 57);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(39, 34);
            this.pictureBox2.TabIndex = 3;
            this.pictureBox2.TabStop = false;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(8)))), ((int)(((byte)(198)))), ((int)(((byte)(91)))));
            this.panel3.Location = new System.Drawing.Point(31, 89);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(333, 2);
            this.panel3.TabIndex = 1;
            // 
            // txtBuscador
            // 
            this.txtBuscador.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.txtBuscador.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.txtBuscador.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBuscador.ForeColor = System.Drawing.Color.White;
            this.txtBuscador.Location = new System.Drawing.Point(31, 64);
            this.txtBuscador.Name = "txtBuscador";
            this.txtBuscador.Size = new System.Drawing.Size(333, 19);
            this.txtBuscador.TabIndex = 0;
            this.txtBuscador.TextChanged += new System.EventHandler(this.txtBuscador_TextChanged);
            // 
            // PanelPaginado
            // 
            this.PanelPaginado.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(39)))), ((int)(((byte)(39)))), ((int)(((byte)(39)))));
            this.PanelPaginado.Controls.Add(this.panel15);
            this.PanelPaginado.Controls.Add(this.flowLayoutPanel1);
            this.PanelPaginado.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.PanelPaginado.Location = new System.Drawing.Point(0, 731);
            this.PanelPaginado.Name = "PanelPaginado";
            this.PanelPaginado.Size = new System.Drawing.Size(1140, 80);
            this.PanelPaginado.TabIndex = 1;
            // 
            // panel15
            // 
            this.panel15.Controls.Add(this.btnUltimaPagina);
            this.panel15.Controls.Add(this.btnPrimerPagina);
            this.panel15.Controls.Add(this.lblPagina);
            this.panel15.Controls.Add(this.lblTotalPaginas);
            this.panel15.Controls.Add(this.label11);
            this.panel15.Controls.Add(this.label10);
            this.panel15.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel15.Location = new System.Drawing.Point(428, 0);
            this.panel15.Name = "panel15";
            this.panel15.Size = new System.Drawing.Size(712, 80);
            this.panel15.TabIndex = 1;
            // 
            // btnUltimaPagina
            // 
            this.btnUltimaPagina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(224)))), ((int)(((byte)(87)))));
            this.btnUltimaPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUltimaPagina.ForeColor = System.Drawing.Color.Blue;
            this.btnUltimaPagina.Location = new System.Drawing.Point(238, 6);
            this.btnUltimaPagina.Name = "btnUltimaPagina";
            this.btnUltimaPagina.Size = new System.Drawing.Size(165, 50);
            this.btnUltimaPagina.TabIndex = 4;
            this.btnUltimaPagina.TabStop = false;
            this.btnUltimaPagina.Text = "Última página";
            this.btnUltimaPagina.UseVisualStyleBackColor = false;
            this.btnUltimaPagina.Click += new System.EventHandler(this.btnUltimaPagina_Click);
            // 
            // btnPrimerPagina
            // 
            this.btnPrimerPagina.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(224)))), ((int)(((byte)(87)))));
            this.btnPrimerPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrimerPagina.ForeColor = System.Drawing.Color.Blue;
            this.btnPrimerPagina.Location = new System.Drawing.Point(409, 6);
            this.btnPrimerPagina.Name = "btnPrimerPagina";
            this.btnPrimerPagina.Size = new System.Drawing.Size(165, 50);
            this.btnPrimerPagina.TabIndex = 5;
            this.btnPrimerPagina.TabStop = false;
            this.btnPrimerPagina.Text = "Primer página";
            this.btnPrimerPagina.UseVisualStyleBackColor = false;
            this.btnPrimerPagina.Click += new System.EventHandler(this.btnPrimerPagina_Click);
            // 
            // lblPagina
            // 
            this.lblPagina.AutoSize = true;
            this.lblPagina.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblPagina.ForeColor = System.Drawing.Color.White;
            this.lblPagina.Location = new System.Drawing.Point(70, 33);
            this.lblPagina.Name = "lblPagina";
            this.lblPagina.Size = new System.Drawing.Size(18, 20);
            this.lblPagina.TabIndex = 3;
            this.lblPagina.Text = "0";
            // 
            // lblTotalPaginas
            // 
            this.lblTotalPaginas.AutoSize = true;
            this.lblTotalPaginas.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTotalPaginas.ForeColor = System.Drawing.Color.White;
            this.lblTotalPaginas.Location = new System.Drawing.Point(161, 33);
            this.lblTotalPaginas.Name = "lblTotalPaginas";
            this.lblTotalPaginas.Size = new System.Drawing.Size(18, 20);
            this.lblTotalPaginas.TabIndex = 2;
            this.lblTotalPaginas.Text = "0";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.DimGray;
            this.label11.Location = new System.Drawing.Point(109, 33);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(27, 20);
            this.label11.TabIndex = 1;
            this.label11.Text = "de";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.DimGray;
            this.label10.Location = new System.Drawing.Point(6, 33);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(58, 20);
            this.label10.TabIndex = 0;
            this.label10.Text = "Página";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.btnPagAnterior);
            this.flowLayoutPanel1.Controls.Add(this.btnPagSiguiente);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Left;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(428, 80);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // btnPagAnterior
            // 
            this.btnPagAnterior.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(224)))), ((int)(((byte)(87)))));
            this.btnPagAnterior.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagAnterior.ForeColor = System.Drawing.Color.Blue;
            this.btnPagAnterior.Location = new System.Drawing.Point(3, 3);
            this.btnPagAnterior.Name = "btnPagAnterior";
            this.btnPagAnterior.Size = new System.Drawing.Size(165, 50);
            this.btnPagAnterior.TabIndex = 1;
            this.btnPagAnterior.TabStop = false;
            this.btnPagAnterior.Text = "Página anterior";
            this.btnPagAnterior.UseVisualStyleBackColor = false;
            this.btnPagAnterior.Click += new System.EventHandler(this.btnPagAnterior_Click);
            // 
            // btnPagSiguiente
            // 
            this.btnPagSiguiente.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(215)))), ((int)(((byte)(224)))), ((int)(((byte)(87)))));
            this.btnPagSiguiente.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPagSiguiente.ForeColor = System.Drawing.Color.Blue;
            this.btnPagSiguiente.Location = new System.Drawing.Point(174, 3);
            this.btnPagSiguiente.Name = "btnPagSiguiente";
            this.btnPagSiguiente.Size = new System.Drawing.Size(165, 50);
            this.btnPagSiguiente.TabIndex = 0;
            this.btnPagSiguiente.TabStop = false;
            this.btnPagSiguiente.Text = "Página siguiente";
            this.btnPagSiguiente.UseVisualStyleBackColor = false;
            this.btnPagSiguiente.Click += new System.EventHandler(this.btnPagSiguiente_Click);
            // 
            // dataGridViewImageColumn1
            // 
            this.dataGridViewImageColumn1.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
            this.dataGridViewImageColumn1.Frozen = true;
            this.dataGridViewImageColumn1.HeaderText = "Eliminar";
            this.dataGridViewImageColumn1.Image = global::SIEClinica.Properties.Resources.borrador;
            this.dataGridViewImageColumn1.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn1.Name = "dataGridViewImageColumn1";
            this.dataGridViewImageColumn1.ReadOnly = true;
            // 
            // dataGridViewImageColumn2
            // 
            this.dataGridViewImageColumn2.Frozen = true;
            this.dataGridViewImageColumn2.HeaderText = "Editar";
            this.dataGridViewImageColumn2.Image = global::SIEClinica.Properties.Resources.lapiz;
            this.dataGridViewImageColumn2.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.dataGridViewImageColumn2.Name = "dataGridViewImageColumn2";
            this.dataGridViewImageColumn2.ReadOnly = true;
            // 
            // dataGridViewImageColumn3
            // 
            this.dataGridViewImageColumn3.HeaderText = "";
            this.dataGridViewImageColumn3.Image = global::SIEClinica.Properties.Resources.carrito_de_compras_1_;
            this.dataGridViewImageColumn3.Name = "dataGridViewImageColumn3";
            this.dataGridViewImageColumn3.ReadOnly = true;
            // 
            // dtgRegistros
            // 
            this.dtgRegistros.AllowUserToAddRows = false;
            this.dtgRegistros.AllowUserToDeleteRows = false;
            this.dtgRegistros.AllowUserToOrderColumns = true;
            this.dtgRegistros.AllowUserToResizeRows = false;
            this.dtgRegistros.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.dtgRegistros.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.dtgRegistros.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            this.dtgRegistros.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Editar});
            this.dtgRegistros.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dtgRegistros.Location = new System.Drawing.Point(0, 104);
            this.dtgRegistros.MultiSelect = false;
            this.dtgRegistros.Name = "dtgRegistros";
            this.dtgRegistros.ReadOnly = true;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            dataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dtgRegistros.RowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dtgRegistros.RowTemplate.DefaultCellStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(29)))), ((int)(((byte)(29)))), ((int)(((byte)(29)))));
            this.dtgRegistros.RowTemplate.DefaultCellStyle.ForeColor = System.Drawing.Color.White;
            this.dtgRegistros.RowTemplate.DefaultCellStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.dtgRegistros.RowTemplate.DefaultCellStyle.SelectionForeColor = System.Drawing.Color.White;
            this.dtgRegistros.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dtgRegistros.Size = new System.Drawing.Size(1140, 627);
            this.dtgRegistros.TabIndex = 41;
            this.dtgRegistros.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dtgRegistros_CellClick);
            // 
            // Editar
            // 
            this.Editar.Frozen = true;
            this.Editar.HeaderText = "";
            this.Editar.Image = global::SIEClinica.Properties.Resources.lapiz;
            this.Editar.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.Editar.Name = "Editar";
            this.Editar.ReadOnly = true;
            // 
            // ControlInventario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.dtgRegistros);
            this.Controls.Add(this.PanelBusqueda);
            this.Controls.Add(this.PanelPaginado);
            this.Name = "ControlInventario";
            this.Size = new System.Drawing.Size(1140, 811);
            this.PanelBusqueda.ResumeLayout(false);
            this.PanelBusqueda.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.PanelPaginado.ResumeLayout(false);
            this.panel15.ResumeLayout(false);
            this.panel15.PerformLayout();
            this.flowLayoutPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dtgRegistros)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel PanelBusqueda;
        private System.Windows.Forms.Panel PanelPaginado;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.TextBox txtBuscador;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Button btnAgregar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button btnPagSiguiente;
        private System.Windows.Forms.Button btnPagAnterior;
        private System.Windows.Forms.Panel panel15;
        private System.Windows.Forms.Label lblPagina;
        private System.Windows.Forms.Label lblTotalPaginas;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btnUltimaPagina;
        private System.Windows.Forms.Button btnPrimerPagina;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn1;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn2;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.DateTimePicker dtFechaFin;
        private System.Windows.Forms.DateTimePicker dtFechaIni;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.ComboBox cbStatusBusqueda;
        private System.Windows.Forms.DataGridViewImageColumn dataGridViewImageColumn3;
        private System.Windows.Forms.DataGridView dtgRegistros;
        private System.Windows.Forms.DataGridViewImageColumn Editar;
    }
}
