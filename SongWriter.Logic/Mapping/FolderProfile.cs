using AutoMapper;
using System;
using System.Collections.Generic;
using System.Text;
using data = SongWriter.Data.Models;
using SongWriter.Logic.Models;


namespace SongWriter.Logic.Mapping
{
    public class FolderProfile : Profile
    {
        public FolderProfile()
        {
            this.CreateMap<data.Folder, Folder>();
            this.CreateMap<Folder, data.Folder>()
                            .ForMember(m => m.Documents, o => o.Ignore());
        }
    }
}
