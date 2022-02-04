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
    /// Lógica de interacción para CreacionContrato.xaml
    /// </summary>
    public partial class A_CreacionContrato : UserControl
    {
        OracleConnection conn = null;
        public A_CreacionContrato()
        {
            InitializeComponent();
            
        }
        
        private void BtnRegistrarContrato_Click(object sender, RoutedEventArgs e)
        {
            
        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Content = new A_RegistroEmpresa();
        }

        private void boton_confirmacion_Click(object sender, RoutedEventArgs e)
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
                OracleCommand comando = new OracleCommand("sp_contrato ", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("v_descontrato", OracleDbType.Varchar2).Value = "Activo";
                comando.Parameters.Add("v_fechainicio", OracleDbType.Varchar2).Value = dpFechaInicio.Text;
                comando.Parameters.Add("v_rutemp", OracleDbType.Varchar2).Value = txtRutEmp.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Contrato registrado");

                Content = new A_AsesoríayPlan();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido completar la acción solicitada.");
            }
            con.Close();
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
                OracleCommand cmd = new OracleCommand("fn_contrato", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Empresa> lista = new List<Empresa>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Empresa rep = new Empresa();
                    rep.rut_empresa = reader.GetString(0);
                    rep.nombre_empresa = reader.GetString(1);

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

        private void btnVolverBusquedaNombre_Click(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
            txtNombreAsociado.Text = "";
            txtRunAsociado.Text = "";
        } 

        private void btnVolverBusqueda_Click(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
            txtNombreAsociado.Text = "";
            txtRunAsociado.Text = "";
        }

        private void dgEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Empresa emp = dgEmpresa.SelectedItem as Empresa;
            if (emp != null)
            {
                string emprut = Convert.ToString(emp.rut_empresa);
                txtRutEmp.Text = emprut;
            }
        }


        private void btnBuscarRun_Click(object sender, RoutedEventArgs e)
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
                OracleCommand comando = new OracleCommand("FN_BUSCAR_RUT_EMPRESA", con);
                comando.CommandType = CommandType.StoredProcedure;
                OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add("V_RUT", txtRunAsociado.Text);
                comando.ExecuteNonQuery();
                List<Empresa> lista = new List<Empresa>();
                OracleDataReader lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Empresa emp = new Empresa();
                    emp.rut_empresa = lector.GetString(0);
                    emp.nombre_empresa = lector.GetString(1);
                    lista.Add(emp);
                }
                dgEmpresa.ItemsSource = lista;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtNombreAsociado.Text = "";
            CargarGrilla();
        }

        private void btnCancelar2_Click(object sender, RoutedEventArgs e)
        {
            txtRunAsociado.Text = "";
            CargarGrilla();
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
                OracleCommand comando = new OracleCommand("FN_BUSCAR_NOMBRE_EMPRESA", con);
                comando.CommandType = CommandType.StoredProcedure;
                OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add("V_NOMBRE", txtNombreAsociado.Text);
                comando.ExecuteNonQuery();
                List<Empresa> lista = new List<Empresa>();

                OracleDataReader lector = ((OracleRefCursor)output.Value).GetDataReader();

                while (lector.Read())
                {
                    Empresa emp = new Empresa();
                    emp.rut_empresa = lector.GetString(0);
                    emp.nombre_empresa = lector.GetString(1);
                    lista.Add(emp);
                }
                dgEmpresa.ItemsSource = lista;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void txtRunAsociado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void txtNombreAsociado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void dpFechaInicio_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var anio = DateTime.Now;
            if (dpFechaInicio.SelectedDate < anio)
            {
                MessageBox.Show("Error", "Seleccione una fecha válida");
            }
        }
    }
}
