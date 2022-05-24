using AutoMapper;
using GloboTicket.TicketManagement.Application.Profiles;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace GloboTicket.TicketManagement.Application
{
    // this class register services of this project into service collection in the 
    // asp.net core project, this will be implemented by extension method 
    public static class ApplicationServiceRegisteration
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services) 
        {
            //var mappingConfig = new MapperConfiguration(x => x.AddProfile(new MappingProfile()));
            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);
            var x = Assembly.GetExecutingAssembly();
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            return services;
        }
    }
}
