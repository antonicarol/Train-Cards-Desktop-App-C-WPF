using PracticeDesktopApp.Controllers;
using PracticeDesktopApp.Models;
using PracticeDesktopApp.ViewModel;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
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

namespace PracticeDesktopApp.Views.Modals.Shop
{
    /// <summary>
    /// Lógica de interacción para ShopHome.xaml
    /// </summary>
    public partial class ShopHome : Window
    {
        MainWindow window;
        List<Game> allGames;
        
        ShopViewModel shopViewModel;
        public ShopHome(MainWindow win)
        {
            window = win;
            window.isShopOpen = true;
            InitializeComponent();
            shopViewModel = new ShopViewModel(this);
            allGames = shopViewModel.GetGames();
            DisplayAllGamesList();
        }

        private void DisplayAllGamesList()
        {
            Games_Shop_Grid.Children.Clear();

            for (int i = 0; i < allGames.Count; i++)
            {
                RowDefinition row = new RowDefinition();
                row.Height = new GridLength(40);
             
                Label name = new Label();
                name.Content = allGames[i].Name;
                name.HorizontalAlignment = HorizontalAlignment.Center;
                Grid.SetColumn(name, 0);
                Grid.SetRow(name, i);

                Button btn = new Button();
                btn.Content = "Purchase";
                btn.DataContext = new Tuple<string, int>(allGames[i].Name, allGames[i].Id);
                btn.Click += Purchase_Click;
                Grid.SetColumn(btn, 1);
                Grid.SetRow(btn, i);

                Games_Shop_Grid.RowDefinitions.Add(row);
                Games_Shop_Grid.Children.Add(btn);
                Games_Shop_Grid.Children.Add(name);
            }
        }

        private void Purchase_Click(object sender, RoutedEventArgs e)
        {
            Tuple<string, int> dataContext = (Tuple<string,int>) (e.Source as Button).DataContext;
            string name = dataContext.Item1;
            int id = dataContext.Item2;

            if(shopViewModel.PurchaseGame(name, id))
            {
                UpdateUI();
                MessageBox.Show("Game purchase completed!");
            }
        }

        public void UpdateUI()
        {
            allGames = shopViewModel.GetAllGamesFromDB();
            DisplayAllGamesList();
        }

        private void CloseModal()
        {
            window.isShopOpen = false;
            window.UpdateUI(1);
            Close();
        }

        private void CloseShop_Click(object sender, RoutedEventArgs e)
        {
            CloseModal();
        }
    }
}
