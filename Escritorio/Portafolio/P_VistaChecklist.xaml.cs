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
    /// Lógica de interacción para P_VistaChecklist.xaml
    /// </summary>
    public partial class P_VistaChecklist : UserControl
    {
        public P_VistaChecklist()
        {
            InitializeComponent();
        }

        private void BtnModificar_Click(object sender, RoutedEventArgs e)
        {
            if (txtItem1.Text != "" && txtItem2.Text != "" && txtItem3.Text != "")
            {
                btnActualizar.IsEnabled = true;

                txtItem1.IsEnabled = true;
                txtItem2.IsEnabled = true;
                txtItem3.IsEnabled = true;
                txtItemExtra1.IsEnabled = true;
                txtItemExtra2.IsEnabled = true;
                txtItemExtra3.IsEnabled = true;
            }
            else
            {
                MessageBox.Show("No ha seleccionado ninguna visita a terreno");
            }



        }

        private void btnCancelarProf_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnBuscarProfesional_Click(object sender, RoutedEventArgs e)
        {

        }

        private void btnCancelarEmpresa_Click(object sender, RoutedEventArgs e)
        {
            txtEmpresa.Text = "";
            CargarGrilla();

        }

        private void dgVisita_Loaded(object sender, RoutedEventArgs e)
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
                OracleCommand cmd = new OracleCommand("fn_visitas_vista", con);
                cmd.CommandType = CommandType.StoredProcedure;
                List<Vista_visita_terreno> lista = new List<Vista_visita_terreno>();

                OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                cmd.ExecuteNonQuery();

                OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                while (reader.Read())
                {
                    Vista_visita_terreno rep = new Vista_visita_terreno();
                    rep.idvisita = reader.GetInt32(0);
                    rep.fechavisita = reader.GetString(1);
                    rep.tipovisitas = reader.GetString(2);
                    rep.estado = reader.GetString(3);
                    rep.rut_empresa = reader.GetString(4);
                    rep.run_profesional_asociado = reader.GetString(5);
                    rep.nombre_empresa = reader.GetString(6);
                    lista.Add(rep);
                }

                dgVisita.ItemsSource = lista;
            }
            catch (Exception ex)
            {

                MessageBox.Show("Error al generar carga de datos");
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

            try
            {
                con.Open();
                OracleCommand comando = new OracleCommand("FN_BUSCAR_NOMBRE_EMPRESA_VISITA", con);
                comando.CommandType = CommandType.StoredProcedure;
                OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add("V_NOMBRE", txtEmpresa.Text);
                comando.ExecuteNonQuery();
                List<Vista_visita_terreno> lista = new List<Vista_visita_terreno>();

                OracleDataReader lector = ((OracleRefCursor)output.Value).GetDataReader();

                while (lector.Read())
                {
                    Vista_visita_terreno rep = new Vista_visita_terreno();
                    rep.idvisita = lector.GetInt32(0);
                    rep.fechavisita = lector.GetString(1);
                    rep.tipovisitas = lector.GetString(2);
                    rep.estado = lector.GetString(3);
                    rep.rut_empresa = lector.GetString(4);
                    rep.run_profesional_asociado = lector.GetString(5);
                    rep.nombre_empresa = lector.GetString(6);
                    lista.Add(rep);
                }
                dgVisita.ItemsSource = lista;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void btnBuscarRun_Click(object sender, RoutedEventArgs e)
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
                OracleCommand comando = new OracleCommand("FN_BUSCAR_RUT_EMPRESA_VISITA", con);
                comando.CommandType = CommandType.StoredProcedure;
                OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                output.Direction = ParameterDirection.ReturnValue;
                comando.Parameters.Add("V_RUT", txtRunAsociado.Text);
                comando.ExecuteNonQuery();
                List<Vista_visita_terreno> lista = new List<Vista_visita_terreno>();
                OracleDataReader lector = comando.ExecuteReader();


                while (lector.Read())
                {
                    Vista_visita_terreno rep = new Vista_visita_terreno();
                    rep.idvisita = lector.GetInt32(0);
                    rep.fechavisita = lector.GetString(1);
                    rep.tipovisitas = lector.GetString(2);
                    rep.estado = lector.GetString(3);
                    rep.rut_empresa = lector.GetString(4);
                    rep.run_profesional_asociado = lector.GetString(5);
                    rep.nombre_empresa = lector.GetString(6);
                    lista.Add(rep);
                }
                dgVisita.ItemsSource = lista;

            }
            catch (Exception)
            {
                MessageBox.Show("Error al generar carga de datos");
            }
            con.Close();
        }

        private void btnCancelar2_Click(object sender, RoutedEventArgs e)
        {
            txtRunAsociado.Text = "";
            CargarGrilla();
        }

        private void txtRunAsociado_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.D0 && e.Key <= Key.D9 || e.Key >= Key.NumPad0 && e.Key <= Key.NumPad9)
                e.Handled = false;
            else
                e.Handled = true;
        }

        private void dgVisita_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Vista_visita_terreno emp = dgVisita.SelectedItem as Vista_visita_terreno;
            if (emp != null)
            {
                string idvisita = Convert.ToString(emp.idvisita);

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
                    OracleCommand cmd = new OracleCommand("FN_DATOS_REGISTRO", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    List<Info_registro> lista = new List<Info_registro>();

                    OracleParameter output = cmd.Parameters.Add("l_cursor", OracleDbType.RefCursor);
                    output.Direction = ParameterDirection.ReturnValue;
                    cmd.Parameters.Add("V_ID", idvisita);
                    cmd.ExecuteNonQuery();

                    OracleDataReader reader = ((OracleRefCursor)output.Value).GetDataReader();

                    while (reader.Read())
                    {
                        Info_registro per = new Info_registro();
                        per.id_Registro = reader.GetString(0);
                        per.item1 = reader.GetString(1);
                        per.item2 = reader.GetString(2);
                        per.item3 = reader.GetString(3);
                        per.comentarioitem1 = reader.GetString(4);
                        per.comentarioitem2 = reader.GetString(5);
                        per.comentarioitem3 = reader.GetString(6);
                        per.itemextra1 = reader.GetString(7);
                        per.itemextra2 = reader.GetString(8);
                        per.itemextra3 = reader.GetString(9);
                        per.comentarioitemextra1 = reader.GetString(10);
                        per.comentarioitemextra2 = reader.GetString(11);
                        per.comentarioitemextra3 = reader.GetString(12);
                        per.descripcionitem1 = reader.GetString(13);
                        per.descripcionitem2 = reader.GetString(14);
                        per.descripcionitem3 = reader.GetString(15);
                        per.descripcionitem1extra = reader.GetString(16);
                        per.descripcionitem2extra = reader.GetString(17);
                        per.descripcionitem3extra = reader.GetString(18);

                        if (per.item1 == "0")
                        {
                            Item1.IsChecked = false;
                        }
                        else
                        {
                            Item1.IsChecked = true;
                        }

                        if (per.item2 == "0")
                        {
                            Item2.IsChecked = false;
                        }
                        else
                        {
                            Item2.IsChecked = true;
                        }

                        if (per.item3 == "0")
                        {
                            Item3.IsChecked = false;
                        }
                        else
                        {
                            Item3.IsChecked = true;
                        }


                        FlowDocument documento = new FlowDocument();
                        Run texto = new Run(per.comentarioitem1);
                        Paragraph parrafo = new Paragraph();
                        parrafo.Inlines.Add(texto);
                        documento.Blocks.Add(parrafo);
                        comentario1.Document = documento;


                        FlowDocument documento2 = new FlowDocument();
                        Run texto2 = new Run(per.comentarioitem2);
                        Paragraph parrafo2 = new Paragraph();
                        parrafo2.Inlines.Add(texto2);
                        documento2.Blocks.Add(parrafo2);
                        comentario2.Document = documento2;


                        FlowDocument documento3 = new FlowDocument();
                        Run texto3 = new Run(per.comentarioitem3);
                        Paragraph parrafo3 = new Paragraph();
                        parrafo3.Inlines.Add(texto3);
                        documento3.Blocks.Add(parrafo3);
                        comentario3.Document = documento3;


                        FlowDocument documento4 = new FlowDocument();
                        Run texto4 = new Run(per.comentarioitemextra1);
                        Paragraph parrafo4 = new Paragraph();
                        parrafo4.Inlines.Add(texto4);
                        documento4.Blocks.Add(parrafo4);
                        comentarioExtra1.Document = documento4;


                        FlowDocument documento5 = new FlowDocument();
                        Run texto5 = new Run(per.comentarioitemextra2);
                        Paragraph parrafo5 = new Paragraph();
                        parrafo5.Inlines.Add(texto5);
                        documento5.Blocks.Add(parrafo5);
                        comentarioExtra2.Document = documento5;


                        FlowDocument documento6 = new FlowDocument();
                        Run texto6 = new Run(per.comentarioitemextra3);
                        Paragraph parrafo6 = new Paragraph();
                        parrafo6.Inlines.Add(texto6);
                        documento6.Blocks.Add(parrafo6);
                        comentarioExtra3.Document = documento6;


                        txtItem1.Text = per.descripcionitem1;
                        txtItem2.Text = per.descripcionitem2;
                        txtItem3.Text = per.descripcionitem3;

                        txtItemExtra1.Text = per.descripcionitem1extra;
                        txtItemExtra2.Text = per.descripcionitem2extra;
                        txtItemExtra3.Text = per.descripcionitem3extra;

                        lblIdRegistro.Content = per.id_Registro;
                    }


                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error al generar carga de datos");
                }
                con.Close();


            }
        }


        private void btnActualizar_Click(object sender, RoutedEventArgs e)
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
            OracleCommand comando = new OracleCommand("FN_CAMBIO_REGISTRO ", con);
            comando.CommandType = System.Data.CommandType.StoredProcedure;
            OracleParameter output = comando.Parameters.Add("l_cursor", OracleDbType.RefCursor);
            output.Direction = ParameterDirection.ReturnValue;
            comando.Parameters.Add("V_ID_REGISTRO", OracleDbType.Varchar2).Value = lblIdRegistro.Content;
            comando.ExecuteNonQuery();
            OracleDataReader lector = ((OracleRefCursor)output.Value).GetDataReader();

            if (lector.Read())
            {
                try
                {
                    OracleCommand comando5 = new OracleCommand("sp_registro_visita ", con);
                    comando5.CommandType = System.Data.CommandType.StoredProcedure;
                    comando5.Parameters.Add("v_id_registro", OracleDbType.Varchar2).Value = lblIdRegistro.Content;
                    comando5.Parameters.Add("v_desc1", OracleDbType.Varchar2).Value = txtItem1.Text;
                    comando5.Parameters.Add("v_desc2", OracleDbType.Varchar2).Value = txtItem2.Text;
                    comando5.Parameters.Add("v_desc3", OracleDbType.Varchar2).Value = txtItem3.Text;
                    comando5.Parameters.Add("v_descextra1", OracleDbType.Varchar2).Value = txtItemExtra1.Text;
                    comando5.Parameters.Add("v_descextra2", OracleDbType.Varchar2).Value = txtItemExtra2.Text;
                    comando5.Parameters.Add("v_descextra3", OracleDbType.Varchar2).Value = txtItemExtra3.Text;

                    comando5.ExecuteNonQuery();
                    MessageBox.Show("Checklist actualizado correctamente.");
                    Content = new P_VistaChecklist();

                }
                catch (Exception)
                {
                    MessageBox.Show("No se ha podido completar la acción solicitada.");
                }
            }
            else
            {
                MessageBox.Show("No existe el rut ingresado");
            }

            con.Close();
        }
    }
}
