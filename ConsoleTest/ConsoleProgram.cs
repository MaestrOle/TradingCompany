using AutoMapper;
using BusinessLogic.Concrete;
using DAL.Interfaces;
using DAL.Concrete;
using DALef.Concrete;
using DTO;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace ConsoleTester
{
    class Program
    {
        static void Main(string[] args)
        {

            IMapper mapper = SetupMapper();

            Console.WriteLine("type 'l' to login");
            Console.WriteLine("type 'n' if you new customer");
            Console.WriteLine("type 'e' to exit");


            char c = char.Parse(Console.ReadLine());

            while (true)
            {
                Console.WriteLine("type 'g' to show all genres");
                Console.WriteLine("type 'i' to show games in concrete genre");
                Console.WriteLine("type 'c' to choose game by ID");
                Console.WriteLine("type 'e' to exit");
                switch (c)
                {
                    case 'n': //create customer

                        string email;
                        string password;
                        Console.WriteLine("Your FirstName");
                        string firstname = Console.ReadLine();
                        Console.WriteLine("Your LastName");
                        string lastname = Console.ReadLine();
                        Console.WriteLine("Your YearOfBirth");
                        int yearofbirth = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Your Email");
                        email = Console.ReadLine();
                        Console.WriteLine("Create Your Password");
                        password = Console.ReadLine();
                        ICustomerDal customer = new CustomerDalEf(mapper);
                        {
                            customer.CreateCustomer(firstname, lastname, yearofbirth, email, password);
                        }

                        break;
                    case 'l':
                        Console.WriteLine("Your Email");
                        email = Console.ReadLine();
                        Console.WriteLine("Your Password");
                        password = Console.ReadLine();
                        ICustomerDal login = new CustomerDalEf(mapper);
                        {
                            login.Login(email, password);
                        }
                        break;
                    case 'g':
                        ShowGenres();
                        break;
                    case 'i':
                        Console.WriteLine("Choose genre by ID from list");
                        int genreID = Convert.ToInt32(Console.ReadLine());
                        ShowGamesInGenre(genreID);
                        break;
                    case 'c':
                        Console.WriteLine("Choose game by ID from list");
                        int gameID = Convert.ToInt32(Console.ReadLine());
                        ShowInfo(gameID);

                        Console.WriteLine("type 'b' for Adding to Basket or other to break");
                        char elem = char.Parse(Console.ReadLine());
                        if (elem == 'b')
                        {
                            AddToBasket(gameID);
                            break;
                        }
                        else
                            break;
                    case 'e':
                        return;
                }
            }
        }
        private static IMapper SetupMapper()
        {
            MapperConfiguration conf = new MapperConfiguration(
                    cfg => cfg.AddMaps(typeof(CustomerDalEf).Assembly)
                );
            return conf.CreateMapper();
        }
        private static void ShowGenres()
        {
            GenresDal dal = new GenresDal(ConfigurationManager.ConnectionStrings["GamesDB"].ConnectionString);

            foreach (var genre in dal.GetAllGenres())
            {
                Console.WriteLine($"{genre.GenreID}\t{genre.GenreName}");
            }
        }
        private static void ShowGamesInGenre(int genreID)
        {
            GamesDal dal = new GamesDal(ConfigurationManager.ConnectionStrings["GamesDB"].ConnectionString);
            foreach (var game in dal.GamesInGenre(genreID))
            {
                Console.WriteLine($"{game.GameID}\t{game.Title}\t{game.DevCompany}\t{game.RelizeDate}\t{game.Price}");
            }
        }
        private static void ShowInfo(int gameID)
        {
            GamesDal dal = new GamesDal(ConfigurationManager.ConnectionStrings["GamesDB"].ConnectionString);
            var game = dal.ShowGameInfo(gameID);
            {
                Console.WriteLine($"{game.Title}\t{game.DevCompany}\t{game.RelizeDate}\t{game.Price}");
            }
        }
        private static void AddToBasket(int gameID)
        {
            GamesDal dal = new GamesDal(ConfigurationManager.ConnectionStrings["GamesDB"].ConnectionString);
            var game = dal.ShowGameInfo(gameID);
            BasketDal basket = new BasketDal(ConfigurationManager.ConnectionStrings["GamesDB"].ConnectionString);
            BasketDTO newelem = new BasketDTO();
            newelem.Title = game.Title;
            newelem.Price = game.Price;
            basket.AddToBasket(newelem);
        }

    }
}

                