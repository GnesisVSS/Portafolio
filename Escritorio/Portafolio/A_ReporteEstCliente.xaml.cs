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
using Modelo;
using System.Data;
using Oracle.ManagedDataAccess.Types;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para ReporteEstCliente_admin.xaml
    /// </summary>
    public partial class A_ReporteEstCliente : UserControl
    {
        public A_ReporteEstCliente()
        {
            InitializeComponent();
            lblError.Visibility = Visibility.Visible;
            lblError2.Visibility = Visibility.Visible;
            cboCapacitaciones.IsEnabled = false;
        }

        private void CargarCantActividades()
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
                OracleCommand cmd = new OracleCommand("FN_CANTIDAD_ACT_VISITAS", con);

                cmd.CommandType = CommandType.StoredProcedure;
                List<Visita_activa> lista = new List<Visita_activa>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("V_EMPRESA", OracleDbType.Varchar2).Value = lblRunEmpresa.Content.ToString();
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                OracleCommand cmd2 = new OracleCommand("FN_CANTIDAD_ACT_CAPACITACIONES", con);

                cmd2.CommandType = CommandType.StoredProcedure;
                List<Capacitacion_cerradas> lista2 = new List<Capacitacion_cerradas>();

                OracleParameter output2 = cmd2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                cmd2.Parameters.Add("V_EMPRESA", OracleDbType.Varchar2).Value = lblRunEmpresa.Content.ToString();
                cmd2.ExecuteNonQuery();

                OracleDataReader reader2 = ((OracleRefCursor)output2.Value).GetDataReader();

                if (reader.Read())
                {
                    if (reader2.Read())
                    {
                        prueba2.Update(true, true);
                        lblError2.Visibility = Visibility.Hidden;

                        Visita_activa gr = new Visita_activa();
                        Capacitacion_activa gr2 = new Capacitacion_activa();
                        gr.cant = reader.GetInt32(0);
                        gr2.cant = reader2.GetInt32(0);

                        

                        var Visitas = new PieSeries
                        {
                            Title = " Visitas",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(gr.cant) },
                            DataLabels = true
                        };

                        var Capacitaciones = new PieSeries
                        {
                            Title = "Capacitaciones",
                            Values = new ChartValues<ObservableValue> { new ObservableValue(gr2.cant) },
                            DataLabels = true
                        };

                        SeriesCollection = new SeriesCollection();
                        SeriesCollection.Add(Visitas);
                        SeriesCollection.Add(Capacitaciones);
                        prueba2.Update(true, true);
                        prueba2.Series = SeriesCollection;
                        DataContext = this;

                        if (gr.cant == 0 && gr2.cant == 0)
                        {
                            lblError2.Visibility = Visibility.Visible;
                            prueba2.Visibility = Visibility.Hidden;
                        }
                        else
                        {
                            prueba2.Visibility = Visibility.Visible;
                        }
                    }
                   
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al generar carga de datos1");
                dgAsociado.Visibility = Visibility.Hidden;
                ChartActCli.Visibility = Visibility.Hidden;
                Chart.Visibility = Visibility.Hidden;
                prueba2.Visibility = Visibility.Hidden;
                lblError.Visibility = Visibility.Visible;
                lblError2.Visibility = Visibility.Visible;
            }
            con.Close();

            DataContext = this;
        }

        private void CargarCapacitacionCliente()
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
                OracleCommand cmd = new OracleCommand("FN_CAPACITACIONES_ACTIVAS_CLIENTE", con);

                cmd.CommandType = CommandType.StoredProcedure;
                List<Capacitacion_activa> lista = new List<Capacitacion_activa>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("V_EMPRESA", OracleDbType.Varchar2).Value = lblRunEmpresa.Content.ToString();
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();



                OracleCommand cmd2 = new OracleCommand("FN_CAPACITACIONES_CERRADAS_CLIENTE", con);

                cmd2.CommandType = CommandType.StoredProcedure;
                List<Capacitacion_cerradas> lista2 = new List<Capacitacion_cerradas>();

                OracleParameter output2 = cmd2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                cmd2.Parameters.Add("V_EMPRESA", OracleDbType.Varchar2).Value = lblRunEmpresa.Content.ToString();
                cmd2.ExecuteNonQuery();

                OracleDataReader reader2 = ((OracleRefCursor)output2.Value).GetDataReader();


                OracleCommand cmd3 = new OracleCommand("FN_CAPACITACIONES_PENDIENTES_CLIENTE", con);

                cmd3.CommandType = CommandType.StoredProcedure;
                List<Capacitacion_pendiente> lista3 = new List<Capacitacion_pendiente>();

                OracleParameter output3 = cmd3.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output3.Direction = ParameterDirection.ReturnValue;
                cmd3.Parameters.Add("V_EMPRESA", OracleDbType.Varchar2).Value = lblRunEmpresa.Content.ToString();
                cmd3.ExecuteNonQuery();

                OracleDataReader reader3 = ((OracleRefCursor)output3.Value).GetDataReader();


                if (reader.Read())
                {
                    if (reader2.Read())
                    {
                        if (reader3.Read())
                        {
                            lblError.Visibility = Visibility.Hidden;
                            lblError2.Visibility = Visibility.Hidden;
                            Capacitacion_activa gr = new Capacitacion_activa();
                            Capacitacion_cerradas gr2 = new Capacitacion_cerradas();
                            Capacitacion_pendiente gr3 = new Capacitacion_pendiente();
                            gr.cant = reader.GetInt32(0);
                            gr2.cant = reader2.GetInt32(0);
                            gr3.cant = reader3.GetInt32(0);

                            if (gr.cant == 0 && gr2.cant == 0 && gr3.cant == 0)
                            {
                                lblError.Visibility = Visibility.Visible;
                                Chart.Visibility = Visibility.Hidden;
                            }
                            else
                            {
                                Chart.Visibility = Visibility.Visible;

                                cboCapacitaciones.IsEnabled = true;
                                btnActualizar.IsEnabled = true;
                                if (cboCapacitaciones.SelectedIndex == 0)
                                {
                                    Chart.Visibility = Visibility.Visible;
                                    ChartActCli.Visibility = Visibility.Hidden;
                                }
                                else if (cboCapacitaciones.SelectedIndex == 1)
                                {
                                    ChartActCli.Visibility = Visibility.Visible;
                                    Chart.Visibility = Visibility.Hidden;
                                }
                            }

                            var Activas = new PieSeries
                            {
                                Title = " Capacitaciones Activas",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr.cant) },
                                DataLabels = true
                            };

                            var Pendientes = new PieSeries
                            {
                                Title = "Capacitaciones Pendientes",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr2.cant) },
                                DataLabels = true
                            };

                            var Cerradas = new PieSeries
                            {
                                Title = "Capacitaciones Cerradas",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr3.cant) },
                                DataLabels = true
                            };

                            SeriesCollection2 = new SeriesCollection();
                            SeriesCollection2.Add(Activas);
                            SeriesCollection2.Add(Pendientes);
                            SeriesCollection2.Add(Cerradas);
                            Chart.Update(true, true);
                            Chart.Series = SeriesCollection2;
                            DataContext = this;

                            
                        }

                    }


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos2");
                dgAsociado.Visibility = Visibility.Hidden;
                ChartActCli.Visibility = Visibility.Hidden;
                Chart.Visibility = Visibility.Hidden;
                prueba2.Visibility = Visibility.Hidden;
                lblError.Visibility = Visibility.Visible;
                lblError2.Visibility = Visibility.Visible;
            }
            con.Close();
            DataContext = this;
        }

        private void CargarVisitaCliente()
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
                OracleCommand cmd = new OracleCommand("FN_VISITAS_ACTIVAS_CLIENTE", con);

                cmd.CommandType = CommandType.StoredProcedure;
                List<Visita_activa> lista = new List<Visita_activa>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.Parameters.Add("V_EMPRESA", OracleDbType.Varchar2).Value = lblRunEmpresa.Content.ToString();
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();



                OracleCommand cmd2 = new OracleCommand("FN_VISITAS_PENDIENTE_CLIENTE", con);

                cmd2.CommandType = CommandType.StoredProcedure;
                List<Visita_pendiente> lista2 = new List<Visita_pendiente>();

                OracleParameter output2 = cmd2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                cmd2.Parameters.Add("V_EMPRESA", OracleDbType.Varchar2).Value = lblRunEmpresa.Content.ToString();
                cmd2.ExecuteNonQuery();

                OracleDataReader reader2 = ((OracleRefCursor)output2.Value).GetDataReader();


                OracleCommand cmd3 = new OracleCommand("FN_VISITAS_CERRADA_CLIENTE", con);

                cmd3.CommandType = CommandType.StoredProcedure;
                List<Visita_cerrada> lista3 = new List<Visita_cerrada>();

                OracleParameter output3 = cmd3.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output3.Direction = ParameterDirection.ReturnValue;
                cmd3.Parameters.Add("V_EMPRESA", OracleDbType.Varchar2).Value = lblRunEmpresa.Content.ToString();
                cmd3.ExecuteNonQuery();

                OracleDataReader reader3 = ((OracleRefCursor)output3.Value).GetDataReader();


                if (reader.Read())
                {
                    if (reader2.Read())
                    {
                        if (reader3.Read())
                        {
                            ChartActCli.Update(true, true);
                            lblError.Visibility = Visibility.Hidden;
                            lblError2.Visibility = Visibility.Hidden;

                            Visita_activa gr = new Visita_activa();
                            Visita_pendiente gr2 = new Visita_pendiente();
                            Visita_cerrada gr3 = new Visita_cerrada();
                            gr.cant = reader.GetInt32(0);
                            gr2.cant = reader2.GetInt32(0);
                            gr3.cant = reader3.GetInt32(0);

                            if (gr.cant == 0 && gr2.cant == 0 && gr3.cant == 0)
                            {
                                lblError.Visibility = Visibility.Visible;
                                ChartActCli.Visibility = Visibility.Hidden;
                            }
                            else
                            {
                                ChartActCli.Visibility = Visibility.Visible;

                                cboCapacitaciones.IsEnabled = true;
                                btnActualizar.IsEnabled = true;

                                if (cboCapacitaciones.SelectedIndex == 0)
                                {
                                    Chart.Visibility = Visibility.Visible;
                                    ChartActCli.Visibility = Visibility.Hidden;
                                }
                                else if (cboCapacitaciones.SelectedIndex == 1)
                                {
                                    ChartActCli.Visibility = Visibility.Visible;
                                    Chart.Visibility = Visibility.Hidden;
                                }
                            }

                            var Activas = new PieSeries
                            {
                                Title = "Visitas Activas",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr.cant) },
                                DataLabels = true
                            };

                            var Pendientes = new PieSeries
                            {
                                Title = "Visitas Pendientes",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr2.cant) },
                                DataLabels = true
                            };

                            var Cerradas = new PieSeries
                            {
                                Title = "Visitas Cerradas",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr3.cant) },
                                DataLabels = true
                            };

                            SeriesCollection4 = new SeriesCollection();
                            SeriesCollection4.Add(Activas);
                            SeriesCollection4.Add(Pendientes);
                            SeriesCollection4.Add(Cerradas);
                            ChartActCli.Update(true, true);
                            ChartActCli.Series = SeriesCollection4;
                            DataContext = this;

                        }

                    }


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos3");
                dgAsociado.Visibility = Visibility.Hidden;
                ChartActCli.Visibility = Visibility.Hidden;
                Chart.Visibility = Visibility.Hidden;
                prueba2.Visibility = Visibility.Hidden;
                lblError.Visibility = Visibility.Visible;
                lblError2.Visibility = Visibility.Visible;
            }
            con.Close();
            DataContext = this;

        }

        public SeriesCollection SeriesCollection { get; set; }
        public SeriesCollection SeriesCollection2 { get; set; }

        public SeriesCollection SeriesCollection3 { get; set; }

        public SeriesCollection SeriesCollection4 { get; set; }

       

        private void Boton_confirmacion_Click(object sender, RoutedEventArgs e)
        {

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

            if (txtRunAsociado.Text != "")
            {
                try
                {

                    con.Open();
                    OracleCommand comando2 = new OracleCommand("FN_BUSCAR_RUN_REP_REPORTE_CLIENTE", con);
                    comando2.CommandType = CommandType.StoredProcedure;
                    OracleParameter output2 = comando2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output2.Direction = ParameterDirection.ReturnValue;
                    comando2.Parameters.Add("V_RUT", OracleDbType.Varchar2).Value = txtRunAsociado.Text;

                    comando2.ExecuteNonQuery();
                    List<Run_representante> lista = new List<Run_representante>();
                    OracleDataReader lector = comando2.ExecuteReader();


                    while (lector.Read())
                    {
                        dgAsociado.Visibility = Visibility.Visible;
                        
                        Run_representante nom = new Run_representante();
                        nom.nombrerepre = lector.GetString(0);
                        lista.Add(nom);
                    }
                    dgAsociado.ItemsSource = lista;
                }
                catch (Exception)
                {
                    MessageBox.Show("Debe ingresar los campos solicitados");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Debe agregar un valor para poder generar la búsqueda");
                ChartActCli.Visibility = Visibility.Hidden;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            DataContext = this;
            CargarVisitaCliente();
            CargarCapacitacionCliente();
            ChartActCli.Update(true, true);
            Chart.Update(true, true);
            prueba2.Update(true,true);
        }

        private void btnPDF_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                this.IsEnabled = false;
                PrintDialog printDialog = new PrintDialog();
                if (printDialog.ShowDialog() == true)
                {
                    printDialog.PrintVisual(print, "Portafolio");
                }
            }
            finally
            {

                this.IsEnabled = true;
            }
        }

        private void prueba_DataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {

        }

        private void dgAsociado_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Run_representante emp = dgAsociado.SelectedItem as Run_representante;

            if (emp != null)
            {
                string nomrepre = Convert.ToString(emp.nombrerepre);

                txtRunAsociado.Text = nomrepre;

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

                OracleCommand comando2 = new OracleCommand("FN_INFO_REPORTE_CLIENTE", con);
                comando2.CommandType = CommandType.StoredProcedure;
                

                OracleParameter output2 = comando2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                comando2.Parameters.Add("v_nombre", OracleDbType.Varchar2).Value = nomrepre;
                comando2.ExecuteNonQuery();

                OracleDataReader lector2 = ((OracleRefCursor)output2.Value).GetDataReader();



                if (lector2.Read())
                {
                    Info_reporte_cliente cli = new Info_reporte_cliente();
                    cli.runemp = lector2.GetString(0);
                    cli.nombreemp = lector2.GetString(1);
                    cli.nombrerep = lector2.GetString(2);
                    cli.rutrep = lector2.GetInt32(3);

                    lblRunEmpresa.Content = cli.runemp;
                    lblNombreEmpresa.Content = cli.nombreemp;
                    lblRepNombre.Content = cli.nombrerep;
                    lblRepRut.Content = cli.rutrep;

                    CargarVisitaCliente();
                    CargarCapacitacionCliente();
                    CargarCantActividades();

                }

                else
                {
                    MessageBox.Show("No existen datos relacionados");
                    dgAsociado.Visibility = Visibility.Hidden;
                    ChartActCli.Visibility = Visibility.Hidden;
                    Chart.Visibility = Visibility.Hidden;
                    prueba2.Visibility = Visibility.Hidden;
                    lblError.Visibility = Visibility.Visible;
                    lblError2.Visibility = Visibility.Visible;
                }
                con.Close();
                dgAsociado.Visibility = Visibility.Hidden;
               
            }
        }

        private void btnCancelar_Click(object sender, RoutedEventArgs e)
        {
            txtRunAsociado.Text = "";
            lblRunEmpresa.Content = "";
            lblNombreEmpresa.Content = "";
            lblRepNombre.Content = "";
            lblRepRut.Content = "";
             
            dgAsociado.Visibility = Visibility.Hidden;
            ChartActCli.Visibility = Visibility.Hidden;
            Chart.Visibility = Visibility.Hidden;
            prueba2.Visibility = Visibility.Hidden;
            lblError.Visibility = Visibility.Visible;
            lblError2.Visibility = Visibility.Visible;
            cboCapacitaciones.IsEnabled = false;
        }

        private void cboCapacitaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (cboCapacitaciones.SelectedIndex == 0)
            {
                Chart.Update(true, true);
                Chart.Visibility = Visibility.Visible;
                ChartActCli.Visibility = Visibility.Hidden;


            }
            else if (cboCapacitaciones.SelectedIndex == 1)
            {
                Chart.Update(true, true);
                Chart.Visibility = Visibility.Hidden;
                ChartActCli.Visibility = Visibility.Visible;
            }

           
        }

        private void txtRunAsociado_TextChanged(object sender, TextChangedEventArgs e)
        {
            
        }

        private void txtRunAsociado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }
    }
        
}
