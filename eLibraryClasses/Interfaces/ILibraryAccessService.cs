using System;
using System.Collections.Generic;
using System.Text;
using eLibraryClasses.Models;

namespace eLibraryClasses.Interfaces
{
    public interface ILibraryAccessService
    {
        UserModel UserLoginIn(string userName, string password);
    }
}
