using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace BookStore.Models
{


    public class BaseBookViewModel : BaseEntity
    {
        [DataType(DataType.Text)]
        public string Title { get; set; }

        [DataType(DataType.Text)]
        public string Authors { get; set; }

        [DataType(DataType.MultilineText)]
        [Display(Name = "Tag of book")]
        public string Tag { get; set; }
    }


    public class IndexBookViewModel : BaseBookViewModel
    {
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of creation")]
        public DateTime CreateDate { get; set; }
    }

    public class DetailsBookViewModel : BaseBookViewModel
    {
        [DataType(DataType.DateTime)]
        [Display(Name = "Date of creation")]
        public DateTime CreateDate { get; set; }
    }

    public class CreateBookViewModel : BaseBookViewModel
    {
    }

    public class EditBookViewModel : BaseBookViewModel
    {
    }

    public class DeleteBookViewModel : BaseBookViewModel
    {
    }
}