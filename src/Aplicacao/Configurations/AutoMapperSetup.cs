using System;
using Aplicacao.Application.AutoMapper;
using AutoMapper;
using Microsoft.Extensions.DependencyInjection;

namespace Aplicacao.Configurations
{
    public static class AutoMapperSetup
    {
        public static void AddAutoMapperSetup(this IServiceCollection services)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddAutoMapper(typeof(Startup).Assembly);

            // Registering Mappings automatically only works if the
            // Automapper Profile classes are in ASP.NET project
            var config = AutoMapperConfig.RegisterMappings();
            var mapper = config.CreateMapper();
            services.AddSingleton(mapper);
        }
    }
}
