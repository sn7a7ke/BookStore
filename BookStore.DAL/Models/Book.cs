using System;

namespace BookStore.DAL.Models
{
    public class Book : BaseEntity
    {        
        public string Title { get; set; }

        public string Description { get; set; }

        public string Authors { get; set; }

        public string Tag { get; set; }

        public DateTime CreateDate { get; set; }
    }
}