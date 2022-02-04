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
using Portafolio.ViewModel;
using MaterialDesignThemes.Wpf;
using System.Data;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Modelo;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para Plan.xaml
    /// </summary>
    public partial class A_Plan : UserControl
    {
        public A_Plan()
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
                OracleCommand cmd = new OracleCommand("FN_TIPO_PLAN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Tipo_plan> lista = new List<Tipo_plan>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Tipo_plan rep = new Tipo_plan();
                    rep.idtipoplan = reader.GetString(0);
                    cboTipoPlan.Items.Add(rep.idtipoplan);
                    
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();

        }
        
        private void BtnBuscar_Click(object sender, RoutedEventArgs e)
        {
            
        }

       

        private void txtValorFinal_TextChanged(object sender, TextChangedEventArgs e)
        {
            
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
                OracleCommand comando = new OracleCommand("sp_plan", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("v_id_plan", OracleDbType.Varchar2).Value = cboTipoPlan.SelectedIndex + 1;
                comando.Parameters.Add("v_id_asesoria", OracleDbType.Int32).Value = Int32.Parse(txtAsesoria.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("Plan asociado exitosamente");
            }
            catch (Exception)
            {
                MessageBox.Show("No se ha podido finalizar la acción solicitada.");
            }
            con.Close();
            Content = new A_Plan();
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
                OracleCommand cmd = new OracleCommand("FN_ASESORIA_LISTA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Asesoria> lista = new List<Asesoria>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Asesoria rep = new Asesoria();
                    rep.id = reader.GetInt32(0);
                    rep.rut_emp = reader.GetString(1);
                    rep.nombre_emp = reader.GetString(2);

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
            btnBuscarNombre.IsEnabled = true;
            btnBuscar.IsEnabled = true;

        }

        private void btnBuscarNombre_Click(object sender, RoutedEventArgs e)
        {
            btnBuscar.IsEnabled = false;
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
                OracleCommand comando2 = new OracleCommand("FN_BUSCAREMPRESA_PLAN", con);
                comando2.CommandType = CommandType.StoredProcedure;
                OracleParameter output2 = comando2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                comando2.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = txtNombreAsociado.Text;

                comando2.ExecuteNonQuery();
                List<Asesoria> lista = new List<Asesoria>();
                OracleDataReader lector = comando2.ExecuteReader();

                while (lector.Read())
                {
                    Asesoria emp = new Asesoria();
                    emp.id = lector.GetInt32(0);
                    emp.rut_emp = lector.GetString(1);
                    emp.nombre_emp = lector.GetString(2);
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

        private void btnVolverBusqueda_Click(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
            txtNombreAsociado.Text = "";
            txtRunAsociado.Text = "";
            btnBuscar.IsEnabled = true;
            btnBuscarNombre.IsEnabled = true;
        }

        private void btnBuscar_Click(object sender, RoutedEventArgs e)
        {
            btnBuscarNombre.IsEnabled = false;
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
                OracleCommand comando = new OracleCommand("FN_BUSCAR_RUNEMPRESA_PLAN", con);
                comando.CommandType = CommandType.StoredProcedure;
                OracleParameter output2 = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add("V_RUT", OracleDbType.Varchar2).Value = txtRunAsociado.Text;

                comando.ExecuteNonQuery();
                List<Asesoria> lista = new List<Asesoria>();
                OracleDataReader lector = comando.ExecuteReader();

                while (lector.Read())
                {
                    Asesoria emp = new Asesoria();
                    emp.id = lector.GetInt32(0);
                    emp.rut_emp = lector.GetString(1);
                    emp.nombre_emp = lector.GetString(2);
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

        private void dgEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Asesoria emp = dgEmpresa.SelectedItem as Asesoria;
            string emprut = Convert.ToString(emp.id);
            txtAsesoria.Text = emprut;
        }

        private void btnCargar_Click(object sender, RoutedEventArgs e)
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
                OracleCommand cmd = new OracleCommand("FN_VALOR_PLAN", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Valor_plan> lista = new List<Valor_plan>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("V_IDTIPOPLAN", cboTipoPlan.SelectedIndex+1);
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Valor_plan valor = new Valor_plan();
                    valor.valor = reader.GetInt32(0);
                    txtValorFinal.Text = valor.valor.ToString();
                }

            }
            catch (Exception ex)
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

        private void btnCrearPlan_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
