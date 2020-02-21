﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLibraryClasses.Models;

namespace eLibraryClasses.UserInterfaceServices
{
    public class StatisticsService
    {
        //Check if book lists of user are created. If not, create a new ones
        public void PreventNullError(ref UserModel loggedUser)
        {
            if (loggedUser.ReadBooks == null)
            {
                loggedUser.ReadBooks = new List<BookModel>();
            }

            if (loggedUser.ToReadBooks == null)
            {
                loggedUser.ToReadBooks = new List<BookModel>();
            }

            if (loggedUser.FavoriteAuthors == null)
            {
                loggedUser.FavoriteAuthors = new List<string>();
            }
        }

        //Get the number of summary pages of all books read by user, and write it down to form
        public string GetReadPages(UserModel loggedUser)
        {
            int numberOfReadPages = 0;

            foreach (BookModel book in loggedUser.ReadBooks)
            {
                numberOfReadPages += book.Pages;
            }

            return numberOfReadPages.ToString();
        }

        //Get the number of summary pages of all books selected to read by user, and write it down to form
        public string GetToReadPages(UserModel loggedUser)
        {
            int numberOfToReadPages = 0;

            foreach (BookModel book in loggedUser.ToReadBooks)
            {
                numberOfToReadPages += book.Pages;
            }

            return numberOfToReadPages.ToString();
        }

        public string GetNumberOfFavoriteAuthors(UserModel loggedUser)
        {
            return loggedUser.FavoriteAuthors.Count.ToString();
        }

        public string GetFavoriteGenre(UserModel loggedUser)
        {
            //Create a new temporary list of all books read or to read by user
            List<BookModel> userAllBooks = new List<BookModel>();

            //Add to temporary list every book which user read
            foreach (BookModel book in loggedUser.ReadBooks)
            {
                userAllBooks.Add(book);
            }

            //Add to temporary list every book which user selected "to read"
            foreach (BookModel book in loggedUser.ToReadBooks)
            {
                userAllBooks.Add(book);
            }

            //Create a new structure
            Genres genresCount = new Genres();

            //Set all values to 0
            genresCount = SetStartingValuesOfGenres();

            //Count the number of repetitions of each book genre
            foreach (BookModel book in userAllBooks)
            {
                switch (book.Genre)
                {
                    case "fantastyka":
                        genresCount.fantastyka++;
                        break;

                    case "horror":
                        genresCount.horror++;
                        break;

                    case "historyczna":
                        genresCount.historyczna++;
                        break;

                    case "inna":
                        genresCount.inna++;
                        break;

                    case "przygodowa":
                        genresCount.przygodowa++;
                        break;

                    case "kryminał":
                        genresCount.kryminał++;
                        break;
                }
            }

            //If there are no books in user bookshelf, return "No info"
            if (loggedUser.ReadBooks.Count == 0 && loggedUser.ToReadBooks.Count == 0)
            {
                return "Brak info";
            }

            //Get name of genre with highest value from structure, and assign it to label
            return genresCount.GetType().GetFields().OrderByDescending(x => x.GetValue(genresCount)).First().Name;
        }

        //Create a new structure with all available genres in Polish
        public struct Genres
        {
            public int fantastyka, horror, historyczna, inna, przygodowa, kryminał;
        }

        //Starting value to count of every genre is 0;
        public Genres SetStartingValuesOfGenres()
        {
            Genres output = new Genres
            {
                fantastyka = 0,
                horror = 0,
                historyczna = 0,
                inna = 0,
                przygodowa = 0,
                kryminał = 0
            };

            return output;
        }

    }
}
