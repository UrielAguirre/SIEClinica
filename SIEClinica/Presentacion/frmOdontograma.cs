using SIEClinica.Datos;
using SIEClinica.Logica;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SIEClinica.Presentacion
{
    public partial class frmOdontograma : Form
    {
        ArrayList listOfPoints;
        bool PencilDown = false;
        bool statusBorrar = false;
        string Paciente;
        //int pp = 1, cc=1;
        int iniciaTrazo = 0;
        public frmOdontograma( string paciente)
        {
            InitializeComponent();
            listOfPoints = new ArrayList();
            Paciente = paciente;

            ToolTip tp = new ToolTip();

            tp.SetToolTip(rdbRed, "Tinta roja");
            tp.SetToolTip(rdbBlue, "Tinta azul");
            tp.SetToolTip(btnLimpia, "Limpiar todo");
            tp.SetToolTip(btnBorrar, "Borrar último trazo");
            tp.SetToolTip(btnOdontogramaRegresar, "Regresar");
        }

        private void pbOdontograma_MouseMove(object sender, MouseEventArgs e)
        {            
                //txtPunto.Text = MousePosition.X.ToString() + "," + MousePosition.Y.ToString();
                Graphics g = pbOdontograma.CreateGraphics();
                Point points = new Point(e.X, e.Y);
                Color colorSeleccionado;
                if (rdbBlue.Checked)
                {
                    colorSeleccionado = Color.Blue;
                }
                else
                {
                    colorSeleccionado = Color.Red;
                }
                Pen pencil = new Pen(colorSeleccionado, 2);

                if (PencilDown == true)
                {
                    if (listOfPoints.Count > 1)
                    {
                        //Point point1 = new Point()
                        g.DrawLine(pencil, (Point)listOfPoints[listOfPoints.Count - 1], points);
                        listOfPoints.Add(points);
                        //GuardaCoordenas(e.X, e.Y);
                        GuardaCoordenas(listOfPoints[listOfPoints.Count - 1].ToString(), points.ToString());
                    }
                }

                txtPunto.Text = e.X.ToString() + "," + e.Y.ToString();
            
            
        }       

        private void pbOdontograma_MouseDown(object sender, MouseEventArgs e)
        {
            PencilDown = true;
            Point p = new Point(e.X, e.Y);
            listOfPoints.Add(p);            
        }

        private void pbOdontograma_MouseUp(object sender, MouseEventArgs e)
        {
            PencilDown = false;
            
        }

        //private void GuardaCoordenas(int a, int b, int c, int d)
       private void GuardaCoordenas(string a, string b)
        {
            LOdontograma parametros = new LOdontograma();
            DOdontograma funcion = new DOdontograma();

            parametros.Paciente = Paciente;
            parametros.PuntoIniX = 0;
            parametros.PuntoIniY = 0;
            parametros.PuntoFinX = 0;
            parametros.PuntoFinY = 0;
            parametros.PuntoIni = a;
            parametros.PuntoFin = "";
            if (rdbBlue.Checked)
            {
                parametros.Color = "Blue";
            }
            else
            {
                parametros.Color = "Red";
            }
            parametros.Inicia = iniciaTrazo;
            parametros.Finaliza = 0;
            parametros.borrado = 0;
            parametros.Usuario = "SUP";
            parametros.Estacion = "ESTACION01";

            if (funcion.InsertarCoordenas(parametros)==false)
            {
                txtError.Text = "Error";
            }
            else
            {
                txtError.Text = "Ok";
            }
            if (iniciaTrazo == 1)
            {
                iniciaTrazo = 0;
            }
        }
               
        private void Borra()
        {
            try
            {
                int id = 0;
                ConexionBD.Abrir();
                string strSQL = "Select Top 1 * From odontograma Where inicia = 1 And paciente ='" + Paciente + "' Order By Id Desc";
                SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                SqlDataReader registro = cmd.ExecuteReader();

                if (registro.Read())
                {
                    id = Convert.ToInt32(registro["id"].ToString());
                   
                }
                registro.Close();
                cmd.Dispose();
                if(id > 0)
                {
                    SqlCommand cmd1 = new SqlCommand("Delete From odontograma Where paciente = '" + Paciente + "' And id >= " + id, ConexionBD.conectar);
                    cmd1.ExecuteNonQuery();
                    pbOdontograma.Invalidate();
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                ConexionBD.Cerrar();
            }
            
            
        }

        private void Limpia()
        {
            try
            {
                ConexionBD.Abrir();
                SqlCommand cmd1 = new SqlCommand("Delete From odontograma Where paciente = '" + Paciente + "'", ConexionBD.conectar);
                cmd1.ExecuteNonQuery();
                pbOdontograma.Invalidate();              

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + " " + ex.StackTrace);
            }
            finally
            {
                ConexionBD.Cerrar();
            }


        }

        private void pbOdontograma_Paint(object sender, PaintEventArgs e)
        {
            Graphics g;
            g = e.Graphics; //OJO:obtenemos el grafico de los argumentos del evento
            //g.Clear(Color.LightGreen);
            
            try
            {
               // MessageBox.Show("si");
                int a = 0, b = 0, c = 0, d = 0, i = 0;
                ConexionBD.Abrir();
                string strSQL = "Select SubSTring(PuntoIni, 4, CharIndex(',',PuntoIni,0) - 4) As PIniA, SubSTring(PuntoIni, CharIndex('Y',PuntoIni,0) + 2, Len(PuntoIni) - (CharIndex('Y',PuntoIni,0) + 2) ) As PIniB, " +
                       //"SubSTring(PuntoFin, 4, CharIndex(',',PuntoFin,0) - 4) As PFinA, SubSTring(PuntoFin, CharIndex('Y',PuntoFin,0) + 2, Len(PuntoFin) - (CharIndex('Y',PuntoFin,0) + 2) ) As PFinB, " +
                       "Color, inicia " +
                       "From Odontograma Where paciente = '" + Paciente + "'";
                //SqlCommand cmd = new SqlCommand(strSQL, ConexionBD.conectar);
                //cmd.CommandType = CommandType.Text;
                //SqlDataReader registros = cmd.ExecuteReader();
                Color colorSeleccionado;
                SqlDataAdapter da = new SqlDataAdapter(strSQL,ConexionBD.conectar); 
                DataTable dt = new DataTable();
                da.Fill(dt);
                int iSuma = 1;
                for(i = 0; i < dt.Rows.Count-1; i++)
                {
                    
                    if (dt.Rows[i]["Color"].ToString() == "Blue")
                    {
                        colorSeleccionado = Color.Blue;
                    }
                    else
                    {
                        colorSeleccionado = Color.Red;
                    }
                    Pen lapiz = new Pen(colorSeleccionado, 2);

                    if (Convert.ToInt32(dt.Rows[i]["inicia"].ToString()) == 1)
                    {
                        a = Convert.ToInt32(dt.Rows[i]["PIniA"].ToString());
                        b = Convert.ToInt32(dt.Rows[i]["PIniB"].ToString());

                        if ((i + iSuma) > dt.Rows.Count)
                        {
                            iSuma = 0;
                        }
                       
                        c = Convert.ToInt32(dt.Rows[i + iSuma]["PIniA"].ToString());
                        d = Convert.ToInt32(dt.Rows[i + iSuma]["PIniB"].ToString());
                        g.DrawLine(lapiz, a, b, c, d);
                    }
                    else
                    {
                        a = c;
                        b = d;

                        if ((i + iSuma) > dt.Rows.Count)
                        {
                            iSuma = 0;
                        }
                        if (Convert.ToInt32(dt.Rows[i + iSuma]["inicia"].ToString()) != 1)
                        {
                            c = Convert.ToInt32(dt.Rows[i + iSuma]["PIniA"].ToString());
                            d = Convert.ToInt32(dt.Rows[i + iSuma]["PIniB"].ToString());
                            g.DrawLine(lapiz, a, b, c, d);
                        }
                    }
                        
                    
                    if (i < 5)
                    {
                        // MessageBox.Show("a = " + a + ", b = " + b + ", c = " + c + ", d= " + d);
                    }
                    // PintaOdontograma(a, b, c, d);
                   
                        
                  
                    
                    //registros.NextResult();
                }
                //MessageBox.Show(i.ToString());
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.StackTrace);
                MessageBox.Show(ex.Message + " " + ex.StackTrace);

            }
            finally
            {
                ConexionBD.Cerrar();
            }
        }

        private void pbOdontograma_Click(object sender, EventArgs e)
        {
            iniciaTrazo = 1;
        }               

        private void btnOdontogramaRegresar_Click_1(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void btnBorrar_Click_1(object sender, EventArgs e)
        {
            Borra();
        }

        private void btnLimpia_Click(object sender, EventArgs e)
        {
            Limpia();
        }
    }
}
