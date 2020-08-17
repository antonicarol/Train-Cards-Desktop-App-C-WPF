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
        public hangedWindow()
        {
            InitializeComponent();
            game = new HangedMan();

            //Setting up letters like toolbox, to choose them.

            char[] alphabet = game.GetAbecedarie();

            for (int i = 0; i < alphabet.Length; i++)
            {
                Button btn = new Button();
                btn.Content = alphabet[i];
                btn.FontSize = 6;
                btn.Click += Letter_selected;
                Alphabet.Children.Add(btn);
            }

        }
        private void Letter_selected(object sender, RoutedEventArgs e)
        {
            string letter = (e.Source as Button).Content.ToString();
            
            if(game.SayCharacter(letter, word))
            {
                ActualizeResult();
            }
            else
            {
                Debug.Content = "NO";
            }
            
        }

            private void ShowWord_Click(object sender, RoutedEventArgs e)
        {
            word = game.GetRandomWord();
            Word.Content = word;

            char[] res = game.GetResult();
            //Well have to loop through the word and display spaces where char should be
            for( int i = 0; i < res.Length; i++)
            {
                
                Word_chars.Children.Add(new Label { Content = res[i].ToString() });
                
                
            }
        }

        public void ActualizeResult()
        {
            char[] res = game.GetResult();
            Word_chars.Children.Clear();
            for (int i = 0; i < res.Length; i++)
            {
                Word_chars.Children.Add(new Label { Content = res[i].ToString() });
            }
        }
    }
}
