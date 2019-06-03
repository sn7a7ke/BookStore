using AutoMapper;
using BookStore.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Models
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Book, IndexBookViewModel>();

            CreateMap<Book, DetailsBookViewModel>();

            CreateMap<CreateBookViewModel, Book>();

            CreateMap<EditBookViewModel, Book>();

            CreateMap<Book, EditBookViewModel>();

            CreateMap<DeleteBookViewModel, Book>();

            CreateMap<Book, DeleteBookViewModel>();
        }
    }
}