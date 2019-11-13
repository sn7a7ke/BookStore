using AutoMapper;
using BookStore.DAL;
using BookStore.Models;
using Ninject;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace BookStore.Util
{
    public class AutoMapperModule : NinjectModule
    {
        public override void Load()
        {
            //Bind<IValueResolver<SourceEntity, DestModel, bool>>().To<MyResolver>();
            Bind<IUnitOfWork>().To<UnitOfWork>();


            var mapperConfiguration = CreateConfiguration();
            Bind<MapperConfiguration>().ToConstant(mapperConfiguration).InSingletonScope();

            // This teaches Ninject how to create automapper instances say if for instance
            // MyResolver has a constructor with a parameter that needs to be injected
            Bind<IMapper>().ToMethod(ctx =>
                 new Mapper(mapperConfiguration, type => ctx.Kernel.Get(type)));
        }

        private MapperConfiguration CreateConfiguration()
        {
            var config = new MapperConfiguration(cfg => cfg.AddProfile(new MappingProfile()));

            return config;
        }
    }
}