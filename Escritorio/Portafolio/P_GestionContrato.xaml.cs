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
    /// Lógica de interacción para GestionContrato_prof.xaml
    /// </summary>
    public partial class P_GestionContrato : UserControl
    {
        public P_GestionContrato()
        {
            InitializeComponent();
           
        }

        private void Boton_confirmacion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtgContratos_Loaded(object sender, RoutedEventArgs e)
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
                OracleCommand cmd = new OracleCommand("FN_GESTION_CONTRATO_PROFESIONAL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Gestion_contrato> lista = new List<Gestion_contrato>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Gestion_contrato rep = new Gestion_contrato();
                    rep.id_contrato = reader.GetInt32(0);
                    rep.run_profesional_asociado = reader.GetString(1);
                    rep.nombre_profesional_asociado = reader.GetString(2);
                    rep.id_asesoria = reader.GetInt32(3);
                    rep.run_representante = reader.GetInt32(4);
                    rep.descripcion_contrato = reader.GetString(5);
                    rep.fecha_pago = reader.GetString(6);
                    rep.cantidad_visitas_a_terreno = reader.GetInt32(7);
                    rep.cantidad_capacitaciones = reader.GetInt32(8);
                    rep.cantidad_asesorías = reader.GetInt32(9);
                    rep.estado_pago = reader.GetString(10);
                    rep.nombre_empresa = reader.GetString(11);
                    lista.Add(rep);
                }

                dgContrato.ItemsSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void btnNotificarPago_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Pago Generado");
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtEmpresa.Text = "";
            CargarGrilla();
        }

        private void btnCancelar2_Click(object sender, RoutedEventArgs e)
        {
            txtRunCliente.Text = "";
            CargarGrilla();
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
                if (txtRunCliente.Text == "")
                {
                    if (txtEmpresa.Text != "")
                    {


                        OracleCommand comando2 = new OracleCommand("FN_BUSCAR_EMPRESA_GESTIONCONTRATO_PROF", con);
                        comando2.CommandType = CommandType.StoredProcedure;
                        OracleParameter output2 = comando2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                        output2.Direction = ParameterDirection.ReturnValue;
                        comando2.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = txtEmpresa.Text;

                        comando2.ExecuteNonQuery();
                        List<Gestion_contrato> lista = new List<Gestion_contrato>();
                        OracleDataReader lector = comando2.ExecuteReader();

                        while (lector.Read())
                        {
                            Gestion_contrato rep = new Gestion_contrato();
                            rep.id_contrato = lector.GetInt32(0);
                            rep.run_profesional_asociado = lector.GetString(1);
                            rep.nombre_profesional_asociado = lector.GetString(2);
                            rep.id_asesoria = lector.GetInt32(3);
                            rep.run_representante = lector.GetInt32(4);
                            rep.descripcion_contrato = lector.GetString(5);
                            rep.fecha_pago = lector.GetString(6);
                            rep.cantidad_visitas_a_terreno = lector.GetInt32(7);
                            rep.cantidad_capacitaciones = lector.GetInt32(8);
                            rep.cantidad_asesorías = lector.GetInt32(9);
                            rep.estado_pago = lector.GetString(10);
                            rep.nombre_empresa = lector.GetString(11);
                            lista.Add(rep);
                        }

                        dgContrato.ItemsSource = lista;
                    }
                    else
                    {
                        MessageBox.Show("No se han encontrado datos relacionados a la búsqueda");
                    }

                }
                else if (txtRunCliente.Text != "" && txtEmpresa.Text != "")
                {
                    OracleCommand comando = new OracleCommand("FN_BUSCAR_EMPRESA_RUTREPRE_GESTIONCONTRATO_PROFESIONAL", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    OracleParameter output2 = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output2.Direction = ParameterDirection.ReturnValue;
                    comando.Parameters.Add("V_RUT", OracleDbType.Int32).Value = Int32.Parse(txtRunCliente.Text);
                    comando.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = txtEmpresa.Text;
                    comando.ExecuteNonQuery();
                    List<Gestion_contrato> lista = new List<Gestion_contrato>();
                    OracleDataReader lector = comando.ExecuteReader();

                    while (lector.Read())
                    {
                        Gestion_contrato rep = new Gestion_contrato();
                        rep.id_contrato = lector.GetInt32(0);
                        rep.run_profesional_asociado = lector.GetString(1);
                        rep.nombre_profesional_asociado = lector.GetString(2);
                        rep.id_asesoria = lector.GetInt32(3);
                        rep.run_representante = lector.GetInt32(4);
                        rep.descripcion_contrato = lector.GetString(5);
                        rep.fecha_pago = lector.GetString(6);
                        rep.cantidad_visitas_a_terreno = lector.GetInt32(7);
                        rep.cantidad_capacitaciones = lector.GetInt32(8);
                        rep.cantidad_asesorías = lector.GetInt32(9);
                        rep.estado_pago = lector.GetString(10);
                        rep.nombre_empresa = lector.GetString(11);
                        lista.Add(rep);
                    }
                    dgContrato.ItemsSource = lista;

                }
                else
                {

                    OracleCommand comando2 = new OracleCommand("FN_BUSCAR_RUTREPRE_GESTIONCONTRATO_PROFESIONAL", con);
                    comando2.CommandType = CommandType.StoredProcedure;
                    OracleParameter output2 = comando2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output2.Direction = ParameterDirection.ReturnValue;
                    comando2.Parameters.Add("V_RUT", OracleDbType.Int32).Value = Int32.Parse(txtRunCliente.Text);
                    comando2.ExecuteNonQuery();
                    List<Gestion_contrato> lista = new List<Gestion_contrato>();
                    OracleDataReader lector = comando2.ExecuteReader();

                    while (lector.Read())
                    {
                        Gestion_contrato rep = new Gestion_contrato();
                        rep.id_contrato = lector.GetInt32(0);
                        rep.run_profesional_asociado = lector.GetString(1);
                        rep.nombre_profesional_asociado = lector.GetString(2);
                        rep.id_asesoria = lector.GetInt32(3);
                        rep.run_representante = lector.GetInt32(4);
                        rep.descripcion_contrato = lector.GetString(5);
                        rep.fecha_pago = lector.GetString(6);
                        rep.cantidad_visitas_a_terreno = lector.GetInt32(7);
                        rep.cantidad_capacitaciones = lector.GetInt32(8);
                        rep.cantidad_asesorías = lector.GetInt32(9);
                        rep.estado_pago = lector.GetString(10);
                        rep.nombre_empresa = lector.GetString(11);
                        lista.Add(rep);

                    }
                    dgContrato.ItemsSource = lista;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void txtRunCliente_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
