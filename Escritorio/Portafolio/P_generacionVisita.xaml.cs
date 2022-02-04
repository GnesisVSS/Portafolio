using Modelo;
using Oracle.ManagedDataAccess.Client;
using Oracle.ManagedDataAccess.Types;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para P_generacionVisita.xaml
    /// </summary>
    public partial class P_generacionVisita : UserControl
    {
        public P_generacionVisita()
        {
            InitializeComponent();
        }

        private void btnAgregarItem_Click(object sender, RoutedEventArgs e)
        {

        }


        private void btnDocumento_Click(object sender, RoutedEventArgs e)
        {

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
                OracleCommand comando = new OracleCommand("SP_VISITAS ", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("v_fecha", OracleDbType.Varchar2).Value = dpFechaVisita.Text;
                comando.Parameters.Add("v_tipo", OracleDbType.Varchar2).Value = txtTipo.Text;
                comando.Parameters.Add("v_empresa", OracleDbType.Varchar2).Value = txtEmpresa.Text;
                comando.ExecuteNonQuery();
                OracleCommand comando2 = new OracleCommand("SP_VISITA_REGISTRO ", con);
                comando2.CommandType = System.Data.CommandType.StoredProcedure;
                comando2.Parameters.Add("V_DESC_1", OracleDbType.Varchar2).Value = DescItem1.Text;
                comando2.Parameters.Add("V_DESC_2", OracleDbType.Varchar2).Value = DescItem2.Text;
                comando2.Parameters.Add("V_DESC_3", OracleDbType.Varchar2).Value = DescItem3.Text;
                comando2.Parameters.Add("V_DESC_EXTRA_1", OracleDbType.Varchar2).Value = DescExtraItem1.Text;
                comando2.Parameters.Add("V_DESC_EXTRA_2", OracleDbType.Varchar2).Value = DescExtraItem2.Text;
                comando2.Parameters.Add("V_DESC_EXTRA_3", OracleDbType.Varchar2).Value = DescExtraItem3.Text;
                comando2.ExecuteNonQuery();
                MessageBox.Show("Visita Registrada.");

                Content = new P_generacionVisita();

            }
            catch (Exception ex)
            {
               
             MessageBox.Show("Debe completar todos los campos");


            }
            con.Close();
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

        private void dgEmpresa_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Rut_empresa_visitas rut = dgEmpresa.SelectedItem as Rut_empresa_visitas;
            if (rut != null)
            {
                string nombreemp = Convert.ToString(rut.rut_empresa);
                txtEmpresa.Text = nombreemp;
                Rut_empresa_visitas nom = new Rut_empresa_visitas();
                txtEmpresa.Text = nombreemp;
            }
                else
                {
                    MessageBox.Show("Algo salio mal");
                }
            
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtEmpresa.Text = "";
            dgEmpresa.Visibility = Visibility.Hidden;
        }

        private void dgEmpresa_Loaded(object sender, RoutedEventArgs e)
        {

        }
    }
}
