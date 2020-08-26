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
using PracticeDesktopApp.Logic._3inaRow;

namespace PracticeDesktopApp.Views.Windows.Games
{
    /// <summary>
    /// Lógica de interacción para RowGame.xaml
    /// </summary>
    public partial class RowGame : Window
    {
        ThreeRowGame game = new ThreeRowGame();
        int[][] board;
        
        public RowGame()
        {
            InitializeComponent();
            FillBoard();
        }

        private void FillBoard()
        {
            board = game.GetBoard();
            Board_Grid.Children.Clear();
            for (int i = 0; i < 3; i++){
                for (int j = 0; j < 3; j++)
                {

                    Button btn = new Button();
                    btn.Content = board[i][j].ToString();
                    btn.FontSize = 10;
                    btn.DataContext = new int[] { i, j };
                    btn.Click += Player_Pick;

                    Grid.SetRow(btn, i);
                    Grid.SetColumn(btn, j);
                    Board_Grid.Children.Add(btn);

                }
            }
            
        }

        private void Player_Pick(object sender, RoutedEventArgs e)
        {
            int[] position = (int[])(e.Source as Button).DataContext;

            Debug_Board.Content = position[0] + "   " + position[1];

            game.Player_Pick(position[0], position[1]);
            
            FillBoard();

            if (game.win)
            {
                Debug_Board.Content = game.winMessage;
                MessageBox.Show("You Won the Game");
            }
            else{
                game.IA_Pick();
                FillBoard();
            }

            
        }
    }

        
    }

