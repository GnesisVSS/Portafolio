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
using Oracle.ManagedDataAccess.Client;
using System.Data;
using Modelo;
using Oracle.ManagedDataAccess.Types;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para PerfilAdmin.xaml
    /// </summary>
    public partial class A_Perfil : UserControl
    {
        public A_Perfil()
        {
            InitializeComponent();

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
                OracleCommand cmd = new OracleCommand("FN_PERFIL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<classPerfil> lista = new List<classPerfil>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    classPerfil per = new classPerfil();
                    per.NOMBRE = reader.GetString(0);
                    per.RUNPRF = reader.GetString(1);
                    per.EDADPRF = reader.GetString(2);
                    per.CORREOPRF = reader.GetString(3);
                    per.TELEFONOPRF = reader.GetString(4);
                    per.FECHANACPRF = reader.GetString(5);
                    per.DIRECCIONPRF = reader.GetString(6);
                    per.EXPERIENCIAPRF = reader.GetString(7);
                    per.FECHACONTRATAPRF = reader.GetString(8);
                    per.CARGO = reader.GetString(9);
                    per.PAISNACIMIENTOPRF = reader.GetString(10);
                    per.JORNADA = reader.GetString(11);
                    per.GENERO = reader.GetString(12);

                    txtNombre.Text = per.NOMBRE;
                    txtRun.Text = per.RUNPRF;
                    txtEdad.Text = per.EDADPRF;
                    txtCorreo.Text = per.CORREOPRF;
                    txtTeñefono.Text = per.TELEFONOPRF;
                    txtNacimiento.Text = per.FECHANACPRF;
                    txtDireccion.Text = per.DIRECCIONPRF;
                    if (per.EXPERIENCIAPRF == "1")
                    {
                        txtExperiencia.Text = "Con experiencia";
                    }
                    else
                    {
                        txtExperiencia.Text = "Sin experiencia";
                    }
                    txtFechaContrato.Text = per.FECHACONTRATAPRF;
                    txtCargo.Text = per.CARGO;
                    txtPais.Text = per.PAISNACIMIENTOPRF;
                    txtJornada.Text = per.JORNADA;
                    txtGenero.Text = per.GENERO;
                }

                
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();

        }

        

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Content = new A_GestionContratos();
        }
    }
}
