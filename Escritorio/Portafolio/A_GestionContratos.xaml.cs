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
    /// Lógica de interacción para GestionContratos_admin.xaml
    /// </summary>
    public partial class A_GestionContratos : UserControl
    {
        public A_GestionContratos()
        {
            InitializeComponent();
        }

        private void BtnNotificarPago_Click(object sender, RoutedEventArgs e)
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
                OracleCommand comando = new OracleCommand("sp_cambio_estado ", con);
                comando.CommandType = System.Data.CommandType.StoredProcedure;
                comando.Parameters.Add("v_id_contrato", OracleDbType.Int32).Value = lbl3.Content;
                comando.Parameters.Add("v_id_asesoria", OracleDbType.Int32).Value = lbl4.Content;
                comando.Parameters.Add("v_estado", OracleDbType.Varchar2).Value = cboEstado.Text;
                comando.Parameters.Add("v_runprf", OracleDbType.Varchar2).Value = lbl1.Content;

                comando.ExecuteNonQuery();
                MessageBox.Show("Actualizado");
            }
            catch (Exception)
            {
                MessageBox.Show("No Actualizado");
            }
            con.Close();

        }

        private void Boton_confirmacion_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("Notificación de pago realizada");
        }

        private void dgContrato_Loaded(object sender, RoutedEventArgs e)
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
                OracleCommand cmd = new OracleCommand("fn_gestion_contrato", con);
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

                        
                        OracleCommand comando2 = new OracleCommand("FN_BUSCAR_EMPRESA_GESTIONCONTRATO", con);
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
                        MessageBox.Show("Error");
                    }

                }
                else if (txtRunCliente.Text != "" && txtEmpresa.Text != "")
                {
                    OracleCommand comando = new OracleCommand("FN_BUSCAR_EMPRESA_RUTREPRE_GESTIONCONTRATO", con);
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

                    OracleCommand comando2 = new OracleCommand("FN_BUSCAR_REPRESENTANTE_GESTIONCONTRATO", con);
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

        private void dgContrato_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Gestion_contrato rep = dgContrato.SelectedItem as Gestion_contrato;
            int id_contrato = Convert.ToInt32(rep.id_contrato);
            int id_asesoria = Convert.ToInt32(rep.id_asesoria);
            string descripcion_contrato = Convert.ToString(rep.descripcion_contrato);
            string run_profesional = Convert.ToString(rep.run_profesional_asociado);

            cboEstado.Text = descripcion_contrato;
            txtProfesional.Text = run_profesional;
            lbl1.Content = run_profesional;
            lbl3.Content = id_contrato;
            lbl4.Content = id_asesoria;

            lblEtiquetaProfesional.Visibility = Visibility.Visible;
            txtProfesional.Visibility = Visibility.Visible;
            btnBuscarEmp.Visibility = Visibility.Visible;
            lblEtiquetaEstado.Visibility = Visibility.Visible;
            cboEstado.Visibility = Visibility.Visible;
        }

        private void btnBuscarEmp_Click(object sender, RoutedEventArgs e)
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

            if (txtProfesional.Text != "")
            {
                try
                {
                    con.Open();
                    OracleCommand comando = new OracleCommand("SELECT pnombreprf || ' ' || apellidopatprf || ' ' || apellidomatprf FROM profesional WHERE runprf || digitoverificadorprf = :run or runprf || '-' || digitoverificadorprf = :run  or runprf = :run  or runprf LIKE( '%' || :run || '%')", con);
                    comando.Parameters.Add(":run", txtProfesional.Text);

                    OracleDataReader lector = comando.ExecuteReader();
                    List<Nombre_profesional> lista = new List<Nombre_profesional>();

                    while (lector.Read())
                    {
                        dgProfesional.Visibility = Visibility.Visible;
                        Nombre_profesional nom = new Nombre_profesional();
                        nom.nombre_profesional = lector.GetString(0);
                        lista.Add(nom);
                    }
                    dgProfesional.ItemsSource = lista;

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

        private void dgProfesional_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {


            Nombre_profesional nombre = dgProfesional.SelectedItem as Nombre_profesional;
            if (nombre != null)
            {
                string nombreemp = Convert.ToString(nombre.nombre_profesional);
                txtProfesional.Text = nombreemp;

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
                OracleCommand comando = new OracleCommand("select runprf from profesional where lower(pnombreprf || ' ' || apellidopatprf || ' ' || apellidomatprf) = lower(:nombre)", con);
                comando.Parameters.Add(":nombre", nombreemp);

                OracleDataReader lector = comando.ExecuteReader();

                if (lector.Read())
                {
                    lbl1.Content = lector.GetString(0);
                    txtProfesional.Text = nombreemp;
                }
                else
                {
                    MessageBox.Show("Algo salio mal");
                }

                con.Close();
            }
        }

        private void txtEmpresa_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            int ascci = Convert.ToInt32(Convert.ToChar(e.Text));

            if (ascci >= 65 && ascci <= 90 || ascci >= 97 && ascci <= 122)

                e.Handled = false;

            else e.Handled = true;
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
