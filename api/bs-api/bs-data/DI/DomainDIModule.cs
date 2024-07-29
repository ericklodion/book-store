﻿using bs_data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace bs_data.DI
{
    public static class DomainDIModule
    {
        public static IServiceCollection AddAppDbContext(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<BookReporitory>();
            services.AddScoped<SubjectReporitory>();
            services.AddScoped<AuthorReporitory>();
            services.AddScoped<PriceTableReporitory>();

            services.AddScoped<UnitOfWork>();

            return services;
        }
    }
}