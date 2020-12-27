using System;
using System.Collections.Generic;
using System.Linq;
using eLibraryClasses.DataAccess;
using eLibraryClasses.UI_Forms_Logic.Interfaces;

namespace eLibraryClasses.UI_Forms_Logic.Services
{
    public class ReadBooksService : IReadBooksService
    {
        private readonly IDataConnection _dataConnection;

        public ReadBooksService(IDataConnection dataConnection)
        {
            _dataConnection = dataConnection;
        }
        //Randomize order of list of quotes and change text of label to quote
        public string RandomizeAndReturnQuote()
        {
            List<string> quotes = _dataConnection.GetQuotes_All();

            //Sort the list randomly
            quotes = quotes.OrderBy(o => Guid.NewGuid()).ToList();

            return quotes[0];
        }
    }
}
