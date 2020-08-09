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

        private void UpdateDebug(string round, string cards)
        {
            debug1.Content = round;
            debugCards.Content = cards;
        }

        private void resetGame()
        {
            game.ClearProgress();

            roundOne.Visibility = Visibility.Visible;
            roundTwo.Visibility = Visibility.Hidden;
            roundThree.Visibility = Visibility.Hidden;
            roundFour.Visibility = Visibility.Hidden;
            roundFive.Visibility = Visibility.Hidden;

            //reset Images

            cardDrawed.Source = null;
            cardDrawed2.Source = null;
            cardDrawed3.Source = null;
            cardDrawed4.Source = null;
            cardDrawed5.Source = null;



        }

        private void Button_Red(object sender, RoutedEventArgs e)
        {
            Card card = game.GetRandomCard();
            string cardName = card.ToString();


            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));
            cardDrawed.Source = bitmap;
            if (game.RoundOne(Red_Button.Content.ToString(), card))
            {
                // YOU PASSED ROUND ONE
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundOne.Visibility = Visibility.Hidden;
                roundTwo.Visibility = Visibility.Visible;

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

            cardDrawed.Source = bitmap;

            if (game.RoundOne(Black_Button.Content.ToString(), card))
            {
                // YOU PASSED ROUND ONE
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundOne.Visibility = Visibility.Hidden;
                roundTwo.Visibility = Visibility.Visible;

            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You failed";
                result.Visibility = Visibility.Visible;

            }
        }

        private void Low_Button_Click(object sender, RoutedEventArgs e)
        {

            Card card = game.GetRandomCard();
            string cardName = card.ToString();


            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));

            cardDrawed2.Source = bitmap;

            if (game.RoundTwo(Low_Button.Content.ToString(), card))
            {
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundTwo.Visibility = Visibility.Hidden;
                roundThree.Visibility = Visibility.Visible;


            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You Failed";
                result.Visibility = Visibility.Visible;

            }

        }



        private void High_Button_Click(object sender, RoutedEventArgs e)
        {

            Card card = game.GetRandomCard();
            string cardName = card.ToString();


            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));

            cardDrawed2.Source = bitmap;

            if (game.RoundTwo(High_Button.Content.ToString(), card))
            {
                // YOU PASSED ROUND two
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundTwo.Visibility = Visibility.Hidden;
                roundThree.Visibility = Visibility.Visible;


            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You Failed";
                result.Visibility = Visibility.Visible;

            }


        }

        private void Reset_Click(object sender, RoutedEventArgs e)
        {
            resetGame();
        }

        private void Between_Button_Click(object sender, RoutedEventArgs e)
        {
            Card card = game.GetRandomCard();
            string cardName = card.ToString();


            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));

            cardDrawed3.Source = bitmap;

            if (game.RoundThree("BETWEEN", card))
            {
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundThree.Visibility = Visibility.Hidden;
                roundFour.Visibility = Visibility.Visible;
                UpdateDebug("Round : 3", game.GetProcess());
            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You Failed";
                result.Visibility = Visibility.Visible;
            }
        }

        private void Outside_Button_Click(object sender, RoutedEventArgs e)
        {

            Card card = game.GetRandomCard();
            string cardName = card.ToString();


            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));

            cardDrawed3.Source = bitmap;

            if (game.RoundThree("OUTSIDE", card))
            {
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundThree.Visibility = Visibility.Hidden;
                roundFour.Visibility = Visibility.Visible;
                UpdateDebug("Round : 3", game.GetProcess());
            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You Failed";
                result.Visibility = Visibility.Visible;
            }
        }

        private void Yes_Type_Button_Click(object sender, RoutedEventArgs e)
        {
            Card card = game.GetRandomCard();
            string cardName = card.ToString();

            debug1.Content = card.GetCardType();

            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));

            cardDrawed4.Source = bitmap;
            if (game.RoundFour("YES", card))
            {
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundFour.Visibility = Visibility.Hidden;
                roundFive.Visibility = Visibility.Visible;
            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You Failed";
                result.Visibility = Visibility.Visible;
            }
        }

        private void No_Type_Button_Click(object sender, RoutedEventArgs e)
        {
            Card card = game.GetRandomCard();
            string cardName = card.ToString();

            debug1.Content = card.GetCardType();


            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));

            cardDrawed4.Source = bitmap;
            if (game.RoundFour("NO", card))
            {
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundFour.Visibility = Visibility.Hidden;
                roundFive.Visibility = Visibility.Visible;
                UpdateDebug("Round : 3", game.GetProcess());
            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You Failed";
                result.Visibility = Visibility.Visible;
            }
        }

        private void Yes_Number_Button_Click(object sender, RoutedEventArgs e)
        {
            Card card = game.GetRandomCard();
            string cardName = card.ToString();


            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));

            cardDrawed5.Source = bitmap;

            if (game.RoundFive("YES", card))
            {
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundFive.Visibility = Visibility.Hidden;
                UpdateDebug("Round : 3", game.GetProcess());

            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You Failed";
                result.Visibility = Visibility.Visible;
            }
        }

        private void No_Number_Button_Click(object sender, RoutedEventArgs e)
        {
            Card card = game.GetRandomCard();
            string cardName = card.ToString();


            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceCards.ResourceManager.GetObject(cardName));

            cardDrawed5.Source = bitmap;

            cardDrawed5.Source = bitmap;

            if (game.RoundFive("NO", card))
            {
                result.Background = Brushes.Green;
                result.Content = "You passed";
                result.Visibility = Visibility.Visible;
                roundFive.Visibility = Visibility.Hidden;
                UpdateDebug("Round : 3", game.GetProcess());

            }
            else
            {
                result.Background = Brushes.Red;
                result.Content = "You Failed";
                result.Visibility = Visibility.Visible;
            }
        }
    }
}
