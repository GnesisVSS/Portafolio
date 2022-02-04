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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Oracle.ManagedDataAccess.Types;
using System.Configuration;
using Oracle.ManagedDataAccess.Client;
using Modelo;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para CambioContrasena.xaml
    /// </summary>
    public partial class CambioContrasena : Window
    {
        public CambioContrasena()
        {
            InitializeComponent();
        }

        private void txtRun_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void btnIngresar_Click(object sender, RoutedEventArgs e)
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

            con.Open();

            //Comando de conexión para la funcion de validacion de contraseña
            OracleCommand comando = new OracleCommand("FN_CAMBIO_CONTRASENA ", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add("V_RUT", OracleDbType.Varchar2).Value = txtRun.Text;
            comando.ExecuteNonQuery();
            OracleDataReader lector = ((OracleRefCursor)output.Value).GetDataReader();

            if (lector.Read())
            {
                try
                {
                    OracleCommand comando2 = new OracleCommand("sp_contrasena", con);
                    comando2.CommandType = System.Data.CommandType.StoredProcedure;
                    comando2.Parameters.Add("v_rut", OracleDbType.Varchar2).Value = txtRun.Text;
                    comando2.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = txtPasswordConfirma.Password;
                   

                    if (txtPassword.Password == txtPasswordConfirma.Password)
                    {
                        comando2.ExecuteNonQuery();
                        MessageBox.Show("Contraseña actualizada.");
                        MainWindow main = new MainWindow();
                        main.Show();
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Las contraseñas ingresadas no coinciden");
                    }

                }
                catch (Exception)
                {
                    MessageBox.Show("Debe Completar todos los campos");
                }
            }
            else
            {
                if (txtPassword.Password == "" || txtPasswordConfirma.Password == "" || txtRun.Text == "")
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    MessageBox.Show("No existe el rut ingresado");
                }
                
            }
            
            con.Close();

        }

        private void btnCerrar_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void btnMaximizar_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnMinimizar_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnVolver_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
        }

        private bool _altf4 = false;
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (_altf4)
                e.Cancel = true;
            _altf4 = false;
        }

        private void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.SystemKey == Key.F4 && (Keyboard.IsKeyDown(Key.LeftAlt) || Keyboard.IsKeyDown(Key.RightAlt)))
            {
                _altf4 = true;
            }
        }
    }
}
