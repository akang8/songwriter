using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using SongWriter.Core;
using SongWriter.Data;
using SongWriter.Logic.Services;
using SongWriter.Logic.Services.Abstractions;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.DependencyConfiguration
{
    public static class DependencyInitializer
    {
        public static void AddSongWriterLogic(this IServiceCollection services)
        {
            services
                .AddScoped<AppDbContext>()
                .AddScoped(s =>
                {
                    var dbOptionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
                    var appOptions = s.GetService<IOptions<AppConfiguration>>();
                    dbOptionsBuilder.UseSqlServer(appOptions.Value.ConnectionString);

                    return dbOptionsBuilder.Options;
                });

            services.AddScoped<IDocumentService, DocumentService>();
        }
    }
}
