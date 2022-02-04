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
    /// Lógica de interacción para GestionActividades_admin.xaml
    /// </summary>
    public partial class A_GestionActividades : UserControl
    {
        public A_GestionActividades()
        {
            InitializeComponent();
        }

        private void DataGrid_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void DataGrid_Loaded(object sender, RoutedEventArgs e)
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
                OracleCommand cmd = new OracleCommand("FN_GESTION_ACT", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Gestion_actividades> lista = new List<Gestion_actividades>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Gestion_actividades ges = new Gestion_actividades();
                    ges.nombre_empleado = reader.GetString(0);
                    ges.nombreempresa = reader.GetString(1);
                    ges.cantidad_asesoria = reader.GetInt32(2);
                    ges.cantidad_visitas = reader.GetInt32(3);
                    ges.cantidad_capacitaciones = reader.GetInt32(4);
                    lista.Add(ges);
                }

                dgActividad.ItemsSource = lista;
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
                if (txtRunProfesional.Text == "")
                {
                    if (txtEmpresa.Text != "")
                    {
                        OracleCommand comando2 = new OracleCommand("FN_BUSCAR_EMPRESA_GESTIONACT", con);
                        comando2.CommandType = CommandType.StoredProcedure;
                        OracleParameter output2 = comando2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                        output2.Direction = ParameterDirection.ReturnValue;
                        comando2.Parameters.Add("V_NOMBRE", OracleDbType.Varchar2).Value = txtEmpresa.Text;

                        comando2.ExecuteNonQuery();
                        List<Gestion_actividades> lista = new List<Gestion_actividades>();
                        OracleDataReader lector = comando2.ExecuteReader();
                        

                        while (lector.Read())
                        {
                            Gestion_actividades ges = new Gestion_actividades();
                            ges.nombre_empleado = lector.GetString(0);
                            ges.nombreempresa = lector.GetString(1);
                            ges.cantidad_asesoria = lector.GetInt32(2);
                            ges.cantidad_visitas = lector.GetInt32(3);
                            ges.cantidad_capacitaciones = lector.GetInt32(4);
                            lista.Add(ges);
                        }
                        dgActividad.ItemsSource = lista;
                    }
                    else
                    {
                        MessageBox.Show("Error");
                    }

                }
                else if (txtRunProfesional.Text != "" && txtEmpresa.Text != "")
                {
                    OracleCommand comando = new OracleCommand("FN_BUSCAR_EMPRESA_Y_EMPLEADO_GESTIONACT", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output.Direction = ParameterDirection.ReturnValue;
                    comando.Parameters.Add("V_NOMBRE_EMPRESA", OracleDbType.Varchar2).Value = txtEmpresa.Text;
                    comando.Parameters.Add("V_NOMBRE_EMPLEADO", OracleDbType.Varchar2).Value = txtRunProfesional.Text;

                    comando.ExecuteNonQuery();


                    List<Gestion_actividades> lista = new List<Gestion_actividades>();
                    OracleDataReader lector = comando.ExecuteReader();
                    

                    while (lector.Read())
                    {
                        Gestion_actividades ges = new Gestion_actividades();
                        ges.nombre_empleado = lector.GetString(0);
                        ges.nombreempresa = lector.GetString(1);
                        ges.cantidad_asesoria = lector.GetInt32(2);
                        ges.cantidad_visitas = lector.GetInt32(3);
                        ges.cantidad_capacitaciones = lector.GetInt32(4);
                        lista.Add(ges);
                    }
                    dgActividad.ItemsSource = lista;

                }
                else
                {

                    OracleCommand comando = new OracleCommand("FN_BUSCAR_EMPLEADO_GESTIONACT", con);
                    comando.CommandType = CommandType.StoredProcedure;
                    OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output.Direction = ParameterDirection.ReturnValue;
                    comando.Parameters.Add("V_NOMBRE_PROFESIONAL", OracleDbType.Varchar2).Value = txtRunProfesional.Text;
                    OracleDataReader lector = comando.ExecuteReader();
                    List<Gestion_actividades> lista = new List<Gestion_actividades>();

                    while (lector.Read())
                    {
                        Gestion_actividades ges = new Gestion_actividades();
                        ges.nombre_empleado = lector.GetString(0);
                        ges.nombreempresa = lector.GetString(1);
                        ges.cantidad_asesoria = lector.GetInt32(2);
                        ges.cantidad_visitas = lector.GetInt32(3);
                        ges.cantidad_capacitaciones = lector.GetInt32(4);
                        lista.Add(ges);
                    }
                    dgActividad.ItemsSource = lista;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void btnCancelar2_Click(object sender, RoutedEventArgs e)
        {
            txtRunProfesional.Text = "";
            CargarGrilla();
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtEmpresa.Text = "";
            CargarGrilla();
        }
    }
}
