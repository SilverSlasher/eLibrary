using eLibraryClasses.Models;

namespace eLibraryClasses.UI_Forms_Logic.Interfaces
{
    public interface ILibraryAccessService
    {
        UserModel UserLoginIn(string userName, string password);
    }
}
