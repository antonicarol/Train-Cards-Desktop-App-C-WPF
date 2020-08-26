using PracticeDesktopApp.Controllers;
using PracticeDesktopApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace PracticeDesktopApp.ViewModel
{
    class ShopViewModel
    {
        Window window;
        private UsersDAO usersDAO;
        private GamesDAO gamesDAO;

        private List<Game> allGames;
        public ShopViewModel(Window w)
        {
            window = w;
            usersDAO = new UsersDAO();
            gamesDAO = new GamesDAO();
            allGames = GetAllGamesFromDB();
        }

        public List<Game> GetGames()
        {
            return allGames;
        }

        internal List<Game> GetAllGamesFromDB()
        {
            return gamesDAO.GetAllGames();
        }

        internal bool PurchaseGame(string name, int id)
        {
            gamesDAO.PurchaseGame(name, id);
            Game game = GetGame(allGames, id);
            if (usersDAO.GamePurchased(UserInfo.Id, game))
            {
                return true;
            }
            return false;
        }

        public Game GetGame(List<Game> games, int id)
        {
            foreach (Game game in games)
            {
                if (game.Id == id)
                {
                    return game;
                }
            }
            return null;
        }
    }
}
