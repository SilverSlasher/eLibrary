using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using eLibraryClasses.DataAccess;

namespace eLibraryClasses.UserInterfaceServices
{
    public class ReadBooksService
    {
        //Randomize order of list of quotes and change text of label to quote
        public string RandomizeAndReturnQuote()
        {
            //Create a list of quotes and fill it from file .txt
            List<string> quotes = GlobalConfig.QuotesFile.FullFilePath().LoadFile().ConvertToQuoteModels();
            //Sort the list randomly
            quotes = quotes.OrderBy(o => Guid.NewGuid()).ToList();
            return quotes[0];
        }
    }
}
