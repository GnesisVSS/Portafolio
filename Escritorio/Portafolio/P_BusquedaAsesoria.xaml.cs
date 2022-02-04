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
    /// Lógica de interacción para P_BusquedaAsesoria.xaml
    /// </summary>
    public partial class P_BusquedaAsesoria : UserControl
    {
        public P_BusquedaAsesoria()
        {
            InitializeComponent();
        }

        private void Boton_confirmacion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void dtgAsesorias_Loaded(object sender, RoutedEventArgs e)
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
                OracleCommand cmd = new OracleCommand("FN_LISTAR_ASESORIA", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Listar_asesoria> lista = new List<Listar_asesoria>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Listar_asesoria ase = new Listar_asesoria();
                    ase.idasesoria = reader.GetInt32(0);
                    ase.fechaasesoria = reader.GetDateTime(1);
                    ase.cantaccidentes = reader.GetInt32(2);
                    ase.tasaaccidentes = reader.GetInt32(3);
                    ase.rutemp = reader.GetString(4);
                    ase.valorasesoria = reader.GetInt32(5);
                    ase.runprf = reader.GetString(6);
                    lista.Add(ase);
                }

                dtgAsesorias.ItemsSource = lista;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void btnBuscarNombre_Click(object sender, RoutedEventArgs e)
        {
            dgEmpresa.Visibility = Visibility.Visible;
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

            if (txtEmpresa.Text != "")
            {
                try
                {
                    con.Open();
                    OracleCommand comando = new OracleCommand("FN_BUSCAR_NOMBRE_EMPRESA_PROFESIONAL_VISITAS", con);

                    comando.CommandType = CommandType.StoredProcedure;
                    OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output.Direction = ParameterDirection.ReturnValue;
                    comando.Parameters.Add("v_nombre", txtEmpresa.Text);
                    comando.ExecuteNonQuery();

                    List<Rut_empresa_visitas> lista = new List<Rut_empresa_visitas>();
                    OracleDataReader lector = comando.ExecuteReader();


                    while (lector.Read())
                    {
                        dgEmpresa.Visibility = Visibility.Visible;
                        Rut_empresa_visitas nom = new Rut_empresa_visitas();
                        nom.nombre_empresa = lector.GetString(0);
                        nom.rut_empresa = lector.GetString(1);
                        lista.Add(nom);
                    }
                    dgEmpresa.ItemsSource = lista;

                }
                catch (Exception)
                {
                    MessageBox.Show("Algo ha salido mal");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Debe agregar un valor para poder generar la búsqueda");
            }
        }

        private void dgEmpresa_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void dgEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            dgEmpresa.Visibility = Visibility.Hidden;
            Rut_empresa_visitas rut = dgEmpresa.SelectedItem as Rut_empresa_visitas;
            if (rut != null)
            {
                string nombreemp = Convert.ToString(rut.rut_empresa);
                txtEmpresa.Text = nombreemp;
                Rut_empresa_visitas nom = new Rut_empresa_visitas();
                txtEmpresa.Text = nombreemp;

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

                if (txtEmpresa.Text != "")
                {

                    try
                    {
                        con.Open();
                        OracleCommand cmd = new OracleCommand("FN_LISTAR_ASESORIA_BUSCAR", con);
                        cmd.CommandType = CommandType.StoredProcedure;
                        List<Listar_asesoria> lista = new List<Listar_asesoria>();

                        OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                        output.Direction = ParameterDirection.ReturnValue;
                        cmd.Parameters.Add("V_RUN", txtEmpresa.Text);
                        cmd.ExecuteNonQuery();

                        OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                        while (reader.Read())
                        {
                            Listar_asesoria ase = new Listar_asesoria();
                            ase.idasesoria = reader.GetInt32(0);
                            ase.fechaasesoria = reader.GetDateTime(1);
                            ase.cantaccidentes = reader.GetInt32(2);
                            ase.tasaaccidentes = reader.GetInt32(3);
                            ase.rutemp = reader.GetString(4);
                            ase.valorasesoria = reader.GetInt32(5);
                            ase.runprf = reader.GetString(6);
                            lista.Add(ase);
                        }

                        dtgAsesorias.ItemsSource = lista;
                    }
                    catch (Exception ex)
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
            else
            {
                MessageBox.Show("Algo salio mal");
            }
        }

        private void btnCancelarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            txtEmpresa.Text = "";
            CargarGrilla();
            dgEmpresa.Visibility = Visibility.Hidden;
        }
    }
}
