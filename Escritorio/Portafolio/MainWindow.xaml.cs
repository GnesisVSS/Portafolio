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
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Portafolio.ViewModel;
using MaterialDesignThemes.Wpf;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Oracle.ManagedDataAccess.Types;
using Modelo;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            

        }

        private void btnSalir(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        private void Button_SourceUpdated(object sender, DataTransferEventArgs e)
        {

        }
        private async void btnIngresar_Click(object sender, RoutedEventArgs e)
        {
           
            const string _protocol = "TCP";
            const string _schema = "Portafolio";
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

                //Comando de conexión para la funcion de validacion de contraseña
                OracleCommand comandoValidacionPass = new OracleCommand("FN_CONTRASENA_PRF ", con);
                comandoValidacionPass.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter outputPass = comandoValidacionPass.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                outputPass.Direction = ParameterDirection.ReturnValue;
                comandoValidacionPass.Parameters.Add("V_PASS", OracleDbType.Varchar2).Value = txtPassword.Password;
                comandoValidacionPass.ExecuteNonQuery();
                OracleDataReader lectorValidacionPass = ((OracleRefCursor)outputPass.Value).GetDataReader();


                //Comando de validacion para la funcion de validacion de usuario
                OracleCommand comandoValidacionUsuario = new OracleCommand("FN_USUARIO_PRF ", con);
                comandoValidacionUsuario.CommandType = System.Data.CommandType.StoredProcedure;
                OracleParameter outputUsuario = comandoValidacionUsuario.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                outputUsuario.Direction = ParameterDirection.ReturnValue;
                comandoValidacionUsuario.Parameters.Add("V_USUARIO", OracleDbType.Varchar2).Value = txtUsuario.Text;
                comandoValidacionUsuario.ExecuteNonQuery();
                OracleDataReader lectorValidacionUsuario = ((OracleRefCursor)outputUsuario.Value).GetDataReader();

                //Si se leen correctamente el nombre de usuario y contraseña permite ingresar a la vista correspondiente al profesional
                if (lectorValidacionPass.Read())
                {
                    if (lectorValidacionUsuario.Read())
                    {
                        OracleCommand comando = new OracleCommand("FN_INICIO_SESION_PROFESIONAL", con);
                        comando.CommandType = System.Data.CommandType.StoredProcedure;

                        OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                        output.Direction = ParameterDirection.ReturnValue;

                        comando.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = txtUsuario.Text;
                        comando.Parameters.Add("v_pass", OracleDbType.Varchar2).Value = txtPassword.Password;

                        comando.ExecuteNonQuery();

                        OracleDataReader lector = ((OracleRefCursor)output.Value).GetDataReader();

                        if (lector.Read())
                        {
                            
                            //Llamado de procedimiento para ingreso de rut en la tabla de perfil
                            OracleCommand comandoPERFIL = new OracleCommand("sp_perfil ", con);
                            comandoPERFIL.CommandType = System.Data.CommandType.StoredProcedure;
                            comandoPERFIL.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = txtUsuario.Text;
                            comandoPERFIL.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = txtPassword.Password;
                            comandoPERFIL.ExecuteNonQuery();

                            MessageBox.Show("Bienvenido");
                            menuProfesionales menuProfe = new menuProfesionales();
                            menuProfe.Show();
                            this.Close();
                        }
                        else
                        {
                            OracleCommand comando2 = new OracleCommand("FN_INICIO_SESION_ADMIN", con);
                            comando2.CommandType = System.Data.CommandType.StoredProcedure;

                            OracleParameter output2 = comando2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                            output2.Direction = ParameterDirection.ReturnValue;

                            comando2.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = txtUsuario.Text;
                            comando2.Parameters.Add("v_pass", OracleDbType.Varchar2).Value = txtPassword.Password;

                            comando2.ExecuteNonQuery();

                            OracleDataReader lector2 = ((OracleRefCursor)output2.Value).GetDataReader();

                            if (lector2.Read())
                            {
                                OracleCommand comando3 = new OracleCommand("sp_perfil", con);
                                comando3.CommandType = System.Data.CommandType.StoredProcedure;
                                comando3.Parameters.Add("v_usuario", OracleDbType.Varchar2).Value = txtUsuario.Text;
                                comando3.Parameters.Add("v_contrasena", OracleDbType.Varchar2).Value = txtPassword.Password;
                                comando3.ExecuteNonQuery();

                                MessageBox.Show("Bienvenido");
                                A_menuAdministrador menuAdmin = new A_menuAdministrador();
                                menuAdmin.Show();
                                
                                this.Close();
                            }
                        }
                    }

                    else
                    {
                        MessageBox.Show("El nombre de usuario no coincide,intentelo nuevamente.");
                    }

                }
                else
                {
                    //Comando de validacion para la funcion de validacion de usuario
                    OracleCommand comandoValidacionUsuario2 = new OracleCommand("FN_USUARIO_PRF ", con);
                    comandoValidacionUsuario2.CommandType = System.Data.CommandType.StoredProcedure;
                    OracleParameter outputUsuario2 = comandoValidacionUsuario2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    outputUsuario2.Direction = ParameterDirection.ReturnValue;
                    comandoValidacionUsuario2.Parameters.Add("V_USUARIO", OracleDbType.Varchar2).Value = txtUsuario.Text;
                    comandoValidacionUsuario2.ExecuteNonQuery();
                    OracleDataReader lectorValidacionUsuario2 = ((OracleRefCursor)outputUsuario2.Value).GetDataReader();

                    if (lectorValidacionUsuario2.Read())
                    {
                        MessageBox.Show("La contraseña no coincide,intentelo nuevamente.");
                    }
                    else
                    {
                        if (txtPassword.Password == "" || txtUsuario.Text == "")
                        {
                            MessageBox.Show("Debe completar todos los campos");
                        }
                        else
                        {
                            MessageBox.Show("Las credenciales ingresadas no existen, intente nuevamente");
                        }

                    }

                    
                }
                
            }

            catch (Exception ex)
            {

                if (txtPassword.Password=="" || txtUsuario.Text == "")
                {
                    MessageBox.Show("Debe completar todos los campos");
                }
                else
                {
                    MessageBox.Show("Las credenciales ingresadas no existen, intente nuevamente");
                }
                
            }
            con.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
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

        private void btnContrasena_Click(object sender, RoutedEventArgs e)
        {
            CambioContrasena menucontra = new CambioContrasena();
            menucontra.Show();
            this.Close();
        }

        private void txtUsuario_TextChanged(object sender, TextChangedEventArgs e)
        {

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
