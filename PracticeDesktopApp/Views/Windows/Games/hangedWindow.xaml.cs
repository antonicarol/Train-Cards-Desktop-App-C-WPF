using PracticeDesktopApp.Logic.HangedMan;
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
    /// Lógica de interacción para hangedWindow.xaml
    /// </summary>
    public partial class hangedWindow : Window
    {
        HangedMan game;
        string word;
        bool debug = true;
        List<char[]> alphabet;
        public hangedWindow()
        {
            InitializeComponent();
            InitGame();
            InitViews();
           

        }
        private void InitGame()
        {
            game = new HangedMan();

            if (debug)
            {
                DebugPanel.Visibility = Visibility.Visible;
            }

            //Setting up letters like toolbox, to choose them.

            alphabet = game.GetAbecedarie();

        }
        private void InitViews()
        {
            DrawHangedMan();
            DrawLetters();
           
        }
        
        private void DrawHangedMan()
        {
            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceHangedMan.ResourceManager.GetObject(game.GetImgHangedMan()));
            HangedMan.Source = bitmap;
        }
        private void DrawLetters()
        {
            for (int i = 0; i < alphabet.Count; i++)
            {
                if (i == 0)
                {
                    for (int j = 0; j < alphabet[i].Length; j++)
                    {
                        Button btn = new Button();
                        btn.Content = alphabet[i][j];
                        btn.FontSize = 8;
                        btn.Click += Letter_selected;
                        Alphabet1.Children.Add(btn);
                    }
                }
                if (i == 1)
                {
                    for (int j = 0; j < alphabet[i].Length; j++)
                    {
                        Button btn = new Button();
                        btn.Content = alphabet[i][j];
                        btn.FontSize = 8;
                        btn.Click += Letter_selected;
                        Alphabet2.Children.Add(btn);
                    }
                }
            }
        }

        private void Letter_selected(object sender, RoutedEventArgs e)
        {
            string letter = (e.Source as Button).Content.ToString();
            
            if(game.SayCharacter(letter, word))
            {
                ActualizeResult(debug);
            }
            else
            {
                ActualizeResult(debug);
            }
            
        }

        private void ShowWord_Click(object sender, RoutedEventArgs e)
        {
            word = game.GetRandomWord();
            

            char[] res = game.GetResult();
            //Well have to loop through the word and display spaces where char should be
            for( int i = 0; i < res.Length; i++)
            {
                Word_chars.Children.Add(new Label { Content = res[i].ToString(), FontSize = 40,
                                                    HorizontalAlignment = HorizontalAlignment.Center,
                                                    VerticalAlignment = VerticalAlignment.Center});
                                                
            
            }
        }

        public void ActualizeResult(bool debug)
        {
            //ACTUAL WORD   
            char[] res = game.GetResult();
            Word_chars.Children.Clear();
            for (int i = 0; i < res.Length; i++)
            {
                Word_chars.Children.Add(new Label { Content = res[i].ToString(), FontSize = 40,
                                                       HorizontalAlignment= HorizontalAlignment.Center,
                                                       VerticalAlignment=VerticalAlignment.Center});
            }

            //HANGED MAN

            var image = new BitmapImage();
            var bitmap = (BitmapSource)new ImageSourceConverter().ConvertFrom(FileStore.ResourceHangedMan.ResourceManager.GetObject(game.GetImgHangedMan()));
            HangedMan.Source = bitmap;

            //DEBUG
            if (debug)
            {
               
                Progres_Deb.Content = "Progress : " + game.GetProgress();
                Word_Deb.Content = "Word is : " + word;
                HangedMan_Deb.Content = "HangedMan : "+ game.GetHangedMan();
            }
        }
    }
}
