using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace eLibraryClasses.Models
{
    public class BookModel
    {
        //Unique Id of the book
        public int Id { get; set; }
        //Author name of the book
        public string Author { get; set; }
        //Title of the book
        public string Title { get; set; }
        //Genre of the book
        public string Genre { get; set; }
        //Number of pages of the book
        public int Pages { get; set; }
        //Description of the book
        public string Description { get; set; }

        public BookModel()
        {

        }

        public BookModel(string author, string title, string genre, string pages,string description)
        {
            Author = author;

            Title = title;

            Genre = genre;

            int pagesValue = 0;

            int.TryParse(pages, out pagesValue);

            Pages = pagesValue;

            Description = description;

        }
    }
}
