using System;
using System.Collections.Generic;
using System.Configuration;
using System.Text;
using eLibraryClasses.DataAccess;
using Microsoft.IdentityModel.Protocols;
using NLog.Internal;


namespace eLibraryClasses
{
    public static class GlobalConfig
    {
        //Name of the file with saved users
        public const string UsersFile = "UsersFile.txt";
        //Name of the file with saved books
        public const string BooksFile = "BooksFile.txt";
        //Name of the file with saved quotes
        public const string QuotesFile = "QuotesFile.txt";
        //Name of the file with saved quiz questions and answers
        public const string QuizFile = "QuizFile.txt";


        
        public static IDataConnection Connection { get; private set; }

        //Creating connections between application and files
        public static void InitializeConnections()
        {
            FilesConnector text = new FilesConnector();
            Connection = text;
        }

        //Configure key for email connection working properly
        public static string AppKeyLookup(string key)
        {
            return ConfigurationManager.AppSettings[key];
        }
    }
}
