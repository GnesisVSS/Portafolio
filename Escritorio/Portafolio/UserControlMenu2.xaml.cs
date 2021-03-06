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
using Portafolio.ViewModel;

namespace Portafolio
{
    /// <summary>
    /// Lógica de interacción para UserControlMenu2.xaml
    /// </summary>
    public partial class UserControlMenu2 : UserControl
    {
        menuProfesionales _context;
        public UserControlMenu2(ItemMenu itemMenu, menuProfesionales context)
        {
            InitializeComponent();

            _context = context;

            ExpanderMenu.Visibility = itemMenu.SubItems == null ? Visibility.Collapsed : Visibility.Visible;
            ListViewItemMenu.Visibility = itemMenu.SubItems == null ? Visibility.Visible : Visibility.Collapsed;

            this.DataContext = itemMenu;
        }

        private void TextBlock_MouseDown(object sender, MouseButtonEventArgs e)
        {
            _context.SwitchScreen(((TextBlock)sender).Tag);
        }
    }
}
