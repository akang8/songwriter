using AutoMapper;
using SongWriter.Logic.Mapping;
using System;
using System.Collections.Generic;
using System.Text;

namespace SongWriter.Logic.Startup
{
    public static class MappingInitializer
    {
        public static void Initialize()
        {
            var assembly = typeof(MappingInitializer).Assembly;

            Mapper.Initialize(cfg =>
            {
                cfg.AddProfiles(assembly);
            });
        }
    }
}
