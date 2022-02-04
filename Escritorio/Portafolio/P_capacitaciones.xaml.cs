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
    /// Lógica de interacción para p_capacitaciones.xaml
    /// </summary>
    public partial class P_capacitaciones : UserControl
    {
        public P_capacitaciones()
        {
            InitializeComponent();
        }
       
        private void Boton_confirmacion_Click(object sender, RoutedEventArgs e)
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
                OracleCommand comando = new OracleCommand("sp_capacitacion ", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("v_fecha", OracleDbType.Varchar2).Value = dtFecha.Text;
                comando.Parameters.Add("v_hora", OracleDbType.Varchar2).Value = cboHora.Text;
                comando.Parameters.Add("v_minuto", OracleDbType.Varchar2).Value = cboMinuto.Text;
                comando.Parameters.Add("v_cant_asistentes", OracleDbType.Int32).Value = Int32.Parse(txtAsistente.Text);
                comando.Parameters.Add("v_nombreemp", OracleDbType.Varchar2).Value = txtRunEmpresa.Text;
                comando.ExecuteNonQuery();
                MessageBox.Show("Capacitación registrada exitosamente");

                Content = new P_capacitaciones();
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido completar la acción solicitada.");
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
            if (txtRunEmpresa.Text != "")
            {
                try
                {
                    con.Open();
                    OracleCommand comando = new OracleCommand("FN_BUSCAR_CAPACITACIONES", con);

                    comando.CommandType = CommandType.StoredProcedure;
                    OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output.Direction = ParameterDirection.ReturnValue;
                    comando.Parameters.Add("V_NOMBRE", txtRunEmpresa.Text);
                    comando.ExecuteNonQuery();

                    List<Rut_empresa> lista = new List<Rut_empresa>();
                    OracleDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        dgEmpresa.Visibility = Visibility.Visible;
                        Rut_empresa emp = new Rut_empresa();
                        emp.nombre = lector.GetString(0);
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
            else
            {
                MessageBox.Show("Debe agregar un valor para poder generar la búsqueda");
            }
               
        }

        private void btnPago_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dgEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            Rut_empresa nombre = dgEmpresa.SelectedItem as Rut_empresa;
            if (nombre != null)
            {
                string nombreemp = Convert.ToString(nombre.nombre);
                txtRunEmpresa.Text = nombreemp;
            }

            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtRunEmpresa.Text = "";
            dgEmpresa.Visibility = Visibility.Hidden;
        }

        private void txtAsistente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dtFecha_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var anio = DateTime.Now;
            if (dtFecha.SelectedDate < anio)
            {
                MessageBox.Show("Error", "Seleccione una fecha válida");
            }
        }

        private void txtRunEmpresa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }
    }
}
