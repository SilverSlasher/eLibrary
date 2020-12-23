using eLibraryClasses.Models;
using eLibraryClasses.UI_Forms_Logic.Services;

namespace eLibraryClasses.UI_Forms_Logic.Interfaces
{
    public interface IStatisticsService
    {
        void PreventNullError(UserModel loggedUser);

        string GetReadPages(UserModel loggedUser);

        string GetToReadPages(UserModel loggedUser);


        string GetNumberOfFavoriteAuthors(UserModel loggedUser);


        string GetFavoriteGenre(UserModel loggedUser);

        StatisticsService.Genres SetStartingValuesOfGenres();

    }
}
