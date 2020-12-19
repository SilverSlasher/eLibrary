using System;
using System.Collections.Generic;
using System.Text;

namespace eLibraryClasses.Interfaces
{
    public interface IRemindAccountService
    {
        void RemindEmail(string emailAddress);
    }
}
