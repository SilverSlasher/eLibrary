using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;

namespace eLibraryClasses.Models
{
    public class BookModel
    {
        public int Id { get; set; }
        public string Author { get; set; }
        public string Title { get; set; }
        public string Genre { get; set; }
        public int Pages { get; set; }
        public string Description { get; set; }

        public BookModel()
        {

        }

        public BookModel(string author, string title, string genre, string pages,string description)
        {
            Author = author;

            Title = title;

            Genre = genre;

            int.TryParse(pages, out int pagesValue);

            Pages = pagesValue;

            Description = description;

        }
    }
}
