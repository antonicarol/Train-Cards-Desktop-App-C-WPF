using MaterialDesignThemes.Wpf;
using PracticeDesktopApp.Controllers;
using PracticeDesktopApp.Models;
using PracticeDesktopApp.Views;
using PracticeDesktopApp.Views.Modals;
using PracticeDesktopApp.Views.Modals.Shop;
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
        internal bool isShopOpen;
        private GamesDAO GamesDao;
        public bool isModalOpen = false;
        public bool isRegisterOpen = false;
        public bool isLoginOpen = false;
        public bool authorized = false;

        public MainWindow()
        {
            GamesDao = new GamesDAO();
            InitializeComponent();
        }

        private void GetAllUserGames()
        {
            Display_Gamess.Children.Clear();

            List<Models.Game> allGames = GamesDao.GetUserGames();
            for(int i = 0; i<allGames.Count; i++)
            {
                //GAME ELEMENTS
                Label lblName = new Label();
                lblName.Content = allGames[i].Name;
                Button btnPlay = new Button();
                btnPlay.Content = "PLAY";
                btnPlay.HorizontalAlignment = HorizontalAlignment.Right;
                StackPanel panel = new StackPanel();
                panel.Orientation = Orientation.Horizontal;
                panel.HorizontalAlignment = HorizontalAlignment.Center;
                panel.Children.Add(lblName);
                panel.Children.Add(btnPlay);

                Grid.SetRow(panel, i);
                Grid.SetColumn(panel, 0);

                Display_Gamess.Children.Add(panel);
            }
        }

        private void CheckFirstTime()
        {
            if (UserInfo.FirstTime == 0)
            {
                ModalFirstTime modal = new ModalFirstTime(this);
                modal.Owner = this;
                SetBlurrEffect(this,true);
                modal.ShowDialog();
               
                if (!isModalOpen)
                {
                    SetBlurrEffect(this,false);
                }
            }
            
        }

        private void SetBlurrEffect(Window win, bool add)
        {
            if (add)
            {
                var objBlur = new System.Windows.Media.Effects.BlurEffect();
                objBlur.Radius = 5;
                win.Effect = objBlur;
            }
            else
            {
                win.Effect = null;
            }
        }
   
        private void HangedMan_Click(object sender, RoutedEventArgs e)
        {
            hangedWindow window = new hangedWindow();
            window.Show();
            Close();
        }

        private void User_Click(object sender, RoutedEventArgs e)
        {
            //Open the profile!
            if(UserInfo.FirstTime == 0)
            {
                CheckFirstTime();
            }
            
            
        }

        internal void UpdateUI(int type)
        {
            switch (type)
            {
                case 0:
                    lblUsername.Content = UserInfo.Name;
                    lblCurrency.Content = UserInfo.Currency.ToString() + " $ ";
                    break;

                case 1:
                    lblCurrency.Content = UserInfo.Currency.ToString() + " $ ";
                    break;

            }
            
        }

      

        private void Scores_Click(object sender, RoutedEventArgs e)
        {
            //Se scoreboards
        }


        private void PlayTrainCards_Click(object sender, RoutedEventArgs e)
        {
            TrainCardWindow TrainCard = new TrainCardWindow();
            TrainCard.Show();

        }

        internal void CheckAuthorized()
        {
            if (authorized)
            {
                Authorize.Visibility = Visibility.Hidden;
                SideBar.Visibility = Visibility.Visible;
                Content_Body.Visibility = Visibility.Visible;
                GetAllUserGames();

            }
        }

        private void PlayHangedMan_Click(object sender, RoutedEventArgs e)
        {
            hangedWindow HangedMan = new hangedWindow();
            HangedMan.Show();
        }
        private void Login_Click(object sender, RoutedEventArgs e)
        {
            ModalLogin login = new ModalLogin(this);
            login.Owner = this;
            SetBlurrEffect(this, true);
            login.ShowDialog();
            if (!isLoginOpen)
            {
                SetBlurrEffect(this, false);
                CheckAuthorized();
                
            }
        }

        private void Register_Click(object sender, RoutedEventArgs e)
        {
            ModalRegister register = new ModalRegister(this);
            register.Owner = this;
            SetBlurrEffect(this, true);
            register.ShowDialog();

            if (!isRegisterOpen)
            {
                SetBlurrEffect(this, false);
            }
        }

        private void Store_Click(object sender, RoutedEventArgs e)
        {
            //Open up the store

            ShopHome shop = new ShopHome(this);
            shop.Owner = this;
            SetBlurrEffect(this, true);
            shop.ShowDialog();
            if (!isShopOpen)
            {
                SetBlurrEffect(this, false);
                GetAllUserGames();
            }
        }
    }
}
