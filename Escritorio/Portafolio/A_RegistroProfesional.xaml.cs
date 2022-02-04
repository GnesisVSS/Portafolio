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
using Modelo;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Oracle.ManagedDataAccess.Types;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para RegistroProfesional_admin.xaml
    /// </summary>
    public partial class A_RegistroProfesional : UserControl
    {
        public A_RegistroProfesional()
        {
            InitializeComponent();
            
        }

        private void BtnRegistrarCliente_Click(object sender, RoutedEventArgs e)
        {
            rctangulo.Visibility = Visibility.Visible;
            lblCorreoInicio.Visibility = Visibility.Visible;
            lblPassInicio.Visibility = Visibility.Visible;
            lblTituloInicio.Visibility = Visibility.Visible;
            txtCorreoInicio.Visibility = Visibility.Visible;
            txtPassword.Visibility = Visibility.Visible;
            btnIngresar.Visibility = Visibility.Visible;
            imgGmail.Visibility = Visibility.Visible;
            btnCerrar.Visibility = Visibility.Visible;
            btnMinimizar.Visibility = Visibility.Visible;
            btnMaximizar.Visibility = Visibility.Visible;
        }

        private void CboGenero_SelectionChanged(object sender, SelectionChangedEventArgs e)
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

                OracleCommand comandoValidacionUsuario = new OracleCommand("FN_RUN_REPRESENTANTE ", con);
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
                        MessageBox.Show("El rut ya está registrado como representante");
                    }
                    else
                    {
                        OracleCommand comando = new OracleCommand("sp_profesional ", con);
                        comando.CommandType = System.Data.CommandType.StoredProcedure;
                        comando.Parameters.Add("V_RUNPRF", OracleDbType.Varchar2).Value = txtRunAsociado.Text;
                        comando.Parameters.Add("V_PNOMBREPRF", OracleDbType.Varchar2).Value = txtPrimerNombre.Text;
                        comando.Parameters.Add("V_APELLIDOPATPRF", OracleDbType.Varchar2).Value = txtApellidoPaterno.Text;
                        comando.Parameters.Add("V_APELLIDOMATPRF", OracleDbType.Varchar2).Value = txtApellidoMaterno.Text;
                        comando.Parameters.Add("V_CORREOPRF", OracleDbType.Varchar2).Value = txtCorreo.Text;
                        comando.Parameters.Add("V_TELEFONOPRF", OracleDbType.Varchar2).Value = txtTelefono.Text;
                        comando.Parameters.Add("V_FECHANACPRF", OracleDbType.Varchar2).Value = dpFechaNacimiento.Text;
                        comando.Parameters.Add("V_DIRECCIONPRF", OracleDbType.Varchar2).Value = txtDireccion.Text;
                        comando.Parameters.Add("V_EXPERIENCIAPRF", OracleDbType.Int32).Value = cboExperiencia.SelectedIndex;
                        comando.Parameters.Add("V_FECHACONTRATAPRF", OracleDbType.Varchar2).Value = dpFechaContrato.Text;
                        comando.Parameters.Add("V_PROFESION", OracleDbType.Int32).Value = cboProfesion.SelectedIndex;
                        comando.Parameters.Add("V_PAIS", OracleDbType.Varchar2).Value = cboPais.Text;
                        comando.Parameters.Add("V_JORNADA", OracleDbType.Int32).Value = cboJornada.SelectedIndex;
                        comando.Parameters.Add("V_GENERO", OracleDbType.Int32).Value = cboGenero.SelectedIndex;
                        
                        

                        System.Net.Mail.MailMessage correo = new System.Net.Mail.MailMessage();

                        correo.To.Add(txtCorreo.Text);
                        correo.Subject = "Envío de credenciales";
                        correo.SubjectEncoding = System.Text.Encoding.UTF8;

                        correo.Body = "Usuario: " + txtRunAsociado.Text + "(Sin digito verificador)" + " " + "Contraseña: " + txtRunAsociado.Text;
                        correo.BodyEncoding = System.Text.Encoding.UTF8;
                        correo.IsBodyHtml = true;
                        correo.From = new System.Net.Mail.MailAddress(txtCorreoInicio.Text);

                        System.Net.Mail.SmtpClient cliente = new System.Net.Mail.SmtpClient();

                        cliente.Credentials = new System.Net.NetworkCredential(txtCorreoInicio.Text, txtPassword.Password);

                        cliente.Port = 587;
                        cliente.EnableSsl = true;

                        cliente.Host = "smtp.gmail.com";

                        try
                        {
                            cliente.Send(correo);
                            comando.ExecuteNonQuery();
                            MessageBox.Show("Profesional registrado. Sus credenciales corresponderán a su rut sin digito verificador y como contraseña su rut con digito verificador sin puntos ni guión");
                            Content = new A_RegistroProfesional();
                        }
                        catch (Exception)
                        {

                            MessageBox.Show("Compruebe los campos nuevamente y vuelva a intentar.");
                        }
                    }
                }
                
            }
            catch (Exception ex)
            {

                OracleCommand comandoValidacionCatch = new OracleCommand("FN_RUN_PROFESIONAL ", con);
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
                    MessageBox.Show("Revise los campos ingresados y vuelva a intentarlo");
                }

            }
            con.Close();
        }

        private void txtRunAsociado_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
        }

        private void txtRunAsociado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            rctangulo.Visibility = Visibility.Hidden;
            lblCorreoInicio.Visibility = Visibility.Hidden;
            lblPassInicio.Visibility = Visibility.Hidden;
            lblTituloInicio.Visibility = Visibility.Hidden;
            txtCorreoInicio.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            btnIngresar.Visibility = Visibility.Hidden;
            imgGmail.Visibility = Visibility.Hidden;
            btnCerrar.Visibility = Visibility.Hidden;
            btnMinimizar.Visibility = Visibility.Hidden;
            btnMaximizar.Visibility = Visibility.Hidden;
        }

        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            rctangulo.Visibility = Visibility.Hidden;
            lblCorreoInicio.Visibility = Visibility.Hidden;
            lblPassInicio.Visibility = Visibility.Hidden;
            lblTituloInicio.Visibility = Visibility.Hidden;
            txtCorreoInicio.Visibility = Visibility.Hidden;
            txtPassword.Visibility = Visibility.Hidden;
            btnIngresar.Visibility = Visibility.Hidden;
            imgGmail.Visibility = Visibility.Hidden;
            btnCerrar.Visibility = Visibility.Hidden;
            btnMinimizar.Visibility = Visibility.Hidden;
            btnMaximizar.Visibility = Visibility.Hidden;
        }

        private void dpFechaNacimiento_SelectedDateChanged(object sender, SelectionChangedEventArgs e)
        {
            var anio = DateTime.Now;
            var anioresta = anio.AddYears(-18);
            if (dpFechaNacimiento.SelectedDate > anioresta)
            {
                MessageBox.Show("Error","Seleccione una fecha de nacimiento válida");
            }
        }
    }
}
