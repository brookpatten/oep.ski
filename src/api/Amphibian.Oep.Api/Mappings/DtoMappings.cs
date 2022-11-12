using Amphibian.Oep.Api.Dtos;
using Amphibian.Oep.Api.Models;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Amphibian.Oep.Api.Mappings
{
    public static class DtoMappings
    {
        public static IServiceCollection AddMappings(this IServiceCollection services)
        {
            var configuration = GetMapperConfiguration();
            return services.AddTransient<IMapper>(p => configuration.CreateMapper());
        }

        public static MapperConfiguration GetMapperConfiguration()
        {
            var configuration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserIdentifier>();
                
            });
            return configuration;
        }
    }
}
