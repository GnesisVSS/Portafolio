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
using System.Windows.Shapes;
using MahApps.Metro.Controls;
using MahApps.Metro.Controls.Dialogs;
using Modelo;
using Portafolio.ViewModel;
using MaterialDesignThemes.Wpf;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para menuProfesionales.xaml
    /// </summary>
    public partial class menuProfesionales : Window
    {
        public menuProfesionales()
        {
            InitializeComponent();
            GridMain.Children.Add(new P_GestionContrato());


            var menuCliente = new List<SubItem>();
            menuCliente.Add(new SubItem("Gestión de Contratos", new P_GestionContrato()));
            menuCliente.Add(new SubItem("Capacitaciones", new P_capacitaciones()));
            var item1 = new ItemMenu("Cliente", menuCliente, PackIconKind.AccountGroup);


            var MenuProfesional = new List<SubItem>();
            MenuProfesional.Add(new SubItem("Visitas Registradas", new P_VistaChecklist()));
            MenuProfesional.Add(new SubItem("Visitas Solicitadas", new P_BusquedaVisita()));
            MenuProfesional.Add(new SubItem("Generar Visita", new P_generacionVisita()));
            var item2 = new ItemMenu("Visitas a Terreno", MenuProfesional, PackIconKind.MapMarkerRadius);


            var MenuReportes = new List<SubItem>();
            MenuReportes.Add(new SubItem("Nueva Asesoría", new P_NuevaAsesoria()));
            MenuReportes.Add(new SubItem("Asesoría", new P_BusquedaAsesoria()));
            var item3 = new ItemMenu("Asesorías", MenuReportes, PackIconKind.Forum);

            Menu.Children.Add(new UserControlMenu2(item1, this));
            Menu.Children.Add(new UserControlMenu2(item2, this));
            Menu.Children.Add(new UserControlMenu2(item3, this));


        }

        internal void SwitchScreen(object sender)
        {

            var screen = ((UserControl)sender);
            if (screen != null)
            {
                GridMain.Children.Clear();
                GridMain.Children.Add(screen);
            }
        }

        private void BtnPerfil_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(new Perfil());
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(new P_GestionContrato());
        }


        private void Btn_cerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
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
            this.Close();
        }

        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
            {
                this.DragMove();
            }
        }
    }
}
