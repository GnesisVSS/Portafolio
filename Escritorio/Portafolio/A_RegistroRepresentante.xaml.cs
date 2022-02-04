using Oracle.ManagedDataAccess.Client;
using System.Data;
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
using Oracle.ManagedDataAccess.Types;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para RegistroRepresentante_admin.xaml
    /// </summary>
    public partial class A_RegistroRepresentante : UserControl
    {
        public A_RegistroRepresentante()
        {
            InitializeComponent();
        }
        

        private void BtnRegistrarRepresentante_Click(object sender, RoutedEventArgs e)
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
                //VALIDACIÓN PARA QUE EL RUT DEL REPRESENTANTE NO SEA IGUAL AL RUT DE EMPRESA
                OracleCommand comandoValidacionRun = new OracleCommand("FN_RUN_EMPRESA ", con);
                comandoValidacionRun.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter outputRun = comandoValidacionRun.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                outputRun.Direction = ParameterDirection.ReturnValue;
                comandoValidacionRun.Parameters.Add("V_RUN", OracleDbType.Varchar2).Value = txtRunAsociado.Text;
                comandoValidacionRun.ExecuteNonQuery();
                OracleDataReader lectorValidacionPass = ((OracleRefCursor)outputRun.Value).GetDataReader();

                OracleCommand comandoValidacionUsuario = new OracleCommand("FN_RUN_PROFESIONAL ", con);
                comandoValidacionUsuario.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter outputUsuario = comandoValidacionUsuario.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                outputUsuario.Direction = ParameterDirection.ReturnValue;
                comandoValidacionUsuario.Parameters.Add("V_RUN", OracleDbType.Varchar2).Value = txtRunAsociado.Text;
                comandoValidacionUsuario.ExecuteNonQuery();
                OracleDataReader lectorValidacionUsuario = ((OracleRefCursor)outputUsuario.Value).GetDataReader();

                if (lectorValidacionPass.Read())
                {
                    MessageBox.Show("El rut ya está registrado como empresa");
                }
                else
                {
                    if (lectorValidacionUsuario.Read())
                    {
                        MessageBox.Show("El rut ya está registrado como profesional");
                    }
                    else
                    {
                        OracleCommand comando = new OracleCommand("Sp_representante", con);
                        comando.CommandType = CommandType.StoredProcedure;
                        comando.Parameters.Add("v_rut", OracleDbType.Int32).Value = Int32.Parse(txtRunAsociado.Text);
                        comando.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = txtPrimerNombre.Text;
                        comando.Parameters.Add("v_apellido", OracleDbType.Varchar2).Value = txtApellidoPaterno.Text;
                        comando.Parameters.Add("v_cargo", OracleDbType.Varchar2).Value = txtCargo.Text;
                        comando.Parameters.Add("v_numero", OracleDbType.Varchar2).Value = txtTelefono.Text;
                        comando.Parameters.Add("v_genero", OracleDbType.Int32).Value = cboGenero.SelectedIndex;
                        comando.ExecuteNonQuery();
                        MessageBox.Show("Representante registrado");
                        Content = new A_RegistroEmpresa();
                    }
                }

            }
            catch (Exception ex)
            {

                OracleCommand comandoValidacionCatch = new OracleCommand("FN_RUN_REPRESENTANTE ", con);
                comandoValidacionCatch.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter outputCatch = comandoValidacionCatch.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                outputCatch.Direction = ParameterDirection.ReturnValue;
                comandoValidacionCatch.Parameters.Add("V_RUN", OracleDbType.Varchar2).Value = txtRunAsociado.Text;
                comandoValidacionCatch.ExecuteNonQuery();
                OracleDataReader lectorValidacionCatch = ((OracleRefCursor)outputCatch.Value).GetDataReader();

                if (lectorValidacionCatch.Read())
                {
                    MessageBox.Show("El rut ya existe");
                }
                else
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
            }
        }

        

        private void txtPrimerNombre_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            //Evita que se ingresen numeros en el text box
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        
        //Evita que se ingresen letras en los campos de numero
        private void txtTelefono_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
}
