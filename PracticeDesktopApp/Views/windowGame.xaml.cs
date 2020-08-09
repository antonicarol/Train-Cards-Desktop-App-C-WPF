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
using TrainCards;

namespace PracticeDesktopApp.Views
{
    /// <summary>
    /// Lógica de interacción para windowGame.xaml
    /// </summary>
    public partial class windowGame : Window
    {
        Game game;
        public windowGame()
        {
            game = new Game();
            InitializeComponent();
        }

        private void Button_Red(object sender, RoutedEventArgs e)
        {
            Card card = game.GetRandomCard();
            string cardName = card.ToString();

            
            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));
            cardDrawed.Source = bitmap ;
            if (game.RoundOne(Red_Button.Content.ToString(), card))
            {
                // YOU PASSED ROUND ONE
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;

            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You failed";
                result.Visibility = Visibility.Visible;
            }

        }
        private void Button_Black(object sender, RoutedEventArgs e)
        {
            Card card = game.GetRandomCard();
            string cardName = card.ToString();

            
            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));

            cardDrawed.Source = bitmap ;
            
            if (game.RoundOne(Black_Button.Content.ToString(), card))
            {
                // YOU PASSED ROUND ONE
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;

            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You failed";
                result.Visibility = Visibility.Visible;
            }
        }
    }
}
