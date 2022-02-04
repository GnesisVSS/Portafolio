using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Data;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Modelo;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para RegistroEmpresa_admin.xaml
    /// </summary>
    public partial class A_RegistroEmpresa : UserControl
    {
        OracleConnection conn = null;

        public A_RegistroEmpresa()
        {
            InitializeComponent();

            const string _protocol = "TCP";
            const string _schema = "portafolio";
            const string _pswSchema = "1234";
            const string _host = "localhost";
            const string _port = "1521";
            const string _serviceName = "";

            const string _cnnString = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=" + _protocol + ")(HOST=" + _host + ")"
                                 + "(PORT=" + _port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + _serviceName + ")))";

            var oracleConnectionStringBuilder = new OracleConnectionStringBuilder
            {
                DataSource = _cnnString,
                UserID = _schema,
                Password = _pswSchema
            };

            string cnnStringFormat2 = "Data Source=" + _cnnString + ";User Id=" + _schema + ";Password=" + _pswSchema;
            OracleConnection con = new OracleConnection(oracleConnectionStringBuilder.ToString());


            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("FN_COMUNA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Tipo_plan> lista = new List<Tipo_plan>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Comuna rep = new Comuna();
                    rep.comuna = reader.GetString(0);
                    cboComuna.Items.Add(rep.comuna);

                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }


        private void BtnRegistrarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Content = new A_RegistroRepresentante();
        }
        

        private void dgEmpresa_Loaded(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
        }


        private void CargarGrilla()
        {
            const string _protocol = "TCP";
            const string _schema = "portafolio";
            const string _pswSchema = "1234";
            const string _host = "localhost";
            const string _port = "1521";
            const string _serviceName = "";

            const string _cnnString = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=" + _protocol + ")(HOST=" + _host + ")"
                                 + "(PORT=" + _port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + _serviceName + ")))";

            var oracleConnectionStringBuilder = new OracleConnectionStringBuilder
            {
                DataSource = _cnnString,
                UserID = _schema,
                Password = _pswSchema
            };

            string cnnStringFormat2 = "Data Source=" + _cnnString + ";User Id=" + _schema + ";Password=" + _pswSchema;
            OracleConnection con = new OracleConnection(oracleConnectionStringBuilder.ToString());


            try
            {
                con.Open();
                OracleCommand cmd = new OracleCommand("fn_representante",con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Representante> lista = new List<Representante>();

                OracleParameter output = cmd.Parameters.Add("l_cursor",OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read()) {
                    Representante rep = new Representante();
                    rep.rut_representante = reader.GetInt32(0);
                    rep.nombre_representante = reader.GetString(1);

                    lista.Add(rep);
                }

                dgEmpresa.ItemsSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            const string _protocol = "TCP";
            const string _schema = "portafolio";
            const string _pswSchema = "1234";
            const string _host = "localhost";
            const string _port = "1521";
            const string _serviceName = "";

            const string _cnnString = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=" + _protocol + ")(HOST=" + _host + ")"
                                 + "(PORT=" + _port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + _serviceName + ")))";


            var oracleConnectionStringBuilder = new OracleConnectionStringBuilder
            {
                DataSource = _cnnString,
                UserID = _schema,
                Password = _pswSchema
            };

            string cnnStringFormat2 = "Data Source=" + _cnnString + ";User Id=" + _schema + ";Password=" + _pswSchema;
            OracleConnection con = new OracleConnection(oracleConnectionStringBuilder.ToString());

            try
            {
                con.Open();
                OracleCommand comando2 = new OracleCommand("FN_BUSCAR_RUN_REP_REGISTROEMPRESA", con);
                comando2.CommandType = CommandType.StoredProcedure;
                OracleParameter output2 = comando2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                comando2.Parameters.Add("V_RUT", OracleDbType.Int32).Value = Int32.Parse(txtRunAsociado.Text);

                comando2.ExecuteNonQuery();
                List<Representante> lista = new List<Representante>();
                OracleDataReader lector = comando2.ExecuteReader();


                while (lector.Read())
                {
                    Representante rep = new Representante();
                    rep.rut_representante = lector.GetInt32(0);
                    rep.nombre_representante = lector.GetString(1);
                    lista.Add(rep);
                }
                dgEmpresa.ItemsSource = lista;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();

        }

            private void boton_confirmacion_Click(object sender, RoutedEventArgs e){

            const string _protocol = "TCP";
            const string _schema = "portafolio";
            const string _pswSchema = "1234";
            const string _host = "localhost";
            const string _port = "1521";
            const string _serviceName = "";

            const string _cnnString = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=" + _protocol + ")(HOST=" + _host + ")"
                                 + "(PORT=" + _port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + _serviceName + ")))";

            var oracleConnectionStringBuilder = new OracleConnectionStringBuilder
            {
                DataSource = _cnnString,
                UserID = _schema,
                Password = _pswSchema
            };

            string cnnStringFormat2 = "Data Source=" + _cnnString + ";User Id=" + _schema + ";Password=" + _pswSchema;
            OracleConnection con = new OracleConnection(oracleConnectionStringBuilder.ToString());

            try
            {
                con.Open();


                //VALIDACIÓN PARA QUE EL RUT DEL REPRESENTANTE NO SEA IGUAL AL RUT DE EMPRESA
                OracleCommand comandoValidacionRun = new OracleCommand("FN_RUN_PROFESIONAL ", con);
                comandoValidacionRun.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter outputRun = comandoValidacionRun.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                outputRun.Direction = ParameterDirection.ReturnValue;
                comandoValidacionRun.Parameters.Add("V_RUN", OracleDbType.Varchar2).Value = txtRutEmpresa.Text;
                comandoValidacionRun.ExecuteNonQuery();
                OracleDataReader lectorValidacionPass = ((OracleRefCursor)outputRun.Value).GetDataReader();

                OracleCommand comandoValidacionUsuario = new OracleCommand("FN_RUN_REPRESENTANTE ", con);
                comandoValidacionUsuario.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter outputUsuario = comandoValidacionUsuario.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                outputUsuario.Direction = ParameterDirection.ReturnValue;
                comandoValidacionUsuario.Parameters.Add("V_RUN", OracleDbType.Varchar2).Value = txtRutEmpresa.Text;
                comandoValidacionUsuario.ExecuteNonQuery();
                OracleDataReader lectorValidacionUsuario = ((OracleRefCursor)outputUsuario.Value).GetDataReader();

                if (lectorValidacionPass.Read())
                {
                    MessageBox.Show("El rut ya está registrado como profesional");
                }
                else
                {
                    if (lectorValidacionUsuario.Read())
                    {
                        MessageBox.Show("El rut ya está registrado como representante");
                    }
                    else
                    {
                        OracleCommand comando = new OracleCommand("sp_empresa ", con);
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.Parameters.Add("v_rut", OracleDbType.Varchar2).Value = txtRutEmpresa.Text;
                        comando.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = txtNombreEmpresa.Text;
                        comando.Parameters.Add("v_direccion", OracleDbType.Varchar2).Value = txtDireccion.Text;
                        comando.Parameters.Add("v_telefono", OracleDbType.Int32).Value = Int32.Parse(txtTelefono.Text);
                        comando.Parameters.Add("v_correo", OracleDbType.Varchar2).Value = txtCorreo.Text;
                        comando.Parameters.Add("v_comuna", OracleDbType.Int32).Value = cboComuna.SelectedIndex;
                        if (cboRubro.SelectedIndex != 4)
                        {
                            comando.Parameters.Add("v_rubro", OracleDbType.Varchar2).Value = cboRubro.Text;
                        }
                        else
                        {
                            comando.Parameters.Add("v_rubro", OracleDbType.Varchar2).Value = txtOtroRubro.Text;
                        }

                        comando.Parameters.Add("v_rut_repre", OracleDbType.Int32).Value = Int32.Parse(txtRutRep.Text);
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Empresa registrada.");

                        Content = new A_CreacionContrato();
                    }
                }
               
            }
            catch (Exception ex)
            {
                OracleCommand comandoValidacionCatch = new OracleCommand("FN_RUN_PROFESIONAL ", con);
                comandoValidacionCatch.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter outputCatch = comandoValidacionCatch.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                outputCatch.Direction = ParameterDirection.ReturnValue;
                comandoValidacionCatch.Parameters.Add("V_RUN", OracleDbType.Varchar2).Value = txtRutEmpresa.Text;
                comandoValidacionCatch.ExecuteNonQuery();
                OracleDataReader lectorValidacionCatch= ((OracleRefCursor)outputCatch.Value).GetDataReader();

                if (lectorValidacionCatch.Read())
                {
                    MessageBox.Show("El rut ya existe");
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }

               
            }
            con.Close();

        }

        private void btnVolverBusqueda_Click(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
            txtNombreAsociado.Text = "";
            txtRunAsociado.Text = "";
        }

        private void btnBuscarNombre_Click(object sender, RoutedEventArgs e)
        {
            const string _protocol = "TCP";
            const string _schema = "portafolio";
            const string _pswSchema = "1234";
            const string _host = "localhost";
            const string _port = "1521";
            const string _serviceName = "";

            const string _cnnString = "(DESCRIPTION=(ADDRESS_LIST=(ADDRESS=(PROTOCOL=" + _protocol + ")(HOST=" + _host + ")"
                                 + "(PORT=" + _port + ")))(CONNECT_DATA=(SERVER=DEDICATED)(SERVICE_NAME=" + _serviceName + ")))";


            var oracleConnectionStringBuilder = new OracleConnectionStringBuilder
            {
                DataSource = _cnnString,
                UserID = _schema,
                Password = _pswSchema
            };

            string cnnStringFormat2 = "Data Source=" + _cnnString + ";User Id=" + _schema + ";Password=" + _pswSchema;
            OracleConnection con = new OracleConnection(oracleConnectionStringBuilder.ToString());

            try
            {

                con.Open();
                OracleCommand comando2 = new OracleCommand("FN_BUSCAR_NOMBRE_REP_REGISTROEMPRESA", con);
                comando2.CommandType = CommandType.StoredProcedure;
                OracleParameter output2 = comando2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                comando2.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = txtNombreAsociado.Text;

                comando2.ExecuteNonQuery();
                List<Representante> lista = new List<Representante>();
                OracleDataReader lector = comando2.ExecuteReader();

                while (lector.Read())
                {
                    Representante rep = new Representante();
                    rep.rut_representante = lector.GetInt32(0);
                    rep.nombre_representante = lector.GetString(1);
                    lista.Add(rep);
                }
                dgEmpresa.ItemsSource = lista;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void btnVolverBusquedaNombre_Click(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
            txtNombreAsociado.Text = "";
            txtRunAsociado.Text = "";
        }

        private void dgEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Representante rep = dgEmpresa.SelectedItem as Representante;
            if (rep != null)
            {
                string reprut = Convert.ToString(rep.rut_representante);
                txtRutRep.Text = reprut;
            }
        }

        private void txtRutEmpresa_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNombreEmpresa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void cboRubro_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboRubro.SelectedIndex == 4)
            {
                lblOtro.Visibility = Visibility.Visible;
                txtOtroRubro.Visibility = Visibility.Visible;
            }
        }
    }
}
