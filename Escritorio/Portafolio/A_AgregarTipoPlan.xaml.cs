using Oracle.ManagedDataAccess.Client;
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
using Modelo;
using Oracle.ManagedDataAccess.Types;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para AgregarTipoPlan.xaml
    /// </summary>
    public partial class A_AgregarTipoPlan : UserControl
    {
        public A_AgregarTipoPlan()
        {
            InitializeComponent();
            
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
                OracleCommand comando = new OracleCommand("sp_tipo_plan", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = txtTipoPlan.Text;
                comando.Parameters.Add("v_valor", OracleDbType.Int32).Value = Int32.Parse(txtValorPlan.Text);
                comando.Parameters.Add("v_cant_asesoria", OracleDbType.Int32).Value = Int32.Parse(txtCantAsesorias.Text);
                comando.Parameters.Add("v_cant_capacitaciones", OracleDbType.Int32).Value = Int32.Parse(txtCantCapacitaciones.Text);
                comando.Parameters.Add("v_cant_visita", OracleDbType.Int32).Value = Int32.Parse(txtCantVisitas.Text);
                comando.ExecuteNonQuery();
                MessageBox.Show("Tipo de plan registrado");

                Content = new A_AgregarTipoPlan();
                
            }
            catch (Exception)
            {
                MessageBox.Show("No se pudo finalizar la acción solicitada.");
            }
            con.Close();
        }

        private void txtValorPlan_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnCrearPlan_Click(object sender, RoutedEventArgs e)
        {

        }

        private void txtTipoPlan_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }
    }
}
