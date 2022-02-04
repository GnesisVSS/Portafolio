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
    /// Lógica de interacción para P_BusquedaVisita.xaml
    /// </summary>
    public partial class P_BusquedaVisita : UserControl
    {
        public P_BusquedaVisita()
        {
            InitializeComponent();
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
                OracleCommand cmd = new OracleCommand("fn_visitas_vista_busqueda", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Vista_visita_terreno> lista = new List<Vista_visita_terreno>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Vista_visita_terreno rep = new Vista_visita_terreno();
                    rep.idvisita = reader.GetInt32(0);
                    rep.fechavisita = reader.GetString(1);
                    rep.tipovisitas = reader.GetString(2);
                    rep.estado = reader.GetString(3);
                    rep.rut_empresa = reader.GetString(4);
                    rep.run_profesional_asociado = reader.GetString(5);
                    rep.nombre_empresa = reader.GetString(6);
                    lista.Add(rep);
                }

                dgVisita.ItemsSource = lista;
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
                OracleCommand comando = new OracleCommand("FN_BUSCAR_NOMBRE_EMPRESA_VISITA", con);
                comando.CommandType = CommandType.StoredProcedure;
                OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add("V_NOMBRE", txtEmpresa.Text);
                comando.ExecuteNonQuery();
                List<Vista_visita_terreno> lista = new List<Vista_visita_terreno>();

                OracleDataReader lector = ((OracleRefCursor)output.Value).GetDataReader();

                while (lector.Read())
                {
                    Vista_visita_terreno rep = new Vista_visita_terreno();
                    rep.idvisita = lector.GetInt32(0);
                    rep.fechavisita = lector.GetString(1);
                    rep.tipovisitas = lector.GetString(2);
                    rep.estado = lector.GetString(3);
                    rep.rut_empresa = lector.GetString(4);
                    rep.run_profesional_asociado = lector.GetString(5);
                    rep.nombre_empresa = lector.GetString(6);
                    lista.Add(rep);
                }
                dgVisita.ItemsSource = lista;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
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
                OracleCommand comando = new OracleCommand("FN_BUSCAR_RUT_EMPRESA_VISITA", con);
                comando.CommandType = CommandType.StoredProcedure;
                OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add("V_RUT", txtRunAsociado.Text);
                comando.ExecuteNonQuery();
                List<Vista_visita_terreno> lista = new List<Vista_visita_terreno>();
                OracleDataReader lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Vista_visita_terreno rep = new Vista_visita_terreno();
                    rep.idvisita = lector.GetInt32(0);
                    rep.fechavisita = lector.GetString(1);
                    rep.tipovisitas = lector.GetString(2);
                    rep.estado = lector.GetString(3);
                    rep.rut_empresa = lector.GetString(4);
                    rep.run_profesional_asociado = lector.GetString(5);
                    rep.nombre_empresa = lector.GetString(6);
                    lista.Add(rep);
                }
                dgVisita.ItemsSource = lista;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void btnCancelar2_Click(object sender, RoutedEventArgs e)
        {
            txtRunAsociado.Text = "";
            CargarGrilla();
        }

        private void dgVisita_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void btnCancelarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            txtEmpresa.Text = "";
            CargarGrilla();
        }

        private void dgVisita_Loaded(object sender, RoutedEventArgs e)
        {
            CargarGrilla();
        }
    }
}
