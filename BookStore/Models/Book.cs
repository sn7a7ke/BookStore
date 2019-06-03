using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class Book : BaseEntity
    {        
        public string Title { get; set; }

        public string Authors { get; set; }

        public string Tag { get; set; }

        public DateTime CreateDate { get; set; }
    }
}