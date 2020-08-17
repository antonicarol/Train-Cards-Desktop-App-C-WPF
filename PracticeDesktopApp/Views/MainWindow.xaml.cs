using PracticeDesktopApp.Views;
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
using TrainCards;

namespace PracticeDesktopApp
{
    /// <summary>
    /// Lógica de interacción para MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Game game = new Game();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            TrainCardWindow game = new TrainCardWindow();
            game.Show();
            Close();
        }

       

        private void HangedMan_Click(object sender, RoutedEventArgs e)
        {
            hangedWindow window = new hangedWindow();
            window.Show();
            Close();
        }
    }
}
