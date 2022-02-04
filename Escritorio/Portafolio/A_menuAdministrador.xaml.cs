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
    /// Lógica de interacción para menuAdministrador.xaml
    /// </summary>
    public partial class A_menuAdministrador : Window
    {
        public A_menuAdministrador()
        {
            InitializeComponent();
            GridMain.Children.Add(new A_GestionContratos());

            var menuCliente = new List<SubItem>();
            menuCliente.Add(new SubItem("Gestión de Contratos",new A_GestionContratos()));
            menuCliente.Add(new SubItem("Registro Representante",new A_RegistroRepresentante()));
            menuCliente.Add(new SubItem("Asesoría nueva", new A_AsesoríayPlan()));
            var item1 = new ItemMenu("Cliente", menuCliente, PackIconKind.AccountGroup);

            var MenuPlan = new List<SubItem>();
            MenuPlan.Add(new SubItem("Asociar Nuevo Plan", new A_Plan()));
            MenuPlan.Add(new SubItem("Registro Plan", new A_AgregarTipoPlan()));
            var item2 = new ItemMenu("Planes", MenuPlan, PackIconKind.NotebookOutline);

            var MenuProfesional = new List<SubItem>();
            MenuProfesional.Add(new SubItem("Registro Profesional",new A_RegistroProfesional()));
            MenuProfesional.Add(new SubItem("Gestión de Actividades",new A_GestionActividades()));
            var item3 = new ItemMenu("Profesionales", MenuProfesional, PackIconKind.Domain);

            var MenuReportes = new List<SubItem>();
            MenuReportes.Add(new SubItem("Reporte Estadistico Cliente",new A_ReporteEstCliente()));
            MenuReportes.Add(new SubItem("Reporte Estadistico Global", new A_ReporteEstGlobal()));
            var item4 = new ItemMenu("Reportes", MenuReportes, PackIconKind.ChartBar);
            
            Menu.Children.Add(new UserControlMenu(item1, this));
            Menu.Children.Add(new UserControlMenu(item2, this));
            Menu.Children.Add(new UserControlMenu(item3, this));
            Menu.Children.Add(new UserControlMenu(item4, this));


        }

        internal void SwitchScreen(object sender) {

            var screen = ((UserControl)sender);
            if (screen != null) {
                GridMain.Children.Clear();
                GridMain.Children.Add(screen);
            }
        }

        private void BtnPerfil_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(new A_Perfil());
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            GridMain.Children.Clear();
            GridMain.Children.Add(new A_GestionContratos());
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }

        private void Btn_cerrar_Click(object sender, RoutedEventArgs e)
        {
            MainWindow main = new MainWindow();
            main.Show();
            this.Close();
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
