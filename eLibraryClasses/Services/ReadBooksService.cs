using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLibraryClasses.DataAccess;
using eLibraryClasses.Interfaces;

namespace eLibraryClasses.Services
{
    public class ReadBooksService : IReadBooksService
    {
        //Randomize order of list of quotes and change text of label to quote
        public string RandomizeAndReturnQuote()
        {
            List<string> quotes = GlobalConfig.QuotesFile.FullFilePath().LoadFile().ConvertToQuoteModels();

            //Sort the list randomly
            quotes = quotes.OrderBy(o => Guid.NewGuid()).ToList();

            return quotes[0];
        }
    }
}
