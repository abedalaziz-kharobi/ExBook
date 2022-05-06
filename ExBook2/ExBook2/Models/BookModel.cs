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
        public int Salary { get; set; }
        public string MyCollege { get; set; }

        public string SelectedCollege { get; set; }
        public string value { get; set; }
        public string CollegeList { get; set; }

        public string Description { get; set; } //Changeable
        // image ?
    }
}