using System;
using System.Collections.Generic;
using System.Text;

namespace ExBook2.Models
{
    internal class BookModel
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public int EditionNumber { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public int salary { get; set; }
        public string CollegeName { get; set; }
        public string Description { get; set; } //Changeable
        // image ?
    }
}
