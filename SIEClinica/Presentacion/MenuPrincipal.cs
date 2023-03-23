using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIEClinica.Presentacion
{
    public partial class MenuPrincipal : Form
    {
        public MenuPrincipal()
        {
            InitializeComponent();
            btnPacientes.Visible = false;
            btnMedicos.Visible = false;
            btnConsultorios.Visible = false;
            btnProductos.Visible = false;
            MenuCatalogoAbierto = 0;
                        
            btnCaja.Visible = false;
            btnCobranza.Visible = false;
            MenuTesoreriaAbierto = 0;

            btnInventario.Visible = false;
            btnCalendario.Visible = false;
            btnCatalogos.Visible = false;
            btnConfiguracion.Visible = false;
            btnTesoreria.Visible = false;

            btnCalendario.Visible = true;
            btnTesoreria.Visible = true;
            btnInventario.Visible = true;
            btnCatalogos.Visible = true;
            btnConfiguracion.Visible = true;

            //btnInventario.Enabled = false;

        }

        int MenuCatalogoAbierto, MenuTesoreriaAbierto;
               
       

        private void btnSalir_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void MenuPrincipal_Load(object sender, EventArgs e)
        {
            panelBienvenida.Dock = DockStyle.Fill;
            MenuCatalogoAbierto = 0;
        }
              
        private void btnCalendario_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            ControlCitaAdd control = new ControlCitaAdd();
            control.Dock = DockStyle.Fill;            
            panelPrincipal.Controls.Add(control);
            seleccionaBotonMenu( btnCalendario );
        }
        private void seleccionaBotonMenu( object botonSeleccionado )
        {
            if ( botonSeleccionado == btnCalendario)
            {
                btnCalendario.BackColor = Color.FromArgb(80, 80, 80);

                btnCatalogos.BackColor = Color.FromArgb(29, 29, 29);
                btnPacientes.BackColor = Color.FromArgb(29, 29, 29);
                btnMedicos.BackColor = Color.FromArgb(29, 29, 29);
                btnConsultorios.BackColor = Color.FromArgb(29, 29, 29);
                btnProductos.BackColor = Color.FromArgb(29, 29, 29);
                btnConfiguracion.BackColor = Color.FromArgb(29, 29, 29);
                btnSalir.BackColor = Color.FromArgb(29, 29, 29);           
            }

            if (botonSeleccionado == btnCatalogos)
            {
                btnCalendario.BackColor = Color.FromArgb(29, 29, 29);

                btnCatalogos.BackColor = Color.FromArgb(80, 80, 80);

                btnPacientes.BackColor = Color.FromArgb(29, 29, 29);
                btnMedicos.BackColor = Color.FromArgb(29, 29, 29);
                btnConsultorios.BackColor = Color.FromArgb(29, 29, 29);
                btnProductos.BackColor = Color.FromArgb(29, 29, 29);
                btnConfiguracion.BackColor = Color.FromArgb(29, 29, 29);
                btnSalir.BackColor = Color.FromArgb(29, 29, 29);
            }

            if (botonSeleccionado == btnPacientes)
            {
                btnCalendario.BackColor = Color.FromArgb(29, 29, 29);

                btnCatalogos.BackColor = Color.FromArgb(29, 29, 29);
                btnPacientes.BackColor = Color.FromArgb(80, 80, 80);
                btnMedicos.BackColor = Color.FromArgb(29, 29, 29);
                btnConsultorios.BackColor = Color.FromArgb(29, 29, 29);
                btnProductos.BackColor = Color.FromArgb(29, 29, 29);
                btnConfiguracion.BackColor = Color.FromArgb(29, 29, 29);
                btnSalir.BackColor = Color.FromArgb(29, 29, 29);
            }

            if (botonSeleccionado == btnMedicos)
            {
                btnCalendario.BackColor = Color.FromArgb(29, 29, 29);

                btnCatalogos.BackColor = Color.FromArgb(29, 29, 29);
                btnPacientes.BackColor = Color.FromArgb(29, 29, 29);
                btnMedicos.BackColor = Color.FromArgb(80, 80, 80);
                btnConsultorios.BackColor = Color.FromArgb(29, 29, 29);
                btnProductos.BackColor = Color.FromArgb(29, 29, 29);
                btnConfiguracion.BackColor = Color.FromArgb(29, 29, 29);
                btnSalir.BackColor = Color.FromArgb(29, 29, 29);
            }

            if (botonSeleccionado == btnConsultorios)
            {
                btnCalendario.BackColor = Color.FromArgb(29, 29, 29);

                btnCatalogos.BackColor = Color.FromArgb(29, 29, 29);
                btnPacientes.BackColor = Color.FromArgb(29, 29, 29);
                btnMedicos.BackColor = Color.FromArgb(29, 29, 29);
                btnConsultorios.BackColor = Color.FromArgb(80, 80, 80);
                btnProductos.BackColor = Color.FromArgb(29, 29, 29);
                btnConfiguracion.BackColor = Color.FromArgb(29, 29, 29);
                btnSalir.BackColor = Color.FromArgb(29, 29, 29);
            }

            if (botonSeleccionado == btnProductos)
            {
                btnCalendario.BackColor = Color.FromArgb(29, 29, 29);

                btnCatalogos.BackColor = Color.FromArgb(29, 29, 29);
                btnPacientes.BackColor = Color.FromArgb(29, 29, 29);
                btnMedicos.BackColor = Color.FromArgb(29, 29, 29);
                btnConsultorios.BackColor = Color.FromArgb(29, 29, 29);
                btnProductos.BackColor = Color.FromArgb(80, 80, 80);
                btnConfiguracion.BackColor = Color.FromArgb(29, 29, 29);
                btnSalir.BackColor = Color.FromArgb(29, 29, 29);
            }

            if (botonSeleccionado == btnConfiguracion)
            {
                btnCalendario.BackColor = Color.FromArgb(29, 29, 29);

                btnCatalogos.BackColor = Color.FromArgb(29, 29, 29);
                btnPacientes.BackColor = Color.FromArgb(29, 29, 29);
                btnMedicos.BackColor = Color.FromArgb(29, 29, 29);
                btnConsultorios.BackColor = Color.FromArgb(29, 29, 29);
                btnProductos.BackColor = Color.FromArgb(29, 29, 29);
                btnConfiguracion.BackColor = Color.FromArgb(80, 80, 80);
                btnSalir.BackColor = Color.FromArgb(29, 29, 29);
            }

            if (botonSeleccionado == btnSalir)
            {
                btnCalendario.BackColor = Color.FromArgb(29, 29, 29);

                btnCatalogos.BackColor = Color.FromArgb(29, 29, 29);
                btnPacientes.BackColor = Color.FromArgb(29, 29, 29);
                btnMedicos.BackColor = Color.FromArgb(29, 29, 29);
                btnConsultorios.BackColor = Color.FromArgb(29, 29, 29);
                btnProductos.BackColor = Color.FromArgb(29, 29, 29);
                btnConfiguracion.BackColor = Color.FromArgb(29, 29, 29);
                btnSalir.BackColor = Color.FromArgb(80, 80, 80);
            }
        }

        private void btnConfiguracion_Click(object sender, EventArgs e)
        {
            seleccionaBotonMenu(btnConfiguracion);
        }
       
        private void btnCatalogos_Click_1(object sender, EventArgs e)
        {
            if (MenuCatalogoAbierto == 0)
            {
                btnPacientes.Visible = true;
                btnMedicos.Visible = true;
                btnConsultorios.Visible = true;
                btnProductos.Visible = true;
                MenuCatalogoAbierto = 1;
                //btnCatalogos.Image = Image.FromFile(@"..\..\Resources\pintura.png");
            }
            else
            {
                btnPacientes.Visible = false;
                btnMedicos.Visible = false;
                btnConsultorios.Visible = false;
                btnProductos.Visible = false;
                MenuCatalogoAbierto = 0;
                //btnCatalogos.Image = Image.FromFile(@"..\..\Resources\rgb.png");            
            }
            seleccionaBotonMenu(btnCatalogos);
        }

        private void btnCaja_Click_1(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            ControlFlujo control = new ControlFlujo();
            control.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(control);

            seleccionaBotonMenu(btnCaja);
        }

        private void btnCobranza_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            ControlCobranza control = new ControlCobranza();
            control.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(control);

            seleccionaBotonMenu(btnTesoreria);
        }

        private void btnInventario_Click_1(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            ControlInventario control = new ControlInventario();
            control.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(control);

            seleccionaBotonMenu(btnInventario);
        }

        private void btnPacientes_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            ControlPacientes control = new ControlPacientes();
            control.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(control);
            seleccionaBotonMenu(btnPacientes);
        }

        private void btnMedicos_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            ControlMedicos control = new ControlMedicos();
            control.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(control);

            seleccionaBotonMenu(btnMedicos);
        }

        private void btnProductos_Click_1(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            ControlProductos control = new ControlProductos();
            control.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(control);
            seleccionaBotonMenu(btnProductos);
        }

        private void btnConsultorios_Click_1(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            ControlConsultorios control = new ControlConsultorios();
            control.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(control);

            seleccionaBotonMenu(btnConsultorios);
        }

        private void btnReportes_Click(object sender, EventArgs e)
        {
            panelPrincipal.Controls.Clear();
            ControlReportes control = new ControlReportes();
            control.Dock = DockStyle.Fill;
            panelPrincipal.Controls.Add(control);

            seleccionaBotonMenu(btnConsultorios);
        }

        private void btnTesoreria_Click(object sender, EventArgs e)
        {
            if (MenuTesoreriaAbierto == 0)
            {
                btnCaja.Visible = true;
                btnCobranza.Visible = true;
                MenuTesoreriaAbierto = 1;
            }
            else
            {
                btnCaja.Visible = false;
                btnCobranza.Visible = false;
                MenuTesoreriaAbierto = 0;
            }
            seleccionaBotonMenu(btnTesoreria);
        }

    }
}
