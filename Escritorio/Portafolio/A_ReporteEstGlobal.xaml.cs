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
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.Defaults;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para ReporteEstGlobal_admin.xaml
    /// </summary>
    public partial class A_ReporteEstGlobal : UserControl
    {
        public A_ReporteEstGlobal()
        {
           
            InitializeComponent();
            ClientesActivos();
            ClientesInactivos();
            CargarPie();
            CargarCantidadClientes();
            CargarCantidadProfesionales();
            CargarCapacitacion();
            CargarVisita();
            CargarCantidadCapacitaciones();
            CargarCantidadVisitas();
            CargarCantidadContratos();
        }

        private void CargarCantidadContratos()
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
                OracleCommand cmd = new OracleCommand("FN_CONTRATOS_TOTAL ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Grafico> lista = new List<Grafico>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                if (reader.Read())
                {
                    cantidadClientes cant = new cantidadClientes();
                    cant.cant = reader.GetInt32(0);
                    lblCantContrato.Content = cant.cant;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void CargarCantidadVisitas()
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
                OracleCommand cmd = new OracleCommand("FN_VISITAS_TOTAL ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Grafico> lista = new List<Grafico>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                if (reader.Read())
                {
                    cantidadClientes cant = new cantidadClientes();
                    cant.cant = reader.GetInt32(0);
                    lblCantVisita.Content = cant.cant;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void CargarCantidadCapacitaciones()
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
                OracleCommand cmd = new OracleCommand("FN_CAPACITACIONES_TOTAL ", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Grafico> lista = new List<Grafico>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                if (reader.Read())
                {
                    cantidadClientes cant = new cantidadClientes();
                    cant.cant = reader.GetInt32(0);
                    lblCantCap.Content = cant.cant;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void ClientesInactivos()
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
                OracleCommand cmd = new OracleCommand("FN_CLIENTES_INACTIVOS  ", con);

                cmd.CommandType = CommandType.StoredProcedure;
                List<Clientes_activos> lista = new List<Clientes_activos>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();


                OracleCommand cmd2 = new OracleCommand("FN_CONTRATOS_TOTAL", con);

                cmd2.CommandType = CommandType.StoredProcedure;
                List<cantidadClientes> lista2 = new List<cantidadClientes>();

                OracleParameter output2 = cmd2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                cmd2.ExecuteNonQuery();

                OracleDataReader reader2 = ((OracleRefCursor)output2.Value).GetDataReader();

                if (reader.Read())
                {
                    if (reader2.Read())
                    {
                        Clientes_inactivos gr = new Clientes_inactivos();
                        cantidadClientes gr2 = new cantidadClientes();
                        gr.cant = reader.GetInt32(0);
                        gr2.cant = reader2.GetInt32(0);

                        CantClientesInac.Value = gr.cant;
                        CantClientesInac.From = 0;
                        CantClientesInac.To = gr2.cant;
                    }

                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void CargarVisita()
        {
            Chart2.Visibility = Visibility.Hidden;
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
                OracleCommand cmd = new OracleCommand("FN_VISITAS_ACTIVAS", con);

                cmd.CommandType = CommandType.StoredProcedure;
                List<Visita_activa> lista = new List<Visita_activa>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();



                OracleCommand cmd2 = new OracleCommand("FN_VISITAS_PENDIENTE", con);

                cmd2.CommandType = CommandType.StoredProcedure;
                List<Visita_pendiente> lista2 = new List<Visita_pendiente>();

                OracleParameter output2 = cmd2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                cmd2.ExecuteNonQuery();

                OracleDataReader reader2 = ((OracleRefCursor)output2.Value).GetDataReader();


                OracleCommand cmd3 = new OracleCommand("FN_VISITAS_CERRADA", con);

                cmd3.CommandType = CommandType.StoredProcedure;
                List<Visita_cerrada> lista3 = new List<Visita_cerrada>();

                OracleParameter output3 = cmd3.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output3.Direction = ParameterDirection.ReturnValue;
                cmd3.ExecuteNonQuery();

                OracleDataReader reader3 = ((OracleRefCursor)output3.Value).GetDataReader();


                if (reader.Read())
                {
                    if (reader2.Read())
                    {
                        if (reader3.Read())
                        {
                            Visita_activa gr = new Visita_activa();
                            Visita_pendiente gr2 = new Visita_pendiente();
                            Visita_cerrada gr3 = new Visita_cerrada();
                            gr.cant = reader.GetInt32(0);
                            gr2.cant = reader2.GetInt32(0);
                            gr3.cant = reader3.GetInt32(0);
                            SeriesCollection3 = new SeriesCollection
                        {
                            new PieSeries
                            {
                                Title = "Activas",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr.cant) },
                                DataLabels = true
                            },
                            new PieSeries
                            {
                                Title = "Cerradas",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr2.cant) },
                                DataLabels = true
                            },
                            new PieSeries
                            {
                                Title = "Pendientes",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr3.cant) },
                                DataLabels = true
                            }
                        };
                        }

                    }


                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();

            DataContext = this;
        }

        private void CargarCapacitacion()
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
                    OracleCommand cmd = new OracleCommand("FN_CAPACITACIONES_ACTIVAS", con);

                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Capacitacion_activa> lista = new List<Capacitacion_activa>();

                    OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output.Direction = ParameterDirection.ReturnValue;
                    cmd.ExecuteNonQuery();

                    OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();



                    OracleCommand cmd2 = new OracleCommand("FN_CAPACITACIONES_CERRADAS", con);

                    cmd2.CommandType = CommandType.StoredProcedure;
                    List<Capacitacion_cerradas> lista2 = new List<Capacitacion_cerradas>();

                    OracleParameter output2 = cmd2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output2.Direction = ParameterDirection.ReturnValue;
                    cmd2.ExecuteNonQuery();

                    OracleDataReader reader2 = ((OracleRefCursor)output2.Value).GetDataReader();


                    OracleCommand cmd3 = new OracleCommand("FN_CAPACITACIONES_PENDIENTES", con);

                    cmd3.CommandType = CommandType.StoredProcedure;
                    List<Capacitacion_pendiente> lista3 = new List<Capacitacion_pendiente>();

                    OracleParameter output3 = cmd3.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output3.Direction = ParameterDirection.ReturnValue;
                    cmd3.ExecuteNonQuery();

                    OracleDataReader reader3 = ((OracleRefCursor)output3.Value).GetDataReader();


                    if (reader.Read())
                    {
                        if (reader2.Read())
                        {
                            if (reader3.Read())
                            {
                                Capacitacion_activa gr = new Capacitacion_activa();
                                Capacitacion_cerradas gr2 = new Capacitacion_cerradas();
                                Capacitacion_pendiente gr3 = new Capacitacion_pendiente();
                                gr.cant = reader.GetInt32(0);
                                gr2.cant = reader2.GetInt32(0);
                                gr3.cant = reader3.GetInt32(0);
                                SeriesCollection2 = new SeriesCollection
                        {
                            new PieSeries
                            {
                                Title = "Activas",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr.cant) },
                                DataLabels = true
                            },
                            new PieSeries
                            {
                                Title = "Cerradas",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr2.cant) },
                                DataLabels = true
                            },
                            new PieSeries
                            {
                                Title = "Pendientes",
                                Values = new ChartValues<ObservableValue> { new ObservableValue(gr3.cant) },
                                DataLabels = true
                            }
                        };
                            }

                        }


                    }

                }
                catch (Exception ex)
                {

                    MessageBox.Show("Error al generar carga de datos");
                }
                con.Close();

                DataContext = this;
           
        }

        public SeriesCollection SeriesCollection2 { get; set; }
        public SeriesCollection SeriesCollection3 { get; set; }

        public SeriesCollection SeriesCollection4 { get; set; }
        private void ClientesActivos()
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
                OracleCommand cmd = new OracleCommand("FN_CLIENTES_ACTIVOS ", con);

                cmd.CommandType = CommandType.StoredProcedure;
                List<Clientes_activos> lista = new List<Clientes_activos>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();


                OracleCommand cmd2 = new OracleCommand("FN_CONTRATOS_TOTAL", con);

                cmd2.CommandType = CommandType.StoredProcedure;
                List<cantidadClientes> lista2 = new List<cantidadClientes>();

                OracleParameter output2 = cmd2.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output2.Direction = ParameterDirection.ReturnValue;
                cmd2.ExecuteNonQuery();

                OracleDataReader reader2 = ((OracleRefCursor)output2.Value).GetDataReader();

                if (reader.Read())
                {
                    if (reader2.Read())
                    {
                        Clientes_activos gr = new Clientes_activos();
                        cantidadClientes gr2 = new cantidadClientes();
                        gr.cant = reader.GetInt32(0);
                        gr2.cant = reader2.GetInt32(0);

                        CantClientesActivos.Value = gr.cant;
                        CantClientesActivos.From = 0;
                        CantClientesActivos.To = gr2.cant;
                    }
                    
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
            
        }

        private void CargarCantidadProfesionales()
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
                OracleCommand cmd = new OracleCommand("FN_PROFESIONALES_TOTAL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Grafico> lista = new List<Grafico>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                if (reader.Read())
                {
                    CantidadProfesionales cant = new CantidadProfesionales();
                    cant.cant = reader.GetInt32(0);
                    lblCantProfesionales.Content = cant.cant;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void CargarCantidadClientes()
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
                OracleCommand cmd = new OracleCommand("FN_CLIENTES_TOTAL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Grafico> lista = new List<Grafico>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                if (reader.Read())
                {
                    cantidadClientes cant = new cantidadClientes();
                    cant.cant = reader.GetInt32(0);
                    lblCantClientes.Content = cant.cant;
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        public SeriesCollection SeriesCollection { get; set; }
        int contador = 0;
        private void CargarPie()
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
                OracleCommand cmd = new OracleCommand("FN_REPORTE_GLOBAL", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Grafico> lista = new List<Grafico>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                DataTable Datos = new DataTable();

                SeriesCollection = new SeriesCollection();

                while (reader.Read())
                {
                    contador++;

                    Label lbl = new Label();
                    lbl.HorizontalAlignment = HorizontalAlignment.Left;
                    lbl.Margin = new Thickness(146, 542, 0, 0);
                    lbl.VerticalAlignment = VerticalAlignment.Top;
                    lbl.Visibility = Visibility.Hidden;

                    Grafico gr = new Grafico();
                    gr.cant = reader.GetInt32(0);
                    gr.nombre = reader.GetString(1);

                    print.Children.Add(lbl);
                    lbl.Content = gr.cant;

                    var serie =
                        new PieSeries
                        {
                            Title = gr.nombre,
                            Values = new ChartValues<ObservableValue> { new ObservableValue(gr.cant) },
                            DataLabels = true
                        };

                    SeriesCollection.Add(serie);
                }

            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();

            DataContext = this;

        }

        


        private void Boton_confirmacion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnNotificarPago_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Chart.Update(true, true);
            prueba.Update(true, true);
            Chart2.Update(true, true);
            DataContext = this;
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

        private void PieChart_DataClick(object sender, LiveCharts.ChartPoint chartPoint)
        {

        }

        private void cboCapacitaciones_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            
            if (cboCapacitaciones.SelectedIndex == 0)
            {
                Chart.Update(true, true);
                Chart.Visibility = Visibility.Visible;
                Chart2.Visibility = Visibility.Hidden;
            }
            else if(cboCapacitaciones.SelectedIndex == 1)
            {
                Chart2.Update(true, true);
                Chart.Visibility = Visibility.Hidden;
                Chart2.Visibility = Visibility.Visible;
            }
        }

    }

    
}
