using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.Models;
using eLibraryClasses.Services;

namespace eLibraryClasses.Interfaces
{
    public interface IStatisticsService
    {
        void PreventNullError(ref UserModel loggedUser);

        string GetReadPages(UserModel loggedUser);

        string GetToReadPages(UserModel loggedUser);


        string GetNumberOfFavoriteAuthors(UserModel loggedUser);


        string GetFavoriteGenre(UserModel loggedUser);

        StatisticsService.Genres SetStartingValuesOfGenres();

    }
}
