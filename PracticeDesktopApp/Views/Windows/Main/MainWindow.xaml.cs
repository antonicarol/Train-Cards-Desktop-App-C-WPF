using MaterialDesignThemes.Wpf;
using PracticeDesktopApp.Models;
using PracticeDesktopApp.Views;
using PracticeDesktopApp.Views.Modals;
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
        public bool isModalOpen = false;
        public bool isRegisterOpen = false;
        public bool isLoginOpen = false;
        public bool authorized = false;

        public MainWindow()
        {
            InitializeComponent();
            UpdateUI();
            
           
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

        private void User_Click(object sender, RoutedEventArgs e)
        {
            //Open the profile!
            if(UserInfo.FirstTime == 0)
            {
                CheckFirstTime();
            }
            
            
        }

        internal void UpdateUI()
        {
            lblName.Content = "Welcome " + UserInfo.Name;
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
                Content.Visibility = Visibility.Visible;
                
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
    }
}
