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

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para P_VisitaTerreno.xaml
    /// </summary>
    public partial class P_VisitaTerreno : UserControl
    {
        public P_VisitaTerreno()
        {
            InitializeComponent();
        }

        private void Boton_confirmacion_Click(object sender, RoutedEventArgs e)
        {

        }

        private void BtnVolver_Click(object sender, RoutedEventArgs e)
        {
            Content = new P_BusquedaVisita();
        }
    }
}
